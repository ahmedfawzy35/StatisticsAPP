using StatisticsAPP.Data;
using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Models.CourtsModels;
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

namespace StatisticsAPP.Forms.CircleForms
{
    public partial class CircleDayForm : Form
    {
        List<SuperCourt> usersuperCourts;
        List<SupCourt> supCourts;
        List<Circle> userCircles;
        bool isloding = true;
        public CircleDayForm()
        {
            InitializeComponent();
            usersuperCourts = LocalUser.userSuperCourt;
            supCourts = LocalUser.userSupCourt;
            userCircles = LocalUser.userCircles;

        }
        #region Methods
        private void GetCircls()
        {
            try
            {
                if (comboBoxSupCourt.SelectedItem == null)
                {
                    comboBox_Circle.DataSource = null;
                    return;
                }
                SupCourt selectedSupCourt = (SupCourt)comboBoxSupCourt.SelectedItem!;
                if (selectedSupCourt == null)
                {
                    comboBox_Circle.DataSource = null;
                    return;
                }
                int selectedSupCourtId = selectedSupCourt.Id;
                if (userCircles.Where(s => s.IdSupCourt == selectedSupCourtId).ToList().Count <= 0)
                {
                    comboBox_Circle.DataSource = null;
                    return;
                }
                List<Circle> circles = userCircles.Where(s => s.IdSupCourt == selectedSupCourtId).ToList();
                if (circles.Count <= 0)
                {
                    comboBox_Circle.DataSource = null;
                    return;
                }

                comboBox_Circle.DataSource = circles;
                comboBox_Circle.DisplayMember = "Name";
                comboBox_Circle.ValueMember = "Id";
            }
            catch (Exception)
            {

                throw;
            }



        }
        private void GetSupCourts()
        {
            try
            {
                if (comboBoxSuperCourt.SelectedItem == null)
                {
                    comboBoxSupCourt.DataSource = null;
                    return;
                }
                SuperCourt selectedSuperCourt = (SuperCourt)comboBoxSuperCourt.SelectedItem;
                if (selectedSuperCourt == null)
                {
                    comboBoxSupCourt.DataSource = null;
                    return;
                }
                int selectedSuperCourtId = selectedSuperCourt.Id;
                if (supCourts.Where(s => s.SuperCourtId == selectedSuperCourtId).ToList().Count <= 0)
                {
                    comboBoxSupCourt.DataSource = null;
                    return;
                }
                comboBoxSupCourt.DataSource = supCourts.Where(s => s.SuperCourtId == selectedSuperCourtId).ToList();
                comboBoxSupCourt.DisplayMember = "Name";
                comboBoxSupCourt.ValueMember = "Id";
            }
            catch (Exception)
            {

                comboBoxSupCourt.DataSource = null;
                return;
            }

        }

        private void GetCircleType()
        {
            try
            {
                if (comboBoxSupCourt.SelectedItem == null)
                {
                    comboBox_Type.DataSource = null;
                    return;
                }
                SupCourt selectedSupCourt = (SupCourt)comboBoxSupCourt.SelectedItem;
                if (selectedSupCourt == null)
                {
                    comboBox_Type.DataSource = null;
                    return;
                }

                comboBox_Type.DataSource = MyContext.UnitOfWork.CircleType.GetAll();
                comboBox_Type.DisplayMember = "Name";
                comboBox_Type.ValueMember = "Id";
            }
            catch (Exception)
            {

                comboBoxSupCourt.DataSource = null;
                return;
            }

        }
        private void GetCircleDays()
        {
            try
            {
                if (comboBox_Circle.SelectedItem == null)
                {
                    FillDataGrid(new List<CircleDay>());
                    return;
                }
                Circle selectedCircle = (Circle)comboBox_Circle.SelectedItem;
                if (selectedCircle == null)
                {
                    FillDataGrid(new List<CircleDay>());
                    return;
                }
                FillDataGrid(MyContext.UnitOfWork.CircleDays.FindAll(x => x.CircleId == selectedCircle.Id).ToList());
            }
            catch (Exception)
            {
                FillDataGrid(new List<CircleDay>());
                return;
            }
        }
        private void FillDataGrid(List<CircleDay> data)
        {
            dataGridView_CirleDays.DataSource = data;
        }
        private void AddCircleDay()
        {
            try
            {
                if (comboBoxSuperCourt.SelectedItem == null || comboBoxSupCourt.SelectedItem == null || comboBox_Circle.SelectedItem == null || comboBox_Type.SelectedItem == null || comboBox_Day.SelectedItem == null)
                {
                    MessageBox.Show("Please fill all fields");
                    return;
                }
                Circle selectedCircle = (Circle)comboBox_Circle.SelectedItem;
                CircleDay circleDay = new CircleDay();
                circleDay.CircleId = selectedCircle.Id;
                circleDay.CircleTypeId = ((CircleType)comboBox_Type.SelectedItem).Id;
                circleDay.Day = comboBox_Day.Text;
                circleDay.Name = text_Name.Text;
                MyContext.UnitOfWork.CircleDays.Add(circleDay);
                MessageBox.Show(MyContext.UnitOfWork.Save());
               
                DbContextFactory.RefreshContext();
                
                FillDataGrid(MyContext.UnitOfWork.CircleDays.FindAll(x => x.CircleId == selectedCircle.Id).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ" + ex.Message);
            }
        }

        #endregion

        #region Events
        private void CircleDayForm_Load(object sender, EventArgs e)
        {

            if (usersuperCourts.Count <= 0 || supCourts.Count <= 0)
            {
                MessageBox.Show("Not authorized");
                return;
            }

            comboBoxSuperCourt.DataSource = usersuperCourts;
            comboBoxSuperCourt.DisplayMember = "Name";
            comboBoxSuperCourt.ValueMember = "Id";
            GetSupCourts();

            comboBox_Day.DataSource = Enum.GetValues(typeof(MyStrings.ArabicDay));
        }
        private void comboBoxSuperCourt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isloding)
            {
                GetSupCourts();

            }
            else
            {
                isloding = false;
            }

        }
        #endregion



        private void comboBoxSupCourt_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCircls();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox_Circle_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCircleType();
            GetCircleDays();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            AddCircleDay();
        }
    }
}
