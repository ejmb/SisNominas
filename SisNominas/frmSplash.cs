using Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisNominas_Clases;
using SplashScreen;

namespace SisNominas
{
    public partial class frmSplash : SplashForm
    {
        private static Thread _splashThread;
        private static frmSplash _splashForm;

        public frmSplash()
        {
            InitializeComponent();
            
        }

        public static void ShowSplash()
        {
            if (_splashThread == null)
            {
                // show the form in a new thread
                _splashThread = new Thread(new ThreadStart(DoShowSplash));
                _splashThread.IsBackground = true;
                _splashThread.Start();
            }
        }

        private static void DoShowSplash()
        {
            if (_splashForm == null)
                _splashForm = new frmSplash();

            // create a new message pump on this thread (started from ShowSplash)
            Application.Run(_splashForm);
        }

        public static void CloseSplash()
        {
            // need to call on the thread that launched this splash
            if (_splashForm.InvokeRequired)
                _splashForm.Invoke(new MethodInvoker(CloseSplash));

            else
                Application.ExitThread();
        }
    }
}
