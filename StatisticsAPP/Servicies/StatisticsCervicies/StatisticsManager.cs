using Microsoft.EntityFrameworkCore;
using StatisticsAPP.Data;
using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Models.DecisionModels;
using StatisticsAPP.Models.JudgeModels;
using StatisticsAPP.Models.StatisticsModels;
using StatisticsAPP.Servicies.StatisticsCervicies.DTOS;
using StatisticsAPP.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Servicies.StatisticsCervicies
{
    public class StatisticsManager
    {
        private readonly ApplicationDbContext _context;
        private string _ModelCode = MyStrings.ModulsName.GetModulesCode(MyStrings.ModulsName.User);
        private string _ModelName = MyStrings.ModulsName.User;

        public StatisticsManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<StatistaicsDto> StatisticsList()
        {
            List<StatistaicsDto> statisticsList = new List<StatistaicsDto>();
            for (int i = 0; i < 6; i++)
            {
                statisticsList.Add(new StatistaicsDto
                {
                    Year = 2023 + i,
                    Sapek = 10 + i,
                    MogaddMenShatb = 20 + i,
                    moagalMenAlwakfLhinAlfasl = 30 + i,
                    moagalMenAlwakfGzaey = 40 + i,
                    moagalMenAlwakfTaeliky = 50 + i,
                    moagalMenAlwakfItfaky = 60 + i,
                    moagalMenAlEnktae = 70 + i,
                    MoadMenAlEstenf = 80 + i,
                    TaksirCount = 90 + i,
                    TaksirMonth = 100 + i,
                    EhalaForm = 110 + i,
                    ehalaTo = 120 + i,
                    newCases = 130 + i,
                    Mashtob = 140 + i,
                    Shakly = 150 + i,
                    Mawdoey = 160 + i,
                    Solh = 170 + i,
                    Farey = 180 + i,
                    Khapir = 190 + i,
                    BackToKhapir = 200 + i,
                    Tahkik = 210 + i,
                });
            }
            return statisticsList;
        }
        public async Task<CircleDayStatistaicsDto> GetStatistaicsDtoAsync(int circledayId, int circleId, int month, int year)
        {
            var circleStatistics = await MyContext.context.CircleStatistics
               .Include(x => x.StatisticsDecisions!)
                   .ThenInclude(x => x.CaseYear!)
               .Include(x => x.StatisticsDecisions!)
                   .ThenInclude(x => x.Decision!)
                         .ThenInclude(x => x.DecisionCategory!)
               .Include(x => x.StatisticsInterCases!)
                   .ThenInclude(x => x.CaseYear!)
               .Include(x => x.StatisticsDelayCases!)
                   .ThenInclude(x => x.CaseYear!)
               .Include(x => x.CircleDay!)
                   .ThenInclude(x => x.DelayCacesForMonths!)
               .Include(x => x.StatisticsDeleted!)
                   .ThenInclude(x => x.CaseYear!)
               .Include(x => x.Shortening!)
                   .ThenInclude(x => x.CaseYear!)
               .FirstOrDefaultAsync(x => x.IdCircleDay == circledayId && x.Year == year && x.Month == month);

            var sapek = await _context.DelayCacesForMonths.Include(x=>x.CaseYear!)
                .Where(x => x.IdCircleDay == circledayId  && x.Month == month && x.Year == year)
                .ToListAsync();
            var caseYearsNotSorted = await _context.CaseYears.Where(x => x.Year >= circleStatistics!.StartCaseYear && x.Year <= circleStatistics.EndCaseYear).ToListAsync();
            var caseYears = caseYearsNotSorted.OrderBy(x => x.Year);
            if (circleStatistics == null) return null;

            CircleDayStatistaicsDto circleDay = new CircleDayStatistaicsDto();

           
            var StaticsForYears = new List<StatistaicsDto>();
            var circl = await _context.Circles
                .Include(x => x.CircleCategory!)
                .FirstOrDefaultAsync(x => x.Id == circleId);
            var mycircleday = await _context.CircleDays
                .Include(x => x.CircleType!)
                .ThenInclude(x => x.CircleMasterType!)
                .FirstOrDefaultAsync(x => x.Id == circledayId);

            foreach (var caseYear in caseYears)
            {
                StaticsForYears.Add(setStatistaicsDto(circleStatistics, caseYear , sapek));
            }
            circleDay.Year = circleStatistics.Year;
            circleDay.Month = circleStatistics.Month;
            circleDay.IdCircleDay = circleStatistics.IdCircleDay;
            circleDay.IdCircle = circleStatistics.CircleDay!.CircleId;
            circleDay.StartCaseYear = circleStatistics.StartCaseYear;
            circleDay.EndCaseYear = circleStatistics.EndCaseYear;
            circleDay.CountCaseYear = caseYears.Count();
            circleDay.CircleCategory = circl!.CircleCategory;
            circleDay.CircleType = mycircleday!.CircleType;
            circleDay.CircleMasterType = mycircleday.CircleType!.CircleMasterType!;

            circleDay.StaticsForYear = StaticsForYears;
            circleDay.Judges = await GetCircleJugesAsync(circleId, new DateTime(year, month, 30));
            foreach (var judge in circleDay.Judges)
            {
                if (judge.Rate == 1)
                {
                    circleDay.JudgeDecision1 = setJudgesDeccisionsDto(1, circleStatistics.StatisticsDecisions!.ToList()!, caseYears.ToList());

                }
                else if (judge.Rate == 2)
                {
                    circleDay.JudgeDecision2 = setJudgesDeccisionsDto(2, circleStatistics.StatisticsDecisions!.ToList()!, caseYears.ToList());
                }
                else if (judge.Rate == 3)
                {
                    circleDay.JudgeDecision3 = setJudgesDeccisionsDto(3, circleStatistics.StatisticsDecisions!.ToList()!, caseYears.ToList());
                }
                else if (judge.Rate == 4)
                {
                    circleDay.JudgeDecision4 = setJudgesDeccisionsDto(4, circleStatistics.StatisticsDecisions!.ToList()!, caseYears.ToList());
                }
            }

            return circleDay;
        }
        public async Task<List<CircleJudge>> GetCircleJugesAsync(int IdCircle, DateTime date)
        {

            var hudjes =await _context.CircleJudges
                .Include(x => x.Judge!)
                .Include(x => x.Circle!)
                .Where(x => x.Circle!.Id == IdCircle && x.DateStart <= date.Date && (x.DateEnd == null || x.DateEnd >= date.Date))
                .ToListAsync();
            return hudjes.OrderBy(x=>x.Rate).ToList();
        }
        private StatistaicsDto setStatistaicsDto(CircleStatistics circleStatistics, CaseYear caseYear ,List< DelayCacesForMonth> sapek)
        {
            StatistaicsDto statistaicsDto = new StatistaicsDto();
            if (caseYear.IsOld)
            {
                statistaicsDto.Year = caseYear.Year;
                statistaicsDto.Sapek = sapek.Where(x=>x.CaseYear!.Year == caseYear.Year).Sum(x=>x.Count);
                statistaicsDto.MogaddMenShatb = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.MogaddMenShatb).Sum(x=>x.Count);
                statistaicsDto.moagalMenAlwakfLhinAlfasl = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.moagalMenAlwakfLhinAlfasl).Sum(x=>x.Count);
                statistaicsDto.moagalMenAlwakfGzaey = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.moagalMenAlwakfGzaey).Sum(x=>x.Count);
                statistaicsDto.moagalMenAlwakfTaeliky = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.moagalMenAlwakfTaeliky).Sum(x=>x.Count);
                statistaicsDto.moagalMenAlwakfItfaky = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.moagalMenAlwakfItfaky).Sum(x=>x.Count);
                statistaicsDto.moagalMenAlEnktae = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.moagalMenAlEnktae).Sum(x=>x.Count);
                statistaicsDto.MoadMenAlEstenf = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.MoadMenAlEstenf).Sum(x=>x.Count);
                statistaicsDto.EhalaForm = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.EhalaForm).Sum(x=>x.Count);
                statistaicsDto.EhalaForm = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.ehalaTo).Sum(x=>x.Count);
                statistaicsDto.newCases = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.newCases).Sum(x=>x.Count);
                statistaicsDto.TaksirCount = circleStatistics.Shortening!.Where(x => x.CaseYear!.Year <= caseYear.Year).Sum(x=>x.Count);
                statistaicsDto.Mashtob = circleStatistics.StatisticsDeleted!.Where(x => x.CaseYear!.Year <= caseYear.Year).Sum(x=>x.Count);
                statistaicsDto.Shakly = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionKateyTypes.Shakly).Sum(x=>x.Count);
                statistaicsDto.Mawdoey = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionKateyTypes.Mawdoey).Sum(x=>x.Count);
                statistaicsDto.Solh = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionKateyTypes.Solh).Sum(x=>x.Count);
                statistaicsDto.Farey = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionFareyTypes.Farey).Sum(x=>x.Count);
                statistaicsDto.Khapir = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionEthbatTypes.Khapir).Sum(x=>x.Count);
                statistaicsDto.BackToKhapir = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionEthbatTypes.BackToKhapir).Sum(x=>x.Count);
                statistaicsDto.Tahkik = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionEthbatTypes.Tahkik).Sum(x=>x.Count);
                statistaicsDto.Estgwap = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionEthbatTypes.Estgwap).Sum(x=>x.Count);
                statistaicsDto.HelfYamin = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionEthbatTypes.HelfYamin).Sum(x=>x.Count);
                statistaicsDto.WakfGazaey = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionWakftTypes.WakfGazaey).Sum(x=>x.Count);
                statistaicsDto.WakfTaeliky = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionWakftTypes.WakfTaeliky).Sum(x=>x.Count);
                statistaicsDto.EnktaeSirAlKhsoma = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionEnktaeSirAlKhsomaTypes.EnktaeSirAlKhsoma).Sum(x=>x.Count);
                statistaicsDto.MahguzLelHokm = circleStatistics.StatisticsDelayCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.DelayCase!.Name! == MyStrings.DelayCacesypes.MahguzLelHokm).Sum(x=>x.Count);
                statistaicsDto.MadAgal = circleStatistics.StatisticsDelayCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.DelayCase!.Name! == MyStrings.DelayCacesypes.MadAgal).Sum(x=>x.Count);
                statistaicsDto.EadaLelMorafea = circleStatistics.StatisticsDelayCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.DelayCase!.Name! == MyStrings.DelayCacesypes.MadAgal).Sum(x=>x.Count);
                statistaicsDto.MoeagalLelTkrir = circleStatistics.StatisticsDelayCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.DelayCase!.Name! == MyStrings.DelayCacesypes.MoeagalLelTkrir).Sum(x=>x.Count);
                statistaicsDto.Okhrah = circleStatistics.StatisticsDelayCases!.Where(x => x.CaseYear!.Year <= caseYear.Year && x.DelayCase!.Name! == MyStrings.DelayCacesypes.Okhrah).Sum(x=>x.Count);



            }
            else
            {

            }

            return statistaicsDto;

        }
        public  List<JudgesDeccisionDto> setJudgesDeccisionsDto(int JudgeId , List<StatisticsDecisions> decisions , List<CaseYear> years)
        {
            var judgeDecisions = new List<JudgesDeccisionDto>();

            foreach (var year in years)
            {
                var judgeDecision = new JudgesDeccisionDto();
                judgeDecision.Year = year.Year;
                judgeDecision.AdmKbol = decisions.Where(x=>x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_ShaklyTypes.AdmKbol).Sum(x => x.Count);
                judgeDecision.AdmEjhtsas = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_ShaklyTypes.AdmEjhtsas).Sum(x => x.Count);
                judgeDecision.SkotAlHakFiRAFEAlDaewa = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_ShaklyTypes.SkotAlHakFiRAFEAlDaewa).Sum(x => x.Count);
                judgeDecision.SkotAlKhsomaWEnkdaeha = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_ShaklyTypes.SkotAlKhsomaWEnkdaeha).Sum(x => x.Count);
                judgeDecision.TarkAlKhsoma = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_ShaklyTypes.TarkAlKhsoma).Sum(x => x.Count);
                judgeDecision.EnedamAlKhsoma = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_ShaklyTypes.EnedamAlKhsoma).Sum(x => x.Count);
                judgeDecision.KanLamTkon = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_ShaklyTypes.KanLamTkon).Sum(x => x.Count);
                judgeDecision.Kbol = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_MawdoeyTypes.Kbol).Sum(x => x.Count);
                judgeDecision.Rafd = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_MawdoeyTypes.Rafd).Sum(x => x.Count);
                judgeDecision.RafdBeHalatha = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_MawdoeyTypes.RafdBeHalatha).Sum(x => x.Count);
                judgeDecision.AdamGwazLeSabekatAlFaslFiha = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_MawdoeyTypes.AdamGwazLeSabekatAlFaslFiha).Sum(x => x.Count);
                judgeDecision.EnkdaeAlhakBeModiAlModa = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_MawdoeyTypes.EnkdaeAlhakBeModiAlModa).Sum(x => x.Count);
                judgeDecision.Solh = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_MawdoeyTypes.Solh).Sum(x => x.Count);
                judgeDecision.Farey = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionFareyTypes.Farey).Sum(x => x.Count);
                judgeDecision.NadbKhabir = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionEthbatTypes.Khapir).Sum(x => x.Count);
                judgeDecision.BackTOKhabir = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionEthbatTypes.BackToKhapir).Sum(x => x.Count);
                judgeDecision.Tahkik = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionEthbatTypes.Tahkik).Sum(x => x.Count);
                judgeDecision.Estgwab = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionEthbatTypes.Estgwap).Sum(x => x.Count);
                judgeDecision.HelfYamin = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionEthbatTypes.HelfYamin).Sum(x => x.Count);
                judgeDecision.WakfGazaey = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionWakftTypes.WakfGazaey).Sum(x => x.Count);
                judgeDecision.WakfTaeliky = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionWakftTypes.WakfTaeliky).Sum(x => x.Count);
                judgeDecision.WakfEtifaky = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionWakftTypes.WakfEtfaky).Sum(x => x.Count);
                judgeDecision.EnktaeSirAlKhsoma = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionEnktaeSirAlKhsomaTypes.EnktaeSirAlKhsoma).Sum(x => x.Count);
                judgeDecision.MadAgal = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionMadAgalTypes.MadAgal).Sum(x => x.Count);
                judgeDecision.EadaLelMorafea = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionEadaLeMorafeaTypes.EadaLelMorafea).Sum(x => x.Count);

                judgeDecisions.Add(judgeDecision);
            }



            return  judgeDecisions;

        }


    }
}
