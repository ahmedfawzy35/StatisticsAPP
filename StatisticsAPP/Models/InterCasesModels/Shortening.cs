using StatisticsAPP.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("IdCircleStatistics")]
        public CircleStatistics?   CircleStatistics { get; set; }
    }
}
