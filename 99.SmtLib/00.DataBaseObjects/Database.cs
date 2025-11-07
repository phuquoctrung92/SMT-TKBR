using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using static SmtLib.FormatMessage;

namespace SmtLib.DataBaseObjects
{
    /// <summary>
    /// データベース
    /// </summary>
    public abstract class Database : Base
    {
        #region Variable Value

        private bool m_disposed_value = false;
        /// <summary>データベース接続</summary>
        protected System.Data.Common.DbConnection m_connection;
        /// <summary>接続文字列</summary>
        protected string m_connection_string;
        /// <summary>接続タイムアウト</summary>
        protected int m_connection_timeout;
        /// <summary>データベース種別</summary>
        protected DataSourceTypes m_dataSourceType;
        /// <summary>トランザクション</summary>
        protected System.Data.Common.DbTransaction m_transaction;
        /// <summary>クエリ実行タイムアウト</summary>
        protected int m_command_timeout;

        #endregion

        #region Enumerated type

        /// <summary>データベース種別</summary>
        public enum DataSourceTypes : int
        {
            /// <summary>未定義</summary>
            None = 0,
            /// <summary>MS Access</summary>
            Access = 1,
            /// <summary>MS SQLServer</summary>
            SQLServer = 2,
            /// <summary>PostgreSQL</summary>
            PostgreSQL = 3,
            /// <summary>SQLServerCompact</summary>
            SQLServerCompact = 4,
            /// <summary>未定義</summary>
            Unknown = -1
        }

        #endregion

        #region Property
        /// <summary>接続文字列</summary>
        public virtual string ConnectionString
        {
            [DebuggerStepThrough()]
            get
            {
                if (m_connection_string is null)
                {
                    return string.Empty;
                }
                else
                {
                    return m_connection_string;
                }
            }
        }
        /// <summary>接続タイムアウト</summary>
        public virtual int ConnectionTimeout
        {
            [DebuggerStepThrough()]
            get
            {
                return m_connection_timeout;
            }
        }
        /// <summary>クエリ実行タイムアウト</summary>
        public virtual int CommandTimeout
        {
            [DebuggerStepThrough()]
            get
            {
                return m_command_timeout;
            }
            [DebuggerStepThrough()]
            set
            {
                if (value < 0)
                {
                    // command timeout value out of range error.
                    m_command_timeout = 0;
                }
                else
                {
                    m_command_timeout = value;
                }
            }
        }
        /// <summary>接続状況</summary>
        /// <remarks>True：接続中、False：未接続</remarks>
        public virtual bool ExistsConnection
        {
            [DebuggerStepThrough()]
            get
            {
                if (m_connection is null)
                    return false;
                switch (m_connection.State)
                {
                    case ConnectionState.Closed:
                        {
                            return false;
                        }
                    case ConnectionState.Open:
                        {
                            return true;
                        }

                    default:
                        {
                            return false;
                        }
                }
            }
        }
        /// <summary>トランザクション状況</summary>
        /// <remarks>True：トランザクション中、False：未トランザクション</remarks>
        public virtual bool ExistsTransaction
        {
            [DebuggerStepThrough()]
            get
            {
                return m_transaction is not null;
            }
        }

        #endregion

        #region Constructor
        /// <summary>初期設定</summary>
        protected Database()
        {
            m_connection = null;
            m_connection_string = null;
            m_connection_timeout = 15;
            m_dataSourceType = DataSourceTypes.None;
            m_transaction = null;
            m_command_timeout = 600;
        }

        #endregion

        #region Overrides Method
        /// <summary>取消</summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {

            if (!m_disposed_value)
            {
                if (disposing)
                {
                    if (m_transaction is not null)
                    {
                        m_transaction.Dispose();
                        m_transaction = null;
                    }
                    if (m_connection is not null)
                    {
                        m_connection.Dispose();
                        m_connection = null;
                    }
                    m_transaction = null;
                    m_connection = null;
                }
            }
            m_disposed_value = true;

            base.Dispose(disposing);

        }
        /// <summary>デバッグログを出力</summary>
        /// <param name="pCommand">クエリ＋パラメータ</param>
        protected virtual void OutPutDebugSQLLog(System.Data.Common.DbCommand pCommand)
        {

            GlobalContext.SQLLog.Debug(CommandToDebugSQL(pCommand));

        }

