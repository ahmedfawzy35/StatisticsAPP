using StatisticsAPP.Models.CourtsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.Auth
{
    public class UserSupCourts
    {
        public int Id { get; set; }
        public int IdSupCourt { get; set; }
        public int IdUser { get; set; }



        public SupCourt? SupCourt { get; set; }
        public User? User { get; set; }
    }
}
