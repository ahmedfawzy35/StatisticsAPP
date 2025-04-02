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
using Microsoft.IdentityModel.Tokens;

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
        #region get Methods
        private void GetCircles()
        {
           var circlesQuery = userCircles.Where(x => x.IdSupCourt == Config!.SupCourtId    &&
                                                x.IdCircleCategory == Config.CircleCtogryId  );

           var circlesQuery2 = userCircles.Where(x => x.SupCourt!.SuperCourtId == Config!.SuperCourtId    &&
                                                 x.IdCircleCategory == Config.CircleCtogryId  );

            var circls = Config!.SupCourtId == 0 ? circlesQuery2.ToList() : circlesQuery.ToList();

            var circleToView = circls.Where(x => (x.CircleDays.Where(cd =>cd.CircleType.IdCircleMasterType == Config.CircleMasterTypeId).ToList().Count > 0)).ToList();



          

            comboBox_Circles.DataSource = circleToView;
            comboBox_Circles.DisplayMember = "Name";
            comboBox_Circles.ValueMember = "Id";
        }
        private void GetCirclDays()
        {
            var circle = (Circle)comboBox_Circles.SelectedItem!;
            if (circle == null) { MessageBox.Show("CircleDay is null"); return; }
            var _circle = userCircles.Where(x=>x.Id == circle.Id).First();

            var circledays =_circle.CircleDays!.Where(cd => cd.CircleType!.IdCircleMasterType == Config!.CircleMasterTypeId).ToList();

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
        #endregion
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

        #region Calc Methods
        private void CalcMotadawal()
        {
            var textboxes = groupBox_Motdawal.Controls.OfType<TextBox>().ToList();


            int motadawal = 0;
            foreach (var textbox in textboxes)
            {
                if (!string.IsNullOrEmpty(textbox.Text))
                {
                    motadawal += int.Parse(textbox.Text);
                }
            }
            motadawal += string.IsNullOrEmpty(Text_Taksir_Count.Text) ? 0 : int.Parse(Text_Taksir_Count.Text);
            motadawal -= string.IsNullOrEmpty(text__Ehalah_From.Text) ? 0 : int.Parse(text__Ehalah_From.Text);
            motadawal += string.IsNullOrEmpty(text__Ehalah_To.Text) ? 0 : int.Parse(text__Ehalah_To.Text);
            text_Mokadam_Motadawal.Text = motadawal.ToString();
        }

        private void CalcMokadam()
        {
            int motadawal = string.IsNullOrEmpty(text_Mokadam_Motadawal.Text) ? 0 : int.Parse(text_Mokadam_Motadawal.Text);
            int newCaces = string.IsNullOrEmpty(text_Mokadam_New.Text) ? 0 : int.Parse(text_Mokadam_New.Text);
            text_Mokadam_Total.Text = (motadawal + newCaces).ToString();
        }

        private void CalcMahkoumFih()
        {
            var textBoxes = groupBox_MahkoumFih.Controls.OfType<TextBox>().ToList();
            var textBoxesKatey = group_Katey.Controls.OfType<TextBox>().ToList();

            int totalKatey = 0;
            int mahkoumFih = 0;
            foreach (var textBox in textBoxes)
            {
                if (textBox.Name == "text_MahkoumFih_Total") continue;
                mahkoumFih += string.IsNullOrEmpty(textBox.Text) ? 0 : int.Parse(textBox.Text);


            }
            foreach (var textBox in textBoxesKatey)
            {
                if (textBox.Name == "text_MahkoumFih_Katey_Total") continue;
                totalKatey += string.IsNullOrEmpty(textBox.Text) ? 0 : int.Parse(textBox.Text);
            }

            mahkoumFih += totalKatey;
            text_MahkoumFih_Total.Text = mahkoumFih.ToString();
            text_MoagalatAlaAshhorTalia_Ethbat_Count.Text = string.IsNullOrEmpty(text_MahkoumFih_Ethbat.Text) ? " 0" : text_MahkoumFih_Ethbat.Text;
        }

        private void CalcMoeagalKhargALshahr()
        {
            var texboxs = group_MoeagalKhargALshahr.Controls.OfType<TextBox>().ToList();
            int MoeagalKhargALshahr = 0;
            foreach (var textBox in texboxs)
            {
                if (textBox.Name == "text_MoeagalKhargALshahr_Total") continue;
                MoeagalKhargALshahr += string.IsNullOrEmpty(textBox.Text) ? 0 : int.Parse(textBox.Text);
            }

            text_MoagalatAlaAshhorTalia_MahgouzLelhokm_Count.Text = string.IsNullOrEmpty(text_MoeagalKhargALshahr_MahgouzLelhokm.Text) ? "0" : text_MoeagalKhargALshahr_MahgouzLelhokm.Text;
            text_MoagalatAlaAshhorTalia_EadaLelMorafea_Count.Text = string.IsNullOrEmpty(text_MoeagalKhargALshahr_EadaLelMorafeah.Text) ? "0" : text_MoeagalKhargALshahr_EadaLelMorafeah.Text;
            text_MoagalatAlaAshhorTalia_MadAgal_Count.Text = string.IsNullOrEmpty(text_MoeagalKhargALshahr_MadAgl.Text) ? "0" : text_MoeagalKhargALshahr_MadAgl.Text;
            int MoagalLelTakrir = string.IsNullOrEmpty(text_MoeagalKhargALshahr_MoagalLelTakrir.Text) ? 0 : int.Parse(text_MoeagalKhargALshahr_MoagalLelTakrir.Text);
            int Okhra = string.IsNullOrEmpty(text_MoeagalKhargALshahr_Okhra.Text) ? 0 : int.Parse(text_MoeagalKhargALshahr_Okhra.Text);
            text_MoagalatAlaAshhorTalia_AlBaky_Count.Text = (MoagalLelTakrir + Okhra).ToString();


            text_MoeagalKhargALshahr_Total.Text = MoeagalKhargALshahr.ToString();
        }

        private void Calctext_Katey_Shakly()
        {
            var textboxs = group_Tawzie_Katey_Shakly.Controls.OfType<TextBox>().ToList();
            int shakly = 0;
            foreach (var textbox in textboxs)
            {

                if (textbox.Name == "text_Tawzie_Katey_Shakly_Total") continue;
                shakly += string.IsNullOrEmpty(textbox.Text) ? 0 : int.Parse(textbox.Text);
            }
            text_Tawzie_Katey_Shakly_Total.Text = shakly.ToString();
            text_MahkoumFih_Katey_Total.Text = shakly.ToString();
        }
        private void Calctext_Katey_Mawdoey()
        {
            var textboxs = group_Tawzie_Katey_Mawdoey.Controls.OfType<TextBox>().ToList();
            int Mawdoey = 0;
            foreach (var textbox in textboxs)
            {

                if (textbox.Name == "text_Tawzie_Katey_Mawdoey_Total") continue;
                Mawdoey += string.IsNullOrEmpty(textbox.Text) ? 0 : int.Parse(textbox.Text);
            }
            text_Tawzie_Katey_Mawdoey_Total.Text = Mawdoey.ToString();
            text_MahkoumFih_Katey_Mawdoey.Text = Mawdoey.ToString();
        }
        private void Calctext_Ethbat()
        {
            var textboxs = group_Tawzie_Ethbat.Controls.OfType<TextBox>().ToList();
            int Ethbat = 0;
            foreach (var textbox in textboxs)
            {

                if (textbox.Name == "text_Tawzie_Ethbat_Total") continue;
                Ethbat += string.IsNullOrEmpty(textbox.Text) ? 0 : int.Parse(textbox.Text);
            }
            text_Tawzie_Ethbat_Total.Text = Ethbat.ToString();
            text_MahkoumFih_Ethbat.Text = Ethbat.ToString();
        }
        private void Calctext_Okhra()
        {
            var textboxs = group_Tawzie_Okhra.Controls.OfType<TextBox>().ToList();
            int Okhra = 0;
            int Enktae = string.IsNullOrEmpty(text_Tawzie_Okhra_Enktae.Text) ? 0 : int.Parse(text_Tawzie_Okhra_Enktae.Text);
            int WakfEtfaky = string.IsNullOrEmpty(text_Tawzie_Okhra_WakfEtfaky.Text) ? 0 : int.Parse(text_Tawzie_Okhra_WakfEtfaky.Text);
            int WakfGzaey = string.IsNullOrEmpty(text_Tawzie_Okhra_WakfGzaey.Text) ? 0 : int.Parse(text_Tawzie_Okhra_WakfGzaey.Text);
            int WakfTaeliky = string.IsNullOrEmpty(text_Tawzie_Okhra_WakfTaeliky.Text) ? 0 : int.Parse(text_Tawzie_Okhra_WakfTaeliky.Text);
            Okhra = Enktae + WakfEtfaky + WakfGzaey + WakfTaeliky;

            text_Tawzie_Okhra_Total.Text = Okhra.ToString();
            text_MahkoumFih_EnktaeSirAlKhsoma.Text = Enktae.ToString();
            text_MahkoumFih_WakfEtfaky.Text = WakfEtfaky.ToString();
            text_MahkoumFih_WakfTaeliky.Text = WakfTaeliky.ToString();
            text_MahkoumFih_WakfGazaey.Text = WakfGzaey.ToString();

        }
        private void CalcTotalMahkomFIh()
        {
            int Katey_Shakly = string.IsNullOrEmpty(text_Tawzie_Katey_Shakly_Total.Text) ? 0 : int.Parse(text_Tawzie_Katey_Shakly_Total.Text);
            int Katey_Mawdoey = string.IsNullOrEmpty(text_Tawzie_Katey_Mawdoey_Total.Text) ? 0 : int.Parse(text_Tawzie_Katey_Mawdoey_Total.Text);
            int Ethbat = string.IsNullOrEmpty(text_Tawzie_Ethbat_Total.Text) ? 0 : int.Parse(text_Tawzie_Ethbat_Total.Text);
            int Okhra = string.IsNullOrEmpty(text_Tawzie_Okhra_Total.Text) ? 0 : int.Parse(text_Tawzie_Okhra_Total.Text);
            int solh = string.IsNullOrEmpty(text_Tawzie_Katey_Solh.Text) ? 0 : int.Parse(text_Tawzie_Katey_Solh.Text);
            int farey = string.IsNullOrEmpty(text_Tawzie_Farey.Text) ? 0 : int.Parse(text_Tawzie_Farey.Text);

            tex_Tawzie_TotalMahkomFih.Text = (Katey_Shakly + Katey_Mawdoey + Ethbat + Okhra + solh + farey).ToString();
        }
        #endregion
        #endregion


        #region Events
        private void StatisticsAddUserControl_Load(object sender, EventArgs e)
        {
            GetCircles();
            comboBox_CaseYear.DataSource = MyContext.context.CaseYears.ToList();
            comboBox_CaseYear.DisplayMember = "Name";
            comboBox_CaseYear.ValueMember = "Id";
            Text_SupCourt.Text = Config.SupCourtName;
            Text_SuperCourt.Text = Config.SuperCourtName;
            Text_Year.Text = Config.Year.ToString();
            Text_Month.Text = Config.Month.ToString();
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

        private void comboBox_CaseYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetValues();
        }
        private void TextBox_IntOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


        }

        #endregion


        private void text_Motadawal_TextChanged(object sender, EventArgs e)
        {
            CalcMotadawal();
        }

        private void text_Mokadam_TextChanged(object sender, EventArgs e)
        {
            CalcMokadam();
        }

        private void text_MahkoumFih_TextChanged(object sender, EventArgs e)
        {
            CalcMahkoumFih();
        }

        private void text_MoeagalKhargALshahr_TextChanged(object sender, EventArgs e)
        {
            CalcMoeagalKhargALshahr();
        }

        private void text_Tawzie_Katey_Shakly_TextChanged(object sender, EventArgs e)
        {
            Calctext_Katey_Shakly();
        }

        private void text_Tawzie_Katey_Mawdoey_TextChanged(object sender, EventArgs e)
        {
            Calctext_Katey_Mawdoey();
        }

        private void text_Tawzie_Ethbat_TextChanged(object sender, EventArgs e)
        {
            Calctext_Ethbat();
        }

        private void text_Tawzie_Okhra_TextChanged(object sender, EventArgs e)
        {
            Calctext_Okhra();
        }

        private void text_Tawzie_Katey_Solh_TextChanged(object sender, EventArgs e)
        {
            text_MahkoumFih_Katey_Solh.Text = text_Tawzie_Katey_Solh.Text;
            CalcTotalMahkomFIh();
        }

        private void text_Tawzie_Farey_TextChanged(object sender, EventArgs e)
        {
            text_MahkoumFih_Farey.Text = text_Tawzie_Farey.Text;
            CalcTotalMahkomFIh();
        }

        private void text_Tawzie_Total_TextChanged(object sender, EventArgs e)
        {
            CalcTotalMahkomFIh();
        }
    }
}
