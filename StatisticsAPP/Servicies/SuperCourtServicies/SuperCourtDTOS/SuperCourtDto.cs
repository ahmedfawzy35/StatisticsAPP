using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Servicies.SuperCourtServicies.SuperCourtDTOS
{
    public class SuperCourtDto
    {

        [DisplayName("الرقم التعريفي")]
        public int Id { get; set; }
        [DisplayName("اسم المحكمة")]
        public String? Name { get; set; }
        [DisplayName("المستخدم المنشئ")]
        public String? UserCreatedName { get; set; }
        [DisplayName("تاريخ الانشاء")]
        public DateTime CreatedAt { get; set; }

    }
}
