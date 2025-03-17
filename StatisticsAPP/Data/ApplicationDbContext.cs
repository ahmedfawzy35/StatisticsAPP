using Microsoft.EntityFrameworkCore;
using StatisticsAPP.Models.Auth;
using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Models.CourtsModels;
using StatisticsAPP.Models.DecisionModels;
using StatisticsAPP.Models.DelayCasesModels;
using StatisticsAPP.Models.InterCasesModels;
using StatisticsAPP.Models.JudgeModels;
using StatisticsAPP.Models.StatisticsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Data
{
    public class ApplicationDbContext : DbContext
    {
       static readonly string con = Properties.Settings.Default.ConnectionString;
        //static readonly string con1 = "Server=.;Initial Catalog=StoreManageDBTest1;Trusted_Connection=Yes;TrustServerCertificate=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(con);
        }

      
        #region Auth
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        public DbSet<Operation> Operations { get; set; } = default!;
        public DbSet<UserRole> UserRoles { get; set; } = default!;
        public DbSet<RoleOperation> RoleOperations { get; set; } = default!;
        public DbSet<UserCircles> UserCircles { get; set; } = default!;
        public DbSet<UserSupCourts> UserSupCourts { get; set; } = default!;
        public DbSet<UserSuperCourts> UserSuperCourts { get; set; } = default!;

        #endregion

        #region CircleModels
        public DbSet<Circle> Circles { get; set; } = default!;
        public DbSet<CircleCategory> CircleCategories { get; set; } = default!;
        public DbSet<CircleType> CircleTypes { get; set; } = default!;
        public DbSet<CircleJudge> CircleJudges { get; set; } = default!;
        public DbSet<CircleDay> CircleDays { get; set; } = default!;

        #endregion

        #region CourtsModels
        public DbSet<SuperCourt> SuperCourts { get; set; } = default!;
        public DbSet<SupCourt> SupCourts { get; set; } = default!;
        #endregion

        #region DecisionModels
        public DbSet<DecisionCategory> DecisionCategories { get; set; } = default!;
        public DbSet<Decision> Decisions { get; set; } = default!;
        #endregion

        #region DelayCasesModels
        public DbSet<DelayCase> DelayCases { get; set; } = default!;

        #endregion

        #region InterCasesModels
        public DbSet<InterCasesCategory> InterCasesCategories { get; set; } = default!;
        public DbSet<InterCase> InterCases { get; set; } = default!;
        public DbSet<Shortening> Shortenings { get; set; } = default!;
        #endregion

        #region JudgeModels
        public DbSet<Judge> Judges { get; set; } = default!;

        #endregion

        #region StatisticsModels
        public DbSet<CircleStatistics> CircleStatistics { get; set; } = default!;
        public DbSet<StatisticsDecisions> StatisticsDecisions { get; set; } = default!;
        public DbSet<StatisticsInterCases> StatisticsInterCases { get; set; } = default!;
        public DbSet<StatisticsDelayCases> StatisticsDelayCases { get; set; } = default!;
        public DbSet<DelayCacesForMonth> DelayCacesForMonths { get; set; } = default!;
        public DbSet<CaseYear> CaseYears { get; set; } = default!;

        #endregion






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Auth
            #region اضافة البيانات الافتراضية 
            // إضافة مستخدم افتراضي "مدير النظام"
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FullName = "مدير النظام" , UserName = "admin", Password = "ADMIN"  , Enable = true  ,CreatedBy = 0 }
            );
            // إضافة مستخدم افتراضي "مدير النظام"
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, UserId =1, IdRole = 1, UserCreatedId = 1  }
            );
            // إضافة دور "مدير النظام"
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "مدير النظام", Code = "ADMIN"  , UserId = 1},
                new Role { Id = 2, Name = "قاضٍ", Code = "JUDGE",  UserId = 1 }
            );

            // إضافة عمليات (إجراءات) للنظام
            modelBuilder.Entity<Operation>().HasData(
                new Operation { Id = 1, Name = "إضافة مستخدم", Code = "ADD_USER", UserId = 1 },
                new Operation { Id = 2, Name = "تعديل مستخدم", Code = "EDIT_USER", UserId = 1 },
                new Operation { Id = 3, Name = "حذف مستخدم", Code = "DELETE_USER", UserId = 1 }
            );

            // تعيين الصلاحيات لدور "مدير النظام"
            modelBuilder.Entity<RoleOperation>().HasData(
                new RoleOperation { Id = 1, IdRole = 1, IdOperation = 1, UserId = 1 },
                new RoleOperation { Id = 2, IdRole = 1, IdOperation = 2, UserId = 1 },
                new RoleOperation { Id = 3, IdRole = 1, IdOperation = 3, UserId = 1 }
            );

            #endregion
            #region اعداد العلاقات
            // إعداد العلاقة بين User و UserRole
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.IdRole)
                .OnDelete(DeleteBehavior.NoAction);

            // إعداد العلاقة بين Role و RoleOperation
            modelBuilder.Entity<RoleOperation>()
                .HasOne(ro => ro.Role)
                .WithMany(r => r.RoleOperations)
                .HasForeignKey(ro => ro.IdRole)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RoleOperation>()
                .HasOne(ro => ro.Operation)
                .WithMany(o => o.RoleOperations)
                .HasForeignKey(ro => ro.IdOperation)
                .OnDelete(DeleteBehavior.NoAction);

            // إضافة فهرس فريد لمنع تكرار نفس الدور للمستخدم أكثر من مرة
            modelBuilder.Entity<UserRole>()
                .HasIndex(ur => new { ur.UserId, ur.IdRole })
                .IsUnique();

            // إضافة فهرس فريد لمنع تكرار نفس الصلاحية لنفس الدور أكثر من مرة
            modelBuilder.Entity<RoleOperation>()
                .HasIndex(ro => new { ro.IdRole, ro.IdOperation })
                .IsUnique();
            #endregion
            #endregion

            // علاقات الإحصائيات مع القضايا والأحكام
            modelBuilder.Entity<StatisticsDecisions>()
                .HasOne(sd => sd.CircleStatistics)
                .WithMany()
                .HasForeignKey(sd => sd.IdCircleStatistics);

            modelBuilder.Entity<StatisticsDecisions>()
                .HasOne(sd => sd.Decision)
                .WithMany()
                .HasForeignKey(sd => sd.IdDecision);

            modelBuilder.Entity<StatisticsInterCases>()
                .HasOne(si => si.CircleStatistics)
                .WithMany()
                .HasForeignKey(si => si.IdCircleStatistics);

            modelBuilder.Entity<StatisticsDelayCases>()
                .HasOne(sd => sd.CircleStatistics)
                .WithMany()
                .HasForeignKey(sd => sd.IdCircleStatistics);

            // علاقة القضاة مع الدوائر
            modelBuilder.Entity<CircleJudge>()
                .HasOne(cj => cj.Circle)
                .WithMany()
                .HasForeignKey(cj => cj.IdCircle);

            modelBuilder.Entity<CircleJudge>()
                .HasOne(cj => cj.Judge)
                .WithMany()
                .HasForeignKey(cj => cj.IdJudge);

            // علاقات المستخدمين والصلاحيات
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany()
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany()
                .HasForeignKey(ur => ur.IdRole);

            modelBuilder.Entity<RoleOperation>()
                .HasOne(ro => ro.Role)
                .WithMany()
                .HasForeignKey(ro => ro.IdRole);

            modelBuilder.Entity<RoleOperation>()
                .HasOne(ro => ro.Operation)
                .WithMany()
                .HasForeignKey(ro => ro.IdOperation);

           

            // 🔹 منع تكرار اسم القاضي
            modelBuilder.Entity<Judge>()
                .HasIndex(j => j.Name)
                .IsUnique();

            // 🔹 منع تكرار اسم المستخدم أو الاسم الكامل
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.FullName)
                .IsUnique();

            // 🔹 منع تكرار اسم الصلاحية
            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            // 🔹 منع تكرار اسم الإجراء
            modelBuilder.Entity<Operation>()
                .HasIndex(o => o.Name)
                .IsUnique();

            // 🔹 إدارة العلاقة بين القضاة والفترات الزمنية بحيث لا يحدث تداخل
            modelBuilder.Entity<CircleJudge>()
                .HasOne(cj => cj.Circle)
                .WithMany()
                .HasForeignKey(cj => cj.IdCircle);

            modelBuilder.Entity<CircleJudge>()
                .HasOne(cj => cj.Judge)
                .WithMany()
                .HasForeignKey(cj => cj.IdJudge);

            modelBuilder.Entity<CircleJudge>()
                .HasIndex(cj => new { cj.IdJudge, cj.IdCircle, cj.DateStart, cj.DateEnd })
                .IsUnique(); // 🔹 يمنع تداخل الفترات الزمنية عند تعيين القضاة في الدوائر

          


        }
    }

}
