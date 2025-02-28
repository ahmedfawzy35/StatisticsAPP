using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.Auth
{
    public class User
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public bool Enable { get; set; }

        // تتبع الإنشاء والتعديل
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // العلاقات
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }

}
