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

namespace StatisticsAPP.Forms.AuthForms.UserForms
{
    public partial class ManageUsersForm : Form
    {
        public ManageUsersForm()
        {
            InitializeComponent();
        }

        void Loading()
        {
            pictureBox_Loading.Visible = true;
        }
        void UnLoading()
        {
            pictureBox_Loading.Visible = false;
        }
        private async Task  GetUsers()
        {
            Loading();
            dataGridView_Users.DataSource = await MyContext.UnitOfWork.User.GetAllAsync();
            UnLoading();
        }
        private async void ManageUsersForm_Load(object sender, EventArgs e)
        {
         await   GetUsers();
        }
    }
}
