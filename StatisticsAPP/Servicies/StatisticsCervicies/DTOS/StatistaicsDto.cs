using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Models.JudgeModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Servicies.StatisticsCervicies.DTOS
{
    public class CircleDayStatistaicsDto
    {
        [DisplayName("السنة")]
        public int Year { get; set; }
        [DisplayName("الشهر")]
        public int Month { get; set; }
        public int IdCircleDay { get; set; }
        public int IdCircle { get; set; }
        public int StartCaseYear { get; set; }
        public int EndCaseYear { get; set; }
        public int CountCaseYear { get; set; }
        public CircleCategory? CircleCategory { get; set; }= new CircleCategory();
        public CircleType? CircleType { get; set; } = new CircleType();
        public CircleMasterType? CircleMasterType { get; set; } = new CircleMasterType();
        public List<StatistaicsDto>? StaticsForYear { get; set; } = new List<StatistaicsDto>();
        public List<CircleJudge>? Judges { get; set; } = new List<CircleJudge>();
        public List<JudgesDeccisionDto>?   JudgeDecision1 { get; set; } = new List<JudgesDeccisionDto>();
        public List<JudgesDeccisionDto>?   JudgeDecision2 { get; set; } = new List<JudgesDeccisionDto>();
        public List<JudgesDeccisionDto>?   JudgeDecision3 { get; set; } = new List<JudgesDeccisionDto>();
        public List<JudgesDeccisionDto>?   JudgeDecision4 { get; set; } = new List<JudgesDeccisionDto>();
        public List<DelayCacesForMonthDto>? DelayCacesForMonthEthbat { get; set; } = new List<DelayCacesForMonthDto>();
        public List<DelayCacesForMonthDto>? DelayCacesForMonthMahgouzLelHokm { get; set; } = new List<DelayCacesForMonthDto>();
        public List<DelayCacesForMonthDto>? DelayCacesForMonthMadAgal { get; set; } = new List<DelayCacesForMonthDto>();
        public List<DelayCacesForMonthDto>? DelayCacesForMonthEadaLelMorafea { get; set; } = new List<DelayCacesForMonthDto>();
        public List<DelayCacesForMonthDto>? DelayCacesForMonthBaky { get; set; } = new List<DelayCacesForMonthDto>();





    }

    public class JudgesDeccisionDto
    {
        [DisplayName("هل اجمالي")]
        public int IsTotalRow { get; set; } = 0;
        [DisplayName("السنة")]
        public int Year { get; set; }
        [DisplayName("عدم قبول")]
        public int AdmKbol { get; set; }
        [DisplayName("عدم اختصاص")]
        public int AdmEjhtsas { get; set; }
        [DisplayName("سقوط الحق في رفع الدعوى")]
        public int SkotAlHakFiRAFEAlDaewa { get; set; }
        [DisplayName("سقوط الخصومة وانقضائها")]
        public int SkotAlKhsomaWEnkdaeha { get; set; }
        [DisplayName("ترك الخصومة")]
        public int TarkAlKhsoma{ get; set; }
        [DisplayName("انعدام الخصومة")]
        public int EnedamAlKhsoma { get; set; }
        [DisplayName("كأن لم تكن")]
        public int KanLamTkon { get; set; }
       
        [DisplayName("قبول")]
        public int Kbol{ get; set; }
        [DisplayName("رفض")]
        public int Rafd{ get; set; }
        [DisplayName("رفض بحالتها")]
        public int RafdBeHalatha{ get; set; }
        [DisplayName("عدم جواز لسابقة الفصل")]
        public int AdamGwazLeSabekatAlFaslFiha{ get; set; }
        [DisplayName("انقضاء الحق بمضي المدة (التقادم)")]
        public int EnkdaeAlhakBeModiAlModa{ get; set; }
     
        [DisplayName("صلح")]
        public int Solh{ get; set; }
        [DisplayName("اجمالي الاحكام القطعية")]
        public int TotalKatey => AdmKbol + AdmEjhtsas + SkotAlHakFiRAFEAlDaewa + SkotAlKhsomaWEnkdaeha + TarkAlKhsoma + EnedamAlKhsoma + KanLamTkon + Kbol + Rafd + RafdBeHalatha + AdamGwazLeSabekatAlFaslFiha + EnkdaeAlhakBeModiAlModa + Solh;
        [DisplayName("أحكام فرعية")]
        public int Farey { get; set; }
        [DisplayName("ندب خبير")]
        public int NadbKhabir { get; set; }
        [DisplayName("إعادة للخبير")]
        public int BackTOKhabir { get; set; }
        [DisplayName("تحقيق")]
        public int Tahkik { get; set; }
        [DisplayName("استجواب")]
        public int Estgwab { get; set; }
        [DisplayName("حلف يمين")]
        public int HelfYamin { get; set; }
        [DisplayName("وقف جزائي")]
        public int WakfGazaey { get; set; }
        [DisplayName("وقف تعليقي")]
        public int WakfTaeliky { get; set; }
        [DisplayName("وقف اتفاقي")]
        public int WakfEtifaky { get; set; }
        [DisplayName("انقطاع سير الخصومة")]
        public int EnktaeSirAlKhsoma { get; set; }
        [DisplayName("المجموع")]
        public int Total => TotalKatey + Farey + NadbKhabir + BackTOKhabir + Tahkik + Estgwab + HelfYamin + WakfGazaey + WakfTaeliky + WakfEtifaky + EnktaeSirAlKhsoma;
        [DisplayName("مد أجل")]
        public int MadAgal { get; set; }
        [DisplayName("إعادة للمرافعة")]
        public int EadaLelMorafea { get; set; }
        [DisplayName("القضايا المعادة من الاستئناف")]
        public int MoeadMenAlEsenaf { get; set; } 
    }
    public class StatistaicsDto
    {
        [DisplayName("هل اجمالي")]
        public int IsTotalRow { get; set; } = 0;
        [DisplayName("السنة")]
        public int Year { get; set; }
        [DisplayName("السابق")]
        public int Sapek { get; set; }
        [DisplayName("مجدد من الشطب")]
        public int MogaddMenShatb { get; set; }
        [DisplayName("معجل من الوقف لحين الفصل في")]
        public int moagalMenAlwakfLhinAlfasl { get; set; }
        [DisplayName("معجل من الوقف الجزائي")]
        public int moagalMenAlwakfGzaey { get; set; }
        [DisplayName("معجل من الوقف التعليقي")]
        public int moagalMenAlwakfTaeliky { get; set; }
        [DisplayName("معجل من الوقف الاتفاقي")]
        public int moagalMenAlwakfItfaky { get; set; }
        [DisplayName("معجل من الانقطاع")]
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
        [DisplayName("جديد")]
        public int newCases { get; set; }
        [DisplayName("جملة المقدم")]
        public int TotalMokadam => Sapek + MogaddMenShatb + moagalMenAlwakfLhinAlfasl + moagalMenAlwakfGzaey + moagalMenAlwakfTaeliky + moagalMenAlwakfItfaky + moagalMenAlEnktae + MoadMenAlEstenf + TaksirCount + ehalaTo + newCases - EhalaForm;
        [DisplayName("المشطوب")]
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
        public int Estgwap { get; set; }
        [DisplayName("حلف يمين")]
        public int HelfYamin { get; set; }
        [DisplayName("جملة الاثبات")]
        public int TotalEthbat =>  Khapir + BackToKhapir + Tahkik + Estgwap + HelfYamin;
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
        public int TotaMahkomFih => TotalKatey + TotalEthbat + TotalWakf + EnktaeSirAlKhsoma + Farey;
        [DisplayName("محجوز للحكم خارج الشهر")]
        public int MahguzLelHokm { get; set; }
        [DisplayName("مد اجل خارج الشهر")]
        public int MadAgal { get; set; }
        [DisplayName("اعادة للمرافعة خارج الشهر")]
        public int EadaLelMorafea { get; set; }
        [DisplayName("المؤجل لورود التقرير")]
        public int MoeagalLelTkrir { get; set; }
        [DisplayName("أخرى")]
        public int Okhrah { get; set; }
        [DisplayName("جملة المؤجل")]

        public int TotoalMoeagal => MahguzLelHokm + MadAgal + EadaLelMorafea + MoeagalLelTkrir + Okhrah;


    }
    public class DelayCacesForMonthDto
    {
        public int CaseYear { get; set; }
        public int Month1 { get; set; }
        public int Month2 { get; set; }
        public int Month3 { get; set; }
        public int Total => Month1 + Month2 + Month3;

    }
    }
