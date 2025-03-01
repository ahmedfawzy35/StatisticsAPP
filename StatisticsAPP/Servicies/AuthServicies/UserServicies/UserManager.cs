using StatisticsAPP.Data;
using StatisticsAPP.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Servicies.AuthServicies.UserServicies
{
    public  class UserManager
    {
        private readonly ApplicationDbContext _context;
        private string _ModelName = MyStrings.ModulsName.User;
        public UserManager(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
