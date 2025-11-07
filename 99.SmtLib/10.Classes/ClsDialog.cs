using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Windows.Forms;

namespace SmtLib
{
    /// <summary>
    /// ダイアログ関係
    /// </summary>
    /// <remarks></remarks>
    public class ClsDialog
    {
        /// <summary>
        /// ファイル選択ダイアログ
        /// </summary>
        /// <param name="_Folder">フォルダ</param>
        /// <param name="_FileNm">ファイル名</param>
        /// <param name="_Filter">フィルタ(渡さない場合は"すべてのファイル(*.*)|*.*"）</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string OpenFileDialog(string _Folder, string _FileNm, string[] _Filter = null)
        {
            // SaveFileDialog の新しいインスタンスを生成する (デザイナから追加している場合は必要ない)
            var OpenFileDialog1 = new OpenFileDialog();
            try
            {
                ref var withBlock = ref OpenFileDialog1;

                if (_Folder != "" && _FileNm !="" && _Folder.IndexOf(_FileNm)!=-1) {

                    _Folder = _Folder.Replace( _FileNm, "");
                }


                GetDefaultPath(ref _Folder, ref _FileNm);

                     // 初期表示するディレクトリを設定する
                    withBlock.InitialDirectory = _Folder;

                    // 初期表示するファイル名を設定する
                    // ファイル名に使用できない文字は削除
                    withBlock.FileName = _FileNm;
            

                if (_Filter is null)
                {
                    _Filter = new string[] { "すべてのファイル(*.*)|*.*" };
                }

                // ファイルのフィルタを設定する
                withBlock.Filter = string.Join("|", _Filter);
                // ファイルの種類 の初期設定を 1 番目に設定する (初期値 1)
                withBlock.FilterIndex = 1;

                // ダイアログボックスを閉じる前に現在のディレクトリを復元する (初期値 False)
                withBlock.RestoreDirectory = true;

                // ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
                if (withBlock.ShowDialog() != DialogResult.OK)
                {
                    return string.Empty;
                }

                return withBlock.FileName;
            }

            catch
            {
                return string.Empty;
            }
            finally
            {
                // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
                OpenFileDialog1.Dispose();
            }
        }

        /// <summary>
        /// ファイル保存ダイアログ
        /// </summary>
        /// <param name="_Folder">フォルダ</param>
        /// <param name="_FileNm">ファイル名</param>
        /// <param name="_Filter">フィルタ(渡さない場合は"すべてのファイル(*.*)|*.*"）</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string SaveFileDialog(string _Folder, string _FileNm, string[] _Filter = null)
        {
            // SaveFileDialog の新しいインスタンスを生成する (デザイナから追加している場合は必要ない)
            var SaveFileDialog1 = new SaveFileDialog();
            try
            {
                GetDefaultPath(ref _Folder, ref _FileNm);

                // 初期表示するディレクトリを設定する
                SaveFileDialog1.InitialDirectory = _Folder;

                // 初期表示するファイル名を設定する
                // ファイル名に使用できない文字は削除
                SaveFileDialog1.FileName = _FileNm;

                if (_Filter is null)
                {
                    _Filter = new string[] { "すべてのファイル(*.*)|*.*" };
                }

                // ファイルのフィルタを設定する
                SaveFileDialog1.Filter = string.Join("|", _Filter);

                // ファイルの種類 の初期設定を 1 番目に設定する (初期値 1)
                SaveFileDialog1.FilterIndex = 1;

                // ダイアログボックスを閉じる前に現在のディレクトリを復元する (初期値 False)
                SaveFileDialog1.RestoreDirectory = true;

                // 存在しないファイルを指定した場合は、
                // 新しく作成するかどうかの問い合わせを表示する (初期値 False)
                // SaveFileDialog1.CreatePrompt = True
                // [ヘルプ] ボタンを表示する (初期値 False)
                // SaveFileDialog1.ShowHelp = False
                // 存在しているファイルを指定した場合は、
                // 上書きするかどうかの問い合わせを表示する (初期値 True)
                // SaveFileDialog1.OverwritePrompt = True
                // 存在しないファイル名を指定した場合は警告を表示する (初期値 False)
                // SaveFileDialog1.CheckFileExists = True
                // 存在しないパスを指定した場合は警告を表示する (初期値 True)
                // SaveFileDialog1.CheckPathExists = True
                // 拡張子を指定しない場合は自動的に拡張子を付加する (初期値 True)
                // SaveFileDialog1.AddExtension = True
                // 有効な Win32 ファイル名だけを受け入れるようにする (初期値 True)
                // SaveFileDialog1.ValidateNames = True

                // ダイアログを表示し、戻り値が [OK] の場合は、選択したファイルを表示する
                if (SaveFileDialog1.ShowDialog() != DialogResult.OK)
                {
                    return string.Empty;
                }

                return SaveFileDialog1.FileName;
            }

            catch
            {
                return string.Empty;
            }
            finally
            {
                // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
                SaveFileDialog1.Dispose();
            }
        }

        /// <summary>
        /// デフォルトのパスを取得
        /// </summary>
        /// <param name="_Folder">フォルダ</param>
        /// <param name="_FileNm">ファイル名</param>
        /// <remarks></remarks>
        protected static void GetDefaultPath(ref string _Folder, ref string _FileNm)
        {
            string wk = _Folder;

            // 空白・存在しないファイルの場合
            if (ClsCheck.IsNull(wk) || !ClsFile.IsExist(wk))
            {
                if(!ClsDirectory.isExist(wk)){ 
                    _Folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    //_FileNm = string.Empty;
                }
                
            }
        }

        /// <summary>
        /// フォルダ選択ダイアログ
        /// </summary>
        /// <param name="_Folder">フォルダ</param>
        /// <param name="XmlKbnNm">Path.xmlの区分</param>
        /// <param name="_bolSaveFlg">保存フラグ（Path.xml区分ありで保存がTrueの場合選択したものを保存する）</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string FolderBrowserDialog(string _Folder, string XmlKbnNm = "", bool _bolSaveFlg = false)
        {
            // FolderBrowserDialogクラスのインスタンスを作成
            var fbd = new FolderBrowserDialog();
            try
            {
                // 上部に表示する説明テキストを指定する
                fbd.Description = "フォルダを指定してください。";
                // ルートフォルダを指定する
                // デフォルトでDesktop
                fbd.RootFolder = Environment.SpecialFolder.Desktop;

                // 最初に選択するフォルダを指定する
                // RootFolder以下にあるフォルダである必要がある

                // 空白・存在しないフォルダの場合はデスクトップ
                string arg_FileNm = "";
                GetDefaultPath(ref _Folder, ref arg_FileNm);

                fbd.SelectedPath = _Folder;
                // ユーザーが新しいフォルダを作成できるようにする
                // デフォルトでTrue
                fbd.ShowNewFolderButton = true;

                // ダイアログを表示する
                if (fbd.ShowDialog() != DialogResult.OK)
                {
                    return string.Empty;
                }

                if (!ClsCheck.IsNull(XmlKbnNm) && _bolSaveFlg)
                {
                    var pathXml = new ClsXml(Const_XML.FILE_Path);
                    pathXml.CanSavePathXml(ClsXml.XML_PATH_NODE_NAME, ClsXml.XML_PATH_MEMBER_ID, XmlKbnNm, ClsXml.XML_PATH_MEMBER_DIR, fbd.SelectedPath);
                }

                return fbd.SelectedPath;
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
                fbd.Dispose();
            }

        }
    }
}