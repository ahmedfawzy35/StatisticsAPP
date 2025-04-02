using System;
using System.Drawing;
using System.Windows.Forms;

public class CustomDataGridView : DataGridView
{
    public CustomDataGridView()
    {
        // تفعيل التصميم الاحترافي
        InitializeGridStyle();
    }

    private void InitializeGridStyle()
    {
        this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        this.AllowUserToAddRows = false;
        this.ReadOnly = true;
        this.ColumnHeadersHeight = 40;
        this.EnableHeadersVisualStyles = false;

        // تصميم رأس الجدول
        this.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
        this.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        this.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

        // تصميم الصفوف
        this.DefaultCellStyle.BackColor = Color.White;
        this.DefaultCellStyle.ForeColor = Color.Black;
        this.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
        this.DefaultCellStyle.SelectionForeColor = Color.White;
        this.RowTemplate.Height = 30;

        // إلغاء الحدود التقليدية
        this.BorderStyle = BorderStyle.None;
        this.CellBorderStyle = DataGridViewCellBorderStyle.None;
        this.RowHeadersVisible = false;

        // تأثير Hover
        this.CellMouseEnter += (s, e) =>
        {
            if (e.RowIndex >= 0)
                this.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
        };

        this.CellMouseLeave += (s, e) =>
        {
            if (e.RowIndex >= 0)
                this.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        };

        // تحسين الأداء عند التعامل مع بيانات كبيرة
        typeof(DataGridView).InvokeMember("DoubleBuffered",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
            null, this, new object[] { true });
    }

    // دالة لإضافة زر داخل كل صف
    public void AddButtonColumn(string columnName, string buttonText)
    {
        DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
        {
            HeaderText = columnName,
            Text = buttonText,
            UseColumnTextForButtonValue = true,
            FlatStyle = FlatStyle.Flat
        };
        this.Columns.Add(btnColumn);
    }
}
