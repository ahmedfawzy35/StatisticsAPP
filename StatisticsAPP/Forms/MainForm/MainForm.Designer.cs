namespace StatisticsAPP.Forms.MainForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            ToolStripMenuItem_File = new ToolStripMenuItem();
            اغلاقToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem_Courts = new ToolStripMenuItem();
            ToolStripMenuItem_SuperCourts = new ToolStripMenuItem();
            ToolStripMenuItem_SupCourts = new ToolStripMenuItem();
            ToolStripMenuItem_circles = new ToolStripMenuItem();
            ToolStripMenuItem_AddCircle = new ToolStripMenuItem();
            ToolStripMenuItem_ManageCircle = new ToolStripMenuItem();
            ToolStripMenuItem_judges = new ToolStripMenuItem();
            ToolStripMenuItem_AddJudge = new ToolStripMenuItem();
            ToolStripMenuItem_AppointmentOfJudge = new ToolStripMenuItem();
            ToolStripMenuItem_ManageJudges = new ToolStripMenuItem();
            ToolStripMenuItem_Appoiments = new ToolStripMenuItem();
            ToolStripMenuItem_Statistics = new ToolStripMenuItem();
            ToolStripMenuItem_AddStatistic_Madani = new ToolStripMenuItem();
            ToolStripMenuItem_AddStatistic_Genaey = new ToolStripMenuItem();
            ToolStripMenuItem_AddStatistic_Osra = new ToolStripMenuItem();
            احصائيةقاضيToolStripMenuItem = new ToolStripMenuItem();
            احصائيةمحكمةابتدائيةToolStripMenuItem = new ToolStripMenuItem();
            احصائيةمحكمةجزئيةToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem_Reports = new ToolStripMenuItem();
            الاحصائيةالشهريةToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem_Settings = new ToolStripMenuItem();
            ToolStripMenuItem_Users = new ToolStripMenuItem();
            ToolStripMenuItem_AddUser = new ToolStripMenuItem();
            ToolStripMenuItem_ManageUsers = new ToolStripMenuItem();
            ToolStripMenuItem_Roles = new ToolStripMenuItem();
            ToolStripMenuItem_AddRole = new ToolStripMenuItem();
            ToolStripMenuItem_ManageRoles = new ToolStripMenuItem();
            ToolStripMenuItem_EditPassword = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            menuStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem_File, ToolStripMenuItem_Courts, ToolStripMenuItem_circles, ToolStripMenuItem_judges, ToolStripMenuItem_Statistics, ToolStripMenuItem_Reports, ToolStripMenuItem_Settings, ToolStripMenuItem_Users });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1271, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_File
            // 
            ToolStripMenuItem_File.DropDownItems.AddRange(new ToolStripItem[] { اغلاقToolStripMenuItem });
            ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
            ToolStripMenuItem_File.Size = new Size(42, 20);
            ToolStripMenuItem_File.Text = "ملف";
            // 
            // اغلاقToolStripMenuItem
            // 
            اغلاقToolStripMenuItem.Name = "اغلاقToolStripMenuItem";
            اغلاقToolStripMenuItem.Size = new Size(100, 22);
            اغلاقToolStripMenuItem.Text = "اغلاق";
            اغلاقToolStripMenuItem.Click += اغلاقToolStripMenuItem_Click;
            // 
            // ToolStripMenuItem_Courts
            // 
            ToolStripMenuItem_Courts.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_SuperCourts, ToolStripMenuItem_SupCourts });
            ToolStripMenuItem_Courts.Name = "ToolStripMenuItem_Courts";
            ToolStripMenuItem_Courts.Size = new Size(56, 20);
            ToolStripMenuItem_Courts.Text = "المحاكم";
            // 
            // ToolStripMenuItem_SuperCourts
            // 
            ToolStripMenuItem_SuperCourts.Name = "ToolStripMenuItem_SuperCourts";
            ToolStripMenuItem_SuperCourts.Size = new Size(155, 22);
            ToolStripMenuItem_SuperCourts.Text = "المحاكم الإبتدائية";
            ToolStripMenuItem_SuperCourts.Click += ToolStripMenuItem_AddCourt_Click;
            // 
            // ToolStripMenuItem_SupCourts
            // 
            ToolStripMenuItem_SupCourts.Name = "ToolStripMenuItem_SupCourts";
            ToolStripMenuItem_SupCourts.Size = new Size(155, 22);
            ToolStripMenuItem_SupCourts.Text = "المحاكم الجزئية";
            // 
            // ToolStripMenuItem_circles
            // 
            ToolStripMenuItem_circles.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_AddCircle, ToolStripMenuItem_ManageCircle });
            ToolStripMenuItem_circles.Name = "ToolStripMenuItem_circles";
            ToolStripMenuItem_circles.Size = new Size(50, 20);
            ToolStripMenuItem_circles.Text = "الدوائر";
            // 
            // ToolStripMenuItem_AddCircle
            // 
            ToolStripMenuItem_AddCircle.Name = "ToolStripMenuItem_AddCircle";
            ToolStripMenuItem_AddCircle.Size = new Size(130, 22);
            ToolStripMenuItem_AddCircle.Text = "اضافة دائرة";
            // 
            // ToolStripMenuItem_ManageCircle
            // 
            ToolStripMenuItem_ManageCircle.Name = "ToolStripMenuItem_ManageCircle";
            ToolStripMenuItem_ManageCircle.Size = new Size(130, 22);
            ToolStripMenuItem_ManageCircle.Text = "ادارة الدوائر";
            // 
            // ToolStripMenuItem_judges
            // 
            ToolStripMenuItem_judges.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_AddJudge, ToolStripMenuItem_AppointmentOfJudge, ToolStripMenuItem_ManageJudges, ToolStripMenuItem_Appoiments });
            ToolStripMenuItem_judges.Name = "ToolStripMenuItem_judges";
            ToolStripMenuItem_judges.Size = new Size(53, 20);
            ToolStripMenuItem_judges.Text = "القضاه";
            // 
            // ToolStripMenuItem_AddJudge
            // 
            ToolStripMenuItem_AddJudge.Name = "ToolStripMenuItem_AddJudge";
            ToolStripMenuItem_AddJudge.Size = new Size(143, 22);
            ToolStripMenuItem_AddJudge.Text = "اضافة قاضي";
            // 
            // ToolStripMenuItem_AppointmentOfJudge
            // 
            ToolStripMenuItem_AppointmentOfJudge.Name = "ToolStripMenuItem_AppointmentOfJudge";
            ToolStripMenuItem_AppointmentOfJudge.Size = new Size(143, 22);
            ToolStripMenuItem_AppointmentOfJudge.Text = "تعيين قاضي";
            // 
            // ToolStripMenuItem_ManageJudges
            // 
            ToolStripMenuItem_ManageJudges.Name = "ToolStripMenuItem_ManageJudges";
            ToolStripMenuItem_ManageJudges.Size = new Size(143, 22);
            ToolStripMenuItem_ManageJudges.Text = "ادارة القضاه";
            // 
            // ToolStripMenuItem_Appoiments
            // 
            ToolStripMenuItem_Appoiments.Name = "ToolStripMenuItem_Appoiments";
            ToolStripMenuItem_Appoiments.Size = new Size(143, 22);
            ToolStripMenuItem_Appoiments.Text = "ادارة التعيينات";
            // 
            // ToolStripMenuItem_Statistics
            // 
            ToolStripMenuItem_Statistics.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_AddStatistic_Madani, ToolStripMenuItem_AddStatistic_Genaey, ToolStripMenuItem_AddStatistic_Osra, احصائيةقاضيToolStripMenuItem, احصائيةمحكمةابتدائيةToolStripMenuItem, احصائيةمحكمةجزئيةToolStripMenuItem });
            ToolStripMenuItem_Statistics.Name = "ToolStripMenuItem_Statistics";
            ToolStripMenuItem_Statistics.Size = new Size(73, 20);
            ToolStripMenuItem_Statistics.Text = "الاحصائيات";
            // 
            // ToolStripMenuItem_AddStatistic_Madani
            // 
            ToolStripMenuItem_AddStatistic_Madani.Name = "ToolStripMenuItem_AddStatistic_Madani";
            ToolStripMenuItem_AddStatistic_Madani.Size = new Size(186, 22);
            ToolStripMenuItem_AddStatistic_Madani.Text = "اضافة احصائية مدني";
            // 
            // ToolStripMenuItem_AddStatistic_Genaey
            // 
            ToolStripMenuItem_AddStatistic_Genaey.Name = "ToolStripMenuItem_AddStatistic_Genaey";
            ToolStripMenuItem_AddStatistic_Genaey.Size = new Size(186, 22);
            ToolStripMenuItem_AddStatistic_Genaey.Text = "اضافة احصائية جنائي";
            // 
            // ToolStripMenuItem_AddStatistic_Osra
            // 
            ToolStripMenuItem_AddStatistic_Osra.Name = "ToolStripMenuItem_AddStatistic_Osra";
            ToolStripMenuItem_AddStatistic_Osra.Size = new Size(186, 22);
            ToolStripMenuItem_AddStatistic_Osra.Text = "اضافة احصائية اسرة";
            // 
            // احصائيةقاضيToolStripMenuItem
            // 
            احصائيةقاضيToolStripMenuItem.Name = "احصائيةقاضيToolStripMenuItem";
            احصائيةقاضيToolStripMenuItem.Size = new Size(186, 22);
            احصائيةقاضيToolStripMenuItem.Text = "احصائية قاضي";
            // 
            // احصائيةمحكمةابتدائيةToolStripMenuItem
            // 
            احصائيةمحكمةابتدائيةToolStripMenuItem.Name = "احصائيةمحكمةابتدائيةToolStripMenuItem";
            احصائيةمحكمةابتدائيةToolStripMenuItem.Size = new Size(186, 22);
            احصائيةمحكمةابتدائيةToolStripMenuItem.Text = "احصائية محكمة ابتدائية";
            // 
            // احصائيةمحكمةجزئيةToolStripMenuItem
            // 
            احصائيةمحكمةجزئيةToolStripMenuItem.Name = "احصائيةمحكمةجزئيةToolStripMenuItem";
            احصائيةمحكمةجزئيةToolStripMenuItem.Size = new Size(186, 22);
            احصائيةمحكمةجزئيةToolStripMenuItem.Text = "احصائية محكمة جزئية";
            // 
            // ToolStripMenuItem_Reports
            // 
            ToolStripMenuItem_Reports.DropDownItems.AddRange(new ToolStripItem[] { الاحصائيةالشهريةToolStripMenuItem });
            ToolStripMenuItem_Reports.Name = "ToolStripMenuItem_Reports";
            ToolStripMenuItem_Reports.Size = new Size(47, 20);
            ToolStripMenuItem_Reports.Text = "تقارير";
            // 
            // الاحصائيةالشهريةToolStripMenuItem
            // 
            الاحصائيةالشهريةToolStripMenuItem.Name = "الاحصائيةالشهريةToolStripMenuItem";
            الاحصائيةالشهريةToolStripMenuItem.Size = new Size(162, 22);
            الاحصائيةالشهريةToolStripMenuItem.Text = "الاحصائية الشهرية";
            // 
            // ToolStripMenuItem_Settings
            // 
            ToolStripMenuItem_Settings.Name = "ToolStripMenuItem_Settings";
            ToolStripMenuItem_Settings.Size = new Size(62, 20);
            ToolStripMenuItem_Settings.Text = "الاعددات";
            // 
            // ToolStripMenuItem_Users
            // 
            ToolStripMenuItem_Users.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_AddUser, ToolStripMenuItem_ManageUsers, ToolStripMenuItem_Roles, ToolStripMenuItem_EditPassword });
            ToolStripMenuItem_Users.Name = "ToolStripMenuItem_Users";
            ToolStripMenuItem_Users.Size = new Size(79, 20);
            ToolStripMenuItem_Users.Text = "المستخدمين";
            // 
            // ToolStripMenuItem_AddUser
            // 
            ToolStripMenuItem_AddUser.Name = "ToolStripMenuItem_AddUser";
            ToolStripMenuItem_AddUser.Size = new Size(247, 22);
            ToolStripMenuItem_AddUser.Text = "اضافة مستخدم";
            // 
            // ToolStripMenuItem_ManageUsers
            // 
            ToolStripMenuItem_ManageUsers.Name = "ToolStripMenuItem_ManageUsers";
            ToolStripMenuItem_ManageUsers.Size = new Size(247, 22);
            ToolStripMenuItem_ManageUsers.Text = "ادارة المستخدمين";
            ToolStripMenuItem_ManageUsers.Click += ToolStripMenuItem_ManageUsers_Click;
            // 
            // ToolStripMenuItem_Roles
            // 
            ToolStripMenuItem_Roles.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_AddRole, ToolStripMenuItem_ManageRoles });
            ToolStripMenuItem_Roles.Name = "ToolStripMenuItem_Roles";
            ToolStripMenuItem_Roles.Size = new Size(247, 22);
            ToolStripMenuItem_Roles.Text = "الصلاحيات";
            // 
            // ToolStripMenuItem_AddRole
            // 
            ToolStripMenuItem_AddRole.Name = "ToolStripMenuItem_AddRole";
            ToolStripMenuItem_AddRole.Size = new Size(150, 22);
            ToolStripMenuItem_AddRole.Text = "اضافة صلاحية";
            // 
            // ToolStripMenuItem_ManageRoles
            // 
            ToolStripMenuItem_ManageRoles.Name = "ToolStripMenuItem_ManageRoles";
            ToolStripMenuItem_ManageRoles.Size = new Size(150, 22);
            ToolStripMenuItem_ManageRoles.Text = "ادارة الصلاحيات";
            // 
            // ToolStripMenuItem_EditPassword
            // 
            ToolStripMenuItem_EditPassword.Name = "ToolStripMenuItem_EditPassword";
            ToolStripMenuItem_EditPassword.Size = new Size(247, 22);
            ToolStripMenuItem_EditPassword.Text = "تعديل كلمة المرور للمستخدم الحالي";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.ItemSize = new Size(500, 35);
            tabControl1.Location = new Point(0, 24);
            tabControl1.MinimumSize = new Size(500, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.ShowToolTips = true;
            tabControl1.Size = new Size(1271, 595);
            tabControl1.TabIndex = 7;
            tabControl1.DrawItem += tabControl1_DrawItem;
            tabControl1.MouseClick += tabControl1_MouseClick;
            // 
            // tabPage1
            // 
            tabPage1.AllowDrop = true;
            tabPage1.AutoScroll = true;
            tabPage1.BackColor = Color.FromArgb(255, 255, 192);
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.RightToLeft = RightToLeft.Yes;
            tabPage1.Size = new Size(1263, 552);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "الرئيسيه";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 619);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "الرئيسية";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripMenuItem_File;
        private ToolStripMenuItem ToolStripMenuItem_Courts;
        private ToolStripMenuItem ToolStripMenuItem_SuperCourts;
        private ToolStripMenuItem ToolStripMenuItem_circles;
        private ToolStripMenuItem ToolStripMenuItem_AddCircle;
        private ToolStripMenuItem ToolStripMenuItem_ManageCircle;
        private ToolStripMenuItem ToolStripMenuItem_judges;
        private ToolStripMenuItem ToolStripMenuItem_AddJudge;
        private ToolStripMenuItem ToolStripMenuItem_AppointmentOfJudge;
        private ToolStripMenuItem ToolStripMenuItem_ManageJudges;
        private ToolStripMenuItem ToolStripMenuItem_Appoiments;
        private ToolStripMenuItem ToolStripMenuItem_Statistics;
        private ToolStripMenuItem ToolStripMenuItem_AddStatistic_Madani;
        private ToolStripMenuItem ToolStripMenuItem_AddStatistic_Genaey;
        private ToolStripMenuItem ToolStripMenuItem_Reports;
        private ToolStripMenuItem الاحصائيةالشهريةToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItem_Settings;
        private ToolStripMenuItem ToolStripMenuItem_Users;
        private ToolStripMenuItem ToolStripMenuItem_AddUser;
        private ToolStripMenuItem ToolStripMenuItem_ManageUsers;
        private ToolStripMenuItem ToolStripMenuItem_Roles;
        private ToolStripMenuItem ToolStripMenuItem_AddRole;
        private ToolStripMenuItem ToolStripMenuItem_ManageRoles;
        private ToolStripMenuItem ToolStripMenuItem_EditPassword;
        private ToolStripMenuItem اغلاقToolStripMenuItem;
        private TabPage tabPage1;
        public TabControl tabControl1;
        private ToolStripMenuItem ToolStripMenuItem_SupCourts;
        private ToolStripMenuItem ToolStripMenuItem_AddStatistic_Osra;
        private ToolStripMenuItem احصائيةقاضيToolStripMenuItem;
        private ToolStripMenuItem احصائيةمحكمةابتدائيةToolStripMenuItem;
        private ToolStripMenuItem احصائيةمحكمةجزئيةToolStripMenuItem;
    }
}