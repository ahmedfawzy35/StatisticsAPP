using StatisticsAPP.Models.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models
{
    public class MainClass
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
