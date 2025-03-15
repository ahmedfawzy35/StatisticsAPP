using Microsoft.EntityFrameworkCore;
using StatisticsAPP.Data;
using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Models.CourtsModels;
using StatisticsAPP.Models.DecisionModels;
using StatisticsAPP.Models.DelayCasesModels;
using StatisticsAPP.Models.InterCasesModels;
using StatisticsAPP.Models.StatisticsModels;
using StatisticsAPP.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Seeds
{
    public static class DefualtData
    {
        public static readonly ApplicationDbContext db = new ApplicationDbContext();
        public static int userid = LocalUser.localUserId;

        public static async Task AddDefultCircleType()
        {
            CircleType circleType = new CircleType { Name = "مدني", UserId = userid, CreatedAt = DateTime.Now };
            CircleType circleType2 = new CircleType { Name = "جنائي", UserId = userid, CreatedAt = DateTime.Now };
            CircleType circleType3 = new CircleType { Name = "اسرة", UserId = userid, CreatedAt = DateTime.Now };
            db.CircleTypes.Add(circleType);
            await db.SaveChangesAsync();
        }
        public static async Task AddDefultSuperCourt()
        {
            SuperCourt superCourt = new SuperCourt { Name = "محكمة بني سويف الابتدائية", UserId = userid, CreatedAt = DateTime.Now };
            db.SuperCourts.Add(superCourt);
            await db.SaveChangesAsync();
        }
        public static async Task AddDefultSupCourt()
        {
            var superCourtBn = await db.SuperCourts.Where(x => x.Name == "محكمة بني سويف الابتدائية").FirstOrDefaultAsync();
            if (superCourtBn == null) return;
            var superCourtId = superCourtBn.Id;
            SupCourt supCourt = new SupCourt { Name = "محكمة بني سويف الكلية", Adress = "مجمع المحاكم حي الرمد بني سويف", SuperCourtId = superCourtId, UserId = userid, CreatedAt = DateTime.Now };
            SupCourt supCourt1 = new SupCourt { Name = "محكمة الواسطى" + " " + "الجزئية", Adress = "مركز الواسطى بنب سويف", SuperCourtId = superCourtId, UserId = userid, CreatedAt = DateTime.Now };
            SupCourt supCourt2 = new SupCourt { Name = "محكمة ناصر", Adress = "مركز ناصر بني سويف", SuperCourtId = superCourtId, UserId = userid, CreatedAt = DateTime.Now };
            SupCourt supCourt3 = new SupCourt { Name = "محكمة بندر بني سويف" + " " + "الجزئية", Adress = "مجمع المحاكم حي الرمد بني سويف", SuperCourtId = superCourtId, UserId = userid, CreatedAt = DateTime.Now };
            SupCourt supCourt4 = new SupCourt { Name = "محكمة مركز بني سويف" + " " + "الجزئية", Adress = "شارع عبدالسلام عارف بندر بني سويف", SuperCourtId = superCourtId, UserId = userid, CreatedAt = DateTime.Now };
            SupCourt supCourt5 = new SupCourt { Name = "محكمة اهناسيا" + " " + "الجزئية", Adress = "مركز اهناسيا بني سويف", SuperCourtId = superCourtId, UserId = userid, CreatedAt = DateTime.Now };
            SupCourt supCourt6 = new SupCourt { Name = "محكمة ببا" + " " + "الجزئية", Adress = "مركز ببا بني سويف", SuperCourtId = superCourtId, UserId = userid, CreatedAt = DateTime.Now };
            SupCourt supCourt7 = new SupCourt { Name = "محكمة سمسطا" + " " + "الجزئية", Adress = "مركز سمسطا بني سويف", SuperCourtId = superCourtId, UserId = userid, CreatedAt = DateTime.Now };
            SupCourt supCourt8 = new SupCourt { Name = "محكمة الفشن" + " " + "الجزئية", Adress = "مركز الفشن بني سويف", SuperCourtId = superCourtId, UserId = userid, CreatedAt = DateTime.Now };
            db.SupCourts.AddRange(new List<SupCourt> { supCourt , supCourt1, supCourt2, supCourt3, supCourt4, supCourt5, supCourt6 ,  supCourt7,supCourt8});
            await db.SaveChangesAsync();
        }
        public static async Task AddDefultFatherDecisionCategory()
        {
            DecisionCategory decisionCategory = new DecisionCategory { Name = "قطعي", IsFather = true, UserId = userid, CreatedAt = DateTime.Now };
            DecisionCategory decisionCategory2 = new DecisionCategory { Name = "فرعي", IsFather = false, UserId = userid, CreatedAt = DateTime.Now };
            DecisionCategory decisionCategory3 = new DecisionCategory { Name = "اثبات", IsFather = true, UserId = userid, CreatedAt = DateTime.Now };
            DecisionCategory decisionCategory4 = new DecisionCategory { Name = "وقف", IsFather = true, UserId = userid, CreatedAt = DateTime.Now };
            DecisionCategory decisionCategory5 = new DecisionCategory { Name = "انقطاع سير الخصومه", IsFather = false, UserId = userid, CreatedAt = DateTime.Now };
            DecisionCategory decisionCategory6 = new DecisionCategory { Name = "مد أجل", IsFather = false, UserId = userid, CreatedAt = DateTime.Now };
            DecisionCategory decisionCategory7 = new DecisionCategory { Name = "إعادة للمرافعة", IsFather = false, UserId = userid, CreatedAt = DateTime.Now };

            db.DecisionCategories.AddRange(new List<DecisionCategory> { decisionCategory , decisionCategory2, decisionCategory3, decisionCategory4,
                                                                        decisionCategory5,decisionCategory6,decisionCategory7});
            await db.SaveChangesAsync();
        }
        public static async Task AddDefultSecondDecisionCategory()
        {
            var قطعي = await db.DecisionCategories.Where(x => x.Name == "قطعي").FirstOrDefaultAsync();
            if (قطعي == null) return;

            DecisionCategory decisionCategory = new DecisionCategory { Name = "شكلي", IsFather = false, UserId = userid, CreatedAt = DateTime.Now  , ParentID = قطعي.Id};
            DecisionCategory decisionCategory1 = new DecisionCategory { Name = "موضوعي", IsFather = false, UserId = userid, CreatedAt = DateTime.Now  , ParentID = قطعي.Id };
            db.DecisionCategories.AddRange(new List<DecisionCategory> { decisionCategory , decisionCategory1});

           


           
         


            await db.SaveChangesAsync();
        }
       
        public static async Task AddDefultDecisions()
        {
            var قطعي = await db.DecisionCategories.Where(x => x.Name == "قطعي").FirstOrDefaultAsync();
            if (قطعي == null) return;
            Decision decision = new Decision { Name = "صلح" , UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = قطعي.Id };

            var اثبات = await db.DecisionCategories.Where(x => x.Name == "اثبات").FirstOrDefaultAsync();
            if (اثبات == null) return;
            Decision decision3 = new Decision { Name = "ندب خبير",  UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = اثبات.Id };
            Decision decision4 = new Decision { Name = "إعادة للخبير", UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = اثبات.Id };
            Decision decision5 = new Decision { Name = "تحقيق", UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = اثبات.Id };
            Decision decision6 = new Decision { Name = "استجواب",  UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = اثبات.Id };
            Decision decision7 = new Decision { Name = "حلف يمين",  UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = اثبات.Id  };


            var وقف = await db.DecisionCategories.Where(x => x.Name == "وقف").FirstOrDefaultAsync();
            if (وقف == null) return;
            Decision decision8 = new Decision { Name = "وقف جزائي", UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = وقف.Id };
            Decision decision9 = new Decision { Name = "وقف تعليقي",  UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = وقف.Id };
            Decision decision10 = new Decision { Name = "وقف اتفاقي", UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = وقف.Id };


            var فرعي = await db.DecisionCategories.Where(x => x.Name == "فرعي").FirstOrDefaultAsync();
            if (فرعي == null) return;
            Decision decision11 = new Decision { Name = "فرعي", UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = فرعي.Id };

            var سير = await db.DecisionCategories.Where(x => x.Name == "انقطاع سير الخصومه").FirstOrDefaultAsync();
            if (سير == null) return;
            Decision decision12 = new Decision { Name = "انقطاع سير الخصومه", UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = سير.Id };

            var مرافعة = await db.DecisionCategories.Where(x => x.Name == "إعادة للمرافعة").FirstOrDefaultAsync();
            if (مرافعة == null) return;
            Decision decision13 = new Decision { Name = "إعادة للمرافعة",  UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = مرافعة.Id };

            var مد_اجل = await db.DecisionCategories.Where(x => x.Name == "مد أجل").FirstOrDefaultAsync();
            if (مد_اجل == null) return;
            Decision decision14 = new Decision { Name = "مد أجل", UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = مد_اجل.Id };


            var شكلي = await db.DecisionCategories.Where(x => x.Name == "شكلي").FirstOrDefaultAsync();
            if (شكلي == null) return;
            Decision decision15 = new Decision { Name = "عدم قبول", UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = شكلي.Id };
            Decision decision16 = new Decision { Name = "عدم اختصاص", UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = شكلي.Id };
            Decision decision17 = new Decision { Name = "سقوط الحق في رفع الدعوى", UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = شكلي.Id };
            Decision decision18 = new Decision { Name = "سقوط الخصومة وانقضائها",  UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = شكلي.Id };
            Decision decision19 = new Decision { Name = "ترك الخصومة",  UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = شكلي.Id };
            Decision decision20 = new Decision { Name = "انعدام الخصومة",  UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = شكلي.Id };
            Decision decision21 = new Decision { Name = "كأن لم تكن",  UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = شكلي.Id };

         
            var موضوعي = await db.DecisionCategories.Where(x => x.Name == "موضوعي").FirstOrDefaultAsync();
            if (موضوعي == null) return;
            Decision decision22 = new Decision { Name = "قبول",UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = موضوعي.Id };
            Decision decision23 = new Decision { Name = "رفض",  UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = موضوعي.Id };
            Decision decision24 = new Decision { Name = "رفض بحالتها",  UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = موضوعي.Id };
            Decision decision25 = new Decision { Name = "عدم جواز لسابقة الفصل فيها",  UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = موضوعي.Id };
            Decision decision26 = new Decision { Name = "انقضاء الحق بمضي المدة",  UserId = userid, CreatedAt = DateTime.Now, IdDecisionCategory = موضوعي.Id };

            db.Decisions.AddRange(new List<Decision> { decision,decision3,decision4,decision5,decision6,decision7,decision8,decision9,decision10,decision11,decision12,decision13,decision14,
                                                       decision14,decision16,decision17,decision18,decision19,decision20,decision21,decision22,decision23,decision24,decision25,decision26});
            await db.SaveChangesAsync();

        }

        public static async Task AddDefultDelayCase()
        {
            DelayCase delayCase = new DelayCase { Name = "محجوز للحكم خارج الشهر", UserId = userid, CreatedAt = DateTime.Now };
            DelayCase delayCase1 = new DelayCase { Name = "مد اجل خارج الشهر", UserId = userid, CreatedAt = DateTime.Now };
            DelayCase delayCase2 = new DelayCase { Name = "اعادة للمرافعة خارج الشهر", UserId = userid, CreatedAt = DateTime.Now };
            DelayCase delayCase3 = new DelayCase { Name = "المؤجل لورود التقرير", UserId = userid, CreatedAt = DateTime.Now };
            DelayCase delayCase4 = new DelayCase { Name = "أخرى", UserId = userid, CreatedAt = DateTime.Now };

            db.DelayCases.AddRange(new List<DelayCase> { delayCase , delayCase1, delayCase2, delayCase3 , delayCase4 });
            await db.SaveChangesAsync();

        }
        public static async Task AddDefultFatherInterCasesCategory()
        {
            InterCasesCategory interCasesCategory1 = new InterCasesCategory { Name = "متداول", IsFather = true, UserId = userid, CreatedAt = DateTime.Now  };
            InterCasesCategory interCasesCategory2 = new InterCasesCategory { Name = "جديد", IsFather = true, UserId = userid, CreatedAt = DateTime.Now  };
            db.InterCasesCategories.AddRange(new List<InterCasesCategory> { interCasesCategory1, interCasesCategory2 });
            await db.SaveChangesAsync();
        }

        public static async Task AddDefultSecondInterCasesCategory()
        {
          

            var متداول = await db.InterCasesCategories.Where(x => x.Name == "متداول").FirstOrDefaultAsync();
            if (متداول == null) return; 
            InterCasesCategory interCasesCategory1 = new InterCasesCategory { Name = "المعجل من الوقف", IsFather = false, UserId = userid, CreatedAt = DateTime.Now , ParentID = متداول.Id };
            db.InterCasesCategories.Add( interCasesCategory1 );
            await db.SaveChangesAsync();
        }
        public static async Task AddDefultInterCases()
        {
            var متداول = await db.InterCasesCategories.Where(x => x.Name == "متداول").FirstOrDefaultAsync();
            if (متداول == null) return;
            InterCase interCase1 = new InterCase { Name = "سابق", UserId = userid, CreatedAt = DateTime.Now, IdInterCasesCategory = متداول.Id };
            InterCase interCase2 = new InterCase { Name = "مجدد من الشطب", UserId = userid, CreatedAt = DateTime.Now, IdInterCasesCategory = متداول.Id };
            InterCase interCase3 = new InterCase { Name = "معجل من الانقضاء", UserId = userid, CreatedAt = DateTime.Now, IdInterCasesCategory = متداول.Id };
            InterCase interCase4 = new InterCase { Name = "معاد من الاستئناف", UserId = userid, CreatedAt = DateTime.Now, IdInterCasesCategory = متداول.Id };
            InterCase interCase5 = new InterCase { Name = "احالة من الدائرة", UserId = userid, CreatedAt = DateTime.Now, IdInterCasesCategory = متداول.Id };
            InterCase interCase6 = new InterCase { Name = "احالة الى الدائرة", UserId = userid, CreatedAt = DateTime.Now, IdInterCasesCategory = متداول.Id };

            var المعجل = await db.InterCasesCategories.Where(x => x.Name == "المعجل من الوقف").FirstOrDefaultAsync();
            if (المعجل == null) return;
            InterCase interCase7 = new InterCase { Name = "معجل من الوقف لحين الفصل في", UserId = userid, CreatedAt = DateTime.Now, IdInterCasesCategory = المعجل.Id };
            InterCase interCase8 = new InterCase { Name = "معجل من الوقف الجزائي", UserId = userid, CreatedAt = DateTime.Now, IdInterCasesCategory = المعجل.Id };
            InterCase interCase9 = new InterCase { Name = "معجل من الوقف التعليقي", UserId = userid, CreatedAt = DateTime.Now, IdInterCasesCategory = المعجل.Id };
            InterCase interCase10 = new InterCase { Name = "معجل من الوقف الاتفاقي", UserId = userid, CreatedAt = DateTime.Now, IdInterCasesCategory = المعجل.Id };

            
        }
        public static async Task AddDefultCaseYear()
        {
            CaseYear caseYear1 = new CaseYear { Name = "2019 وما قبلها", Year = 2019 , IsOld = true };
            CaseYear caseYear2 = new CaseYear { Name = "2020", Year = 2020 , IsOld = false };
            CaseYear caseYear3 = new CaseYear { Name = "2021", Year = 2021 , IsOld = false };
            CaseYear caseYear4 = new CaseYear { Name = "2022", Year = 2022 , IsOld = false };
            CaseYear caseYear5 = new CaseYear { Name = "2023", Year =2023  , IsOld = false };
            CaseYear caseYear6 = new CaseYear { Name = "2024", Year = 2024 , IsOld = false };
            CaseYear caseYear7 = new CaseYear { Name = "2025", Year =  2025, IsOld = false };
            db.CaseYears.AddRange(new CaseYear[] { caseYear1, caseYear2, caseYear3, caseYear4, caseYear5, caseYear6, caseYear7 });
            await db.SaveChangesAsync();

        }

        public static async Task AddDefultData()
        {
            await AddDefultCircleType();
            await AddDefultSuperCourt();
            await AddDefultSupCourt();
            await AddDefultFatherDecisionCategory();
            await AddDefultSecondDecisionCategory();
            await AddDefultDecisions();
            await AddDefultDelayCase();
            await AddDefultFatherInterCasesCategory();
            await AddDefultSecondInterCasesCategory();
            await AddDefultInterCases();
            await AddDefultCaseYear();








          
           

        }
    }
}
