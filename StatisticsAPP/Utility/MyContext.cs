using StatisticsAPP.Data;
using StatisticsAPP.Forms.AuthForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Utility
{
    public static class MyContext
    {
        public static ApplicationDbContext context
        {
            get
            {
                if (LoginForm._context == null)
                {
                    return new ApplicationDbContext();
                }
                else
                {
                    return LoginForm._context;
                }
            }
        }


    }
}
