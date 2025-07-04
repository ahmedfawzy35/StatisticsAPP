using Microsoft.EntityFrameworkCore;
using StatisticsAPP.Data;
using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Models.DecisionModels;
using StatisticsAPP.Models.InterCasesModels;
using StatisticsAPP.Models.JudgeModels;
using StatisticsAPP.Models.StatisticsModels;
using StatisticsAPP.Servicies.StatisticsCervicies.DTOS;
using StatisticsAPP.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StatisticsAPP.Utility.MyStrings;

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

        public async Task SaveStatistic(CircleDayStatistaicsDto circleStatistics)
        {
            var circleStatistic = await GetStatistaicAsync(circleStatistics.IdCircleDay, circleStatistics.Year, circleStatistics.Month);
            if (circleStatistic != null)
            {
                var years = await _context.CaseYears
                    .Where(x => (x.Year >= circleStatistic.StartCaseYear || x.Year <= circleStatistic.EndCaseYear) && x.Enabled )
                    .ToListAsync();
                var interCasesType = await _context.InterCases.ToListAsync();
                List<StatisticsInterCases> interCases = new List<StatisticsInterCases>();

                if (circleStatistic.IsNew)
                {
                    circleStatistic.IsNew = false;
                    foreach (var statistic in circleStatistics.StaticsForYear!)
                    {

                        if (statistic.IsTotalRow == 1)
                        {
                            continue;
                        }
                        CaseYear caseYear = years.FirstOrDefault(x => x.Year == statistic.Year)!;
                        if (statistic.MogaddMenShatb > 0)
                        {
                            interCases.Add(new StatisticsInterCases
                            {
                                Count = statistic.MogaddMenShatb,
                                CircleStatistics = circleStatistic,
                                CaseYearId = caseYear.Id,
                                IdInterCase = interCasesType!.Where(x => x.Name == MyStrings.InterCasesTypes.MogaddMenShatb).FirstOrDefault().Id,
                                IdCircleStatistics = circleStatistic.Id,
                                UserId = LocalUser.localUserId,
                                CreatedAt = DateTime.Now
                            });

                          
                        }
                        if (statistic.moagalMenAlwakfLhinAlfasl > 0)
                        {
                            interCases.Add(new StatisticsInterCases
                            {
                                Count = statistic.moagalMenAlwakfLhinAlfasl,
                                CircleStatistics = circleStatistic,
                                CaseYearId = caseYear.Id,
                                IdInterCase = interCasesType!.Where(x => x.Name == MyStrings.InterCasesTypes.moagalMenAlwakfLhinAlfasl).FirstOrDefault().Id,
                                IdCircleStatistics = circleStatistic.Id,
                                UserId = LocalUser.localUserId,
                                CreatedAt = DateTime.Now
                            });
                        }
                        if (statistic.moagalMenAlwakfGzaey > 0)
                        {
                            interCases.Add(new StatisticsInterCases
                            {
                                Count = statistic.moagalMenAlwakfGzaey,
                                CircleStatistics = circleStatistic,
                                CaseYearId = caseYear.Id,
                                IdInterCase = interCasesType!.Where(x => x.Name == MyStrings.InterCasesTypes.moagalMenAlwakfGzaey).FirstOrDefault().Id,
                                IdCircleStatistics = circleStatistic.Id,
                                UserId = LocalUser.localUserId,
                                CreatedAt = DateTime.Now
                            });
                        }
                        if (statistic.moagalMenAlwakfTaeliky > 0)
                        {
                            interCases.Add(new StatisticsInterCases
                            {
                                Count = statistic.moagalMenAlwakfTaeliky,
                                CircleStatistics = circleStatistic,
                                CaseYearId = caseYear.Id,
                                IdInterCase = interCasesType!.Where(x => x.Name == MyStrings.InterCasesTypes.moagalMenAlwakfTaeliky).FirstOrDefault().Id,
                                IdCircleStatistics = circleStatistic.Id,
                                UserId = LocalUser.localUserId,
                                CreatedAt = DateTime.Now
                            });
                        }
                        if (statistic.moagalMenAlwakfItfaky > 0)
                        {
                            interCases.Add(new StatisticsInterCases
                            {
                                Count = statistic.moagalMenAlwakfItfaky,
                                CircleStatistics = circleStatistic,
                                CaseYearId = caseYear.Id,
                                IdInterCase = interCasesType!.Where(x => x.Name == MyStrings.InterCasesTypes.moagalMenAlwakfItfaky).FirstOrDefault().Id,
                                IdCircleStatistics = circleStatistic.Id,
                                UserId = LocalUser.localUserId,
                                CreatedAt = DateTime.Now
                            });
                        }
                        if (statistic.moagalMenAlEnktae > 0)
                        {
                            interCases.Add(new StatisticsInterCases
                            {
                                Count = statistic.moagalMenAlEnktae,
                                CircleStatistics = circleStatistic,
                                CaseYearId = caseYear.Id,
                                IdInterCase = interCasesType!.Where(x => x.Name == MyStrings.InterCasesTypes.moagalMenAlEnktae).FirstOrDefault().Id,
                                IdCircleStatistics = circleStatistic.Id,
                                UserId = LocalUser.localUserId,
                                CreatedAt = DateTime.Now
                            });

                        }
                        if (statistic.MoadMenAlEstenf > 0)
                        {
                            interCases.Add(new StatisticsInterCases
                            {
                                Count = statistic.MoadMenAlEstenf,
                                CircleStatistics = circleStatistic,
                                CaseYearId = caseYear.Id,
                                IdInterCase = interCasesType!.Where(x => x.Name == MyStrings.InterCasesTypes.MoadMenAlEstenf).FirstOrDefault().Id,
                                IdCircleStatistics = circleStatistic.Id,
                                UserId = LocalUser.localUserId,
                                CreatedAt = DateTime.Now
                            });

                        }
                        if (statistic.EhalaForm > 0)
                            {
                                interCases.Add(new StatisticsInterCases
                                {
                                    Count = statistic.EhalaForm,
                                    CircleStatistics = circleStatistic,
                                    CaseYearId = caseYear.Id,
                                    IdInterCase = interCasesType!.Where(x => x.Name == MyStrings.InterCasesTypes.EhalaForm).FirstOrDefault().Id,
                                    IdCircleStatistics = circleStatistic.Id,
                                    UserId = LocalUser.localUserId,
                                    CreatedAt = DateTime.Now
                                });

                         }
                        if (statistic.ehalaTo > 0)
                            {
                                interCases.Add(new StatisticsInterCases
                                {
                                    Count = statistic.ehalaTo,
                                    CircleStatistics = circleStatistic,
                                    CaseYearId = caseYear.Id,
                                    IdInterCase = interCasesType!.Where(x => x.Name == MyStrings.InterCasesTypes.ehalaTo).FirstOrDefault().Id,
                                    IdCircleStatistics = circleStatistic.Id,
                                    UserId = LocalUser.localUserId,
                                    CreatedAt = DateTime.Now
                                });

                         }
                        if (statistic.newCases > 0)
                            {
                                interCases.Add(new StatisticsInterCases
                                {
                                    Count = statistic.newCases,
                                    CircleStatistics = circleStatistic,
                                    CaseYearId = caseYear.Id,
                                    IdInterCase = interCasesType!.Where(x => x.Name == MyStrings.InterCasesTypes.newCases).FirstOrDefault().Id,
                                    IdCircleStatistics = circleStatistic.Id,
                                    UserId = LocalUser.localUserId,
                                    CreatedAt = DateTime.Now
                                });

                         }
                       
                       
                        if (statistic.TaksirCount > 0)
                            {
                               var shorting =new Shortening
                               {
                                    Count = statistic.TaksirCount,
                                    CircleStatistics = circleStatistic,
                                    Month = statistic.TaksirMonth,
                                    Year = statistic.TaksirMonth > circleStatistic.Month? circleStatistic.Year : circleStatistic.Year + 1,                                   
                                    CaseYearId = caseYear.Id,
                                    IdCircleStatistics = circleStatistic.Id,
                                    UserId = LocalUser.localUserId,
                                    CreatedAt = DateTime.Now

                                };
                            await _context.Shortenings.AddRangeAsync(shorting);

                        }



                    }


                    // _context.CircleStatistics.Update(circleStatistic);
                    try
                    {

                        if (interCases.Count > 1) await _context.StatisticsInterCases.AddRangeAsync(interCases);

                        await _context.SaveChangesAsync();
                        MessageBox.Show("تم حفظ الاحصائيات بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception x)
                    {

                        MessageBox.Show($"خطأ في حفظ الاحصائيات {x.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
                else
                {

                }
            }
        }

    
        
        public async Task<CircleStatistics> GetStatistaicAsync(int circledayId, int year, int month)
        {
            var circleStatistic = await _context.CircleStatistics
                .Include(x => x.StatisticsDecisions!)
                    .ThenInclude(x => x.CaseYear!)
                .Include(x => x.Sapek!).ThenInclude(x => x.CaseYear!)
                .Include(x => x.StatisticsDecisions!)
                    .ThenInclude(x => x.Decision!)
                        .ThenInclude(x => x.DecisionCategory!)
                .Include(x => x.StatisticsInterCases!)
                    .ThenInclude(x => x.CaseYear!)
                .Include(x => x.StatisticsDelayCases!)
                    .ThenInclude(x => x.CaseYear!)
                .Include(x => x.CircleDay!)
                    .ThenInclude(x => x.DelayCacesForMonths!)
                    .ThenInclude(x => x.CaseYear!)
                .Include(x => x.DelayCacesForMonths!)
                     .ThenInclude(x => x.DelayCacesForMonthType!)
                .Include(x => x.StatisticsDeleted!)
                    .ThenInclude(x => x.CaseYear!)
                .Include(x => x.Shortening!)
                    .ThenInclude(x => x.CaseYear!)
                .FirstOrDefaultAsync(x => x.IdCircleDay == circledayId && x.Year == year && x.Month == month);


            var StatisticsDecisions = await _context.StatisticsDecisions
                .Include(x => x.Decision!)
                    .ThenInclude(x => x.DecisionCategory!)
                .Where(x => x.IdCircleStatistics == circleStatistic!.Id)
                .ToListAsync();

            circleStatistic.StatisticsDecisions = StatisticsDecisions;
            var Sapek = await _context.Sapeks
                .Include(x => x.CaseYear!)
                .Where(x => x.IdCircleStatistics == circleStatistic.Id)
                .ToListAsync();
            circleStatistic.Sapek = Sapek;
            var StatisticsInterCases = await _context.StatisticsInterCases
                .Include(x => x.InterCase!)
                .Include(x => x.CaseYear!)
                .Where(x => x.IdCircleStatistics == circleStatistic.Id)
                .ToListAsync();
            circleStatistic.StatisticsInterCases = StatisticsInterCases;
            var StatisticsDelayCases = await _context.StatisticsDelayCases
                .Include(x => x.DelayCase!)
                .Include(x => x.CaseYear!)
                .Where(x => x.IdCircleStatistics == circleStatistic.Id)
                .ToListAsync();
            circleStatistic.StatisticsDelayCases = StatisticsDelayCases;
            var StatisticsDeleted = await _context.StatisticsDeleteds
                .Include(x => x.CaseYear!)
                .Where(x => x.IdCircleStatistics == circleStatistic.Id)
                .ToListAsync();
            circleStatistic.StatisticsDeleted = StatisticsDeleted;
            var Shortening = await _context.Shortenings
                .Include(x => x.CaseYear!)
                .Where(x => x.IdCircleStatistics == circleStatistic.Id)
                .ToListAsync();
            circleStatistic.Shortening = Shortening;

            if (circleStatistic == null) return null;
            var delayCacesForMonths = await _context.DelayCacesForMonths.Include(x => x.CaseYear!)
                .Where(x => x.IdCircleDay == circledayId)
                .ToListAsync();
            var caseYearsNotSorted = await _context.CaseYears.Where(x => x.Year >= circleStatistic!.StartCaseYear && x.Year <= circleStatistic.EndCaseYear).ToListAsync();
            var caseYears = caseYearsNotSorted.OrderBy(x => x.Year);
            if (circleStatistic == null) return null;
            return circleStatistic;
        }
        public async Task<CircleDayStatistaicsDto> GetStatistaicsDtoAsync(int circledayId, int circleId, int month, int year)
        {
            var circleStatistics = await GetStatistaicAsync(circledayId, year, month);
            if (circleStatistics == null) return null;
            var delayCacesForMonths = await _context.DelayCacesForMonths.Include(x => x.CaseYear!)
                .Where(x => x.IdCircleDay == circledayId && x.Month == month && x.Year == year)
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
                var static_for_year = setStatistaicsDto(circleStatistics, caseYear);
                if (circleStatistics.IsNew)
                    static_for_year.Sapek = CalcMokadam(delayCacesForMonths, circleStatistics.Year, circleStatistics.Month, caseYear);
                else
                {
                    if (circleStatistics.Sapek == null)
                    {
                        static_for_year.Sapek = 0;


                    }
                    else
                    {
                        static_for_year.Sapek = circleStatistics.Sapek!
                       .Where(x => x.CaseYear!.Year == caseYear.Year).FirstOrDefault() == null ? 0
                       :
                       circleStatistics.Sapek!
                       .Where(x => x.CaseYear!.Year == caseYear.Year).FirstOrDefault()
                       .Count;

                    }


                }
                StaticsForYears.Add(static_for_year);


            }
            #region Add Total Row
            var totalRow = GetTotalRowStatistaics(StaticsForYears);
            StaticsForYears.Add(totalRow);



            #endregion
            circleDay.IdCircleStatistaic = circleStatistics.Id;
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
                    var totalrow = GetTotalRowJudgesDeccision(circleDay.JudgeDecision1);
                    circleDay.JudgeDecision1.Add(totalrow);
                }
                else if (judge.Rate == 2)
                {
                    circleDay.JudgeDecision2 = setJudgesDeccisionsDto(2, circleStatistics.StatisticsDecisions!.ToList()!, caseYears.ToList());
                    var totalrow = GetTotalRowJudgesDeccision(circleDay.JudgeDecision2);
                    circleDay.JudgeDecision2.Add(totalrow);
                }
                else if (judge.Rate == 3)
                {
                    circleDay.JudgeDecision3 = setJudgesDeccisionsDto(3, circleStatistics.StatisticsDecisions!.ToList()!, caseYears.ToList());
                    var totalrow = GetTotalRowJudgesDeccision(circleDay.JudgeDecision3);
                    circleDay.JudgeDecision3.Add(totalrow);
                }
                else if (judge.Rate == 4)
                {
                    circleDay.JudgeDecision4 = setJudgesDeccisionsDto(4, circleStatistics.StatisticsDecisions!.ToList()!, caseYears.ToList());
                    var totalrow = GetTotalRowJudgesDeccision(circleDay.JudgeDecision4);
                    circleDay.JudgeDecision4.Add(totalrow);
                }
            }
            int c = circleStatistics.Month == 12 ? 1 : circleStatistics.Month + 1;
            circleDay.DelayCacesForMonthEthbat = SetDelayCacesForMonthDtos(circleStatistics.DelayCacesForMonths!.ToList(), caseYears.ToList(), DelayCacesForMonthTypes.DelayCacesForMonthEthbat, circleStatistics.Month);
            circleDay.DelayCacesForMonthEadaLelMorafea = SetDelayCacesForMonthDtos(circleStatistics.DelayCacesForMonths!.ToList(), caseYears.ToList(), DelayCacesForMonthTypes.DelayCacesForMonthEadaLelMorafea, circleStatistics.Month);
            circleDay.DelayCacesForMonthMahgouzLelHokm = SetDelayCacesForMonthDtos(circleStatistics.DelayCacesForMonths!.ToList(), caseYears.ToList(), DelayCacesForMonthTypes.DelayCacesForMonthMahgouzLelHokm, circleStatistics.Month);
            circleDay.DelayCacesForMonthMadAgal = SetDelayCacesForMonthDtos(circleStatistics.DelayCacesForMonths!.ToList(), caseYears.ToList(), DelayCacesForMonthTypes.DelayCacesForMonthMadAgal, circleStatistics.Month);
            circleDay.DelayCacesForMonthBaky = SetDelayCacesForMonthDtos(circleStatistics.DelayCacesForMonths!.ToList(), caseYears.ToList(), DelayCacesForMonthTypes.DelayCacesForMonthBaky, circleStatistics.Month);

            return circleDay;
        }
        public async Task<List<CircleJudge>> GetCircleJugesAsync(int IdCircle, DateTime date)
        {

            var hudjes = await _context.CircleJudges
                .Include(x => x.Judge!)
                .Include(x => x.Circle!)
                .Where(x => x.Circle!.Id == IdCircle && x.DateStart <= date.Date && (x.DateEnd == null || x.DateEnd >= date.Date))
                .ToListAsync();
            return hudjes.OrderBy(x => x.Rate).ToList();
        }
        private StatistaicsDto setStatistaicsDto(CircleStatistics circleStatistics, CaseYear caseYear)
        {
            StatistaicsDto statistaicsDto = new StatistaicsDto();

            statistaicsDto.Year = caseYear.Year;
            // statistaicsDto.Sapek = circleStatistics.Sapek.Where(x=>x.CaseYear.Year == caseYear.Year).FirstOrDefault() == null ?0 : circleStatistics.Sapek.Where(x => x.CaseYear.Year == caseYear.Year).FirstOrDefault().Count;
            statistaicsDto.MogaddMenShatb = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.MogaddMenShatb).Sum(x => x.Count);
            statistaicsDto.moagalMenAlwakfLhinAlfasl = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.moagalMenAlwakfLhinAlfasl).Sum(x => x.Count);
            statistaicsDto.moagalMenAlwakfGzaey = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.moagalMenAlwakfGzaey).Sum(x => x.Count);
            statistaicsDto.moagalMenAlwakfTaeliky = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.moagalMenAlwakfTaeliky).Sum(x => x.Count);
            statistaicsDto.moagalMenAlwakfItfaky = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.moagalMenAlwakfItfaky).Sum(x => x.Count);
            statistaicsDto.moagalMenAlEnktae = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.moagalMenAlEnktae).Sum(x => x.Count);
            statistaicsDto.MoadMenAlEstenf = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.MoadMenAlEstenf).Sum(x => x.Count);
            statistaicsDto.EhalaForm = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.EhalaForm).Sum(x => x.Count);
            statistaicsDto.ehalaTo = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.ehalaTo).Sum(x => x.Count);
            statistaicsDto.newCases = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.InterCase!.Name == MyStrings.InterCasesTypes.newCases).Sum(x => x.Count);
            statistaicsDto.TaksirCount = circleStatistics.Shortening!.Where(x => x.CaseYear!.Year == caseYear.Year).Sum(x => x.Count);
            statistaicsDto.Mashtob = circleStatistics.StatisticsDeleted!.Where(x => x.CaseYear!.Year == caseYear.Year).Sum(x => x.Count);
            statistaicsDto.Shakly = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionKateyTypes.Shakly).Sum(x => x.Count);
            statistaicsDto.Mawdoey = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionKateyTypes.Mawdoey).Sum(x => x.Count);
            statistaicsDto.Solh = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionKateyTypes.Solh).Sum(x => x.Count);
            statistaicsDto.Farey = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionFareyTypes.Farey).Sum(x => x.Count);
            statistaicsDto.Khapir = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionEthbatTypes.Khapir).Sum(x => x.Count);
            statistaicsDto.BackToKhapir = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionEthbatTypes.BackToKhapir).Sum(x => x.Count);
            statistaicsDto.Tahkik = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionEthbatTypes.Tahkik).Sum(x => x.Count);
            statistaicsDto.Estgwap = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionEthbatTypes.Estgwap).Sum(x => x.Count);
            statistaicsDto.HelfYamin = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionEthbatTypes.HelfYamin).Sum(x => x.Count);
            statistaicsDto.WakfGazaey = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionWakftTypes.WakfGazaey).Sum(x => x.Count);
            statistaicsDto.WakfTaeliky = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionWakftTypes.WakfTaeliky).Sum(x => x.Count);
            statistaicsDto.EnktaeSirAlKhsoma = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year && x.Decision!.DecisionCategory!.Name == MyStrings.DecisionEnktaeSirAlKhsomaTypes.EnktaeSirAlKhsoma).Sum(x => x.Count);
            statistaicsDto.MahguzLelHokm = circleStatistics.StatisticsDelayCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.DelayCase!.Name! == MyStrings.DelayCacesypes.MahguzLelHokm).Sum(x => x.Count);
            statistaicsDto.MadAgal = circleStatistics.StatisticsDelayCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.DelayCase!.Name! == MyStrings.DelayCacesypes.MadAgal).Sum(x => x.Count);
            statistaicsDto.EadaLelMorafea = circleStatistics.StatisticsDelayCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.DelayCase!.Name! == MyStrings.DelayCacesypes.MadAgal).Sum(x => x.Count);
            statistaicsDto.MoeagalLelTkrir = circleStatistics.StatisticsDelayCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.DelayCase!.Name! == MyStrings.DelayCacesypes.MoeagalLelTkrir).Sum(x => x.Count);
            statistaicsDto.Okhrah = circleStatistics.StatisticsDelayCases!.Where(x => x.CaseYear!.Year == caseYear.Year && x.DelayCase!.Name! == MyStrings.DelayCacesypes.Okhrah).Sum(x => x.Count);





            return statistaicsDto;

        }
        public List<JudgesDeccisionDto> setJudgesDeccisionsDto(int JudgeId, List<StatisticsDecisions> decisions, List<CaseYear> years)
        {
            var judgeDecisions = new List<JudgesDeccisionDto>();

            foreach (var year in years)
            {
                var judgeDecision = new JudgesDeccisionDto();
                judgeDecision.Year = year.Year;
                judgeDecision.AdmKbol = decisions.Where(x => x.IdJudge == JudgeId && x.CaseYear!.Year == year.Year && x.Decision!.Name == MyStrings.DecisionKatey_ShaklyTypes.AdmKbol).Sum(x => x.Count);
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



            return judgeDecisions;

        }
        public List<DelayCacesForMonthDto> SetDelayCacesForMonthDtos(List<DelayCacesForMonth> delayCacesForMonths, List<CaseYear> years, string Type, int firstMonth)
        {
            int secondMonth = firstMonth == 12 ? 1 : firstMonth + 1;
            int thirdMonth = firstMonth == 11 ? 1 : firstMonth + 2;
            var delayCacesForMonthDtos = new List<DelayCacesForMonthDto>();
            foreach (var item in years)
            {
                var delayCacesForMonthDto = new DelayCacesForMonthDto();
                delayCacesForMonthDto.CaseYear = item.Year;
                delayCacesForMonthDto.Month1 = delayCacesForMonths.Where(x => x.DelayCacesForMonthType!.Name == Type && x.CaseYear!.Year == item.Year && x.Month == firstMonth).Sum(x => x.Count);
                delayCacesForMonthDto.Month2 = delayCacesForMonths.Where(x => x.DelayCacesForMonthType!.Name == Type && x.CaseYear!.Year == item.Year && x.Month == secondMonth).Sum(x => x.Count);
                delayCacesForMonthDto.Month3 = delayCacesForMonths.Where(x => x.DelayCacesForMonthType!.Name == Type && x.CaseYear!.Year == item.Year && x.Month == thirdMonth).Sum(x => x.Count);

                delayCacesForMonthDtos.Add(delayCacesForMonthDto);
            }
            return delayCacesForMonthDtos;

        }
        public async Task<List<StatisticsDecisions>> GetStatisticsDecisions(int circleStatisticsId)
        {
            var decisions = await _context.StatisticsDecisions
                .Include(x => x.Decision!).ThenInclude(x => x.DecisionCategory!)
                .Include(x => x.Judge!)
                .Include(x => x.CaseYear!)
                .Where(x => x.IdCircleStatistics == circleStatisticsId)
                .ToListAsync();
            return decisions;
        }
        public StatistaicsDto GetTotalRowStatistaics(List<StatistaicsDto> list)
        {
            return new StatistaicsDto
            {
                IsTotalRow = 1,
                Year = 0, // أو "إجمالي" لو غيرت النوع إلى string
                Sapek = list.Sum(x => x.Sapek),
                MogaddMenShatb = list.Sum(x => x.MogaddMenShatb),
                moagalMenAlwakfLhinAlfasl = list.Sum(x => x.moagalMenAlwakfLhinAlfasl),
                moagalMenAlwakfGzaey = list.Sum(x => x.moagalMenAlwakfGzaey),
                moagalMenAlwakfTaeliky = list.Sum(x => x.moagalMenAlwakfTaeliky),
                moagalMenAlwakfItfaky = list.Sum(x => x.moagalMenAlwakfItfaky),
                moagalMenAlEnktae = list.Sum(x => x.moagalMenAlEnktae),
                MoadMenAlEstenf = list.Sum(x => x.MoadMenAlEstenf),
                TaksirCount = list.Sum(x => x.TaksirCount),
                TaksirMonth = list.Sum(x => x.TaksirMonth),
                EhalaForm = list.Sum(x => x.EhalaForm),
                ehalaTo = list.Sum(x => x.ehalaTo),
                newCases = list.Sum(x => x.newCases),
                Mashtob = list.Sum(x => x.Mashtob),
                Shakly = list.Sum(x => x.Shakly),
                Mawdoey = list.Sum(x => x.Mawdoey),
                Solh = list.Sum(x => x.Solh),
                Farey = list.Sum(x => x.Farey),
                Khapir = list.Sum(x => x.Khapir),
                BackToKhapir = list.Sum(x => x.BackToKhapir),
                Tahkik = list.Sum(x => x.Tahkik),
                Estgwap = list.Sum(x => x.Estgwap),
                HelfYamin = list.Sum(x => x.HelfYamin),
                WakfGazaey = list.Sum(x => x.WakfGazaey),
                WakfTaeliky = list.Sum(x => x.WakfTaeliky),
                WakfEtfaky = list.Sum(x => x.WakfEtfaky),
                EnktaeSirAlKhsoma = list.Sum(x => x.EnktaeSirAlKhsoma),
                MahguzLelHokm = list.Sum(x => x.MahguzLelHokm),
                MadAgal = list.Sum(x => x.MadAgal),
                EadaLelMorafea = list.Sum(x => x.EadaLelMorafea),
                MoeagalLelTkrir = list.Sum(x => x.MoeagalLelTkrir),
                Okhrah = list.Sum(x => x.Okhrah),
            };
        }

        public JudgesDeccisionDto GetTotalRowJudgesDeccision(List<JudgesDeccisionDto> list)
        {
            return new JudgesDeccisionDto
            {
                IsTotalRow = 1,
                Year = 0, // أو "إجمالي" لو غيرت النوع إلى string
                AdmKbol = list.Sum(x => x.AdmKbol),
                AdmEjhtsas = list.Sum(x => x.AdmEjhtsas),
                SkotAlHakFiRAFEAlDaewa = list.Sum(x => x.SkotAlHakFiRAFEAlDaewa),
                SkotAlKhsomaWEnkdaeha = list.Sum(x => x.SkotAlKhsomaWEnkdaeha),
                TarkAlKhsoma = list.Sum(x => x.TarkAlKhsoma),
                EnedamAlKhsoma = list.Sum(x => x.EnedamAlKhsoma),
                KanLamTkon = list.Sum(x => x.KanLamTkon),
                Kbol = list.Sum(x => x.Kbol),
                Rafd = list.Sum(x => x.Rafd),
                RafdBeHalatha = list.Sum(x => x.RafdBeHalatha),
                AdamGwazLeSabekatAlFaslFiha = list.Sum(x => x.AdamGwazLeSabekatAlFaslFiha),
                EnkdaeAlhakBeModiAlModa = list.Sum(x => x.EnkdaeAlhakBeModiAlModa),
                Solh = list.Sum(x => x.Solh),
                Farey = list.Sum(x => x.Farey),
                NadbKhabir = list.Sum(x => x.NadbKhabir),
                BackTOKhabir = list.Sum(x => x.BackTOKhabir),
                Tahkik = list.Sum(x => x.Tahkik),
                Estgwab = list.Sum(x => x.Estgwab),
                HelfYamin = list.Sum(x => x.HelfYamin),
                WakfGazaey = list.Sum(x => x.WakfGazaey),
                WakfTaeliky = list.Sum(x => x.WakfTaeliky),
                WakfEtifaky = list.Sum(x => x.WakfEtifaky),
                EnktaeSirAlKhsoma = list.Sum(x => x.EnktaeSirAlKhsoma),
                MadAgal = list.Sum(x => x.MadAgal)
            };
        }

        public int CalcMokadam(List<DelayCacesForMonth> delays, int year, int month, CaseYear caseYear)
        {
            var count = delays
                .Where(x => x.CaseYear.Year == caseYear.Year && x.Month == month && x.Year == year)
                .Sum(x => x.Count);
            return count;

        }

       
    }
}
