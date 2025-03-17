using StatisticsAPP.Models.CircleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.CourtsModels
{
    public class SupCourt : MainClass
    {
        public int Id { get; set; }
        [Required]
        public  String? Name { get; set; }
        public string? Adress { get; set; }
        public  int SuperCourtId { get; set; }
        [ForeignKey("SuperCourtId")]
        public SuperCourt? SuperCourt { get; set; }

        public virtual IEnumerable<Circle>? Circles { get; set; }
    }
}
