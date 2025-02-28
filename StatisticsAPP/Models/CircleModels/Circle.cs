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
        public int IdType { get; set; }  // نوع الدائرة
        public int Count { get; set; }
        public bool Enable { get; set; }

        // العلاقات

        public CircleType? CircleType { get; set; }
         public ICollection<CircleJudge> CircleJudges { get; set; } = new List<CircleJudge>();
    }
}
