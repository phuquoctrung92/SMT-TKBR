
// Windows アプリケーション  UNLHA32.vb
// CreationTime 11/02/10 Thu  LastWriteTime 11/04/06 Wed
// ___________________________________________________________ _ _

// 
// 

using System;

namespace SmtLib
{

    // 
    public class UNLHA32
    {

        #region  Constants 

        // 
        private const string dllName = "UNLHA32.DLL";

        // ** Unlha32 API 定義
        [System.Runtime.InteropServices.DllImport(dllName, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]

        public static extern int Unlha(IntPtr hWnd, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)] string szCmdLine, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)] string szOutput, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)] int dwSize);





        // Public Declare Function Unlha Lib "unlha32" (ByVal hWindows As Long, ByVal CmdLine As String, ByVal Console As String, ByVal size As Long) As Long



        #endregion

        #region Variable Value

        private static int m_last_error_code;

        private static Exception m_last_error_exception;

        #endregion

        #region Property

        public static int LastErrorCode
        {
            get
            {
                return m_last_error_code;
            }
        }

        public static Exception LastError
        {
            get
            {
                return m_last_error_exception;
            }
        }

        #endregion

        // /* WARNING */
        /// <summary>ディスク容量が不足</summary>
        public const long ERROR_DISK_SPACE = 0x8005L;
        /// <summary>読取のみエラー</summary>
        public const long ERROR_READ_ONLY = 0x8006L;
        /// <summary>ユーザが読み飛ばし</summary>
        public const long ERROR_USER_SKIP = 0x8007L;
        /// <summary>未定義</summary>
        public const long ERROR_UNKNOWN_TYPE = 0x8008L;
        /// <summary>メソッドエラー</summary>
        public const long ERROR_METHOD = 0x8009L;
        /// <summary>パスワードエラー</summary>
        public const long ERROR_PASSWORD_FILE = 0x800AL;
        /// <summary>バージョンエラー</summary>
        public const long ERROR_VERSION = 0x800BL;
        public const long ERROR_FILE_CRC = 0x800CL;
        /// <summary>ファイルを開きにエラー</summary>
        public const long ERROR_FILE_OPEN = 0x800DL;
        public const long ERROR_MORE_FRESH = 0x800EL;
        /// <summary>存在しないエラー</summary>
        public const long ERROR_NOT_EXIST = 0x800FL;
        /// <summary>存在しているエラー</summary>
        public const long ERROR_ALREADY_EXIST = 0x8010L;
        /// <summary>ファイルが多すぎエラー</summary>
        public const long ERROR_TOO_MANY_FILES = 0x8011L;

        // /* ERROR */
        /// <summary>フォルダの作成にエラー</summary>
        public const long ERROR_MAKEDIRECTORY = 0x8012L;
        /// <summary>書き込みエラー</summary>
        public const long ERROR_CANNOT_WRITE = 0x8013L;
        public const long ERROR_HUFFMAN_CODE = 0x8014L;
        public const long ERROR_COMMENT_HEADER = 0x8015L;
        public const long ERROR_HEADER_CRC = 0x8016L;
        public const long ERROR_HEADER_BROKEN = 0x8017L;
        public const long ERROR_ARC_FILE_OPEN = 0x8018L;
        public const long ERROR_NOT_ARC_FILE = 0x8019L;
        /// <summary>読み取りエラー</summary>
        public const long ERROR_CANNOT_READ = 0x801AL;
        public const long ERROR_FILE_STYLE = 0x801BL;
        public const long ERROR_COMMAND_NAME = 0x801CL;
        public const long ERROR_MORE_HEAP_MEMORY = 0x801DL;
        /// <summary>メモリ不足</summary>
        public const long ERROR_ENOUGH_MEMORY = 0x801EL;
        /// <summary>既に実行している</summary>
        public const long ERROR_ALREADY_RUNNING = 0x801FL;
        /// <summary>キャンセルされた</summary>
        public const long ERROR_USER_CANCEL = 0x8020L;
        public const long ERROR_HARC_ISNOT_OPENED = 0x8021L;
        public const long ERROR_NOT_SEARCH_MODE = 0x8022L;
        /// <summary>対応なしエラー</summary>
        public const long ERROR_NOT_SUPPORT = 0x8023L;
        public const long ERROR_TIME_STAMP = 0x8024L;
        public const long ERROR_TMP_OPEN = 0x8025L;
        /// <summary>ファイル名が長すぎエラー</summary>
        public const long ERROR_LONG_FILE_NAME = 0x8026L;
        public const long ERROR_ARC_READ_ONLY = 0x8027L;
        /// <summary>同じファイル名エラー</summary>
        public const long ERROR_SAME_NAME_FILE = 0x8028L;
        public const long ERROR_NOT_FIND_ARC_FILE = 0x8029L;
        public const long ERROR_RESPONSE_READ = 0x802AL;
        public const long ERROR_NOT_FILENAME = 0x802BL;
        public const long ERROR_TMP_COPY = 0x802CL;
        public const long ERROR_EOF = 0x802DL;
        public const long ERROR_ADD_TO_LARC = 0x802EL;
        public const long ERROR_TMP_BACK_SPACE = 0x802FL;
        public const long ERROR_SHARING = 0x8030L;
        public const long ERROR_NOT_FIND_FILE = 0x8031L;
        public const long ERROR_LOG_FILE = 0x8032L;
        public const long ERROR_NO_DEVICE = 0x8033L;
        public const long ERROR_GET_ATTRIBUTES = 0x8034L;
        public const long ERROR_SET_ATTRIBUTES = 0x8035L;
        public const long ERROR_GET_INFORMATION = 0x8036L;
        public const long ERROR_GET_POINT = 0x8037L;
        public const long ERROR_SET_POINT = 0x8038L;
        public const long ERROR_CONVERT_TIME = 0x8039L;
        public const long ERROR_GET_TIME = 0x803AL;
        public const long ERROR_SET_TIME = 0x803BL;
        public const long ERROR_CLOSE_FILE = 0x803CL;
        public const long ERROR_HEAP_MEMORY = 0x803DL;
        public const long ERROR_HANDLE = 0x803EL;
        public const long ERROR_TIME_STAMP_RANGE = 0x803FL;
        public const long ERROR_MAKE_ARCHIVE = 0x8040L;
        public const long ERROR_NOT_CONFIRM_NAME = 0x8041L;
        public const long ERROR_UNEXPECTED_EOF = 0x8042L;
        public const long ERROR_INVALID_END_MARK = 0x8043L;
        public const long ERROR_INVOLVED_LZH = 0x8044L;
        public const long ERROR_NO_END_MARK = 0x8045L;
        public const long ERROR_HDR_INVALID_SIZE = 0x8046L;
        public const long ERROR_UNKNOWN_LEVEL = 0x8047L;
        public const long ERROR_BROKEN_DATA = 0x8048L;
        public const long ERROR_INVALID_PATH = 0x8049L;
        public const long ERROR_TOO_BIG = 0x804AL;
        public const long ERROR_EXECUTABLE_FILE = 0x804BL;
        public const long ERROR_INVALID_VALUE = 0x804CL;
        public const long ERROR_HDR_EXPLOIT = 0x804DL;

        /// <summary>
    /// 圧縮
    /// </summary>
    /// <param name="source">圧縮対象ファイルリスト</param>
    /// <param name="output_path">圧縮ファイル名</param>
    /// <remarks></remarks>
        public static void Compressing(string[] source, string output_path)


        {

            ClearError();

            if (source.Length == 0)
            {
                m_last_error_code = -1;
                return;
            }

            IntPtr hWnd;
            int iResult;
            string strInput;
            string strOutput;

            hWnd = IntPtr.Zero;

            try
            {
                foreach (string s in source)
                {


                    strInput = string.Format("a \"{0}\" \"{1}\"", output_path, s);
                    strOutput = new string(' ', 1024);

                    iResult = Unlha(hWnd, strInput, strOutput, strOutput.Length);

                    if (iResult != 0)
                    {
                        m_last_error_code = iResult;
                        m_last_error_exception = new Exception(GetErrorMsg(m_last_error_code));
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                m_last_error_code = -1;
                m_last_error_exception = ex;
            }

        }

        // ''' <summary>
        // ''' 解凍
        // ''' </summary>
        // ''' <param name="source">解凍対象ファイル</param>
        // ''' <param name="output_path">解凍ファイル出力先</param>
        // ''' <remarks></remarks>
        // Public Shared Sub Defrosting( _
        // ByVal source As String, 
        // ByVal output_path As String, 
        // Optional ByVal file_name As String = "*.*" _
        // )

        // ClearError()

        // If source.Length = 0 Then
        // m_last_error_code = -1
        // Exit Sub
        // End If

        // Dim hWnd As System.IntPtr
        // Dim iResult As Integer
        // Dim strInput As String
        // Dim strOutput As String

        // hWnd = System.IntPtr.Zero

        // If Strings.Right(output_path, 1) <> "\" Then
        // output_path &= "\"
        // End If

        // Try
        // strInput = String.Format("-xv -o ""{0}"" ""{1}"" ""{2}""", source, output_path, file_name)
        // strOutput = New String(" "c, 1024)
        // iResult = UNLHA32.UnZip(hWnd, strInput, strOutput, strOutput.Length)

        // If iResult <> 0 Then
        // m_last_error_code = iResult
        // m_last_error_exception = New Exception(GetErrorMsg(m_last_error_code))
        // Exit Sub
        // End If
        // Catch ex As Exception
        // m_last_error_code = -1
        // m_last_error_exception = ex
        // End Try

        // End Sub

        private static void ClearError()
        {
            m_last_error_code = 0;
            m_last_error_exception = null;
        }

        private static string GetErrorMsg(long error_code)

        {
            string str;

            switch (error_code)
            {
                case ERROR_DISK_SPACE: // (0x8005)
                    {
                        str = "ディスクの空き容量が足りません。";
                        break;
                    }
                case ERROR_READ_ONLY: // (0x8006)
                    {
                        str = "読込専用の同名ファイルが存在しています。";
                        break;
                    }
                case ERROR_USER_SKIP: // (0x8007)
                    {
                        str = "ユーザによりディレクトリ作成がキャンセルされました。";
                        break;
                    }
                case ERROR_UNKNOWN_TYPE: // (0x8008)
                    {
                        str = "特殊属性のファイルへ上書きできませんでした。";
                        break;
                    }
                case ERROR_FILE_CRC: // (0x800C)
                    {
                        str = "ファイルのCRCが書庫の情報と異なっています。";
                        break;
                    }
                case ERROR_FILE_OPEN: // (0x800D)
                    {
                        str = "ファイルの内部的なオープンエラーです。";
                        break;
                    }
                case ERROR_MORE_FRESH: // (0x800E)
                    {
                        str = "展開先に同名のファイルが存在しています。";
                        break;
                    }
                case ERROR_NOT_EXIST: // (0x800F)
                    {
                        str = "ファイルが展開先に存在しません｡";
                        break;
                    }
                case ERROR_ALREADY_EXIST: // (0x8010)
                    {
                        str = "同名のファイルが展開先に既に存在しています｡";
                        break;
                    }
                case ERROR_MAKEDIRECTORY: // (0x8012)
                    {
                        str = "ディレクトリの作成に失敗しました｡";
                        break;
                    }
                case ERROR_CANNOT_WRITE: // (0x8013)
                    {
                        str = "ファイルの書き込みに失敗しました。";
                        break;
                    }
                case ERROR_HUFFMAN_CODE: // (0x8014)
                    {
                        str = "書庫が壊れています｡";
                        break;
                    }
                case ERROR_HEADER_CRC: // (0x8016)
                    {
                        str = "ヘッダのCRCが一致しません。";
                        break;
                    }
                case ERROR_HEADER_BROKEN: // (0x8017)
                    {
                        str = "書庫のヘッダが破損しています｡";
                        break;
                    }
                case ERROR_ARC_FILE_OPEN: // (0x8018)
                    {
                        str = "書庫のオープンに失敗しました。";
                        break;
                    }
                case ERROR_NOT_ARC_FILE: // (0x8019)
                    {
                        str = "書庫が指定されていません。";
                        break;
                    }
                case ERROR_CANNOT_READ: // (0x801A)
                    {
                        str = "ファイルの読み込みに失敗しました。";
                        break;
                    }
                case ERROR_FILE_STYLE: // (0x801B)
                    {
                        str = "このファイルはLZH書庫ではありません。";
                        break;
                    }
                case ERROR_COMMAND_NAME: // (0x801C)
                    {
                        str = "コマンドに誤りがあります。";
                        break;
                    }
                case ERROR_MORE_HEAP_MEMORY: // (0x801D)
                    {
                        str = "作業メモリを確保できませんでした。";
                        break;
                    }
                case ERROR_ENOUGH_MEMORY: // (0x801E)
                    {
                        str = "処理結果のバッファを確保できませんでした。";
                        break;
                    }
                case ERROR_ALREADY_RUNNING: // (0x801F)
                    {
                        str = "UNLHA32.DLL が既に動作中です。";
                        break;
                    }
                case ERROR_USER_CANCEL: // (0x8020)
                    {
                        str = "ユーザにより、処理がキャンセルされました。";
                        break;
                    }
                case ERROR_HARC_ISNOT_OPENED: // (0x8021)
                    {
                        str = "HARCハンドルが不正です。";
                        break;
                    }
                case ERROR_NOT_SEARCH_MODE: // (0x8022)
                    {
                        str = "書庫の検索に失敗しました。";
                        break;
                    }
                case ERROR_NOT_SUPPORT: // (0x8023)
                    {
                        str = "サポートされていないAPIです。";
                        break;
                    }
                case ERROR_TIME_STAMP: // (0x8024)
                    {
                        str = "日時指定に誤りがあります。";
                        break;
                    }
                case ERROR_TMP_OPEN: // (0x8025)
                    {
                        str = "作業ファイルが開けません。";
                        break;
                    }
                case ERROR_LONG_FILE_NAME: // (0x8026)
                    {
                        str = "パス名が長すぎます。";
                        break;
                    }
                case ERROR_ARC_READ_ONLY: // (0x8027)
                    {
                        str = "読込専用の書庫です。";
                        break;
                    }
                case ERROR_SAME_NAME_FILE: // (0x8028)
                    {
                        str = "書庫に同じ名前のファイルが存在しています。";
                        break;
                    }
                case ERROR_NOT_FIND_ARC_FILE: // (0x8029)
                    {
                        str = "指定された書庫ファイルが見つかりません。";
                        break;
                    }
                case ERROR_RESPONSE_READ: // (0x802A)
                    {
                        str = "レスポンスファイルからの読込に失敗しました。";
                        break;
                    }
                case ERROR_NOT_FILENAME: // (0x802B)
                    {
                        str = "ファイルが指定されていません｡";
                        break;
                    }
                case ERROR_TMP_COPY: // (0x802C)
                    {
                        str = "作業用書庫へコピーできません。";
                        break;
                    }
                case ERROR_EOF: // (0x802D)
                    {
                        str = "予期しない箇所でファイルの終わりが検知されたました｡";
                        break;
                    }
                case ERROR_ADD_TO_LARC: // (0x802E)
                    {
                        str = "この書庫は操作できません。";
                        break;
                    }
                case ERROR_TMP_BACK_SPACE: // (0x802F)
                    {
                        str = "作業中にディスクの空き容量がなくなりました。";
                        break;
                    }
                case ERROR_SHARING: // (0x8030)
                    {
                        str = "ファイルの共有エラーが発生しました。";
                        break;
                    }
                case ERROR_NOT_FIND_FILE: // (0x8031)
                    {
                        str = "ファイルが見当たりません。";
                        break;
                    }
                case ERROR_LOG_FILE: // (0x8032)
                    {
                        str = "ログファイルへの書き込みに失敗しました｡";
                        break;
                    }
                case ERROR_NO_DEVICE: // (0x8033)
                    {
                        str = "デバイス(ドライブ) にアクセスできません。";
                        break;
                    }
                case ERROR_GET_ATTRIBUTES: // (0x8034)
                    {
                        str = "ファイルの属性取得に失敗しました｡";
                        break;
                    }
                case ERROR_SET_ATTRIBUTES: // (0x8035)
                    {
                        str = "ファイルの属性変更に失敗しました。";
                        break;
                    }
                case ERROR_GET_INFORMATION: // (0x8036)
                    {
                        str = "ファイルの情報取得に失敗しました。";
                        break;
                    }
                case ERROR_GET_POINT: // (0x8037)
                    {
                        str = "ファイル操作に失敗しました。";
                        break;
                    }
                case ERROR_SET_POINT: // (0x8038)
                    {
                        str = "ファイル操作に失敗しました。";
                        break;
                    }
                case ERROR_CONVERT_TIME: // (0x8039)
                    {
                        str = "タイムスタンプの変換に失敗しました。";
                        break;
                    }
                case ERROR_GET_TIME: // (0x803A)
                    {
                        str = "タイムスタンプの取得に失敗しました。";
                        break;
                    }
                case ERROR_SET_TIME: // (0x803B)
                    {
                        str = "タイムスタンプの設定に失敗しました。";
                        break;
                    }
                case ERROR_CLOSE_FILE: // (0x803C)
                    {
                        str = "ファイルをクローズできませんでした。";
                        break;
                    }
                case ERROR_HEAP_MEMORY: // (0x803D)
                    {
                        str = "ヒープメモリの解放に失敗しました。";
                        break;
                    }
                case ERROR_HANDLE: // (0x803E)
                    {
                        str = "FindClose の呼び出しに失敗しました｡";
                        break;
                    }
                case ERROR_TIME_STAMP_RANGE: // (0x803F)
                    {
                        str = "タイムスタンプが不正です。";
                        break;
                    }
                case ERROR_MAKE_ARCHIVE: // (0x8040)
                    {
                        str = "書庫が正常に作成できませんでした。";
                        break;
                    }
                case ERROR_NOT_CONFIRM_NAME: // (0x8041)
                    {
                        str = "パス名が正しく記録できませんでした。";
                        break;
                    }
                case ERROR_UNEXPECTED_EOF: // (0x8042)
                    {
                        str = "ヘッダ読み込みに失敗しました｡";
                        break;
                    }
                case ERROR_INVALID_END_MARK: // (0x8043)
                    {
                        str = "不正な終了情報が書庫のエンドマークとして記録されています。";
                        break;
                    }
                case ERROR_INVOLVED_LZH: // (0x8044)
                    {
                        str = "他の書庫に格納されている LZH書庫です。";
                        break;
                    }
                case ERROR_NO_END_MARK: // (0x8045)
                    {
                        str = "必要な終了情報が書庫のエンドマークとして記録されていません。";
                        break;
                    }
                case ERROR_HDR_INVALID_SIZE: // (0x8046)
                    {
                        str = "不正なヘッダサイズです。";
                        break;
                    }
                case ERROR_UNKNOWN_LEVEL: // (0x8047)
                    {
                        str = "unlha32.DLL で扱えないヘッダ形式です。";
                        break;
                    }
                case ERROR_BROKEN_DATA: // (0x8048)
                    {
                        str = " 格納ファイルが壊れています。";
                        break;
                    }
                case ERROR_INVALID_PATH: // (0x8049)
                    {
                        str = "パスが基準ディレクトリやルートディレクトリを越えています。";
                        break;
                    }
                case ERROR_TOO_BIG: // (0x804A)
                    {
                        str = "ファイルサイズが大きすぎます。";
                        break;
                    }
                case ERROR_EXECUTABLE_FILE: // (0x804B)
                    {
                        str = "この拡張子は抑止されています。";
                        break;
                    }
                case ERROR_INVALID_VALUE: // (0x804C)
                    {
                        str = "パラメータの整合性がとれません。";
                        break;
                    }
                case ERROR_HDR_EXPLOIT: // (0x804D)
                    {
                        str = "不正なヘッダが見つかりました。";
                        break;
                    }
                case 0L:
                    {
                        str = "正常に処理が終了しました。";
                        break;
                    }

                default:
                    {
                        str = "登録されていないエラーが発生しました。";
                        break;
                    }
            }

            return str;
        }

    }
}