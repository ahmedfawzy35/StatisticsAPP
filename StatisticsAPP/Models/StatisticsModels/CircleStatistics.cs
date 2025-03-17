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
    public class CircleStatistics : MainClass
    {
        public int Id { get; set; }
        public int IdCircleDay { get; set; }
        [Required]
        public  string? DayOfWork { get; set; }
        public required int Year { get; set; }
        public required int Month { get; set; }

        [ForeignKey("IdCircleDay")]
        public CircleDay? CircleDay { get; set; }

        public virtual IEnumerable<StatisticsDecisions>? StatisticsDecisions { get; set; }
        public virtual IEnumerable<StatisticsInterCases>? StatisticsInterCases { get; set; }
        public virtual IEnumerable<StatisticsDelayCases>? StatisticsDelayCases { get; set; }
        public virtual IEnumerable<DelayCacesForMonth>? DelayCacesForMonths { get; set; }

    }

}
