using System;
using model = System.ComponentModel;
using System.Windows.Forms;
using static CtrlLib.MyControls.Common;
using SmtLib;


namespace CtrlLib.MyControls
{

    /// <summary>
    /// 時間ボックスの共通機能
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    /// <memo>
    /// MM/ddがないフォーマットでのLabel設定は表示されますがおかしくなるためしないようにしてください。
    /// Labelは曜日(何曜日)表示用です。
    /// </memo>
    public class TimeBox : BaseTextBox
    {

        #region Variable Value

        private string[] m_valid_time_formats;
        private TimeFormats m_time_format;

        private ImeMode m_ime_mode;

        const int ja_JP_LCID = 1041;
        private readonly System.Globalization.CultureInfo _TimeDisplayFormat_ja_JP = System.Globalization.CultureInfo.GetCultureInfo(ja_JP_LCID);
        #endregion

        #region Property
        /// <summary>
        /// IMEモード
        /// </summary>
        [model.DefaultValue(ImeMode.Disable)]
        public new ImeMode ImeMode
        {
            get
            {
                return m_ime_mode;
            }
            set
            {
                m_ime_mode = value;
                base.ImeMode = value;
            }
        }

        #endregion

        #region Extend Property

        /// <summary>
        /// 時間形式
        /// </summary>
        [model.Category("拡張")]
        public TimeFormats TimeFormat
        {
            get
            {
                return m_time_format;
            }
            set
            {
                int arg_MaxLength = base.MaxLength;
                string arg_formatString = FormatString;
                SetTimeProperty(value, ref arg_MaxLength, ref arg_formatString);
                base.MaxLength = arg_MaxLength;
                FormatString = arg_formatString;
                m_time_format = value;
            }
        }

        /// <summary>
        /// 最大の桁数
        /// </summary>
        [model.Category("拡張")]
        [model.ReadOnly(true)]
        public override int MaxLength
        {
            get
            {
                return base.MaxLength;
            }
            set
            {
                base.MaxLength = value;
            }
        }

        /// <summary>
        /// 形式文字
        /// </summary>
        [model.Category("拡張")]
        [model.ReadOnly(true)]
        public string FormatString { get; set; }

        /// <summary>
        /// 値
        /// </summary>
        [model.Category("拡張")]
        [model.ReadOnly(true)]
        public string Value
        {
            get
            {
                return Text.Replace(":", "");
            }
            set
            {
                Text = TimeDisplayFormat(this, value);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 初期設定
        /// </summary>
        public TimeBox() : base()
        {

            IsValidCharacter = IsTimeChar;
            TextDisplayFormat = TimeDisplayFormat;

            TextAlign = HorizontalAlignment.Center;

            m_time_format = TimeFormats.HHmm;
            int arg_MaxLength = base.MaxLength;
            string arg_formatString = FormatString;
            SetTimeProperty(TimeFormat, ref arg_MaxLength, ref arg_formatString);
            base.MaxLength = arg_MaxLength;
            FormatString = arg_formatString;

            m_valid_time_formats = new string[] { "HH:mm", "HH", "mm" };

            ImeMode = ImeMode.Disable;

        }

        #endregion

        #region Overrides
        /// <summary>
        /// 作成イベント
        /// </summary>
        protected override void OnCreateControl()
        {

            switch (TimeFormat)
            {

                case TimeFormats.HH:
                    {
                        m_valid_time_formats = new string[] { "HH", "H" };

                        break;
                    }

                case TimeFormats.mm:
                    {
                        m_valid_time_formats = new string[] { "mm", "m" };

                        break;
                    }

                default:
                    {
                        m_valid_time_formats = new string[] { "HH:mm", "HHmm", "HH", "mm" };



                        break;
                    }
            }


            base.OnCreateControl();
        }

        /// <summary>
        /// コントロールを取消
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        /// <summary>
        /// KeyDown
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // 必須の場合または値が入っている場合
            if (e.KeyData == Keys.Enter && (!AllowEmpty || !ClsCheck.IsNull(Text)) && !ControlKeyDownErr(LastErrorNumber, this, Caption))
            {
                SelectAll();
                e.Handled = true;
                return;
            }

            base.OnKeyDown(e);
        }

        #endregion

        #region Method

        /// <summary>
        /// 表示用に編集
        /// </summary>
        /// <remarks></remarks>
        /// <memo>
        /// 年度があるかつ年を入力しない場合
        /// １～３月は年度を＋１して表示
        /// 年度があるけど年が入力できる場合
        /// 入力された値で表示
        /// </memo>
        private string TimeDisplayFormat(object sender, string s)


        {
            const System.Globalization.DateTimeStyles styles = System.Globalization.DateTimeStyles.None;

            TimeBox dtBox;
            DateTime dt;

            dtBox = (TimeBox)sender;

            if (DateTime.TryParseExact(s, dtBox.m_valid_time_formats, _TimeDisplayFormat_ja_JP, styles, out dt) || DateTime.TryParse(s, _TimeDisplayFormat_ja_JP, styles, out dt))
            {
                // 年度がないまたは年が入力できる場合
                return dt.ToString(dtBox.FormatString);
            }
            else
            {
                return s;
            }

        }

        /// <summary>
        /// 日付形式に無効な文字かをチェック
        /// </summary>
        /// <param name="sender">実行したオブジェクト</param>
        /// <param name="c">チェック文字</param>
        /// <returns>Boolean</returns>
        private bool IsDateChar(object sender, char c)
        {

            switch (c)
            {
                case var @case when '/' <= @case && @case <= '9':
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }
        }

        /// <summary>
        /// 時間形式に無効な文字かをチェック
        /// </summary>
        /// <param name="sender">実行したオブジェクト</param>
        /// <param name="c">チェック文字</param>
        /// <returns>Boolean</returns>
        private bool IsTimeChar(object sender, char c)
        {

            switch (c)
            {
                case var @case when '0' <= @case && @case <= ':':
                    {
                        return true;
                    }

                default:
                    {
                        return false;
                    }
            }

        }

        #endregion

        #region Control Validation
        /// <summary>
        /// 日付形式に無効なテキストかをチェック
        /// </summary>
        /// <param name="_source">テキスト</param>
        /// <returns>ErrorNumbers</returns>
        public override int ValidateText(string _source)

        {

            DateTime dt;

            if (_source is not null)
                _source = _source.Trim();

            // text edit formating.
            if (TextDisplayFormat is not null)
            {
                try
                {
                    _source = TextDisplayFormat.Invoke(this, _source);
                    Text = _source;
                }
                catch
                {
                }
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

            // invalid chars.
            if (IsValidCharacter is not null)
            {
                for (int index = 0, loopTo = _source.Length - 1; index <= loopTo; index++)
                {
                    if (!IsValidCharacter.Invoke(this, _source[index]))
                    {
                        SetLastError(ErrorNumbers.InvalidCharError);
                        return (int)LastErrorNumber;
                    }
                }
            }

            dt = ClsConvert.ToDateExact(_source, FormatString);

            if (dt == default)
            {
                SetLastError(ErrorNumbers.IsInputErr);
                return (int)LastErrorNumber;
            }

            // OK.
            SetLastError(ErrorNumbers.OK);
            return (int)LastErrorNumber;

        }

        #endregion

    }

}