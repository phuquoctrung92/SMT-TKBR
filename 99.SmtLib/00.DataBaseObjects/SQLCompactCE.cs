using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Diagnostics;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.VisualBasic.CompilerServices;

using static SmtLib.FormatMessage;

namespace SmtLib.DataBaseObjects
{
    /// <summary>SQLCEデータベース</summary>
    /// <remarks>HT用のSDFファイルで</remarks>
    public class SqlCompactCE : Database
    {

        #region Constructor

        /// <summary>初期設定</summary>
        public SqlCompactCE() : base()
        {

        }

        #endregion

        #region Overrides Method
        /// <summary>データベースをオーペン</summary>
        /// <param name="connectionString">接続文字列</param>
        /// <returns></returns>
        public override int Open(string connectionString)
        {
            // validate parameters.
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
                            SetLastError((int)Results.E_ActiveConnections);
                            return LastErrorCode;
                        }

                    default:
                        {
                            SetLastError((int)Results.E_UnknownConnectionState, m_connection.State);
                            return LastErrorCode;
                        }
                }
            }

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
                }
                m_connection.Dispose();
                m_connection = null;
            }

            // create instance.
            m_connection = new SqlCeConnection();
            try
            {
                m_connection.ConnectionString = connectionString;
                m_connection.Open();
            }

            catch (InvalidOperationException ex)
            {
                // データ ソースまたはサーバーを指定せずに接続を開くことはできません。
                // または
                // 接続が既に開いています。

                SetLastError((int)Results.E_OpenFailed, connectionString, ex);
                m_connection.Dispose();
                m_connection = null;
                return LastErrorCode;
            }

            catch (System.Data.SqlClient.SqlException ex)
            {
                // 接続を開くときに、接続レベルのエラーが発生しました。Number プロパティに値 18487 または 18488 が含まれている場合は、指定したパスワードの有効期限が切れているか、またはパスワードをリセットする必要があることを示します。詳細については、ChangePassword メソッドのトピックを参照してください。

                SetLastError((int)Results.E_OpenFailed, connectionString, ex);
                m_connection.Dispose();
                m_connection = null;
                return LastErrorCode;

            }

            m_connection_string = connectionString;
            return (int)Results.S_OK;

        }

        /// <summary>データベースに切断</summary>
        /// <returns>Results</returns>
        public override int Close()
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

            m_connection_string = null;
            m_dataSourceType = DataSourceTypes.None;

            return (int)Results.S_OK;

        }

        /// <summary>トランザクションの開始</summary>
        /// <param name="iso_lationLevel">分離レベル</param>
        /// <returns>Results</returns>
        public new int BeginTransaction(IsolationLevel iso_lationLevel = IsolationLevel.ReadCommitted)
        {
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
                m_transaction = m_connection.BeginTransaction(iso_lationLevel);
            }

            catch (InvalidOperationException ex)
            {
                // 並列トランザクションはサポートされていません。

                SetLastError((int)Results.E_BeginTransactionFailed, ex, iso_lationLevel);
                return LastErrorCode;

            }

            return (int)Results.S_OK;

        }
        /// <summary>ロールバック</summary>
        /// <returns>Results</returns>
        public override int Rollback()
        {

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

            }

            return (int)Results.S_OK;

        }
        /// <summary>コミット</summary>
        /// <returns>Results</returns>
        public override int Commit()
        {

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

            }

            return (int)Results.S_OK;

        }

        #endregion

        #region Method

        /// <summary>
        /// SQLServerCompact用接続情報
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public int OpenForSQLServerCompact(string strDataSource)
        {

            string connectionString;
            int ret;

            connectionString = string.Format("Data Source='{0}'", strDataSource);

            ret = Open(connectionString);
            if (ret < 0)
            {
                return ret;
            }

            m_dataSourceType = DataSourceTypes.SQLServerCompact;

            return ret;

        }

        /// <summary>クエリからコマンドを作成</summary>
        /// <param name="_query">クエリ</param>
        /// <returns></returns>
        public SqlCeCommand CreateCommand(string _query)
        {
            SqlCeCommand command;

            if (m_connection is null)
            {
                command = new SqlCeCommand();
            }
            else
            {
                command = ((SqlCeConnection)m_connection).CreateCommand();
                command.Transaction = (SqlCeTransaction)m_transaction;
            }

            command.CommandText = _query;
            command.CommandTimeout = 0; // m_command_timeout SQLServerCompactは0らしい

            return command;

        }

        /// <summary>パラメータを作成</summary>
        /// <param name="_command"></param>
        /// <param name="_name"></param>
        /// <param name="_value"></param>
        /// <returns></returns>
        public SqlCeParameter CreateParameter(SqlCeCommand _command, string _name, object _value)
        {
            SqlCeParameter parameter;

            if (_command is null)
            {
                parameter = new SqlCeParameter(_name, _value);
            }
            else
            {
                parameter = _command.CreateParameter();
                parameter.ParameterName = _name;
                parameter.Value = _value;
            }

            //switch (m_dataSourceType)
            //{

            //}

            return parameter;
        }

        /// <summary>ExecuteNonQueryで実行</summary>
        /// <param name="_command">コマンド</param>
        /// <returns></returns>
        public int ExecuteNonQuery(SqlCeCommand _command)
        {
            int ret;

            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If DEBUG Then
            */
            if (_command is null)
            {
                SetLastError((int)Results.E_ArgumentNull, "command");
                return default;
            }
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            try
            {
                ClearLastError();
                ret = _command.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // ロックされている行に対してコマンドを実行しているときに例外が発生しました。この例外は .NET Framework Version 1.0 を使用している場合は生成されません。
                base.OutPutDebugSQLLog(_command);
                SetLastError((int)Results.E_ExecuteNonQueryFailed, ex, CommandToDebugString(_command));
                return -2;
            }

            return ret;
        }

        /// <summary>ExecuteNonQueryで実行</summary>
        /// <param name="_query">クエリ</param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(string _query)
        {
            int ret;
            SqlCeCommand command;

            command = CreateCommand(_query);
            try
            {
                ret = ExecuteNonQuery(command);
            }
            finally
            {
                command.Dispose();
            }

            return ret;
        }

        /// <summary>ExecuteNonQueryで実行</summary>
        /// <param name="_query">クエリ</param>
        /// <param name="_params">パラメータ</param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(string _query, SqlParameter[] _params)
        {
            var ret = default(int);
            SqlCeCommand command;

            command = CreateCommand(_query);
            foreach (SqlParameter param in _params)
                command.Parameters.Add(CreateParameter(command, param.ParameterName, param.Value));
            try
            {
                ret = ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                command.Dispose();
            }

            return ret;
        }

        /// <summary>ExecuteNonQueryで実行</summary>
        /// <param name="_query">クエリ</param>
        /// <param name="_paramList">パラメータ一覧</param>
        /// <returns></returns>
        public virtual int ExecuteNonQuery(System.Text.StringBuilder _query, List<SqlParameter> _paramList)
        {
            return ExecuteNonQuery(_query.ToString(), _paramList.ToArray());
        }

        /// <summary>ExecuteReaderで実行</summary>
        /// <param name="_command">コマンド</param>
        /// <returns></returns>
        public SqlCeDataReader ExecuteReader(SqlCeCommand _command)
        {

            SqlCeDataReader reader;

            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If DEBUG Then
            */
            if (_command is null)
            {
                SetLastError((int)Results.E_ArgumentNull, "command");
                return null;
            }
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            try
            {
                ClearLastError();

                reader = _command.ExecuteReader();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // ロックされている行に対してコマンドを実行しているときに例外が発生しました。この例外は .NET Framework Version 1.0 を使用している場合は生成されません。
                base.OutPutDebugSQLLog(_command);
                SetLastError((int)Results.E_ExecuteReaderFailed, ex, CommandToDebugString(_command));
                return null;
            }
            catch (Exception ex)
            {
                // コマンドを実行できませんでした。
                base.OutPutDebugSQLLog(_command);
                SetLastError((int)Results.E_ExecuteReaderFailed, ex, CommandToDebugString(_command));
                return null;
            }

            return reader;
        }

        /// <summary>ExecuteReaderで実行</summary>
        /// <param name="_query">クエリ</param>
        /// <returns></returns>
        public SqlCeDataReader ExecuteReader(string _query)
        {

            SqlCeCommand command;
            SqlCeDataReader reader;

            command = CreateCommand(_query);
            try
            {
                reader = ExecuteReader(command);
            }

            finally
            {
                command.Dispose();
            }

            return reader;

        }
        /// <summary>ExecuteReaderで実行</summary>
        /// <param name="_query">クエリ</param>
        /// <param name="_params">パラメータ</param>
        /// <returns></returns>
        public SqlCeDataReader ExecuteReader(string _query, params SqlParameter[] _params)
        {
            SqlCeCommand command;
            SqlCeDataReader reader;

            command = CreateCommand(_query);
            try
            {
                foreach (SqlParameter param in _params)
                    command.Parameters.Add(CreateParameter(command, param.ParameterName, param.Value));
                reader = ExecuteReader(command);
            }

            finally
            {
                command.Dispose();
            }

            return reader;
        }

        /// <summary>ExecuteReaderで実行</summary>
        /// <param name="_query">クエリ</param>
        /// <param name="_paramList">パラメータ一覧</param>
        /// <returns></returns>
        public virtual SqlCeDataReader ExecuteReader(System.Text.StringBuilder _query, List<SqlParameter> _paramList)
        {
            return ExecuteReader(_query.ToString(), _paramList.ToArray());
        }

        /// <summary>ExecuteScalarで実行</summary>
        /// <param name="_command">コマンド</param>
        /// <returns></returns>
        public object ExecuteScalar(SqlCeCommand _command)
        {
            object scalar;

            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If DEBUG Then
            */
            if (_command is null)
            {
                SetLastError((int)Results.E_ArgumentNull, "command");
                return null;
            }
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            try
            {
                ClearLastError();

                scalar = _command.ExecuteScalar();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                // ロックされている行に対してコマンドを実行しているときに例外が発生しました。この例外は .NET Framework Version 1.0 を使用している場合は生成されません。
                base.OutPutDebugSQLLog(_command);
                SetLastError((int)Results.E_ExecuteScalarFailed, ex, CommandToDebugString(_command));
                return null;

            }

            return scalar;
        }

        /// <summary>ExecuteScalarで実行</summary>
        /// <param name="_query">クエリ</param>
        /// <returns></returns>
        public object ExecuteScalar(string _query)
        {

            SqlCeCommand command;
            object scalar;

            command = CreateCommand(_query);
            try
            {
                scalar = ExecuteScalar(command);
            }

            finally
            {
                command.Dispose();
            }

            return scalar;

        }

        /// <summary>ExecuteScalarで実行</summary>
        /// <param name="_query">クエリ</param>
        /// <param name="_params">パラメータ</param>
        /// <returns></returns>
        public object ExecuteScalar(string _query, params SqlParameter[] _params)
        {

            SqlCeCommand command;
            object scalar;

            command = CreateCommand(_query);
            try
            {
                foreach (SqlParameter param in _params)
                    command.Parameters.Add(CreateParameter(command, param.ParameterName, param.Value));
                scalar = ExecuteScalar(command);
            }

            finally
            {
                command.Dispose();
            }

            return scalar;

        }

        /// <summary>ExecuteScalarで実行</summary>
        /// <param name="_query">クエリ</param>
        /// <param name="_paramList">パラメータ一覧</param>
        /// <returns></returns>
        public virtual object ExecuteScalar(System.Text.StringBuilder _query, List<SqlParameter> _paramList)
        {
            return ExecuteScalar(_query.ToString(), _paramList.ToArray());
        }

        /// <summary>ExecuteTableで実行</summary>
        /// <param name="_command">コマンド</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteTable(SqlCeCommand _command)
        {
            SqlCeDataAdapter adapter;
            DataTable table;
            int ret;

            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If DEBUG Then
            */
            if (_command is null)
            {
                SetLastError((int)Results.E_ArgumentNull, "command");
                return null;
            }
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            adapter = new SqlCeDataAdapter(_command);
            try
            {
                ClearLastError();

                table = new DataTable();
                ret = adapter.Fill(table);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                base.OutPutDebugSQLLog(_command);
                SetLastError((int)Results.E_FillFailed, ex, CommandToDebugString(_command));
                return null;
            }
            catch (InvalidOperationException ex)
            {
                // ソース テーブルが無効です。
                base.OutPutDebugSQLLog(_command);
                SetLastError((int)Results.E_FillFailed, ex, CommandToDebugString(_command));
                return null;
            }
            finally
            {
                adapter.Dispose();
            }

            return table;
        }

        /// <summary>ExecuteTableで実行</summary>
        /// <param name="_query">クエリ</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteTable(string _query)
        {
            return ExecuteTable(_query, new SqlParameter[] { });
        }

        /// <summary>ExecuteTableで実行</summary>
        /// <param name="_query">クエリ</param>
        /// <param name="_params">パラメータ</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteTable(string _query, SqlParameter[] _params)
        {

            SqlCeCommand command;
            DataTable table;

            command = CreateCommand(_query);
            try
            {
                foreach (SqlParameter param in _params)
                    command.Parameters.Add(CreateParameter(command, param.ParameterName, param.Value));
                table = ExecuteTable(command);
            }

            finally
            {
                command.Dispose();
            }

            return table;
        }

        /// <summary>ExecuteTableで実行</summary>
        /// <param name="_query">クエリ</param>
        /// <param name="_paramList">パラメータ一覧</param>
        /// <returns>DataTable</returns>
        public virtual DataTable ExecuteTable(System.Text.StringBuilder _query, List<SqlParameter> _paramList)
        {
            return ExecuteTable(_query.ToString(), _paramList.ToArray());
        }

        private string _CommandToDebugString_newLine = Environment.NewLine;

        /// <summary>DEBUGためにコマンドからテキストに変換</summary>
        /// <param name="command">コマンド</param>
        /// <returns>クエリのテキスト</returns>
        protected virtual string CommandToDebugString(System.Data.Common.DbCommand command)
        {
            List<string> list;

            if (command is null)
                return null;

            list = new List<string>();

            list.Add(string.Format("CommandText = \"{0}\"", command.CommandText));

            foreach (System.Data.Common.DbParameter parameter in command.Parameters)
            {
                if (parameter.Value is null || ReferenceEquals(parameter.Value, DBNull.Value))
                {
                    // null.
                    list.Add(string.Format("{0} = NULL", parameter.ParameterName));
                }
                else if (parameter.Value.GetType().IsValueType)
                {
                    // value type.
                    list.Add(string.Format("{0} = {1}", parameter.ParameterName, parameter.Value));
                }
                else if (parameter.Value is string)
                {
                    // string type.
                    list.Add(string.Format("{0} = \"{1}\"", parameter.ParameterName, ((string)parameter.Value).Replace(Conversions.ToString('"'), "\"\"")));
                }
                else
                {
                    // object type.
                    list.Add(string.Format("{0} = {{{1}}}", parameter.ParameterName, parameter.GetType().ToString()));
                }
            }

            return string.Join(_CommandToDebugString_newLine, list.ToArray());
        }


        #endregion

        //public virtual int ExecuteBulkCopy(string tablename , DataTable setData){

        //    using (SqlCeBulkCopy bc = new SqlCeBulkCopy(m_connection.ConnectionString))
        //    {
        //        bc.DestinationTableName = tablename;
        //        bc.WriteToServer(setData); // ← SetDBはDataTableです
        //    }
        //    return 0;
        //}

    }

}