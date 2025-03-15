using StatisticsAPP.Models.DecisionModels;
using StatisticsAPP.Models.JudgeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.StatisticsModels
{
    public class StatisticsDecisions : MainClass
    {
        public int Id { get; set; }
        public int IdCircleStatistics { get; set; }
        public int IdDecision { get; set; }
        public int Count { get; set; }
        public int CaseYearId { get; set; }
        public int IdJudge { get; set; }

        public CircleStatistics? CircleStatistics { get; set; }
        public Decision? Decision { get; set; }
        public Judge? Judge { get; set; }
        public CaseYear? CaseYear { get; set; }
    }

}
