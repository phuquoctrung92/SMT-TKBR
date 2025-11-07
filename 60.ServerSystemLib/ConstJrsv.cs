

using System.Collections.Generic;

public class ConstKrsv
{
    /// <summary> ログ表示なし </summary>
    public const string LOG_NONE = "0";
    /// <summary> ログ表示あり </summary>
    public const string LOG_DISPLAY = "1";

    /// <summary> 付属出力あり </summary>
    public const int OUT_FUZOKU_FLAG_FALSE = 0;
    /// <summary> 付属出力なし </summary>
    public const int OUT_FUZOKU_FLAG_TRUE = 1;

    /// <summary> TCP 読込みタイムアウト(ms) </summary>
    public const int TCP_READ_TIMEOUT = 30000;
    /// <summary> TCP 書込みタイムアウト(ms) </summary>
    public const int TCP_WRITE_TIMEOUT = 30000;

    /// <summary> TCP 返信データ一覧形式の明細数最大値 </summary>
    public const int TCP_ICHIRAN_MAX_DATA = 999;

    /// <summary> データ毎に分ける </summary>
    public const string SEPARATOR_Data = "\x1A";
    /// <summary> ファイル分ける </summary>
    public const string SEPARATOR_File = "\x1C";

    /// <summary> 定数受注No </summary>
    public const string JUCHU_NO = "569364";
}

public class HTErrorMessage
{
    // ↓クラウディアで使用していたメッセージ メッセージは20Byteまでに収める              "12345678901234567890"
    public const string ERR_PARAMETER = "ﾊﾟﾗﾒｰﾀに誤りあり";
    public const string ERR_CODE_NOTHING = "{0}未登録";
    public const string ERR_MASTER_UNREGISTERD = "{0}読取不備";
    public const string ERR_PASSWORD = "ﾊﾟｽﾜｰﾄﾞが不一致";
    public const string ERR_ICHIRAN_MAX_DATA = "{0}が桁数ｵｰﾊﾞｰ";
    public const string ERR_RFID_TIE_UP = "{0}紐付く衣装なし";
    public const string ERR_UPDATE = "{0}更新ｴﾗｰ";
    public const string ERR_UPDATE_EXCLUSIVE = "他者更新で書込不可";
    // public const string ERR_ETC = "{0}";
    public const string ERR_SETTING_NOTHING = "{0}未設定";
    // ↑クラウディアで使用していたメッセージ

    public const string ERR_ETC = "{0}";

    public const string ERR_FUSOKU = "パラメーターの数が不正です。";

    public const string ERR_MINYURYOKU = "{0}が入力されていません。";
    public const string ERR_NOT_EXIST = "{0}に存在していません。（{1})";
    public const string ERR_NOT_EXIST2 = "{0}が存在しませんでした。";
    public const string ERR_NOT_EXIST3 = "存在しない{0}です。";
    public const string ERR_NOT_EXIST4 = "{0}が存在しません。";
    public const string ERR_NOT_EXIST5 = "{0}に存在しない{1}です。";
    public const string ERR_NOT_EXIST6 = "{0}が存在していません。";
    public const string ERR_ILLEGAL    = "{0}が不正です。";

    public const string ERR_SHIPPAI = "{0}に失敗しました。";
    public const string ERR_AYAMARI = "{0}が誤っています。";
    public const string ERR_FUKUMI = "{0}が含まれています。";
}

public class ActionLogDetail
{
    public const string ACL_OK = "OK";
    public const string ACL_NG = "NG"; // NGのときは基本エラーメッセージ入れるからいらんかも

    public const string ACL_TOROKU = "登録処理：";
    public const string ACL_SDF_RECEIVE = "SDF受信：";
    public const string ACL_SDF_SEND = "SDF送信：";

}