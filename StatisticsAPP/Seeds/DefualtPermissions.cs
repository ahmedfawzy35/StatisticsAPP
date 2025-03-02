using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using StatisticsAPP.Data;
using StatisticsAPP.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StatisticsAPP.Seeds.Permissions;

namespace StatisticsAPP.Seeds
{
    public static class DefualtPermissions
    {
        public static readonly ApplicationDbContext db = new ApplicationDbContext();
        public static async Task AddDefualtOperations()
        {
            var allOperationsFromDataBase = db.Operations.ToList();
            var allPermission = Permissions.GenrateAllPermissionsList();
            List<Operation> addOperations = new List<Operation>();
            foreach (OperationTexts item in allPermission)
            {
               

                if (!allOperationsFromDataBase.Any(X => X.Code == item.Code))
                    {
                    addOperations.Add(new Operation { Name = item.Name , Code = item.Code , UserId = 1 });
                    }

            }
            await db.Operations.AddRangeAsync(addOperations);

            await db.SaveChangesAsync();

        }

        public  static async Task AddDefualtToRoleOperation()
        {
            var role = await db.Roles.Where(x => x.Id == 1).FirstOrDefaultAsync();
            if (role != null)
            {
                var allOperations = await db.Operations.ToListAsync();
                var allRoleOperations = await db.RoleOperations.ToListAsync();
                List< RoleOperation> AddRoleOperation = new List<RoleOperation>();
                foreach (var item in allOperations)
                {
                    if (!allRoleOperations.Any(x=>x.IdRole == role.Id && x.IdOperation == item.Id))
                    {
                        AddRoleOperation.Add(new RoleOperation { IdOperation = item.Id, IdRole = role.Id, UserId = 1 });

                    }
                }

                await db.RoleOperations.AddRangeAsync(AddRoleOperation);
                await db.SaveChangesAsync();
            }


        }

        public static async Task AddDefualtSuperCourt()
        {
            var adminUser = await db.Users.Where(x=>x.UserName == "admin").FirstOrDefaultAsync();
            if (adminUser != null) return;
            var allSuperCourts = await db.SuperCourts.ToListAsync();
            if (allSuperCourts.Count < 1) return;
            var allUserSuperCourts = await db.UserSuperCourts.ToListAsync();
            List<UserSuperCourts> adds = new List<UserSuperCourts>();
            foreach (var superCourt in allSuperCourts)
            {
                if (!allUserSuperCourts.Any(x=>x.IdSuperCourt == superCourt.Id))
                {
                    adds.Add(new UserSuperCourts {IdUser = adminUser!.Id  , IdSuperCourt = superCourt.Id , User = adminUser });

                }
            }
            await db.AddRangeAsync(adds);
            await db.SaveChangesAsync();
        }
        public static async Task AddDefualtSupCourt()
        {
            var adminUser = await db.Users.Where(x => x.UserName == "admin").FirstOrDefaultAsync();
            if (adminUser != null) return;
            var allSupCourts = await db.SupCourts.ToListAsync();
            if (allSupCourts.Count < 1) return;
            
            var allUserSupCourts = await db.UserSupCourts.ToListAsync();
            List<UserSupCourts> adds = new List<UserSupCourts>();
            foreach (var supCourt in allSupCourts)
            {
                if (!allUserSupCourts.Any(x => x.IdSupCourt == supCourt.Id))
                {
                    adds.Add(new UserSupCourts { IdUser = adminUser!.Id, IdSupCourt = supCourt.Id, User = adminUser });

                }
            }
            await db.AddRangeAsync(adds);
            await db.SaveChangesAsync();
        }
    }
}
