using System;
using System.Collections.Generic;

using model = System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// チェックボックスリスト
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class CheckedListBox : System.Windows.Forms.CheckedListBox
    {


        #region Variable Value

        private readonly List<ComboData> mDataList;

        private string m_caption;


        #endregion

        #region Extend Property

        /// <summary> 空の文字列を許可するかどうかを示す値を取得または設定します。 </summary>
        [model.Category("拡張")]
        [model.DefaultValue(true)]
        [model.Description("空の文字列を許可するかどうかを示します。")]
        public bool AllowEmpty { get; set; }

        /// <summary> コントロールに関連付けられた '表示名' を取得または設定します。 </summary>
        [model.Category("拡張")]
        [model.Description("オブジェクトに関連付けられた、ユーザー定義の '表示名' です。")]
        public virtual string Caption
        {
            get
            {
                if (m_caption is null)
                    return string.Empty;
                return m_caption;
            }
            set
            {
                m_caption = value;
                AlertCaption = value;
            }
        }

        /// <summary> 警告表示用の表示名を取得または設定します。 </summary>
        [model.Browsable(false)]
        public string AlertCaption { get; set; }


        /// <summary> コントロールの値が変わったかどうかを示します。 </summary>
        [model.Browsable(false)]
        [model.ReadOnly(true)]
        public bool ChangeFlg { get; set; }


        /// <summary> コードの取得・セット </summary>
        [model.Browsable(false)]
        public List<object> SelectedList
        {
            get
            {
                if (SelectedIndex < 0)
                {
                    return new List<object>();
                }
                var ret = new List<object>();

                foreach (int i in CheckedIndices)
                    ret.Add(mDataList[i].Value);

                return ret;
            }
            set
            {

                foreach (object v in value)
                {

                    for (int i = 0, loopTo = mDataList.Count - 1; i <= loopTo; i++)
                    {
                        if ((v.ToString() ?? "") == (mDataList[i].Value.ToString() ?? ""))
                        {
                            SetItemCheckState(i, CheckState.Checked);
                        }

                    }

                }

            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// 初期設定
        /// </summary>
        public CheckedListBox()
        {

            Text = string.Empty;

            m_caption = null;

            ChangeFlg = false;

            CheckOnClick = true;

            // MSC 標準のフォント サイズを初期値としています。
            Font = new Font("ＭＳ ゴシック", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 128);
            mDataList = new List<ComboData>();
            Clear();
        }

        #endregion

        #region Overrides

        /// <summary> KeyDownイベント </summary>
        protected override void OnKeyDown(KeyEventArgs e)

        {

            switch (e.KeyCode)
            {

                case Keys.Enter:
                    {

                        // Enter キー
                        if (e.Handled)
                            return;

                        Control arg_current_control = this;
                        Common.SelectNextControl(ref arg_current_control, this, !e.Shift);
                        e.Handled = true;
                        return;
                    }

                case Keys.Left:
                case Keys.Right:
                    {

                        // カーソルキー ←→
                        e.Handled = true;
                        return;
                    }

            }

            base.OnKeyDown(e);

        }

        /// <summary> PreviewKeyDown </summary>
        /// <remarks>カーソルキーは KeyDown イベントが発生しないので、発生させるようにする</remarks>
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)

        {

            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.Right:
                    {
                        // KeyDownイベントを発生させる
                        e.IsInputKey = true;
                        break;
                    }

                default:
                    {
                        e.IsInputKey = false;
                        break;
                    }
            }

        }
        /// <summary>
        /// 作成イベント
        /// </summary>
        protected override void OnCreateControl()
        {

            base.OnCreateControl();

        }

        /// <summary> フォーカス中のイベント</summary>
        protected override void OnEnter(EventArgs e)
        {
            Common.SetToolStripStatusLabel(this, string.Format("{0}を選択/解除します。", m_caption));
            base.OnEnter(e);
        }
        /// <summary> フォーカスが切れたのイベント</summary>
        protected override void OnLeave(EventArgs e)
        {
            Common.SetToolStripStatusLabel(this);
            base.OnLeave(e);
        }

        /// <summary> マウスが入るのイベント </summary>
        protected override void OnMouseEnter(EventArgs e)
        {
            Common.SetToolStripStatusLabel(this, string.Format("{0}を選択/解除します。", m_caption));
            base.OnMouseEnter(e);
        }

        /// <summary> マウスが出るのイベント </summary>
        protected override void OnMouseLeave(EventArgs e)
        {
            Common.SetToolStripStatusLabel(this);
            base.OnMouseLeave(e);
        }

        #endregion

        /// <summary>
        /// 値の追加
        /// </summary>
        /// <param name="_text">表示文字</param>
        /// <param name="_value">選択の値</param>
        public void AddItem(string _text, string _value)
        {

            mDataList.Add(new ComboData(_text, _value));
            Items.Add(_text);

        }

        /// <summary>
        /// クリア
        /// </summary>
        public void Clear()
        {

            mDataList.Clear();
            Items.Clear();

        }

        /// <summary>
        /// アイテムを削除
        /// </summary>
        /// <param name="_value">選択の値</param>
        public void RemoveItem(string _value)
        {

            int tg = -1;
            for (int i = 0, loopTo = mDataList.Count - 1; i <= loopTo; i++)
            {
                var cbd = mDataList[i];
                if (cbd is not null && cbd.Value.Equals(_value))
                {
                    tg = i;
                    break;
                }
            }

            if (tg > -1)
            {
                Items.RemoveAt(tg);
                mDataList.RemoveAt(tg);
            }

        }

        /// <summary>
        /// 検証
        /// </summary>
        /// <returns>ErrorNumbers</returns>
        public ErrorNumbers ValidateText()
        {

            // is empty.
            if (Items.Count == 0)
            {
                if (AllowEmpty)
                {
                    return ErrorNumbers.OK;
                }
                else
                {
                    return ErrorNumbers.IsSelectEmpty;
                }

            }
            // OK.
            return ErrorNumbers.OK;

        }

    }

}