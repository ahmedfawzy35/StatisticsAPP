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
        public CircleDayStatistaicsDto? circleStatistics { get; set; }
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


            //circleStatistics = await manager.GetStatistaicsDtoAsync(circleday.Id, circle.Id, Config.Month, Config.Year);
            //BindingList<StatistaicsDto> statisticsList = new BindingList<StatistaicsDto>(circleStatistics.StaticsForYear!);
            //dataGridView_StatisticInformation.DataSource = statisticsList;
            //BindingList<StatistaicsDto> statisticsList = new BindingList<StatistaicsDto>(circleStatistics.StaticsForYear!);
            //dataGridView_StatisticInformation.DataSource = statisticsList;




            //StatisticsList = MyCervicies.statisticsManager.StatisticsList();
            //dataGridView_StatisticInformation.DataSource = StatisticsList;
            //dataGridView_Juge1.DataSource = StatisticsList;
            //dataGridView_Juge2.DataSource = StatisticsList;
            //dataGridView_Juge3.DataSource = StatisticsList;
            //dataGridView_Juge4.DataSource = StatisticsList;



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
        private async Task GetStatistic()
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
            StatisticsManager manager = new StatisticsManager(new Data.ApplicationDbContext());
            circleStatistics = await manager.GetStatistaicsDtoAsync(circleday.Id, circle.Id, Config.Month, Config.Year);
            if (circleStatistics == null)
            {
                MessageBox.Show("لم يتم فتح الاحصائية بعد ");
                return;
            }
            string juge1Name = circleStatistics.Judges!.Count < 1 ? " ": circleStatistics.Judges!.Where(x => x.Rate == 1).FirstOrDefault()!.Judge!.Name!;
            string juge2Name = circleStatistics.Judges!.Count < 2 ? " " : circleStatistics.Judges!.Where(x => x.Rate == 2).FirstOrDefault()!.Judge!.Name!;
            string juge3Name = circleStatistics.Judges!.Count < 3 ? " " : circleStatistics.Judges!.Where(x => x.Rate == 3).FirstOrDefault()!.Judge!.Name!;
            string juge4Name = circleStatistics.Judges!.Count < 4 ? " " : circleStatistics.Judges!.Where(x => x.Rate == 4).FirstOrDefault()!.Judge!.Name!;
            label_Juge1.Text = $"رئيس الدائرة -  {juge1Name}";
            label_Juge2.Text = $"عضو يمين الدائرة -  {juge2Name}";
            label_Juge3.Text = $"عضو يسار الدائرة -  {juge3Name}";
            label_Juge4.Text = circleStatistics.Judges!.Count < 4 ? " " : $"عضو يسار اليسار الدائرة -  {juge4Name}";
            BindingList<StatistaicsDto> statisticsList = new BindingList<StatistaicsDto>(circleStatistics.StaticsForYear!);
            dataGridView_StatisticInformation.DataSource = statisticsList;

            BindingList<JudgesDeccisionDto> judgei1 = new BindingList<JudgesDeccisionDto>(circleStatistics.JudgeDecision1!);
            dataGridView_Juge1.DataSource = judgei1;

            BindingList<JudgesDeccisionDto> judgei2 = new BindingList<JudgesDeccisionDto>(circleStatistics.JudgeDecision2!);
            dataGridView_Juge2.DataSource = judgei2;

            BindingList<JudgesDeccisionDto> judgei3 = new BindingList<JudgesDeccisionDto>(circleStatistics.JudgeDecision2!);
            dataGridView_Juge3.DataSource = judgei3;

            BindingList<JudgesDeccisionDto> judgei4 = new BindingList<JudgesDeccisionDto>(circleStatistics.JudgeDecision4!);
            dataGridView_Juge4.DataSource = judgei4;
            dataGridView_Juge4.Visible = circleStatistics.Judges!.Count > 3 ? true : false;

            EditColoumnsWidth(dataGridView_StatisticInformation);
            dataGridView_StatisticInformation.Columns[0].Visible = false;
            EditColoumnsWidthForJudje(dataGridView_Juge1);
            EditColoumnsWidthForJudje(dataGridView_Juge2);
            EditColoumnsWidthForJudje(dataGridView_Juge3);
            EditColoumnsWidthForJudje(dataGridView_Juge4);


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
            int colwidth = totalWidth / 42;
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {

                col.Width = colwidth;

            }
            dataGridView.Columns[1].Width = colwidth * 3;
            dataGridView.Invalidate();
        }
        void EditColoumnsWidthForJudje(DataGridView dataGridView)
        {
            int totalWidth = this.Width / 2;
            int colwidth = totalWidth / 31;
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {

                col.Width = colwidth;

            }
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].Width = colwidth * 3;
            dataGridView.Invalidate();
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // تخصيص رسم رؤوس الأعمدة فقط
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true); // رسم الخلفية
                DataGridView dataGridView = (DataGridView)sender;
                string headerText = dataGridView.Columns[e.ColumnIndex].HeaderText;

                using (Brush brush = new SolidBrush(dataGridView.ColumnHeadersDefaultCellStyle.ForeColor))
                {
                    SizeF textSize = e.Graphics!.MeasureString(headerText, dataGridView.ColumnHeadersDefaultCellStyle.Font);

                    // تدوير النص
                    e.Graphics.TranslateTransform(
                        e.CellBounds.Left + (e.CellBounds.Width / 2),
                        e.CellBounds.Top + e.CellBounds.Height
                    );
                    e.Graphics.RotateTransform(-90);

                    // رسم النص في المنتصف
                    e.Graphics.DrawString(
                        headerText,
                        dataGridView.ColumnHeadersDefaultCellStyle.Font,
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
            grid.Rows[rowIndex].Cells[1].Style.BackColor = Color.YellowGreen;
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
        private void UpdateTotalRow()
        {
            if (circleStatistics.StaticsForYear == null || circleStatistics.StaticsForYear.Count == 0)
                return;

            var totalRow = circleStatistics.StaticsForYear.Last();

            var properties = typeof(StatistaicsDto)
                .GetProperties()
                .Where(p =>
                    p.PropertyType == typeof(int) &&
                    p.CanWrite &&
                    !p.GetGetMethod().IsVirtual &&
                    p.Name != "Year" // ✅ استثناء العمود الثاني (Year)
                )
                .ToList();

            foreach (var prop in properties)
            {
                int sum = circleStatistics.StaticsForYear
                    .Take(circleStatistics.StaticsForYear.Count - 1) // استثناء صف الإجمالي
                    .Sum(x => (int)(prop.GetValue(x) ?? 0));

                prop.SetValue(totalRow, sum);
            }

            dataGridView_StatisticInformation.Refresh(); // تحديث الواجهة
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            if (dataGridView.Name == "dataGridView_StatisticInformation")
            {
                if (e.RowIndex == circleStatistics.StaticsForYear.Count - 1) // صف الإجمالي
                {
                    e.Cancel = true;
                    return;
                }
            }
            //ResetGridColors(dataGridView);

            //int colIndex = e.ColumnIndex;
            //int rowIndex = e.RowIndex;

            //HighlightRowAndColumn(dataGridView, rowIndex, colIndex);

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView dataGridView = sender as DataGridView;

            //ResetGridColors(dataGridView);
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

            DataGridView dataGridView = sender as DataGridView;
            string columnName = dataGridView.Columns[e.ColumnIndex].HeaderText;

            if (columnName == "جملة المقدم" || columnName == "جملة الاحكام القطعية" || columnName == "جملة الاثبات" || columnName == "جملة الوقف" || columnName == "جملة المحكوم فيه" || columnName == "جملة المؤجل" || columnName == "اجمالي الاحكام القطعية" || columnName == "المجموع")
            {
                // تغيير لون العمود "جملة المحكوم فيه" إلى لون معين
                e.CellStyle.BackColor = Color.FromArgb(32, 178, 170);
                dataGridView.Columns[e.ColumnIndex].HeaderCell.Style.BackColor = Color.FromArgb(32, 178, 170);
            }

            if (dataGridView.Rows[e.RowIndex].DataBoundItem is StatistaicsDto dto && dto.IsTotalRow == 1)
            {
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(218, 165, 32);
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold);
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

        private async void comboBox_CircleDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GetStatistic();
        }

        private void dataGridView_StatisticInformation_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // تجاهل التعديل في صف الإجمالي
            if (e.RowIndex >= 0 && e.RowIndex < circleStatistics!.StaticsForYear!.Count - 1)
            {
                UpdateTotalRow();
            }
        }

        private void dataGridView_StatisticInformation_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView_StatisticInformation.IsCurrentCellDirty)
            {
                dataGridView_StatisticInformation.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView_StatisticInformation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
