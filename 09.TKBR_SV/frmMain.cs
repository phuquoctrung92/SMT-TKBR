using SmtLib;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ServerSystemLib;

namespace TKBR_SV
{
    public partial class frmMain : Form
    {
        private Boolean START_FLAG = false;
        private bool loadSw = false;
        private TcpKrdServer tcpServer;
        /// <summary>
        /// 排他制御オブジェクト
        /// </summary>
        private readonly object objLockObject;

        /// <summary>
        /// enum:TCPステータス
        /// </summary>
        private enum TcpStatus
        {
            /// <summary>
            /// 状態：接続
            /// </summary>
            Connect,
            /// <summary>
            /// 状態：受信
            /// </summary>
            Receive,
            /// <summary>
            /// 状態：送信
            /// </summary>
            Send,
            /// <summary>
            /// 状態：切断
            /// </summary>
            DisConnect,
            /// <summary>
            /// 状態：エラー
            /// </summary>
            Error
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            tcpServer = new TcpKrdServer();

            // イベントの追加
            tcpServer.Connected += TcpServer_Connected;
            tcpServer.Disconnected += TcpServer_Disconnected;
            tcpServer.ReceivedData += TcpServer_ReceivedData;
            tcpServer.SendData += TcpServer_SendData;
            tcpServer.ErrorOccurs += TcpServer_ErrorOccurs;
            tcpServer.ServerConnectInfo += TcpServer_ServerConnectInfo;

            var assembly = Assembly.GetExecutingAssembly().GetName();
            var ver = assembly.Version;

            this.Text = this.Text + $"　Ver.{ver.Major}.{ver.Minor}.{ver.Build}";

            // 排他制御オブジェクト作成
            this.objLockObject = new object();

            // ポート番号設定
            this.txtPort.Text = xmlSystem.TCPIP_Port;
            this.txtPort.ReadOnly = true;

            // IPアドレス設定
            this.txtIpAddress.Text = string.Empty;
            this.txtIpAddress.ReadOnly = true;

            // 開始ボタンの設定
            this.btnTcpip.Enabled = true;
            this.btnTcpip.Text = "開始";

            // 終了ボタンの設定
            this.btnEnd.Enabled = false;

            // クリアボタンの設定
            this.btnLogClear.Enabled = false;

            // ログ表示設定
            if (xmlSystem.TCPIP_LogDisplay.Equals(ConstKrsv.LOG_DISPLAY))
            {
                this.tlpMain.RowStyles[0] = new RowStyle(SizeType.Percent, 100F);
                this.tlpMain.RowStyles[1] = new RowStyle(SizeType.AutoSize);
            }

        }

        /// <summary>
        /// TCPServer状態イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpServer_ServerConnectInfo(object sender, ServerConnectEventArgs e)
        {
            string ipAddress = e.Server.ClientIpAddress;
            string msg = string.Empty;
            //if (e.ServerState == ServerState.Listening)
            //{
            //    msg = ipAddress + " -> 接続を開始しました";
            //    AddLog(msg, Color.White, TcpStatus.Connect);

            //    // リストビュー更新
            //    this.UpdateListView(bhtSNo, ipAddress, e.Server.ClientPortNo.ToString(), TcpStatus.Connect);
            //}
            //else if(e.ServerState == ServerState.Stopped)
            //{
            //    msg = ipAddress + " <- 接続を終了しました";
            //    AddLog(msg, Color.White, TcpStatus.DisConnect);

            //    // リストビュー更新
            //    this.UpdateListView(bhtSNo, ipAddress, e.Server.ClientPortNo.ToString(), TcpStatus.DisConnect);
            //}
        }

        /// <summary>
        /// TCPServer送信イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpServer_SendData(object sender, SendDataEventArgs e)
        {
            string sndMsg = e.SendString.Replace("\r\n", "");
            string bhtSNo = e.Server.BHTSNo;
            string msg = bhtSNo + " <- " + sndMsg;
            AddLog(msg, Color.White, TcpStatus.Send);

            // リストビュー更新
            this.UpdateListView(bhtSNo, e.Server.ClientPortNo.ToString(), TcpStatus.Send);
        }
        /// <summary>
        /// TCPServerエラー発生イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpServer_ErrorOccurs(object sender, SendDataEventArgs e)
        {
            string sndMsg = e.SendString.Replace("\r\n", "");
            string msg = "送り状発行 -> " + e.SendString;
            AddLog(msg, Color.Red, TcpStatus.Error);
        }

        /// <summary>
        /// TCPServer受信イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpServer_ReceivedData(object sender, ReceivedDataEventArgs e)
        {
            string rcvMsg = e.ReceivedString.Replace("\r\n", "");
            string bhtSNo = e.Server.BHTSNo;
            string msg = bhtSNo + " -> " + rcvMsg;
            AddLog(msg, Color.White, TcpStatus.Receive);

            // リストビュー更新
            this.UpdateListView(bhtSNo, e.Server.ClientPortNo.ToString(), TcpStatus.Receive);
        }

