using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic;
using SmtLib;

namespace CtrlLib.Wfr
{

    /// <summary>
    /// Wonderful Report 発行ベースクラス
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create  1.00              Y.Ase       新規作成
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class WfrBase : IPrint
    {

        #region Variable Value

        /// <summary> WonderfulReport wfrファイル＋csvファイル </summary>
        protected List<frmPreview.WfrCsvSet> mlstWfrCsv = null;

        /// <summary> Output Directory </summary>
        protected string mOutputDir;
        /// <summary> Report Title </summary>
        protected string mTitle;
        /// <summary> Report ID </summary>
        protected string mReportId;
        /// <summary> Printer Driver </summary>
        protected string mDriverName;
        /// <summary> Offset Value (x軸方向) </summary>
        protected double mOffsetX;
        /// <summary> Offset Value (y軸方向) </summary>
        protected double mOffsetY;

        /// <summary> 用紙方向 </summary>
        protected string mDirection;
        /// <summary> 用紙名 </summary>
        protected string mPaperNm;
        /// <summary> ヘッダー　</summary>
        protected bool mExistHeader;


        ////// <summary>frmPreviewWfrの状態を管理します。</summary>
        //private IPrint.EnumStatus mStatus;
        //private int mErrorCode;
        //private object mErrorParameter;

        /// <summary>印刷をしたかどうかを判断するフラグ</summary>
        private bool mIsPrint;

        //private string mCsvData;

        //protected DataTable mMainDt;


        //protected bool mbolAfterRet;

        /// <summary> WFR参照ディレクトリ </summary>
        public static string CST_WONDERFUL_REPORT_DIR
        {
            get 
            {
                return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "report");
            }
        }

        #endregion

        #region Constructor
        /*        public WfrBase(string _className)
                {

                    // パラメータ初期化
                    // Call Initialize(_id)
                    mExistHeader = false;
                    //mReportId = _className;
                    // Dim drs() As DataRow = New ClsXml("Printer.xml").GetCurrentDataSet.Tables("Printer").Select("Name = '" & _className & "'")
                    // If drs IsNot Nothing AndAlso drs.Count <> 0 Then
                    // Dim dr As DataRow = drs(0)
                    // Me.mDriverName = dr.Item("Driver").ToString
                    // Me.mOffsetX = ClsConvert.ToDouble(dr.Item("OffsetX").ToString)
                    // Me.mOffsetY = ClsConvert.ToDouble(dr.Item("OffsetY").ToString)

                    // End If
                }*/


        /// <summary>
        /// コンストラクタ(DataTableを引き渡してCSV作成から)
        /// wfrファイルとcsvファイルが一つだけのパターン
        /// </summary>
        /// <param name="inTitle"> ウィンドウタイトル </param>
        /// <param name="inCsvData"> 帳票出力元データ </param>
        /// <param name="inWfrFileName"> wfrファイル名(パスなし） </param>
        /// <param name="inPaperNm"> 用紙名 </param>
        /// <param name="driverName"></param>
        public WfrBase(String inTitle, DataTable inCsvData, String inWfrFileName, String inPaperNm = "", string driverName = null)
        {

            List<DataTable> setDts = new List<DataTable>(){ inCsvData };
            List<List<DataTable>> setDtLists = new List<List<DataTable>>(){ setDts };

            List<string> setWfrs = new List<string>(){ inWfrFileName };

            Init(inTitle, setDtLists, setWfrs, inPaperNm, driverName);
        }

        /// <summary>
        /// コンストラクタ(DataTableを引き渡してCSV作成から)
        /// wfrファイルとcsvファイルが複数ある(wfr:csv 1対1 )パターン
        /// </summary>
        public WfrBase(String inTitle, List<DataTable> inCsvDataLists, List<String> inWfrFileNameList, String inPaperNm = "", string driverName = null)
        {
            List<List<DataTable>> setDtLists = new List<List<DataTable>>();
            foreach(DataTable setDt in inCsvDataLists)
            {
                List<DataTable> tmp = new List<DataTable>();
                tmp.Add(setDt);
                setDtLists.Add(tmp);
            }

            Init(inTitle, setDtLists, inWfrFileNameList, inPaperNm, driverName);
        }
        /// <summary>
        /// コンストラクタ(DataTableを引き渡してCSV作成から)
        /// wfrファイルとcsvファイルが複数ある(wfr:csv 1対多 )パターン
        /// </summary>
        public WfrBase(String inTitle, List<List<DataTable>> inCsvDataLists, List<String> inWfrFileNameList, String inPaperNm = "", string driverName = null)
        {
            Init(inTitle, inCsvDataLists, inWfrFileNameList, inPaperNm, driverName);
        }



        /// <summary>
        /// コンストラクタ(csv作成後パターン)
        /// wfrファイルとcsvファイルが一つだけのパターン
        /// </summary>
        public WfrBase(String inTitle, String inFileName, String inWfrFileName, String inPaperNm = "", bool inExistHeader = true, string driverName = null)
        {

            List<String> setDts = new List<String>();
            setDts.Add(inFileName);
            List<List<String>> setDtLists = new List<List<String>>();
            setDtLists.Add(setDts);

            List<string> setWfrs = new List<string>();
            setWfrs.Add(inWfrFileName);

            Init(inTitle, setDtLists, setWfrs, inPaperNm, inExistHeader, driverName);
        }


