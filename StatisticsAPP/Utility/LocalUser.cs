using StatisticsAPP.Models.Auth;
using StatisticsAPP.Models.CourtsModels;
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
        public static List<Operation> UserClime = MyCervicies.roleManager.getuserOperations(localUserId);
        public static List<SuperCourt> userSuperCourt = MyCervicies.roleManager.GetUserSuperCourts(localUserId);
        public static List<SupCourt> userSupCourt = MyCervicies.roleManager.GetUserSupCourts(localUserId);


    }
}

