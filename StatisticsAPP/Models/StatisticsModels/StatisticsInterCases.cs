using StatisticsAPP.Models.InterCasesModels;
using StatisticsAPP.Models.JudgeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.StatisticsModels
{
    public class StatisticsInterCases : MainClass
    {
        public int Id { get; set; }
        public int IdCircleStatistics { get; set; }
        public int IdInterCase { get; set; }
        public int Count { get; set; }
        public int IdJudge { get; set; }

        public CircleStatistics? CircleStatistics { get; set; }
        public InterCase? InterCase { get; set; }
        public Judge? Judge { get; set; }
    }

}
