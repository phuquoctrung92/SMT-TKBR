
namespace SmtLib
{

    /// <summary>エンコーディング</summary>
    public class Const_Encoding
    {
        /// <summary> エンコード(Shift-JIS) </summary>
        public static readonly System.Text.Encoding ShiftJIS = System.Text.Encoding.GetEncoding(932);
        /// <summary> エンコード(UTF-8) </summary>
        public static readonly System.Text.Encoding UTF8 = new System.Text.UTF8Encoding(false);
        /// <summary> エンコード(UTF-8 BOMあり) </summary>
        public static readonly System.Text.Encoding UTF8B = new System.Text.UTF8Encoding(true);
    }
    /// <summary>
    /// XMLファイル
    /// </summary>
    public static class Const_XML
    {
        /// <summary> システム設定 XML </summary>
        public const string FILE_SYSTEM = "SystemSettings.xml";
        /// <summary> 色設定 XML </summary>
        public const string FILE_COLOR = "Color.xml";
        /// <summary> 色設定 XML </summary>
        public const string FILE_MESSAGE = "Message.xml";
        /// <summary> 保存先デフォルト設定XMLファイル名 </summary>
        public const string FILE_Path = "Path.xml";

        /// <summary> プリンター情報設定XMLファイル名 </summary>
        public const string FILE_PRINTER = "Printer.xml";
    }
    /// <summary>
    /// 不変共通
    /// </summary>
    public static class ConstLib
    {
        #region Extension Definition

        /// <summary> 拡張子(exe) </summary>
        public const string EXTENSION_EXE = ".exe";
        /// <summary> 拡張子(Csv) </summary>
        public const string EXTENSION_CSV = ".csv";
        /// <summary> 拡張子(xml) </summary>
        public const string EXTENSION_XML = ".xml";
        /// <summary> 拡張子(log) </summary>
        public const string EXTENSION_LOG = ".log";
        /// <summary> 拡張子(Ini) </summary>
        public const string EXTENSION_INI = ".ini";
        /// <summary> 拡張子(pdf) </summary>
        public const string EXTENSION_PDF = ".pdf";
        /// <summary> 拡張子(Word(～2003)) </summary>
        public const string EXTENSION_OFFICE_WORD = ".doc";
        /// <summary> 拡張子(Excel(～2003)) </summary>
        public const string EXTENSION_OFFICE_EXCEL = ".xls";
        /// <summary> 拡張子(Access(～2003)) </summary>
        public const string EXTENSION_OFFICE_ACCESS = ".mdb";
        /// <summary> 拡張子(Word(2007～)) </summary>
        public const string EXTENSION_OFFICE_WORD_NEW = ".docx";
        /// <summary> 拡張子(Excel(2007～)) </summary>
        public const string EXTENSION_OFFICE_EXCEL_NEW = ".xlsx";
        /// <summary> 拡張子(Access(2007～)) </summary>
        public const string EXTENSION_OFFICE_ACCESS_NEW = ".accdb";
        /// <summary> 拡張子(WonderFulReport) </summary>
        public const string EXTENSION_WONDERFUL_REPORT_2000 = ".wfd";
        /// <summary> 拡張子(WonderFulReport2005) </summary>
        public const string EXTENSION_WONDERFUL_REPORT_2005 = ".wfr";

        #endregion

        #region Character Definition

        /// <summary> ハイフン「-」 </summary>
        public const string STR_HYPHEN = "-";
        /// <summary> NULL文字「NULL」 </summary>
        public const string STR_NULL = "NULL";
        /// <summary> シングルコーテーション「'」 </summary>
        public const string STR_SINGLECORTATION = "'";
        /// <summary> ダブルコーテーション「"」 </summary>
        public const string STR_DOUBLECORTATION = "\"";
        /// <summary> カンマ「,」 </summary>
        public const string STR_COMMA = ",";
        /// <summary> 半角スペース「 」 </summary>
        public const string STR_HALFSPACE = " ";
        /// <summary> 半角アスタリスク「*」 </summary>
        public const string STR_HALFASTERISK = "*";
        /// <summary> 全角アスタリスク「＊」 </summary>
        public const string STR_WIDEASTERISK = "＊";
        /// <summary> スラッシュ「/」 </summary>
        public const string STR_SLASH = "/";
        /// <summary> コロン「:」 </summary>
        public const string STR_COLON = ":";
        /// <summary> バックスラッシュ「\」 </summary>
        public const string STR_BACKSLASH = @"\";
        /// <summary> ドット「.」 </summary>
        public const string STR_DOT = ".";
        /// <summary> パーセント「%」 </summary>
        public const string STR_PERCENT = "%";
        /// <summary> バーティカルバー「|」 </summary>
        public const string STR_VERTICALBAR = "|";

