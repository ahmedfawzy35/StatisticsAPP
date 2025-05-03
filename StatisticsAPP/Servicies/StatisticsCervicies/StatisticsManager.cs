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
        public async Task<CircleDayStatistaicsDto> GetStatistaicsDtoAsync(int circledayId ,int circleId, int month , int  year)
        {
           var circleStatistics = await MyContext.context.CircleStatistics
              .Include(x => x.StatisticsDecisions!)
                  .ThenInclude(x => x.CaseYear!)
              .Include(x => x.StatisticsInterCases!)
                  .ThenInclude(x => x.CaseYear!)
              .Include(x => x.StatisticsDelayCases!)
                  .ThenInclude(x => x.CaseYear!)
            .Include(x => x.CircleDay!)
                  .ThenInclude(x => x.DelayCacesForMonths!)
              .FirstOrDefaultAsync(x => x.IdCircleDay == circledayId && x.Year ==year && x.Month == month);


            var caseYears = _context.CaseYears.Where(x=>x.Enabled).ToList().OrderBy(x=>x.Year);
            if (circleStatistics == null) return null;

            CircleDayStatistaicsDto circleDay = new CircleDayStatistaicsDto();

            circleDay.Year = circleStatistics.Year;
            circleDay.Month = circleStatistics.Month;
            circleDay.Judges = await GetCircleJugesAsync(circleId, new DateTime(year,month,30));
            var  StaticsForYears = new List<StatistaicsDto>();
          

            foreach (var caseYear in caseYears)
            {
                StaticsForYears.Add(setStatistaicsDto(circleStatistics, caseYear));
            }
            return circleDay;
        }
        public async Task<List< Judge>> GetCircleJugesAsync(int IdCircle , DateTime date)
        {


            return new List<Judge>();
        }
        private StatistaicsDto setStatistaicsDto(CircleStatistics circleStatistics , CaseYear caseYear)
        {
            StatistaicsDto statistaicsDto = new StatistaicsDto();
            if (caseYear.IsOld )
            {
                statistaicsDto.Year = caseYear.Year;
                // statistaicsDto.Sapek = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year && x.CaseYear.IsOld == false).Count();
                statistaicsDto.MogaddMenShatb = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear.Year<=caseYear.Year & x.InterCase.Name ==MyStrings.InterCasesTypes.MogaddMenShatb).Count();
                //statistaicsDto.moagalMenAlwakfLhinAlfasl = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.CaseYear.IsOld == false).Count();
                //statistaicsDto.moagalMenAlwakfGzaey = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.CaseYear.IsOld == true).Count();
                //statistaicsDto.moagalMenAlwakfTaeliky = circleStatistics.StatisticsDelayCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.CaseYear.IsOld == false).Count();
                //statistaicsDto.moagalMenAlwakfItfaky = circleStatistics.StatisticsDelayCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.CaseYear.IsOld == true).Count();
                //statistaicsDto.moagalMenAlEnktae = circleStatistics.DelayCacesForMonths!.Where(x => x.CaseYear!.Year == caseYear.Year && x.CaseYear.IsOld == false).Count();
                //statistaicsDto.MoadMenAlEstenf = circleStatistics.DelayCacesForMonths!.Where(x => x.CaseYear!.Year == caseYear.Year && x.CaseYear.IsOld == true).Count();
            }
            else
            {

            }
               
            return statistaicsDto;

        }
    }
}
