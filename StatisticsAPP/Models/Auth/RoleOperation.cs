using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.Auth
{
    public class RoleOperation 
    {
        public int Id { get; set; }
        public int IdRole { get; set; }
        public int IdOperation { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        // العلاقات
        [ForeignKey("IdRole")]
        public Role? Role { get; set; }
        [ForeignKey("IdOperation")]
        public Operation? Operation { get; set; }
    }
}
