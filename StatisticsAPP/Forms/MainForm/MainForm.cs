using StatisticsAPP.Forms.AuthForms.UserForms;
using StatisticsAPP.Forms.CourtsForms;
using StatisticsAPP.Seeds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatisticsAPP.Forms.MainForm
{
    public partial class MainForm : Form
    {
        #region SingleTone
        private static MainForm? main_form;
        static void formmain_formclosed(object sender, FormClosedEventArgs e)
        {

            System.Windows.Forms.Application.Exit();
        }
        public static MainForm GetFormMain
        {
            get
            {
                if (main_form == null)
                {
                    main_form = new MainForm();
                    main_form.FormClosed += new FormClosedEventHandler(formmain_formclosed!);
                }
                return main_form;
            }
        }
        #endregion

        Image CloseImage;
        public MainForm()
        {
            InitializeComponent();
            if (main_form == null) main_form = this;
        }

        #region Methods
        int is_exits(string x)
        {
            int a = -1;
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {

                if (tabControl1.TabPages[i].Text == x)
                {

                    tabControl1.SelectTab(i);
                    a = i;
                    break;
                }
            }

            return a;

        }
        #endregion
        #region Tab Control
        public void ShowForm(string x, Form frm)
        {
            //if (!MyServicies.checkPermissionsManager.CheckCreatePermission(MyStrings.ModulsName.Product))
            //{
            //    System.Windows.MessageBox.Show("الاجراء غير مصرح به  " + Environment.NewLine+ Permissions.Creat(MyStrings.ModulsName.Product));
            //    return;
            //}

            int select = is_exits(x);
            if (select == -1)
            {
                frm.TopLevel = false;
                frm.Visible = true;
                //frm.BackColor = MyColors.MasterBackColor;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                //frm.Height = 2000;
                int index1 = tabControl1.TabPages.Count;
                TabPage xtab = new TabPage
                {
                    Name = frm.Name,
                    Text = x,
                    //BackColor = MyColors.MasterBackColor,

                };
                tabControl1.TabPages.Add(xtab);
                tabControl1.TabPages[index1].AutoScroll = true;
                //tabControl1.TabPages[index1].Height = 1000;

                //tabControl1.TabPages[index1].AutoScrollMinSize = new System.Drawing.Size(1000, 2000);

                tabControl1.TabPages[index1].Controls.Clear();
                tabControl1.TabPages[index1].Text = x;
                tabControl1.TabPages[index1].RightToLeft = RightToLeft.Yes;
                tabControl1.TabPages[index1].Controls.Add(frm);
                tabControl1.TabPages[index1].Name = frm.Name;
                tabControl1.SelectTab(index1);
                return;

            }
            else
            {
                tabControl1.SelectTab(select);
            }
        }
        public static Rectangle GetRTLCoordinates(Rectangle container, Rectangle drawRectangle)
        {
            return new Rectangle(
                container.Width - drawRectangle.Width - drawRectangle.X,
                drawRectangle.Y,
                drawRectangle.Width,
                drawRectangle.Height);
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {

                // e.BackColor = MyColors.MasterBackColor;

                var tabRect = this.tabControl1.GetTabRect(e.Index);
                tabRect.Inflate(-2, -2);
                var imageRect = new Rectangle(tabRect.Right - CloseImage.Width,
                                         tabRect.Top + (tabRect.Height - CloseImage.Height) / 2,
                                         CloseImage.Width,
                                         CloseImage.Height);

                var sf = new StringFormat(StringFormat.GenericDefault);

                if (this.tabControl1.RightToLeft == System.Windows.Forms.RightToLeft.Yes &&
                    this.tabControl1.RightToLeftLayout == true)
                {
                    tabRect = GetRTLCoordinates(this.tabControl1.ClientRectangle, tabRect);
                    imageRect = GetRTLCoordinates(this.tabControl1.ClientRectangle, imageRect);
                    sf.FormatFlags |= StringFormatFlags.DirectionRightToLeft;

                }

                var newrect = tabRect;
                newrect.Inflate(3, 3);
                if (e.State == DrawItemState.Selected)
                {

                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), newrect);

                    e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, new Font("Cairo", 11, FontStyle.Bold), new SolidBrush(Color.White), tabRect, sf);



                }
                else
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Bisque), newrect);
                    e.Graphics.DrawString(this.tabControl1.TabPages[e.Index].Text, new Font("Traditional Arabic", 14, FontStyle.Bold), new SolidBrush(Color.Black), tabRect, sf);
                }
                e.Graphics.DrawImage(CloseImage, imageRect.Location);






            }
            catch (Exception) { }
        }
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            for (var i = 0; i < this.tabControl1.TabPages.Count; i++)
            {
                var tabRect = this.tabControl1.GetTabRect(i);
                tabRect.Inflate(-2, -2);
                var imageRect = new Rectangle(tabRect.Right - CloseImage.Width,
                                         tabRect.Top + (tabRect.Height - CloseImage.Height) / 2,
                                         CloseImage.Width,
                                         CloseImage.Height);
                if (imageRect.Contains(e.Location))
                {
                    if (i == 0)
                    {
                        int xx = this.tabControl1.TabPages.Count;
                        for (int x = 1; x < xx; x++)
                        {
                            if (x == 0) continue;
                            this.tabControl1.TabPages.RemoveAt(1);
                        }
                    }
                    else
                    {
                        this.tabControl1.TabPages.RemoveAt(i);
                        this.tabControl1.SelectTab(i - 1);
                        break;
                    }

                }
            }
        }
        #endregion
        #region Events
        private async void MainForm_Load(object sender, EventArgs e)
        {
            CloseImage = Properties.Resources.close16;
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            //tabControl1.DrawItem += tabControl1_DrawItem;
            tabControl1.Padding = new System.Drawing.Point(50, 3);

            await Task.Run(async () =>
            {

                await DefualtPermissions.AddDefualtOperations();
                await DefualtPermissions.AddDefualtToRoleOperation();
                await DefualtPermissions.AddDefualtSuperCourt();
                await DefualtPermissions.AddDefualtSupCourt();




            });
        }
        private void RecentLable_Click(object sender, EventArgs e)
        {
            Label l = (Label)sender;
            int recentIndex = is_exits("النماذج المفتوحه");
            int select = is_exits(l.Text);
            tabControl1.SelectTab(select);

            tabControl1.TabPages.RemoveAt(recentIndex);

        }

        private void اغلاقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion





        private void ToolStripMenuItem_AddCourt_Click(object sender, EventArgs e)
        {
            ShowForm("المحاكم الابتدائية", new SuperCourtTabes());
        }

        private void ToolStripMenuItem_ManageUsers_Click(object sender, EventArgs e)
        {
            ShowForm("ادارة المستخدمين", new ManageUsersForm());
        }
    }
}
