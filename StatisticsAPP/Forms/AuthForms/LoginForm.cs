using StatisticsAPP.Data;
using StatisticsAPP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatisticsAPP.Forms.AuthForms
{
    public partial class LoginForm : Form
    {
        string username;
        string password;
        public static ApplicationDbContext _context = MyContext.context;
        public LoginForm()
        {
            InitializeComponent();
        }
    }
}
