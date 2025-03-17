using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Models.CourtsModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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


        [ForeignKey("IdCircle")]
        public Circle? Circle { get; set; }
        [ForeignKey("IdUser")]
        public User? User { get; set; }
    }
}
