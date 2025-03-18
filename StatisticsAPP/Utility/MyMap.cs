using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Servicies.Repositories.CircleRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Utility
{
   public static class MyMap
    {
        public static List< CircleDayDTO> MapToCircleDayDTO(List< CircleDay> circleDay)
        {
            List<CircleDayDTO> circleDayDTOs = new List<CircleDayDTO>();
            foreach (var circleDayDTO in circleDay )
            {
                circleDayDTOs.Add(new CircleDayDTO
                {
                 
                Id = circleDayDTO.Id,
                Name = circleDayDTO.Name,
                Day = circleDayDTO.Day,
                CircleTypeName = circleDayDTO.CircleType != null ? circleDayDTO.CircleType.Name : null,
                CircleName = circleDayDTO.Circle != null ? circleDayDTO.Circle.Name : null,
                SupCourteName = circleDayDTO.Circle != null && circleDayDTO.Circle.SupCourt != null
                                ? circleDayDTO.Circle.SupCourt.Name : null
           
                });
            }
            return circleDayDTOs;
        }


    }
}
