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
            label8 = new Label();
            panel5 = new Panel();
            panel7 = new Panel();
            dataGridView_CircleJudjes = new DataGridView();
            btnDeleteCircleJudge = new DataGridViewButtonColumn();
            panel6 = new Panel();
            textBox_Rate = new TextBox();
            label13 = new Label();
            button1 = new Button();
            date_End = new DateTimePicker();
            date_Start = new DateTimePicker();
            text_GudjeName = new TextBox();
            text_GudjeId = new TextBox();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            dataGridView_SearchJudjes = new DataGridView();
            btn_Select = new DataGridViewButtonColumn();
            text_SearchJudje = new TextBox();
            label7 = new Label();
            panel4 = new Panel();
            comboBox_Circle = new ComboBox();
            label3 = new Label();
            btn_Save = new Button();
            text_Name = new TextBox();
            comboBox_Type = new ComboBox();
            comboBox_Day = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            label4 = new Label();
            panel3 = new Panel();
            dataGridView_CirleDays = new DataGridView();
            btnDelete = new DataGridViewButtonColumn();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_CircleJudjes).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_SearchJudjes).BeginInit();
            panel4.SuspendLayout();
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
            panel1.Size = new Size(1180, 66);
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
            panel2.Controls.Add(label8);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(btn_Save);
            panel2.Controls.Add(text_Name);
            panel2.Controls.Add(comboBox_Type);
            panel2.Controls.Add(comboBox_Day);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 66);
            panel2.Name = "panel2";
            panel2.Size = new Size(1180, 301);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(867, 230);
            label8.Name = "label8";
            label8.Size = new Size(63, 15);
            label8.TabIndex = 6;
            label8.Text = "ايام الانعقاد";
            // 
            // panel5
            // 
            panel5.Controls.Add(panel7);
            panel5.Controls.Add(panel6);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 48);
            panel5.Name = "panel5";
            panel5.Size = new Size(1180, 169);
            panel5.TabIndex = 5;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.Fixed3D;
            panel7.Controls.Add(dataGridView_CircleJudjes);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(399, 169);
            panel7.TabIndex = 1;
            // 
            // dataGridView_CircleJudjes
            // 
            dataGridView_CircleJudjes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_CircleJudjes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_CircleJudjes.ColumnHeadersVisible = false;
            dataGridView_CircleJudjes.Columns.AddRange(new DataGridViewColumn[] { btnDeleteCircleJudge });
            dataGridView_CircleJudjes.Dock = DockStyle.Fill;
            dataGridView_CircleJudjes.Location = new Point(0, 0);
            dataGridView_CircleJudjes.Name = "dataGridView_CircleJudjes";
            dataGridView_CircleJudjes.ReadOnly = true;
            dataGridView_CircleJudjes.RowHeadersVisible = false;
            dataGridView_CircleJudjes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_CircleJudjes.Size = new Size(395, 165);
            dataGridView_CircleJudjes.TabIndex = 3;
            dataGridView_CircleJudjes.CellClick += dataGridView_CircleJudjes_CellClick;
            // 
            // btnDeleteCircleJudge
            // 
            btnDeleteCircleJudge.FlatStyle = FlatStyle.Flat;
            btnDeleteCircleJudge.HeaderText = "";
            btnDeleteCircleJudge.Name = "btnDeleteCircleJudge";
            btnDeleteCircleJudge.ReadOnly = true;
            btnDeleteCircleJudge.Text = "حذف";
            btnDeleteCircleJudge.ToolTipText = "حذف";
            btnDeleteCircleJudge.UseColumnTextForButtonValue = true;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(255, 255, 192);
            panel6.BorderStyle = BorderStyle.Fixed3D;
            panel6.Controls.Add(textBox_Rate);
            panel6.Controls.Add(label13);
            panel6.Controls.Add(button1);
            panel6.Controls.Add(date_End);
            panel6.Controls.Add(date_Start);
            panel6.Controls.Add(text_GudjeName);
            panel6.Controls.Add(text_GudjeId);
            panel6.Controls.Add(label12);
            panel6.Controls.Add(label11);
            panel6.Controls.Add(label10);
            panel6.Controls.Add(label9);
            panel6.Controls.Add(dataGridView_SearchJudjes);
            panel6.Controls.Add(text_SearchJudje);
            panel6.Controls.Add(label7);
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(399, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(781, 169);
            panel6.TabIndex = 0;
            // 
            // textBox_Rate
            // 
            textBox_Rate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox_Rate.Location = new Point(114, 18);
            textBox_Rate.Name = "textBox_Rate";
            textBox_Rate.Size = new Size(67, 23);
            textBox_Rate.TabIndex = 9;
            textBox_Rate.KeyPress += textBox_Rate_KeyPress;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Location = new Point(187, 21);
            label13.Name = "label13";
            label13.Size = new Size(41, 15);
            label13.TabIndex = 8;
            label13.Text = "الترتيب";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(4, 132);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "تسكين";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // date_End
            // 
            date_End.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            date_End.Location = new Point(103, 138);
            date_End.Name = "date_End";
            date_End.Size = new Size(244, 23);
            date_End.TabIndex = 6;
            // 
            // date_Start
            // 
            date_Start.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            date_Start.Location = new Point(103, 100);
            date_Start.Name = "date_Start";
            date_Start.Size = new Size(244, 23);
            date_Start.TabIndex = 6;
            // 
            // text_GudjeName
            // 
            text_GudjeName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            text_GudjeName.Location = new Point(103, 53);
            text_GudjeName.Name = "text_GudjeName";
            text_GudjeName.ReadOnly = true;
            text_GudjeName.Size = new Size(244, 23);
            text_GudjeName.TabIndex = 5;
            // 
            // text_GudjeId
            // 
            text_GudjeId.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            text_GudjeId.Location = new Point(280, 13);
            text_GudjeId.Name = "text_GudjeId";
            text_GudjeId.ReadOnly = true;
            text_GudjeId.Size = new Size(67, 23);
            text_GudjeId.TabIndex = 5;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(353, 140);
            label12.Name = "label12";
            label12.Size = new Size(69, 15);
            label12.TabIndex = 4;
            label12.Text = " تاريخ الانتهاء";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(353, 108);
            label11.Name = "label11";
            label11.Size = new Size(56, 15);
            label11.TabIndex = 4;
            label11.Text = "تاريخ البدء";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(353, 61);
            label10.Name = "label10";
            label10.Size = new Size(65, 15);
            label10.TabIndex = 4;
            label10.Text = "اسم القاضي";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(353, 21);
            label9.Name = "label9";
            label9.Size = new Size(62, 15);
            label9.TabIndex = 4;
            label9.Text = "رقم القاضي";
            // 
            // dataGridView_SearchJudjes
            // 
            dataGridView_SearchJudjes.Anchor = AnchorStyles.Top;
            dataGridView_SearchJudjes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_SearchJudjes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_SearchJudjes.ColumnHeadersVisible = false;
            dataGridView_SearchJudjes.Columns.AddRange(new DataGridViewColumn[] { btn_Select });
            dataGridView_SearchJudjes.Location = new Point(428, 47);
            dataGridView_SearchJudjes.Name = "dataGridView_SearchJudjes";
            dataGridView_SearchJudjes.ReadOnly = true;
            dataGridView_SearchJudjes.RowHeadersVisible = false;
            dataGridView_SearchJudjes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_SearchJudjes.Size = new Size(346, 118);
            dataGridView_SearchJudjes.TabIndex = 2;
            dataGridView_SearchJudjes.CellClick += dataGridView_SearchJudjes_CellClick;
            // 
            // btn_Select
            // 
            btn_Select.FlatStyle = FlatStyle.Flat;
            btn_Select.HeaderText = "";
            btn_Select.Name = "btn_Select";
            btn_Select.ReadOnly = true;
            btn_Select.Text = "اختيار";
            btn_Select.ToolTipText = "اختيار";
            btn_Select.UseColumnTextForButtonValue = true;
            // 
            // text_SearchJudje
            // 
            text_SearchJudje.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            text_SearchJudje.Location = new Point(428, 21);
            text_SearchJudje.Name = "text_SearchJudje";
            text_SearchJudje.Size = new Size(346, 23);
            text_SearchJudje.TabIndex = 3;
            text_SearchJudje.TextChanged += text_SearchJudje_TextChanged;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(464, 3);
            label7.Name = "label7";
            label7.Size = new Size(76, 15);
            label7.TabIndex = 1;
            label7.Text = "تسكين القضاه";
            // 
            // panel4
            // 
            panel4.Controls.Add(comboBox_Circle);
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1180, 48);
            panel4.TabIndex = 4;
            // 
            // comboBox_Circle
            // 
            comboBox_Circle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_Circle.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Circle.FormattingEnabled = true;
            comboBox_Circle.Location = new Point(867, 15);
            comboBox_Circle.Name = "comboBox_Circle";
            comboBox_Circle.Size = new Size(225, 23);
            comboBox_Circle.TabIndex = 1;
            comboBox_Circle.SelectedIndexChanged += comboBox_Circle_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(1125, 18);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 0;
            label3.Text = "الدائرة";
            // 
            // btn_Save
            // 
            btn_Save.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_Save.Location = new Point(302, 264);
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
            text_Name.Location = new Point(422, 261);
            text_Name.Name = "text_Name";
            text_Name.Size = new Size(260, 23);
            text_Name.TabIndex = 2;
            // 
            // comboBox_Type
            // 
            comboBox_Type.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_Type.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Type.FormattingEnabled = true;
            comboBox_Type.Location = new Point(789, 261);
            comboBox_Type.Name = "comboBox_Type";
            comboBox_Type.Size = new Size(121, 23);
            comboBox_Type.TabIndex = 1;
            // 
            // comboBox_Day
            // 
            comboBox_Day.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox_Day.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Day.FormattingEnabled = true;
            comboBox_Day.Location = new Point(983, 261);
            comboBox_Day.Name = "comboBox_Day";
            comboBox_Day.Size = new Size(121, 23);
            comboBox_Day.TabIndex = 1;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(707, 264);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 0;
            label5.Text = "الاسم";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(933, 264);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 0;
            label6.Text = "النوع";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(1137, 268);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 0;
            label4.Text = "اليوم";
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridView_CirleDays);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 367);
            panel3.Name = "panel3";
            panel3.Size = new Size(1180, 207);
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
            dataGridView_CirleDays.Size = new Size(1180, 207);
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
            panel5.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView_CircleJudjes).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView_SearchJudjes).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
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
        private Panel panel5;
        private Panel panel6;
        private Panel panel4;
        private Panel panel7;
        private DataGridView dataGridView_SearchJudjes;
        private TextBox text_SearchJudje;
        private Label label7;
        private Label label8;
        private DataGridView dataGridView_CircleJudjes;
        private Label label9;
        private DateTimePicker date_End;
        private DateTimePicker date_Start;
        private TextBox text_GudjeName;
        private TextBox text_GudjeId;
        private Label label12;
        private Label label11;
        private Label label10;
        private DataGridViewButtonColumn btn_Select;
        private Button button1;
        private DataGridViewButtonColumn btnDeleteCircleJudge;
        private TextBox textBox_Rate;
        private Label label13;
    }
}