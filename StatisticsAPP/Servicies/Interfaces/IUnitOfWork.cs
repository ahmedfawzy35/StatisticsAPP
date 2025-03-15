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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace StatisticsAPP.Servicies.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IBaseRepository<Operation> Operation { get; }
        IBaseRepository<Role> Role { get; }
        IBaseRepository<RoleOperation> RoleOperation { get; }
        IBaseRepository<User> User { get; }
        IBaseRepository<UserCircles> UserCircles { get; }
        IBaseRepository<UserRole> UserRole { get; }
        IBaseRepository<UserSupCourts> UserSupCourts { get; }
        IBaseRepository<UserSuperCourts> UserSuperCourts { get; }
        IBaseRepository<Circle> Circle { get; }
        IBaseRepository<CircleJudge> CircleJudge { get; }
        IBaseRepository<CircleType> CircleType { get; }
        IBaseRepository<CircleDay> CircleDays { get; }

        IBaseRepository<SupCourt> SupCourt { get; }
        IBaseRepository<SuperCourt> SuperCourt { get; }
        IBaseRepository<Decision> Decision { get; }
        IBaseRepository<DecisionCategory> DecisionCategory { get; }
        IBaseRepository<DelayCase> DelayCase { get; }
        IBaseRepository<InterCase> InterCase { get; }
        IBaseRepository<Shortening> Shortening { get; }
        IBaseRepository<InterCasesCategory> InterCasesCategory { get; }
        IBaseRepository<Judge> Judge { get; }
        IBaseRepository<CircleStatistics> CircleStatistics { get; }
        IBaseRepository<StatisticsDecisions> StatisticsDecisions { get; }
        IBaseRepository<StatisticsDelayCases> StatisticsDelayCases { get; }
        IBaseRepository<StatisticsInterCases> StatisticsInterCases { get; }
        IBaseRepository<DelayCacesForMonth> DelayCacesForMonths { get; }
        IBaseRepository<CaseYear> CaseYears{ get; }
        



      

        #region cash in

     

        #endregion
        #region cash out

       

        #endregion
       

        #region money safe
    
        #endregion
      

        #region employee
       

        #endregion
        string Save();
    }
}
