using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.DelayCasesModels
{
    public class DelayCasesCategory:MainClass
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? ParentID { get; set; }
    }

}
