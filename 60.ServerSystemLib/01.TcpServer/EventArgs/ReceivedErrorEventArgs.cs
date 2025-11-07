using System;

namespace ServerSystemLib
{
    public class ReceivedErrorEventArgs : EventArgs
    {
        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
        }

        public ReceivedErrorEventArgs(string msg)
        {
            this._errorMessage = msg;
        }
    }
}
