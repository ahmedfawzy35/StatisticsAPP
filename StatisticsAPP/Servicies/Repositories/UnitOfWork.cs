using StatisticsAPP.Data;
using StatisticsAPP.Models.Auth;
using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Models.CourtsModels;
using StatisticsAPP.Models.DecisionModels;
using StatisticsAPP.Models.DelayCasesModels;
using StatisticsAPP.Models.InterCasesModels;
using StatisticsAPP.Models.JudgeModels;
using StatisticsAPP.Models.StatisticsModels;
using StatisticsAPP.Servicies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace StatisticsAPP.Servicies.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public static event Action DataUpdated; // الحدث اللي هيبلغ الفورمات بالتحديث

        public IBaseRepository<User> User { get; private set; }

        public IBaseRepository<Operation> Operation { get; private set; }

        public IBaseRepository<Role> Role { get; private set; }

        public IBaseRepository<RoleOperation> RoleOperation { get; private set; }

        public IBaseRepository<UserCircles> UserCircles { get; private set; }

        public IBaseRepository<UserRole> UserRole { get; private set; }

        public IBaseRepository<UserSupCourts> UserSupCourts { get; private set; }

        public IBaseRepository<UserSuperCourts> UserSuperCourts { get; private set; }

        public IBaseRepository<Circle> Circle { get; private set; }

        public IBaseRepository<CircleJudge> CircleJudge { get; private set; }

        public IBaseRepository<CircleType> CircleType { get; private set; }
        public IBaseRepository<CircleDay> CircleDays { get; private set; }

        public IBaseRepository<SupCourt> SupCourt { get; private set; }

        public IBaseRepository<SuperCourt> SuperCourt { get; private set; }

        public IBaseRepository<Decision> Decision { get; private set; }

        public IBaseRepository<DecisionCategory> DecisionCategory { get; private set; }

        public IBaseRepository<DelayCase> DelayCase { get; private set; }


        public IBaseRepository<InterCase> InterCase { get; private set; }
        public IBaseRepository<Shortening> Shortening { get; private set; }

        public IBaseRepository<InterCasesCategory> InterCasesCategory { get; private set; }

        public IBaseRepository<Judge> Judge { get; private set; }

        public IBaseRepository<CircleStatistics> CircleStatistics { get; private set; }

        public IBaseRepository<StatisticsDecisions> StatisticsDecisions { get; private set; }

        public IBaseRepository<StatisticsDelayCases> StatisticsDelayCases { get; private set; }

        public IBaseRepository<StatisticsInterCases> StatisticsInterCases { get; private set; }


        public IBaseRepository<DelayCacesForMonth> DelayCacesForMonths { get; private set; }
        public IBaseRepository<CaseYear> CaseYears { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            User = new BaseRepository<User>(_context);
            Operation = new BaseRepository<Operation>(_context);
            Role = new BaseRepository<Role>(_context);
            RoleOperation = new BaseRepository<RoleOperation>(_context);
            UserCircles = new BaseRepository<UserCircles>(_context);
            UserRole = new BaseRepository<UserRole>(_context);
            UserSupCourts = new BaseRepository<UserSupCourts>(_context);
            UserSuperCourts = new BaseRepository<UserSuperCourts>(_context);
            Circle = new BaseRepository<Circle>(_context);
            CircleJudge = new BaseRepository<CircleJudge>(_context);
            CircleType = new BaseRepository<CircleType>(_context);
            CircleDays = new BaseRepository<CircleDay>(_context);
            SupCourt = new BaseRepository<SupCourt>(_context);
            SuperCourt = new BaseRepository<SuperCourt>(_context);
            Decision = new BaseRepository<Decision>(_context);
            DecisionCategory = new BaseRepository<DecisionCategory>(_context);
            DelayCase = new BaseRepository<DelayCase>(_context);
            InterCase = new BaseRepository<InterCase>(_context);
            Shortening = new BaseRepository<Shortening>(_context);
            InterCasesCategory = new BaseRepository<InterCasesCategory>(_context);
            Judge = new BaseRepository<Judge>(_context);
            CircleStatistics = new BaseRepository<CircleStatistics>(_context);
            StatisticsDecisions = new BaseRepository<StatisticsDecisions>(_context);
            StatisticsDelayCases = new BaseRepository<StatisticsDelayCases>(_context);
            StatisticsInterCases = new BaseRepository<StatisticsInterCases>(_context);
            DelayCacesForMonths = new BaseRepository<DelayCacesForMonth>(_context);
            CaseYears = new BaseRepository<CaseYear>(_context);
            
           
        }

        public string Save()
        {
            try
            {
                int result = _context.SaveChanges();
                DataUpdated?.Invoke();
                return result == 1 ? "تم الحفظ بنجاح" : "فشل في حفظ البيانات  ";
            }
            catch (Exception x)
            {

                return   $"فشل في حفظ البيانات  {x.Message} ";
            }
          
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
