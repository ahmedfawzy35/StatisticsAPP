using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.CourtsModels
{
    public class SuperCourt : MainClass
    {
        [DisplayName("الرقم التعريفي")]
        public int Id { get; set; }
        [DisplayName("اسم المحكمة")]
        [Required]
        public   String? Name { get; set; }
       

    }
}
