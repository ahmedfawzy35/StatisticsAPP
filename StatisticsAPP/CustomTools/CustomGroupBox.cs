using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class CustomGroupBox : GroupBox
{
    public Color BorderColor { get; set; } = Color.Blue;  // لون الإطار
    public int BorderRadius { get; set; } = 28;          // درجة استدارة الزوايا
    public Color BackgroundColor { get; set; } = SystemColors.Control; // لون الخلفية
    public float TitleFontSize { get; set; } = 12f;      // حجم الخط
    public int BorderThickness { get; set; } = 2;        // سمك الإطار  
    public Color TitleBackgroundColor { get; set; } = Color.Yellow; // خلفية العنوان

    public CustomGroupBox()
    {
        this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        this.ForeColor = Color.Black;
        this.RightToLeft = RightToLeft.Yes; // ✅ ضبط الاتجاه إلى اليمين
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias; // تحسين الجودة

        // رسم الخلفية يدويًا لمنع الوميض
        using (SolidBrush bgBrush = new SolidBrush(BackgroundColor))
        {
            g.FillRectangle(bgBrush, this.ClientRectangle);
        }

        Rectangle rect = new Rectangle(BorderThickness / 2, 15 + (BorderThickness / 2),
                                       this.Width - BorderThickness,
                                       this.Height - 20 - BorderThickness);

        using (GraphicsPath path = GetRoundedRect(rect, BorderRadius))
        using (Pen borderPen = new Pen(BorderColor, BorderThickness))
        {
            g.DrawPath(borderPen, path); // رسم الإطار فقط
        }

        // رسم مستطيل العنوان في الأعلى
        using (Font titleFont = new Font(this.Font.FontFamily, TitleFontSize, FontStyle.Bold))
        using (SolidBrush titleBrush = new SolidBrush(this.ForeColor))
        using (SolidBrush titleBgBrush = new SolidBrush(TitleBackgroundColor))
        {
            SizeF textSize = g.MeasureString(this.Text, titleFont);
            int titleHeight = (int)textSize.Height + 6;
            int titleWidth = (int)textSize.Width + 10;
            int titleX = this.Width - titleWidth - 10; // ✅ محاذاة النص لليمين
            int titleY = 0;

            // رسم خلفية العنوان
            g.FillRectangle(titleBgBrush, titleX, titleY, titleWidth, titleHeight);

            // رسم النص
            g.DrawString(this.Text, titleFont, titleBrush, titleX + 5, titleY + 2);
        }
    }

    // دالة لإنشاء مستطيل بزوايا دائرية
    private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int arcDiameter = radius * 2;

        path.AddArc(rect.Left, rect.Top, arcDiameter, arcDiameter, 180, 90);
        path.AddArc(rect.Right - arcDiameter, rect.Top, arcDiameter, arcDiameter, 270, 90);
        path.AddArc(rect.Right - arcDiameter, rect.Bottom - arcDiameter, arcDiameter, arcDiameter, 0, 90);
        path.AddArc(rect.Left, rect.Bottom - arcDiameter, arcDiameter, arcDiameter, 90, 90);
        path.CloseFigure();

        return path;
    }
}
