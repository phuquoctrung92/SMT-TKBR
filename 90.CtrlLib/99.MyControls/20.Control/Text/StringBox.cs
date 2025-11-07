using System;
using model = System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SmtLib;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// 改行対応テキストボックス
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class StringBox : BaseTextBox
    {
        #region Variable Value

        private InputPatterns m_input_pattern;

        #endregion

        #region Extend Property

        /// <summary>
        /// テキスト入力パターンを設定、取得します。
        /// </summary>
        [model.Category("拡張")]
        [model.Description("テキスト入力パターンを設定、取得します。")]
        public virtual InputPatterns InputPattern
        {
            get
            {
                return m_input_pattern;
            }
            set
            {
                m_input_pattern = value;
                switch (m_input_pattern)
                {
                    case InputPatterns.All:
                    case InputPatterns.File:
                        {
                            ImeMode = ImeMode.Hiragana;
                            break;
                        }

                    case InputPatterns.KatakanaHalf:
                        {
                            ImeMode = ImeMode.KatakanaHalf;
                            break;
                        }

                    case InputPatterns.Alphabet:
                    case InputPatterns.AlphabetOnly:
                        {
                            ImeMode = ImeMode.Off;
                            break;
                        }

                    default:
                        {
                            ImeMode = ImeMode.Disable;
                            break;
                        }
                }
            }
        }

        /// <summary> バーティカルバー「|」文字を入力可能かどうか設定します。 </summary>
        [model.Category("拡張")]
        [model.DefaultValue(true)]
        public bool AllowVerticalBar { get; set; }

        /// <summary> クォーテーション文字を入力可能かどうか設定します。 </summary>
        [model.Browsable(false)]
        [model.DefaultValue(false)]
        public bool AllowQuotation { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// 初期設定
        /// </summary>
        public StringBox()
        {
            OnPasted += StringBox_OnPasted;

            m_input_pattern = InputPatterns.All;
            IsValidCharacter = IsStringChar;
            PasteType = PasteTypes.Control;
            AllowVerticalBar = true;
        }

        #endregion

        #region Overrides
        /// <summary>
        /// 作成イベント
        /// </summary>
        [DebuggerStepThrough()]
        protected override void OnCreateControl()
        {
            switch (InputPattern)
            {
                case InputPatterns.Code:
                case InputPatterns.Barcode:
                    {
                        CharacterCasing = CharacterCasing.Upper;
                        break;
                    }

                default:
                    {
                        CharacterCasing = CharacterCasing.Normal;
                        break;
                    }
            }

            // Baseでなくコントロール側で貼り付けイベントを行うための処置
            PasteType = PasteTypes.Control;

            base.OnCreateControl();
        }

        /// <summary>
        /// フォーカス中のイベント
        /// </summary>
        /// <param name="e"></param>
        [DebuggerStepThrough()]
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
        }

        /// <summary>
        /// キーを押下したイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == '\b')
            {
                // BackSpaceは許可
                return;
            }

            if (char.IsControl(e.KeyChar))   // Ctrl関係
            {
                return;
            }

            if (Common.IsInPutTxtChar(Conversions.ToString(e.KeyChar), InputPattern, MaxLength, AllowQuotation, AllowVerticalBar) != ErrorNumbers.OK)
            {
                e.Handled = true;
            }

        }

        /// <summary>
        /// キーを押下したイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            string strRep = string.Empty;

            if (e.KeyData == Keys.Enter)
            {

                EnterKeyDownBefore?.Invoke(this, e);

                if (e.Handled)
                {
                    return;
                }

                if (AllowEnterInput)
                {
                    base.OnKeyDown(e);
                    e.Handled = true;
                    return;
                }

                if (LastErrorNumber == ErrorNumbers.IsLength)
                {

                    strRep = MaxLength.ToString() + "桁 以内";

                }

                // If Not Common.ControlKeyDownErr(Me.LastErrorNumber, Me.Caption, strRep) Then
                if (!Common.ControlKeyDownErr(LastErrorNumber, this, Caption, strRep))
                {
                    SelectAll();
                    e.Handled = true;
                    return;
                }
            }
            base.OnKeyDown(e);
        }

        #endregion

        #region Extend Event

        /// <summary> Enter処理の最初 </summary>
        public event EnterKeyDownBeforeEventHandler EnterKeyDownBefore;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void EnterKeyDownBeforeEventHandler(object sender, KeyEventArgs e);

        /// <summary>
        /// StringBox コントロール内で Pasted イベントの処理をつぶしていたため、
        /// 上位で対応できるように イベントを発行します。
        /// </summary>
        public event PastingEventHandler Pasting;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void PastingEventHandler(object sender, EventArgsHandled e);

        /// <summary>
        /// 貼り付けイベント
        /// </summary>
        private void StringBox_OnPasted(EventArgsHandled e)
        {
            string s;
            char[] chars;
            int count, length;
            System.Text.StringBuilder sb;

            // StringBox コントロール内で Pasted イベントの処理をつぶしていたため、
            // 上位で対応できるように 新たにイベントを発行します。
            var ev = new EventArgsHandled();
            Pasting?.Invoke(this, ev);
            if (ev.Handled)
                return;

            s = Clipboard.GetText();

            sb = new System.Text.StringBuilder();

            if (!Multiline && s.Length != 0)
            {
                s = s.Replace(Constants.vbCrLf, ",").Replace(Constants.vbCr, ",").Replace(Constants.vbLf, ",");
                if (s.Substring(s.Length - 1, 1) == ",")
                {
                    s = s.Substring(0, s.Length - 1);
                }
            }


            for (int i = 0, loopTo = s.Length - 1; i <= loopTo; i++)
            {
                if (ValidateText(Conversions.ToString(s[i])) == (int)ErrorNumbers.OK)
                {
                    sb.Append(s[i]);
                }
            }
            s = sb.ToString();

            if (0 < MaxLength)
            {

                count = MaxLength - ClsCheck.GetLengthAsByte(Text) + ClsCheck.GetLengthAsByte(SelectedText);
                chars = s.ToCharArray();
                var loopTo1 = chars.Length - 1;
                for (length = 0; length <= loopTo1; length++)
                {
                    // count -= ClsCheck.GetLenB(chars.ToString.Substring(length, 1))
                    count -= ClsCheck.GetLengthAsByte(Conversions.ToString(chars[length]));
                    if (count < 0)
                    {
                        s = s.Substring(0, length);
                        break;
                    }
                }
            }
            SelectedText = s;
            e.Handled = true;
        }

        #endregion

        #region Method
        /// <summary>
        /// 入力した値は文字かチェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="c">文字</param>
        /// <returns></returns>
        public static bool IsStringChar(object sender, char c)
        {
            // 禁則文字チェック
            if (((StringBox)sender).m_input_pattern == InputPatterns.Barcode)
            {
                if (!ClsCheck.IsProhibitionCharacter(Conversions.ToString(c), ConstLib.STR_HALFASTERISK, ((StringBox)sender).AllowQuotation, ((StringBox)sender).AllowVerticalBar))
                {
                    return true;
                }
            }
            else if (!ClsCheck.IsProhibitionCharacter(Conversions.ToString(c), _allow_quotation: ((StringBox)sender).AllowQuotation, _allow_VerticalBar: ((StringBox)sender).AllowVerticalBar))
            {
                return true;
            }

            return false;
        }

        #endregion

        #region Control Validation
        /// <summary>
        /// 無効なテキストかをチェック
        /// </summary>
        /// <param name="_source"></param>
        /// <returns>ErrorNumbers</returns>
        public override int ValidateText(string _source)
        {
            if (_source is not null && TextEditFormat is not null)
            {
                // text edit formating.
                _source = TextEditFormat.Invoke(this, _source);
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

            if (ClsCheck.GetLengthAsByte(_source) > MaxLength)
            {
                SetLastError(ErrorNumbers.IsLength);
                return (int)LastErrorNumber;
            }

            // エラーチェック
            SetLastError(Common.IsInPutTxtChar(_source, InputPattern, MaxLength, AllowQuotation));

            return (int)LastErrorNumber;
        }
        #endregion
    }
}