          /// <summary>デバッグログを出力</summary>
        /// <param name="pCommand">クエリ＋パラメータ</param>
        protected virtual void OutPutErrorSQLLog(System.Data.Common.DbCommand pCommand)
        {

            GlobalContext.SQLLog.Error(CommandToDebugSQL(pCommand));

        }

        /// <summary>デバッグ用のクエリに変換</summary>
        /// <param name="pCommand">クエリ＋パラメータ</param>
        /// <returns>テキストクエリ</returns>
        protected virtual string CommandToDebugSQL(System.Data.Common.DbCommand pCommand)
        {
            var list = new List<string>();
            string s;

            if (pCommand is null)
            {
                list.Add("command is null.");
            }
            else
            {

                list.Add("");

                // command text.
                list.Add(pCommand.CommandText);

                // parameters.
                foreach (System.Data.Common.DbParameter param in pCommand.Parameters)
                {

                    if (param.Value is null)
                    {
                        // not set.
                        s = string.Format("{0}", param.ParameterName);
                    }
                    else if (ReferenceEquals(param.Value, DBNull.Value))
                    {
                        // null.
                        s = string.Format("{0} IS NULL", param.ParameterName);
                    }
                    else if (param.Value is DateTime)
                    {
                        // date value.
                        DateTime dt = (DateTime)param.Value;
                        if (0 != dt.Millisecond)
                        {
                            s = string.Format("{0} = '{1:yyyy/M/d H:mm:ss.fff}'", param.ParameterName, dt);
                        }
                        else if (0 != dt.Hour + dt.Minute + dt.Second)
                        {
                            s = string.Format("{0} = '{1:yyyy/M/d H:mm:ss}'", param.ParameterName, dt);
                        }
                        else
                        {
                            s = string.Format("{0} = '{1:yyyy/M/d}'", param.ParameterName, dt);
                        }
                    }
                    else if (param.Value is string)
                    {
                        // string value.
                        s = string.Format("{0} = '{1}'", param.ParameterName, (string)param.Value);
                    }
                    else if (param.Value.GetType().IsValueType)
                    {
                        s = string.Format("{0} = {1}", param.ParameterName, param.Value);
                    }
                    else
                    {
                        s = string.Format("{0} = {{{1}}}", param.ParameterName, param.Value.GetType());
                    }

                    s = s + "  " + param.DbType.ToString();
                    list.Add(s);
                }

                list.Add("");

            }
            return string.Join(Microsoft.VisualBasic.Constants.vbCrLf, list);
        }
        #endregion

        #region Method
        /// <summary>接続文字列の更新</summary>
        /// <param name="connStr"></param>
        public void UpdateConnectionString(string connStr)
        {
            m_connection_string = connStr;
        }
        /// <summary>データベースをオーペン</summary>
        /// <param name="connectionString">接続文字列</param>
        /// <returns>Results</returns>
        public virtual int Open(string connectionString)
        {

            SetLastError((int)Results.E_NotImplemented, "Open");
            return LastErrorCode;

        }
        /// <summary>データベースをオーペン</summary>
        /// <returns>Results</returns>
        public int Open()
        {
            return Open(m_connection_string);
        }