        /// <summary>
        /// コンストラクタ(csv作成後パターン)
        /// wfrファイルとcsvファイルが複数ある(wfr:csv 1対1 )パターン
        /// </summary>
        public WfrBase(String inTitle, List<String> inCsvFileNameLists, List<String> inWfrFileName, String inPaperNm = "", bool inExistHeader = true, string driverName = null)
        {
            List<List<String>> setCsvLists = new List<List<String>>();
            foreach (String setCsvName in inCsvFileNameLists)
            {
                List<String> tmp = new List<String>();
                tmp.Add(setCsvName);
                setCsvLists.Add(tmp);
            }

            Init(inTitle, setCsvLists, inWfrFileName, inPaperNm, inExistHeader, driverName);
        }


        /// <summary>
        /// コンストラクタ(csv作成後パターン)
        /// wfrファイルとcsvファイルが複数ある(wfr:csv 1対多 )パターン
        /// </summary>
        public WfrBase(String inTitle , List<List<String>> inCsvFileNameLists, List<String> inWfrFileName, String inPaperNm  = "", bool inExistHeader = true, string driverName = null)
        {
            Init(inTitle, inCsvFileNameLists, inWfrFileName, inPaperNm, inExistHeader, driverName);
        }

        /// <summary>
        /// 初期処理 DataTable → csv変換後 
        /// </summary>
        private void Init(string inTitle, List<List<DataTable>> inCsvDataLists, List<String> inWfrFileName, string inPaperNm, string driverName)
        {
            // DataTableからCsvファイル作成
            string tmpFileNameBase = "tmp";
            List<List<string>> csvFileNamesList = new List<List<string>>();

            for (int i = 0; i < inCsvDataLists.Count; i++)
            {
                List<string> csvFileNames = new List<string>();
                for (int j = 0; j < inCsvDataLists[i].Count; j++)
                {
                    string csvName = tmpFileNameBase + "_" + i.ToString() + "_" + j.ToString() +".csv";

                    // CSV出力
                    var tmp = clsExport.TextEncoding;
                    clsExport.TextEncoding = Const_Encoding.UTF8B; // BOM付きUTF-8 で出力
                    clsExport.Text(ClsPath.CombinePath(CST_WONDERFUL_REPORT_DIR, csvName), clsExport.TextType.CSV, inCsvDataLists[i][j]);
                    clsExport.TextEncoding = tmp; // 他のテキスト出力処理に影響あるので戻す

                    // CSVのファイル名を保持
                    csvFileNames.Add(csvName);
                }
                csvFileNamesList.Add(csvFileNames);
            }

            Init(inTitle, csvFileNamesList, inWfrFileName, inPaperNm, true, driverName);
        }

        /// <summary>
        /// 初期処理 csvファイル名
        /// </summary>
        private void Init(string inTitle, List<List<String>> inCsvFileNameLists, List<String> inWfrFileName, string inPaperNm, bool existHeader, string driverName)
        {
            // csvファイルとwfrファイルの数が異なっている場合はエラー
            if (inCsvFileNameLists.Count != inWfrFileName.Count)
            {
                throw new Exception("wfrファイルと参照元データの数が合いません。");
            }

            mTitle = inTitle;
            mOffsetX = 0;
            mOffsetY = 0;
            mDriverName = driverName;
            // mBtnPrintoutVisible = true;
            mPaperNm = inPaperNm;
            mOutputDir = CST_WONDERFUL_REPORT_DIR;
            mExistHeader = existHeader;

            mlstWfrCsv = new List<frmPreview.WfrCsvSet>();
            for (int i= 0; i < inWfrFileName.Count; i++)
            {
                frmPreview.WfrCsvSet setValue = new frmPreview.WfrCsvSet();
                setValue.WfrName = ClsPath.CombinePath(CST_WONDERFUL_REPORT_DIR, inWfrFileName[i]); 

                setValue.CsvName = new List<string>();
                foreach (String csvName in inCsvFileNameLists[i])
                {
                    setValue.CsvName.Add(ClsPath.CombinePath(CST_WONDERFUL_REPORT_DIR, csvName));
                }

                mlstWfrCsv.Add(setValue);
            }
        }


        #endregion

        #region MustOverride


        /// <summary>印字済みのイベント</summary>
        protected event OnPrintAfterEventHandler OnPrintAfter;
        /// <summary>印字済みイベントのハンドル</summary>
        protected delegate void OnPrintAfterEventHandler();
   

        #endregion

        #region Function

