using StatisticsAPP.Servicies.StatisticsCervicies.DTOS;
using StatisticsAPP.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatisticsAPP.Forms.StatisticsForms
{
    public partial class StatisticsAddForm: Form
    {
        public StatisticsFormConfig? _Config { get; set; }

        public StatisticsAddForm(StatisticsFormConfig Config)
        {
            InitializeComponent();
            _Config = Config;
            AddStatisticsUserControl statisticsAddUserControl = new AddStatisticsUserControl { Config = _Config };
            statisticsAddUserControl.Dock = DockStyle.Top;
            panel2.Controls.Clear();
            panel2.Controls.Add(statisticsAddUserControl);

        }
    }
}
