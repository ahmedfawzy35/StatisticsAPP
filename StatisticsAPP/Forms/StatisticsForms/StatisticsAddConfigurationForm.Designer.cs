namespace StatisticsAPP.Forms.StatisticsForms
{
    partial class StatisticsAddConfigurationForm
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
            label1 = new Label();
            comboBox_Month = new ComboBox();
            label2 = new Label();
            comboBox_Year = new ComboBox();
            label3 = new Label();
            comboBox_SuperCourt = new ComboBox();
            label4 = new Label();
            comboBox_CircleMasterType = new ComboBox();
            label5 = new Label();
            comboBox_SupCourt = new ComboBox();
            label7 = new Label();
            comboBox_CircleType = new ComboBox();
            btn_Save = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(6, 36);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 0;
            label1.Text = "الشهر";
            // 
            // comboBox_Month
            // 
            comboBox_Month.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_Month.FormattingEnabled = true;
            comboBox_Month.Location = new Point(103, 33);
            comboBox_Month.Name = "comboBox_Month";
            comboBox_Month.Size = new Size(121, 23);
            comboBox_Month.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(356, 36);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 0;
            label2.Text = "السنة";
            // 
            // comboBox_Year
            // 
            comboBox_Year.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_Year.FormattingEnabled = true;
            comboBox_Year.Location = new Point(445, 36);
            comboBox_Year.Name = "comboBox_Year";
            comboBox_Year.Size = new Size(121, 23);
            comboBox_Year.TabIndex = 1;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(356, 110);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 0;
            label3.Text = "النوع";
            // 
            // comboBox_SuperCourt
            // 
            comboBox_SuperCourt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_SuperCourt.FormattingEnabled = true;
            comboBox_SuperCourt.Location = new Point(103, 102);
            comboBox_SuperCourt.Name = "comboBox_SuperCourt";
            comboBox_SuperCourt.Size = new Size(121, 23);
            comboBox_SuperCourt.TabIndex = 1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(6, 105);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 0;
            label4.Text = "المحكمة الابتدائية";
            // 
            // comboBox_CircleMasterType
            // 
            comboBox_CircleMasterType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_CircleMasterType.FormattingEnabled = true;
            comboBox_CircleMasterType.Location = new Point(445, 105);
            comboBox_CircleMasterType.Name = "comboBox_CircleMasterType";
            comboBox_CircleMasterType.Size = new Size(121, 23);
            comboBox_CircleMasterType.TabIndex = 1;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(356, 176);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 0;
            label5.Text = "المحكمة الجزئية";
            // 
            // comboBox_SupCourt
            // 
            comboBox_SupCourt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_SupCourt.FormattingEnabled = true;
            comboBox_SupCourt.Location = new Point(445, 176);
            comboBox_SupCourt.Name = "comboBox_SupCourt";
            comboBox_SupCourt.Size = new Size(121, 23);
            comboBox_SupCourt.TabIndex = 1;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(6, 176);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 0;
            label7.Text = "نوع الدائرة";
            // 
            // comboBox_CircleType
            // 
            comboBox_CircleType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_CircleType.FormattingEnabled = true;
            comboBox_CircleType.Location = new Point(103, 173);
            comboBox_CircleType.Name = "comboBox_CircleType";
            comboBox_CircleType.Size = new Size(121, 23);
            comboBox_CircleType.TabIndex = 1;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(356, 283);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(148, 59);
            btn_Save.TabIndex = 2;
            btn_Save.Text = "موافق";
            btn_Save.UseVisualStyleBackColor = true;
            // 
            // StatisticsAddConfigurationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1241, 411);
            Controls.Add(btn_Save);
            Controls.Add(comboBox_CircleMasterType);
            Controls.Add(comboBox_CircleType);
            Controls.Add(comboBox_Year);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(label2);
            Controls.Add(comboBox_SuperCourt);
            Controls.Add(comboBox_SupCourt);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(comboBox_Month);
            Controls.Add(label1);
            Name = "StatisticsAddConfigurationForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "اختيار بيانات الاحصائية";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox comboBox_Month;
        private Label label2;
        private ComboBox comboBox_Year;
        private Label label3;
        private ComboBox comboBox_SuperCourt;
        private Label label4;
        private ComboBox comboBox_CircleMasterType;
        private Label label5;
        private ComboBox comboBox_SupCourt;
        private Label label7;
        private ComboBox comboBox_CircleType;
        private Button btn_Save;
    }
}