        /// <summary>データベースをクローズ</summary>
        /// <returns>Results</returns>
        [DebuggerStepThrough()]
        public virtual int Close()
        {

            // release.
            if (m_transaction is not null)
            {
                m_transaction.Rollback();
                m_transaction.Dispose();
                m_transaction = null;
            }
            if (m_connection is not null)
            {
                switch (m_connection.State)
                {
                    case ConnectionState.Closed:
                        {
                            break;
                        }
                    case ConnectionState.Open:
                        {
                            m_connection.Close();
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }
                m_connection.Dispose();
                m_connection = null;
            }

            m_dataSourceType = DataSourceTypes.None;

            return (int)Results.S_OK;
        }

        /// <summary>トランザクションを開始</summary>
        /// <returns>Results</returns>
        [DebuggerStepThrough()]
        public virtual int BeginTransaction()
        {

            // Me.SetLastError(Results.E_NotImplemented, "BeginTransaction")
            // Return Me.LastErrorCode

            // validate parameters.
            if (m_connection is null)
            {
                SetLastError((int)Results.E_ConnectionNotOpen);
                return LastErrorCode;
            }
            else
            {
                switch (m_connection.State)
                {
                    case ConnectionState.Closed:
                        {
                            SetLastError((int)Results.E_ConnectionNotOpen);
                            return LastErrorCode;
                        }
                    case ConnectionState.Open:
                        {
                            break;
                        }

                    default:
                        {
                            SetLastError((int)Results.E_ConnectionNotOpen);
                            return LastErrorCode;
                        }
                }
            }
            if (m_transaction is not null)
            {
                SetLastError((int)Results.E_ActiveConnections);
                return LastErrorCode;
            }

            try
            {
                m_transaction = m_connection.BeginTransaction();
            }

            catch (InvalidOperationException ex)
            {
                // 並列トランザクションはサポートされていません。

                SetLastError((int)Results.E_BeginTransactionFailed, ex);
                return LastErrorCode;

            }

            return (int)Results.S_OK;

        }
        /// <summary>トランザクションを開始</summary>
        /// <returns>Results</returns>
        [DebuggerStepThrough()]
        public virtual int BeginTransaction(IsolationLevel isolationLevel)
        {

            // Me.SetLastError(Results.E_NotImplemented, "BeginTransaction")
            // Return Me.LastErrorCode

            // validate parameters.
            if (m_connection is null)
            {
                SetLastError((int)Results.E_ConnectionNotOpen);
                return LastErrorCode;
            }
            switch (m_connection.State)
            {
                case ConnectionState.Closed:
                    {
                        SetLastError((int)Results.E_ConnectionNotOpen);
                        return LastErrorCode;
                    }
                case ConnectionState.Open:
                    {
                        break;
                    }

                default:
                    {
                        SetLastError((int)Results.E_ConnectionNotOpen);
                        return LastErrorCode;
                    }
            }
            if (m_transaction is not null)
            {
                SetLastError((int)Results.E_ActiveTransactions);
                return LastErrorCode;
            }

            try
            {
                m_transaction = m_connection.BeginTransaction(isolationLevel);
            }

            catch (InvalidOperationException ex)
            {
                // 並列トランザクションはサポートされていません。

                SetLastError((int)Results.E_BeginTransactionFailed, ex, isolationLevel);
                return LastErrorCode;

            }

            return (int)Results.S_OK;

        }

        /// <summary>コミットを開始</summary>
        /// <returns>Results</returns>
        [DebuggerStepThrough()]
        public virtual int Commit()
        {

            // Me.SetLastError(Results.E_NotImplemented, "Commit")
            // Return Me.LastErrorCode

            // validate parameters.
            if (m_transaction is null)
            {
                SetLastError((int)Results.E_NoTransactionHasBeenStarted);
                return LastErrorCode;
            }

            try
            {
                m_transaction.Commit();
            }

            catch (InvalidOperationException ex)
            {
                // トランザクションは、既にコミットまたはロールバックされています。
                // または
                // 接続が切断されています。

                SetLastError((int)Results.E_CommitFailed, ex);
                return LastErrorCode;
            }

            catch (Exception ex)
            {
                // トランザクションのコミット中にエラーが発生しました。

                SetLastError((int)Results.E_CommitFailed, ex);
                return LastErrorCode;
            }

            finally
            {

                m_transaction.Dispose();
                m_transaction = null;
                if (m_connection != null && m_connection.State == ConnectionState.Open)
                {
                    m_connection.Close();
                }
            }

            return (int)Results.S_OK;

        }

        /// <summary>ロールバックを開始</summary>
        /// <returns>Results</returns>
        [DebuggerStepThrough()]
        public virtual int Rollback()
        {

            // Me.SetLastError(Results.E_NotImplemented, "Rollback")
            // Return Me.LastErrorCode

            // validate parameters.
            if (m_transaction is null)
            {
                SetLastError((int)Results.E_NoTransactionHasBeenStarted);
                return LastErrorCode;
            }

            try
            {
                m_transaction.Rollback();
            }

            catch (InvalidOperationException ex)
            {
                // トランザクションは、既にコミットまたはロールバックされています。
                // または
                // 接続が切断されています。

                SetLastError((int)Results.E_RollbackFailed, ex);
                return LastErrorCode;
            }

            catch (Exception ex)
            {
                // トランザクションのコミット中にエラーが発生しました。

                SetLastError((int)Results.E_RollbackFailed, ex);
                return LastErrorCode;
            }

            finally
            {

                m_transaction.Dispose();
                m_transaction = null;
                if (m_connection != null && m_connection.State == ConnectionState.Open)
                {
                    m_connection.Close();
                }
            }

            return (int)Results.S_OK;

        }

        #endregion

    }

}