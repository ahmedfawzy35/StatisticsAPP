using StatisticsAPP.Models.JudgeModels;
using StatisticsAPP.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("IdCircle")]
        public Circle? Circle { get; set; }
        [ForeignKey("IdJudge")]
        public Judge? Judge { get; set; }

        public virtual IEnumerable<StatisticsDecisions>? StatisticsDecisions { get; set; }

    }

}
