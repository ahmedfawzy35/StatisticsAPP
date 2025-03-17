using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.Auth
{
    public class Role 
    {
        public int Id { get; set; }
        [Required]
        public  string? Name { get; set; }  // مثال: "مدير النظام"
        [Required]
        public  string? Code { get; set; }  // مثال: "ADMIN"
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public IEnumerable<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public IEnumerable<RoleOperation> RoleOperations { get; set; } = new List<RoleOperation>();
    }

}
