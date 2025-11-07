using SmtLib;
using System;
using System.Data.SqlTypes;
using System.Net;
using System.Net.Sockets;

namespace ServerSystemLib
{

    #region デリゲート

    /// <summary>
    /// クライアント情報を持つイベントを処理するメソッドを表す
    /// </summary>
    public delegate void ReceivedDataEventHandler(object sender, ReceivedDataEventArgs e);
    public delegate void SendDataEventHandler(object sender, SendDataEventArgs e);
    public delegate void ServerConnetHandler(object sender, ServerConnectEventArgs e);

    #endregion

    #region 列挙型

    /// <summary>
    /// サーバーの状態
    /// </summary>
    public enum ServerState
    {
        None,
        Listening,
        Stopped
    }

    #endregion

    public class TcpKrdServer : IDisposable
    {
        static object lcObject = new object();                      // ロック用オブジェクト

        private TcpListener tcpListener;
        // *---------------------------------------------------------------------------------------------------*

        #region イベント

        /// <summary>
        /// データの受信
        /// </summary>
        public event ReceivedDataEventHandler ReceivedData;
        protected virtual void OnReceivedData(ReceivedDataEventArgs e)
        {
            if (this.ReceivedData != null)
            {
                this.ReceivedData(this, e);
            }
        }

        /// <summary>
        /// データの送信
        /// </summary>
        public event SendDataEventHandler SendData;
        protected virtual void OnSendData(SendDataEventArgs e)
        {
            if (this.SendData != null)
            {
                this.SendData(this, e);
            }
        }

        /// <summary>
        /// サーバーの状態
        /// </summary>
        public event ServerConnetHandler ServerConnectInfo;
        protected virtual void OnServerConnectInfo(ServerConnectEventArgs e)
        {
            if (this.ServerConnectInfo != null)
            {
                this.ServerConnectInfo(this, e);
            }
        }

        /// <summary>
        /// サーバーの開始
        /// </summary>
        public event EventHandler Connected;
        protected virtual void OnConnected(EventArgs e)
        {
            if (this.Connected != null)
            {
                this.Connected(this, e);
            }
        }

        /// <summary>
        /// サーバーの停止
        /// </summary>
        public event EventHandler Disconnected;
        protected virtual void OnDisconeccted(EventArgs e)
        {
            if (this.Disconnected != null)
            {
                this.Disconnected(this, e);
            }
        }

        public event SendDataEventHandler ErrorOccurs;
        protected virtual void OnErrorOccurs(string msg)
        {
            ErrorOccurs?.Invoke(this, new SendDataEventArgs(this, msg));
        }
        #endregion

        // *---------------------------------------------------------------------------------------------------*

        #region プロパティ

        /// <summary>
        /// ログイン状態
        /// </summary>
        public ServerState ServerState { get; set; }

        private string _receivedString = "";
        /// <summary>
        /// 受信したデータの文字列
        /// </summary>
        protected string ReceivedString
        {
            get
            {
                return _receivedString;
            }
        }

        private string _retRecMessage = "";
        /// <summary>
        /// 受信メッセージ
        /// </summary>
        public string RetRecMessage
        {
            get
            {
                return _retRecMessage;
            }
            set
            {
                _retRecMessage = value;
            }
        }

        private string _bhtSNo = "";
        /// <summary>
        /// BHTシリアル番号
        /// </summary>
        public string BHTSNo
        {
            get
            {
                return _bhtSNo;
            }
            set
            {
                _bhtSNo = value;
            }
        }

        private int _retryCount = 0;
        /// <summary>
        /// 送信のリトライ回数
        /// </summary>
        public int RetryCount
        {
            get
            {
                return _retryCount;
            }
            set
            {
                _retryCount = value;
            }
        }

        private string _clientIpAddress = "";
        /// <summary>
        /// クライアントＩＰアドレス
        /// </summary>
        public string ClientIpAddress
        {
            get
            {
                return _clientIpAddress;
            }
            set
            {
                _clientIpAddress = value;
            }
        }

