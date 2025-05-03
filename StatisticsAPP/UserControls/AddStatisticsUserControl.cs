using Microsoft.EntityFrameworkCore;
using StatisticsAPP.Forms.MainForm;
using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Models.StatisticsModels;
using StatisticsAPP.Servicies.CircleServicies.DTOS;
using StatisticsAPP.Servicies.StatisticsCervicies;
using StatisticsAPP.Servicies.StatisticsCervicies.DTOS;
using StatisticsAPP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatisticsAPP.UserControls
{
    public partial class AddStatisticsUserControl : UserControl
    {
        #region fff
        public StatisticsFormConfig? Config { get; set; }
        public CircleStatistics? circleStatistics { get; set; }
        bool isEditCircleStatistics = false;
        bool isEditCircleStatisticsForYear = false;
        List<Circle> userCircles;
        private Dictionary<string, int> months = new Dictionary<string, int> { };


        #endregion

        readonly DataTable dt = new();
        private int hoveredRowIndex = -1;
        private int hoveredColumnIndex = -1;
        List<StatistaicsDto> StatisticsList;
        public AddStatisticsUserControl()
        {
            InitializeComponent();
            #region fff
            userCircles = LocalUser.userCircles;
            comboBox_Circles.MouseWheel += new MouseEventHandler(comboBox1_MouseWheel);
            comboBox_CircleDays.MouseWheel += new MouseEventHandler(comboBox1_MouseWheel);


            #endregion



            BindingList<StatistaicsDto> statisticsList = new BindingList<StatistaicsDto>(MyCervicies.statisticsManager.StatisticsList());
            dataGridView_StatisticInformation.DataSource = statisticsList;
            StatisticsList = MyCervicies.statisticsManager.StatisticsList();
            dataGridView_StatisticInformation.DataSource = StatisticsList;
            dataGridView_Juge1.DataSource = StatisticsList;
            dataGridView_Juge2.DataSource = StatisticsList;
            dataGridView_Juge3.DataSource = StatisticsList;
            dataGridView_Juge4.DataSource = StatisticsList;

            EditColoumnsWidth(dataGridView_Juge1);
            EditColoumnsWidth(dataGridView_StatisticInformation);
            EditColoumnsWidth(dataGridView_Juge2);
            EditColoumnsWidth(dataGridView_Juge3);
            EditColoumnsWidth(dataGridView_Juge4);
        }

        #region fff

        private void GetCircles()
        {
            var circlesQuery = userCircles.Where(x => x.IdSupCourt == Config!.SupCourtId &&
                                                 x.IdCircleCategory == Config.CircleCtogryId);

            var circlesQuery2 = userCircles.Where(x => x.SupCourt!.SuperCourtId == Config!.SuperCourtId &&
                                                  x.IdCircleCategory == Config.CircleCtogryId);

            var circls = Config!.SupCourtId == 0 ? circlesQuery2.ToList() : circlesQuery.ToList();

            var circleToView = circls.Where(x => (x.CircleDays.Where(cd => cd.CircleType.IdCircleMasterType == Config.CircleMasterTypeId).ToList().Count > 0)).ToList();





            comboBox_Circles.DataSource = circleToView;
            comboBox_Circles.DisplayMember = "Name";
            comboBox_Circles.ValueMember = "Id";

        }
        private void GetCirclDays()
        {
            var circle = (Circle)comboBox_Circles.SelectedItem!;
            if (circle == null) { MessageBox.Show("CircleDay is null"); return; }
            var _circle = userCircles.Where(x => x.Id == circle.Id).First();

            var circledays = _circle.CircleDays!.Where(cd => cd.CircleType!.IdCircleMasterType == Config!.CircleMasterTypeId).ToList();

            comboBox_CircleDays.DataSource = circledays;
            comboBox_CircleDays.DisplayMember = "Name";
            comboBox_CircleDays.ValueMember = "Id";

            GetJudges();
        }
        private void GetJudges()
        {
            var circle = (Circle)comboBox_Circles.SelectedItem!;
            if (circle == null) { MessageBox.Show("CircleDay is null"); return; }

            var judges = MyContext.context.CircleJudges.Include(j => j.Judge).Where(cj => cj.IdCircle == circle.Id && cj.DateStart <= DateTime.Now.Date && cj.DateEnd >= DateTime.Now.Date).Select(x => new CircleJudgeDto
            {
                IdJudge = x.IdJudge,
                NameJudge = x.Judge!.Name!,
                DateEnd = x.DateEnd,
                DateStart = x.DateStart,
                Id = x.Id,
                IdCircle = x.IdCircle,
                rate = x.Rate,

            }
            ).ToList();

            //comboBox_Tawzie_Judje.DataSource = judges;
            //comboBox_Tawzie_Judje.DisplayMember = "NameJudge";
            //comboBox_Tawzie_Judje.ValueMember = "IdJudge";
        }
        private void GetStatistic()
        {
            if (Config == null) { return; }
            var circle = (Circle)comboBox_Circles.SelectedItem!;
            if (circle == null) { MessageBox.Show("CircleDay is null"); return; }
            var circleday = comboBox_CircleDays.SelectedItem as CircleDay;
            if (circleday == null)
            {
                MessageBox.Show("CircleDay is null");
                
                return;

            }

            circleStatistics = MyContext.context.CircleStatistics
                .Include(x => x.StatisticsDecisions!)
                    .ThenInclude(x => x.CaseYear!)
                .Include(x => x.StatisticsInterCases!)
                    .ThenInclude(x => x.CaseYear!)
                .Include(x => x.StatisticsDelayCases!)
                    .ThenInclude(x => x.CaseYear!)
                .Include(x => x.CircleDay!)
                    .ThenInclude(x => x.DelayCacesForMonths!)
                .FirstOrDefault(x => x.IdCircleDay == circleday.Id && x.Year == Config.Year && x.Month == Config.Month);

            if (circleStatistics == null)
            {
                MessageBox.Show("لم يتم فتح الاحصائية بعد ");
             
              

                dataGridView_StatisticInformation.Enabled = false;
                dataGridView_Juge1.Enabled = false;
                dataGridView_Juge2.Enabled = false;
                dataGridView_Juge3.Enabled = false;
                dataGridView_Juge4.Enabled = false;
                dataGridView_Ethbat.Enabled = false;
                dataGridView_Mahgouz.Enabled = false;
                dataGridView_MadAgal.Enabled = false;
                dataGridView_Morafea.Enabled = false;
                dataGridView_Baki.Enabled = false;
                button1.Enabled = false;
                return;
            }
            else
            {
                dataGridView_StatisticInformation.Enabled = true;
                dataGridView_Juge1.Enabled = true;
                dataGridView_Juge2.Enabled = true;
                dataGridView_Juge3.Enabled = true;
                dataGridView_Juge4.Enabled = true;
                dataGridView_Ethbat.Enabled = true;
                dataGridView_Mahgouz.Enabled = true;
                dataGridView_MadAgal.Enabled = true;
                dataGridView_Morafea.Enabled = true;
                dataGridView_Baki.Enabled = true;
                button1.Enabled = true;
            }
        }
        private string GetArabicMonthName(int month)
        {
            return new DateTime(1, month, 1)
                .ToString("MMMM", new CultureInfo("ar-AE")); // أو "ar-EG" للغة المصرية
        }

     


        private void comboBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        #endregion
        void EditColoumnsWidth(DataGridView dataGridView)
        {
            int totalWidth = this.Width;
            int colwidth = totalWidth / 39;
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {

                col.Width = colwidth;

            }
            dataGridView.Columns[0].Width = colwidth * 3;
            dataGridView.Invalidate();
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // تخصيص رسم رؤوس الأعمدة فقط
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true); // رسم الخلفية

                string headerText = dataGridView_StatisticInformation.Columns[e.ColumnIndex].HeaderText;

                using (Brush brush = new SolidBrush(dataGridView_StatisticInformation.ColumnHeadersDefaultCellStyle.ForeColor))
                {
                    SizeF textSize = e.Graphics!.MeasureString(headerText, dataGridView_StatisticInformation.ColumnHeadersDefaultCellStyle.Font);

                    // تدوير النص
                    e.Graphics.TranslateTransform(
                        e.CellBounds.Left + (e.CellBounds.Width / 2),
                        e.CellBounds.Top + e.CellBounds.Height
                    );
                    e.Graphics.RotateTransform(-90);

                    // رسم النص في المنتصف
                    e.Graphics.DrawString(
                        headerText,
                        dataGridView_StatisticInformation.ColumnHeadersDefaultCellStyle.Font,
                        brush,
                        new PointF((e.CellBounds.Height - textSize.Width) / 2, -textSize.Height / 2)
                    );
                }

                e.Graphics.ResetTransform(); // إرجاع الوضع الطبيعي
                e.Handled = true; // منع الرسم التلقائي
            }
        }
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            hoveredRowIndex = e.RowIndex;
            hoveredColumnIndex = e.ColumnIndex;

            // تظليل الصف والعمود
            dataGridView_StatisticInformation.Columns[hoveredColumnIndex].HeaderCell.Style.BackColor = Color.YellowGreen;

            dataGridView_StatisticInformation.Rows[hoveredRowIndex].Cells[0].Style.BackColor = Color.YellowGreen;

            //for (int i = 0; i < dataGridView1.ColumnCount; i++)
            //{
            //    dataGridView1.Rows[hoveredRowIndex].Cells[i].Style.BackColor = Color.OrangeRed;
            //}

            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    dataGridView1.Rows[i].Cells[hoveredColumnIndex].Style.BackColor = Color.OrangeRed;
            //}
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (hoveredRowIndex < 0 || hoveredColumnIndex < 0)
                return;


            // إعادة لون الصف

            dataGridView_StatisticInformation.Columns[hoveredColumnIndex].HeaderCell.Style.BackColor = Color.LightGray;

            dataGridView_StatisticInformation.Rows[hoveredRowIndex].Cells[0].Style.BackColor = Color.White;


            //for (int i = 0; i < dataGridView1.ColumnCount; i++)
            //{
            //    dataGridView1.Rows[hoveredRowIndex].Cells[i].Style.BackColor = Color.White;
            //}

            //// إعادة لون العمود
            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            //    dataGridView1.Rows[i].Cells[hoveredColumnIndex].Style.BackColor = Color.White;
            //}

            hoveredRowIndex = -1;
            hoveredColumnIndex = -1;
        }
        void HighlightRowAndColumn(DataGridView grid, int rowIndex, int colIndex)
        {
            grid.Columns[colIndex].HeaderCell.Style.BackColor = Color.YellowGreen;
            grid.Rows[rowIndex].Cells[0].Style.BackColor = Color.YellowGreen;
            grid.Columns[colIndex].HeaderCell.Style.BackColor = Color.LightGreen;

        }
        private void ResetGridColors(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }

            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.HeaderCell.Style.BackColor = Color.White;
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            ResetGridColors(dataGridView);

            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;

            HighlightRowAndColumn(dataGridView, rowIndex, colIndex);

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            ResetGridColors(dataGridView);
        }
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int result;
            if (
                !int.TryParse(Convert.ToString(e.FormattedValue), out result))
            {
                e.Cancel = true;
                MessageBox.Show("من فضلك أدخل رقم صحيح فقط.");
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // التحقق من اسم العمود
            string columnName = dataGridView_StatisticInformation.Columns[e.ColumnIndex].HeaderText;

            if (columnName == "جملة المقدم" || columnName == "جملة الاحكام القطعية" || columnName == "جملة الاثبات" || columnName == "جملة الوقف" || columnName == "جملة المحكوم فيه" || columnName == "جملة المؤجل")
            {
                // تغيير لون العمود "جملة المحكوم فيه" إلى لون معين
                e.CellStyle.BackColor = Color.FromArgb(32, 178, 170);
                dataGridView_StatisticInformation.Columns[e.ColumnIndex].HeaderCell.Style.BackColor = Color.FromArgb(32, 178, 170);
            }
        }

        private void AddStatisticsUserControl_Load(object sender, EventArgs e)
        {
            GetCircles();
            Text_SupCourt.Text = Config.SupCourtName;
            Text_SuperCourt.Text = Config.SuperCourtName;
            Text_Year.Text = Config.Year.ToString();
            Text_Month.Text = GetArabicMonthName(Config.Month);
            Text_CircleCtogry.Text = Config.CircleCtogryName;
            Text_CircleMasterType.Text = Config.CircleMasterTypeName;
        }

        private void comboBox_Circles_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCirclDays();
        }

        private void comboBox_CircleDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetStatistic();
        }
    }
}
