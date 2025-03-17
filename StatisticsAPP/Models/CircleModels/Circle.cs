using StatisticsAPP.Models.CourtsModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.CircleModels
{
    public class Circle : MainClass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string? Name { get; set; }
       
        public int Count { get; set; }
        public int IdSupCourt { get; set; }
        public int IdCircleCategory { get; set; }
        public bool Enable { get; set; } = true;

        // العلاقات

         public virtual IEnumerable<CircleJudge>? CircleJudges { get; set; }
         public virtual IEnumerable<CircleDay>? CircleDays { get; set; }
        [ForeignKey("IdSupCourt")]
        public SupCourt? SupCourt { get; set; }
        [ForeignKey("IdCircleCategory")]
        public CircleCategory? CircleCategory { get; set; }
    }
}
