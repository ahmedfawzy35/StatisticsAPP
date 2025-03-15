using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int CircleTypeId { get; set; }
        public int CircleId { get; set; }


        public Circle? Circle  { get; set; }
        public CircleType? CircleType  { get; set; }
    }
}
