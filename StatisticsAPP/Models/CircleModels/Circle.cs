using StatisticsAPP.Models.CourtsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.CircleModels
{
    public class Circle : MainClass
    {
        public int Id { get; set; }
        public required string Name { get; set; }
       
        public int Count { get; set; }
        public int IdSupCourt { get; set; }
        public int IdCircleCategory { get; set; }
        public bool Enable { get; set; }

        // العلاقات

         public ICollection<CircleJudge>? CircleJudges { get; set; }
         public IQueryable<CircleDay>? CircleDays { get; set; }

        public SupCourt? SupCourt { get; set; }
        public CircleCategory? CircleCategory { get; set; }
    }
}
