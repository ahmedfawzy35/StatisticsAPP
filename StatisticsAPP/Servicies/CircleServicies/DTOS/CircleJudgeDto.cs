using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Servicies.CircleServicies.DTOS
{
    public class CircleJudgeDto
    {
        private static readonly Dictionary<int, string> RateNames = new()
    {
        { 1, "رئيس الدائرة" },
        { 2, "عضو يمين" },
        { 3, "عضو يسار" },
        { 4, "عضو يسار اليسار" }
    };
        [DisplayName("المعرف")]
        public int Id { get; set; }
        [DisplayName("رقم الدائرة")]
        public int IdCircle { get; set; }
        [DisplayName("رقم القاضي")]
        public int IdJudge { get; set; }
        [DisplayName("اسم القاضي")]
        public string NameJudge { get; set; } = string.Empty;
        [DisplayName("اسم الدائرة")]
        public string NameCircle { get; set; } = string.Empty;
        [DisplayName("الترتيب")]
        public int rate { get; set; } 
        [DisplayName("الوظيفة")]
        public string rateName => RateNames.ContainsKey(rate) ? RateNames[rate] : "غير معروف";
        [DisplayName("تاريخ البداية")]
        public DateTime DateStart { get; set; }
        [DisplayName("تاريخ النهاية")]
        public DateTime? DateEnd { get; set; }
    }

   
}
