using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Models.CourtsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.Auth
{
    public class UserCircles
    {
        public int Id { get; set; }
        public int IdCircle { get; set; }
        public int IdUser { get; set; }



        public Circle? Circle { get; set; }
        public User? User { get; set; }
    }
}
