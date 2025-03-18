namespace StatisticsAPP.Forms.CircleForms
{
    partial class CircleDayForm
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
            comboBoxSupCourt = new ComboBox();
            comboBoxSuperCourt = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            btn_Save = new Button();
            text_Name = new TextBox();
            comboBox_Type = new ComboBox();
            comboBox_Day = new ComboBox();
            comboBox_Circle = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            panel3 = new Panel();
            dataGridView_CirleDays = new DataGridView();
            btnDelete = new DataGridViewButtonColumn();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_CirleDays).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBoxSupCourt);
            panel1.Controls.Add(comboBoxSuperCourt);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1180, 60);
            panel1.TabIndex = 0;
            // 
            // comboBoxSupCourt
            // 
            comboBoxSupCourt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxSupCourt.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSupCourt.FormattingEnabled = true;
            comboBoxSupCourt.Location = new Point(528, 21);
            comboBoxSupCourt.Name = "comboBoxSupCourt";
            comboBoxSupCourt.Size = new Size(184, 23);
            comboBoxSupCourt.TabIndex = 1;
            comboBoxSupCourt.SelectedIndexChanged += comboBoxSupCourt_SelectedIndexChanged;
            // 
            // comboBoxSuperCourt
            // 
            comboBoxSuperCourt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxSuperCourt.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSuperCourt.FormattingEnabled = true;
            comboBoxSuperCourt.Location = new Point(840, 24);
            comboBoxSuperCourt.Name = "comboBoxSuperCourt";
            comboBoxSuperCourt.Size = new Size(225, 23);
            comboBoxSuperCourt.TabIndex = 1;
            comboBoxSuperCourt.SelectedIndexChanged += comboBoxSuperCourt_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(718, 24);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 0;
            label2.Text = "المحكمة الفرعية";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(1071, 27);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 0;
            label1.Text = "المحكمة الابتدائية";
            // 
            // panel2
            // 
            panel2.Controls.Add(btn_Save);
            panel2.Controls.Add(text_Name);
            panel2.Controls.Add(comboBox_Type);
            panel2.Controls.Add(comboBox_Day);
            panel2.Controls.Add(comboBox_Circle);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(1180, 103);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // btn_Save
            // 
            btn_Save.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Save.Location = new Point(263, 65);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(75, 23);
            btn_Save.TabIndex = 3;
            btn_Save.Text = "اضافة";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // text_Name
            // 
            text_Name.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            text_Name.Location = new Point(383, 62);
            text_Name.Name = "text_Name";
            text_Name.Size = new Size(260, 23);
            text_Name.TabIndex = 2;
            // 
            // comboBox_Type
            // 
            comboBox_Type.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_Type.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Type.FormattingEnabled = true;
            comboBox_Type.Location = new Point(750, 62);
            comboBox_Type.Name = "comboBox_Type";
            comboBox_Type.Size = new Size(121, 23);
            comboBox_Type.TabIndex = 1;
            // 
            // comboBox_Day
            // 
            comboBox_Day.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_Day.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Day.FormattingEnabled = true;
            comboBox_Day.Location = new Point(944, 62);
            comboBox_Day.Name = "comboBox_Day";
            comboBox_Day.Size = new Size(121, 23);
            comboBox_Day.TabIndex = 1;
            // 
            // comboBox_Circle
            // 
            comboBox_Circle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_Circle.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Circle.FormattingEnabled = true;
            comboBox_Circle.Location = new Point(840, 12);
            comboBox_Circle.Name = "comboBox_Circle";
            comboBox_Circle.Size = new Size(225, 23);
            comboBox_Circle.TabIndex = 1;
            comboBox_Circle.SelectedIndexChanged += comboBox_Circle_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(668, 65);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 0;
            label5.Text = "الاسم";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(894, 65);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 0;
            label6.Text = "النوع";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(1098, 69);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 0;
            label4.Text = "اليوم";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(1098, 15);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 0;
            label3.Text = "الدائرة";
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridView_CirleDays);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 163);
            panel3.Name = "panel3";
            panel3.Size = new Size(1180, 411);
            panel3.TabIndex = 2;
            // 
            // dataGridView_CirleDays
            // 
            dataGridView_CirleDays.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_CirleDays.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_CirleDays.Columns.AddRange(new DataGridViewColumn[] { btnDelete });
            dataGridView_CirleDays.Dock = DockStyle.Fill;
            dataGridView_CirleDays.Location = new Point(0, 0);
            dataGridView_CirleDays.Name = "dataGridView_CirleDays";
            dataGridView_CirleDays.ReadOnly = true;
            dataGridView_CirleDays.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_CirleDays.Size = new Size(1180, 411);
            dataGridView_CirleDays.TabIndex = 1;
            dataGridView_CirleDays.CellClick += dataGridView_CirleDays_CellClick;
            // 
            // btnDelete
            // 
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.HeaderText = "";
            btnDelete.Name = "btnDelete";
            btnDelete.ReadOnly = true;
            btnDelete.Text = "حذف";
            btnDelete.ToolTipText = "حذف";
            btnDelete.UseColumnTextForButtonValue = true;
            // 
            // CircleDayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 574);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CircleDayForm";
            RightToLeft = RightToLeft.Yes;
            Text = "ايام انعقاد الدوائر";
            Load += CircleDayForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_CirleDays).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private ComboBox comboBoxSupCourt;
        private ComboBox comboBoxSuperCourt;
        private Label label2;
        private Label label1;
        private ComboBox comboBox_Circle;
        private Label label3;
        private Label label4;
        private DataGridView dataGridView_CirleDays;
        private TextBox text_Name;
        private ComboBox comboBox_Type;
        private ComboBox comboBox_Day;
        private Label label5;
        private Label label6;
        private Button btn_Save;
        private DataGridViewButtonColumn btnDelete;
    }
}