using System;
using model = System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SmtLib;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// ラジオボタン共通機能
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class RadioButton : System.Windows.Forms.RadioButton
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
        /// <summary>
        /// 初期設定
        /// </summary>
        public RadioButton()
        {

            Checked = false;
            Text = string.Empty;

            Caption = null;
            ChangeFlg = false;

            // MSC 標準のフォント サイズを初期値としています。
            Font = new Font("ＭＳ ゴシック", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 128);

        }

        #endregion

        #region Overrides

        /// <summary>
        /// KeyDownイベント
        /// </summary>
        /// <param name="e"></param>
        /// <remarks></remarks>
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

            }
            base.OnKeyDown(e);
        }

        /// <summary>コントロールの初期化</summary>
        protected override void OnCreateControl()
        {
            // 親コントロール名をグループ名にする
            GroupName = Parent.Name;
            // Me.TabStop = Me.Parent.TabStop

            base.OnCreateControl();
        }

        /// <summary>チェック状態の変更</summary>
        /// <param name="e"></param>
        protected override void OnCheckedChanged(EventArgs e)
        {
            ChangeFlg = true;
            base.OnCheckedChanged(e);
        }

        #endregion

        #region Control Validation

        /// <summary>
        /// チェック状態の取得
        /// </summary>
        /// <returns>ErrorNumbers</returns>
        /// <remarks></remarks>
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

            // 親コントロールが GroupBox もしくは Panel の場合
            if (!ClsCheck.IsNull(c) && (c is GroupBox || c is Panel))
            {
                // 親コントロール内のコントロールを検索する
                for (int i = 0; i < c.Controls.Count; i++)
                {
                    var ctlRadio = c.Controls[i] as RadioButton;
                    // RadioButton で、グループ名が同じコントロールの場合
                    if (ctlRadio != null && (ctlRadio.Name ?? "") != (Name ?? "") && (ctlRadio.GroupName ?? "") == (GroupName ?? ""))
                    {
                        // 一つでもチェックされている場合はＯＫ
                        if (ctlRadio.Checked)
                        {
                            return (int)ErrorNumbers.OK;
                        }
                        // エラーメッセージの設定
                        if (string.IsNullOrEmpty(AlertCaption))
                        {
                            AlertCaption = ctlRadio.AlertCaption;
                        }
                    }
                }
            }

            return (int)ErrorNumbers.IsSelectEmpty;

        }

        #endregion
        /// <summary> フォーカス中のイベント</summary>
        protected override void OnEnter(EventArgs e)
        {
            Common.SetToolStripStatusLabel(this, string.Format("{0}を選択します。", m_caption));
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
            Common.SetToolStripStatusLabel(this, string.Format("{0}を選択します。", m_caption));
            base.OnMouseEnter(e);
        }

        /// <summary> マウスが出るのイベント </summary>
        protected override void OnMouseLeave(EventArgs e)
        {
            Common.SetToolStripStatusLabel(this);
            base.OnMouseLeave(e);
        }
    }

}