using SmtLib;
using System;
using System.Windows.Forms;
using System.Diagnostics;
using SmtLib.DataBaseObjects;
using System.Threading;
using ServerSystemLib;
using System.Linq;

namespace TKBR_SV
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            clsLogger.Debug("begin windows application.");
            //二重起動をチェックする
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                //すでに起動していると判断して終了
                MessageBox.Show("多重起動はできません。\r\n確認して下さい", "HT･SV連携");
                clsLogger.Debug("二重起動が発生");
                return;
            }

            try
            {
                SQLServer.Instance.UpdateConnectionString(clsCommon.ConnectionString());
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                clsLogger.Info("end windows application.");
            }
        }
    }
}
