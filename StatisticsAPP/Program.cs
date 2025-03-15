using Microsoft.EntityFrameworkCore.Internal;
using StatisticsAPP.Data;
using StatisticsAPP.Forms.MainForm;
using StatisticsAPP.Servicies.Repositories;

namespace StatisticsAPP
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
        
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.SetDefaultFont(new Font(new FontFamily("Cairo"), 8.25f));
            ApplicationConfiguration.Initialize();
            UnitOfWork.DataUpdated += () => DbContextFactory.RefreshContext();
            Application.Run(new MainForm());
        }
    }
}