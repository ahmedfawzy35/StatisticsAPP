using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.DecisionModels
{
    public class DecisionCategory : MainClass
    {
        public int Id { get; set; }
        [Required]
        public  string? Name { get; set; }
        public int? ParentID { get; set; }
        public bool IsFather { get; set; } = false;
        public virtual IEnumerable<Decision>? Decisions { get; set; }
    }

}
