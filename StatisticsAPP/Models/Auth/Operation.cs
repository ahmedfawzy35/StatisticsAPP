using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.Auth
{
    public class Operation
    {
        public int Id { get; set; }
        [Required]
        public   string? Name { get; set; }
        [Required]
        public   string? Code { get; set; }  
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public IEnumerable<RoleOperation> RoleOperations { get; set; } = new List<RoleOperation>();
    }

}