        private bool Execute(bool _Preview)
        {

            try
            {
                /*
                // 前回実行ＣＳＶが残っている場合は削除
                ClsFile.Delete(System.IO.Path.Combine(mOutputDir, mCsvName));

                if (_GetData)
                {

                    // データ取得
                    mMainDt = CanGetData();

                    // 件数チェック
                    if (mMainDt is null || mMainDt.Rows.Count == 0)
                    {
                        return false;
                    }
                }

                // Csvデータ作成
                mCsvData = CreateCsv();
                if (ClsCheck.IsNull(mCsvData))
                {
                    return false;
                }
                
                // 書込み
                ClsFile.Delete(System.IO.Path.Combine(mOutputDir, mCsvName));
                ClsFile.Write(System.IO.Path.Combine(mOutputDir, mCsvName), mCsvData);
                */
                frmPreview frmPreview;

                // プレビュー画面インスタンス生成
                // frmPreview = new frmPreview(mOutputDir);
                // frmPreview = new frmPreview(mOutputDir, mWfrName, mCsvName, mTitle, mDriverName, mOffsetX, mOffsetY, mExistHeader, "", mPaperNm, mDirection);

                frmPreview = new frmPreview(mlstWfrCsv
                                          , mTitle
                                          , mDriverName
                                          , mOffsetX
                                          , mOffsetY
                                          , mExistHeader
                                          , ""
                                          , mPaperNm
                                          , mDirection
                                       );

                if (_Preview)
                {
                    frmPreview.ShowDialog();

                    mIsPrint = frmPreview.IsPrint;
                }
                else
                {
                    // 直接印字
                    mIsPrint = frmPreview.DirectPrint();
                }
                if (!mIsPrint)
                {
                    clsLogger.Info(frmPreview.ErrorMessage);
                }
                frmPreview.Dispose();
                frmPreview = null;

                if (mIsPrint)
                {
                    //mbolAfterRet = true;
                    OnPrintAfter?.Invoke();
                }

                return mIsPrint;
            }

            catch
            {
                // ClsMsgBox.SystemErrorMsg(ex, Me.mfrm.ClsLog, Me.mfrm.Text)
                return false;
            }
            finally
            {
                // ステータス、プログレスバーを非表示
                // Call mfrm.ProgressBarExit()
            }



        }

        /// <summary>
        /// 印刷実行 プレビュー表示を行わない
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool ExecutePrint()
        {

            return Execute(false);
        }

        /// <summary>
        /// プレビューを表示する
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool ExecutePreview()
        {

            return Execute(true);
        }


        public void Setting(string printer, string paper_nm, double offset_yoko = 0, double offset_tate = 0)
        {
            mDriverName = printer;
            mPaperNm = paper_nm;
            mOffsetX = offset_yoko;
            mOffsetY = offset_tate;
        }
        #endregion

        #region Method

        // ''' <summary>
        // ''' 値セット
        // ''' </summary>
        // ''' <remarks></remarks>
        // Private Sub Initialize(ByVal _id As XmlFileListLib.EnumFile)

        // mOutputDir = XmlSystemLib.GetValue(EnumSystem.DirReport)
        // mWfrName = XmlFileListLib.GetData(_id).FileName & ConstLib.ExtensionWfr
        // mCsvName = XmlFileListLib.GetData(_id).FileName & ConstLib.ExtensionCsv
        // mTitle = XmlFileListLib.GetData(_id).Title

        // End Sub

        ////// <summary>初期処理を行います。</summary>
        ////// <remarks>この関数は、コンストラクタ処理時に1度だけ呼び出してください。</remarks>
        //private int InitializefrmPreviewWfr()
        //{

        //    mReportId = string.Empty;
        //    mTitle = string.Empty;
        //    mWfrName = string.Empty;
        //    mStatus = IPrint.EnumStatus.StatusNone;
        //    mErrorCode = 0;
        //    mErrorParameter = null;

        //    return (int)IPrint.EnumResult.ResultOK;

        //}


        #region  csvファイル処理関連 

        /// <summary>csvファイル用の文字列配列を、csvフォーマットの文字列へ結合します。</summary>
        /// <param name="strColumns">文字列配列</param>
        /// <param name="_Crlf">改行判定</param>
        /// <returns>
        /// 結合されたcsvフォーマットの文字列を返します。(文字列の終端に、vbCrLf を含みます)、
        /// パラメータに誤りがある時は、 String.Empty を返します。</returns>
        /// <remarks></remarks>
        protected string JoinCsv(ref string[] strColumns, bool _Crlf = true)
        {
            string[] strWorks;

            // パラメータをチェックします。
            if (strColumns == null || strColumns.Length <= 0)
                return string.Empty;

            strWorks = new string[strColumns.Length];
            for (int i = 0, loopTo = strColumns.Length - 1; i <= loopTo; i++)
                // " → "" へ変換します。
                // strWorks(i) = ClsConvert.ToFullWideTild(Strings.Replace(strColumns(i), """", """"""))
                strWorks[i] = Strings.Replace(strColumns[i], "\"", "\"\"");
            if (_Crlf)
            {
                return "\"" + Strings.Join(strWorks, "\",\"") + "\"" + Constants.vbCrLf;
            }
            else
            {
                return "\"" + Strings.Join(strWorks, "\",\"") + "\"";
            }

        }

        #endregion

        #endregion

    }

}