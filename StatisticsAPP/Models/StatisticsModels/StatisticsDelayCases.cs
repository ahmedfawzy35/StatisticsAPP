using StatisticsAPP.Models.DelayCasesModels;
using StatisticsAPP.Models.JudgeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.StatisticsModels
{
    public class StatisticsDelayCases : MainClass
    {
        public int Id { get; set; }
        public int IdCircleStatistics { get; set; }
        public int IdDelayCase { get; set; }
        public int Count { get; set; }
        public int IdJudge { get; set; }
        public int MonthDelay { get; set; }
        public int YearDelay { get; set; }

        public CircleStatistics? CircleStatistics { get; set; }
        public DelayCase? DelayCase { get; set; }
        public Judge? Judge { get; set; }
    }

}
