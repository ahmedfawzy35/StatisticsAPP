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
    public partial class SuperCourtTabes : Form
    {
        string AddEdit = "اضافة محكمة ابتدائية";
        string Manage = "ادارة المحاكم الابتدائية";

        List<string> forms = new List<string>();
        
        public SuperCourtTabes()
        {
            InitializeComponent();
            forms.Add(AddEdit);
            forms.Add(Manage);
        }
        #region Methods
        public void ShowForm(TabPage xtab)
        {
            Form frm = GetForm(xtab.Text);
            if (xtab.Controls.Count == 0)
            {
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                xtab.Controls.Add(frm);
            }

        }
        private void CreatePage(string name)
        {
            TabPage xtab = new TabPage
            {
                Name = name,
                Text = name,
            };
            xtab.AutoScroll = true;
            xtab.RightToLeft = RightToLeft.Yes;

            tabControl1.TabPages.Add(xtab);

        
        }
        private void AddPages()
        {
            foreach (string name in forms)
            {
                CreatePage(name);
            }
        }

        private Form GetForm(string FormText)
        {
            switch (FormText)
            {
                case string v when v == AddEdit:
                    return new AddSuperCourtForm();
                case string v when v == Manage:
                    return new SuperCourtManageForm();
               

                default:
                    return new AddSuperCourtForm();

            }

        }
        #endregion
        #region TabPage
        private void SuperCourtTabes_Load(object sender, EventArgs e)
        {
           

            AddPages();
            ShowForm(tabControl1.TabPages[0]);
        }
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            for (var i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                var tabRect = this.tabControl1.GetTabRect(i);

                if (tabRect.Contains(e.Location))
                {
                    ShowForm(tabControl1.TabPages[i]);

                }
            }
        }
        #endregion
    }
}
