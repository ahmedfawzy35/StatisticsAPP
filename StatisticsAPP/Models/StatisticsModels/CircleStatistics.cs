using StatisticsAPP.Models.CircleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.StatisticsModels
{
    public class CircleStatistics : MainClass
    {
        public int Id { get; set; }
        public int IdCircle { get; set; }
        public required string DayOfWork { get; set; }
        public string? Employee { get; set; }
        public required int Year { get; set; }
        public required int Month { get; set; }
        public int InterCasesCount { get; set; }
        public int DelayedCases { get; set; }
        public int DecisionsCount { get; set; }

        public Circle? Circle { get; set; }
    }

}
