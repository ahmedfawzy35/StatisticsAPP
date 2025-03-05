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

namespace StatisticsAPP.Forms.CourtsForms
{
    public partial class SuperCourtManageForm : Form
    {
        public SuperCourtManageForm()
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
        private async Task GetSuperCourts()
        {
            Loading();
            string[] includs = new string[1];
            includs[0] = "User";
            dataGridView_SuperCourts.DataSource = await MyContext.UnitOfWork.SuperCourt.FindAllAsync(x=> true ,includs);
            UnLoading();
        }
        private async void ManageUsersForm_Load(object sender, EventArgs e)
        {
            await GetSuperCourts();
        }

        private async void btn_Refresh_Click(object sender, EventArgs e)
        {
            await GetSuperCourts();
        }
    }
}
