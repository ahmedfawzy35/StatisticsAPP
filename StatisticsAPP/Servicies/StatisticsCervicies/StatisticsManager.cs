using Microsoft.EntityFrameworkCore;
using StatisticsAPP.Data;
using StatisticsAPP.Models.CircleModels;
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

            circleDay.Year = circleStatistics.Year;
            circleDay.Month = circleStatistics.Month;
            circleDay.Judges = await GetCircleJugesAsync(circleId, new DateTime(year, month, 30));
            var StaticsForYears = new List<StatistaicsDto>();


            foreach (var caseYear in caseYears)
            {
                StaticsForYears.Add(setStatistaicsDto(circleStatistics, caseYear , sapek));
            }

            circleDay.StaticsForYear = StaticsForYears;


            return circleDay;
        }
        public async Task<List<Judge>> GetCircleJugesAsync(int IdCircle, DateTime date)
        {

            // TO DO
            return new List<Judge>();
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
    }
}
