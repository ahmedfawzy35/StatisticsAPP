using StatisticsAPP.Data;
using StatisticsAPP.Models.Auth;
using StatisticsAPP.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Servicies.AuthServicies.UserServicies
{
    public  class UserManager
    {
        private readonly ApplicationDbContext _context;
        private string _ModelCode =MyStrings.ModulsName.GetModulesCode( MyStrings.ModulsName.User);
        private string _ModelName = MyStrings.ModulsName.User;

        public UserManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User item)
        {
            if (MyCervicies.checkPermissionsManager.CheckPermission(_ModelName, MyTypes.PermissionsType.Create).Permission)
            {
                try
                {


                    if (item != null)
                    {

                      await  _context.Users.AddAsync(item);
                      await  _context.SaveChangesAsync();

                        MessageBox.Show(MyStrings.AddSucsessMessage);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(MyStrings.AddFaildMessage + " " + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(MyStrings.UnPermissionMessage(MyStrings.PermessionCreate, _ModelName));
            }


        }
        public void  Add(User item)
        {
            if (MyCervicies.checkPermissionsManager.CheckPermission(_ModelName, MyTypes.PermissionsType.Create).Permission)
            {
                try
                {


                    if (item != null)
                    {

                         _context.Users.Add(item);
                         _context.SaveChanges();

                        MessageBox.Show(MyStrings.AddSucsessMessage);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(MyStrings.AddFaildMessage + " " + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show(MyStrings.UnPermissionMessage(MyStrings.PermessionCreate, _ModelName));
            }


        }
    }
}
