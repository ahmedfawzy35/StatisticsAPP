using StatisticsAPP.Models.CircleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.JudgeModels
{
    public class Judge : MainClass
    {
        public int Id { get; set; }
        [Required]
        public  string? Name { get; set; }
        public int SeniorityNumber { get; set; }
        public string? Degree { get; set; }
        // العلاقات
        public IEnumerable<CircleJudge> CircleJudges { get; set; } = new List<CircleJudge>();
    }

}
