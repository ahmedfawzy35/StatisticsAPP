using StatisticsAPP.Models.JudgeModels;
using StatisticsAPP.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.CircleModels
{
    public class CircleDay
    {
        public int Id { get; set; }
        [Required]
        public  string? Name { get; set; }
        public  bool  Enable { get; set; }
        [Required]
        public  string? Day { get; set; }

        public int CircleTypeId { get; set; }
        public int CircleId { get; set; }

        [ForeignKey("CircleId")]
        public Circle? Circle  { get; set; }
        [ForeignKey("CircleTypeId")]
        public CircleType? CircleType  { get; set; }

        public virtual IEnumerable<DelayCacesForMonth>? DelayCacesForMonths { get; set; }
        public virtual IEnumerable<CircleStatistics>? CircleStatistics { get; set; }
    }
}
