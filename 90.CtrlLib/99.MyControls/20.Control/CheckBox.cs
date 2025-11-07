using System;
using model = System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SmtLib;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// チェックボックス共通機能
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class CheckBox : System.Windows.Forms.CheckBox
    {

        #region Variable Value
        private string m_caption;
        #endregion

        #region Extend Property

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

        /// <summary> コントロールのグループ名を取得または設定します。 </summary>
        [model.Category("拡張")]
        [model.Description("グループ名を指定します。同じグループのコントロールに少なくとも１つはチェックされる必要があります。")]
        public string GroupName { get; set; }

        /// <summary> コントロールの値が変わったかどうかを示します。 </summary>
        [model.Browsable(false)]
        [model.ReadOnly(true)]
        public bool ChangeFlg { get; set; }

        #endregion

        #region Constructor
        /// <summary>初期設定</summary>
        public CheckBox()
        {

            Checked = false;
            Text = string.Empty;

            m_caption = null;

            ChangeFlg = false;

            // MSC 標準のフォント サイズを初期値としています。
            Font = new Font("ＭＳ ゴシック", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 128);

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

                case Keys.Up:
                    {

                        // カーソルキー ↑
                        Control arg_current_control1 = this;
                        Common.SelectNextControl(ref arg_current_control1, this, false);
                        e.Handled = true;
                        return;
                    }

                case Keys.Down:
                    {

                        // カーソルキー ↓
                        Control arg_current_control2 = this;
                        Common.SelectNextControl(ref arg_current_control2, this, true);
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

        /// <summary>カーソルキーは KeyDown イベントが発生しないので、発生させるようにする</summary>
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)

        {

            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
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

        /// <summary> チェックボックス変更 </summary>
        protected override void OnCheckedChanged(EventArgs e)
        {
            ChangeFlg = true;
            base.OnCheckedChanged(e);
        }

        /// <summary> 作成イベント </summary>
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

        #region Control Validation

        /// <summary> チェック状態を取得します。 </summary>
        public int ValidateCheck()
        {
            Control c;
            // 親コントロールの取得
            c = Parent;

            // グループ指定されていない場合はＯＫ
            // チェック済みの場合はＯＫ
            if (string.IsNullOrEmpty(GroupName) || Checked)
            {
                return (int)ErrorNumbers.OK;
            }
            else if (!ClsCheck.IsNull(c) && (c is GroupBox || c is Panel)) // 親コントロールが GroupBox もしくは Panel の場合
            {
                // 親コントロール内のコントロールを検索する
                for (int i = 0; i < c.Controls.Count; i++)
                {
                    // CheckBox で、グループ名が同じコントロールの場合
                    var ctlCheck = c.Controls[i] as CheckBox;
                    if (ctlCheck != null && ((ctlCheck.Name ?? "") != (Name ?? "") && (ctlCheck.GroupName ?? "") == (GroupName ?? "")))
                    {
                        // 一つでもチェックされている場合はＯＫ
                        if (ctlCheck.Checked)
                        {
                            return (int)ErrorNumbers.OK;
                        }
                        // エラーメッセージの設定
                        if (string.IsNullOrEmpty(AlertCaption))
                        {
                            AlertCaption = ctlCheck.AlertCaption;
                        }
                    }
                }
            }
            return (int)ErrorNumbers.IsSelectEmpty;

        }

        #endregion

    }

}