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
                StringBuilder sb = new StringBuilder();

                //左側レーン情報初期表示
                pnlLane1_Info.Controls.Clear();
                pnlLane1_Footer.Controls.Clear();
                sb.AppendLine("ABC-MART");
                sb.AppendLine("ABCNETMART");
                sb.AppendLine("小山企業株式会社");
                pnlLane1_Info.Controls.Add(new UC.ucInfo(nohinSaki: sb.ToString(), zansu: 680) { Dock = DockStyle.Fill });
                pnlLane1_Footer.Controls.Add(new UC.ucProgress("321 / 1001") { Dock = DockStyle.Fill });

                //右側レーン情報初期表示
                pnlLane2_Info.Controls.Clear();
                pnlLane2_Footer.Controls.Clear();
                pnlLane2_Info.Controls.Add(new UC.ucInfo(nohinSaki: sb.ToString(), zansu: 0) { Dock = DockStyle.Fill });
                pnlLane2_Footer.Controls.Add(new UC.ucProgress("321 / 1001") { Dock = DockStyle.Fill });
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