        #endregion

        #region Message Categories

        /// <summary> 情報 </summary>
        public const string MESSAGE_CATEGORY_INFORMATION = "I";
        /// <summary> 注意 </summary>
        public const string MESSAGE_CATEGORY_EXCLAMATION = "E";
        /// <summary> 問い合わせ </summary>
        public const string MESSAGE_CATEGORY_QUESTION = "Q";
        /// <summary> 警告 </summary>
        public const string MESSAGE_CATEGORY_CRITICAL = "C";

        #endregion

        #region Validation Error Message
        /// <summary>入力エラーの検証</summary>
        public const string VALIDATION_ERROR_TITLE = "入力エラー";
        /// <summary>未入力エラーの検証</summary>
        public const string VALIDATION_ERROR_EMPTY = "{0}を入力してください。";
        /// <summary>未選択エラーの検証</summary>
        public const string VALIDATION_ERROR_NO_SELECTED = "{0}を選択してください。";
        /// <summary>無効なデータエラーの検証</summary>
        public const string VALIDATION_ERROR_UNJUST_VALUE = "{0}が間違っています。";
        /// <summary>オーバフロー入力エラーの検証</summary>
        public const string VALIDATION_ERROR_OVERFLOW = "{0}は{1}で入力してください。";
        /// <summary>無効なテクストエラーの検証</summary>
        public const string VALIDATION_ERROR_INVALID_CHARACTER = "{0}に禁則文字が含まれています。";
        /// <summary>無効な値エラーの検証</summary>
        public const string VALIDATION_ERROR_INVALID_CAST = "{0}に無効な値が入力されました。";
        /// <summary>マイナス値エラーの検証</summary>
        public const string VALIDATION_ERROR_INPUT_NEGATIVEVALUE = "{0}にマイナスは入力できません。";
        /// <summary>0入力エラーの検証</summary>
        public const string VALIDATION_ERROR_INPUT_ZERO_VALUE = "{0}に0は入力できません。";
        /// <summary>小数入力エラーの検証</summary>
        public const string VALIDATION_ERROR_INPUT_DECIMAL_VALUE = "{0}に小数は入力できません。";

        #endregion

        #region Button Caption
        /// <summary></summary>
        public const string CST_BTNNM = "";

        /// <summary>新規作成</summary>
        public const string CST_BTNNM_NEW = "新規作成";
        /// <summary>登録</summary>
        public const string CST_BTNNM_ENT = "登録";
        /// <summary>更新</summary>
        public const string CST_BTNNM_UPD = "更新";
        /// <summary>削除</summary>
        public const string CST_BTNNM_DEL = "削除";
        /// <summary>選択</summary>
        public const string CST_BTNNM_SEL = "選択";

        /// <summary>検索</summary>
        public const string CST_BTNNM_SER = "検索";
        /// <summary>参照</summary>
        public const string CST_BTNNM_REF = "参照";
        /// <summary>印刷</summary>
        public const string CST_BTNNM_PRN = "印刷";
        /// <summary>Excel出力</summary>
        public const string CST_BTNNM_XLS = "Excel出力";
        /// <summary>作成</summary>
        public const string CST_BTNNM_OUT = "作成";

        /// <summary>リセット</summary>
        public const string CST_BTNNM_RST = "リセット";
        /// <summary>閉じる</summary>
        public const string CST_BTNNM_CLS = "閉じる";
        /// <summary>クリア</summary>
        public const string CST_BTNNM_CLR = "クリア";

        /// <summary>追加</summary>
        public const string CST_BTNNM_ADD = "追加";
        /// <summary>実行</summary>
        public const string CST_BTNNM_EXC = "実行";

