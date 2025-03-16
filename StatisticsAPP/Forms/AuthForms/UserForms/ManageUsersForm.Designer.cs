namespace StatisticsAPP.Forms.AuthForms.UserForms
{
    partial class ManageUsersForm
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
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox_Loading = new PictureBox();
            dataGridView_Users = new DataGridView();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Loading).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Users).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1224, 100);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 463);
            panel2.Name = "panel2";
            panel2.Size = new Size(1224, 100);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox_Loading);
            panel3.Controls.Add(dataGridView_Users);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 100);
            panel3.Name = "panel3";
            panel3.Size = new Size(1224, 363);
            panel3.TabIndex = 2;
            // 
            // pictureBox_Loading
            // 
            pictureBox_Loading.Image = Properties.Resources.loading_gif;
            pictureBox_Loading.Location = new Point(0, 0);
            pictureBox_Loading.Name = "pictureBox_Loading";
            pictureBox_Loading.Size = new Size(1160, 363);
            pictureBox_Loading.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_Loading.TabIndex = 0;
            pictureBox_Loading.TabStop = false;
            pictureBox_Loading.Visible = false;
            // 
            // dataGridView_Users
            // 
            dataGridView_Users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_Users.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Users.Dock = DockStyle.Fill;
            dataGridView_Users.Location = new Point(0, 0);
            dataGridView_Users.Name = "dataGridView_Users";
            dataGridView_Users.ReadOnly = true;
            dataGridView_Users.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_Users.Size = new Size(1224, 363);
            dataGridView_Users.TabIndex = 0;
            // 
            // ManageUsersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 563);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ManageUsersForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "ادارة المستخدمين";
            Load += ManageUsersForm_Load;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Loading).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Users).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dataGridView_Users;
        private PictureBox pictureBox_Loading;
    }
}