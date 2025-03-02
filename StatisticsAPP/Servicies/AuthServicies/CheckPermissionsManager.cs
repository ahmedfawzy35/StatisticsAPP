using StatisticsAPP.Models.Auth;
using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Seeds;
using StatisticsAPP.Servicies.AuthServicies.DTOS;
using StatisticsAPP.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using static StatisticsAPP.Seeds.Permissions;
using static StatisticsAPP.Utility.MyTypes;

namespace StatisticsAPP.Servicies.AuthServicies
{
    public class CheckPermissionsManager
    {
        private readonly List<Operation> _userPermission;


        public CheckPermissionsManager(List<Operation> userPermission)
        {
            _userPermission = userPermission;
        }

        public CheckPermissionsDto CheckPermission(string model, PermissionsType type)
        {
           
            var modulesoperationTexts = MyStrings.ModulsName.ModulesoperationTexts().ToList();
            var modelCode = modulesoperationTexts.Where(x => x.Name == model).FirstOrDefault();
            if (modelCode == null)
            {
                return new CheckPermissionsDto
                {
                    Permission =false,
                    Message = $"{MyStrings.UnPermission} {MyStrings.PermessionView} {model}"
                };
            }
            switch (type)
            {
                case PermissionsType.None:
                    break;
                case PermissionsType.View:
                    return new CheckPermissionsDto
                    {
                        Permission = _userPermission.Any(x => x.Code == Permissions.View(model , modelCode.Code).Code),
                        Message = $"{MyStrings.UnPermission} {MyStrings.PermessionView} {model}"
                    };

                case PermissionsType.Create:
                    return new CheckPermissionsDto
                    {
                        Permission = _userPermission.Any(x => x.Code == Permissions.Creat(model, modelCode.Code).Code),
                        Message = $"{MyStrings.UnPermission} {MyStrings.PermessionCreate} {model}"
                    };

                case PermissionsType.Edit:
                    return new CheckPermissionsDto
                    {
                        Permission = _userPermission.Any(x => x.Code == Permissions.Edit(model, modelCode.Code).Code),
                        Message = $"{MyStrings.UnPermission} {MyStrings.PermessionEdit} {model}"
                    };
                case PermissionsType.Delete:
                    return new CheckPermissionsDto
                    {
                        Permission = _userPermission.Any(x => x.Code == Permissions.Delete(model, modelCode.Code).Code),
                        Message = $"{MyStrings.UnPermission}  {MyStrings.PermessionDelete} {model}"
                    };
                default:
                    return new CheckPermissionsDto
                    {
                        Permission = _userPermission.Any(x => x.Code == Permissions.View(model, modelCode.Code).Code),
                        Message = $"{MyStrings.UnPermission} {MyStrings.PermessionView} {model}"
                    };

            }
            return new CheckPermissionsDto
            {
                Permission = _userPermission.Any(x => x.Name == Permissions.View(model, modelCode.Code).Code),
                Message = $"{MyStrings.UnPermission} {MyStrings.PermessionView} {model}"
            };


        }
        public CheckPermissionsDto CheckPermissionByCode(string code, PermissionsType type)
        {
           
            switch (type)
            {
                case PermissionsType.None:
                    break;
                case PermissionsType.View:
                    return new CheckPermissionsDto
                    {
                        Permission = _userPermission.Any(x => x.Code == Permissions.View(code, code).Code),
                        Message = $"{MyStrings.UnPermission} {MyStrings.PermessionView} {code}"
                    };

                case PermissionsType.Create:
                    return new CheckPermissionsDto
                    {
                        Permission = _userPermission.Any(x => x.Code == Permissions.Creat(code, code).Code),
                        Message = $"{MyStrings.UnPermission} {MyStrings.PermessionCreate} {code}"
                    };

                case PermissionsType.Edit:
                    return new CheckPermissionsDto
                    {
                        Permission = _userPermission.Any(x => x.Code == Permissions.Edit(code, code).Code),
                        Message = $"{MyStrings.UnPermission} {MyStrings.PermessionEdit} {code}"
                    };
                case PermissionsType.Delete:
                    return new CheckPermissionsDto
                    {
                        Permission = _userPermission.Any(x => x.Code == Permissions.Delete(code, code).Code),
                        Message = $"{MyStrings.UnPermission}  {MyStrings.PermessionDelete} {code}"
                    };
                default:
                    return new CheckPermissionsDto
                    {
                        Permission = _userPermission.Any(x => x.Code == Permissions.View(code, code).Code),
                        Message = $"{MyStrings.UnPermission} {MyStrings.PermessionView} {code}"
                    };

            }
            return new CheckPermissionsDto
            {
                Permission = _userPermission.Any(x => x.Name == Permissions.View(code, code).Code),
                Message = $"{MyStrings.UnPermission} {MyStrings.PermessionView} {code}"
            };


        }

        public bool CheckAnyModelPermission(string model)
        {
            var modelCode = MyStrings.ModulsName.ModulesoperationTexts().ToList().Where(x => x.Name == model).FirstOrDefault();
            if (modelCode == null)
            {
              return  false;
            }
            bool result = false;
            foreach (var climeName in Permissions.GenrateModulePermissionsList(model , modelCode.Code))
            {
                if (_userPermission.Any(x => x.Code == climeName.Code))
                {
                    result = true; break;
                }
            }


            return result;
        }

        public bool CheckAnyModelPermissionMulty(List<string> model)
        {

            bool result = false;
            foreach (var item in model)
            {
                var modelCode = MyStrings.ModulsName.ModulesoperationTexts().ToList().Where(x => x.Name == item).FirstOrDefault();

                foreach (var climeName in Permissions.GenrateModulePermissionsList(item , modelCode!.Code))
                {
                    if (_userPermission.Any(x => x.Code == climeName.Code))
                    {
                        result = true; break;
                    }
                }
                if (result)
                {
                    break;
                }
            }
            return result;
        }
    }
}
