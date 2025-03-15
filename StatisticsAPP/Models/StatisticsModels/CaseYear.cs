using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.StatisticsModels
{
    public class CaseYear
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int Year { get; set; }
        public bool IsOld { get; set; }
    }
}
