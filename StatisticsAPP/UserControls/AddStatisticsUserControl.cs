
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        #region properties
        public StatisticsFormConfig? Config { get; set; }
        public CircleDayStatistaicsDto? circleStatistics { get; set; }

        List<Circle> userCircles;
        private Dictionary<string, int> months = new Dictionary<string, int> { };

        readonly DataTable dt = new();
        private int hoveredRowIndex = -1;
        private int hoveredColumnIndex = -1;
        List<StatistaicsDto> StatisticsList;
        #endregion
        public AddStatisticsUserControl()
        {
            InitializeComponent();
            dataGridView_StatisticInformation.EditMode = DataGridViewEditMode.EditOnEnter;
            EnableDoubleBuffering(dataGridView_StatisticInformation);
            EnableDoubleBuffering(dataGridView_Juge1);
            EnableDoubleBuffering(dataGridView_Juge2);
            EnableDoubleBuffering(dataGridView_Juge3);
            EnableDoubleBuffering(dataGridView_Juge4);
            EnableDoubleBuffering(dataGridView_Ethbat);
            EnableDoubleBuffering(dataGridView_Mahgouz);
            EnableDoubleBuffering(dataGridView_MadAgal);
            EnableDoubleBuffering(dataGridView_Morafea);
            EnableDoubleBuffering(dataGridView_Baki);
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
        #region Methods
        #region GetData

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
        private void ShowLoading()
        {
            comboBox_Circles.Enabled = false;
            comboBox_CircleDays.Enabled = false;
        
            pictureBox_Loading.Visible = true;
        }
        private void HideLoading()
        {
            comboBox_Circles.Enabled = true;
            comboBox_CircleDays.Enabled = true;
            pictureBox_Loading.Visible = false;
        }
        private async Task GetStatistic()
        {
            ShowLoading();
            try
            {
                if (Config == null) { HideLoading(); return; }
                var circle = (Circle)comboBox_Circles.SelectedItem!;
                if (circle == null) { MessageBox.Show("CircleDay is null"); HideLoading(); return; }
                var circleday = comboBox_CircleDays.SelectedItem as CircleDay;
                if (circleday == null)
                {
                    MessageBox.Show("CircleDay is null");
                    HideLoading();
                    return;
                }
                StatisticsManager manager = new StatisticsManager(new Data.ApplicationDbContext());
                circleStatistics = await manager.GetStatistaicsDtoAsync(circleday.Id, circle.Id, Config.Month, Config.Year);
                if (circleStatistics == null)
                {
                    MessageBox.Show("لم يتم فتح الاحصائية بعد ");
                    HideLoading();
                    return;
                }
                string juge1Name = circleStatistics.Judges!.Count < 1 ? " " : circleStatistics.Judges!.Where(x => x.Rate == 1).FirstOrDefault()!.Judge!.Name!;
                string juge2Name = circleStatistics.Judges!.Count < 2 ? " " : circleStatistics.Judges!.Where(x => x.Rate == 2).FirstOrDefault()!.Judge!.Name!;
                string juge3Name = circleStatistics.Judges!.Count < 3 ? " " : circleStatistics.Judges!.Where(x => x.Rate == 3).FirstOrDefault()!.Judge!.Name!;
                string juge4Name = circleStatistics.Judges!.Count < 4 ? " " : circleStatistics.Judges!.Where(x => x.Rate == 4).FirstOrDefault()!.Judge!.Name!;
                label_Juge1.Text = $"رئيس الدائرة -  {juge1Name}";
                label_Juge2.Text = $"عضو يمين الدائرة -  {juge2Name}";
                label_Juge3.Text = $"عضو يسار الدائرة -  {juge3Name}";
                label_Juge4.Text = circleStatistics.Judges!.Count < 4 ? " " : $"عضو يسار اليسار الدائرة -  {juge4Name}";
                BindingList<StatistaicsDto> statisticsList = new BindingList<StatistaicsDto>(circleStatistics.StaticsForYear!);
                dataGridView_StatisticInformation.DataSource = statisticsList;
                SetStatisticInfoColumnsReadOnly();

                BindingList<JudgesDeccisionDto> judgei1 = new BindingList<JudgesDeccisionDto>(circleStatistics.JudgeDecision1!);
                dataGridView_Juge1.DataSource = judgei1;

                BindingList<JudgesDeccisionDto> judgei2 = new BindingList<JudgesDeccisionDto>(circleStatistics.JudgeDecision2!);
                dataGridView_Juge2.DataSource = judgei2;

                BindingList<JudgesDeccisionDto> judgei3 = new BindingList<JudgesDeccisionDto>(circleStatistics.JudgeDecision3!);
                dataGridView_Juge3.DataSource = judgei3;

                BindingList<JudgesDeccisionDto> judgei4 = new BindingList<JudgesDeccisionDto>(circleStatistics.JudgeDecision4!);
                dataGridView_Juge4.DataSource = judgei4;
                dataGridView_Juge4.Visible = circleStatistics.Judges!.Count > 3 ? true : false;

                BindingList<DelayCacesForMonthDto> Etbat = new BindingList<DelayCacesForMonthDto>(circleStatistics.DelayCacesForMonthEthbat!);
                dataGridView_Ethbat.DataSource = Etbat;

                BindingList<DelayCacesForMonthDto> Mahgouz = new BindingList<DelayCacesForMonthDto>(circleStatistics.DelayCacesForMonthMahgouzLelHokm!);
                dataGridView_Mahgouz.DataSource = Mahgouz;

                BindingList<DelayCacesForMonthDto> MadAgal = new BindingList<DelayCacesForMonthDto>(circleStatistics.DelayCacesForMonthMadAgal!);
                dataGridView_MadAgal.DataSource = MadAgal;

                BindingList<DelayCacesForMonthDto> Morafea = new BindingList<DelayCacesForMonthDto>(circleStatistics.DelayCacesForMonthEadaLelMorafea!);
                dataGridView_Morafea.DataSource = Morafea;

                BindingList<DelayCacesForMonthDto> Baki = new BindingList<DelayCacesForMonthDto>(circleStatistics.DelayCacesForMonthBaky!);
                dataGridView_Baki.DataSource = Baki;


                EditColoumnsWidthForDelayCaces();
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
            finally
            {
                HideLoading();
            }
        }
        private string GetArabicMonthName(int month)
        {
            return new DateTime(1, month, 1)
                .ToString("MMMM", new CultureInfo("ar-AE")); // أو "ar-EG" للغة المصرية
        }

        #endregion

        #region Design
        // تعديل جميع الدوال والمعاملات لتعمل مع DataGridView فقط
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
        }
        void EditColoumnsWidthForDelayCaces()
        {

            var firstMonth = circleStatistics!.Month;
            dataGridView_Ethbat.Columns[1].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month); // عمود التاريخ
            dataGridView_Ethbat.Columns[2].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month + 1); // عمود التاريخ
            dataGridView_Ethbat.Columns[3].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month + 2); // عمود التاريخ
                                                                                                                      // dataGridView_Ethbat.Invalidate();


            dataGridView_Mahgouz.Columns[1].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month); // عمود التاريخ
            dataGridView_Mahgouz.Columns[2].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month + 1); // عمود التاريخ
            dataGridView_Mahgouz.Columns[3].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month + 2); // عمود التاريخ
                                                                                                                       // dataGridView_Mahgouz.Invalidate();



            dataGridView_MadAgal.Columns[1].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month); // عمود التاريخ
            dataGridView_MadAgal.Columns[2].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month + 1); // عمود التاريخ
            dataGridView_MadAgal.Columns[3].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month + 2); // عمود التاريخ
                                                                                                                       // dataGridView_MadAgal.Invalidate();

            dataGridView_Morafea.Columns[1].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month); // عمود التاريخ
            dataGridView_Morafea.Columns[2].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month + 1); // عمود التاريخ
            dataGridView_Morafea.Columns[3].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month + 2); // عمود التاريخ
                                                                                                                       //  dataGridView_Morafea.Invalidate();

            dataGridView_Baki.Columns[1].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month); // عمود التاريخ
            dataGridView_Baki.Columns[2].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month + 1); // عمود التاريخ
            dataGridView_Baki.Columns[3].HeaderText = MyStrings.GetNextMonthArabicName(circleStatistics.Month + 2); // عمود التاريخ
                                                                                                                    // dataGridView_Baki.Invalidate();


        }
        #endregion

        #region Validation

        private void UpdateTotalRow_dataGridView_StatisticInformation()
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
            label__Ethbat.Text = totalRow.TotalEthbat.ToString();
            label_Mahgouz.Text = totalRow.MahguzLelHokm.ToString();
            label_MadAgal.Text = totalRow.MadAgal.ToString();
            label1_Morafea.Text = totalRow.EadaLelMorafea.ToString();
            label__Baki.Text = (totalRow.Okhrah + totalRow.MoeagalLelTkrir).ToString();
            totalRow.IsTotalRow = 1; // تعيين قيمة العمود الأول (IsTotalRow) إلى 1
            circleStatistics.StaticsForYear[circleStatistics.StaticsForYear.Count - 1] = totalRow;
            if (dataGridView_StatisticInformation.Rows.Count > 5)
                dataGridView_StatisticInformation.InvalidateRow(5);

            // إجبار DataGridView على تحديث صف الإجمالي فوراً
            var cm = dataGridView_StatisticInformation.BindingContext[dataGridView_StatisticInformation.DataSource] as CurrencyManager;
            cm?.Refresh();
        }

        private void UpdateTotalRow_dataGridView_Judge(List<JudgesDeccisionDto>? JudgeDecision, DataGridView dataGridView)
        {
            if (JudgeDecision == null || JudgeDecision.Count == 0)
                return;

            var totalRow = JudgeDecision.Last();

            var properties = typeof(JudgesDeccisionDto)
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
                int sum = JudgeDecision
                    .Take(JudgeDecision.Count - 1) // استثناء صف الإجمالي
                    .Sum(x => (int)(prop.GetValue(x) ?? 0));

                prop.SetValue(totalRow, sum);
            }

            dataGridView.Refresh(); // تحديث الواجهة
        }

        #endregion
        #endregion

        #region   Events
        #region Data GridView Events

        // منع التعديل في صف الإجمالي
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView == null || circleStatistics?.StaticsForYear == null)
                return;
            if (e.RowIndex == circleStatistics.StaticsForYear.Count - 1)
            {
                e.Cancel = true;
                return;
            }



        }

        // رسم رؤوس الأعمدة بشكل عمودي
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
        // تظليل الصف والعمود عند تمرير الفأرة
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
        // إعادة لون الصف والعمود عند مغادرة الفأرة
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView != null)
                ResetGridColors(dataGridView);
        }
        // التحقق من صحة الخلايا عند التحرير --  للأرقام فقط
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
        // تلوين اعمدة الاجماليات لجداول احكام القضاة
        private void dataGridViewJuges_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView == null) return;
            string columnName = dataGridView.Columns[e.ColumnIndex].HeaderText;
            if (columnName == "اجمالي الاحكام القطعية" || columnName == "المجموع")
            {
                e.CellStyle.BackColor = Color.FromArgb(32, 178, 170);
                dataGridView.Columns[e.ColumnIndex].HeaderCell.Style.BackColor = Color.FromArgb(32, 178, 170);
            }
            if (dataGridView.Rows[e.RowIndex].DataBoundItem is JudgesDeccisionDto dto && dto.IsTotalRow == 1)
            {
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(218, 165, 32);
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold);
            }
        }
        // تلوين اعمدة الاجماليات لجدول احكام الانتاج
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView == null) return;
            string columnName = dataGridView.Columns[e.ColumnIndex].HeaderText;
            if (columnName == "جملة المقدم" || columnName == "جملة الاحكام القطعية" || columnName == "جملة الاثبات" || columnName == "جملة الوقف" || columnName == "جملة المحكوم فيه" || columnName == "جملة المؤجل")
            {
                e.CellStyle.BackColor = Color.FromArgb(32, 178, 170);
                dataGridView.Columns[e.ColumnIndex].HeaderCell.Style.BackColor = Color.FromArgb(32, 178, 170);
            }
            if (dataGridView.Rows[e.RowIndex].DataBoundItem is StatistaicsDto dto && dto.IsTotalRow == 1)
            {
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(218, 165, 32);
                dataGridView.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(dataGridView.Font, FontStyle.Bold);
            }
            if (dataGridView_StatisticInformation.Columns[e.ColumnIndex].Name == "TotalMokadam")
            {
                var row = dataGridView_StatisticInformation.Rows[e.RowIndex];
                var totalMokadam = Convert.ToInt32(row.Cells["TotalMokadam"].Value);
                var totaMahkomFih = Convert.ToInt32(row.Cells["TotaMahkomFih"].Value);
                var totoalMoeagal = Convert.ToInt32(row.Cells["TotoalMoeagal"].Value);
                var Mashtob = Convert.ToInt32(row.Cells["Mashtob"].Value);
                if (totalMokadam != (totaMahkomFih + totoalMoeagal + Mashtob))
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(32, 178, 170);
                }
            }
        }
        // تحديث صف الإجمالي عند تغيير قيمة خلية في جدول الانتاج
        private void dataGridView_StatisticInformation_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // تجاهل التعديل في صف الإجمالي
            if (e.RowIndex >= 0 && e.RowIndex < circleStatistics!.StaticsForYear!.Count - 1)
            {
                UpdateTotalRow_dataGridView_StatisticInformation();
            }
        }
        // تحديث صف الإجمالي عند تغيير قيمة خلية في جدول أحكام القاضي الأول
        private void dataGridView_Judge_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView == null || circleStatistics?.StaticsForYear == null) return;
            if (e.RowIndex >= 0 && e.RowIndex < circleStatistics.StaticsForYear.Count - 1)
            {
                switch (dataGridView.Name)
                {
                    case "dataGridView_Juge1":
                        UpdateTotalRow_dataGridView_Judge(circleStatistics.JudgeDecision1, dataGridView);
                        break;
                    case "dataGridView_Juge2":
                        UpdateTotalRow_dataGridView_Judge(circleStatistics.JudgeDecision2, dataGridView);
                        break;
                    case "dataGridView_Juge3":
                        UpdateTotalRow_dataGridView_Judge(circleStatistics.JudgeDecision3, dataGridView);
                        break;
                    case "dataGridView_Juge4":
                        UpdateTotalRow_dataGridView_Judge(circleStatistics.JudgeDecision4, dataGridView);
                        break;
                    default:
                        break;
                }
                UpdateStatisticInfoAggregates(e.RowIndex);
                UpdateTotalRow_dataGridView_StatisticInformation();
            }
        }
        // تحديث قيمة الخلايا مباشرة بعد التعديل دون مغادرة الخلية
        private void dataGridView_StatisticInformation_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // تم تعطيل الكود حتى لا ينتقل المؤشر تلقائياً بعد أول إدخال
            //if (dataGridView_StatisticInformation.IsCurrentCellDirty)
            //{
            //    dataGridView_StatisticInformation.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
        }
        // منع إدخال أحرف غير رقمية في الخلايا -- لايعمل 
        private void dataGridView_StatisticInformation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        #endregion



        void HighlightRowAndColumn(DataGridView grid, int rowIndex, int colIndex)
        {
            grid.Columns[colIndex].HeaderCell.Style.BackColor = Color.YellowGreen;
            grid.Rows[rowIndex].Cells[1].Style.BackColor = Color.YellowGreen;
            grid.Columns[colIndex].HeaderCell.Style.BackColor = Color.LightGreen;

        }
        private void ResetGridColors(DataGridView grid)
        {
            int lastRowIndex = grid.Rows.Count - 1;
            for (int i = 0; i < lastRowIndex; i++)
            {
                foreach (DataGridViewCell cell in grid.Rows[i].Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }
            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.HeaderCell.Style.BackColor = Color.White;
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
            SetStatisticInfoColumnsReadOnly();
        }

        #region ComboBox Events
        private void comboBox_Circles_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCirclDays();
        }

        private async void comboBox_CircleDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            await GetStatistic();
        }
        private void comboBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
        }
        #endregion

        #endregion
        // يجب وضع هذه الدالة في بداية الكلاس أو في قسم Methods
        /// <summary>
        /// Enables double buffering for a DataGridView to reduce flicker and improve performance.
        /// </summary>
        private static void EnableDoubleBuffering(DataGridView dgv)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            var property = typeof(DataGridView).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            property?.SetValue(dgv, true, null);
        }

        private void SetStatisticInfoColumnsReadOnly()
        {
            // الأعمدة التي يجب أن تكون للعرض فقط
            string[] readOnlyColumns = new string[] {
                "Shakly", "Mawdoey", "Solh", "Farey", "Khapir", "BackToKhapir", "Tahkik", "Estgwap", "HelfYamin", "WakfGazaey", "WakfTaeliky", "WakfEtfaky", "EnktaeSirAlKhsoma", "EadaLelMorafea", "MadAgal"
            };
            foreach (var colName in readOnlyColumns)
            {
                if (dataGridView_StatisticInformation.Columns.Contains(colName))
                    dataGridView_StatisticInformation.Columns[colName].ReadOnly = true;
            }
        }
        // تحديث الأعمدة المجمعّة في جدول الإحصائيات عند تغيير أي قيمة في جداول القضاة
        private void UpdateStatisticInfoAggregates(int rowIndex)
        {
            // إذا كان صف الإجمالي، تجاهل
            if (rowIndex < 0 || rowIndex >= dataGridView_StatisticInformation.Rows.Count - 1)
                return;

            // جمع الأعمدة الخاصة بـ Shakly
            int shakly = 0;
            string[] shaklyCols = { "AdmKbol", "AdmEjhtsas", "SkotAlHakFiRAFEAlDaewa", "SkotAlKhsomaWEnkdaeha", "TarkAlKhsoma", "EnedamAlKhsoma", "KanLamTkon" };
            foreach (var col in shaklyCols)
            {
                shakly += GetJudgeSumForColumn(col, rowIndex);
            }
            SetStatisticInfoCell(rowIndex, "Shakly", shakly);

            // جمع الأعمدة الخاصة بـ Mawdoey
            int mawdoey = 0;
            string[] mawdoeyCols = { "Kbol", "Rafd", "RafdBeHalatha", "AdamGwazLeSabekatAlFaslFiha", "EnkdaeAlhakBeModiAlModa" };
            foreach (var col in mawdoeyCols)
            {
                mawdoey += GetJudgeSumForColumn(col, rowIndex);
            }
            SetStatisticInfoCell(rowIndex, "Mawdoey", mawdoey);

            // الأعمدة التي تنسخ مباشرة
            string[] directCols = { "Solh", "Farey", "NadbKhabir", "BackTOKhabir", "Tahkik", "Estgwab", "HelfYamin", "WakfGazaey", "WakfTaeliky", "WakfEtifaky", "EnktaeSirAlKhsoma", "EadaLelMorafea", "MadAgal" };
            string[] statCols = { "Solh", "Farey", "Khapir", "BackToKhapir", "Tahkik", "Estgwap", "HelfYamin", "WakfGazaey", "WakfTaeliky", "WakfEtfaky", "EnktaeSirAlKhsoma", "EadaLelMorafea", "MadAgal" };
            for (int i = 0; i < directCols.Length; i++)
            {
                int sum = GetJudgeSumForColumn(directCols[i], rowIndex);
                SetStatisticInfoCell(rowIndex, statCols[i], sum);
            }
        }

        // جمع قيمة عمود معين من جداول القضاة الأربعة لنفس الصف
        private int GetJudgeSumForColumn(string colName, int rowIndex)
        {
            int sum = 0;
            DataGridView[] judgeGrids = { dataGridView_Juge1, dataGridView_Juge2, dataGridView_Juge3, dataGridView_Juge4 };
            foreach (var grid in judgeGrids)
            {
                if (grid.Visible && grid.Columns.Contains(colName) && rowIndex < grid.Rows.Count)
                {
                    var val = grid.Rows[rowIndex].Cells[colName].Value;
                    if (val != null && int.TryParse(val.ToString(), out int v))
                        sum += v;
                }
            }
            return sum;
        }

        // تعيين قيمة في جدول الإحصائيات
        private void SetStatisticInfoCell(int rowIndex, string colName, int value)
        {
            if (dataGridView_StatisticInformation.Columns.Contains(colName) && rowIndex < dataGridView_StatisticInformation.Rows.Count)
            {
                dataGridView_StatisticInformation.Rows[rowIndex].Cells[colName].Value = value;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (circleStatistics == null || circleStatistics.StaticsForYear == null || circleStatistics.StaticsForYear.Count == 0)
                return;

            int rowCount = circleStatistics.StaticsForYear.Count;
            // لا تشمل صف الإجمالي
            for (int i = 0; i < rowCount - 1; i++)
            {
                var row = circleStatistics.StaticsForYear[i];
                // توزيع لكل جدول حسب المطلوب
                if (dataGridView_Ethbat.Rows.Count > i && dataGridView_Ethbat.Columns.Count > 1)
                    dataGridView_Ethbat.Rows[i].Cells[1].Value = row.TotalEthbat;
                if (dataGridView_Mahgouz.Rows.Count > i && dataGridView_Mahgouz.Columns.Count > 1)
                    dataGridView_Mahgouz.Rows[i].Cells[1].Value = row.MahguzLelHokm;
                if (dataGridView_MadAgal.Rows.Count > i && dataGridView_MadAgal.Columns.Count > 1)
                    dataGridView_MadAgal.Rows[i].Cells[1].Value = row.MadAgal;
                if (dataGridView_Morafea.Rows.Count > i && dataGridView_Morafea.Columns.Count > 1)
                    dataGridView_Morafea.Rows[i].Cells[1].Value = row.EadaLelMorafea;
                if (dataGridView_Baki.Rows.Count > i && dataGridView_Baki.Columns.Count > 1)
                    dataGridView_Baki.Rows[i].Cells[1].Value = row.MoeagalLelTkrir + row.Okhrah;
            }
        }

        // التحقق من تطابق الاجمالي في جداول المؤجلات مع جدول الإحصائيات وتلوين الخلية
        private void DelayCasesGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid == null || e.RowIndex < 0)
                return;

            // عمود الاجمالي اسمه Total وهو العمود الخامس (Index=4)
            string totalColName = "Total";
            string statColName = string.Empty;
            if (grid.Name == "dataGridView_Ethbat") statColName = "TotalEthbat";
            else if (grid.Name == "dataGridView_Mahgouz") statColName = "MahguzLelHokm";
            else if (grid.Name == "dataGridView_MadAgal") statColName = "MadAgal";
            else if (grid.Name == "dataGridView_Morafea") statColName = "EadaLelMorafea";
            else if (grid.Name == "dataGridView_Baki") statColName = "MoeagalLelTkrir";
            else return;

            // اجلب قيمة الاجمالي من جدول المؤجلات
            var cell = grid.Rows[e.RowIndex].Cells[totalColName];
            int delayValue = 0;
            int.TryParse(cell.Value?.ToString(), out delayValue);

            // اجلب قيمة الاجمالي المقابل من جدول الإحصائيات
            int statValue = 0;
            if (dataGridView_StatisticInformation.Rows.Count > e.RowIndex && dataGridView_StatisticInformation.Columns.Contains(statColName))
            {
                var statCell = dataGridView_StatisticInformation.Rows[e.RowIndex].Cells[statColName];
                int.TryParse(statCell.Value?.ToString(), out statValue);
            }

            // المقارنة والتلوين
            if (delayValue != statValue)
                cell.Style.BackColor = Color.Red;
            else
                cell.Style.BackColor = Color.White;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
          await  MyCervicies.statisticsManager!.SaveStatistic(circleStatistics!);
           // MessageBox.Show("تم حفظ الاحصائية بنجاح", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
