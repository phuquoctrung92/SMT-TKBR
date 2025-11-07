using SmtLib;
using SmtLib.DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TKBR_TB.Classes;

namespace TKBR_TB
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var p = Process.GetProcessesByName(Application.ProductName);
            if (p.Length > 1)
            {
                MessageBox.Show("既にクライアントシステムが起動されています。", Constants.SYSTEM_NAME, MessageBoxButtons.OK);
                return;
            }
            clsLogger.Info("Begin windows application.");
            clsLogger.InfoFormat("MachineName {0}, UserName {1}", Environment.MachineName, Environment.UserName);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            XmlMessageLib.SetXmlMessage();
            SQLServer.Instance.UpdateConnectionString(clsCommon.ConnectionString());
            Application.Run(new frmMain());
        }
    }
}
