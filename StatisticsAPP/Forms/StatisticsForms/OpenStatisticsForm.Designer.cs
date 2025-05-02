namespace StatisticsAPP.Forms.StatisticsForms
{
    partial class OpenStatisticsForm
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
            comboBox_Year = new ComboBox();
            label2 = new Label();
            comboBox_Month = new ComboBox();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBox_Year
            // 
            comboBox_Year.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_Year.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Year.FormattingEnabled = true;
            comboBox_Year.Location = new Point(146, 81);
            comboBox_Year.Name = "comboBox_Year";
            comboBox_Year.Size = new Size(121, 23);
            comboBox_Year.TabIndex = 7;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(49, 81);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 4;
            label2.Text = "السنة";
            // 
            // comboBox_Month
            // 
            comboBox_Month.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_Month.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Month.FormattingEnabled = true;
            comboBox_Month.Location = new Point(146, 29);
            comboBox_Month.Name = "comboBox_Month";
            comboBox_Month.Size = new Size(121, 23);
            comboBox_Month.TabIndex = 6;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(49, 32);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 5;
            label1.Text = "الشهر";
            // 
            // button1
            // 
            button1.Location = new Point(146, 176);
            button1.Name = "button1";
            button1.Size = new Size(107, 59);
            button1.TabIndex = 8;
            button1.Text = "فتح";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // OpenStatisticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(356, 288);
            Controls.Add(button1);
            Controls.Add(comboBox_Year);
            Controls.Add(label2);
            Controls.Add(comboBox_Month);
            Controls.Add(label1);
            Name = "OpenStatisticsForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "OpenStatisticsForm";
            Load += OpenStatisticsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox_Year;
        private Label label2;
        private ComboBox comboBox_Month;
        private Label label1;
        private Button button1;
    }
}