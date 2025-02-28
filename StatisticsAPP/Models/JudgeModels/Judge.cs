using StatisticsAPP.Models.CircleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.JudgeModels
{
    public class Judge : MainClass
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int SeniorityNumber { get; set; }
        // العلاقات
        public ICollection<CircleJudge> CircleJudges { get; set; } = new List<CircleJudge>();
    }

}
