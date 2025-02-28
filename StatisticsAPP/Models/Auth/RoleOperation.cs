using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.Auth
{
    public class RoleOperation : MainClass
    {
        public int Id { get; set; }
        public int IdRole { get; set; }
        public int IdOperation { get; set; }

        // العلاقات
        public Role? Role { get; set; }
        public Operation? Operation { get; set; }
    }
}
