using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using SmtLib;

namespace CtrlLib
{
    /// <summary> ファンクションボタン設定用構造体 </summary>
    public class FunctionButtons
    {
        /// <summary>キャプション</summary>
        public string Caption { get; set; }
        /// <summary>有効化</summary>
        public bool Enabled { get; set; }
        /// <summary>改行</summary>
        public bool CrLf { get; set; }
        /// <summary>フォント</summary>
        public Font Font { get; set; }

        /// <summary>初期設定</summary>
        /// <param name="_caption">キャプション</param>
        /// <param name="_enabled">有効化・無効化</param>
        /// <param name="_CrLf">改行</param>
        /// <param name="_font">フォント</param>
        public FunctionButtons(string _caption, bool _enabled = true, bool _CrLf = true, Font _font = null)
        {
            Caption = _caption;
            if (_caption.Trim().Length == 0)
            {
                Enabled = false;
            }
            else
            {
                Enabled = _enabled;
            }
            CrLf = _CrLf;
            Font = _font ?? new Font("MS Gothic", 18f, FontStyle.Regular, GraphicsUnit.Point, 128);
        }
    }

    public partial class ucFunction
    {
        #region Constant Value
        private const int MAX_FUNCTION_BUTTON_COUNT = 24;
        #endregion

        private int mButtonCount = 12;
        private Size mButtonSize = new Size(140, 65);
        private MyControls.BaseButton[] mButtunControls;

        /// <summary>ファンクションボタンを取得</summary>
        /// <param name="key">Keys</param>
        /// <returns>BaseButton</returns>
        public MyControls.BaseButton get_FunctionButtonControls(Keys key)
        {
            int index;
            index = (int)key - (int)Keys.F1;
            if (index < 0 || MAX_FUNCTION_BUTTON_COUNT <= index)
                return null;
            return mButtunControls[index];
            // AddHandler Me.m_function_button_controls(index).Click, AddressOf Me.FunctionButton_Click
        }

        /// <summary>ファンクションボタンをセット</summary>
        /// <param name="key">Keys</param>
        /// <param name="value">値</param>
        public void set_FunctionButtonControls(Keys key, MyControls.BaseButton value)
        {
            int index;
            index = (int)key - (int)Keys.F1;
            if (index < 0 || MAX_FUNCTION_BUTTON_COUNT <= index)
                return;
            if (value is null)
            {
                if (mButtunControls[index] is not null)
                {
                    mButtunControls[index].Click -= FunctionButton_Click;
                }
            }
            else
            {
                mButtunControls[index] = value;
            }
        }

        /// <summary> ファンクションボタンの数 </summary>
        [Category("拡張(描画)")]
        public int FunctionButtonCount
        {
            get
            {
                return mButtonCount;
            }
            set
            {
                if (value < 0 || MAX_FUNCTION_BUTTON_COUNT < value)
                    return;
                mButtonCount = value;
                InitializeFunctionButton();
            }
        }

        /// <summary> ファンクションボタンのフォント </summary>
        [Category("拡張(描画)")]
        public Font FunctionButtonFont { get; set; } = new Font("MS Gothic", 20.0f, FontStyle.Regular, GraphicsUnit.Point, 128);

        /// <summary> ファンクションボタンのサイズ </summary>
        [Category("拡張(描画)")]
        public Size FunctionButtonSize
        {
            get
            {
                return mButtonSize;
            }
            set
            {
                mButtonSize = value;
                InitializeFunctionButton();
            }
        }

        /// <summary>初期設定</summary>
        public ucFunction()
        {

            // この呼び出しはデザイナーで必要です。
            InitializeComponent();

            // InitializeComponent() 呼び出しの後で初期化を追加します。

            // ' InitializeComponent() 呼び出しの後で初期化を追加します。
            mButtunControls = new MyControls.BaseButton[24];


            BackColor = XmlColorLib.GetColor(XmlColorLib.Colors.FooterPanel);

        }


        #region FunctionButton

        // Private Event FunctionButtonClick(sender As Object, e As FunctionButtonClickEventArgs)      ' (本来こちらが上位に投げるべきイベント)

        // Protected Event OnFunctionButtonClick(e As FunctionButtonClickEventArgs)



        // ''' <summary> ファンクションに割り当てられているキー押下 </summary>
        // Private Sub Form_OnFunctionButtonClick(e As FunctionButtonClickEventArgs) Handles Me.OnFunctionButtonClick

        // Dim key As String = String.Empty

        // key = "F" & (e.KeyCode - System.Windows.Forms.Keys.F1 + 1).ToString()

        // RaiseEvent FunctionButtonClick(Me, e)

        // e.Handled = True

        // End Sub