        /// <summary>
        /// Listener終了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpServer_Disconnected(object sender, EventArgs e)
        {
            AddLog("Listenerを閉じました。",
                Color.Red, TcpStatus.DisConnect);
        }

        /// <summary>
        /// Listener開始イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TcpServer_Connected(object sender, EventArgs e)
        {
            AddLog("Listenerを開始しました。",
                Color.White, TcpStatus.Connect);
        }

        // デリゲート
        private delegate void PrintStringInvoker(string str, Color col, TcpStatus tcpStatus);

        // *---------------------------------------------------------------------------------------------------*

        /// <summary>
        /// ログに文字列を一行追加する
        /// </summary>
        /// <param name="str"></param>
        /// <param name="col"></param>
        /// <param name="tcpStatus"></param>
        private void AddLog(string str, Color col, TcpStatus tcpStatus)
        {

            if (!this.loadSw)
                return;

            if (this.InvokeRequired)
            {
                this.Invoke(new PrintStringInvoker(PrivateAddLog),
                    new object[] { str, col, tcpStatus });
            }
            else
            {
                this.PrivateAddLog(str, col, tcpStatus);
            }
        }

        /// <summary>
        /// ログ更新
        /// </summary>
        /// <param name="str"></param>
        /// <param name="col"></param>
        /// <param name="cmd"></param>
        private void PrivateAddLog(string str, Color col, TcpStatus tcpStatus)
        {
            string addText = DateTime.Now.ToString("HH:mm:ss") + " : " + str + "\n";

            if (!this.loadSw)
                return;

            //MaxLengthを超えて表示されるとき
            if (txtLog.TextLength + addText.Length > txtLog.MaxLength)
            {
                int delLen = txtLog.TextLength + addText.Length - txtLog.MaxLength;
                delLen = txtLog.Text.IndexOf('\n', delLen) + 1;
                txtLog.Select(0, delLen);
                txtLog.SelectedText = "";
            }

            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.SelectionLength = 0;
            txtLog.SelectionColor = col;
            txtLog.AppendText(addText);
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.Focus();
            txtLog.ScrollToCaret();

            string stsMsg = string.Empty;
            switch (tcpStatus)
            {
                case TcpStatus.Connect:
                    stsMsg = "接続 :";
                    break;
                case TcpStatus.DisConnect:
                    stsMsg = "切断 :";
                    break;
                case TcpStatus.Receive:
                    stsMsg = "受信 :";
                    break;
                case TcpStatus.Send:
                    stsMsg = "送信 :";
                    break;
            }

            clsLogger.InfoFormat("{0}{1}", stsMsg, str);

        }

