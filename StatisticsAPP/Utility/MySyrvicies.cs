using StatisticsAPP.Data;
using StatisticsAPP.Servicies.AuthServicies;
using StatisticsAPP.Servicies.AuthServicies.UserServicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Utility
{
    public static class MySyrvicies
    {
        public static ApplicationDbContext _context = MyContext.context;

        #region AuthServicies
        public static UserManager userManager = new UserManager(_context);
        public static RoleManager roleManager = new RoleManager(_context);
        public static CheckPermissionsManager checkPermissionsManager = new CheckPermissionsManager(roleManager.getuserOperations(LocalUser.localUserId));
      
        #endregion
    }
}
