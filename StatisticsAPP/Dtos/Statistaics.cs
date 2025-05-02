using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Dtos
{
    public class Statistaics
    {
        [DisplayName("السنة")]
        public int Year { get; set; }
        [DisplayName("السابق")]
        public int Sapek { get; set; }
        [DisplayName("مجدد من الشطب")]
        public int MogaddMenShatb { get; set; }
        [DisplayName("من الوقف لحين الفصل")]
        public int moagalMenAlwakfLhinAlfasl { get; set; }
        [DisplayName("من الوقف الجزائي")]
        public int moagalMenAlwakfGzaey { get; set; }
        [DisplayName("من الوقف التعليقي")]
        public int moagalMenAlwakfTaeliky { get; set; }
        [DisplayName("من الوقف الاتفاقي")]
        public int moagalMenAlwakfItfaky { get; set; }
        [DisplayName("من الانقطاع")]
        public int moagalMenAlEnktae { get; set; }
        [DisplayName("معاد من الاستئناف")]
        public int MoadMenAlEstenf { get; set; }
        [DisplayName("العدد المقصر")]
        public int TaksirCount { get; set; }
        [DisplayName("الشهر المقصر منه")]
        public int TaksirMonth { get; set; }
        [DisplayName("احالة من الدائرة")]
        public int EhalaForm { get; set; }
        [DisplayName("احالة الى الدائرة")]
        public int ehalaTo { get; set; }
        [DisplayName("الجديد")]
        public int newCases { get; set; }
        [DisplayName("جملة المقدم")]
        public int TotalMokadam => Sapek + MogaddMenShatb + moagalMenAlwakfLhinAlfasl + moagalMenAlwakfGzaey + moagalMenAlwakfTaeliky + moagalMenAlwakfItfaky + moagalMenAlEnktae + MoadMenAlEstenf + TaksirCount + ehalaTo + newCases - EhalaForm;
        [DisplayName("المشطب")]
        public int Mashtob { get; set; }
        [DisplayName("شكلي")]
        public int Shakly { get; set; }
        [DisplayName("موضوعي")]
        public int Mawdoey { get; set; }
        [DisplayName("صلح")]
        public int Solh { get; set; }
        [DisplayName("جملة الاحكام القطعية")]
        public int TotalKatey => Mawdoey + Shakly + Solh;
        [DisplayName("فرعي")]
        public int Farey { get; set; }
        [DisplayName("ندب خبير")]
        public int Khapir { get; set; }
        [DisplayName("اعادة للخبير")]
        public int BackToKhapir { get; set; }
        [DisplayName("تحقيق")]
        public int Tahkik { get; set; }
        [DisplayName("استجواب")]
        public int Estgeap { get; set; }
        [DisplayName("حلف يمين")]
        public int HelfYamin { get; set; }
        [DisplayName("جملة الاثبات")]
        public int TotalEthbat => Farey + Khapir + BackToKhapir + Tahkik + Estgeap + HelfYamin;
        [DisplayName("وقف جزائي")]
        public int WakfGazaey { get; set; }
        [DisplayName("وقف تعليقي")]
        public int WakfTaeliky { get; set; }
        [DisplayName("وقف اتفاقي")]
        public int WakfEtfaky { get; set; }
        [DisplayName("جملة الوقف")]
        public int TotalWakf => WakfGazaey + WakfTaeliky + WakfEtfaky;
        [DisplayName("انقطاع سير الخصومة")]
        public int EnktaeSirAlKhsoma { get; set; }
        [DisplayName("جملة المحكوم فيه")]
        public int TotaMahkomFih => TotalKatey + TotalEthbat + TotalWakf + EnktaeSirAlKhsoma;
        [DisplayName("محجوز للحكم")]
        public int MahguzLelHokm { get; set; }
        [DisplayName("مد اجل")]
        public int MadAgal { get; set; }
        [DisplayName("اعادة للمرافعة")]
        public int EadaLelMorafea { get; set; }
        [DisplayName("مؤجل للتقرير")]
        public int MoeagalLelTkrir { get; set; }
        [DisplayName("اخرى")]
        public int Okhrah { get; set; }
        [DisplayName("جملة المؤجل")]

        public int TotoalMoeagal => MahguzLelHokm + MadAgal + EadaLelMorafea + MoeagalLelTkrir + Okhrah;


    }

}
