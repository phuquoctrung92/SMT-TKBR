using System;
using System.Drawing;
using System.Windows.Forms;
using SmtLib;

namespace CtrlLib.Message
{

    /// <summary>
    /// カスタムメッセージボックス
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public partial class frmMessage
    {
        #region Variable Value
        #endregion

        #region Extend Property

        /// <summary> メッセージコード </summary>
        public string MessageCD { get; set; }

        /// <summary> メッセージ </summary>
        public string Message { get; set; }

        /// <summary> メッセージボタン </summary>
        public MessageBoxButtons DefaultButton { get; set; }

        /// <summary>メッセージ種別</summary>
        public string MessageCategory { get; set; }

        #endregion

        #region Constructor
        /// <summary>初期設定</summary>
        public frmMessage()
        {
            // この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent();
        }

        #endregion

        #region Form Events

        private void frmMessage_Load(object sender, EventArgs e)
        {
            SetForm();
        }

        #endregion

        #region Control Events

        private void btn1_Click(object sender, EventArgs e)
        {
            this.DialogResult =  DialogResult.Yes;
            Close();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            switch (DefaultButton)
            {
                case MessageBoxButtons.YesNoCancel:
                    {
                        this.DialogResult = DialogResult.No;
                        break;
                    }

                default:
                    {
                        this.DialogResult = DialogResult.OK;
                        break;
                    }
            }
            Close();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            switch (DefaultButton)
            {
                case MessageBoxButtons.YesNo:
                    {
                        this.DialogResult = DialogResult.No;
                        break;
                    }
                case MessageBoxButtons.YesNoCancel:
                    {
                        this.DialogResult = DialogResult.Cancel;
                        break;
                    }
            }
            Close();
        }

        #endregion

        #region Method

        private void SetForm()
        {
            // アイコン・ボタンの設定
            // Select Case Me.m_message_cd.Substring(0, 1)
            switch (MessageCategory ?? "")
            {
                case ConstLib.MESSAGE_CATEGORY_INFORMATION:     // 情報
                    {
                        PictureBox1.Image = SystemIcons.Information.ToBitmap();
                        break;
                    }
                case ConstLib.MESSAGE_CATEGORY_EXCLAMATION:     // 注意
                    {
                        PictureBox1.Image = SystemIcons.Error.ToBitmap();
                        break;
                    }
                case ConstLib.MESSAGE_CATEGORY_QUESTION:        // 問い合わせ
                    {
                        PictureBox1.Image = SystemIcons.Question.ToBitmap();
                        break;
                    }
                case ConstLib.MESSAGE_CATEGORY_CRITICAL:  // 警告
                    {
                        PictureBox1.Image = SystemIcons.Warning.ToBitmap();
                        break;
                    }

                default:
                    {
                        PictureBox1.Image = SystemIcons.Information.ToBitmap();
                        break;
                    }
            }

            lblMsg.Text = Message;

            Show();

            btnControl();

        }

        /// <summary> ボタン表示処理 </summary>
        private void btnControl()
        {
            switch (DefaultButton)
            {
                case MessageBoxButtons.YesNo:
                    {
                        // その他はOKのみ。
                        btn1.Visible = true;
                        btn2.Visible = false;
                        btn3.Visible = true;
                        btn1.Text = "はい";
                        btn3.Text = "いいえ";
                        btn3.Focus();

                        break;
                    }
                case MessageBoxButtons.YesNoCancel:
                    {
                        // その他はOKのみ。
                        btn1.Visible = true;
                        btn2.Visible = true;
                        btn3.Visible = true;
                        btn1.Text = "はい";
                        btn2.Text = "いいえ";
                        btn3.Text = "キャンセル";
                        btn3.Focus();
                        break;
                    }

                default:
                    {
                        // その他はOKのみ。
                        btn1.Visible = false;
                        btn2.Visible = true;
                        btn2.Text = "OK";
                        btn3.Visible = false;
                        btn2.Focus();
                        break;
                    }
            }
        }
        #endregion

    }

}