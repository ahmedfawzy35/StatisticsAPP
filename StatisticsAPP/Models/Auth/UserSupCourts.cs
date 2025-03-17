using StatisticsAPP.Models.CourtsModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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


        [ForeignKey("IdSupCourt")]
        public SupCourt? SupCourt { get; set; }
        [ForeignKey("IdUser")]
        public User? User { get; set; }
    }
}
