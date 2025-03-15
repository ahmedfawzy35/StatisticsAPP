using StatisticsAPP.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.InterCasesModels
{
    public class Shortening :MainClass
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int IdCircleStatistics { get; set; }

        public CircleStatistics?   CircleStatistics { get; set; }
    }
}
