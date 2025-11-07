
namespace CtrlLib
{
    /// <summary>コンボボックスようのデータ</summary>
    public class ComboData
    {
        /// <summary>表示テキスト</summary>
        public string Text { get; set; }
        /// <summary>値</summary>
        public object Value { get; set; }
        /// <summary>初期設定</summary>
        /// <param name="_text">表示テキスト</param>
        /// <param name="_value">値</param>
        public ComboData(string _text, object _value)
        {
            Text = _text;
            Value = _value;
        }
        /// <summary>表示テキストの取得</summary>
        /// <returns>表示テキスト</returns>
        public override string ToString()
        {
            return Text;
        }
        /// <summary>値の取得</summary>
        /// <returns>値</returns>
        public string ToValue()
        {
            return Value.ToString();
        }

    }
}