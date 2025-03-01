using Microsoft.EntityFrameworkCore;
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
    }
}
