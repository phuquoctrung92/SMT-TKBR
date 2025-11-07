using System;
using model = System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SmtLib;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// 数字ボックス共通機能
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class NumberBox : BaseTextBox
    {

        #region Constant Value

        /// <summary> 整数部指定可能最大桁数 </summary>
        private const int MAX_INTEGER_LENGTH = 15;
        /// <summary> 小数部指定可能最大桁数 </summary>
        private const int MAX_DECIMAL_LENGTH = 4;

        #endregion

        #region Variable Value
        /// <summary> 整数部最大桁数 </summary>
        private int m_integer_length = 7;
        /// <summary> 小数部最大桁数 </summary>
        private int m_decimal_length = 0;
        #endregion
        /// <summary>  </summary>
        private bool m_AllowNegativeValue = true;

        #region Extend Property

        /// <summary>
        /// 現在の値を取得します。
        /// </summary>
        [model.Browsable(false)]
        [model.ReadOnly(true)]
        public string Value
        {
            get
            {
                return Text.Replace(",", "");
            }
            set
            {
                Text = DisplayFormat(this, value);
            }
        }

        /// <summary>
        /// 現在の値を数値型で取得します。
        /// 数値に変換できなかった場合は 0 を返します。
        /// </summary>
        [model.Browsable(false)]
        [model.ReadOnly(true)]
        public int IntValue
        {
            get
            {
                var num = ClsConvert.ToInteger(Text.Replace(",", ""));
                if(num == 0)
                {
                    Text = "0";
                }
                return num;
            }
            set
            {
                Text = DisplayFormat(this, value.ToString());
            }
        }


        /// <summary>
        /// 現在の値を取得します。
        /// 入力されていない場合は Null 値を返します。
        /// </summary>
        [model.Browsable(false)]
        [model.ReadOnly(true)]
        public object DbValue
        {
            get
            {
                string ret = Text.Replace(",", "");
                if (string.IsNullOrEmpty(ret))
                {
                    return DBNull.Value;
                }
                else
                {
                    return ret;
                }
            }
        }

        /// <summary>
        /// 負数の入力を許可するかどうかを取得または設定します。
        /// </summary>
        [model.Category("拡張")]
        [model.Description("コントロールに負数の入力を許可するかどうかを示します。")]
        [model.DefaultValue(true)]
        public bool AllowNegativeValue { get { return m_AllowNegativeValue; } set { m_AllowNegativeValue = value; } }

        /// <summary>
        /// 整数部に入力できる最大桁数を取得または設定します。
        /// </summary>
        [model.Category("拡張")]
        [model.Description("コントロールに入力できる整数部の最大桁数を指定します。1 以下の値は指定できません。")]
        [model.DefaultValue(7)]
        public int IntegerLength
        {
            get
            {
                return m_integer_length;
            }
            set
            {
                // 有効な値であれば更新
                if (value > 0 && value <= MAX_INTEGER_LENGTH)
                {
                    m_integer_length = value;
                }
            }
        }

        /// <summary>
        /// 小数部に入力できる最大桁数を取得または設定します。
        /// </summary>
        [model.Category("拡張")]
        [model.Description("コントロールに入力できる小数部の最大桁数を指定します。0 を指定した場合、小数部は入力できません。")]
        [model.DefaultValue(0)]
        public int DecimalLength
        {
            get
            {
                return m_decimal_length;
            }
            set
            {
                // 有効な値であれば更新
                if (value >= 0 && value <= MAX_DECIMAL_LENGTH)
                {
                    m_decimal_length = value;
                }
            }
        }

        /// <summary>
        /// カンマ区割り
        /// </summary>
        [model.Category("拡張")]
        [model.Description("数値をカンマ区切りする場合、True を指定します。")]
        public bool DisplayWithFormat { get; set; }


        #endregion

        #region Constructor
        /// <summary>
        /// 初期設定
        /// </summary>
        public NumberBox() : base()
        {
            OnPasted += NumberBox_OnPasted;

            // 右寄せ
            TextAlign = HorizontalAlignment.Right;
            // IME無効
            ImeMode = ImeMode.Disable;
            // 自コントロールのイベントを優先する
            PasteType = PasteTypes.Control;

            TextDisplayFormat = DisplayFormat;
            DisplayWithFormat = true;
        }
        #endregion

        #region Overrides
        /// <summary>
        /// フォーカスのイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)

        {
            base.OnEnter(e);

            if (string.IsNullOrEmpty(Text))
            {
                return;
            }

            // 区切り文字を取り除く
            Text = Strings.Replace(Text, ConstLib.STR_COMMA, string.Empty);

        }

        /// <summary>
        /// キーを押下したイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            int pos = 0;                         // カーソル位置
            decimal val = 0m;                         // 入力値

            string integerValue = string.Empty;     // 整数値
            string decimalValue = string.Empty;     // 小数値
            int decimalPos = 0;                  // 小数点位置

            try
            {
                if (char.IsControl(e.KeyChar))   // Ctrl関係のショートカットはOK
                {
                    return;
                }

                // 区切り文字を取り除く
                string wkStr = Strings.Replace(Text, ConstLib.STR_COMMA, string.Empty);
                int wkPos = 0;                   // カーソル位置(カンマ除く)
                string chkStr = string.Empty;       // カンマ、ドット入力検証文字列

                if (!string.IsNullOrEmpty(wkStr))
                {
                    // 現在のカーソルのポジション
                    pos = SelectionStart;
                    wkPos = pos;
                    chkStr = Text.Substring(0, pos) + Text.Substring(pos + SelectionLength);

                    if (!ClsCheck.IsNull(wkStr))
                    {
                        if (Strings.InStr(Text, ConstLib.STR_COMMA) > 0)
                        {
                            // カンマの文字数分詰める
                            wkPos -= Text.Length - wkStr.Length;
                        }
                        if (wkPos < 0)
                        {
                            wkPos = 0;
                        }
                    }
                    // 小数点位置を取得する
                    decimalPos = Strings.InStr(wkStr, ConstLib.STR_DOT);

                    // 現在のテキストが範囲選択されている場合
                    if (SelectionLength != 0)
                    {
                        // 現在のテキストから選択範囲のテキストを取り除く
                        if (wkStr.Length > wkPos + SelectionLength)
                        {
                            wkStr = wkStr.Substring(0, wkPos) + wkStr.Substring(wkPos + SelectionLength);
                        }
                        else
                        {
                            wkStr = wkStr.Substring(0, wkPos);
                        }
                        // 小数点位置を再取得する
                        if (Strings.InStr(wkStr, ConstLib.STR_DOT) == 0)
                        {
                            decimalPos = 0;
                        }
                        else
                        {
                            decimalPos = Strings.InStr(wkStr, ConstLib.STR_DOT);
                        }
                    }

                    if (Information.IsNumeric(wkStr))
                    {
                        // テキスト値を Decimal に型変換する
                        val = Conversions.ToDecimal(wkStr);
                    }
                }

                switch (e.KeyChar)
                {

                    case '\b':
                        {
                            break;
                        }
                    // BackSpaceは許可

                    case var @case when @case == Strings.Asc(ConstLib.STR_HYPHEN):       // ハイフン(マイナス)
                        {
                            // マイナス入力が許可されているか
                            if (m_AllowNegativeValue)
                            {
                                if (val == 0m)
                                {
                                    if ((wkStr ?? "") == ConstLib.STR_HYPHEN)
                                    {
                                        Text = string.Empty;
                                        // カーソル位置の補正
                                        if (pos != 0)
                                        {
                                            pos -= 1;
                                        }
                                        e.Handled = true;
                                        SelectionStart = pos;
                                    }
                                    else if (!string.IsNullOrEmpty(wkStr))
                                    {
                                        e.Handled = true;
                                        SelectionStart = pos;
                                    }
                                }
                                else
                                {
                                    // 入力値に -1 をかけて、更新後の値を計算しておく
                                    val *= -1;
                                    // カーソル位置の補正
                                    if (val < 0m)
                                    {
                                        pos += 1;
                                        Text = ConstLib.STR_HYPHEN + Text;
                                    }
                                    else
                                    {
                                        Text = Text.Replace(ConstLib.STR_HYPHEN, string.Empty);
                                        if (pos != 0)
                                        {
                                            pos -= 1;
                                        }
                                    }
                                    e.Handled = true;
                                    SelectionStart = pos;
                                }
                            }
                            else
                            {
                                // テキストを更新する
                                Text = Text.Replace(ConstLib.STR_HYPHEN, string.Empty);
                                e.Handled = true;
                                SelectionStart = pos;
                            }

                            break;
                        }

                    case var case1 when case1 == Strings.Asc(ConstLib.STR_DOT):          // ドット(小数点)
                        {
                            // 小数部の入力が許可されていない場合
                            if (m_decimal_length == 0)
                            {
                                e.Handled = true;
                                return;
                            }
                            // 未入力の場合
                            if (ClsCheck.IsNull(wkStr) || (wkStr ?? "") == ConstLib.STR_HYPHEN)
                            {
                                Text = "0.";
                                SelectionStart = 2;
                                e.Handled = true;
                                return;
                            }
                            // 先頭での入力はエラー
                            if (pos == 0)
                            {
                                e.Handled = true;
                                return;
                            }
                            // 挿入位置の前後に "," が含まれていないか
                            if (pos == chkStr.Length)
                            {
                                if ((chkStr.Substring(pos - 1, 1) ?? "") == ConstLib.STR_COMMA)
                                {
                                    e.Handled = true;
                                    return;
                                }
                            }
                            else if ((chkStr.Substring(pos - 1, 1) ?? "") == ConstLib.STR_COMMA || (chkStr.Substring(pos, 1) ?? "") == ConstLib.STR_COMMA)
                            {
                                e.Handled = true;
                                return;
                            }

                            // 選択範囲テキストを除くテキストに "." が含まれていないか
                            if (decimalPos > 0)
                            {
                                e.Handled = true;
                                return;
                            }

                            // 整数部と小数部に分割
                            integerValue = wkStr.Substring(0, wkPos);
                            decimalValue = wkStr.Substring(wkPos, wkStr.Length - wkPos);

                            // 整数桁、もしくは小数桁が最大値を超える場合
                            if (!string.IsNullOrEmpty(integerValue) && m_integer_length > 0 && Math.Abs(Conversions.ToDecimal(integerValue)).ToString().Length > m_integer_length)
                            {
                                e.Handled = true;
                                return;
                            }
                            if (decimalValue.Length > m_decimal_length)
                            {
                                e.Handled = true;
                                return;
                            }

                            break;
                        }

                    case var case2 when case2 == Strings.Asc(ConstLib.STR_COMMA):        // カンマ(区切り文字)
                        {
                            // 先頭での入力はエラー
                            if (pos == 0)
                            {
                                e.Handled = true;
                                return;
                            }
                            // マイナス値の場合、ハイフン直後の入力は不可
                            if (pos == 1 && !ClsCheck.IsNull(wkStr) && (wkStr.Substring(0, 1) ?? "") == ConstLib.STR_HYPHEN)
                            {
                                e.Handled = true;
                                return;
                            }
                            // 挿入位置の前後に "," が含まれていないか
                            if (pos == chkStr.Length)
                            {
                                if ((chkStr.Substring(pos - 1, 1) ?? "") == ConstLib.STR_COMMA)
                                {
                                    e.Handled = true;
                                    return;
                                }
                            }
                            else if ((chkStr.Substring(pos - 1, 1) ?? "") == ConstLib.STR_COMMA || (chkStr.Substring(pos, 1) ?? "") == ConstLib.STR_COMMA)
                            {
                                e.Handled = true;
                                return;
                            }
                            if (decimalPos == 0)
                            {
                                // 整数部の最大桁が設定されている場合
                                if (m_integer_length > 0)
                                {
                                    if (ClsCheck.IsNull(wkStr) || (wkStr.Replace(ConstLib.STR_HYPHEN, string.Empty).Length >= m_integer_length && wkPos >= wkStr.Length))
                                    {
                                        e.Handled = true;
                                        return;
                                    }
                                    // 整数部が最大桁入力されている場合
                                    else if (SelectionLength > 0)
                                    {
                                        wkPos += SelectionLength - 1;
                                    }
                                }
                            }
                            else
                            {
                                // 小数部での入力は不可
                                if (wkPos >= decimalPos - 1)
                                {
                                    e.Handled = true;
                                    return;
                                }
                                integerValue = wkStr.Substring(0, decimalPos - 1);
                                // 整数部の最大桁が設定されている場合
                                if (m_integer_length > 0 && (wkPos >= integerValue.Length || (integerValue.Replace(ConstLib.STR_HYPHEN, string.Empty).Length >= m_integer_length && wkPos >= integerValue.Length)))
                                {
                                    // 整数部が最大桁入力されている場合
                                    e.Handled = true;
                                    return;
                                }
                            }
                            break;
                        }
                    default:
                        {

                            // 全角が含まれる場合はエラー
                            // 数値以外は不可
                            if (!ClsCheck.IsNarrow(Conversions.ToString(e.KeyChar)) || !Information.IsNumeric(e.KeyChar))
                            {
                                e.Handled = true;
                                return;
                            }

                            if (!string.IsNullOrEmpty(wkStr))
                            {

                                // カーソル位置が先頭で、マイナス値の場合かつ数値が入力された場合
                                if (wkPos == 0 && (wkStr.Substring(0, 1) ?? "") == ConstLib.STR_HYPHEN)
                                {
                                    e.Handled = true;
                                    return;
                                }

                                if (decimalPos == 0)
                                {
                                    // 整数部
                                    integerValue = wkStr;
                                    // 更新後の値をセット
                                    integerValue = integerValue.Substring(0, wkPos) + e.KeyChar + integerValue.Substring(wkPos);
                                }
                                else
                                {
                                    // 整数部と小数部に分割
                                    integerValue = wkStr.Substring(0, decimalPos - 1);
                                    decimalValue = wkStr.Substring(decimalPos);
                                    // カーソル位置で判定
                                    if (wkPos < decimalPos)
                                    {
                                        // 更新後の値をセット
                                        integerValue = integerValue.Substring(0, wkPos) + e.KeyChar + integerValue.Substring(wkPos);
                                    }
                                    else
                                    {
                                        // 更新後の値をセット
                                        decimalValue = decimalValue.Substring(0, wkPos - decimalPos) + e.KeyChar + decimalValue.Substring(wkPos - decimalPos);
                                    }
                                }

                                // 整数部の最大桁が設定されている場合
                                if (m_integer_length > 0 && !string.IsNullOrEmpty(integerValue) && Strings.Replace(integerValue, ConstLib.STR_HYPHEN, string.Empty).Length > m_integer_length)
                                {
                                    e.Handled = true;
                                    return;
                                }

                                // 小数部の最大桁が設定されている場合
                                if (m_decimal_length > 0 && decimalValue.Length > m_decimal_length)
                                {
                                    e.Handled = true;
                                    return;
                                }
                            }
                            break;
                        }
                }
            }

            catch (Exception ex)
            {
                if (ex is OverflowException)
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// キーを押下したイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string RepValue = DecimalLength == 0 ? IntegerLength + "桁 以内" : " 整数 " + IntegerLength + "桁," + " 小数 " + DecimalLength + "桁" + " 以内";

                // If Not Common.ControlKeyDownErr(Me.LastErrorNumber, Me.Caption, RepValue) Then
                if (!Common.ControlKeyDownErr(LastErrorNumber, this, Caption, RepValue))
                {
                    SelectAll();
                    e.Handled = true;
                    return;
                }
            }

            base.OnKeyDown(e);
        }

        #endregion

        #region Control Events
        /// <summary>
        /// 貼り付けイベント
        /// </summary>
        /// <param name="e"></param>
        private void NumberBox_OnPasted(EventArgsHandled e)
        {
            // Disable 以外は親コントロールのイベントに依存
            if (PasteType != PasteTypes.Control)
            {
                return;
            }

            string s = Clipboard.GetText();
            int pos = 0;                         // カーソル位置

            string integerValue = string.Empty;     // 整数値
            string decimalValue = string.Empty;     // 小数値
            int decimalPos = 0;                  // 小数点位置
            string wkStr;                            // 貼り付け後の文字列

            // 全角が含まれる場合はエラー
            // 数値以外はエラー
            if (!ClsCheck.IsNarrow(s) || !Information.IsNumeric(s))
            {
                e.Handled = true;
                return;
            }

            // 現在のテキスト内容と貼り付け内容を結合する
            else if (SelectionStart == 0)
            {
                if (SelectionLength == 0)
                {
                    wkStr = s + Text;
                }
                else
                {
                    wkStr = s + Text.Substring(SelectionLength);
                }
            }
            else if (SelectionLength == 0)
            {
                wkStr = Text.Substring(0, SelectionStart) + s + Text.Substring(SelectionStart);
            }
            else
            {
                wkStr = Text.Substring(0, SelectionStart) + s + Text.Substring(SelectionStart + SelectionLength);
            }

            pos = SelectionStart;

            // 貼り付け後のテキストから小数点位置を取得する
            decimalPos = Strings.InStr(wkStr, ConstLib.STR_DOT);

            if (decimalPos == 0)
            {
                // 整数部
                integerValue = wkStr;
            }
            else
            {
                // 整数部と小数部に分割
                integerValue = wkStr.Substring(0, decimalPos - 1);
                decimalValue = wkStr.Substring(decimalPos);
            }

            // 整数部の最大桁が設定されている場合
            // '区切り文字を除いた桁数で判定
            if (m_integer_length > 0 && !string.IsNullOrEmpty(integerValue) && (Strings.Replace(integerValue.Replace(ConstLib.STR_COMMA, string.Empty), ConstLib.STR_HYPHEN, string.Empty).Length > m_integer_length))
            {
                e.Handled = true;
                return;
            }

            // 小数部の最大桁が設定されている場合
            if (m_decimal_length > 0 && decimalValue.Length > m_decimal_length)
            {
                e.Handled = true;
                return;
            }

            // テキストを更新
            Text = wkStr;
            // カーソル位置をセット
            SelectionStart = pos + s.Length;
        }
        #endregion

        #region Method

        /// <summary> 画面表示用にフォーマットする </summary>
        private string DisplayFormat(object sender, string s)
        {
            decimal dc;
            string formatString;

            if (DisplayWithFormat)
            {
                formatString = "#,##0";
            }
            else
            {
                formatString = "###0";
            }

            if (ClsCheck.IsNull(s))
            {
                return string.Empty;
            }

            // フォーマット書式
            if (m_decimal_length > 0)
            {
                formatString += ConstLib.STR_DOT;
                for (int i = 0, loopTo = m_decimal_length - 1; i <= loopTo; i++)
                    formatString += "0";
            }

            dc = ClsConvert.ToDecimal(s);
            // 2015.9.1 0でもフォーマット指定に従って表示する。
            // If dc = 0 Then
            // Return "0"
            // End If
            return dc.ToString(formatString);
        }

        #endregion

        #region Control Validation

        /// <summary>
        /// 入力値の検証を行います。
        /// </summary>
        public override int ValidateText(string _source)
        {
            try
            {
                if (_source is not null && TextEditFormat is not null)
                {
                    // text edit formating.
                    _source = TextEditFormat.Invoke(this, _source);
                }

                if ((_source ?? "") == ConstLib.STR_HYPHEN)
                {
                    // ハイフンのみの場合はテキストを消去する
                    _source = string.Empty;
                }

                // is empty.
                if (string.IsNullOrEmpty(_source))
                {
                    if (AllowEmpty)
                    {
                        SetLastError(ErrorNumbers.OK);
                    }
                    else
                    {
                        SetLastError(ErrorNumbers.IsTextEmpty);
                    }
                    return (int)LastErrorNumber;
                }

                string formatString;

                if (DisplayWithFormat)
                {
                    formatString = "#,##0";
                }
                else
                {
                    formatString = "###0";
                }

                decimal textValue;
                int decimalPos = 0;

                // カンマを取り除く
                if (string.IsNullOrEmpty(Strings.Replace(_source, ConstLib.STR_COMMA, string.Empty)))
                {
                    SetLastError(ErrorNumbers.InvalidCastError);
                    return (int)LastErrorNumber;
                }
                if ((_source ?? "") == ConstLib.STR_DOT)
                {
                    // ドットのみの場合は0に置き換える
                    textValue = 0m;
                }
                else
                {
                    textValue = Conversions.ToDecimal(Strings.Replace(_source, ConstLib.STR_COMMA, string.Empty));
                }

                // フォーマット書式
                if (m_decimal_length > 0)
                {
                    formatString += ConstLib.STR_DOT;
                    for (int i = 0, loopTo = m_decimal_length - 1; i <= loopTo; i++)
                        formatString += "0";
                }

                // マイナス入力
                if (!m_AllowNegativeValue && textValue < 0m)
                {
                    SetLastError(ErrorNumbers.MinusError);
                    return (int)LastErrorNumber;
                }

                // 整数部の最大桁が設定されている場合
                if (m_integer_length > 0 && Conversion.Fix(Math.Abs(textValue)).ToString().Length > m_integer_length)
                {
                    // マイナス入力があるので絶対値で判定
                    SetLastError(ErrorNumbers.IsLength);
                    return (int)LastErrorNumber;
                }

                // 小数点位置を取得する
                decimalPos = Strings.InStr(textValue.ToString(), ConstLib.STR_DOT);

                // 小数部の最大桁が設定されている場合
                if (decimalPos > 0 && m_decimal_length == 0)
                {
                    SetLastError(ErrorNumbers.DecimalError);
                    return (int)LastErrorNumber;
                }
                // 小数部を切り出す
                else if (decimalPos > 0 && textValue.ToString().Substring(decimalPos).Length > m_decimal_length)
                {
                    SetLastError(ErrorNumbers.IsLength);
                    return (int)LastErrorNumber;
                }

                // 入力値をフォーマットする
                Text = textValue.ToString(formatString);

                // OK.
                SetLastError(ErrorNumbers.OK);
                return (int)LastErrorNumber;
            }

            catch (Exception ex)
            {
                if (ex is OverflowException)
                {
                    SetLastError(ErrorNumbers.IsLength);
                }
                else if (ex is InvalidCastException)
                {
                    SetLastError(ErrorNumbers.InvalidCastError);
                }
                return (int)LastErrorNumber;
            }
        }
        #endregion
    }
}