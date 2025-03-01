using StatisticsAPP.Models.CourtsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.Auth
{
    public class UserSuperCourts
    {
        public int Id { get; set; }
        public int IdSuperCourt { get; set; }
        public int IdUser { get; set; }



        public SuperCourt?   SuperCourt { get; set; }
        public User?   User { get; set; }
    }
}
