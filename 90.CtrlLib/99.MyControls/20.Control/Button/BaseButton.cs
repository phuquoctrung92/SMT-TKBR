using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// メニュー用ボタン
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class BaseButton : Button
    {
        #region Extend Property

        /// <summary> 表示名 </summary>
        [Browsable(false)]
        public string Caption { get; set; }

        #endregion
        // Private m_FlatStyle As System.Windows.Forms.FlatStyle

        #region Extend Events

        /// <summary> コントロールにフォーカスがあるときに ファンクション キーが押されると KeyDown イベントの前に発生します。 </summary>
        public event FunctionKeyDownEventHandler FunctionKeyDown;
        /// <summary>FunctionKeyDownイベントのハンドル</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void FunctionKeyDownEventHandler(object sender, KeyEventArgs e);



        /// <summary> コントロールにフォーカスがあるときに カーソル キーが押されると KeyDown イベントの前に発生します。 </summary>
        public event AllowKeyDownEventHandler AllowKeyDown;
        /// <summary>AllowKeyDownイベントのハンドル</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void AllowKeyDownEventHandler(object sender, KeyEventArgs e);
        #endregion

        // Public Sub New()
        // m_FlatStyle = System.Windows.Forms.FlatStyle.System
        // End Sub

        // <DefaultValue(GetType(System.Windows.Forms.FlatStyle), "System")> _
        // Public Overloads Property FlatStyle() As System.Windows.Forms.FlatStyle
        // Get
        // Return m_FlatStyle
        // End Get
        // Set(ByVal value As System.Windows.Forms.FlatStyle)
        // m_FlatStyle = value
        // End Set
        // End Property

        /// <summary> 作成イベント </summary>
        protected override void OnCreateControl()
        {
            // Me.FlatStyle = System.Windows.Forms.FlatStyle.System
            base.OnCreateControl();
        }

        /// <summary> クリック時のイベントを発生させます。 </summary>
        public void DoClick()
        {
            base.OnClick(new EventArgs());
        }

        #region Overrides Method

        /// <summary> KeyDownイベント </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case var @case when Keys.Left <= @case && @case <= Keys.Down:
                    {

                        AllowKeyDown?.Invoke(this, e);
                        if (!e.Handled)
                        {
                            switch (e.KeyCode)
                            {

                                case Keys.Up:
                                case Keys.Left:
                                    {
                                        Control arg_current_control = this;
                                        Common.SelectNextControl(ref arg_current_control, this, false);
                                        e.Handled = true;
                                        return;
                                    }

                                case Keys.Down:
                                case Keys.Right:
                                    {
                                        Control arg_current_control1 = this;
                                        Common.SelectNextControl(ref arg_current_control1, this, true);
                                        e.Handled = true;
                                        return;
                                    }

                            }
                        }
                        break;

                    }

                case var case1 when Keys.F1 <= case1 && case1 <= Keys.F24:
                    {
                        FunctionKeyDown?.Invoke(this, e);
                        break;
                    }

            }

            if(!e.Handled)
                base.OnKeyDown(e);
        }

        /// <summary> ボタンでKeyDownイベントを発生させる </summary>
        protected override bool IsInputKey(Keys keyData)
        {
            // Altキーが押されているか確認する
            if ((keyData & Keys.Alt) != Keys.Alt)
            {
                // 矢印キーが押されたときは、trueを返す
                var kcode = keyData & Keys.KeyCode;
                if (kcode == Keys.Up || kcode == Keys.Down || kcode == Keys.Left || kcode == Keys.Right)
                {
                    return true;
                }
            }
            return base.IsInputKey(keyData);
        }

        #endregion

        // Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        // Common.SetToolStripStatusLabel(Me, String.Format("{0}を行います。", Me.m_caption))
        // MyBase.OnEnter(e)
        // End Sub
        // Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        // Common.SetToolStripStatusLabel(Me)
        // MyBase.OnLeave(e)
        // End Sub

    }

}