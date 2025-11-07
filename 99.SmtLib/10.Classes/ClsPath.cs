using System;

namespace SmtLib
{
    /// <summary>
    /// パス共通機能
    /// </summary>
    public class ClsPath
    {
        #region Method

        /// <summary> 複数のパス文字列を結合します。 </summary>
        /// <param name="_path1"></param>
        /// <param name="_path2"></param>
        /// <returns>パス</returns>
        public static string CombinePath(string _path1, string _path2)
        {
            return System.IO.Path.Combine(_path1, _path2);
        }

        /// <summary> 複数のパス文字列を結合します。 </summary>
        /// <returns>パス</returns>
        public static string CombinePath(params string[] path)
        {
            return System.IO.Path.Combine(path);
        }

        /// <summary> ファイルの完全パスを取得します。 </summary>
        /// <param name="_source"></param>
        /// <returns>パス</returns>
        public static string GetFullPath(string _source)
        {
            System.IO.DriveInfo drive_info;
            string return_value = _source;
            try
            {
                if (string.IsNullOrEmpty(return_value))
                {
                    return_value = System.IO.Path.GetPathRoot(AppDomain.CurrentDomain.BaseDirectory);
                }
                else if (return_value.Substring(0, 2) != @"\\")
                {
                    drive_info = new System.IO.DriveInfo(System.IO.Path.GetPathRoot(return_value));
                    if (!ClsDirectory.isExist(System.IO.Path.GetPathRoot(return_value)))
                    {
                        // ドライブが存在しない場合、ルートディレクトリに変換
                        return_value = return_value.Replace(System.IO.Path.GetPathRoot(return_value), System.IO.Path.GetPathRoot(AppDomain.CurrentDomain.BaseDirectory));
                    }
                }
            }
            catch
            {
                // 相対パス指定の場合は、カレントディレクトリを親ディレクトリとみなす
                return_value = CombinePath(AppDomain.CurrentDomain.BaseDirectory, return_value);
            }
            // 相対パスを絶対パスに変換する
            return System.IO.Path.GetFullPath(return_value);
        }

        #endregion

    }
}