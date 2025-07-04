using Microsoft.EntityFrameworkCore;
using StatisticsAPP.Models.StatisticsModels;
using StatisticsAPP.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatisticsAPP.Forms.StatisticsForms
{
    public partial class OpenStatisticsForm : Form
    {
        private Dictionary<string, int> months = new Dictionary<string, int>
    {
        { "يناير", 1 }, { "فبراير", 2 }, { "مارس", 3 }, { "أبريل", 4 },
        { "مايو", 5 }, { "يونيو", 6 }, { "يوليو", 7 }, { "أغسطس", 8 },
        { "سبتمبر", 9 }, { "أكتوبر", 10 }, { "نوفمبر", 11 }, { "ديسمبر", 12 }
    };
        public OpenStatisticsForm()
        {
            InitializeComponent();
        }

        private void OpenStatisticsForm_Load(object sender, EventArgs e)
        {
            comboBox_Year.Items.AddRange(new object[] { DateTime.Now.AddYears(-2).Year, DateTime.Now.AddYears(-1).Year, DateTime.Now.Year });
            comboBox_Year.SelectedItem = DateTime.Now.AddMonths(-1).Year;
            comboBox_Month.DataSource = new BindingSource(months, null);
            comboBox_Month.DisplayMember = "Key";
            comboBox_Month.ValueMember = "Value";

            int previousMonth = DateTime.Now.Month - 1;
            if (previousMonth == 0) // إذا كان الشهر الحالي يناير، فالسابق ديسمبر
                previousMonth = 12;

            // تعيين القيمة الافتراضية بناءً على الشهر السابق
            comboBox_Month.SelectedValue = previousMonth;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var lastcircleStatistics = MyContext.context.CircleStatistics
                .Where(x => x.Year == Convert.ToInt32(comboBox_Year.SelectedItem) && x.Month == Convert.ToInt32(comboBox_Month.SelectedValue))
                .ToList();
            if (lastcircleStatistics.Count > 0)
            {
                MessageBox.Show("تم فتح الاحصائيات لهذا الشهر من قبل");
                return;
            }
                List<CircleStatistics> circleStatistics = new List<CircleStatistics>();
            var circles = MyContext.context.Circles.Include(X=>X.CircleDays).ToList();
            foreach (var circle in circles)
            {
                foreach (var circleDay in circle.CircleDays)
                {
                    circleStatistics.Add(new CircleStatistics()
                    {
                        IdCircleDay = circleDay.Id,
                        IsNew = true,   
                        DayOfWork = circleDay.Day,
                        Year = Convert.ToInt32(comboBox_Year.SelectedItem),
                        Month = Convert.ToInt32(comboBox_Month.SelectedValue),
                        CircleDay = circleDay,
                        CreatedAt = DateTime.Now,
                        UserId = LocalUser.localUserId,
                        StartCaseYear = 2020,
                        EndCaseYear = 2025,
                        Employee = " ",
                        CountCaseYear =6 ,
                        

                    });
                }
            }

            MyContext.context.CircleStatistics.AddRange(circleStatistics);
            MyContext.context.SaveChanges();
            MessageBox.Show("تم فتح الاحصائيات بنجاح");
        }
    }
}
