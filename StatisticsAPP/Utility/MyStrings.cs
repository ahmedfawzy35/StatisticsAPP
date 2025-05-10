using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static StatisticsAPP.Seeds.Permissions;

namespace StatisticsAPP.Utility
{
    public static class MyStrings
    {
        public static string PermessionType = "التصريح";
        public static string PermessionView = "بعرض";
        public static string PermessionCreate = "بإضافة";
        public static string PermessionEdit = "بتعديل";
        public static string PermessionDelete = "بحذف";
        public static string PermessionView_Code = "VIEW_";
        public static string PermessionCreate_Code = "ADD_";
        public static string PermessionEdit_Code = "EDIT_";
        public static string PermessionDelete_Code = "DELETE_";
        public static string UnPermission = "غير مصرح";

       


        public static string AddSucsessMessage = "تمت الاضافة بنجاح";
        public static string AddFaildMessage = "فشل الاضافه";
        public static string EditSucsessMessage = "تم التعديل بنجاح";
        public static string EditFaildMessage = "فشل التعديل";
        public static string DeleteSucsessMessage = "تم الحذف بنجاح";
        public static string DeleteFaildMessage = "فشل الحذف";

        public static string UnPermissionMessage(string permission, string model)
        {
            return $"{UnPermission} {permission} {model}";
        }
        public static string ErroMessageNotFound(string Name)
        {
            return string.Format("لم يتم ايجاد {0} في قاعدة البيانات", Name);
        }

        public enum ArabicDay
        {
            السبت,
            الأحد,
            الإثنين,
            الثلاثاء,
            الأربعاء,
            الخميس,
            الجمعه
        }
        public static string GetArabicDay(string EnglishDay)
        {
            switch (EnglishDay)
            {
                case "Sunday":
                    return ArabicDay.الأحد.ToString();

                case "Monday":
                    return ArabicDay.الإثنين.ToString();

                case "Tuesday":
                    return ArabicDay.الثلاثاء.ToString();

                case "Wednesday":
                    return ArabicDay.الأربعاء.ToString();

                case "Thursday":
                    return ArabicDay.الخميس.ToString();

                case "Friday":
                    return ArabicDay.الجمعه.ToString();

                case "Saturday ":
                    return ArabicDay.السبت.ToString();


                default:
                    return "الاحد";
            }
        }
        //  public static List<string> models = ModulsName.Modules();

        public static class ModulsName

        {

            #region DeletedItems
           

            #endregion

            #region Auth
            public static string User = "المستخدمين";
            public static string Role = "الادوار";
            public static string UserRole = "ادوار المستخدمين";
            public static string RoleOperation = "اجراءات الدور";
            public static string UserCircles = "المحاكم الابتدائية للمستخدم";
            public static string UserSupCourts = "المحاكم الجزئية للمستخدم";
            public static string UserSuperCourts = "الدوائر للمستخدم";


            #endregion

            #region CircleModels
            public static string Circle = "الدوائر";
            public static string CircleType = "انواع الدوائر";
            public static string CircleJudge = "تعيينات القضاه";
            public static string CircleDay = "ايام الانعقاد";

            #endregion

            #region CourtsModels
            public static string SuperCourt = "المحاكم الابتدائية";
            public static string SupCourt = "المحاكم الجزئية";

            #endregion

            #region DecisionModels
            public static string DecisionCategory = "تصنيفات الاحكام";
            public static string Decision = "الاحكام";

            #endregion

            #region DelayCasesModels
            public static string DelayCasesCategory = "تصنيفات القضايا المؤجلة";
            public static string DelayCase = "القضايا المؤجلة";

            #endregion

            #region InterCasesModels
            public static string InterCasesCategory = "تصنيفات القضايا المقدمة";
            public static string InterCases = "القضايا المقدمة";

            #endregion

            #region JudgeModels
            public static string Judge = "القضاة";

            #endregion

            #region StatisticsModels
            public static string CircleStatistics = "احصائيات الدوائر";
            public static string StatisticsDecisions = "احصائيات الاحكام";
            public static string StatisticsInterCases = "احصائيات القضايا الداخلة";
            public static string StatisticsDelayCases = "احصائيات القضايا المؤجلة";

            #endregion

            public static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
            {
                return ((MemberExpression)propertyExpression.Body).Member.Name;
            }
            public static List<string> Modules()
            {
               
                return new List<string>
                {
                    User, Role, UserRole, RoleOperation ,UserCircles,UserSupCourts,UserSuperCourts, Circle, CircleType,CircleJudge,CircleDay,SuperCourt,
                    SupCourt,DecisionCategory,Decision,DelayCasesCategory,DelayCase,
                    InterCasesCategory,InterCases,Judge,CircleStatistics,StatisticsDecisions,StatisticsInterCases,StatisticsDelayCases
                };
            }

