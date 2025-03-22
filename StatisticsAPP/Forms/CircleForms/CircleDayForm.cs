using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StatisticsAPP.Data;
using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Models.CourtsModels;
using StatisticsAPP.Servicies.Repositories.CircleRepos;
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
        string[] includs = new string[] { "Circle", "CircleType" };
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
                    FillDataGrid(new List<CircleDayDTO>());
                    return;
                }
                Circle selectedCircle = (Circle)comboBox_Circle.SelectedItem;
                if (selectedCircle == null)
                {
                    FillDataGrid(new List<CircleDayDTO>());
                    return;
                }
                List<CircleDay> datat = MyContext.context.CircleDays.Include(x => x.CircleType).ThenInclude(x => x.CircleMasterType).Include(x => x.Circle).ThenInclude(x => x.SupCourt).Where(x => x.CircleId == selectedCircle.Id).ToList();
                FillDataGrid(MyMap.MapToCircleDayDTO(datat));
                // FillDataGrid(MyMap.MapToCircleDayDTO(MyContext.UnitOfWork.CircleDays.FindAll(x => x.CircleId == selectedCircle.Id , includs).ToList()));
            }
            catch (Exception)
            {
                FillDataGrid(new List<CircleDayDTO>());
                return;
            }
        }
        private void FillDataGrid(List<CircleDayDTO> data)
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
                if (selectedCircle == null)
                {
                    MessageBox.Show("قم باختيار دائرة اولا");
                    return;
                }
                CircleType selectedCircleType = (CircleType)comboBox_Circle.SelectedItem;
                if (selectedCircleType == null)
                {
                    MessageBox.Show("قم باختيار نوع الدائرة  اولا");
                    return;

                }
                CircleDay circleDay = new CircleDay();
                circleDay.CircleId = selectedCircle.Id;
                circleDay.CircleTypeId = selectedCircleType.Id;
                circleDay.Day = comboBox_Day.Text;
                circleDay.Name = text_Name.Text;
                MyContext.UnitOfWork.CircleDays.Add(circleDay);
                MessageBox.Show(MyContext.UnitOfWork.Save());

                GetCircleDays();
                //List<CircleDay> datat = MyContext.context.CircleDays.Include(x => x.CircleType).Include(x => x.Circle).ThenInclude(x => x.SupCourt).Where(x => x.CircleId == selectedCircle.Id).ToList();
                //FillDataGrid(MyMap.MapToCircleDayDTO(datat));
                //FillDataGrid(MyMap.MapToCircleDayDTO( MyContext.UnitOfWork.CircleDays.FindAll(x => x.CircleId == selectedCircle.Id, includs).ToList()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ" + ex.Message);
            }
        }

        private void SearcheJudje()
        {
            if (string.IsNullOrEmpty(text_SearchJudje.Text))
            {
                dataGridView_SearchJudjes.DataSource = null;
                return;
            }
            dataGridView_SearchJudjes.DataSource = MyContext.UnitOfWork.Judge.FindAll(x => x.Name!.Contains(text_SearchJudje.Text)).ToList();
            dataGridView_SearchJudjes.Columns[0].Width = 60;
            dataGridView_SearchJudjes.Columns[1].Visible = false;
            dataGridView_SearchJudjes.Columns[3].Visible = false;
            dataGridView_SearchJudjes.Columns[4].Visible = false;
            dataGridView_SearchJudjes.Columns[5].Visible = false;
            dataGridView_SearchJudjes.Columns[6].Visible = false;
            dataGridView_SearchJudjes.Columns[7].Visible = false;
            dataGridView_SearchJudjes.Columns[8].Visible = false;
        }
        private void GetCircleJujes()
        {
            try
            {
                if (comboBox_Circle.SelectedItem == null)
                {
                    dataGridView_CircleJudjes.DataSource = null;
                    return;
                }
                Circle selectedCircle = (Circle)comboBox_Circle.SelectedItem;
                if (selectedCircle == null)
                {
                    dataGridView_CircleJudjes.DataSource = null;
                    return;
                }
                var data = MyContext.context.CircleJudges.Include(x => x.Circle).Include(x => x.Judge).Where(x => x.IdCircle == selectedCircle.Id).ToList();
                var data2 = data.Select(x => new
                {
                    id = x.Id,
                    NameJudge = x.Judge!.Name,
                    datetart = x.DateStart,
                    DateEnd = x.DateEnd
                }).ToList();
                dataGridView_CircleJudjes.DataSource = data2;
            }
            catch (Exception)
            {
                dataGridView_CircleJudjes.DataSource = null;

                return;
            }
        }
        private void AddCircleJudge()
        {
            try
            {
                if (comboBox_Circle.SelectedItem == null || string.IsNullOrEmpty(text_GudjeId.Text) || string.IsNullOrEmpty(text_GudjeName.Text))
                {
                    MessageBox.Show("   برجاء اختيار قاضي اولا");
                    return;
                } 
                if ( string.IsNullOrEmpty(textBox_Rate.Text))
                {
                    MessageBox.Show("   برجاء ادخال ترتيب القاضي ");
                    return;
                }

                Circle selectedCircle = (Circle)comboBox_Circle.SelectedItem;
                if (selectedCircle == null)
                {
                    MessageBox.Show("قم باختيار دائرة اولا");
                    return;

                }

                CircleJudge circleJudje = new CircleJudge();
                circleJudje.IdJudge = int.Parse(text_GudjeId.Text);
                circleJudje.IdCircle = selectedCircle.Id;
                circleJudje.Rate = int.Parse(textBox_Rate.Text);
                circleJudje.DateStart = date_Start.Value.Date;
                circleJudje.DateEnd = date_End.Value.Date;
                circleJudje.UserId = LocalUser.localUserId;
                circleJudje.CreatedAt = DateTime.Now.Date;

                MyContext.UnitOfWork.CircleJudge.Add(circleJudje);
                MessageBox.Show(MyContext.UnitOfWork.Save());

                GetCircleJujes();

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
            date_Start.Value = new DateTime(DateTime.Now.Year - 1, 10, 1);
            date_End.Value = new DateTime(DateTime.Now.Year, 9, 30);
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
            GetCircleJujes();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            AddCircleDay();
        }

        private void dataGridView_CirleDays_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // التأكد أن المستخدم ضغط على عمود الزر وليس أي عمود آخر
            if (e.ColumnIndex >= 0 && dataGridView_CirleDays.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                // جلب رقم الصف المضغوط عليه
                int rowIndex = e.RowIndex;
                if (rowIndex >= 0)
                {
                    // الحصول على بيانات الصف
                    var row = dataGridView_CirleDays.Rows[rowIndex];

                    // جلب اسم العنصر من العمود الأول (حسب الحاجة)
                    string itemID = row.Cells[1].Value?.ToString() ?? "العنصر";
                    string itemName = row.Cells[2].Value?.ToString() ?? "العنصر";

                    // 3️⃣ إظهار رسالة تأكيد
                    DialogResult result = MessageBox.Show($" - هل تريد حذف العنصر رقم ( {itemID} ) -  والمسجل بالاسم (  {itemName}  )؟",
                        "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                    if (result == DialogResult.Yes)
                    {
                        MyContext.UnitOfWork.CircleDays.Delete(int.Parse(itemID));
                        MessageBox.Show(MyContext.UnitOfWork.Save());
                        // dataGridView_CirleDays.Rows.RemoveAt(rowIndex);
                        // MessageBox.Show("تم الحذف بنجاح!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetCircleDays();
                    }
                }
            }
        }
        private void dataGridView_CircleJudjes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // التأكد أن المستخدم ضغط على عمود الزر وليس أي عمود آخر
            if (e.ColumnIndex >= 0 && dataGridView_CircleJudjes.Columns[e.ColumnIndex].Name == "btnDeleteCircleJudge")
            {
                // جلب رقم الصف المضغوط عليه
                int rowIndex = e.RowIndex;
                if (rowIndex >= 0)
                {
                    // الحصول على بيانات الصف
                    var row = dataGridView_CircleJudjes.Rows[rowIndex];

                    // جلب اسم العنصر من العمود الأول (حسب الحاجة)
                    string itemID = row.Cells[1].Value?.ToString() ?? "العنصر";
                    string JudjeName = row.Cells[2].Value?.ToString() ?? "العنصر";

                    // 3️⃣ إظهار رسالة تأكيد
                    DialogResult result = MessageBox.Show($" - هل تريد حذف العنصر رقم ( {itemID} ) -   والمسجل بالاسم  للقاضي  (  {JudjeName}  )؟",
                        "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                    if (result == DialogResult.Yes)
                    {
                        MyContext.UnitOfWork.CircleJudge.Delete(int.Parse(itemID));
                        MessageBox.Show(MyContext.UnitOfWork.Save());
                       
                        GetCircleJujes();
                    }
                }
            }
        }
        private void dataGridView_SearchJudjes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // التأكد أن المستخدم ضغط على عمود الزر وليس أي عمود آخر
            if (e.ColumnIndex >= 0 && dataGridView_SearchJudjes.Columns[e.ColumnIndex].Name == "btn_Select")
            {
                // جلب رقم الصف المضغوط عليه
                int rowIndex = e.RowIndex;
                if (rowIndex >= 0)
                {
                    // الحصول على بيانات الصف
                    var row = dataGridView_SearchJudjes.Rows[rowIndex];

                    // جلب اسم العنصر من العمود الأول (حسب الحاجة)
                    string itemID = row.Cells[1].Value?.ToString() ?? "العنصر";
                    string itemName = row.Cells[2].Value?.ToString() ?? "العنصر";





                    text_GudjeId.Text = itemID;
                    text_GudjeName.Text = itemName;
                    text_SearchJudje.Text = "";

                }
            }
        }
        private void text_SearchJudje_TextChanged(object sender, EventArgs e)
        {
            SearcheJudje();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddCircleJudge();
        }
        private void textBox_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion










    }
}
