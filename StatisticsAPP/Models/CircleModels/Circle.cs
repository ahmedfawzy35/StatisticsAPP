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
        public bool Enable { get; set; }

        // العلاقات

         public ICollection<CircleJudge>? CircleJudges { get; set; }
         public IQueryable<CircleDay>? CircleDays { get; set; } 


    }
}
