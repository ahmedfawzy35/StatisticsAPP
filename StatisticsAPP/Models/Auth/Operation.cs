using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.Auth
{
    public class Operation
    {
        public int Id { get; set; }
        public  required string Name { get; set; }  // مثال: "إضافة مستخدم"
        public  required string Code { get; set; }  // مثال: "ADD_USER"
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<RoleOperation> RoleOperations { get; set; } = new List<RoleOperation>();
    }

}
