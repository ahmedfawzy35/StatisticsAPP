using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.DecisionModels
{
    public class Decision : MainClass
    {
        public int Id { get; set; }
        [Required]
        public  string? Name { get; set; }
        public int IdDecisionCategory { get; set; }

        [ForeignKey("IdDecisionCategory")]
        public DecisionCategory? DecisionCategory { get; set; }
    }

}
