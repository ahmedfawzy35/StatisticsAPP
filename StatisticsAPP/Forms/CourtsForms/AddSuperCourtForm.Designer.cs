namespace StatisticsAPP.Forms.CourtsForms
{
    partial class AddSuperCourtForm
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
            text_Name = new TextBox();
            lbl_IdEdit = new Label();
            btn_Save = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 81);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "اسم المحكمة";
            // 
            // text_Name
            // 
            text_Name.Location = new Point(121, 73);
            text_Name.Name = "text_Name";
            text_Name.Size = new Size(248, 23);
            text_Name.TabIndex = 1;
            // 
            // lbl_IdEdit
            // 
            lbl_IdEdit.AutoSize = true;
            lbl_IdEdit.Location = new Point(53, 26);
            lbl_IdEdit.Name = "lbl_IdEdit";
            lbl_IdEdit.Size = new Size(0, 15);
            lbl_IdEdit.TabIndex = 0;
            // 
            // btn_Save
            // 
            btn_Save.Location = new Point(152, 268);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(169, 49);
            btn_Save.TabIndex = 2;
            btn_Save.Text = "حفظ";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += btn_Save_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.loading_gif;
            pictureBox1.Location = new Point(274, 278);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 29);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // AddSuperCourtForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 439);
            Controls.Add(pictureBox1);
            Controls.Add(btn_Save);
            Controls.Add(text_Name);
            Controls.Add(lbl_IdEdit);
            Controls.Add(label1);
            Name = "AddSuperCourtForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "اضافة محكمة ابتدائية";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox text_Name;
        private Label lbl_IdEdit;
        private Button btn_Save;
        private PictureBox pictureBox1;
    }
}