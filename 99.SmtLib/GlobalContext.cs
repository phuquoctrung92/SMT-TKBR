
// GlobalContext.vb - 99.SmtLib
// 

using System;
using System.Diagnostics;

namespace SmtLib
{
    /// <summary>GlobalContextの共通機能</summary>
    public sealed class GlobalContext
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private static log4net.ILog _LogLogger = log4net.LogManager.GetLogger("LogLogger");

        /// <summary>
        /// 規定の Logger を使用して ログ出力を行います。
        /// </summary>
        internal static log4net.ILog Log
        {
            [DebuggerStepThrough()]
            get
            {
                return _LogLogger;    // sealed variable.
            }
        }

        /// <summary>ログを設置</summary>
        /// <param name="log"></param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [DebuggerStepThrough()]
        public static void SetLog(log4net.ILog log)
        {
            if (log is null)
            {
                throw new ArgumentNullException("log");
            }
            _LogLogger = log;
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private static log4net.ILog _SQLLogger = log4net.LogManager.GetLogger("SQLLogger");

        /// <summary>別途ログ出力を行い 既定の Logger とは異なる意味合いを持たせます。</summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static log4net.ILog SQLLog
        {
            [DebuggerStepThrough()]
            get
            {
                return _SQLLogger;    // sealed variable.
            }
        }

        /// <summary>SQLログを設置</summary>
        /// <param name="log"></param>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [DebuggerStepThrough()]
        public static void SetSQLLog(log4net.ILog log)
        {
            if (log is null)
            {
                throw new ArgumentNullException("log");
            }
            _SQLLogger = log;
        }
    }
}