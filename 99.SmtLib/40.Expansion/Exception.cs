using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace SmtLib
{
    /// <summary>エラー処理拡張クラス</summary>
    public class ExceptionDataBase : Exception
    {

        private int m_last_code;
        private object[] m_last_args;

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
                if (m_last_code == (int)FormatMessage.Results.S_FALSE)
                {
                    return string.Empty;
                }
                return FormatMessage.Create(m_last_code, m_last_args);
            }
        }

        /// <summary>初期設定</summary>
        /// <param name="ex"></param>
        public ExceptionDataBase(Exception ex) : base("", ex)
        {
            m_last_code = (int)FormatMessage.Results.S_FALSE;

        }

        /// <summary>初期設定</summary>
        /// <param name="ex"></param>
        /// <param name="pErrorCode"></param>
        /// <param name="pArgs"></param>
        public ExceptionDataBase(Exception ex, int pErrorCode, params object[] pArgs) : base(FormatMessage.Create(pErrorCode, pArgs), ex)
        {

            m_last_code = pErrorCode;
            m_last_args = pArgs;

        }

    }
    /// <summary>エラーメッセージフォーマット</summary>
    public class FormatMessage
    {
        /// <summary>結果</summary>
        public enum Results : int
        {
            /// <summary>成功</summary>
            S_OK = 0x0,
            /// <summary>失敗</summary>
            S_FALSE = 0x1,
            /// <summary>失敗</summary>
            E_FALSE = int.MinValue + 0x00000000,
            /// <summary>実行していません。</summary>
            E_NotImplemented,
            /// <summary>接続の有効化に失敗しました。</summary>
            E_ActiveConnections,
            /// <summary>返した接続状況は無定義です。</summary>
            E_UnknownConnectionState,
            /// <summary>データベースのオーペンに失敗</summary>
            E_OpenFailed,
            /// <summary>オーペンされていません。</summary>
            E_ConnectionNotOpen,
            /// <summary>トランザクションを有効化</summary>
            E_ActiveTransactions,
            /// <summary>トランザクションの開始に失敗</summary>
            E_BeginTransactionFailed,
            /// <summary>トランザクションは開始していません</summary>
            E_NoTransactionHasBeenStarted,
            /// <summary>ロールバックに失敗しました。</summary>
            E_RollbackFailed,
            /// <summary>コミットに失敗しました。</summary>
            E_CommitFailed,
            /// <summary>パラメータを入力していません。</summary>
            E_ArgumentNull,
            /// <summary>ExecuteNonQueryの実行に失敗しました</summary>
            E_ExecuteNonQueryFailed,
            /// <summary>ExecuteReaderの実行に失敗しました</summary>
            E_ExecuteReaderFailed,
            /// <summary>ExecuteScalarの実行に失敗しました</summary>
            E_ExecuteScalarFailed,
            /// <summary>データのフィールに失敗しました</summary>
            E_FillFailed

        }

        private static string _Create_newLine = Environment.NewLine;

        /// <summary>
        /// コードからエラーメッセージを返す
        /// </summary>
        /// <param name="code"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Create(int code, object[] args)
        {

            switch ((Results)code)
            {

                case Results.S_OK:
                    {
                        return string.Empty;
                    }

                case Results.E_NotImplemented:
                    {
                        string methodName = (string)args[0];
                        return string.Format("'{0}' メソッドは実装されていません。", methodName);
                    }

                case Results.E_ActiveConnections:
                    {
                        return string.Format("使用中の接続があります。");
                    }

                case Results.E_UnknownConnectionState:
                    {
                        ConnectionState state = (ConnectionState)args[0];
                        return string.Format("接続の状態が不明です。" + _Create_newLine + "State = {0}", state);
                    }

                case Results.E_OpenFailed:
                    {
                        string connectionString = (string)args[0];
                        return string.Format("データベース接続を開くことができませんでした。" + _Create_newLine + "ConnectionString = '{0}'", connectionString);
                    }

                case Results.E_ConnectionNotOpen:
                    {
                        return string.Format("データベース接続が開かれていません。");
                    }

                case Results.E_ActiveTransactions:
                    {
                        return string.Format("トランザクションが既に存在します。");
                    }

                case Results.E_BeginTransactionFailed:
                    {
                        switch (args.Length)
                        {
                            case 1:
                                {
                                    Exception ex = (Exception)args[0];
                                    return string.Format("トランザクションを開始することができませんでした。" + _Create_newLine + "メッセージ = \"{0}\"", ex.Message);
                                }
                            case 2:
                                {
                                    Exception ex = (Exception)args[0];
                                    IsolationLevel isolationLevel = (IsolationLevel)args[0];
                                    return string.Format("トランザクションを開始することができませんでした。" + _Create_newLine + "isolationLevel = {1}" + _Create_newLine + "メッセージ = \"{0}\"", ex.Message, isolationLevel);
                                }
                        }

                        break;
                    }

                case Results.E_NoTransactionHasBeenStarted:
                    {
                        return string.Format("トランザクションが開始されていません。");
                    }

                case Results.E_RollbackFailed:
                    {
                        Exception ex = (Exception)args[0];
                        return string.Format("トランザクションのロールバックに失敗しました。" + _Create_newLine + "メッセージ = \"{0}\"", ex.Message);
                    }

                case Results.E_CommitFailed:
                    {
                        Exception ex = (Exception)args[0];
                        return string.Format("トランザクションのコミットに失敗しました。" + _Create_newLine + "メッセージ = \"{0}\"", ex.Message);
                    }

                case Results.E_ArgumentNull:
                    {
                        string argumentName = (string)args[0];
                        return string.Format("引数 '{0}' に Null は指定できません。", argumentName);
                    }

                case Results.E_ExecuteNonQueryFailed:
                    {
                        Exception ex = (Exception)args[0];
                        string debugString = (string)args[1];
                        return string.Format("SQL ステートメントの実行に失敗しました。" + _Create_newLine + "メッセージ = \"{0}\"" + _Create_newLine + "{1}", ex.Message, debugString);
                    }

                case Results.E_ExecuteReaderFailed:
                    {
                        Exception ex = (Exception)args[0];
                        string debugString = (string)args[1];
                        return string.Format("SQL ステートメントの実行に失敗しました。" + _Create_newLine + "メッセージ = \"{0}\"" + _Create_newLine + "{1}", ex.Message, debugString);
                    }

                case Results.E_ExecuteScalarFailed:
                    {
                        Exception ex = (Exception)args[0];
                        string debugString = (string)args[1];
                        return string.Format("SQL ステートメントの実行に失敗しました。" + _Create_newLine + "メッセージ = \"{0}\"" + _Create_newLine + "{1}", ex.Message, debugString);
                    }

                case Results.E_FillFailed:
                    {
                        Exception ex = (Exception)args[0];
                        string debugString = (string)args[1];
                        return string.Format("DataSet 内の行の追加 または更新に失敗しました。" + _Create_newLine + "メッセージ = \"{0}\"" + _Create_newLine + "{1}", ex.Message, debugString);
                    }

                default:
                    {
                        break;
                    }

            }

            // パターン外のメッセージ
            List<string> stringList;

            if (0 == code)
            {
                return string.Empty;
            }

            stringList = new List<string>();

            stringList.Add(string.Format("コード {0} (0x{0:x})", code));
            if (args is not null)
            {
                foreach (object arg in args)
                {
                    if (arg is null)
                    {
                        stringList.Add("null");
                    }
                    else
                    {
                        stringList.Add(string.Format("{0} {{{1}}}", arg, arg.GetType()));
                    }
                }
            }

            return string.Join(_Create_newLine, stringList.ToArray());


        }

    }
}