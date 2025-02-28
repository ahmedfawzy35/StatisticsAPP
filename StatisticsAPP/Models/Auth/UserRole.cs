using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.Auth
{
    public class UserRole 
    {
        public int Id { get; set; }
        public int IdRole { get; set; }
        public int UserId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime CreatedAt { get; set; }
        // العلاقات
        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}
