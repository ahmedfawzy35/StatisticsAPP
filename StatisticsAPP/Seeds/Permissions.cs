using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StatisticsAPP.Utility.MyStrings;
namespace StatisticsAPP.Seeds
{
    public class Permissions
    {

        public static List<OperationTexts> GenrateModulePermissionsList(string module , string modelCode)
        {
            return new List<OperationTexts>()
            {
              new OperationTexts{Name =   $"{ PermessionType}.{PermessionView}.{module}", Code =  $"{PermessionView_Code}{modelCode.ToUpper()}" },
              new OperationTexts{Name =   $"{ PermessionType}.{PermessionCreate}.{module}", Code =  $"{PermessionCreate_Code}{modelCode.ToUpper()}" },
              new OperationTexts{Name =   $"{ PermessionType}.{PermessionEdit}.{module}", Code =  $"{PermessionEdit_Code}{modelCode.ToUpper()}" },
              new OperationTexts{Name =   $"{ PermessionType}.{PermessionDelete}.{module}", Code =  $"{PermessionDelete_Code}{modelCode.ToUpper()}" }

                
            };
        }
        public static List<OperationTexts> GenrateAllPermissionsList()
        {
            List<OperationTexts> list = new List<OperationTexts>();

            foreach (var model in ModulsName.ModulesoperationTexts())
            {
                list.AddRange(GenrateModulePermissionsList(model.Name , model.Code));
            }

            return list;

        }

        #region ارجاع وظيفه واحده لكل مديول
        public static OperationTexts View(string module , string moduleCode)
        {
            return new OperationTexts { Name = $"{PermessionType}.{PermessionView}.{module}", Code = $"{PermessionView_Code}{moduleCode.ToUpper()}" };
        }
        public static OperationTexts Creat(string module ,string moduleCode)
        {
            return new OperationTexts { Name = $"{PermessionType}.{PermessionCreate}.{module}", Code = $"{PermessionCreate_Code}{moduleCode.ToUpper()}" };
        }
        public static OperationTexts Edit(string module, string moduleCode)
        {
            return new OperationTexts { Name = $"{PermessionType}.{PermessionEdit}.{module}", Code = $"{PermessionEdit_Code}{moduleCode.ToUpper()}" };
        }
        public static OperationTexts Delete(string module, string moduleCode)
        {
            return new OperationTexts { Name = $"{PermessionType}.{PermessionDelete}.{module}", Code = $"{PermessionDelete_Code}{moduleCode.ToUpper()}" };
        }
        #endregion


        public class OperationTexts
        {
            public required string Name { get; set; }  
            public required string Code { get; set; } 
        }
    }
}