        /// <summary>CSV出力</summary>
        public const string CST_BTNNM_CSV = "CSV出力";
        /// <summary>追加取込</summary>
        public const string CST_BTNNM_IMPADD = "追加取込";
        /// <summary>全件取込</summary>
        public const string CST_BTNNM_IMPALL = "全件取込";
        /// <summary>取込</summary>
        public const string CST_BTNNM_IMP = "取込";

        #endregion

        #region CheckBox Checked Value

        /// <summary> チェック True </summary>
        public const string CST_CHECKED = "1";
        /// <summary> チェック False </summary>
        public const string CST_UNCHECKED = "0";

        #endregion

        #region Unzip エラー定数

        // /* WARNING */
        /// <summary>ディスク容量が不足</summary>
        public const int ERROR_DISK_SPACE = 0x8005;
        /// <summary>読取のみエラー</summary>
        public const int ERROR_READ_ONLY = 0x8006;
        /// <summary>ユーザが読み飛ばし</summary>
        public const int ERROR_USER_SKIP = 0x8007;
        /// <summary>未定義</summary>
        public const int ERROR_UNKNOWN_TYPE = 0x8008;
        /// <summary>メソッドエラー</summary>
        public const int ERROR_METHOD = 0x8009;
        /// <summary>パスワードエラー</summary>
        public const int ERROR_PASSWORD_FILE = 0x800A;
        /// <summary>バージョンエラー</summary>
        public const int ERROR_VERSION = 0x800B;
        public const int ERROR_FILE_CRC = 0x800C;
        /// <summary>ファイルを開きにエラー</summary>
        public const int ERROR_FILE_OPEN = 0x800D;
        public const int ERROR_MORE_FRESH = 0x800E;
        /// <summary>存在しないエラー</summary>
        public const int ERROR_NOT_EXIST = 0x800F;
        /// <summary>存在しているエラー</summary>
        public const int ERROR_ALREADY_EXIST = 0x8010;
        /// <summary>ファイルが多すぎエラー</summary>
        public const int ERROR_TOO_MANY_FILES = 0x8011;

        // /* ERROR */
        /// <summary>フォルダの作成にエラー</summary>
        public const int ERROR_MAKEDIRECTORY = 0x8012;
        /// <summary>書き込みエラー</summary>
        public const int ERROR_CANNOT_WRITE = 0x8013;
        public const int ERROR_HUFFMAN_CODE = 0x8014;
        public const int ERROR_COMMENT_HEADER = 0x8015;
        public const int ERROR_HEADER_CRC = 0x8016;
        public const int ERROR_HEADER_BROKEN = 0x8017;
        public const int ERROR_ARC_FILE_OPEN = 0x8018;
        public const int ERROR_NOT_ARC_FILE = 0x8019;
        /// <summary>読み取りエラー</summary>
        public const int ERROR_CANNOT_READ = 0x801A;
        public const int ERROR_FILE_STYLE = 0x801B;
        public const int ERROR_COMMAND_NAME = 0x801C;
        public const int ERROR_MORE_HEAP_MEMORY = 0x801D;
        /// <summary>メモリ不足</summary>
        public const int ERROR_ENOUGH_MEMORY = 0x801E;
        /// <summary>既に実行している</summary>
        public const int ERROR_ALREADY_RUNNING = 0x801F;
        /// <summary>キャンセルされた</summary>
        public const int ERROR_USER_CANCEL = 0x8020;
        public const int ERROR_HARC_ISNOT_OPENED = 0x8021;
        public const int ERROR_NOT_SEARCH_MODE = 0x8022;
        /// <summary>対応なしエラー</summary>
        public const int ERROR_NOT_SUPPORT = 0x8023;
        public const int ERROR_TIME_STAMP = 0x8024;
        public const int ERROR_TMP_OPEN = 0x8025;
        /// <summary>ファイル名が長すぎエラー</summary>
        public const int ERROR_LONG_FILE_NAME = 0x8026;
        public const int ERROR_ARC_READ_ONLY = 0x8027;
        /// <summary>同じファイル名エラー</summary>
        public const int ERROR_SAME_NAME_FILE = 0x8028;
        public const int ERROR_NOT_FIND_ARC_FILE = 0x8029;
        public const int ERROR_RESPONSE_READ = 0x802A;
        public const int ERROR_NOT_FILENAME = 0x802B;

        #endregion
    }
}