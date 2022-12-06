using Department.BLL;
using Department.DAL;
using System;
using System.Windows.Forms;

namespace TestResultsBrowser
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StudentDAO studentdao = new StudentDAO();
            StudentsBL students = new StudentsBL(studentdao);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(students));
        }
    }
}