        private string _serverIpAddress = "";
        /// <summary>
        /// サーバーＩＰアドレス
        /// </summary>
        public string ServerIpAddress
        {
            get
            {
                return _serverIpAddress;
            }
            set
            {
                _serverIpAddress = value;
            }
        }

        private int _portNo = 0;
        /// <summary>
        /// ポート番号
        /// </summary>
        public int PortNo
        {
            get
            {
                return _portNo;
            }
            set
            {
                _portNo = value;
            }
        }

        private int _clientportNo = 0;
        /// <summary>
        /// クライアントポート番号
        /// </summary>
        public int ClientPortNo
        {
            get
            {
                return _clientportNo;
            }
            set
            {
                _clientportNo = value;
            }
        }

        private string _messageData = "";
        /// <summary>
        /// メッセージ
        /// </summary>
        public string MessageData
        {
            get
            {
                return _messageData;
            }
            set
            {
                _messageData = value;
            }
        }

        #endregion

        // *---------------------------------------------------------------------------------------------------*

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TcpKrdServer()
        {
        }
        private void ngTorikomi_onError(string err_msg)
        {
            OnErrorOccurs(err_msg);
        }
        /// <summary>
        /// 破棄する
        /// </summary>
        public virtual void Dispose()
        {
            this.Close();
        }

        /// <summary>
        /// 閉じる
        /// </summary>
        public void Close()
        {
            if (this.ServerState.Equals(ServerState.Listening))
            {
                TcpServerStop();
            }
        }

        // *---------------------------------------------------------------------------------------------------*

        /// <summary>
        /// TCPサーバー開始
        /// </summary>
        /// <param name="_port">ポート番号</param>
        /// <param name="_ipAddress">IPアドレス</param>
        public void TcpServerStart(string _port)
        {
            //ngTorikomi.Start();
            IPAddress ipAdd = IPAddress.Any;          //ListenするIPアドレス
            int port = int.Parse(_port);                                    //Listenするポート番号

            tcpListener = new TcpListener(ipAdd, port);  //TcpListenerオブジェクトを作成する
            this.ServerIpAddress = ipAdd.ToString();
            this.PortNo = port;

            //Listenを開始する
            tcpListener.Start();

            // イベントを発生
            this.OnConnected(new EventArgs());
            clsLogger.InfoFormat("Listenerを開始しました({0}:{1})。",
                ((IPEndPoint)tcpListener.LocalEndpoint).Address,
                ((IPEndPoint)tcpListener.LocalEndpoint).Port);

            tcpListener.BeginAcceptTcpClient(TcpCallBack, tcpListener);
        }

        public void TcpServerStop()
        {
            //リスナを閉じる
            tcpListener.Stop();

            // イベントを発生
            this.OnDisconeccted(new EventArgs());
            Console.WriteLine("Listenerを終了しました。");
        }

