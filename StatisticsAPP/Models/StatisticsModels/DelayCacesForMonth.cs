using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
}
