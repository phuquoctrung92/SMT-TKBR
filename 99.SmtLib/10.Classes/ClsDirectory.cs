using System;
using System.Collections;
using System.IO;
using System.IO.Compression;

namespace SmtLib
{
    /// <summary>ディレクトリの共通機能</summary>
    public class ClsDirectory
    {

        #region Method

        /// <summary> カレントディレクトリを変更し、結果をブール型(Boolean)の値で返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_target_directory"> 変更先ディレクトリ </param>
        /// <returns> True:成功 False:失敗 </returns>
        public static bool ChangeDirectory(string _target_directory)
        {
            Directory.SetCurrentDirectory(_target_directory);
            return true;
        }

        /// <summary> ディレクトリを作成し、結果をブール型(Boolean)の値で返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_target_directory"> 作成したいディレクトリのパス </param>
        /// <returns> True:成功 False:失敗 </returns>
        public static bool CreateDirectory(string _target_directory)
        {
            // ディレクトリが存在しなければ作成する
            if (!Directory.Exists(_target_directory))
            {
                Directory.CreateDirectory(_target_directory);
            }

            return true;
        }

        /// <summary> ディレクトリを削除し、結果をブール型(Boolean)の値で返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_target_path"> 削除対象ディレクトリパス </param>
        /// <param name="_recursive"> サブディレクトリも削除対象とする場合、True </param>
        /// <returns> True:成功 False:失敗 </returns>
        public static bool DeleteDirectroy(string _target_path, bool _recursive = false)
        {
            // ディレクトリが存在すれば削除する
            if (Directory.Exists(_target_path))
            {
                Directory.Delete(_target_path, _recursive);
            }

            return true;
        }

        /// <summary> 指定パス内に存在する指定された拡張子のファイル情報の配列を取得します。ディレクトリ未存在時はNothingを返します。 </summary>
        /// <param name="_target_directory"> 取得したいディレクトリのパス </param>
        /// <param name="_pattern"> 取得するファイルパターン </param>
        /// <returns> ファイル名の ArrayList </returns>
        public static FileInfo[] GetAllFileInfo(string _target_directory, string _pattern = "*")
        {
            if (!Directory.Exists(_target_directory))
            {
                // ディレクトリ未存在
                return null;
            }

            var directory_info = GetDirectoryInfo(_target_directory);

            return directory_info.GetFiles(_pattern);
        }

        /// <summary>指定パス内にすべてディレクトリ情報を取得</summary>
        /// <param name="_target_directory">取得したいディレクトリのパス</param>
        /// <param name="_pattern">取得するファイルパターン</param>
        /// <returns></returns>
        public static DirectoryInfo[] GetAllDirectoryInfo(string _target_directory, string _pattern = "*")
        {
            if (!Directory.Exists(_target_directory))
            {
                // ディレクトリ未存在
                return null;
            }

            var directory_info = GetDirectoryInfo(_target_directory);

            return directory_info.GetDirectories(_pattern);
        }

        /// <summary>
        /// 指定パス内に存在する指定された拡張子のファイル名のArrayListを取得します。ディレクトリ未存在時はNothingを返します。
        /// </summary>
        /// <param name="TargetDir">取得したいディレクトリのパス</param>
        /// <param name="Extension">取得するファイルの拡張子</param>
        /// <param name="_All">検索オプション</param>
        /// <returns>ファイル名のArrayList</returns>
        public static ArrayList GetAllFileName(string TargetDir, string Extension = ".*", SearchOption _All = SearchOption.TopDirectoryOnly)
        {
            var listFile = new ArrayList();
            string strFileName;

            // ディレクトリのパス又は拡張子が空白文字列の場合は処理終了
            if (ClsCheck.IsNull(TargetDir) || ClsCheck.IsNull(Extension))
            {
                return null;
            }

            if ((TargetDir.Substring(TargetDir.Length - 1, 1) ?? "") != ConstLib.STR_BACKSLASH)
            {
                TargetDir = TargetDir + ConstLib.STR_BACKSLASH;
            }

            // ディレクトリ未存在時は処理終了
            if (!Directory.Exists(TargetDir))
            {
                return null;
            }

            // 拡張子ありの場合
            if (!ClsCheck.IsNull(Extension))
            {
                // 拡張子に"."が付いていない場合は付加
                if ((Extension.Substring(0, 1) ?? "") != ConstLib.STR_DOT)
                {
                    Extension = ConstLib.STR_DOT + Extension;
                }

                Extension = ConstLib.STR_HALFASTERISK + Extension;
            }
            else
            {
                // 拡張子なしの場合
                Extension = ".*";
            }

            foreach (var currentStrFileName in Directory.GetFiles(TargetDir, Extension, _All))
            {
                strFileName = currentStrFileName;
                listFile.Add(strFileName);
            }

            return listFile;
        }

        /// <summary> アプリケーションの起動ディレクトリを取得します。 </summary>
        /// <returns> ディレクトリ名 </returns>
        public static string GetApplicationDirectory()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        /// <summary> カレントディレクトリを取得します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <returns> カレントディレクトリ名 </returns>
        public static string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary> フォルダ情報を取得します。 </summary>
        /// <param name="_target_directory"> 情報を取得するディレクトリ </param>
        /// <returns> フォルダ情報 </returns>
        public static DirectoryInfo GetDirectoryInfo(string _target_directory)
        {
            return new DirectoryInfo(_target_directory);
        }

        /// <summary> フォルダが空かどうかをチェックし、、結果をブール型(Boolean)の値で返します。 </summary>
        /// <param name="_target_directory"> チェックするディレクトリ </param>
        /// <returns> True:フォルダが空 False:フォルダが空でない </returns>
        public static bool IsEmpty(string _target_directory)
        {
            var directory_info = GetDirectoryInfo(_target_directory);

            if (directory_info.GetFiles().Length > 0 || directory_info.GetDirectories().Length > 0)
            {
                // ファイルかフォルダが存在する場合は空でない
                return false;
            }

            // 空の時
            return true;
        }

        /// <summary> ファイルまたはディレクトリ、およびその内容を新しい場所に移動します。既に存在しているフォルダに上書きはできません。   </summary>
        /// <param name="_source_path"> コピー元パス </param>
        /// <param name="_target_path"> コピー先パス </param>
        /// <returns> True:成功 False:失敗 </returns>
        public static bool MoveDirectory(string _source_path, string _target_path)
        {
            // ディレクトリが存在すれば移動する
            Directory.Move(_source_path, _target_path);

            return true;
        }

        /// <summary>フォルダを圧縮</summary>
        /// <param name="_source_path">圧縮したいフォルダのパス</param>
        /// <param name="_target_path">圧縮したファイルの出力先</param>
        /// <param name="level">圧縮レベル</param>
        public static void CompressDirectory(string _source_path, string _target_path, CompressionLevel level)
        {
            ZipFile.CreateFromDirectory(_source_path, _target_path, level, true);
        }
        #endregion

        /// <summary>フォルダが存在しているかをチェック</summary>
        /// <param name="_source_path">チェックしたいフォルダのパス</param>
        /// <returns></returns>
        public static bool isExist(string _source_path)
        {
            return Directory.Exists(_source_path);
        }
    }
}