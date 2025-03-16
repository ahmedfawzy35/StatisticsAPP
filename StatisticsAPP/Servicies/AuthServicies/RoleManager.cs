using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using StatisticsAPP.Data;
using StatisticsAPP.Models.Auth;
using StatisticsAPP.Models.CourtsModels;
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

        public List<SuperCourt> GetUserSuperCourts(int idUser )
        {

            var usersc= _context.UserSuperCourts.Include(x=>x.SuperCourt).Where(x=>x.IdUser == idUser).ToList();
            if (usersc.Count ==0)
            {
                return new List<SuperCourt>();
            }
            List<SuperCourt> superCourts = new List<SuperCourt>();
            foreach (var item in usersc)
            {
                if (item.SuperCourt == null)
                {
                    MessageBox.Show("");
                    
                }
                superCourts.Add(item.SuperCourt!);
            }

            return superCourts;
        }
        public List<SupCourt> GetUserSupCourts(int idUser)
        {

            var usersc = _context.UserSupCourts.Include(x => x.SupCourt).Where(x => x.IdUser == idUser).ToList();
            if (usersc.Count == 0)
            {
                return new List<SupCourt>();
            }
            List<SupCourt> supCourts = new List<SupCourt>();
            foreach (var item in usersc)
            {
                supCourts.Add(item.SupCourt!);
            }

            return supCourts;
        }
    }
}