        /// <summary> フォーム上でファンクション キーが押された時の処理を行います。 </summary>
        public new bool ProcessDialogKey(Keys keyData)
        {
            int index;
            index = Convert.ToInt32((int)keyData - (int)Keys.F1);

            if (0 <= index && index < MAX_FUNCTION_BUTTON_COUNT && mButtunControls[index] is not null && mButtunControls[index].Enabled && mButtunControls[index].Visible)
            {
                FunctionButton_Click(mButtunControls[index], new EventArgs());
            }

            keyData = default;
            return base.ProcessDialogKey(keyData);

        }



        #endregion

        /// <summary> ファンクションボタン設定 </summary>
        private void InitializeFunctionButton()
        {
            int i;

            if (mButtonCount < 0 || MAX_FUNCTION_BUTTON_COUNT < mButtonCount)
                return; // num out of range error.

            SuspendLayout();

            MyControls.BaseButton btn;
            var loopTo = Controls.Count - 1;
            for (i = 0; i <= loopTo; i++)
            {
                var btnBase = Controls[i] as MyControls.BaseButton;
                if (btnBase != null)
                {
                    btn = btnBase;
                    btn.Click -= FunctionButton_Click;
                }
            }

            // フッターのコントロールをすべて取り除きます。
            Controls.Clear();

            i = 0;

            while (i < mButtonCount)
            {
                if (mButtunControls[i] is null)
                {
                    mButtunControls[i] = new MyControls.BaseButton();
                }

                ref var withBlock = ref mButtunControls[i];
                withBlock.Location = new Point((Width - mButtonSize.Width * mButtonCount) * (i + 1) / (mButtonCount + 1) + mButtonSize.Width * i, (Height - mButtonSize.Height) / 2 );
                withBlock.Name = string.Format("F{0}", i + 1);
                withBlock.Size = mButtonSize;
                withBlock.TabIndex = i;
                withBlock.FlatStyle = FlatStyle.System;
                withBlock.TabStop = false;
                withBlock.Enabled = false;
                withBlock.Visible = false;
                withBlock.Text = ""; // String.Format("F{0}", i + 1)
                withBlock.UseVisualStyleBackColor = true;
                withBlock.Font = FunctionButtonFont;
                // AddHandler .Click, AddressOf Me.FunctionButton_Click
                         
                Controls.Add(mButtunControls[i]);
                i += 1;
            }

            ResumeLayout();

        }

        public void SetFunctionButtons(params string[] _function_button)
        {
            List<FunctionButtons> functionButtons = new List<FunctionButtons>();
            foreach (string btn in _function_button)
            {
                functionButtons.Add(new FunctionButtons(btn));
            }
            SetFunctionButtons(functionButtons.ToArray());
        }
        /// <summary> 用意されているファンクション ボタンのテキストと有効/無効の設定を行います。 </summary>
        public void SetFunctionButtons(params FunctionButtons[] _function_button)
        {
            if (_function_button is null)
            {
                return;
            }

            int length = Math.Min(MAX_FUNCTION_BUTTON_COUNT, _function_button.Length);

            var ls = new List<Control>();

            foreach (Control ctl in Controls)
            {
                int index;

                index = Array.FindIndex(mButtunControls, (button) => ReferenceEquals(button, ctl));
                if (0 > index)
                {
                    ls.Add(ctl);
                }
            }

            foreach (Control ctl in ls)
                Controls.Remove(ctl);

            for (int i = 0, loopTo = length - 1; i <= loopTo; i++)
            {

                if (mButtunControls[i] is null)
                    continue;

                ref var withBlock = ref mButtunControls[i];
                withBlock.SuspendLayout();

                if (withBlock.Parent is ucFunction)
                {
                    withBlock.Location = new Point((Width - mButtonSize.Width * mButtonCount) * (i + 1) / (mButtonCount + 1) + mButtonSize.Width * i, (Height - mButtonSize.Height) / 2 );
                    withBlock.Size = mButtonSize;
                }
                else
                {
                    var btn = new MyControls.BaseButton();
                    btn.Location = new Point((Width - mButtonSize.Width * mButtonCount) * (i + 1) / (mButtonCount + 1) + mButtonSize.Width * i, (Height - mButtonSize.Height) / 2 );
                    btn.Size = mButtonSize;

                    btn.Click -= FunctionButton_Click;
                    btn.Enabled = false;
                    btn.TabStop = false;
                    btn.Font = FunctionButtonFont;
                    btn.FlatStyle = FlatStyle.System;
                    btn.UseVisualStyleBackColor = true;
                    btn.Visible = true;

                    Controls.Add(btn);
                }

                withBlock.Click -= FunctionButton_Click;
                withBlock.Enabled = _function_button[i].Enabled;
                withBlock.TabStop = false;
                withBlock.Font = _function_button[i].Font;
                withBlock.FlatStyle = FlatStyle.System;
                withBlock.UseVisualStyleBackColor = true;
                withBlock.Visible = true;
                if(!_function_button[i].CrLf) withBlock.TextAlign = ContentAlignment.MiddleLeft;

                if (!ClsCheck.IsNull(_function_button[i].Caption))
                {
                    if (_function_button[i].CrLf)
                    {
                        withBlock.Text = string.Format("F{0}{1}{2}", i + 1, Constants.vbCrLf, _function_button[i].Caption);
                    }
                    else if (withBlock.TextAlign == ContentAlignment.MiddleLeft)
                    {
                        withBlock.Text = string.Format("  F{0}:{1}", i + 1, _function_button[i].Caption);
                    }
                    else
                    {
                        withBlock.Text = string.Format("F{0}:{1}", i + 1, _function_button[i].Caption);
                    }
                    withBlock.Caption = _function_button[i].Caption;

                    withBlock.Click += FunctionButton_Click;
                }
                else
                {
                    withBlock.Text = string.Empty;
                    withBlock.Caption = string.Empty;
                }
                withBlock.ResumeLayout();
            }

        }

//
        private void FunctionButton_Click(object sender, EventArgs e)
        {
            clsLogger.Info("「 " + ((ButtonBase)sender).Text.Replace("\r\n","") + " 」 ボタンを押下");


            var index = System.Array.FindIndex<CtrlLib.MyControls.BaseButton>(mButtunControls, button => button == sender);

            if(0 <= index)
            {
                var ea = new CtrlLib.EventArgsFunctionButtonClick((System.Windows.Forms.Keys)(Keys.F1 + index));
                ClickEvent(ea);
            }

        }

