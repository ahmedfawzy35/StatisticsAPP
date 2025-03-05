namespace StatisticsAPP.Forms.CourtsForms
{
    partial class SuperCourtManageForm
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
            dataGridView_SuperCourts = new DataGridView();
            btn_Refresh = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Loading).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_SuperCourts).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Refresh);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(964, 89);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 508);
            panel2.Name = "panel2";
            panel2.Size = new Size(964, 88);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox_Loading);
            panel3.Controls.Add(dataGridView_SuperCourts);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 89);
            panel3.Name = "panel3";
            panel3.Size = new Size(964, 419);
            panel3.TabIndex = 2;
            // 
            // pictureBox_Loading
            // 
            pictureBox_Loading.Image = Properties.Resources.loading_gif;
            pictureBox_Loading.Location = new Point(151, 53);
            pictureBox_Loading.Name = "pictureBox_Loading";
            pictureBox_Loading.Size = new Size(389, 25);
            pictureBox_Loading.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_Loading.TabIndex = 1;
            pictureBox_Loading.TabStop = false;
            pictureBox_Loading.Visible = false;
            // 
            // dataGridView_SuperCourts
            // 
            dataGridView_SuperCourts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_SuperCourts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_SuperCourts.Dock = DockStyle.Fill;
            dataGridView_SuperCourts.Location = new Point(0, 0);
            dataGridView_SuperCourts.Name = "dataGridView_SuperCourts";
            dataGridView_SuperCourts.ReadOnly = true;
            dataGridView_SuperCourts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_SuperCourts.Size = new Size(964, 419);
            dataGridView_SuperCourts.TabIndex = 1;
            // 
            // btn_Refresh
            // 
            btn_Refresh.Location = new Point(23, 12);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Size = new Size(100, 60);
            btn_Refresh.TabIndex = 0;
            btn_Refresh.Text = "تحديث";
            btn_Refresh.UseVisualStyleBackColor = true;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // SuperCourtManageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 596);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "SuperCourtManageForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "ادارة المحاكم الابتدائية";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Loading).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_SuperCourts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox_Loading;
        private DataGridView dataGridView_SuperCourts;
        private Button btn_Refresh;
    }
}