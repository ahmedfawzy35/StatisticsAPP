using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StatisticsAPP.Servicies.StatisticsCervicies.DTOS;
using StatisticsAPP.Utility;
using Microsoft.EntityFrameworkCore;
using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Models.StatisticsModels;

namespace StatisticsAPP.Forms.StatisticsForms
{
    public partial class StatisticsAddUserControl : UserControl
    {
        public StatisticsFormConfig? Config { get; set; }
        public CircleStatistics? circleStatistics { get; set; }
        bool isEditCircleStatistics = false;
        bool isEditCircleStatisticsForYear = false;
        List<Circle> userCircles;

        public StatisticsAddUserControl()
        {
            InitializeComponent();
            userCircles = LocalUser.userCircles;

        }
        #region Methods

        private void GetCircles()
        {
            var circles = userCircles.Where(x=>x.IdSupCourt == Config!.SupCourtId).ToList();
            var circleDaysForType = MyContext.context.CircleDays.Include(x => x.CircleType)
                                                                .ThenInclude(x => x.CircleMasterType)
                                                                .Include(x=>x.Circle)
                                                                .Where(x => x.CircleType!.IdCircleMasterType == Config.CircleMasterTypeId).ToList();


            //var viewCircls = circleDaysForType.Select(x=> new Circle
            //{
            //    Id = x.CircleId,
            //    Name = x.Circle!.Name,
            //}).ToList();
             var viewCircls = circleDaysForType.Select(x=> x.Circle).ToList();
            var UniqueCircles = viewCircls.GroupBy(x => x.Id).Select(x => x.First()).ToList();

            comboBox_Circles.DataSource = UniqueCircles;
            comboBox_Circles.DisplayMember = "Name";
            comboBox_Circles.ValueMember = "Id";
        }
        private void GetCirclDays()
        {
            var circle = (Circle)comboBox_Circles.SelectedItem;
            if (circle == null) { MessageBox.Show("CircleDay is null"); return; }

            var circledays = MyContext.context.CircleDays.Include(x => x.CircleType).ThenInclude(x => x.CircleMasterType).Where(x => x.CircleId == circle.Id).ToList();
            comboBox_CircleDays.DataSource = circledays;
            comboBox_CircleDays.DisplayMember = "Name";
            comboBox_CircleDays.ValueMember = "Id";
        }
        private void GetStatistic()
        {
            if (Config == null) {; return; }
            var circleday = (CircleDay)comboBox_CircleDays.SelectedItem;
            if (circleday == null) { MessageBox.Show("CircleDay is null"); return; }


            circleStatistics = MyContext.context.CircleStatistics.Include(x => x.StatisticsDecisions).ThenInclude(x => x.CaseYear)
                                                                  .Include(x => x.StatisticsInterCases).ThenInclude(x => x.CaseYear)
                                                                  .Include(x => x.StatisticsDelayCases).ThenInclude(x => x.CaseYear)
                                                                  .Include(x => x.CircleDay).ThenInclude(x => x.DelayCacesForMonths)
                                                                  .Where(x => x.IdCircleDay == circleday.Id && x.Year == Config.Year && x.Month == Config.Month).FirstOrDefault();

            isEditCircleStatistics = circleStatistics != null;
        }
        private void SetValues()
        {

            if (circleStatistics == null) { return; }

            var caseYear = (CaseYear)comboBox_CaseYear.SelectedValue;

            if (caseYear == null)
            {
                return;
            }

            var yearStatisticsDecisions = circleStatistics.StatisticsDecisions!.Where(x => x.CaseYear!.Year == caseYear.Year).FirstOrDefault();
            var StatisticsInterCases = circleStatistics.StatisticsInterCases!.Where(x => x.CaseYear!.Year == caseYear.Year).FirstOrDefault();
            var StatisticsDelayCases = circleStatistics.StatisticsDelayCases!.Where(x => x.CaseYear!.Year == caseYear.Year).FirstOrDefault();


        }
        #endregion


        #region Events
        private void StatisticsAddUserControl_Load(object sender, EventArgs e)
        {
            GetCircles();
            comboBox_CaseYear.DataSource = MyContext.context.CaseYears.ToList();
            comboBox_CaseYear.DisplayMember = "Name";
            comboBox_CaseYear.ValueMember = "Id";
        }

        private void comboBox_Circles_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCirclDays();
        }

        private void comboBox_CircleDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetStatistic();
        }

        private void comboBox_CaseYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValues();
        }
        #endregion


    }
}
