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

namespace StatisticsAPP.Forms.CourtsForms
{
    public partial class AddSuperCourtForm : Form
    {
        public bool IsEdit = false;
        public SuperCourt? SuperCourtToEdit = null;
        public AddSuperCourtForm()
        {
            InitializeComponent();
        }

        #region Methods
        void Loading()
        {
            pictureBox1.Visible = true;
        }
        void UnLoading()
        {
            pictureBox1.Visible = false;
        }
        private List<string> ValidationAdd()
        {
            List<string> eroors = new List<string>();

            if (string.IsNullOrEmpty(text_Name.Text))
            {
                eroors.Add("اسم المحكمة فارغ");
            }
            var supercourt =  MyContext.UnitOfWork.SuperCourt.Find(x => x.Name == text_Name.Text);
            if (supercourt != null)
            {
                eroors.Add($"اسم المحكمة ( {supercourt.Name}) موجود مسبقا مسجل برقم ({supercourt.Id}) ");

            }
            return eroors;
        }
        private async Task<List<string>> ValidationEdit()
        {
            List<string> eroors = new List<string>();

            if (string.IsNullOrEmpty(text_Name.Text))
            {
                eroors.Add("اسم المحكمة فارغ");

            }
            else
            {
                if (text_Name.Text != SuperCourtToEdit!.Name)
                {
                    var supercourt = await MyContext.UnitOfWork.SuperCourt.FindAsync(x => x.Name == text_Name.Text);
                    if (supercourt != null)
                    {
                        if (supercourt.Id != SuperCourtToEdit!.Id)
                        {
                            eroors.Add($"اسم المحكمة ( {supercourt.Name}) موجود مسبقا مسجل برقم ({supercourt.Id}) ");

                        }

                    }
                }
            }


            return eroors;
        }

        private async Task Add()
        {
            
            if (ValidationAdd().Count > 0)
            {
                return;
            }

            SuperCourt supercourt = new SuperCourt { Name = text_Name.Text , UserId = LocalUser.localUserId , CreatedAt = DateTime.Now };
            await MyContext.UnitOfWork.SuperCourt.AddAsync(supercourt);
            MyContext.UnitOfWork.Complete();

            MessageBox.Show("تم الاضافة");
            CleanText();
        }
        private void Edit()
        {
            if (ValidationEdit().Result.Count > 0)
            {
                return;
            }

            SuperCourtToEdit!.Name = text_Name.Text;
            MyContext.UnitOfWork.SuperCourt.Update(SuperCourtToEdit!);
            MyContext.UnitOfWork.Complete();
            this.Close();
        }
        void CleanText()
        {
            text_Name.Text = string.Empty;
        }
        #endregion

        #region Events

        #endregion

        private async void btn_Save_Click(object sender, EventArgs e)
        {
            Loading();
            if (IsEdit)
            {
                if (SuperCourtToEdit == null)
                {
                   
                    MessageBox.Show("لم يتم العثور على المحكمة للتعديل");
                    return;
                }
                Edit();
            }else
            {
               await Add();
            }
           UnLoading();

        }
    }
}
