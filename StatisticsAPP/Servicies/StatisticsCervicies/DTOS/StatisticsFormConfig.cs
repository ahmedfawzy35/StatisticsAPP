using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Servicies.StatisticsCervicies.DTOS
{
    public class StatisticsFormConfig
    {
        public int SuperCourtId { get; set; }
        public int SupCourtId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int CircleCtogryId { get; set; }
        public int CircleMasterTypeId { get; set; }
        public String? SuperCourtName { get; set; }
        public String? SupCourtName { get; set; }
        public String? CircleCtogryName { get; set; }
        public String? CircleMasterTypeName { get; set; }

    }
}
