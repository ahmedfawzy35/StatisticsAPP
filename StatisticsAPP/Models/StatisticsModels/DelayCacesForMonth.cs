using StatisticsAPP.Models.CircleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.StatisticsModels
{
    public class DelayCacesForMonth
    {
        public int Id { get; set; }
        [Required]
        public string? Type { get; set; }
        public int Count { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int IdCircleStatistics { get; set; }
        public int IdCircleDay { get; set; }
        public int IdCaseYear { get; set; }
        [ForeignKey("IdCaseYear")]
        public CaseYear? CaseYear { get; set; }
        public DelayCacesForMonthType? IdDelayCacesForMonthType { get; set; }

        [ForeignKey("IdCircleDay")]
        public CircleDay?  CircleDay { get; set; }
        [ForeignKey("IdCircleStatistics")]
        public CircleStatistics? CircleStatistics { get; set; }
       
    }
}
