namespace StatisticsAPP.Forms.StatisticsForms
{
    partial class StatisticsAddForm
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
            addStatisticsUserControl1 = new StatisticsAPP.UserControls.AddStatisticsUserControl();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1557, 47);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.Controls.Add(addStatisticsUserControl1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 47);
            panel2.Name = "panel2";
            panel2.Size = new Size(1557, 552);
            panel2.TabIndex = 1;
            // 
            // addStatisticsUserControl1
            // 
            addStatisticsUserControl1.AutoScroll = true;
            addStatisticsUserControl1.Dock = DockStyle.Top;
            addStatisticsUserControl1.Font = new Font("Cairo", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addStatisticsUserControl1.Location = new Point(0, 0);
            addStatisticsUserControl1.Margin = new Padding(3, 5, 3, 5);
            addStatisticsUserControl1.Name = "addStatisticsUserControl1";
            addStatisticsUserControl1.RightToLeft = RightToLeft.Yes;
            addStatisticsUserControl1.Size = new Size(1540, 3498);
            addStatisticsUserControl1.TabIndex = 0;
            // 
            // StatisticsAddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1557, 599);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "StatisticsAddForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "اضافة احصائية";
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private UserControls.AddStatisticsUserControl addStatisticsUserControl1;
    }
}