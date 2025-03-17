using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.Auth
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public  string? FullName { get; set; }
        [Required]
        public  string? UserName { get; set; }
        [Required]
        public  string? Password { get; set; }
        public bool Enable { get; set; }

        // تتبع الإنشاء والتعديل
        public int CreatedBy { get; set; }

        // العلاقات
        public IEnumerable<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }

}
