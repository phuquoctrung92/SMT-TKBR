using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Linq;

namespace SmtLib
{
    /// <summary>
    /// ファイル共通機能
    /// </summary>
    public class ClsFile
    {
        #region Structure

        /// <summary> ファイル情報格納用構造体 </summary>
        public struct typeFileTimeInfo
        {
            /// <summary> 作成日時 </summary>
            public DateTime CreateTime;
            /// <summary> 更新日時 </summary>
            public DateTime UpdateTime;
            /// <summary> アクセス日時 </summary>
            public DateTime AccessTime;
        }

        #endregion

        #region Method

        /// <summary>
        /// System.IO.File.AppendAllText 関数拡張。
        /// 上位に例外をスルーしません。
        /// ディレクトリが存在しない場合に作成します。
        /// Shift_JIS エンコーディング固定。
        /// </summary>
        /// <returns> 追記に失敗した時は False を返します。 </returns>
        /// <remarks> ClsFile.Create 関数の代替え。主に ログ ファイル追記に使えそう。 </remarks>
        public static bool AppendAllText(string _target_filename, string _contents)
        {
            if (string.IsNullOrEmpty(_target_filename))
                return false;

            try
            {
                if (!System.IO.File.Exists(_target_filename))
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(_target_filename));
                }
                System.IO.File.AppendAllText(_target_filename, _contents, Const_Encoding.ShiftJIS);
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary> ファイルをCopyし、結果をブール型(boolean)の値で返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_source_filename"> コピー元ファイル </param>
        /// <param name="_target_filename"> コピー先ファイル </param>
        /// <param name="_overwrite"> True:上書き許可 False:上書き不可 </param>
        /// <param name="_retry">失敗したら再試行の回数</param>
        /// <returns> True：成功 False：失敗 </returns>
        public static bool Copy(string _source_filename, string _target_filename, bool _overwrite, int _retry = 10)
        {
            bool CopyRet = false;
            for (int i = 1, loopTo = _retry; i <= loopTo; i++)
            {
                var file_info = new System.IO.FileInfo(_source_filename);
                try
                {
                    // コピー元ファイル存在チェック
                    if (System.IO.File.Exists(_source_filename) && (_overwrite || !System.IO.File.Exists(_target_filename)))
                    {
                        // 上書き可又はファイルが存在してない場合
                        file_info.CopyTo(_target_filename, _overwrite);
                        CopyRet = true;
                    }
                    file_info = null;
                    return true;
                }
                catch (Exception ex)
                {
                    if (i >= _retry)
                    {
                        throw ex;
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }

            return CopyRet;
        }

        /// <summary> ファイルを作成し、結果をブール型(boolean)の値で返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_target_filename"> 作成したいファイルパス </param>
        /// <param name="_create_directory"> True:ディレクトリが存在しなければ作成する False:作成しない </param>
        /// <returns> True:成功 False:失敗 </returns>
        public static bool Create(string _target_filename, bool _create_directory = true)
        {
            System.IO.FileStream file_stream = null;

            try
            {
                var file_info = new System.IO.FileInfo(_target_filename);
                string strDirectory = System.IO.Path.GetDirectoryName(_target_filename);

                // ディレクトリが取得できなかった場合は終了
                if (strDirectory is null)
                {
                    return default;
                }

                // ディレクトリが存在しなければ作成する
                if (_create_directory)
                {
                    ClsDirectory.CreateDirectory(strDirectory);
                }

                // ファイルが存在しなければ作成する
                if (!System.IO.File.Exists(_target_filename))
                {
                    file_stream = file_info.Create();
                }

                return true;
            }
            catch (Exception e)
            {
                if (file_stream is not null)
                {
                    file_stream.Close();
                    file_stream.Dispose();
                }
                throw e;
            }
            finally { 
            if (file_stream is not null)
                {
                    file_stream.Close();
                    file_stream.Dispose();
                }
            }
        }

        /// <summary> ファイルを作成し、結果をブール型(boolean)の値で返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_target_directory"> 作成したいファイルのディレクトリ </param>
        /// <param name="_target_filename"> 作成したいファイル名 </param>
        /// <returns> True:成功 False:失敗 </returns>
        public static bool Create(string _target_directory, string _target_filename)
        {
            System.IO.FileStream file_stream = null;

            try
            {
                if (string.IsNullOrEmpty(_target_directory))
                {
                    return default;
                }

                var file_info = new System.IO.FileInfo(ClsPath.CombinePath(_target_directory, _target_filename));

                // ディレクトリが存在しなければ作成する
                if (!System.IO.Directory.Exists(_target_directory))
                {
                    System.IO.Directory.CreateDirectory(_target_directory);
                }

                // ファイルが存在しなければ作成する
                if (!IsExist(_target_directory, _target_filename))
                {
                    file_stream = file_info.Create();
                }

                return true;
            }
            catch (Exception e)
            {
                if (file_stream is not null)
                {
                    file_stream.Close();
                    file_stream.Dispose();
                }
                throw e;
            }
            finally
            {
                if (file_stream is not null)
                {
                    file_stream.Close();
                    file_stream.Dispose();
                }
            }
        }

        /// <summary> ファイルを削除し、結果をブール型(boolean)の値で返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_target_filename"> 削除したいファイル </param>
        /// <param name="_retry">失敗したら再試行の回数</param>
        /// <returns> True：成功 False:失敗 </returns>
        public static bool Delete(string _target_filename, int _retry = 10)
        {
            // ファイル未存在
            if (IsExist(_target_filename))
            {
                for (int i = 1, loopTo = _retry; i <= loopTo; i++)
                {
                    var file_info = new System.IO.FileInfo(_target_filename);
                    try
                    {
                        // ファイルの削除
                        file_info.Delete();
                        return true;
                    }
                    catch (System.IO.IOException ex)
                    {
                        if (i >= _retry)
                        {
                            throw ex;
                        }
                        System.Threading.Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        if (i >= _retry)
                        {
                            throw ex;
                        }
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
            return true;
        }

        /// <summary> フルパスからフォルダ名を取得します。 </summary>
        /// <param name="_target_filename"> フルパス </param>
        /// <returns> フォルダ名 </returns>
        public static string GetDirectoryName(string _target_filename)
        {
            if (string.IsNullOrEmpty(_target_filename))
            {
                return string.Empty;
            }

            return System.IO.Path.GetDirectoryName(_target_filename);
        }

        /// <summary> 拡張子を取得します。(".XXX"形式) </summary>
        /// <param name="_target_filename"> 拡張子を取得したいファイルパス </param>
        /// <returns> 拡張子 </returns>
        public static string GetExtensionName(string _target_filename)
        {
            return System.IO.Path.GetExtension(_target_filename);
        }

        /// <summary> ファイル情報を取得し、結果をブール型(boolean)の値で返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_source_filename"> 情報を取得したいファイル </param>
        /// <param name="_file_time_info">ファイル情報格納用構造体</param>
        /// <returns> True：成功 False:失敗 </returns>
        public static bool GetFileInfo(string _source_filename, ref typeFileTimeInfo _file_time_info)
        {
            // ファイル未存在ならエラー
            if (!System.IO.File.Exists(_source_filename))
            {
                return default;
            }

            // 作成日時
            _file_time_info.CreateTime = System.IO.File.GetCreationTime(_source_filename);
            // 更新日時
            _file_time_info.UpdateTime = System.IO.File.GetLastWriteTime(_source_filename);
            // 最終ｱｸｾｽ日時
            _file_time_info.AccessTime = System.IO.File.GetLastAccessTime(_source_filename);

            return true;
        }

        /// <summary> フルパスからファイル名を取得します。 </summary>
        /// <param name="_target_filename"> フルパス </param>
        /// <returns> ファイル名 </returns>
        public static string GetFileName(string _target_filename)
        {
            return System.IO.Path.GetFileName(_target_filename);
        }

        /// <summary> フルパスから拡張子を除いたファイル名を取得します。 </summary>
        /// <param name="_target_filename"> フルパス </param>
        /// <returns> ファイル名 </returns>
        public static string GetFileNameWithoutExtension(string _target_filename)
        {
            return System.IO.Path.GetFileNameWithoutExtension(_target_filename);
        }

        /// <summary> ファイルサイズを取得します。取得に失敗した場合は-1を返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_source_filename"> 情報を取得するファイルパス </param>
        /// <returns> ファイルサイズ 取得失敗時は -1 </returns>
        public static long GetFileSize(string _source_filename)
        {
            // ﾌｧｲﾙ未存在時エラー
            if (!IsExist(_source_filename))
            {
                return default;
            }

            var file_info = new System.IO.FileInfo(_source_filename);
            return file_info.Length;
        }

        /// <summary> ファイル行数取得 </summary>
        /// <param name="_target_file"> 対象ファイル </param>
        /// <param name="_has_header"> 先頭がヘッダかどうか </param>
        public static int GetLineCount(string _target_file, bool _has_header = true)
        {
            System.IO.StreamReader stream_reader = null;

            if (!IsExist(_target_file))
            {
                return -1;
            }
            try
            {
                stream_reader = System.IO.File.OpenText(_target_file);
                string read_text = stream_reader.ReadToEnd();
                // 改行コードで件数取得
                int line_count = read_text.Split(Constants.vbCrLf.ToCharArray()).Length;
                // 末尾の改行はカウントしない
                if (read_text.EndsWith(Constants.vbCrLf))
                {
                    line_count -= 1;
                }

                // ヘッダ有の場合
                if (_has_header)
                {
                    line_count -= 1;
                }
                
                return line_count;
            }
            catch
            {
                return -1;
            }
            finally
            {
                if (stream_reader is not null)
                {
                    stream_reader.Close();
                }
            }
        }

        /// <summary> 一時ファイルを作成し、そのパス名を返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <returns> 一時ファイルパス名 </returns>
        public static string GetTempFileName()
        {
            return System.IO.Path.GetRandomFileName();
        }

        /// <summary> ファイルの存在チェックを行い、結果をブール型(boolean)の値で返します。 </summary>
        /// <param name="_target_filename"> ファイルパス </param>
        /// <returns> True:存在 False:未存在 </returns>
        public static bool IsExist(string _target_filename)
        {
            return System.IO.File.Exists(_target_filename);
        }

        /// <summary> ファイルの存在チェックを行い、結果をブール型(boolean)の値で返します。 </summary>
        /// <param name="_target_directory"> ファイルディレクトリ </param>
        /// <param name="_target_filename"> ファイル名 </param>
        /// <returns> True:存在 False:未存在 </returns>
        public static bool IsExist(string _target_directory, string _target_filename)
        {
            if (string.IsNullOrEmpty(_target_directory))
            {
                return false;
            }

            return System.IO.File.Exists(ClsPath.CombinePath(_target_directory, _target_filename));
        }

        /// <summary> 一番初めのリムーバブルメディアドライブを取得する。 </summary>
        /// <returns> ドライブ文字。例："A:\"。該当がない場合には空文字。 </returns>
        /// <remarks> たいていの場合戻り値のドライブはフロッピーディスクドライブです。 </remarks>
        public static string IsFloppy()
        {

            foreach (var drive_info in System.IO.DriveInfo.GetDrives())
            {
                if (drive_info.DriveType == System.IO.DriveType.Removable)
                {
                    return drive_info.Name;
                }
            }

            return string.Empty;
        }

        /// <summary> ファイルの移動を行い、結果をブール型(boolean)の値で返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_source_path"> 移動元ファイル </param>
        /// <param name="_target_path"> 移動先ファイル </param>
        /// <param name="_overwrite">上書き</param>
        /// <param name="_retry">失敗したら再試行の回数</param>
        /// <returns> True:成功 False:失敗 </returns>
        public static bool Move(string _source_path, string _target_path, bool _overwrite = false, int _retry = 10)
        {
            // 移動元ファイル未存在
            // 上書き不可で移動先ファイルが存在
            if (!IsExist(_source_path) || (IsExist(_target_path) && !_overwrite) || !Delete(_target_path))
            {
                return false;
            }

            for (int i = 1, loopTo = _retry; i <= loopTo; i++)
            {
                var file_info = new System.IO.FileInfo(_source_path);
                try
                {
                    // ファイルの移動
                    file_info.MoveTo(_target_path);
                    return true;
                }
                catch (System.IO.IOException ex)
                {
                    if (i >= _retry)
                    {
                        throw ex;
                    }
                    System.Threading.Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    if (i >= _retry)
                    {
                        throw ex;
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }

            return false;
        }

        /// <summary> ファイルの読み込みを行い、結果をブール型(boolean)の値で返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_source_filename"> 読み込み対象ファイル </param>
        /// <returns> True:成功 False:失敗 </returns>
        public static ArrayList Read(string _source_filename)
        {
            string read_text;
            var array_list = new ArrayList();

            // 書込み
            using (var stream_reader = new System.IO.StreamReader(_source_filename, System.Text.Encoding.GetEncoding(932)))
            {
                do
                {
                    read_text = stream_reader.ReadLine();
                    // Nothing = EOF
                    if (read_text is null)
                    {
                        break;
                    }
                    array_list.Add(read_text);
                }
                while (true);
                stream_reader.Close();
            }

            return array_list;
        }

        /// <summary> ファイル名に使用できない文字を削除する </summary>
        /// <param name="_target_filename"> 対象ファイル名 </param>
        public static string ReplaceProhibitionCharacter(string _target_filename)
        {
            const string can_not_use_character = @"""*/:<>?\|.[];";
            // . は保存時に拡張子が正しく判定されなくなるので、ＮＧ扱いとする

            for (int i = 0, loopTo = can_not_use_character.Length - 1; i <= loopTo; i++)
                _target_filename = _target_filename.Replace(can_not_use_character.Substring(i, 1), string.Empty);

            return _target_filename;
        }

        /// <summary> ファイルの読み取り専用を設定し、結果をブール型(boolean)の値で返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_target_filename"> ファイル名 </param>
        /// <param name="_readonly"> True:読取専用 False:読取専用解除 </param>
        /// <returns> True:成功 False:失敗 </returns>
        public static bool SetReadOnly(string _target_filename, bool _readonly)
        {
            // ファイルが存在しなければエラー
            if (!IsExist(_target_filename))
            {
                return default;
            }

            if (_readonly)
            {
                // 読取専用設定
                System.IO.File.SetAttributes(_target_filename, System.IO.File.GetAttributes(_target_filename) | System.IO.FileAttributes.ReadOnly);
            }
            else if ((System.IO.File.GetAttributes(_target_filename) & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
            {
                // 現在の属性から読み取り属性を除去する
                System.IO.File.SetAttributes(_target_filename, System.IO.File.GetAttributes(_target_filename) ^ System.IO.FileAttributes.ReadOnly);
            }

            return true;
        }

        /// <summary> ファイルへの書き込みを行い、結果をブール型(boolean)の値で返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_target_filename"> 書き込みを行うファイル </param>
        /// <param name="_source_string"> 書き込む内容 </param>
        /// <param name="_encoding">引数なし=Shift-JIS</param>
        /// <returns> True:成功 False:失敗 </returns>
        public static bool Write(string _target_filename, string _source_string, System.Text.Encoding _encoding = null)
        {
            _encoding = _encoding ?? Const_Encoding.ShiftJIS;
            // 書込み
            using (var stream_writer = new System.IO.StreamWriter(_target_filename, true, _encoding))
            {
                stream_writer.WriteLine(_source_string);
                stream_writer.Close();
            }

            return true;
        }

        /// <summary> ファイルへの書き込みを行い、結果をブール型(boolean)の値で返します。(Try～Cacthの中に必ず記述して下さい。) </summary>
        /// <param name="_target_filename"> 書き込みを行うファイル </param>
        /// <param name="_source_strings"> 書き込む内容の配列 </param>
        /// <param name="_start_position"> 書き込み開始 Index </param>
        /// <param name="_end_position"> 書き込み終了 Index </param>
        public static bool Write(string _target_filename, string[] _source_strings, int _start_position = 0, int _end_position = -1)
        {
            if (_end_position == -1 || _end_position > _source_strings.Length - 1)
            {
                _end_position = _source_strings.Length - 1;
            }

            try
            {
                // 書込み
                using (var stream_writer = new System.IO.StreamWriter(_target_filename, true, Const_Encoding.ShiftJIS))
                {
                    for (int position = _start_position, loopTo = _end_position; position <= loopTo; position++)
                    {
                        // Null文字を半角スペースに変換
                        _source_strings[position] = _source_strings[position].Replace(Conversions.ToString('\0'), Strings.Space(1));
                        // 改行文字の統一
                        stream_writer.WriteLine(_source_strings[position].Replace(Microsoft.VisualBasic.Constants.vbLf, string.Empty).Replace(Microsoft.VisualBasic.Constants.vbCr, string.Empty).Replace(Microsoft.VisualBasic.Constants.vbCrLf, string.Empty).Replace(Conversions.ToString('\0'), string.Empty));
                    }
                    stream_writer.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary> 一括コピー </summary>
        /// <param name="_source_directory"> コピー元ディレクトリ </param>
        /// <param name="_target_directory"> コピー先ディレクトリ </param>
        /// <param name="_recursive"> サブディレクトリを対象とする場合、True </param>
        /// <param name="_file_list"> 処理対象ファイルリスト </param>
        public static void XCopy(string _source_directory, string _target_directory, [Optional, DefaultParameterValue(null)] ref List<string> _file_list, bool _recursive = false)
        {
            var target_files = new List<string>();

            // ディレクトリがなければ作る
            if (!ClsDirectory.CreateDirectory(_target_directory))
            {
                return;
            }
            // ディレクトリ内のファイルとサブディレクトリを取得する
            target_files.AddRange(System.IO.Directory.GetFileSystemEntries(_source_directory));

            foreach (string target_file in target_files)
            {
                // サブディレクトリの場合
                if (System.IO.Directory.Exists(target_file))
                {
                    if (_recursive)
                    {
                        XCopy(target_file, ClsPath.CombinePath(_target_directory, System.IO.Path.GetFileName(target_file)), ref _file_list, _recursive);
                    }
                }
                else
                {
                    // ファイルの場合
                    Copy(target_file, ClsPath.CombinePath(_target_directory, System.IO.Path.GetFileName(target_file)), true);
                    if (_file_list is not null)
                    {
                        _file_list.Add(System.IO.Path.GetFileName(target_file));
                    }
                }
            }
        }

        /// <summary> 一括削除 </summary>
        /// <param name="_target_directory"> 対象ディレクトリ </param>
        /// <param name="_recursive"> サブディレクトリを対象とする場合、True </param>
        /// <param name="_file_list"> 処理対象ファイルリスト </param>
        public static void XDelete(string _target_directory, [Optional, DefaultParameterValue(null)] ref List<string> _file_list, bool _recursive = false)
        {
            var target_files = new List<string>();

            // ディレクトリ内のファイルとサブディレクトリを取得する
            target_files.AddRange(System.IO.Directory.GetFileSystemEntries(_target_directory));

            foreach (string target_file in target_files)
            {
                // サブディレクトリの場合
                if (System.IO.Directory.Exists(target_file))
                {
                    if (_recursive)
                    {
                        XDelete(target_file, ref _file_list, _recursive);
                    }
                }
                else
                {
                    // ファイルの場合
                    Delete(target_file);
                    if (_file_list is not null)
                    {
                        _file_list.Add(System.IO.Path.GetFileName(target_file));
                    }
                }
            }
        }

        /// <summary> 一括移動 </summary>
        /// <param name="_source_directory"> 移動元ディレクトリ </param>
        /// <param name="_target_directory"> 移動先ディレクトリ </param>
        /// <param name="_recursive"> サブディレクトリを対象とする場合、True </param>
        /// <param name="_file_list"> 処理対象ファイルリスト </param>
        public static void XMove(string _source_directory, string _target_directory, [Optional, DefaultParameterValue(null)] ref List<string> _file_list, bool _recursive = false)
        {
            var target_files = new List<string>();

            // ディレクトリがなければ作る
            if (!ClsDirectory.CreateDirectory(_target_directory))
            {
                return;
            }
            // ディレクトリ内のファイルとサブディレクトリを取得する
            target_files.AddRange(System.IO.Directory.GetFileSystemEntries(_source_directory));

            foreach (string target_file in target_files)
            {
                // サブディレクトリの場合
                if (System.IO.Directory.Exists(target_file))
                {
                    if (_recursive)
                    {
                        XMove(target_file, ClsPath.CombinePath(_target_directory, System.IO.Path.GetFileName(target_file)), ref _file_list, _recursive);
                    }
                }
                else
                {
                    // ファイルの場合
                    Move(target_file, ClsPath.CombinePath(_target_directory, System.IO.Path.GetFileName(target_file)), true);
                    if (_file_list is not null)
                    {
                        _file_list.Add(System.IO.Path.GetFileName(target_file));
                    }
                }
            }
        }

        /// <summary>
        /// ファイル退避(複製)処理
        /// </summary>
        /// <param name="source_FileFullPath"> 対象ファイル(フルPATH) </param>
        /// <param name="backUpFolder"> 格納先ディレクトリ </param>
        /// <param name="aliveFilesCount"> 格納先ディレクトリに保持するファイル数 </param>
        /// <returns> 実行結果判定(済 / 未) </returns>
        /// <remarks>
        /// ファイルのバックアップファイル格納を行う。<br />
        /// ファイル処理は、下記の流れで処理する。<br />
        /// ① 格納先にバックアップファイルが保持するファイル数 [aliveFilesCount]を超過して存在する場合、
        ///    保持するファイル数[aliveFilesCount - 1]以降のファイルを削除する。<br />
        ///     ⇒ ファイル[更新日時]の新しい順に保持するファイル数[aliveFilesCount]まで保持。<br />
        ///     ⇒ 対象とするファイルの["ファイル名"_yyyyMMddHHmmssfff_old."取込ファイル拡張子"]を対象とする。<br />
        /// ② ファイルをリネームして、設定ファイルにて指定した格納先へ移動する。<br />
        ///     ⇒ ファイル[更新日時]を現在時刻に更新する。<br />
        /// 保持するファイル数 [aliveFilesCount]が[1]未満の場合 、処理を終了する。<br />
        /// (何もしない/ 実行結果判定[未]として返す。)<br />
        /// ※ ファイル移動(ClsFile.Move)処理が失敗した場合は、実行結果判定[未]として返す。<br />
        ///     以外は例外(Exception)が発生するので呼出し元にてCatchすること。
        /// </remarks>
        public static bool BackUpTimeStampRenamed(string source_FileFullPath, string backUpFolder, int aliveFilesCount)
        {
            // バックアップファイル名称書式
            const string BACKUP_NAME_FORMAT = "{0}_{1}{2}";

            if (aliveFilesCount < 1)
            {
                return false;
            }

            var ext = Path.GetExtension(source_FileFullPath);
            var fileNamePattern = string.Format(BACKUP_NAME_FORMAT,
                $"^{Path.GetFileNameWithoutExtension(source_FileFullPath)}",
                "[0-9]{17}",
                $"{ext}$"
                );

            // 大文字小文字を区別しない場合
            var regex = new Regex(fileNamePattern, RegexOptions.IgnoreCase);

            var infoBackUpFiles = new DirectoryInfo(backUpFolder).
                EnumerateFiles()?.
                Where(f => regex.IsMatch(f.Name))?.
                OrderByDescending(fi => fi.LastWriteTime) ?? null;

            //if ((infoBackUpFiles?.Count() ?? 0) > (aliveFilesCount - 1))
            //{
            //    foreach (var fileInfo in infoBackUpFiles.Skip(aliveFilesCount - 1))
            //    {
            //        // ファイル削除
            //        fileInfo.Delete();
            //    }
            //}

            // バックアップ処理(ファイル名変更:ReName)
            var createDateTime = DateTime.Now;
            var backupFileFullName = ClsPath.CombinePath(new string[]
            {
                    backUpFolder,
                    string.Format(BACKUP_NAME_FORMAT, new string[]
                    {
                        ClsFile.GetFileNameWithoutExtension(source_FileFullPath),
                        createDateTime.ToString("yyyyMMddHHmmssfff"),
                        ext,
                    })
            });

            if (!ClsFile.Move(source_FileFullPath, backupFileFullName, true))
            {
                return false;
            }

            // 更新日時更新
            new FileInfo(backupFileFullName).LastWriteTime = createDateTime;

            return true;
        }

        #endregion

    }
}