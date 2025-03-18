using StatisticsAPP.Data;
using StatisticsAPP.Forms.AuthForms;
using StatisticsAPP.Servicies.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Utility
{
    public static class MyContext
    {
        private static UnitOfWork _UnitOfWork = new UnitOfWork(context);
        private static ApplicationDbContext _context = new ApplicationDbContext();

        public static ApplicationDbContext context
        {
            get
            {
                if (_context == null)
                {
                    return new ApplicationDbContext();
                }
                else
                {
                    return _context;
                }
            }
        }

              

        public static UnitOfWork UnitOfWork
        {
            get
            {
                if (_UnitOfWork == null)
                {
                    return new UnitOfWork(context);
                }
               
                return _UnitOfWork;
            }
        }

    }
}
