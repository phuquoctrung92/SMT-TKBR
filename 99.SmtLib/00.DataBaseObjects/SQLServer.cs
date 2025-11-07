
// 
// 

using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;
using static SmtLib.FormatMessage;

namespace SmtLib.DataBaseObjects
{
    /// <summary>
    /// SQLServer用の共通機能
    /// </summary>
    public class SQLServer : Database
    {

        #region Constructor

        private static SQLServer _instance = null;
        /// <summary>Instance</summary>
        public static SQLServer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SQLServer();
                }
                return _instance;
            }
        }

        private SQLServer()
        {
        }
        #endregion

        #region Open
        /// <summary>データベースをオーペン</summary>
        /// <param name="connectionString">接続文字列</param>
        /// <returns>Results</returns>
        //<System.Diagnostics.DebuggerStepThrough()>
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
            m_connection = new SqlConnection();
            try
            {
                m_connection.ConnectionString = connectionString;
                m_connection.Open();
                m_connection_string = connectionString;
                return (int)Results.S_OK;
            }

            catch (InvalidOperationException ex)
            {
                // データ ソースまたはサーバーを指定せずに接続を開くことはできません。
                // または
                // 接続が既に開いています。

                SetLastError((int)Results.E_OpenFailed, connectionString, ex);
                clsLogger.Error(ex);
                m_connection.Dispose();
                m_connection = null;
                return LastErrorCode;
            }

            catch (SqlException ex)
            {
                // 接続を開くときに、接続レベルのエラーが発生しました。Number プロパティに値 18487 または 18488 が含まれている場合は、指定したパスワードの有効期限が切れているか、またはパスワードをリセットする必要があることを示します。詳細については、ChangePassword メソッドのトピックを参照してください。

                SetLastError((int)Results.E_OpenFailed, connectionString, ex);
                clsLogger.Error(ex);
                m_connection.Dispose();
                m_connection = null;
                return LastErrorCode;

            }
        }


        #endregion

        #region BeginTransaction
        public override int BeginTransaction()
        {
            if (!ExistsConnection)
            {
                Open();
            }
            return base.BeginTransaction();
        }
        #endregion

        #region Private

        [DebuggerStepThrough()]
        private SqlCommand CreateCommand(string query)
        {

            SqlCommand command;

            if (m_connection is null)
            {
                command = new SqlCommand();
            }
            else
            {
                command = ((SqlConnection)m_connection).CreateCommand();
                command.Transaction = (SqlTransaction)m_transaction;
                command.Connection = (SqlConnection)m_connection;
            }
            command.CommandText = query;
            command.CommandTimeout = m_command_timeout;

            return command;

        }

        [DebuggerStepThrough()]
        private System.Data.SqlClient.SqlParameter CreateParameter(SqlCommand _command, SqlParameter _prm)
        {

            System.Data.SqlClient.SqlParameter parameter;

            if (_command is null)
            {
                parameter = new System.Data.SqlClient.SqlParameter(_prm.ParameterName, _prm.Type);
                parameter.Value = _prm.Value;
            }
            else
            {
                parameter = _command.CreateParameter();
                parameter.ParameterName = _prm.ParameterName;
                parameter.SqlDbType = _prm.Type;
                parameter.Value = _prm.Value;
            }

            //switch (m_dataSourceType)
            //{

            //}

            return parameter;

        }
        #endregion

        #region ExecuteNonQuery
        /// <summary>ExecuteNonQueryでクエリを実行</summary>
        /// <param name="query">クエリ</param>
        /// <param name="params">パラメータ</param>
        /// <returns>成功した行数（マイナスの場合、失敗された。）</returns>
        // <System.Diagnostics.DebuggerStepThrough()>
        public int ExecuteNonQuery(string query, SqlParameter[] @params = null)
        {
            if (!ExistsTransaction)
            {
                _instance.Open();
            }

            if (m_connection == null || m_connection.State != ConnectionState.Open)
            {
                throw new ExceptionDataBase(new Exception(), (int)Results.E_OpenFailed, m_connection_string);
            }

            var command = new SqlCommand();
            try
            {
                command = CreateCommand(query);
                if (@params is not null)
                {
                    foreach (SqlParameter param in @params)
                        command.Parameters.Add(CreateParameter(command, param));
                }
                ClearLastError();
                /* TODO ERROR: Skipped IfDirectiveTrivia
                #If DEBUG Then
                */
                base.OutPutDebugSQLLog(command);
                /* TODO ERROR: Skipped EndIfDirectiveTrivia
                #End If
                */
                return command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                base.OutPutErrorSQLLog(command);
                throw ex;
            }
            finally
            {
                command.Dispose();
                if (m_connection != null && m_connection.State == ConnectionState.Open && !ExistsTransaction)
                {
                    m_connection.Close();
                }
            }
        }

        /// <summary>ExecuteNonQueryでクエリを実行</summary>
        /// <param name="query">クエリ</param>
        /// <param name="params">パラメータ</param>
        /// <returns>成功した行数（マイナスの場合、失敗された。）</returns>
        [DebuggerStepThrough()]
        public int ExecuteNonQuery(System.Text.StringBuilder query, List<SqlParameter> @params)
        {
            return ExecuteNonQuery(query.ToString(), @params.ToArray());
        }
        #endregion

        #region ExecuteReader

        /// <summary>ExecuteReaderでクエリを実行</summary>
        /// <param name="_query">クエリ</param>
        /// <param name="_params">パラメータ</param>
        /// <returns>SqlDataReader</returns>
        [DebuggerStepThrough()]
        public SqlDataReader ExecuteReader(string _query, SqlParameter[] _params = null)
        {
            if (!ExistsTransaction)
            {
                _instance.Open();
            }

            if (m_connection == null || m_connection.State != ConnectionState.Open)
            {
                throw new ExceptionDataBase(new Exception(), (int)Results.E_OpenFailed, m_connection_string);
            }

            var command = new SqlCommand();
            try
            {
                command = CreateCommand(_query);
                if (_params is not null)
                {
                    foreach (SqlParameter param in _params)
                        command.Parameters.Add(CreateParameter(command, param));
                }

                ClearLastError();
                /* TODO ERROR: Skipped IfDirectiveTrivia
                #If DEBUG Then
                */
                base.OutPutDebugSQLLog(command);
                /* TODO ERROR: Skipped EndIfDirectiveTrivia
                #End If
                */
                return command.ExecuteReader();
            }

            catch (Exception ex)
            {
                base.OutPutErrorSQLLog(command);
                throw ex;
            }
            finally
            {
                command.Dispose();
                if (m_connection != null && m_connection.State == ConnectionState.Open && !ExistsTransaction)
                {
                    m_connection.Close();
                }
            }
        }

        /// <summary>ExecuteReaderでクエリを実行</summary>
        /// <param name="query">クエリ</param>
        /// <param name="paramList">パラメータ</param>
        /// <returns>SqlDataReader</returns>
        [DebuggerStepThrough()]
        public virtual object ExecuteReader(System.Text.StringBuilder query, List<SqlParameter> paramList)
        {

            return ExecuteReader(query.ToString(), paramList.ToArray());

        }

        #endregion

        #region ExecuteScalar
        /// <summary>ExecuteScalarでクエリを実行</summary>
        /// <param name="query">クエリ</param>
        /// <param name="params">パラメータ</param>
        /// <returns>Object</returns>
        [DebuggerStepThrough()]
        public object ExecuteScalar(string query, SqlParameter[] @params = null)
        {
            if (!ExistsTransaction)
            {
                _instance.Open();
            }

            if (m_connection == null || m_connection.State != ConnectionState.Open)
            {
                throw new ExceptionDataBase(new Exception(), (int)Results.E_OpenFailed, m_connection_string);
            }

            var command = new SqlCommand();
            try
            {
                command = CreateCommand(query);

                if (@params is not null)
                {
                    foreach (SqlParameter param in @params)
                        command.Parameters.Add(CreateParameter(command, param));
                }

                ClearLastError();
                /* TODO ERROR: Skipped IfDirectiveTrivia
                #If DEBUG Then
                */
                base.OutPutDebugSQLLog(command);
                /* TODO ERROR: Skipped EndIfDirectiveTrivia
                #End If
                */
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                base.OutPutErrorSQLLog(command);
                throw ex;
            }
            finally
            {
                command.Dispose();
                if (m_connection != null && m_connection.State == ConnectionState.Open && !ExistsTransaction)
                {
                    m_connection.Close();
                }
            }
        }

        /// <summary>ExecuteScalarでクエリを実行</summary>
        /// <param name="query">クエリ</param>
        /// <param name="paramList">パラメータ</param>
        /// <returns>Object</returns>
        [DebuggerStepThrough()]
        public virtual object ExecuteScalar(System.Text.StringBuilder query, List<SqlParameter> paramList)
        {

            return ExecuteScalar(query.ToString(), paramList.ToArray());

        }

        /// <summary>ExecuteScalarでクエリを実行</summary>
        /// <param name="query">クエリ</param>
        /// <param name="params">パラメータ</param>
        /// <param name="ReturnName">列名</param>
        /// <returns>Object</returns>
        [DebuggerStepThrough()]
        public string ExecuteScalar(string query, SqlParameter[] @params, string ReturnName)
        {
            _instance.Open(m_connection_string);

            if (m_connection == null || m_connection.State != ConnectionState.Open)
            {
                throw new ExceptionDataBase(new Exception(), (int)Results.E_OpenFailed, m_connection_string);
            }

            var command = new SqlCommand();
            try
            {
                command = CreateCommand(query);

                if (@params is not null)
                {
                    foreach (SqlParameter param in @params)
                        command.Parameters.Add(CreateParameter(command, param));
                }

                command.Parameters.Add(ReturnName, SqlDbType.Int).Direction = ParameterDirection.Output;

                ClearLastError();
                /* TODO ERROR: Skipped IfDirectiveTrivia
                #If DEBUG Then
                */
                base.OutPutDebugSQLLog(command);
                /* TODO ERROR: Skipped EndIfDirectiveTrivia
                #End If
                */
                command.ExecuteScalar();

                return Conversions.ToString(command.Parameters[ReturnName].Value);
            }
            catch (Exception ex)
            {
                base.OutPutDebugSQLLog(command);
                throw ex;
            }
            finally
            {
                command.Dispose();
                if (m_connection != null && m_connection.State == ConnectionState.Open)
                {
                    m_connection.Close();
                }
            }
        }

        #endregion

        #region ExecuteTable

        // <System.Diagnostics.DebuggerStepThrough()>
        /// <summary>ExecuteTableで実行</summary>
        /// <param name="_query"></param>
        /// <param name="_params"></param>
        /// <returns></returns>
        public DataTable ExecuteTable(string _query, SqlParameter[] _params = null)
        {
            if (!ExistsTransaction)
            {
                _instance.Open();
            }

            if (m_connection == null || m_connection.State != ConnectionState.Open)
            {
                throw new ExceptionDataBase(new Exception(), (int)Results.E_OpenFailed, m_connection_string);
            }
            var command = new SqlCommand();
            try
            {
                var table = new DataTable();

                command = CreateCommand(_query);
                var adapter = new SqlDataAdapter(command);

                if (_params is not null)
                {
                    foreach (SqlParameter param in _params)
                        command.Parameters.Add(CreateParameter(command, param));
                }

                ClearLastError();
                /* TODO ERROR: Skipped IfDirectiveTrivia
                #If DEBUG Then
                */
                base.OutPutDebugSQLLog(command);
                /* TODO ERROR: Skipped EndIfDirectiveTrivia
                #End If
                */
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                base.OutPutErrorSQLLog(command);
                throw ex;
            }
            finally
            {
                command.Dispose();
                if (m_connection != null && m_connection.State == ConnectionState.Open && !ExistsTransaction)
                {
                    m_connection.Close();
                }
            }

        }

        /// <summary>ExecuteTableで実行</summary>
        /// <param name="_query">クエリ</param>
        /// <param name="_paramList">パラメータ一覧</param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public virtual DataTable ExecuteTable(System.Text.StringBuilder _query, List<SqlParameter> _paramList)
        {
            return ExecuteTable(_query.ToString(), _paramList?.ToArray());
        }


        //public DateTime GetSystemTime()
        //{
        //    string strSql = "SELECT GETDATE()";  // SQLServerサーバ日付取得
        //    try
        //    {
        //        DataTable dt = null/* TODO Change to default(_) if this is not a reference type */;

        //        dt = ExecuteTable(strSql);

        //        if (dt == null || dt.Rows.Count == 0)
        //            return DateTime.Now;

        //        return Convert.ToDateTime(dt.Rows[0][0].ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLogger.Error(ex);
        //        return DateTime.Now;
        //    }
        //}
        #endregion

        #region BulkCopy
        /// <summary> BulkCopyを実行 </summary>
        /// <param name="dt"> 対象データ(DataTable) </param>
        /// <remarks>
        /// 対象データ(DataTable)を一括挿入(BulkCopy)する。<br />
        /// 対象データ(DataTable)の項目が、挿入するDBテーブルと完全一致していることを前提とする。<br />
        /// 対象データ(DataTable)のテーブル名を、挿入するDBテーブル名とすること。<br />
        /// 呼出し元にて呼び出した(既に確立している接続)[Connection],[Transaction]を用いる。<br />
        /// 例外は[throw]される為、呼出し元でCatchすること
        /// </remarks>
        public void BulkCopyUseTran(DataTable dt)
        {
            if (m_connection == null || m_connection.State != ConnectionState.Open)
            {
                throw new ExceptionDataBase(new Exception(), (int)Results.E_OpenFailed, m_connection_string);
            }

            if (!ExistsTransaction)
            {
                throw new ExceptionDataBase(new Exception(), (int)Results.E_NoTransactionHasBeenStarted);
            }

            using var bc = new SqlBulkCopy((SqlConnection)m_connection,
                                           SqlBulkCopyOptions.Default,
                                           (SqlTransaction)m_transaction)
            {
                DestinationTableName = dt.TableName
            };

            // [DataBase](Destination)の項目名と[DataTable](Source)の項目名を関連付け
            foreach (var column in dt.Columns)
            {
                bc.ColumnMappings.Add(column.ToString(), column.ToString());
            }

            bc.WriteToServer(dt);
        }

        /// <summary> BulkCopyを実行 </summary>
        /// <param name="dt"> 対象データ(DataTable) </param>
        /// <remarks>
        /// 対象データ(DataTable)を一括挿入(BulkCopy)する。<br />
        /// 対象データ(DataTable)の項目が、挿入するDBテーブルと完全一致していることを前提とする。<br />
        /// 対象データ(DataTable)のテーブル名を、挿入するDBテーブル名とすること。<br />
        /// 例外は[throw]される為、呼出し元でCatchすること
        /// </remarks>
        public void BulkCopy(DataTable dt)
        {
            if (m_connection == null || m_connection.State != ConnectionState.Open)
            {
                if (!this.Open().Equals((int)FormatMessage.Results.S_OK))
                {
                    throw new ExceptionDataBase(new Exception(),
                                                (int)Results.E_OpenFailed,
                                                m_connection_string);
                }
            }

            using var bc = new SqlBulkCopy((SqlConnection)m_connection)
            {
                DestinationTableName = dt.TableName
            };

            // [DataBase](Destination)の項目名と[DataTable](Source)の項目名を関連付け
            foreach (var column in dt.Columns)
            {
                bc.ColumnMappings.Add(column.ToString(), column.ToString());
            }

            bc.WriteToServer(dt);
        }

        /// <summary> BulkCopyを実行 </summary>
        /// <param name="reader">対象データReader(DBテーブル) </param>
        /// <param name="targetTableName"> 挿入先テーブル名 </param>
        /// <remarks>
        /// 対象データ(DataReader)を一括挿入(BulkCopy)する。<br />
        /// 対象データ(DataReader)の項目が、挿入するDBテーブルと完全一致していることを前提とする。<br />
        /// DataReadrの読込(Read)毎にデータを挿入する。<br />
        /// 例外は[throw]される為、呼出し元でCatchすること
        /// </remarks>
        public void BulkCopySetDataReader(System.Data.Common.DbDataReader reader, string targetTableName)
        {
            if (m_connection == null || m_connection.State != ConnectionState.Open)
            {
                if (!this.Open().Equals((int)FormatMessage.Results.S_OK))
                {
                    throw new ExceptionDataBase(new Exception(),
                                                (int)Results.E_OpenFailed,
                                                m_connection_string);
                }
            }

            using var bc = new SqlBulkCopy((SqlConnection)m_connection)
            {
                DestinationTableName = targetTableName,
                EnableStreaming = true,
            };

            bc.WriteToServer(reader);
        }
        #endregion

        #region Method

        /// <summary> システム日付取得 </summary>
        /// <returns> 日付 </returns>
        /// <remarks> DBのシステム日付を取得し、引数のSysDateにセットします。 </remarks>
        public DateTime GetSysDate()
        {
            string strSql = "SELECT CURRENT_TIMESTAMP";  // サーバ日付取得
            try
            {
                DataTable dt = null;

                dt = ExecuteTable(strSql);

                if (dt is null || dt.Rows.Count == 0)
                {
                    return DateTime.Now;
                }

                return Conversions.ToDate(dt.Rows[0][0].ToString());
            }
            catch
            {
                return DateTime.Now;
            }

        }


        /// <summary>
        /// SQLの実行を同一トランザクション内で行う
        /// </summary>
        /// <param name="sqlExecuteStructure">構造体</param>
        /// <returns>
        /// 0:正常終了/1:他のユーザにより更新/2:データ未存在
        /// 8:パラメータ不備/9:システムエラー</returns>
        /// <remarks>
        /// 排他チェックなし。
        /// </remarks>
        public int ExecuteStructure(Structure[] sqlExecuteStructure)
        {
            int executeCount;
            var returnValue = default(int);
            bool rollBackFlag = false;

            try
            {
                // 引数チェック
                if (sqlExecuteStructure is null)
                {
                    return 8;
                }
                for (int i = 0, loopTo = sqlExecuteStructure.Length - 1; i <= loopTo; i++)
                {
                    if (!CheckSqlExecuteStructure(sqlExecuteStructure[i]))
                    {
                        return 8;
                    }
                }

                // トランザクション開始
                if (BeginTransaction() != 0)
                {
                    return 9;
                }

                for (int i = 0, loopTo1 = sqlExecuteStructure.Length - 1; i <= loopTo1; i++)
                {

                    // SQL実行
                    executeCount = ExecuteNonQuery(sqlExecuteStructure[i].SQL, sqlExecuteStructure[i].Parameter);
                    if (executeCount == 0)
                    {
                        // 0件
                        switch (sqlExecuteStructure[i].CRUD)
                        {
                            case SqlExecuteCRUD.Update:
                                {
                                    rollBackFlag = true;
                                    returnValue = 2;
                                    break;
                                }
                            case SqlExecuteCRUD.Create:
                                {
                                    rollBackFlag = true;
                                    returnValue = 1;
                                    break;
                                }
                        }
                    }
                    else if (executeCount == -2)
                    {
                        rollBackFlag = true;
                        returnValue = -9;
                    }
                    else
                    {
                        // 正常
                        returnValue = 0;
                    }

                    if (rollBackFlag)
                    {
                        if (Rollback() != 0)
                        {
                            returnValue = -9;
                        }
                        return returnValue;
                    }
                }

                // コミット
                if (Commit() != 0)
                {
                    return -9;
                }
                return 0;
            }
            catch (ExceptionDataBase ex)
            {
                // ロールバック
                Rollback();
                // ex = Nothing
                throw ex;
                //return 9;
            }
            catch (Exception ex)
            {
                // ロールバック
                Rollback();
                // ex = Nothing
                throw ex;
                //return 9;
            }
        }

        /// <summary>
        /// SqlExecuteStructureの内容をチェックする
        /// </summary>
        /// <param name="sqlExecuteStructure">チェックするSqlExecuteStructure</param>
        /// <returns>True:OK/False:NG</returns>
        /// <remarks></remarks>
        private bool CheckSqlExecuteStructure(Structure sqlExecuteStructure)
        {

            if (ClsCheck.IsNull(sqlExecuteStructure.SQL))
            {
                return false;
            }
            if (ClsCheck.IsNull(sqlExecuteStructure.CRUD))
            {
                return false;
            }

            switch (sqlExecuteStructure.CRUD)
            {
                case SqlExecuteCRUD.Create:
                case SqlExecuteCRUD.Update:
                case SqlExecuteCRUD.Delete:
                case SqlExecuteCRUD.InsUpdSelect:
                    {
                        break;
                    }

                default:
                    {
                        return false;
                    }
            }
            return true;
        }
        #endregion

    }

}