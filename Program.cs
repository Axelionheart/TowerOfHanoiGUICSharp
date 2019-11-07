using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TowerOfHanoiUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WorkerThreadClass workerThread = new WorkerThreadClass();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TowerOfHanoiForm(workerThread));
            workerThread.ReleaseWorkerThread();
        }
    }
}
