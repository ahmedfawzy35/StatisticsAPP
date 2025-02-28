using System;
using System.Collections.Generic;
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

        public InterCasesCategory? InterCasesCategory { get; set; }
    }

}
