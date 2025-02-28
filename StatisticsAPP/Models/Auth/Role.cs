using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.Auth
{
    public class Role : MainClass
    {
        public int Id { get; set; }
        public required string Name { get; set; }  // مثال: "مدير النظام"
        public required string Code { get; set; }  // مثال: "ADMIN"

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<RoleOperation> RoleOperations { get; set; } = new List<RoleOperation>();
    }

}
