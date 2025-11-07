using System;

namespace SmtLib
{
    /// <summary>
    /// ログ共通機能
    /// </summary>
    public class clsLogger
    {
        /// <summary>
        /// 情報ログの書き込み
        /// </summary>
        /// <param name="text">情報内容</param>
        public static void Info(string text)
        {
            GlobalContext.Log.Info(text);
        }
        /// <summary>
        /// 情報ログの書き込み
        /// </summary>
        /// <param name="format">フォーマット文字列</param>
        /// <param name="arg">引数</param>
        public static void InfoFormat(string format, object arg)
        {
            GlobalContext.Log.InfoFormat(format, arg);
        }
        /// <summary>
        /// 情報ログの書き込み
        /// </summary>
        /// <param name="format">フォーマット文字列</param>
        /// <param name="arg0">引数０</param>
        /// <param name="arg1">引数１</param>
        public static void InfoFormat(string format, object arg0, object arg1)
        {
            GlobalContext.Log.InfoFormat(format, arg0, arg1);
        }
        /// <summary>
        /// 情報ログの書き込み
        /// </summary>
        /// <param name="format">フォーマット文字列</param>
        /// <param name="arg0">引数０</param>
        /// <param name="arg1">引数１</param>
        /// <param name="arg2">引数２</param>
        public static void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            GlobalContext.Log.InfoFormat(format, arg0, arg1, arg2);
        }
        /// <summary>
        /// 情報ログの書き込み
        /// </summary>
        /// <param name="format">フォーマット文字列</param>
        /// <param name="args">配列の引数</param>
        public static void InfoFormat(string format, object[] args)
        {
            GlobalContext.Log.InfoFormat(format, args);
        }
        /// <summary>
        /// エラーログの書き込み
        /// </summary>
        /// <param name="text">エラー内容</param>
        public static void Error(string text)
        {
            GlobalContext.Log.Error(text);
        }
        /// <summary>
        /// エラーログの書き込み
        /// </summary>
        /// <param name="ex">例外</param>
        public static void Error(Exception ex)
        {
            Error(ex.ToString());
        }
        /// <summary>
        /// デバッグログの書き込み
        /// </summary>
        /// <param name="text">デバッグ内容</param>
        public static void Debug(string text)
        {
            GlobalContext.Log.Debug(text);
        }
        /// <summary>
        /// SQLクエリログの書き込み
        /// </summary>
        /// <param name="query">SQLクエリ</param>
        public static void SQL(string query)
        {
            GlobalContext.SQLLog.Debug(query);
        }
    }
}