            public static List<OperationTexts> ModulesoperationTexts()
            {
                return new List<OperationTexts>
                {
                    new OperationTexts{Name = User , Code = GetPropertyName(()=>User),},
                    new OperationTexts{Name = Role , Code = GetPropertyName(()=>Role),},
                    new OperationTexts{Name = UserRole , Code = GetPropertyName(()=>UserRole),},
                    new OperationTexts{Name = RoleOperation , Code = GetPropertyName(()=>RoleOperation),},
                    new OperationTexts{Name = UserCircles , Code = GetPropertyName(()=>UserCircles),},
                    new OperationTexts{Name = UserSupCourts , Code = GetPropertyName(()=>UserSupCourts),},
                    new OperationTexts{Name = UserSuperCourts , Code = GetPropertyName(()=>UserSuperCourts),},
                    new OperationTexts{Name = Circle , Code = GetPropertyName(()=>Circle),},
                    new OperationTexts{Name = CircleType , Code = GetPropertyName(()=>CircleType),},
                    new OperationTexts{Name = CircleJudge , Code = GetPropertyName(()=>CircleJudge),},
                    new OperationTexts{Name = CircleDay , Code = GetPropertyName(()=>CircleDay),},
                    new OperationTexts{Name = SuperCourt , Code = GetPropertyName(()=>SuperCourt),},
                    new OperationTexts{Name = SupCourt , Code = GetPropertyName(()=>SupCourt),},
                    new OperationTexts{Name = DecisionCategory , Code = GetPropertyName(()=>DecisionCategory),},
                    new OperationTexts{Name = Decision , Code = GetPropertyName(()=>Decision),},
                    new OperationTexts{Name = DelayCasesCategory , Code = GetPropertyName(()=>DelayCasesCategory),},
                    new OperationTexts{Name = DelayCase , Code = GetPropertyName(()=>DelayCase),},
                    new OperationTexts{Name = InterCasesCategory , Code = GetPropertyName(()=>InterCasesCategory),},
                    new OperationTexts{Name = InterCases , Code = GetPropertyName(()=>InterCases),},
                    new OperationTexts{Name = Judge , Code = GetPropertyName(()=>Judge),},
                    new OperationTexts{Name = CircleStatistics , Code = GetPropertyName(()=>CircleStatistics),},
                    new OperationTexts{Name = StatisticsDecisions , Code = GetPropertyName(()=>StatisticsDecisions),},
                    new OperationTexts{Name = StatisticsInterCases , Code = GetPropertyName(()=>StatisticsInterCases),},
                    new OperationTexts{Name = StatisticsDelayCases , Code = GetPropertyName(()=>StatisticsDelayCases),},

                };
            }

            public static string GetModulesCode(string modelName)
            {
              var model =   ModulesoperationTexts().Where(x => x.Name == modelName).FirstOrDefault();
                if (model != null)
                {
                    return model.Code;
                }
                return string.Empty ;
            }
        }

        public static class  InterCasesTypes
        {
           public const string MogaddMenShatb = "مجدد من الشطب";
           public const string moagalMenAlwakfLhinAlfasl = "معجل من الوقف لحين الفصل في";
           public const string moagalMenAlwakfGzaey = "معجل من الوقف الجزائي";
           public const string moagalMenAlwakfTaeliky = "معجل من الوقف التعليقي";
           public const string moagalMenAlwakfItfaky = "معجل من الوقف الاتفاقي";
           public const string moagalMenAlEnktae = "معجل من الانقطاع";
           public const string MoadMenAlEstenf = "معاد من الاستئناف";
           public const string EhalaForm = "احالة من الدائرة";
           public const string ehalaTo = "احالة الى الدائرة";
           public const string newCases = "جديد";
          

        }
        public static class DecisionKateyTypes
        {
           
            public const string Shakly = "شكلي";
            public const string Mawdoey = "موضوعي";
            public const string Solh = "صلح";
          
        }
        public static class DecisionKatey_ShaklyTypes
        {
           
            public const string AdmKbol = "عدم قبول";
            public const string AdmEjhtsas = "عدم اختصاص";
            public const string SkotAlHakFiRAFEAlDaewa = "سقوط الحق في رفع الدعوى";
            public const string SkotAlKhsomaWEnkdaeha = "سقوط الخصومة وانقضائها";
            public const string TarkAlKhsoma = "ترك الخصومة";
            public const string EnedamAlKhsoma = "انعدام الخصومة";
            public const string KanLamTkon = "كأن لم تكن";
          
        } 
        public static class DecisionKatey_MawdoeyTypes
        {
           
            public const string Kbol = "قبول";
            public const string Rafd = "رفض";
            public const string RafdBeHalatha = "رفض بحالتها";
            public const string AdamGwazLeSabekatAlFaslFiha = "عدم جواز لسابقة الفصل فيها";
            public const string EnkdaeAlhakBeModiAlModa = "انقضاء الحق بمضي المدة";
            public const string Solh = "صلح";
          
        } 


        public static class DecisionFareyTypes
        {
           
            public const string Farey = "فرعي";
           
          
        }
        public static class DecisionMadAgalTypes
        {

            public const string MadAgal = "مد أجل";


        }
        public static class DecisionEadaLeMorafeaTypes
        {

            public const string EadaLelMorafea = "إعادة للمرافعة";


        }
        public static class DecisionEnktaeSirAlKhsomaTypes
        {
           
            public const string EnktaeSirAlKhsoma = "انقطاع سير الخصومه";
           
          
        }
        public static class DecisionWakftTypes
        {
            public const string WakfGazaey = "وقف جزائي";
            public const string WakfTaeliky = "وقف تعليقي";
            public const string WakfEtfaky = "وقف اتفاقي";
           
        }
        public static class DecisionEthbatTypes
        {
            public const string Khapir = "ندب خبير";
            public const string BackToKhapir = "إعادة للخبير";
            public const string Tahkik = "تحقيق";
            public const string Estgwap = "استجواب";
            public const string HelfYamin = "حلف يمين";
           
        }
        public static class DelayCacesypes
        {
            public const string MahguzLelHokm = "محجوز للحكم خارج الشهر";
            public const string MadAgal = "مد اجل خارج الشهر";
            public const string EadaLelMorafea = "اعادة للمرافعة خارج الشهر";
            public const string MoeagalLelTkrir = "المؤجل لورود التقرير";
            public const string Okhrah = "أخرى";


        }
    }
}
