using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.Auth
{
    public class Operation : MainClass
    {
        public int Id { get; set; }
        public  required string Name { get; set; }  // مثال: "إضافة مستخدم"
        public  required string Code { get; set; }  // مثال: "ADD_USER"

        public ICollection<RoleOperation> RoleOperations { get; set; } = new List<RoleOperation>();
    }

}
