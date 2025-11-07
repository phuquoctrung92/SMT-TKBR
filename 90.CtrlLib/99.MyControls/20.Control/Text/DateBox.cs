using System;
using model = System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static CtrlLib.MyControls.Common;
using Microsoft.VisualBasic;
using SmtLib;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// 日付共通機能
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
    public class DateBox : BaseTextBox
    {

        #region Variable Value

        private LabelBox m_label;

        private string[] m_valid_date_formats;
        private DateFormats m_date_format;


        private int m_weekday;
        const int ja_JP_LCID = 1041;
        readonly System.Globalization.CultureInfo _DateDisplayFormat_ja_JP = System.Globalization.CultureInfo.GetCultureInfo(ja_JP_LCID);




        #endregion

        #region Property




        #endregion

        #region Extend Property
        /// <summary>
        /// 日付の形式
        /// </summary>
        [model.Category("拡張")]
        public DateFormats DateFormat
        {
            get
            {
                return m_date_format;
            }
            set
            {
                int arg_MaxLength = base.MaxLength;
                string arg_formatString = FormatString;
                SetDateProperty(value, ref arg_MaxLength, ref arg_formatString);
                base.MaxLength = arg_MaxLength;
                FormatString = arg_formatString;
                m_date_format = value;
                SetPatan();
            }
        }
        /// <summary>
        /// テキストの文字数
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
        /// 日付の形式のテキスト
        /// </summary>
        [model.Category("拡張")]
        [model.ReadOnly(true)]
        public string FormatString { get; set; }

        /// <summary>
        /// 曜日表示ラベル
        /// </summary>
        [model.Category("拡張")]
        [model.Description("曜日表示ラベルの設定")]
        public bool HasWeekdayLabel { get; set; }

        /// <summary>
        /// テキストで値を取得・編集
        /// </summary>
        [model.Category("拡張")]
        [model.Browsable(false)]
        public string Value
        {
            get
            {
                return Text.Replace("/", "");
            }
            set
            {
                Text = DateDisplayFormat(this, value);
            }
        }

        /// <summary>
        /// 日付で値を取得
        /// </summary>
        public DateTime? DateValue
        {
            get
            {
                string value = base.Text;
                DateTime dt;
                if (DateTime.TryParseExact(value, m_valid_date_formats, null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    return dt;
                }
                else
                {
                    return default;
                }
            }
        }

        /// <summary>
        /// 曜日を取得
        /// </summary>
        [model.Category("拡張")]
        [model.Browsable(false)]
        public int Weekday
        {
            get
            {
                return m_weekday;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 初期設定
        /// </summary>
        public DateBox() : base()
        {

            IsValidCharacter = IsDateChar;
            TextDisplayFormat = DateDisplayFormat;

            TextAlign = HorizontalAlignment.Center;

            m_date_format = DateFormats.yyyyMMdd;
            int arg_MaxLength = base.MaxLength;
            string arg_formatString = FormatString;
            SetDateProperty(DateFormat, ref arg_MaxLength, ref arg_formatString);
            base.MaxLength = arg_MaxLength;
            FormatString = arg_formatString;

            HasWeekdayLabel = false;

            m_valid_date_formats = new string[] { "yyyy/M/d", "yyyyMM/d", "yyyy/MMdd", "yyyyMMdd", "yy/M/d", "yy/MMdd", "yyMMdd", "/M/d", "/MMdd", "M/d", "MMdd" };

            ImeMode = ImeMode.Disable;

        }

        #endregion

        #region Overrides
        /// <summary>
        /// 作成イベント
        /// </summary>
        protected override void OnCreateControl()
        {

            SetPatan();

            if (HasWeekdayLabel) // ラベル表示する場合だけコントロールを作成
            {
                m_label = new LabelBox();
                {
                    ref var withBlock = ref m_label;
                    withBlock.Font = Font;
                    withBlock.Location = new Point(Location.X + Size.Width + 1, Location.Y);
                    withBlock.Size = Size;
                    withBlock.TextAlign = ContentAlignment.MiddleCenter;
                }
                Parent.Controls.Add(m_label);
                m_label.Text = string.Empty;
            }

            m_weekday = -1;

            base.OnCreateControl();
        }

        /// <summary>
        /// コントロールを取消
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)

        {
            // コントロール削除時にラベルが存在したら一緒に削除
            if (m_label is not null)
            {
                m_label.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// キーを押下したイベント
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
        protected override void OnKeyDown(KeyEventArgs e)

        {

            if (e.KeyData == Keys.Enter)
            {

                if (!AllowEmpty || !ClsCheck.IsNull(Text))   // 必須の場合または値が入っている場合
                {
                    // If Not Common.ControlKeyDownErr(Me.LastErrorNumber, Me.Caption) Then
                    if (!ControlKeyDownErr(LastErrorNumber, this, Caption))
                    {
                        SelectAll();
                        e.Handled = true;
                        return;
                    }
                }
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
        private string DateDisplayFormat(object sender, string s)
        {
            const System.Globalization.DateTimeStyles styles = System.Globalization.DateTimeStyles.None;

            DateBox dtBox;
            DateTime dt;

            dtBox = (DateBox)sender;

            if (m_date_format == DateFormats.MM || m_date_format == DateFormats.dd)
            {
                if (!ClsCheck.IsNull(s) && s.Length == 1)
                {
                    int vi = 0;
                    if (int.TryParse(s, out vi))
                    {
                        return vi.ToString("00");
                    }
                    else
                    {
                        return s;
                    }
                }
                else
                {
                    return s;
                }
            }
            else if (DateTime.TryParseExact(s, dtBox.m_valid_date_formats, _DateDisplayFormat_ja_JP, styles, out dt) || DateTime.TryParse(s, _DateDisplayFormat_ja_JP, styles, out dt))
            {
                // 年度がないまたは年が入力できる場合
                if (dtBox.FormatString.IndexOf("yyyy") >= 0)
                {
                    // そのままの日付で表示
                    if (m_label is not null)
                        m_label.Text = dt.ToString("ddd") + "曜日";
                    m_weekday = (int)dt.DayOfWeek;
                    return dt.ToString(dtBox.FormatString);
                }
                else
                {
                    // 年度用にフォーマットする
                    if (dt.Month <= 3)
                    {
                        dt = ClsConvert.ToDate(DateTime.Now.Year + 1 + dt.ToString("/MM/dd"));
                    }
                    else
                    {
                        dt = ClsConvert.ToDate(DateTime.Now.Year + dt.ToString("/MM/dd"));
                    }
                    if (m_label is not null)
                        m_label.Text = dt.ToString("ddd") + "曜日";
                    m_weekday = (int)dt.DayOfWeek;
                    return dt.ToString(dtBox.FormatString);
                }
            }

            else
            {
                if (m_label is not null)
                    m_label.Text = string.Empty;
                m_weekday = -1;
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

        /// <summary>
        ///　日付形式から形式文字を設定
        /// </summary>
        private void SetPatan()
        {

            switch (DateFormat)
            {
                case DateFormats.yyyyMM:
                    {
                        m_valid_date_formats = new string[] { "yyyy/M", "yyyyMM", "yyyy/MM", "yy/M", "yy/MM", "yyMM", "/M", "/MM", "M", "MM" };
                        break;
                    }
                case DateFormats.yyyy:
                    {
                        m_valid_date_formats = new string[] { "yyyy", "yyy", "yy", "y" };
                        break;
                    }

                case DateFormats.MMdd:
                    {
                        m_valid_date_formats = new string[] { "MMdd", "MM/dd", "M/dd", "Mdd", "M/d", "Md" };
                        break;
                    }

                default:
                    {
                        m_valid_date_formats = new string[] { "yyyy/M/d", "yyyyMM/d", "yyyy/MMdd", "yyyyMMdd", "yy/M/d", "yy/MMdd", "yyMMdd", "/M/d", "/MMdd", "M/d", "MMdd" };
                        break;
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

            // MM,ddフォーマットの場合、Lengthが1で数時換算できる場合のみパース
            if ((m_date_format == DateFormats.MM || m_date_format == DateFormats.dd) && (!string.IsNullOrEmpty(_source.Trim()) && _source.Length == 1))
            {
                int vi = 0;
                if (int.TryParse(_source, out vi))
                {
                    _source = vi.ToString("00");
                }
            }

            if (_source is not null)
                _source = _source.Trim();

            // text edit formating.
            if (TextDisplayFormat is not null)
            {
                _source = TextDisplayFormat.Invoke(this, _source);
                Text = _source;
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

            var smsDt = DateAndTime.DateSerial(1900, 1, 1);
            if (dt < smsDt)
            {
                SetLastError(ErrorNumbers.DateError1900);
                return (int)LastErrorNumber;
            }

            // OK.
            SetLastError(ErrorNumbers.OK);
            return (int)LastErrorNumber;

        }

        #endregion

    }

}