using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace eqPretender
{
    static class Program
    {
        static string mutexId = "StellartechScienceEqPretender";

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, mutexId, out bool createdNew))
            {
                if (!createdNew)
                {
                    Console.WriteLine("Application is already running.");
                    return; // 
                }
                Console.WriteLine("Running application...");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new eqPretenderScreen());
            }
        }
    }
}
