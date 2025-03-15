using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Data
{
    public static class DbContextFactory
    {
        private static AsyncLocal<ApplicationDbContext> _context = new AsyncLocal<ApplicationDbContext>();

        public static event Action DataUpdated; // الحدث اللي هيبلغ الفورمات بالتحديث

        public static ApplicationDbContext GetContext()
        {
            if (_context.Value == null)
            {
                _context.Value = new ApplicationDbContext();
            }
            return _context.Value;
        }

        public static void RefreshContext()
        {
            _context.Value?.Dispose();
            _context.Value = new ApplicationDbContext();

            // إطلاق الحدث لتحديث جميع الفورمات
            DataUpdated?.Invoke();
        }
    }
}
