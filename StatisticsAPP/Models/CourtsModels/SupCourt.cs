using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.CourtsModels
{
    public class SupCourt : MainClass
    {
        public int Id { get; set; }

        public required String Name { get; set; }
        public  int SuperCourtId { get; set; }

        public SuperCourt? SuperCourt { get; set; }

    }
}
