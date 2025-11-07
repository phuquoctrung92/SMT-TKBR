using CtrlLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TKBR_TB.Classes;

namespace TKBR_TB
{
    public partial class frmMain : MainForm
    {
        public frmMain()
        {
            InitializeComponent();
            Initialize("TB", Constants.SYSTEM_NAME);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                StringBuilder nohinSaki = new StringBuilder();
                nohinSaki.AppendLine("ABC-MART");
                nohinSaki.AppendLine("ABCNETMART");
                nohinSaki.AppendLine("小山企業株式会社");

                //左側レーン情報初期表示
                pnlLane1.Controls.Clear();
                pnlLane1.Controls.Add(new UC.ucLane(nohinSaki.ToString(), 321, 1001, false) );


                //右側レーン情報初期表示
                pnlLane2.Controls.Clear();
                pnlLane2.Controls.Add(new UC.ucLane(nohinSaki.ToString(), 1001, 1001, true) { Dock = DockStyle.Fill });
            }
            catch (Exception ex)
            {
                ClsMsgBox.ShowMessage(this.Text, "E999", ex);
                this.Close();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // 閉じるボタンの処理
            if (ClsMsgBox.ShowMessage("終了", "Q999", "終了しますか？") == DialogResult.Yes)
            {
                Close();
            }
        }

    }
}
