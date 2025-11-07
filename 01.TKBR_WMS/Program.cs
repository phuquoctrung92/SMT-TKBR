using CtrlLib;
using SmtLib;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using SmtLib.DataBaseObjects;
using TKBR_Lib.Forms;
using TKBR_Lib.Classes;

namespace TKBR_WMS
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var p = Process.GetProcessesByName(Application.ProductName);
            if(p.Length > 1)
            {
                MessageBox.Show("既にクライアントシステムが起動されています。", Constants.SYSTEM_NAME, MessageBoxButtons.OK);
                return;
            }
            clsLogger.Info("Begin windows application.");
            clsLogger.InfoFormat("MachineName {0}, UserName {1}", Environment.MachineName, Environment.UserName);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                XmlMessageLib.SetXmlMessage();
                SQLServer.Instance.UpdateConnectionString(clsCommon.ConnectionString());
                 var frmMain = new frmMainMenu();
                Application.Run(frmMain);
            }
            catch(Exception ex)
            {
                ClsMsgBox.ShowMessage(Constants.SYSTEM_NAME, "E999", ex);
            }
            finally
            {
                clsLogger.Info("end windows application.");
            }
        }
    }
}
