
using System;
using System.Windows.Forms;

namespace MuaBanSanPhamSen_BabyLotus
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //using (var context = new BanSanPhamSen())
            //{
            //    context.Database.CreateIfNotExists();
            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
