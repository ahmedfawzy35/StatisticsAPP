using StatisticsAPP.Models.CircleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace StatisticsAPP.Servicies.Repositories.CircleRepos
{
   public class CircleDayDTO
    {
        [DisplayName("المعرف")]
        public int Id { get; set; }
        [Required]
        [DisplayName("الاسم")]
        public string? Name { get; set; }
        [Required]
        [DisplayName("يوم الانعقاد")]

        public string? Day { get; set; }
        [DisplayName("النوع ")]
        public string? CircleTypeName { get; set; }
        [DisplayName("الدائرة")]

        public string? CircleName { get; set; }
        [DisplayName("المحكمة التابع لها")]

        public string? SupCourteName { get; set; }

        
      
    }
}
