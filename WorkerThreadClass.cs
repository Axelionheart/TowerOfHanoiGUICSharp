using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TowerOfHanoiUI.TowerOfHanoiForm;

namespace TowerOfHanoiUI
{
    public class WorkerThreadClass 
    {
        Thread m_workerThread;
        EventWaitHandle m_waitHandle = new AutoResetEvent(false);
        readonly object m_locker = new object();
        Queue<IFormController> m_tasks = new Queue<IFormController>();

        public WorkerThreadClass()
        {
            m_workerThread = new Thread(Work);
            m_workerThread.Start();
        }
        public void EnqueueTask(IFormController controller)
        {
            lock (m_locker)
                m_tasks.Enqueue(controller);
            m_waitHandle.Set();
        }

        public void ReleaseWorkerThread()
        {
            EnqueueTask(null);     
            m_workerThread.Join();         
            m_waitHandle.Close();          
        }

        void Work()
        {
            while (true)
            {
                IFormController task = null;
                lock (m_locker)
                {
                    if (m_tasks.Count > 0)
                    {
                        task = m_tasks.Dequeue();
                        if (task == null) return;
                    }
                }                    
                if (task != null)
                {
                    task.InitiateSolution();
                    task.DrawBoardOnForm();
                }
                else
                    m_waitHandle.WaitOne();        
            }
        }
    }
}
