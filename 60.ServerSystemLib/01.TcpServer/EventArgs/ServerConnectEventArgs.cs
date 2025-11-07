using System;

namespace ServerSystemLib
{
    /// <summary>
    /// 接続状態の取得
    /// </summary>
    public class ServerConnectEventArgs : EventArgs
    {
        private ServerState _serverState;
        public ServerState ServerState
        {
            get
            {
                return this._serverState;
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

        public ServerConnectEventArgs(TcpKrdServer svr, ServerState ss)
        {
            this._server = svr;
            this._serverState = ss;
        }
    }
}
