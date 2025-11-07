using System;

namespace ServerSystemLib
{
    /// <summary>
    /// 送信データの取得
    /// </summary>
    public class SendDataEventArgs : EventArgs
    {
        private string _sendString;
        public string SendString
        {
            get
            {
                return this._sendString;
            }
        }

        private TcpKrdServer _server;
        public TcpKrdServer Server
        {
            get
            {
                return _server;
            }
        }

        public SendDataEventArgs(TcpKrdServer svr, string s)
        {
            this._server = svr;
            this._sendString = s;
        }
    }
}
