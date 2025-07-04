﻿using StatisticsAPP.Models.CircleModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsAPP.Models.StatisticsModels
{
    public class Sapek
    {
        public int Id { get; set; }
        public int IdCircleStatistics { get; set; }
        public int IdCircleDay { get; set; }
        public int IdCaseYear { get; set; }

        public int Count { get; set; }

     
        public CaseYear? CaseYear { get; set; }
        public DelayCacesForMonthType? DelayCacesForMonthType { get; set; }

        [ForeignKey("IdCircleDay")]
        public CircleDay? CircleDay { get; set; }
        [ForeignKey("IdCircleStatistics")]
        public CircleStatistics? CircleStatistics { get; set; }
    }
}
