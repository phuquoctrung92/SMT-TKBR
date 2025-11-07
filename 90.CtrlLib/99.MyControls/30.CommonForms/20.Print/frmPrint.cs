using System;   // Wonderful Report 2005 Preview Control のために、Off にしています。
using System.Collections.Generic;
using System.Windows.Forms;
using AxWfr2016c;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Wfr2016c;

namespace CtrlLib
{

    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create  1.00  
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public partial class frmprint : IPrint
    {
        /// <summary> 両面印刷 コンボボックス表示内容 / Wonderｵﾌﾟｼｮﾝ設定値 </summary>
        private static readonly Dictionary<string, string> c_ryomenValue =
            new Dictionary<string, string>
            {
                {"プリンタの設定に従う" , "normal"     },
                {"しない"               , "simplex"    },
                {"する(長辺とじ)"       , "vertical"   },
                {"する(短辺とじ)"       , "horizontal" },
            };

        #region Variable Value

        /// <summary>AxWfrcLib.AxWfrcオブジェクト</summary>
        /// <remarks>frmPreviewから参照します。</remarks>
        private AxWfrControl AxWfrc1;

        private IPrint.EnumStatus mStatus;

        /// <summary> Printer Driver </summary>
        private string mDriverName;
        /// <summary> Offset Value (x軸方向) </summary>
        private double mOffsetX;
        /// <summary> Offset Value (y軸方向) </summary>
        private double mOffsetY;
        /// <summary> 用紙方向 </summary>
        private string mstrDirection;
        /// <summary> トレイ名 </summary>
        private string mstrTrayNm;
        /// <summary> 両面設定 </summary>
        private string mstrRyomenNm;
        /// <summary> 用紙名 </summary>
        private string mstrPaperNm;
        /// <summary> 枚数 </summary>
        private int mintMaisu;

        /// <summary>印刷をしたかどうかを判断するフラグ</summary>
        private bool mIsPrint;


        //  Dictionary<String, String> mRyomen;

        #endregion

        #region Property

        /// <summary>印刷フラグを取得します。</summary>
        /// <remarks>印刷をした時、True</remarks>
        public bool IsPrint
        {
            get
            {
                return mIsPrint;
            }
        }

        /// <summary>x軸オフセット値を取得または設定します。(1/10mm)</summary>
        /// <remarks>
        /// 1/10mm単位の値を保持します。
        /// 印刷時、AxWfrcLib.AxWfrc.PrintOutメソッドには1/100mm単位の値をセットします。
        /// プリンタ設定フォームでは、0.1mm単位で調整します。 </remarks>
        public double OffsetX
        {
            get
            {
                return mOffsetX;
            }
            set
            {
                mOffsetX = value;
                txtOffsetX.Text = mOffsetX.ToString();
            }
        }

        /// <summary>y軸オフセット値を取得または設定します。(1/10mm)</summary>
        /// <remarks> 1/10mm単位の値を保持します。
        /// 印刷時、AxWfrcLib.AxWfrc.PrintOutメソッドには1/100mm単位の値をセットします。
        /// プリンタ設定フォームでは、0.1mm単位で調整します。 </remarks>
        public double OffsetY
        {
            get
            {
                return mOffsetY;
            }
            set
            {
                mOffsetY = value;
                txtOffsetY.Text = mOffsetY.ToString();
            }
        }

        /// <summary>給紙トレイ</summary>
        public string TrayNm
        {
            get
            {
                return mstrTrayNm;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;

                mstrTrayNm = value;
                cmbTray.Text = mstrTrayNm;

            }
        }

        /// <summary>
        /// 両面印刷設定を取得または設定します。
        /// </summary>
        public string RyomenNm
        {
            get
            {
                return mstrRyomenNm;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    cmbRyomen.SelectedIndex = 0;
                    return;
                }

                mstrRyomenNm = value;
                cmbRyomen.Text = mstrRyomenNm;

            }
        }

        /// <summary>用紙名</summary>
        public string PaperNm
        {
            get
            {
                return mstrPaperNm;
            }
            set
            {
                mstrPaperNm = value;
            }
        }

        /// <summary>印刷方向</summary>
        public string Direction
        {
            get
            {
                return mstrDirection;
            }
            set
            {
                mstrDirection = value;
            }
        }

