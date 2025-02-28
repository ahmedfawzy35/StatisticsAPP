using StatisticsAPP.Models.JudgeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.CircleModels
{
    public class CircleJudge : MainClass
    {
        public int Id { get; set; }
        public int IdCircle { get; set; }
        public int IdJudge { get; set; }
        public int Rate { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }

        // العلاقات
        public Circle? Circle { get; set; }
        public Judge? Judge { get; set; }
    }

}
