using System;

namespace ServerSystemLib
{
    /// <summary>
    /// 受信データの取得
    /// </summary>
    public class ReceivedDataEventArgs : EventArgs
    {
        private string _receivedString;
        public string ReceivedString
        {
            get
            {
                return this._receivedString;
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

        public ReceivedDataEventArgs(TcpKrdServer svr, string s)
        {
            this._server = svr;
            this._receivedString = s;
        }
    }
}
