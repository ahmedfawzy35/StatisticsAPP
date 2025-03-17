using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.InterCasesModels
{
    public class InterCase : MainClass
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int IdInterCasesCategory { get; set; }

        [ForeignKey("IdInterCasesCategory")]
        public InterCasesCategory? InterCasesCategory { get; set; }
    }

}
