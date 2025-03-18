using StatisticsAPP.Data;
using StatisticsAPP.Models.CircleModels;
using StatisticsAPP.Servicies.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Servicies.Repositories.CircleRepos
{
    class CircleDayRepository : BaseRepository<CircleDay>
    {
        public CircleDayRepository(ApplicationDbContext context) : base(context)
        {

        }


        
    }
}
