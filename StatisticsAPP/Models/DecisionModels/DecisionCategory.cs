using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.DecisionModels
{
    public class DecisionCategory : MainClass
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? ParentID { get; set; }
        public bool IsFather { get; set; } = false;
    }

}
