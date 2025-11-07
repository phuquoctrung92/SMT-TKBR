using System;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace CtrlLib
{

    public partial class ucDateTimePicker
    {
        #region コンストラクタ
        /// <summary>初期設定</summary>
        public ucDateTimePicker()
        {

            // この呼び出しはデザイナーで必要です。
            InitializeComponent();

            // InitializeComponent() 呼び出しの後で初期化を追加します。
            AddDTBHandle();
            AddDTPHandle();
            AllowEmpty = true;
        }
        #endregion

        #region パブリックイベント
        /// <summary>フォーカス開始のイベント</summary>
        public event Dtp_EnterFocusOutEventHandler Dtp_EnterFocusOut;
        /// <summary>フォーカス開始イベントのハンドル</summary>
        public delegate void Dtp_EnterFocusOutEventHandler(object sender, EventArgs e);

        /// <summary>テキスト変更のイベント</summary>
        public event Dtp_TextChangedEventHandler Dtp_TextChanged;
        /// <summary>テキスト変更のイベントのハンドル</summary>
        public delegate void Dtp_TextChangedEventHandler(object sender, EventArgs e);

        #endregion

        /// <summary> コントロールに関連付けられた '表示名' を取得または設定します。 </summary>
        #region パブリックプロパティ
        [Category("拡張")]
        [Description("テキスト入力パターンを設定、取得します。")]
        public virtual string Caption { get; set; }

        /// <summary>空白を許可</summary>
        [Category("拡張")]
        [DefaultValue(true)]
        public virtual bool AllowEmpty { get; set; }

        /// <summary>値</summary>
        public DateTime? Value
        {
            get
            {
                DateTime dt;
                if (!DateTime.TryParse(dtb.Text, out dt))
                {
                    return default;
                }
                else
                {
                    return dt.Date;
                }
            }
            set
            {
                RemoveDTBHandle();
                RemoveDTPHandle();
                if (value is null)
                {

                    dtb.Text = string.Empty;
                    dtp.Text = string.Empty;
                }
                else
                {
                    DateTime dt = Conversions.ToDate(value);

                    if (dt < new DateTime(1753, 1, 1) || dt > new DateTime(9998, 12, 31))
                    {
                        dtb.Text = string.Empty;
                        dtp.Text = string.Empty;
                        AddDTBHandle();
                        AddDTPHandle();
                        return;
                    }

                    dtb.Text = Conversions.ToDate(value).ToString("yyyy/MM/dd");
                    dtp.Text = Conversions.ToDate(value).ToString("yyyy/MM/dd");
                }
                AddDTBHandle();
                AddDTPHandle();
            }
        }

        #endregion

        #region パブリックメソッド

        /// <summary>テキストから値をセット</summary>
        /// <param name="pstrDate">テキスト</param>
        public void SetValueFromStr(string pstrDate)
        {
            DateTime dt;
            if (!DateTime.TryParse(pstrDate, out dt))
            {
                Value = default;
            }
            else
            {
                Value = dt;
            }
        }
        /// <summary>フォーカス</summary>
        public void SetFocus()
        {
            dtb.Focus();
        }
        /// <summary>値からテキストを取得</summary>
        /// <param name="pstrFormat">フォーマット</param>
        /// <returns>テキスト</returns>
        public string GetValueStr(string pstrFormat = "yyyy/MM/dd")
        {
            string ret = string.Empty;
            var dt = Value;
            if (dt is null)
            {
                ret = string.Empty;
            }
            else
            {
                ret = Conversions.ToDate(dt).ToString(pstrFormat);
            }
            return ret;
        }

        /// <summary>キャプションをセット</summary>
        /// <param name="pstrCaption"></param>
        public void SetCaption(string pstrCaption)
        {
            Caption = pstrCaption;
            dtb.Caption = Caption;
        }
        #endregion

        #region プライベートメソッド


        private void AddDTPHandle()
        {
            dtp.ValueChanged += dtp_Changed;
        }

        private void RemoveDTPHandle()
        {
            dtp.ValueChanged -= dtp_Changed;
        }

        private void AddDTBHandle()
        {
            dtb.TextChanged += dtb_TextChanged;
            dtb.LostFocus += dtb_LostFocus;
        }

        private void RemoveDTBHandle()
        {
            dtb.TextChanged -= dtb_TextChanged;
            dtb.LostFocus -= dtb_LostFocus;
        }

        #endregion


        #region イベント

        private void ucDtp_Load(object sender, EventArgs e)
        {
            dtb.Caption = Caption;
            dtb.AllowEmpty = AllowEmpty;
        }
        /// <summary>Enterキーを押下したのイベント</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void OnEnterDown(object sender, KeyEventArgs e)
        {

            e.Handled = true;
            Control arg_current_control = dtb;
            MyControls.Common.SelectNextControl(ref arg_current_control, this, !e.Shift);
            Dtp_EnterFocusOut?.Invoke(sender, e);
        }

        private void dtb_LostFocus(object sender, EventArgs e)
        {
            // ロストフォーカス時に設定を行う。
            dtb_TextChanged(sender, e);
        }

        private void dtb_TextChanged(object sender, EventArgs e)
        {
            if (dtb.Focused)
            {
                // フォカース所持中は入力中なのでなにもしない
                return;
            }
            // 1753年問題。.NETのコンポネントはそれより過去を表示できない。
            DateTime dt;
            if (DateTime.TryParse(dtb.Text, out dt))
            {
                if (dt < new DateTime(1753, 1, 1) || dt > new DateTime(9998, 12, 31))
                {
                    return;
                }
            }
            else
            {
                // あっちで処理する
            }

            Dtp_TextChanged?.Invoke(sender, e);

            SetValueFromStr(dtb.Text);
        }

        private void dtp_Changed(object sender, EventArgs e)
        {
            SetValueFromStr(dtp.Text);
        }

        private void dtp_Enter(object sender, EventArgs e)
        {
            // フォーカス取得時に、ハンドラをいったん削除して再付与する（エラー系で消えてることがある？）
            // 付与だけだと加算されていくので一旦削除する。
            RemoveDTBHandle();
            RemoveDTPHandle();
            AddDTBHandle();
            AddDTPHandle();
            dtb.Focus();
        }

        private void ucDateTimePicker_FontChanged(object sender, EventArgs e)
        {
            dtb.Font = Font;
            dtp.Font = Font;
        }


        #endregion

        private void ucDateTimePicker_SizeChanged(object sender, EventArgs e)
        {
            dtb.Size = new System.Drawing.Size(Size.Width - 35, dtb.Size.Height);
        }
    }
}