using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Servicies.AuthServicies.DTOS
{
    public class CheckPermissionsDto
    {
        public bool Permission { get; set; }
        public string? Message { get; set; }
    }
}