        /// <summary>F1キー</summary>
        public event F1EventHandler F1;
        /// <summary>F1キーイベント</summary>
        public delegate void F1EventHandler(EventArgsFunctionButtonClick e);

        /// <summary>F2キー</summary>
        public event F2EventHandler F2;
        /// <summary>F2キーイベント</summary>
        public delegate void F2EventHandler(EventArgsFunctionButtonClick e);

        /// <summary>F3キー</summary>
        public event F3EventHandler F3;
        /// <summary>F3キーイベント</summary>
        public delegate void F3EventHandler(EventArgsFunctionButtonClick e);

        /// <summary>F4キー</summary>
        public event F4EventHandler F4;
        /// <summary>F4キーイベント</summary>
        public delegate void F4EventHandler(EventArgsFunctionButtonClick e);

        /// <summary>F5キー</summary>
        public event F5EventHandler F5;
        /// <summary>F5キーイベント</summary>
        public delegate void F5EventHandler(EventArgsFunctionButtonClick e);

        /// <summary>F6キー</summary>
        public event F6EventHandler F6;
        /// <summary>F6キー</summary>
        public delegate void F6EventHandler(EventArgsFunctionButtonClick e);

        /// <summary>F7キー</summary>
        public event F7EventHandler F7;
        /// <summary>F7キーイベント</summary>
        public delegate void F7EventHandler(EventArgsFunctionButtonClick e);

        /// <summary>F8キー</summary>
        public event F8EventHandler F8;
        /// <summary>F8キーイベント</summary>
        public delegate void F8EventHandler(EventArgsFunctionButtonClick e);

        /// <summary>F9キー</summary>
        public event F9EventHandler F9;
        /// <summary>F9キーイベント</summary>
        public delegate void F9EventHandler(EventArgsFunctionButtonClick e);

        /// <summary>F10キー</summary>
        public event F10EventHandler F10;
        /// <summary>F10キーイベント</summary>
        public delegate void F10EventHandler(EventArgsFunctionButtonClick e);

        /// <summary>F11キー</summary>
        public event F11EventHandler F11;
        /// <summary>F11キーイベント</summary>
        public delegate void F11EventHandler(EventArgsFunctionButtonClick e);

        /// <summary>F12キー</summary>
        public event F12EventHandler F12;
        /// <summary>F12キーイベント</summary>
        public delegate void F12EventHandler(EventArgsFunctionButtonClick e);

        private void ClickEvent(EventArgsFunctionButtonClick e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    {
                        F1?.Invoke(e);
                        break;
                    }
                case Keys.F2:
                    {
                        F2?.Invoke(e);
                        break;
                    }
                case Keys.F3:
                    {
                        F3?.Invoke(e);
                        break;
                    }
                case Keys.F4:
                    {
                        F4?.Invoke(e);
                        break;
                    }
                case Keys.F5:
                    {
                        F5?.Invoke(e);
                        break;
                    }
                case Keys.F6:
                    {
                        F6?.Invoke(e);
                        break;
                    }
                case Keys.F7:
                    {
                        F7?.Invoke(e);
                        break;
                    }
                case Keys.F8:
                    {
                        F8?.Invoke(e);
                        break;
                    }
                case Keys.F9:
                    {
                        F9?.Invoke(e);
                        break;
                    }
                case Keys.F10:
                    {
                        F10?.Invoke(e);
                        break;
                    }
                case Keys.F11:
                    {
                        F11?.Invoke(e);
                        break;
                    }
                case Keys.F12:
                    {
                        F12?.Invoke(e);
                        break;
                    }
            }

            e.Handled = true;
        }

    }
}