        /// <summary>
        /// リストビュー更新
        /// </summary>
        /// <param name="strBHTSNo"></param>
        /// <param name="strPortNo"></param>
        /// <param name="objTcpStatus"></param>
        private void UpdateListView(string strBHTSNo, string strPortNo, TcpStatus objTcpStatus)
        {
            // 排他制御実施
            lock (this.objLockObject)
            {
                // Invokeが必要か確認
                if (this.InvokeRequired == true)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        this._updateListView(strBHTSNo, strPortNo, objTcpStatus);
                    });
                }
                else
                {
                    this._updateListView(strBHTSNo, strPortNo, objTcpStatus);
                }
            }
        }

        /// <summary>
        /// リストビュー更新の内部関数(直接呼び出さないこと)
        /// </summary>
        /// <param name="strBHTSNo"></param>
        /// <param name="strPortNo"></param>
        /// <param name="objTcpStatus"></param>
        private void _updateListView(string strBHTSNo, string strPortNo, TcpStatus objTcpStatus)
        {
            ListViewItem objItem = null;
            string val = string.Empty;
            string strSysDt = System.DateTime.Now.ToString("yyyy/MM/dd");
            string strChlDt = string.Empty;
            DateTime chkDt;

            for (int i = 0; i < this.lsvTag.Items.Count; i++)
            {
                // 同シリアル番号
                if (this.lsvTag.Items[i].SubItems[this.columnSerialNo.Index].Text == strBHTSNo)
                {
                    objItem = this.lsvTag.Items[i];
                    break;
                }
            }

            switch (objTcpStatus)
            {
                case TcpStatus.Connect:
                    if (objItem != null)
                    {
                        // 削除
                        //objItem.Remove();
                    }
                    else
                    {
                        // 追加
                        string[] objAddItem = { strBHTSNo, "0", "0", "接続", "" };
                        this.lsvTag.Items.Add(new ListViewItem(objAddItem));
                    }
                    break;

                case TcpStatus.Receive:
                    if (objItem != null)
                    {
                        // 受信回数+1
                        int rcvCnt = ClsConvert.ToInteger(objItem.SubItems[this.columnHeaderReceive.Index].Text) + 1;
                        chkDt = ClsConvert.ToDate(objItem.SubItems[this.columnHeaderTime.Index].Text);
                        strChlDt = chkDt.ToString("yyyy/MM/dd");
                        if (ClsConvert.ToDateExact(strChlDt, "yyyy/MM/dd") != ClsConvert.ToDateExact(strSysDt, "yyyy/MM/dd"))
                        {
                            rcvCnt = 1;
                        }
                        val = ClsConvert.RightB("        " + rcvCnt.ToString("#,##0"), 8);
                        objItem.SubItems[this.columnHeaderReceive.Index].Text = val;
                    }
                    else
                    {
                        // 追加
                        string[] objAddItem = { strBHTSNo, "       1", "       0", "接続", "" };
                        this.lsvTag.Items.Add(new ListViewItem(objAddItem));
                    }
                    break;

                case TcpStatus.Send:
                    if (objItem != null)
                    {
                        int rcvCnt = ClsConvert.ToInteger(objItem.SubItems[this.columnHeaderReceive.Index].Text);
                        // 送信回数+1
                        int sndCnt = rcvCnt == 1 ? 1 : ClsConvert.ToInteger(objItem.SubItems[this.columnHeaderSend.Index].Text) + 1;
                        val = ClsConvert.RightB("        " + sndCnt.ToString("#,##0"), 8);
                        objItem.SubItems[this.columnHeaderSend.Index].Text = val;
                    }
                    else
                    {
                        // 追加
                        string[] objAddItem = { strBHTSNo, "       0", "       1", "接続", "" };
                        this.lsvTag.Items.Add(new ListViewItem(objAddItem));
                    }
                    break;

                case TcpStatus.DisConnect:
                    if (objItem != null)
                    {
                        // 状態更新:切断
                        objItem.SubItems[this.columnHeaderStatus.Index].Text = "切断";
                    }
                    break;
            }

            if (objItem != null)
            {
                // 時刻更新
                objItem.SubItems[this.columnHeaderTime.Index].Text = System.DateTime.Now.ToString();
            }
        }

        // *---------------------------------------------------------------------------------------------------*

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Location = new Point(0, 0);
                loadSw = true;
                clsLogger.InfoFormat("{0}", this.Name);
                btnTcpip.PerformClick();
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex);
            }
        }

        /// <summary>
        /// フォームクロージング
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgRet = MessageBox.Show("HT/SV連携を終了します\r\nよろしいでしょうか？", this.Text
                , MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (dlgRet.Equals(DialogResult.No))
            {
                e.Cancel = true;
                return;
            }
            if(tcpServer != null)
            {
                tcpServer.TcpServerStop();
            }
            loadSw = false;
        }

        /// <summary>
        /// 終了ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ログクリアボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogClear_Click(object sender, EventArgs e)
        {
            this.txtLog.Clear();
        }

        /// <summary>
        /// 通信開始ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTcpip_Click(object sender, EventArgs e)
        {
            if (START_FLAG)
            {
                this.btnEnd.Enabled = true;
                this.btnLogClear.Enabled = true;
                this.txtPort.ReadOnly = false;
                tcpServer.TcpServerStop();

                this.btnTcpip.Text = "開始";
                this.txtIpAddress.Text = string.Empty;
                START_FLAG = false;
            }
            else
            {
                this.btnEnd.Enabled = false;
                this.btnLogClear.Enabled = false;
                this.txtPort.ReadOnly = true;
                tcpServer.TcpServerStart(this.txtPort.Text);

                this.btnTcpip.Text = "停止";
                this.txtIpAddress.Text = tcpServer.ServerIpAddress;
                START_FLAG = true;
            }
        }

        /// <summary>
        /// テスト実行
        /// </summary>
        private void btn_recvTest_Click(object sender, EventArgs e)
        {
            // HT00,000001,,C,LOGIN,1,1

            string rcvMsg = txt_recvTest.Text;

            rcvMsg = rcvMsg.Replace(',', '\x1A');

            string bhtSNo = "RCTEST";
            string msg = bhtSNo + " -> " + rcvMsg;
            AddLog(msg, Color.White, TcpStatus.Receive);

            this.UpdateListView(bhtSNo, "000000", TcpStatus.Receive);

            Main main = new Main();

            var result = main.Execute(rcvMsg);
            string sndMsg = result.DataKbn;
            if (result.Data.Count > 0)
            {
                sndMsg += "\x1A" + String.Join("\x1A", result.Data.ToArray());
            }
            //string bhtSNo = e.Server.BHTSNo;
            msg = bhtSNo + " <- " + sndMsg;
            AddLog(msg, Color.White, TcpStatus.Send);

            this.UpdateListView(bhtSNo, "000000", TcpStatus.Send);
        }
    }
}
