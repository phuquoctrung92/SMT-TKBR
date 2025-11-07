
namespace CtrlLib.MyControls
{
    /// <summary>有効な文字デリゲート</summary>
    /// <param name="sender">送信したオブジェクト</param>
    /// <param name="c">文字</param>
    /// <returns>True：有効、False：無効</returns>
    public delegate bool IsValidCharDelegate(object sender, char c);

    /// <summary>編集文字列</summary>
    /// <param name="sender">送信したオブジェクト</param>
    /// <param name="s">文字列</param>
    /// <returns>文字列</returns>
    public delegate string TextEditFormatDelegate(object sender, string s);

    /// <summary>表示文字列</summary>
    /// <param name="sender">送信したオブジェクト</param>
    /// <param name="s">文字列</param>
    /// <returns>文字列</returns>
    public delegate string TextDisplayFormatDelegate(object sender, string s);

}