        /// <summary>
        /// TCPコールバック
        /// </summary>
        /// <param name="ar"></param>
        private void TcpCallBack(IAsyncResult ar)
        {

            TcpListener l = (TcpListener)ar.AsyncState;
            TcpClient c;

            try
            {
                //if (!l.Server.Connected) return;
                c = l.EndAcceptTcpClient(ar);

                l.BeginAcceptTcpClient(new AsyncCallback(TcpCallBack), l);  // keep listening
                lock (lcObject)
                {
                    //NetworkStreamを取得
                    NetworkStream ns = c.GetStream();

                    // エンドポイントを取得し、接続元のIPアドレスを取得
                    IPEndPoint endpoint = (IPEndPoint)c.Client.RemoteEndPoint;
                    IPAddress address = endpoint.Address;
                    int port = endpoint.Port;
                    this.ClientIpAddress = address.ToString();
                    this.ClientPortNo = port;

                    // イベントを発生
                    this.OnServerConnectInfo(new ServerConnectEventArgs(this, ServerState.Listening));

                    //読み取り、書き込みのタイムアウトを10秒にする
                    //デフォルトはInfiniteで、タイムアウトしない
                    //(.NET Framework 2.0以上が必要)
                    ns.ReadTimeout = ConstKrsv.TCP_READ_TIMEOUT;
                    ns.WriteTimeout = ConstKrsv.TCP_WRITE_TIMEOUT;

                    //クライアントから送られたデータを受信する
                    System.Text.Encoding enc = System.Text.Encoding.UTF8;

                    bool disconnected = false;
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    byte[] resBytes = new byte[short.MaxValue];
                    int resSize = 0;
                    do
                    {

                        //データの一部を受信する
                        resSize = ns.Read(resBytes, 0, resBytes.Length);
                        //Readが0を返した時はクライアントが切断したと判断
                        if (resSize == 0)
                        {
                            disconnected = true;
                            clsLogger.Info("クライアントが切断しました。");
                            // イベント発生
                            this.OnDisconeccted(new EventArgs());
                            this.OnServerConnectInfo(new ServerConnectEventArgs(this, ServerState.Stopped));
                            break;
                        }
                        //受信したデータを蓄積する
                        ms.Write(resBytes, 0, resSize);
                        //まだ読み取れるデータがあるか、データの最後が\nでない時は、
                        System.Threading.Thread.Sleep(IniSVSetting.Config_Recv_Delay);
                        // 受信を続ける
                    } while (ns.DataAvailable);
                    //受信したデータを文字列に変換

                    ms.Close();

                    HtReceiveData rcvData = new HtReceiveData();
                    string resMsg = "";
                    HtSendData sendData = rcvData.SetData(ms.ToArray(), ref resMsg);
                    BHTSNo = rcvData.BHTSNo;
                    if (rcvData.File != null && rcvData.File.Length > 0)
                    {
                        resMsg += $"{ConstKrsv.SEPARATOR_Data}[ファイル]";
                    }

                    // イベント発生
                    this.OnReceivedData(new ReceivedDataEventArgs(this, resMsg));
                    clsLogger.Info(resMsg);
                    // ShowReceivedString(resMsg);

                    if (!disconnected)
                    {
                        Main M = new Main();

                        //クライアントにデータを送信する
                        //クライアントに送信する文字列を作成
                        var result = M.Execute(rcvData, sendData);
                        string sendMsg = result.DataKbn;
                        if (result.Data.Count > 0)
                        {
                            sendMsg += ConstKrsv.SEPARATOR_Data + string.Join(ConstKrsv.SEPARATOR_Data, result.Data.ToArray());
                            if (result.File != null && result.File.Length > 0)
                            {
                                sendMsg += ConstKrsv.SEPARATOR_File;
                            }
                        }
                        //文字列をByte型配列に変換
                        byte[] sendMsgBytes = enc.GetBytes(sendMsg);
                        byte[] sendBytes;
                        if (result.File != null && result.File.Length > 0)
                        {
                            sendMsg += $"{ConstKrsv.SEPARATOR_Data}[ファイル]";
                            sendBytes = new byte[sendMsgBytes.Length + result.File.Length];
                            Buffer.BlockCopy(sendMsgBytes, 0, sendBytes, 0, sendMsgBytes.Length);
                            Buffer.BlockCopy(result.File, 0, sendBytes, sendMsgBytes.Length, result.File.Length);
                        }
                        else
                        {
                            sendBytes = sendMsgBytes;
                        }
                        //データを送信する
                        ns.Write(sendBytes, 0, sendBytes.Length);
                        // イベントを発生
                        OnSendData(new SendDataEventArgs(this, sendMsg));
                        clsLogger.Info(sendMsg);
                    }

                    //閉じる
                    ns.Close();
                    c.Close();

                    // イベントを発生
                    this.OnServerConnectInfo(new ServerConnectEventArgs(this, ServerState.Stopped));

                    clsLogger.Info("クライアントとの接続を閉じました。");
                }
            }
            catch (Exception ex)
            {
                clsLogger.Error(ex.Message);
            }
        }
    }
}
