using System;
using System.Collections.Generic;
using System.Linq;

// Wonderful Report 2005 Preview Control が使用できる時は、以下の定数値を -1 にしてください。
/* TODO ERROR: Skipped DefineDirectiveTrivia
#Const WONDERFULREPORT2005 = -1
*/
// Memo. 参照設定 - AxWfrcLib の追加のしかた
// Step 1. Wonderful Report 2005 のインストール
// ソフトウェアは谷口主任へ
// Step 2. ツールボックスへコントロールを追加
// ツールボックス(Ctrl + Alt + X) → 右クリック → アイテムの選択(&I) → COM コンポーネント タグ → Wonderful Report 2005 Preview Control をチェック
// Step 3. 任意のフォームにコントロールを追加
// どのフォームでも良いので、ツールボックスに追加した、Wonderful Report 2005 Preview Control を選択して張り付ける。
// 以上で、参照設定に AxWfrcLib と、WfrcLib が追加されています。
// 貼り付けたコントロールは削除しておきましょう。
// Memo. 参照の追加 → Wonderful Report 2005 Preview Control だと AxWfrcLib が追加されないのは原因不明。


using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

using SmtLib;
using Wfr2016c;
using static CtrlLib.IPrint;

namespace CtrlLib
{

    /// <summary>
    /// WonderfulReport帳票プレビュー表示クラス
    /// wfrファイルとcsvファイルを紐づけることで帳票プレビューを表示します。
    /// プレビューを表示させずに直接印刷ダイアログを表示させることも可能です(DirectPrintメソッド)。
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create  1.00  
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public partial class frmPreview : IPrint
    {
        /// <summary>
        /// wfrファイルとcsvファイルのセット構造体
        /// </summary>
        public struct WfrCsvSet
        {
            /// <summary> wfrファイル（フルパス込） </summary>
            public string WfrName;
            /// <summary> CSVファイル（フルパス込） </summary>
            public List<string> CsvName;
        }

        #region Zoom Combo Class

        /// <summary>表示倍率コンボボックスにセットする構造体</summary>
        private class CZoom
        {

            /// <summary>表示倍率コンボボックスに表示するテキスト</summary>
            private string m_strText;
            /// <summary>AxWfrcLib.AxWfrc.SetOptions関数に必要な、帳票の表示倍率文字列</summary>
            private string m_strZoom;

            /// <summary>表示倍率コンボボックスに表示するテキスト</summary>
            public string Text
            {
                get
                {
                    return m_strText;
                }
                set
                {
                    m_strText = value;
                }
            }

            /// <summary>AxWfrcLib.AxWfrc.SetOptions関数に必要な、帳票の表示倍率文字列</summary>
        	/// <remarks>
	        /// normal1     | 標準1
	        /// normal2     | 標準2
	        /// adjustwidth | 幅を基準
	        /// whole       | 全体を表示
	        /// 数値        | 表示倍率を指定します。100を指定すると等倍となります。(指定可能範囲:25～1000)
	        /// Wonderful Report 2005 Help より
	        /// </remarks>
            public string Zoom
            {
                get
                {
                    return m_strZoom;
                }
                set
                {
                    m_strZoom = value;
                }
            }

            /// <summary>コンストラクタ</summary>
       		/// <param name="strText">表示倍率コンボボックスに表示するテキスト</param>
      	    /// <param name="strZoom">AxWfrcLib.AxWfrc.SetOptions関数に必要な、帳票の表示倍率文字列</param>
            public CZoom(ref string strText, ref string strZoom)
            {
                m_strText = strText;
                m_strZoom = strZoom;
            }

            public override string ToString()
            {
                return m_strText;
            }

        }

        #endregion

        #region Variable Value

        /// <summary> Report Title </summary>
        private string mTitle;
        /// <summary> Printer Driver </summary>
        private string mDriverName;
        /// <summary> Offset Value (x軸方向) </summary>
        private double mOffsetX;
        /// <summary> Offset Value (y軸方向) </summary>
        private double mOffsetY;


        /// <summary> 用紙方向 </summary>
        protected string mstrDirection;
        /// <summary> トレイ名 </summary>
        protected string mstrTrayNm;
        /// <summary> 用紙名 </summary>
        protected string mstrPaperNm;

        /// <summary> 枚数 </summary>
        protected int mintMaisu;

        /// <summary> Report Id </summary>
        private string mReportId;

        /// <summary>frmPreviewWfrの状態を管理します。</summary>
        private IPrint.EnumStatus mStatus;
        private int mErrorCode;
        private object mErrorParameter;

        /// <summary>印刷をしたかどうかを判断するフラグ</summary>
        private bool mIsPrint;

        /// <summary>CSVにヘッダが含まれるかどうかのフラグ</summary>
        public bool mExistHeader { get; set; }
        /// <summary>帳票ファイルとCSVのパスのセットリスト</summary>
        private List<WfrCsvSet> mlstWfrCsv = null;


        #endregion

        #region Property

        /// <summary>印刷フラグを取得します。</summary>
        /// <returns>印刷をした時は True を返します。</returns>
        /// <remarks>印刷をしたかどうかを判断するフラグ</remarks>
        public bool IsPrint
        {
            get
            {
                return mIsPrint;
            }
        }

        /// <summary>
        /// ヘッダがあるかどうか
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool ExistHeader
        {
            get
            {
                return mExistHeader;
            }
        }


    /// <summary>
    /// wfrファイルとCSVのセットリスト
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
        public List<WfrCsvSet> WfrCsvList
        {
            get
            {
                return mlstWfrCsv;
            }
        }


        /// <summary>デフォルトのプリンタ名を取得または設定します。</summary>
        /// <remarks>
        /// PRINTER.xmlファイルより取得されます。
        /// 変更する時は、New～ShowDialogメソッドの間で指定します。
    	/// </remarks>
        public string DriverName
        {
            get
            {
                return mDriverName;
            }
            set
            {
                mDriverName = value;
            }
        }

        /// <summary>x軸座標オフセット値を取得または設定します。(1/10mm)</summary>
        /// <remarks>
        /// PRINTER.xmlファイルより取得されます。
        /// 変更する時は、New～ShowDialogメソッドの間で指定します。
        /// </remarks>
        public double OffsetX
        {
            get
            {
                return mOffsetX;
            }
            set
            {
                mOffsetX = value;
            }
        }

    	/// <summary>y軸座標オフセット値を取得または設定します。(1/10mm)</summary>
    	/// <remarks>
    	/// PRINTER.xmlファイルより取得されます。
    	/// 変更する時は、New～ShowDialogメソッドの間で指定します。
    	/// </remarks>
        public double OffsetY
        {
            get
            {
                return mOffsetY;
            }
            set
            {
                mOffsetY = value;
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
        /// <summary>用紙方向</summary>
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
        /// <summary>枚数</summary>
        public int Maisu
        {
            get
            {
                return mintMaisu;
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
        /// <summary>エラーコード</summary>
        public int ErrorCode
        {
            get
            {
                return mErrorCode;
            }
        }
        /// <summary>エラーメッセージ</summary>
        public string ErrorMessage
        {
            get
            {
                string strMessage;
                strMessage = GetAxWfrcErrorMsg(mErrorCode);
                if (string.IsNullOrEmpty(strMessage))
                {
                    return GetErrorMessage((IPrint.EnumResult)mErrorCode);
                }
                else
                {
                    return strMessage;
                }
            }
        }
        #endregion

        #region Constructor

        /// <summary>コンストラクタ</summary>
        public frmPreview( List<WfrCsvSet> lstWfrCsv
                        , string strTitle
                        , string strPrinter = ""
                        , double intOffsetX = 0d
                        , double intOffsetY = 0d
                        , bool existHeader = false
                        , string strTrayNm = ""
                        , string strPaperNm = ""
                        , string strDirection = ""
                        , string strRptId = "default"
                        , int pintMaisu = 1)
        {

            // この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent();

            // InitializeComponent() 呼び出しの後で初期化を追加します。

            mStatus = IPrint.EnumStatus.StatusNone;
            InitializefrmPreviewWfr();

            // オブジェクトをセットします。
            mlstWfrCsv = lstWfrCsv;

            mTitle = strTitle;
            mDriverName = strPrinter;
            mOffsetX = intOffsetX;
            mOffsetY = intOffsetY;
            mstrTrayNm = strTrayNm;
            mstrPaperNm = strPaperNm;
            mstrDirection = strDirection;
            mintMaisu = pintMaisu;

            mExistHeader = existHeader;

            //mReportId = strRptId;


            // 帳票を開きます。
            mErrorCode = OpenReport();
            if (mErrorCode < 0)
                return;

            mReportId = ClsFile.GetFileName(mlstWfrCsv.First().WfrName);

            cmbZoom.SelectedIndex = 12;

            // If True Then
            // Me.cmbZoom.SelectedIndex = 7
            // Else
            // Me.cmbZoom.SelectedIndex = 12
            // End If

            if (1 < this.AxWfrControl1.GetPageCount())
            {
                this.btnPrevious.Enabled = true;
                this.btnNext.Enabled = true;
            }
            else
            {
                this.btnPrevious.Enabled = false;
                this.btnNext.Enabled = false;
            }
            UpdatePageNo();

            mStatus = IPrint.EnumStatus.StatusOpend;

            // this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.frmPreviewMouseWheel);
            // this.Paint += new PaintEventHandler(this.frmPreviewMouseWheel);
        }
        #endregion

        #region Form Events

        /// <summary>
        /// frmPreviewWfr_Load
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">System.EventArgs</param>
        /// <remarks></remarks>
        private void frmPreviewWfr_Load(object sender, EventArgs e)
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

            Text = mTitle;
            this.AxWfrControl1.Focus();
        }

        /// <summary>ファンクションボタンを押した時の処理</summary>
        private void frmPreviewWfr_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyData)
            {
                case Keys.F9:
                    {
                        FormPrint();
                        break;
                    }
                case Keys.F12:
                    {
                        FormClose();
                        break;
                    }
            }

        }
        /// <summary>
        /// Xボタン使用不可化
        /// </summary>
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


        private void frmPreviewMouseWheel(object sender, EventArgs e)
        {
            UpdatePageNo();

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

            UpdatePageNo();

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
                                    {
                                        if (!((ComboBox)ActiveControl).DroppedDown)
                                        {
                                            SendKeys.Send("{Tab}");
                                            return true;
                                        }

                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        if (!((ComboBox)ActiveControl).DroppedDown)
                                        {
                                            SendKeys.Send("+{Tab}");
                                            return true;
                                        }

                                        break;
                                    }
                                case Keys.F6:
                                    {
                                        FormPreviousPage();
                                        return true;
                                    }
                                case Keys.F7:
                                    {
                                        FormNextPage();
                                        return true;
                                    }
                                case Keys.F1:
                                    {
                                        FormPrint();
                                        return true;
                                    }
                                case Keys.F10:
                                    {
                                        FormClose();
                                        return true;
                                    }
                                case Keys.Escape:
                                case Keys.F3:
                                    {
                                        return true;
                                    }

                            }

                            break;
                        }
                }
            }

            else
            {

                switch ((IPrint.WindowMessages)msg.Msg)
                {
                    case IPrint.WindowMessages.WM_KEYDOWN:
                    case IPrint.WindowMessages.WM_SYSKEYDOWN:
                        {
                            switch (keyData)
                            {
                                case Keys.Down:
                                    {
                                        break;
                                    }
                                case Keys.Up:
                                    {
                                        break;
                                    }
                                case Keys.F6:
                                    {
                                        FormPreviousPage();
                                        return true;
                                    }
                                case Keys.F7:
                                    {
                                        FormNextPage();
                                        return true;
                                    }
                                case Keys.F1:
                                    {
                                        FormPrint();
                                        return true;
                                    }
                                case Keys.F10:
                                    {
                                        FormClose();
                                        return true;
                                    }
                                case Keys.Escape:
                                case Keys.F3:
                                    {
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
        /// F6:前へ
        /// </summary>
        /// <remarks></remarks>
        private void FormPreviousPage()
        {

            if (!btnPrevious.Enabled)
                return;

            // Dim iPageNo As Int32
            int iPageNo = this.AxWfrControl1.GetPageNo();

            if (iPageNo > 0)
            {
                iPageNo--;
            }
            this.AxWfrControl1.SetPageNo(iPageNo);
            UpdatePageNo();

        }

        /// <summary>
        /// F7:次へ
        /// </summary>
        /// <remarks></remarks>
        private void FormNextPage()
        {

            if (!btnNext.Enabled)
                return;

            int iPageNo = this.AxWfrControl1.GetPageNo();
            if (iPageNo < this.AxWfrControl1.GetPageCount())
            {
                this.AxWfrControl1.SetPageNo(iPageNo + 1);
            }

            UpdatePageNo();

        }

        /// <summary>
        /// F8:印刷
        /// </summary>
        /// <remarks></remarks>
        private void FormPrint()
        {

            // コントロールが無効の時はスルーします。
            if (!btnPrintout.Enabled)
                return;

            UpdatePageNo();
            try
            {
                Enabled = false;

                frmprint frmDialog;

                // 印刷設定フォームを開きます。
                frmDialog = new frmprint(this.AxWfrControl1);

                // '前回使用値を取得
                frmDialog.DriverName = xmlPrinter.get_PrinterDriverPath(mReportId);
                frmDialog.OffsetX = ClsConvert.ToDouble(xmlPrinter.get_PrinterOffsetXPath(mReportId));
                frmDialog.OffsetY = ClsConvert.ToDouble(xmlPrinter.get_PrinterOffsetYPath(mReportId));

                frmDialog.Direction = this.mstrDirection;
                frmDialog.TrayNm = xmlPrinter.get_PrinterTrayName(mReportId);
                frmDialog.RyomenNm = xmlPrinter.get_PrinterRyomen(mReportId);
                frmDialog.PaperNm = this.mstrPaperNm;
                frmDialog.Maisu = this.mintMaisu;
                frmDialog.ShowDialog();

                // ' 印刷設定フォームを閉じてからの処理
                this.mIsPrint = (this.mIsPrint || frmDialog.IsPrint);   // 印刷フラグを受け取ります。

                if (mIsPrint)
                {
                    // 'プリンター情報保存
                    xmlPrinter.set_PrinterDriverPath(mReportId, frmDialog.DriverName);
                    xmlPrinter.set_PrinterOffsetXPath(mReportId, (frmDialog.OffsetX / 10).ToString());
                    xmlPrinter.set_PrinterOffsetYPath(mReportId, (frmDialog.OffsetY / 10).ToString());
                    xmlPrinter.set_PrinterTrayName(mReportId, frmDialog.TrayNm);
                    xmlPrinter.set_PrinterRyomen(mReportId, frmDialog.RyomenNm);
                    xmlPrinter.set_PrinterYoshiNm(mReportId, frmDialog.PaperNm);
                    this.Enabled = true;
                    FormClose();
                }

                // ' Release
                frmDialog.Close();
                frmDialog = null;
            }
            catch //(Exception ex)
            {
                //ex = null;
            }

            finally
            {
                Enabled = true;
            }

        }

        /// <summary>
        /// F9:終了
        /// </summary>
        /// <remarks></remarks>
        private void FormClose()
        {

            // コントロールが無効の時はスルーします。
            if (!btnClose.Enabled)
                return;

            CloseReport();

            // CSV 削除
            foreach(WfrCsvSet wfrcsv in mlstWfrCsv)
            {
                foreach(string csvName in wfrcsv.CsvName)
                {
                    try
                    {
                        System.IO.File.Delete(csvName);
                    }
                    catch // (Exception ex)
                    {
                        // Error. ファイルの削除に失敗しました。
                        // ex = null;
                    }
                }
            }

            // フォームを閉じます。
            Close();

        }

        #endregion

        #region Method

        /// <summary>初期処理を行います。</summary>
        /// <remarks>この関数は、コンストラクタ処理時に1度だけ呼び出してください。</remarks>
        private int InitializefrmPreviewWfr()
        {

            // Me.AxWfrc1 = Nothing
            mTitle = string.Empty;
            mlstWfrCsv = null;
            mStatus = IPrint.EnumStatus.StatusNone;
            mErrorCode = 0;
            mErrorParameter = null;
            btnPrevious.Enabled = false;  // 帳票を開くまで、 Previous, Next ボタンを無効にします。
            btnNext.Enabled = false;      // 

            // 表示倍率コンボボックスのアイテムを初期化します。(Wonderful Report 2005 のデフォルト値)
            cmbZoom.Items.Clear();
            string argstrText = "標準1";
            string argstrZoom = "normal1";
            cmbZoom.Items.Add(new CZoom(ref argstrText, ref argstrZoom));
            string argstrText1 = "標準2";
            string argstrZoom1 = "normal2";
            cmbZoom.Items.Add(new CZoom(ref argstrText1, ref argstrZoom1));
            string argstrText2 = "500%";
            string argstrZoom2 = "500";
            cmbZoom.Items.Add(new CZoom(ref argstrText2, ref argstrZoom2));
            string argstrText3 = "300%";
            string argstrZoom3 = "300";
            cmbZoom.Items.Add(new CZoom(ref argstrText3, ref argstrZoom3));
            string argstrText4 = "200%";
            string argstrZoom4 = "200";
            cmbZoom.Items.Add(new CZoom(ref argstrText4, ref argstrZoom4));
            string argstrText5 = "150%";
            string argstrZoom5 = "150";
            cmbZoom.Items.Add(new CZoom(ref argstrText5, ref argstrZoom5));
            string argstrText6 = "120%";
            string argstrZoom6 = "120";
            cmbZoom.Items.Add(new CZoom(ref argstrText6, ref argstrZoom6));
            string argstrText7 = "100%";
            string argstrZoom7 = "100";
            cmbZoom.Items.Add(new CZoom(ref argstrText7, ref argstrZoom7));
            string argstrText8 = "75%";
            string argstrZoom8 = "75";
            cmbZoom.Items.Add(new CZoom(ref argstrText8, ref argstrZoom8));
            string argstrText9 = "50%";
            string argstrZoom9 = "50";
            cmbZoom.Items.Add(new CZoom(ref argstrText9, ref argstrZoom9));
            string argstrText10 = "25%";
            string argstrZoom10 = "25";
            cmbZoom.Items.Add(new CZoom(ref argstrText10, ref argstrZoom10));
            string argstrText11 = "幅を基準";
            string argstrZoom11 = "adjustwidth";
            cmbZoom.Items.Add(new CZoom(ref argstrText11, ref argstrZoom11));
            string argstrText12 = "全体を表示";
            string argstrZoom12 = "whole";
            cmbZoom.Items.Add(new CZoom(ref argstrText12, ref argstrZoom12));

            return (int)IPrint.EnumResult.ResultOK;
        }

        /// <summary>帳票を開きます。</summary>
        private int OpenReport()
        {


            int iResult;
            System.Text.StringBuilder sbOption;

            if(mlstWfrCsv == null || mlstWfrCsv.Count <= 0)
            {
                return (int)IPrint.EnumResult.Error_NoneRecord;
            }

            // データを設定します。
            sbOption = new System.Text.StringBuilder();
            if (mExistHeader)
            {
                sbOption.Append("Field=on;");    // 1行目をフィールド名として扱います。
            }
            else
            {
                sbOption.Append("Field=off;");　 // 1行目をフィールド名として扱いません。
            }      
            sbOption.Append("LineFeed=[CRLF];"); // 行末文字に、キャリッジリターン+ラインフィードを指定します。

            bool first = true;
            foreach(WfrCsvSet wfrCsvSet in mlstWfrCsv)
            {
                if (!first)
                {
                    AxWfrControl1.AddReport();
                }

                iResult = this.AxWfrControl1.Open(wfrCsvSet.WfrName);
                if (Conversions.ToBoolean(iResult))
                {
                    // Error. AxWfrcLib.AxWfrc.Open関数エラー
                    return iResult;
                }

                for(int i = 0; i < wfrCsvSet.CsvName.Count; i++)
                {
                    iResult = this.AxWfrControl1.Import("#"+(i+1).ToString(), 0, wfrCsvSet.CsvName[i], String.Empty, sbOption.ToString(), String.Empty);
                    if (Conversions.ToBoolean(iResult))
                    {
                        // Error. AxWfrcLib.AxWfrc.Import関数エラー
                        return iResult;
                    }
                }
                first = false;
            }


            // 設定されている情報から帳票出力イメージを作成します。
            iResult = this.AxWfrControl1.Create();
            if (Conversions.ToBoolean(iResult))
            {
                // Error.
                return iResult;
            }

            // ウィンドウや表示に関するオプションを設定します。
            sbOption = new System.Text.StringBuilder();
            sbOption.Append("PopupMenu=disable;");   // プレビューウィンドウでマウス右クリックを押下してもポップアップメニューは表示されません。
            sbOption.Append("ToolBar=off;");         // ツールバーを非表示に設定します。
            sbOption.Append("ViewMode=print;");      // 印刷プレビューモードで表示します。
            sbOption.Append("KeyPriority=low;");
            iResult = this.AxWfrControl1.SetOptions(sbOption.ToString());
            sbOption = null;
            if (Conversions.ToBoolean(iResult))
            {
                // Error. AxWfrcLib.AxWfrc.SetOptions
                return iResult;
            }

            // ウィンドウを表示します。
            this.AxWfrControl1.Visible = true;
            /* TODO ERROR: Skipped ElseDirectiveTrivia
            #Else
            *//* TODO ERROR: Skipped DisabledTextTrivia
                    Dim sb As System.Text.StringBuilder

                    sb = New System.Text.StringBuilder
                    sb.AppendFormat("strRptID    = ""{0}""", Me.m_strRptID) : sb.AppendLine()
                    sb.AppendFormat("[RPTNM]     = ""{0}""", Me.m_strRptNm) : sb.AppendLine()
                    sb.AppendFormat("[RPTFILENM] = ""{0}""", Me.m_strRptFileNm) : sb.AppendLine()
                    sb.AppendFormat("[CSVNM]     = ""{0}""", Me.m_strCsvNm) : sb.AppendLine()
                    sb.AppendFormat("[RPTKNDCD]  = {0}", Me.m_iRptKndCd) : sb.AppendLine()
                    sb.AppendFormat("<OutputDir> = ""{0}""", Me.m_strOutputDir) : sb.AppendLine()
                    sb.AppendFormat("<Driver>    = ""{0}""", Me.m_strDriver) : sb.AppendLine()
                    sb.AppendFormat("<X_Adjust>  = {0}", Me.m_iX_Adjust) : sb.AppendLine()
                    sb.AppendFormat("<Y_Adjust>  = {0}", Me.m_iY_Adjust)

                    Me.lblErrorMessage.Text = sb.ToString
                    Me.lblErrorMessage.Visible = True
                    sb = Nothing
            *//* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            return (int)IPrint.EnumResult.ResultOK;
        }


        /// <summary>帳票を閉じます。</summary>
        private IPrint.EnumResult CloseReport()
        {
            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If WONDERFULREPORT2005 Then
            */        // 帳票を閉じます。
            this.AxWfrControl1.Close();
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
            return IPrint.EnumResult.ResultOK;
        }

        /// <summary>
        /// 帳票プレビューを表示させずに直接印刷ダイアログを表示させます。
        /// </summary>
        public bool DirectPrint()
        {
            try
            {
                frmprint frmDialog;

                // 印刷設定フォームを開きます。
                frmDialog = new frmprint(this.AxWfrControl1);

                // '前回使用値を取得
                frmDialog.DriverName = DriverName;

                frmDialog.Direction = this.mstrDirection;
                frmDialog.PaperNm = this.mstrPaperNm;
                frmDialog.Maisu = this.mintMaisu;
                frmDialog.OffsetX = OffsetX;
                frmDialog.OffsetY = OffsetY;

                frmDialog.FormPrint();

                return frmDialog.IsPrint;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 印刷ボタンを非表示にする。
        /// </summary>
        /// <remarks></remarks>
        public void btnPrintoutHide()
        {
            btnPrintout.Visible = false;
        }

        #endregion

        #region Control Events

        private void cmbZoom_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (((ComboBox)sender).SelectedIndex < 0)
                return;

            /* TODO ERROR: Skipped IfDirectiveTrivia
            #If WONDERFULREPORT2005 Then
            */        // 表示倍率を設定します。


            this.AxWfrControl1.SetOption("Zoom", ((CZoom)((ComboBox)sender).SelectedItem).Zoom);
            /* TODO ERROR: Skipped EndIfDirectiveTrivia
            #End If
            */
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

            FormPreviousPage();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            FormNextPage();

        }

        private void btnPrintout_Click(object sender, EventArgs e)
        {

            FormPrint();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            FormClose();

        }

        #endregion

        #region Not Used

        /// <summary>ページ番号を更新します。</summary>
        private IPrint.EnumResult UpdatePageNo()
        {

            if (this.AxWfrControl1 == null) { return IPrint.EnumResult.ResultError; }
            try
            {
                this.lblPageNo.Text = String.Format("{0}/{1}", this.AxWfrControl1.GetPageNo(), this.AxWfrControl1.GetPageCount());
            }
            catch // (Exception ex) 
            {
                //ex = null;
                return IPrint.EnumResult.ResultError;
            }

            return IPrint.EnumResult.ResultOK;
        }

        private string GetErrorMessage(IPrint.EnumResult eiResult)
        {
            string strMessage;
            switch (eiResult)
            {
                case IPrint.EnumResult.ResultOK:
                    {
                        strMessage = string.Empty;
                        break;
                    }
                case IPrint.EnumResult.ResultError:
                    {
                        strMessage = "エラーが発生しました。";
                        break;
                    }
                case IPrint.EnumResult.Error_CanGetPrinterInfo:
                    {
                        strMessage = "CanGetPrinterInfo関数でエラー値({0})が返りました。";
                        break;
                    }
                case IPrint.EnumResult.Error_MissingCreateDataTable:
                    {
                        strMessage = "{0}データテーブルの作成に失敗しました。";
                        break;
                    }
                case IPrint.EnumResult.Error_MissingReadXml:
                    {
                        strMessage = "{0}ファイルの読み込みに失敗しました。";
                        break;
                    }
                case IPrint.EnumResult.Error_NoneRecord:
                    {
                        strMessage = "{0}レコードが見つかりません。";
                        break;
                    }
                case IPrint.EnumResult.Error_NullParameter:
                    {
                        strMessage = "パラメータエラー({0})";
                        break;
                    }

                default:
                    {
                        strMessage = "予期せぬエラーが発生しました。";
                        break;
                    }
            }

            return string.Format(strMessage, mErrorParameter);
        }

        /// <summary>エラーメッセージを取得します。</summary>
        public string GetAxWfrcErrorMsg(int iAxWfrcErrorCode)
        {

            // Memo. AxWfrcLib.AxWfrcの関数の戻り値に対応しています。(Wonderful Report 2005 - ヘルプ参照)

            switch (iAxWfrcErrorCode)
            {
                case -10:
                    {
                        return "メモリ不足が発生しました。";
                    }
                case -11:
                    {
                        return "原因不明のエラーが発生しました。";
                    }
                case -100:
                    {
                        return "印刷がキャンセルされました。";
                    }
                case -101:
                    {
                        return "原因不明のエラーが発生しました。";
                    }
                case -102:
                    {
                        return "印刷可能なページはありません。";
                    }
                case -103:
                    {
                        return "プリンターを開くことができませんでした。";
                    }
                case -104:
                    {
                        return "プリンターが指定されていません。";
                    }
                case -105:
                    {
                        return "ページ範囲の指定に誤りがあります。";
                    }
                case -106:
                    {
                        return "印刷開始処理でエラーが発生しました。";
                    }
                case -107:
                    {
                        return "印刷終了処理でエラーが発生しました。";
                    }
                case -108:
                    {
                        return "印刷処理でエラーが発生しました。";
                    }
                case -109:
                    {
                        return "印刷ダイアログでキャンセルされました。";
                    }
                case -110:
                    {
                        return "印刷開始処理でエラーが発生しました。出力ファイル名が指定されていません。";
                    }
                case -111:
                    {
                        return "印刷開始処理でエラーが発生しました。出力用ハンドルの生成に失敗しました。";
                    }
                case -112:
                    {
                        return "印刷開始処理でエラーが発生しました。ファイルの作成に失敗しました。";
                    }
                case -113:
                    {
                        return "印刷開始処理でエラーが発生しました。印刷ジョブの開始で失敗しました。";
                    }
                case -114:
                    {
                        return "印刷終了処理でエラーが発生しました。出力ファイル名が指定されていません。";
                    }
                case -115:
                    {
                        return "印刷終了処理でエラーが発生しました。PostScript ファイルの操作中にエラーが発生しました。";
                    }
                case -116:
                    {
                        return "印刷終了処理でエラーが発生しました。PDFの作成に失敗しました。";
                    }
                case -117:
                    {
                        return "仕分印刷中にエラーが発生しました。";
                    }
                case -118:
                    {
                        return "仕分リストファイルが指定されていません。";
                    }
                case -119:
                    {
                        return "仕分リストファイルを開くことができません。";
                    }
                case -120:
                    {
                        return "仕分リストファイルの入力に失敗しました。必要な項目が存在しません。";
                    }
                case -121:
                    {
                        return "仕分リストファイルの入力に失敗しました。認識できないモードが指定されています。";
                    }
                case -122:
                    {
                        return "FAX接続用モジュールのロードに失敗しました。";
                    }
                case -123:
                    {
                        return "「まいとーくFAX」への接続に失敗しました。";
                    }
                case -124:
                    {
                        return "「まいとーくFAX」の初期化中にエラーが発生しました。";
                    }
                case -125:
                    {
                        return "標準のプリンターが見つかりませんでした。";
                    }
                case -126:
                    {
                        return "プリンター情報の取得に失敗しました。";
                    }
                case -301:
                    {
                        return "PdfDistiller に接続することができません。";
                    }
                case -302:
                    {
                        return "PDFファイルの生成に失敗しました。";
                    }
                case -201:
                    {
                        return "原因不明のエラーが発生しました。";
                    }
                case -202:
                    {
                        return "一時ファイルの作成で失敗しました。";
                    }
                case -221:
                    {
                        return "CSVファイルを開くことができませんでした。";
                    }
                case -231:
                    {
                        return "データベースに接続できませんでした。";
                    }
                case -232:
                    {
                        return "フィールド情報を取得できませんでした。";
                    }
                case -10001:
                    {
                        return "原因不明のエラーです。";
                    }
                case -10002:
                    {
                        return "メモリ不足です。";
                    }
                case -10003:
                    {
                        return "一時ファイルの作成に失敗しました。";
                    }
                case -10011:
                    {
                        return "ファイルが存在しないか、サポートされていない形式のファイルです。";
                    }
                case -10012:
                    {
                        return "帳票を開く権限がありません。" + ControlChars.NewLine + "権限のあるユーザ名およびパスワードを指定する必要があります。";
                    }
                case -10013:
                    {
                        return "ファイルが壊れています。";
                    }
                case -10014:
                    {
                        return "Wonderful Report 2000 Professional で作成されたファイルです。" + ControlChars.NewLine + "使用することはできません。";
                    }
                case -10015:
                    {
                        return "ファイルを開くことができません。";
                    }
                case -10016:
                    {
                        return "コンバートツールの実行でエラーが発生しました。";
                    }
                case -10017:
                    {
                        return "起動オプションに誤りがあります。";
                    }
                case -10018:
                    {
                        return "ファイルが存在しない。またはアクセス件がありません。";
                    }
                case -10019:
                    {
                        return "ファイル名が指定されていません。";
                    }
                case -10020:
                    {
                        return "埋め込みフォントの読み込みでエラーが発生しました。";
                    }
                case -10021:
                    {
                        return "帳票が開かれていません。";
                    }
                case -10022:
                    {
                        return "帳票ページイメージ作成で原因不明のエラーが発生しました。";
                    }
                case -10031:
                    {
                        return "サポートされていないモードで保存が実行されました。";
                    }
                case -10032:
                    {
                        return "ファイルを作成することができません。";
                    }
                case -10033:
                    {
                        return "オブジェクト情報の保存中にエラーが発生しました。";
                    }
                case -10034:
                    {
                        return "環境情報の保存中にエラーが発生しました。";
                    }
                case -10035:
                    {
                        return "データ情報の保存中にエラーが発生しました。";
                    }
                case -10036:
                    {
                        return "コンパイルに使用するファイルを開くことができません。";
                    }
                case -10037:
                    {
                        return "ファイルへの保存は許可されていません。";
                    }
                case -10038:
                    {
                        return "保存ファイルが指定されていません。";
                    }
                case -10039:
                    {
                        return "WFR2000の保存に失敗しました。";
                    }
                case -10041:
                    {
                        return "印刷可能なページはありません。";
                    }
                case -10042:
                    {
                        return "プリンター情報を取得することができません。";
                    }
                case -10043:
                    {
                        return "印刷イメージ作成で原因不明のエラーが発生しました。";
                    }
                case -10044:
                    {
                        return "印刷は許可されていません。";
                    }
                case -10045:
                    {
                        return "サポートされていないモードで印刷が実行されました。";
                    }
                case -10051:
                    {
                        return "データの設定は Create メソッド実行前に行う必要があります。";
                    }
                case -10052:
                    {
                        return "データを設定することはできません。";
                    }
                case -10053:
                    {
                        return "該当するデータは見つかりませんでした。";
                    }
                case -10054:
                    {
                        return "サポートされていない形式のデータです。";
                    }
                case -10055:
                    {
                        return "データの読み込みでエラーが発生しました。";
                    }
                case -10056:
                    {
                        return "データ値の設定でエラーが発生しました。";
                    }
                case -10061:
                    {
                        return "Wonderful Report 2000 の実行エンジンが見つかりません。";
                    }
                case -10062:
                    {
                        return "帳票を開くことができません。";
                    }
                case -10063:
                    {
                        return "データの設定でエラーが発生しました。";
                    }
                case -10071:
                    {
                        return "変数の設定でエラーが発生しました。";
                    }
                case -10072:
                    {
                        return "変数の取得でエラーが発生しました。";
                    }
                case -10081:
                    {
                        return "コマンドファイル記述に誤りがあります。";
                    }
                case -10082:
                    {
                        return "コマンドファイルの実行中にエラーが発生しました。";
                    }
                case -10083:
                    {
                        return "フォントファイルの読み込みでエラーが発生しました。";
                    }

                default:
                    {
                        return string.Empty;
                    }
            }
        }

        #endregion
    }
}