        /// <summary>用紙方向</summary>
        public int IntDirection
        {
            get
            {
                if (mstrDirection.Equals("portrait"))
                {
                    return 1;
                }
                else if (mstrDirection.Equals("landscape"))
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>印刷をするプリンタ名を取得または設定します。</summary>
        /// <remarks>String.Emptyの時、通常使うプリンタが使用されます。</remarks>
        public string DriverName
        {
            get
            {
                return mDriverName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    return;

                mDriverName = value;
                cmbPrinter.Text = mDriverName;
            }
        }

        /// <summary>枚数</summary>
        public int Maisu
        {
            get
            {
                return mintMaisu;
            }
            set
            {
                mintMaisu = value;
            }
        }

        /// <summary>印刷設定を取得します。</summary>
        private IPrint.EnumPage SelectPage
        {
            get
            {
                if (rdoPage_All.Checked)
                {
                    return IPrint.EnumPage.PageAll;
                }
                else if (rdoPage_Current.Checked)
                {
                    return IPrint.EnumPage.PageCurrent;
                }
                else if (rdoPage_Range.Checked)
                {
                    return IPrint.EnumPage.PageRange;
                }
                else
                {
                    return IPrint.EnumPage.PageNone;
                }
            }
        }

        /// <summary>状況</summary>
        public IPrint.EnumStatus Status
        {
            get
            {
                return mStatus;
            }
        }

        #endregion

        #region Constructor

        /// <summary>コンストラクタ</summary>
        /// <param name="AxWfrcLib_AxWfrc">frmPreview.AxWfrc1オブジェクトを指定します。</param>
        public frmprint(AxWfrControl AxWfrcLib_AxWfrc)
        {

            // この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent();

            // InitializeComponent() 呼び出しの後で初期化を追加します。
            mStatus = IPrint.EnumStatus.StatusNone;

            // Initialize
            if ((int)InitializefrmPrintPage(ref AxWfrcLib_AxWfrc) < 0)
                return;

            mStatus = IPrint.EnumStatus.StatusInitialized;


        }

        #endregion

        #region Form Events

        /// <summary>
        /// frmPrintPage_Load
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">System.EventArgs</param>
        /// <remarks></remarks>
        private void frmPrintPage_Load(object sender, EventArgs e)
        {

            int x, y;
            x = Screen.PrimaryScreen.WorkingArea.Width - Width;
            y = Screen.PrimaryScreen.WorkingArea.Height - Height;
            if (x < 0)
                x = 0;
            if (y < 0)
                y = 0;
            Left = Screen.PrimaryScreen.WorkingArea.X + x / 2;
            Top = Screen.PrimaryScreen.WorkingArea.Y + y / 2;


            cmbPrinter.Focus();
        }

        private void frmPrintPage_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.F1:
                    {
                        FormPrint();
                        break;
                    }
                case Keys.F2:
                    {
                        FormPrint(true);
                        break;
                    }
                case Keys.F5:
                    {
                        FormClose();
                        break;
                    }
            }

        }

