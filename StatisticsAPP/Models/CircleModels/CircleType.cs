using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.CircleModels
{
    public class CircleType : MainClass
    {
        public int Id { get; set; }
        [Required]
        public  string? Name { get; set; }
        public  int IdCircleMasterType { get; set; }
        [ForeignKey("IdCircleMasterType")]
        public CircleMasterType? CircleMasterType { get; set; }


    }
}
