using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.DelayCasesModels
{
    public class DelayCase : MainClass
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int IdDelayCasesCategory { get; set; }

        public DelayCasesCategory? DelayCasesCategory { get; set; }
    }

}
