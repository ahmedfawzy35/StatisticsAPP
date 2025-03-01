using StatisticsAPP.Data;
using StatisticsAPP.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Servicies.AuthServicies
{
    public class RoleManager
    {
        private readonly ApplicationDbContext _context;


        public RoleManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Role> GetAllROles()
        {
            return _context.Roles.ToList();
        }
        public List<RoleOperation> GetAllRoleOperations()
        {
            return _context.RoleOperations.ToList();
        }
        public List<Role> GetUserRoles(int idUser)
        {
            return (from ur in _context.UserRoles
                    join r in _context.Roles on ur.IdRole equals r.Id
                    where ur.UserId == idUser
                    select r).ToList();
        }


        public List<Operation> GetAlOperations()
        {
            return _context.Operations.ToList();
        }
        public List<Operation> GetRoleOperations(int idrole)
        {
            return (from rc in _context.RoleOperations
                    join c in _context.Operations on rc.IdOperation equals c.Id
                    where rc.IdRole == idrole
                    select c).ToList();
        }

        public List<Operation> getuserOperations(int iduser)
        {
            List<Operation> claims = new List<Operation>();
            foreach (var role in GetUserRoles(iduser))
            {
                claims.AddRange(GetRoleOperations(role.Id));
            }
            return claims;
        }

    }
}
