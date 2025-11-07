using System;

namespace CtrlLib.Input
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
    public partial class frmNumberInput
    {

        #region Variable Value
        private MyControls.StringBox m_target_textBox = null;
        #endregion

        #region Enumerated type

        #endregion

        #region Extend Property

        /// <summary> 最大入力桁数 </summary>
        public int MaxLength { get; set; }

        /// <summary> 戻り値 </summary>
        public string NumberResult { get; set; }

        #endregion

        #region Constructor
        /// <summary>初期設定</summary>
        /// <param name="t">StringBox</param>
        public frmNumberInput(ref MyControls.StringBox t)
        {

            // この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent();

            // InitializeComponent() 呼び出しの後で初期化を追加します。
            m_target_textBox = t;

            MaxLength = m_target_textBox.MaxLength;

            txtNumber.Text = "";

            // 初期表示時に入力元の値を反映させていましたが、毎回クリアボタン押さないとだめなのめんどくさそうなので、初期値空にします。
            // If Integer.TryParse(m_target_textBox.Text, New Integer) Then
            // txtNumber.Text = m_target_textBox.Text
            // End If
        }
        #endregion

        #region Form Events

        private void frmMessage_Load(object sender, EventArgs e)
        {
            SetForm();
        }

        #endregion

        #region Control Events

        private void btn0_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text.Length > 0)
            {
                SetValue(0);
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            SetValue(1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SetValue(2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            SetValue(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            SetValue(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            SetValue(5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            SetValue(6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            SetValue(7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            SetValue(8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            SetValue(9);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtNumber.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_target_textBox.Text = txtNumber.Text;
            Close();
        }

        #endregion

        #region Method
        private void SetForm()
        {
            btnC.Select();
            Show();
        }
        private void SetValue(int value)
        {
            if (txtNumber.Text.Length < MaxLength)
            {
                txtNumber.Text = txtNumber.Text + value.ToString();
            }
        }
        #endregion
    }
}