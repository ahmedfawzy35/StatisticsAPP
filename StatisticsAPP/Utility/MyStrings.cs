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
        public static string PermessionEdit_Code = "EDIT";
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

        enum ArabicDay
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
            public static string DelayCasesCategoriy = "تصنيفات القضايا المؤجلة";
            public static string DelayCase = "القضايا المؤجلة";

            #endregion

            #region InterCasesModels
            public static string InterCasesCategory = "تصنيفات القضايا المقدمة";
            public static string InterCase = "القضايا المقدمة";

            #endregion

            #region JudgeModels
            public static string Judge = "القضاة";

            #endregion

            #region StatisticsModels
            public static string CircleStatistic = "احصائيات الدوائر";
            public static string StatisticsDecision = "احصائيات الاحكام";
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
                    User, Role, UserRole, RoleOperation ,UserCircles,UserSupCourts,UserSuperCourts, Circle, CircleType,CircleJudge,SuperCourt,
                    SupCourt,DecisionCategory,Decision,DelayCasesCategoriy,DelayCase,
                    InterCasesCategory,InterCase,Judge,CircleStatistic,StatisticsDecision,StatisticsInterCases,StatisticsDelayCases
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
                    new OperationTexts{Name = SuperCourt , Code = GetPropertyName(()=>SuperCourt),},
                    new OperationTexts{Name = SupCourt , Code = GetPropertyName(()=>SupCourt),},
                    new OperationTexts{Name = DecisionCategory , Code = GetPropertyName(()=>DecisionCategory),},
                    new OperationTexts{Name = Decision , Code = GetPropertyName(()=>Decision),},
                    new OperationTexts{Name = DelayCasesCategoriy , Code = GetPropertyName(()=>DelayCasesCategoriy),},
                    new OperationTexts{Name = DelayCase , Code = GetPropertyName(()=>DelayCase),},
                    new OperationTexts{Name = InterCasesCategory , Code = GetPropertyName(()=>InterCasesCategory),},
                    new OperationTexts{Name = InterCase , Code = GetPropertyName(()=>InterCase),},
                    new OperationTexts{Name = Judge , Code = GetPropertyName(()=>Judge),},
                    new OperationTexts{Name = CircleStatistic , Code = GetPropertyName(()=>CircleStatistic),},
                    new OperationTexts{Name = StatisticsDecision , Code = GetPropertyName(()=>StatisticsDecision),},
                    new OperationTexts{Name = StatisticsInterCases , Code = GetPropertyName(()=>StatisticsInterCases),},
                    new OperationTexts{Name = StatisticsDelayCases , Code = GetPropertyName(()=>StatisticsDelayCases),},

                };
            }
        }
        }
}
