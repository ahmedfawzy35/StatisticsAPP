using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Models.CourtsModels;
using StatisticsAPP.Servicies.StatisticsCervicies.DTOS;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StatisticsAPP.Forms.StatisticsForms
{
    public partial class StatisticsAddConfigurationForm : Form
    {
        public StatisticsFormConfig? FormConfig { get; private set; }
        List<SuperCourt> usersuperCourts;
        List<SupCourt> supCourts;
        List<Circle> userCircles;
        private Dictionary<string, int> months = new Dictionary<string, int>
    {
        { "يناير", 1 }, { "فبراير", 2 }, { "مارس", 3 }, { "أبريل", 4 },
        { "مايو", 5 }, { "يونيو", 6 }, { "يوليو", 7 }, { "أغسطس", 8 },
        { "سبتمبر", 9 }, { "أكتوبر", 10 }, { "نوفمبر", 11 }, { "ديسمبر", 12 }
    };
        public StatisticsAddConfigurationForm()
        {
            InitializeComponent();
            usersuperCourts = LocalUser.userSuperCourt;
            supCourts = LocalUser.userSupCourt;
            userCircles = LocalUser.userCircles;
        }
        private void GetSupCourts()
        {
            try
            {
                if (comboBox_SuperCourt.SelectedItem == null)
                {
                    comboBox_SupCourt.DataSource = null;
                    return;
                }
                SuperCourt selectedSuperCourt = (SuperCourt)comboBox_SuperCourt.SelectedItem;
                if (selectedSuperCourt == null)
                {
                    comboBox_SupCourt.DataSource = null;
                    return;
                }
                int selectedSuperCourtId = selectedSuperCourt.Id;
                if (supCourts.Where(s => s.SuperCourtId == selectedSuperCourtId).ToList().Count <= 0)
                {
                    comboBox_SupCourt.DataSource = null;
                    return;
                }
                comboBox_SupCourt.DataSource = supCourts.Where(s => s.SuperCourtId == selectedSuperCourtId).ToList();
                comboBox_SupCourt.DisplayMember = "Name";
                comboBox_SupCourt.ValueMember = "Id";
            }
            catch (Exception)
            {

                comboBox_SupCourt.DataSource = null;
                return;
            }

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (comboBox_CircleCategory.SelectedItem == null || comboBox_CircleMasterType.SelectedItem == null
                || comboBox_SupCourt.SelectedItem == null || comboBox_SuperCourt.SelectedItem == null)
            {
                return;
            }
            FormConfig = new StatisticsFormConfig()
            {

                CircleCtogryId = ((CircleCategory)comboBox_CircleCategory.SelectedItem).Id,
                CircleMasterTypeId = ((CircleMasterType)comboBox_CircleMasterType.SelectedItem).Id,
                Month = comboBox_Month.SelectedIndex + 1,
                SupCourtId = ((SupCourt)comboBox_SupCourt.SelectedItem).Id,
                SuperCourtId = ((SuperCourt)comboBox_SuperCourt.SelectedItem).Id,
                Year = Convert.ToInt32(comboBox_Year.SelectedItem),
                SuperCourtName = ((SuperCourt)comboBox_SuperCourt.SelectedItem).Name,
                SupCourtName = ((SupCourt)comboBox_SupCourt.SelectedItem).Name,
                CircleCtogryName= ((CircleCategory)comboBox_CircleCategory.SelectedItem).Name,
                CircleMasterTypeName = ((CircleMasterType)comboBox_CircleMasterType.SelectedItem).Name



            };

            this.Close();

        }

        private void StatisticsAddConfigurationForm_Load(object sender, EventArgs e)
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

            if (usersuperCourts.Count <= 0 || supCourts.Count <= 0)
            {
                MessageBox.Show("Not authorized");
                return;
            }

            comboBox_SuperCourt.DataSource = usersuperCourts;
            comboBox_SuperCourt.DisplayMember = "Name";
            comboBox_SuperCourt.ValueMember = "Id";
            GetSupCourts();
            comboBox_CircleCategory.DataSource = MyContext.context.CircleCategories.ToList();
            comboBox_CircleCategory.DisplayMember = "Name";
            comboBox_CircleCategory.ValueMember = "Id";

            comboBox_CircleMasterType.DataSource = MyContext.context.CircleMasterTypes.ToList();
            comboBox_CircleMasterType.DisplayMember = "Name";
            comboBox_CircleMasterType.ValueMember = "Id";


        }
    }
}
