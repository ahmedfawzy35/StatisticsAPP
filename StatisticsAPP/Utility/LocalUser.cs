using StatisticsAPP.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Utility
{
    public static class LocalUser
    {
        
        public static string localUserName
        {
            get
            {

                return Properties.Settings.Default.LocalUserName;

            }

        }
        public static int localUserId
        {
            get
            {

                return Properties.Settings.Default.LocalUserId;

            }
        }
        public static List<Operation> UserClime = MySyrvicies.roleManager.getuserOperations(LocalUser.localUserId);

    }
}

