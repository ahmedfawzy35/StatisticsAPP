using StatisticsAPP.Models.CircleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
      

        public CircleDay? CircleDay { get; set; }

        public virtual IQueryable<StatisticsDecisions>? StatisticsDecisions { get; set; }
        public virtual IQueryable<StatisticsInterCases>? StatisticsInterCases { get; set; }
        public virtual IQueryable<StatisticsDelayCases>? StatisticsDelayCases { get; set; }
        public virtual IQueryable<DelayCacesForMonth>? DelayCacesForMonths { get; set; }

    }

}
