using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.DecisionModels
{
    public class Decision : MainClass
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int IdDecisionCategory { get; set; }

        public DecisionCategory? DecisionCategory { get; set; }
    }

}
