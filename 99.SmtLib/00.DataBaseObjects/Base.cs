using System;
using System.Diagnostics;

namespace SmtLib.DataBaseObjects
{
    /// <summary>
    /// データベースのベース
    /// </summary>
    public abstract class Base : IDisposable
    {

        #region Variable Value

        private bool m_disposed_value = false;

        private int m_last_code;
        private object[] m_last_args;

        #endregion

        #region Property
        /// <summary> オブジェクトに設定された エラー コードを取得します。 </summary>
        public int LastErrorCode
        {
            [DebuggerStepThrough()]
            get
            {
                return m_last_code;
            }
        }

        /// <summary> エラーコードに関連付けられている メッセージを取得します。 </summary>
        public string LastErrorMessage
        {
            [DebuggerStepThrough()]
            get
            {
                return FormatMessage.Create(m_last_code, m_last_args);
            }
        }
        #endregion

        #region Constructor

        /// <summary>初期設定</summary>
        protected Base()
        {
            m_last_code = 0;
            m_last_args = null;
        }

        #endregion

        #region Implements Method
        /// <summary>コントロールを廃棄</summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed_value)
            {
                if (disposing)
                {
                }
            }
            m_disposed_value = true;
        }

        /// <summary>このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。</summary>
        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(ByVal disposing As Boolean) に記述します。
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Method

        /// <summary> オブジェクトに設定されている エラー情報をクリアします。 </summary>
        [DebuggerStepThrough()]
        public void ClearLastError()
        {
            m_last_code = 0;
            m_last_args = null;
        }

        /// <summary>エラー状態の最後にセット</summary>
        /// <param name="_code">エラーコード</param>
        [DebuggerStepThrough()]
        protected void SetLastError(int _code)
        {
            m_last_code = _code;
            m_last_args = null;
        }

        /// <summary>エラー状態の最後にセット</summary>
        /// <param name="_code">エラーコード</param>
        /// <param name="_args">引数</param>
        [DebuggerStepThrough()]
        protected void SetLastError(int _code, params object[] _args)
        {
            m_last_code = _code;
            m_last_args = _args;
        }
        #endregion
    }

}