        /// <summary> Xボタン使用不可化 </summary>
        /// <value></value>
        /// <returns>System.Windows.Forms.CreateParams</returns>
        /// <remarks>コントロールボックスのXボタンを使用不可状態にします。</remarks>
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200;
                var cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
                return cp;
            }
        }

        /// <summary>
        /// ProcessCmdKey
        /// </summary>
        /// <param name="msg">System.Windows.Forms.Message</param>
        /// <param name="keyData">System.Windows.Forms.Keys</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {

            if (ActiveControl is ComboBox)
            {

                switch ((IPrint.WindowMessages)msg.Msg)
                {
                    case IPrint.WindowMessages.WM_KEYDOWN:
                    case IPrint.WindowMessages.WM_SYSKEYDOWN:
                        {
                            switch (keyData)
                            {
                                case Keys.Down:
                                case Keys.Enter:
                                    {
                                        if (!((ComboBox)ActiveControl).DroppedDown)
                                        {
                                            SendKeys.Send("{Tab}");
                                            return true;
                                        }

                                        break;
                                    }
                                case Keys.Up:
                                case Keys.Shift | Keys.Enter:
                                    {
                                        if (!((ComboBox)ActiveControl).DroppedDown)
                                        {
                                            SendKeys.Send("+{Tab}");
                                            return true;
                                        }

                                        break;
                                    }
                            }

                            break;
                        }
                }
            }

            else if (ActiveControl is RadioButton)
            {

                // Enter のみ。 ラジオボタンが縦に並んでいるので Up, Down は無し。
                switch ((IPrint.WindowMessages)msg.Msg)
                {
                    case IPrint.WindowMessages.WM_KEYDOWN:
                    case IPrint.WindowMessages.WM_SYSKEYDOWN:
                        {
                            switch (keyData)
                            {
                                case Keys.Enter:
                                    {
                                        SendKeys.Send("{Tab}");
                                        return true;
                                    }
                                case Keys.Shift | Keys.Enter:
                                    {
                                        SendKeys.Send("+{Tab}");
                                        return true;
                                    }
                            }

                            break;
                        }
                }
            }

            else if (ActiveControl is TextBox)
            {

                switch ((IPrint.WindowMessages)msg.Msg)
                {
                    case IPrint.WindowMessages.WM_KEYDOWN:
                    case IPrint.WindowMessages.WM_SYSKEYDOWN:
                        {
                            switch (keyData)
                            {
                                case Keys.Down:
                                case Keys.Enter:
                                    {
                                        SendKeys.Send("{Tab}");
                                        return true;
                                    }
                                case Keys.Up:
                                case Keys.Shift | Keys.Enter:
                                    {
                                        SendKeys.Send("+{Tab}");
                                        return true;
                                    }
                            }

                            break;
                        }
                }
            }

            else if (ActiveControl is Button)
            {

                // Up, Down のみ。
                switch ((IPrint.WindowMessages)msg.Msg)
                {
                    case IPrint.WindowMessages.WM_KEYDOWN:
                    case IPrint.WindowMessages.WM_SYSKEYDOWN:
                        {
                            switch (keyData)
                            {
                                case Keys.Down:
                                    {
                                        SendKeys.Send("{Tab}");
                                        return true;
                                    }
                                case Keys.Up:
                                    {
                                        SendKeys.Send("+{Tab}");
                                        return true;
                                    }
                            }

                            break;
                        }
                }

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Function Key Events

        /// <summary>
        /// F1:印刷
        /// </summary>
        /// <remarks></remarks>
        public void FormPrint(bool openDialog = false)
        {

            if (!btnPrintout.Enabled)
                return;

            // オフセット値のセット（値が正しくない場合は0とする）
            if (string.IsNullOrEmpty(txtOffsetX.Text.Trim()) || !Information.IsNumeric(txtOffsetX.Text))
            {
                mOffsetX = 0d;
            }
            else
            {
                mOffsetX = Conversions.ToDouble(txtOffsetX.Text) * 10d;
            }
            if (string.IsNullOrEmpty(txtOffsetY.Text.Trim()) || !Information.IsNumeric(txtOffsetY.Text))
            {
                mOffsetY = 0d;
            }
            else
            {
                mOffsetY = Conversions.ToDouble(txtOffsetY.Text) * 10d;
            }

            ExecutePrintout(openDialog);

        }

        /// <summary>
        /// F9:終了
        /// </summary>
        /// <remarks></remarks>
        private void FormClose()
        {

            if (!btnExit.Enabled)
                return;

            Close();

        }

        #endregion

        #region Method

        /// <summary>初期処理を行います。</summary>
        /// <remarks>この関数は、コンストラクタ処理時に1度だけ呼び出してください。</remarks>
        private IPrint.EnumResult InitializefrmPrintPage(ref AxWfrControl AxWfrcLib_AxWfrc)
        {

            AxWfrc1 = AxWfrcLib_AxWfrc;
            mIsPrint = false;
            mDriverName = string.Empty;
            mOffsetX = 0d;
            mOffsetY = 0d;

            // コンボボックスにプリンタの一覧をセットします。
            int iPrinterNum;
            iPrinterNum = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count;
            if (Conversions.ToBoolean(iPrinterNum))
            {
                cmbPrinter.Items.Clear();
                for (int index = 0, loopTo = iPrinterNum - 1; index <= loopTo; index++)
                    cmbPrinter.Items.Add(System.Drawing.Printing.PrinterSettings.InstalledPrinters[index]);
                // Me.cmbPrinter.SelectedIndex = 0
                var pd = new System.Drawing.Printing.PrintDocument();
                // 通常使うプリンタ名の取得

                string defaultPrinterName = pd.PrinterSettings.PrinterName;
                cmbPrinter.Text = defaultPrinterName;
            }
            else
            {
                // Error. プリンタがインストールされていません。 or プリンタの一覧が取得できませんでした。
                return IPrint.EnumResult.ResultError;
            }

            // コンボボックスに両面印刷の一覧をセットします。
            cmbRyomen.Items.Clear();
            foreach (string setValue in c_ryomenValue.Keys)
            {
                cmbRyomen.Items.Add(setValue);
            }


            rdoPage_All.Checked = true;
            rdoPage_Current.Checked = false;
            rdoPage_Range.Checked = false;

            txtRange_From.MaxLength = 4;
            txtRange_From.Text = 1.ToString();
            txtRange_To.MaxLength = 4;
            if (AxWfrc1 is not null)
                txtRange_To.Text = AxWfrc1.GetPageCount().ToString();

            return IPrint.EnumResult.ResultOK;
        }

        /// <summary>印刷処理をします。</summary>
        /// <remarks>帳票の印刷をして、印刷フラグをTrueに設定します。</remarks>
        private int ExecutePrintout(bool openDialog)
        {
            int iResult;

            if (AxWfrc1 is null)
            {
                iResult = 0;
            }
            else
            {
                System.Text.StringBuilder sbOption;
                int iPageFrom, iPageTo;

                sbOption = new System.Text.StringBuilder();

                // オフセット値を指定します。(1/10mm → 1/100mm へ変換します)
                // If CBool(Me.m_iOffsetX) Then sbOption.AppendFormat("OffsetX={0:0};", Me.m_iOffsetX * 10)
                // If CBool(Me.m_iOffsetY) Then sbOption.AppendFormat("OffsetY={0:0};", Me.m_iOffsetY * 10)
                sbOption.AppendFormat("OffsetX={0:0};", mOffsetX * 10d);
                sbOption.AppendFormat("OffsetY={0:0};", mOffsetY * 10d);

                // If String.IsNullOrEmpty(Me.mstrDirection) = False Then
                // sbOption.AppendFormat("Orient={0};", Me.mstrDirection)
                // End If

                // If String.IsNullOrEmpty(Me.mstrPaperNm) = False Then
                // sbOption.AppendFormat("Paper={0};", Me.mstrPaperNm)
                // End If

                // 印刷ページを指定します。

                switch (SelectPage)
                {
                    case IPrint.EnumPage.PageAll:
                        {
                            sbOption.Append("Range=ALL");
                            break;
                        }

                    case IPrint.EnumPage.PageCurrent:
                        {
                            // sbOption.AppendFormat("Range={0:0};", Me.AxWfrc1.GetPageNo())
                            sbOption.AppendFormat("Range={0:0};", Operators.AddObject(AxWfrc1.GetPageNo(), 1));
                            break;
                        }


                    case IPrint.EnumPage.PageRange:
                        {
                            // 正しい数値が入力されていない時、ページの先頭から。
                            if (!int.TryParse(txtRange_From.Text, out iPageFrom) || iPageFrom < 1)
                                iPageFrom = 1;
                            txtRange_From.Text = iPageFrom.ToString();
                            // 正しい数値が入力されていない時、ページの終わりまで。
                            if (!int.TryParse(txtRange_To.Text, out iPageTo))
                                iPageTo = Conversions.ToInteger(AxWfrc1.GetPageCount());
                            txtRange_To.Text = iPageTo.ToString();
                            sbOption.AppendFormat("Range={0:0}-{1:0};", iPageFrom, iPageTo);
                            break;
                        }

                    default:
                        {
                            // Error. 印刷設定が正しくされていません。
                            return (int)IPrint.EnumResult.ResultError;
                        }
                }
                // 印刷オプションを初期化します。

                AxWfrc1.SetPrintOption("Init", "All");
                if (string.IsNullOrEmpty(mstrDirection) == false)
                {
                    AxWfrc1.SetPrintOption("Orient", mstrDirection);
                }

                if (string.IsNullOrEmpty(mstrPaperNm) == false)
                {
                    AxWfrc1.SetPrintOption("Paper", mstrPaperNm);
                }

                /*if (string.IsNullOrEmpty(mstrTrayNm) == false)
                {
                    AxWfrc1.SetPrintOption("Tray", mstrTrayNm);
                }*/
                
                if (cmbTray.Items.Count > 0 && string.IsNullOrEmpty(cmbTray.SelectedItem?.ToString()) == false)
                {
                    AxWfrc1.SetPrintOption("Tray", cmbTray.SelectedItem.ToString());
                    mstrTrayNm = cmbTray.SelectedItem.ToString();
                }
                else
                {
                    mstrTrayNm = "";
                }

                if (cmbRyomen.Items.Count > 0 && string.IsNullOrEmpty(cmbRyomen.SelectedItem?.ToString()) == false)
                {
                    AxWfrc1.SetPrintOption("Duplex", c_ryomenValue[cmbRyomen.SelectedItem.ToString()]);
                    mstrRyomenNm = cmbRyomen.SelectedItem.ToString();
                }
                else
                {
                    mstrRyomenNm = "";
                }

                AxWfrc1.SetPrintOption("Copies", mintMaisu.ToString());
                // MsgBox("Orient:" + Me.mstrDirection + " Paper:" + Me.mstrPaperNm + " Tray:" + Me.mstrTrayNm + " Copeis:" + Me.mintMaisu.ToString)

                if (openDialog)
                {
                    // 帳票を印刷します（詳細設定ダイアログ表示）。
                    iResult = Conversions.ToInteger(AxWfrc1.PrintOut(1, cmbPrinter.SelectedItem.ToString(), sbOption.ToString()));
                }
                else
                {
                    // 帳票を印刷します。
                    iResult = Conversions.ToInteger(AxWfrc1.PrintOut(0, cmbPrinter.SelectedItem.ToString(), sbOption.ToString()));
                }


                sbOption = null;

            }

            if (iResult == 0)
            {
                mIsPrint = true;
                Close();
            }
            else
            {
                this.Activate();
            }

            return iResult;
        }

        private bool IsNumber(char cNumber)
        {

            return '0' <= cNumber && cNumber <= '9';

        }
        private bool IsNumber(ref string strNumber)
        {

            if (string.IsNullOrEmpty(strNumber))
                return false;

            for (int index = 0, loopTo = strNumber.Length - 1; index <= loopTo; index++)
            {
                if (strNumber[index] < '0' || '9' < strNumber[index])
                    return false;
            }
            return true;

        }

        #endregion

        #region Control Events

        private void cmbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {

            mDriverName = cmbPrinter.Text;

            var pd = new System.Drawing.Printing.PrintDocument();
            pd.PrinterSettings.PrinterName = mDriverName;

            System.Drawing.Printing.PaperSource pkSource;
            cmbTray.Items.Clear();
            for (int i = 0; i < pd.PrinterSettings.PaperSources.Count; i++)
            {
                pkSource = pd.PrinterSettings.PaperSources[i];
                cmbTray.Items.Add(pkSource.SourceName);
            }
            if(cmbTray.Items.Count >= 1)
            {
                cmbTray.SelectedIndex = 0;
            }

        }

        private void rdoPage_CheckedChanged(object sender, EventArgs e)
        {

            switch (SelectPage)
            {
                case IPrint.EnumPage.PageAll:
                    {
                        // すべてのページ
                        txtRange_From.Enabled = false;
                        txtRange_To.Enabled = false;
                        break;
                    }

                case IPrint.EnumPage.PageCurrent:
                    {
                        // 現在のページ
                        txtRange_From.Enabled = false;
                        txtRange_To.Enabled = false;
                        // 現在のページを表示します。
                        if (AxWfrc1 is not null)
                            AxWfrc1.SetPageNo(AxWfrc1.GetPageNo());
                        break;
                    }
                // If Not Me.AxWfrc1 Is Nothing Then Me.AxWfrc1.SetPageNo(Me.AxWfrc1.GetPageNo() + 1)

                case IPrint.EnumPage.PageRange:
                    {
                        // 範囲指定
                        txtRange_From.Enabled = true;
                        txtRange_To.Enabled = true;
                        break;
                    }

                default:
                    {
                        break;
                    }
                    // Error. 印刷範囲が正しくセットされていません。

            }

        }

        private void btnPrintout_Click(object sender, EventArgs e)
        {

            FormPrint();

        }
        private void btnPrintOutDetail_Click(object sender, EventArgs e)
        {
            FormPrint(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            FormClose();

        }



        private void txtRange_KeyPress(object sender, KeyPressEventArgs e)
        {

            switch (e.KeyChar)
            {
                case ControlChars.Back:
                    {
                        break;
                    }

                default:
                    {
                        if (!IsNumber(e.KeyChar))
                            e.Handled = true;
                        break;
                    }
            }

        }

        private void txtRange_From_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            bool localIsNumber() { string argstrNumber = ((TextBox)sender).Text; var ret = IsNumber(ref argstrNumber); ((TextBox)sender).Text = argstrNumber; return ret; }

            if (!localIsNumber())
            {
                // 数字が入力されていない時、ページの先頭から。
                ((TextBox)sender).Text = 1.ToString();
            }

        }

        private void txtRange_To_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            bool localIsNumber() { string argstrNumber1 = ((TextBox)sender).Text; var ret = IsNumber(ref argstrNumber1); ((TextBox)sender).Text = argstrNumber1; return ret; }

            if (!localIsNumber())
            {
                // 数字が入力されていない時、ページの終わりまで
                if (AxWfrc1 is not null)
                {
                    ((TextBox)sender).Text = AxWfrc1.GetPageCount().ToString();
                }
            }

        }

        #endregion

    }
}