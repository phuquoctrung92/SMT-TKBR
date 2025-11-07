using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using ClosedXML;
using ClosedXML.Excel;
using Microsoft.VisualBasic;

namespace SmtLib
{


    /// <summary>
    /// Excel出力処理のベース
    /// </summary>
    /// <remarks></remarks>
    /// <memo>
    /// BarStarどうしますか？
    /// </memo>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create  1.00              H.Ohta      新規作成
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public abstract class ExcelBase
    {

        #region 定数

        /// <summary> Path.XML用Excel出力ID </summary>
        /// <remarks></remarks>
        protected const string CST_EXCEL_ID = "ExcelFile";

        /// <summary> Path.xmlのID Exportは同じフォルダを指定するため固定 </summary>
        /// <remarks></remarks>
        protected const string CST_EXPORT_ID = "Export";

        /// <summary> テンプレートのシート名 </summary>
        protected const string C_TEMP_SHEETNM = "Format";

        /// <summary> 一覧の最大行数 </summary>
        protected const int MAX_LINE = 50;      // 最大行数

        #endregion

        #region 変数

        /// <summary>  </summary>
        protected XLWorkbook mBook;
        /// <summary> シート配列（複数対応） </summary>
        protected IXLWorksheet[] mSheet;

        protected DataTable mMainDt;

        protected string mOutFolder;

        protected string mExcelFolderId;

        /// <summary> Trueの場合だけ出力処理最初でデータの取得を行う </summary>
        public bool mbolGetData { get; set; }

        public string mFilePath { get; set; }

        /// <summary> 出力後にフォルダを開くフラグ（初期値False） </summary>
        protected bool mbolFolderOpen;

        /// <summary> Path.xml用のID </summary>
        protected string mPathID;

        /// <summary> ファイル名 </summary>
        protected string mFileNm;

        protected bool mbolFileSave;

        #endregion

        #region New

        /// <summary>
        /// New
        /// </summary>
        /// <remarks></remarks>
        protected ExcelBase()
        {
            mbolGetData = true;
            mbolFolderOpen = false;
            mbolFileSave = true;
        }


        #endregion

        #region MustOverride

        /// <summary>
        /// データ取得処理
        /// </summary>
        /// <remarks></remarks>
        protected abstract DataTable CanGetData();

        /// <summary>
        /// CSV作成
        /// </summary>
        /// <remarks></remarks>
        protected abstract int SetSheet();


        #endregion

         /// <summary> Excelディレクトリ </summary>
        public string CST_EXCEL_TEMPLETE
        {
            get 
            {
                return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "excel");
            }
        }


        #region 出力処理

        /// <summary>
        /// 出力メイン処理
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public int OutPutMain()
        {

            try
            {


                if (mbolGetData)  // 取得フラグがTrueの場合だけ取得処理を行う
                {
                    // データ取得
                    mMainDt = CanGetData();

                    if (mMainDt is null || mMainDt.Rows.Count == 0)
                    {
                        // ClsMsgBox.ShowMessage(Me.mForm.Text, "E004", "該当データ")
                        return -2;
                    }
                }

                // 出力処理
                if (SetSheet() != 0)
                {
                    return -1;
                }

                if (!mbolFileSave)
                {
                    return 0;
                }

                // シートが2枚以上ある場合先頭をアクティブにする
                /*
                if (mSheet is not null && mSheet.Length != 0 && mSheet[0] is not null)
                {
                    
                    mSheet[0].Cell(1,1).Select();

                }*/

                // 保存処理
                switch (SaveExcelFile())
                {
                    case 0:
                        {
                            if (mbolFolderOpen)
                                Process.Start(ClsFile.GetDirectoryName(mFilePath));

                            // ClsMsgBox.ShowMessage(ClsMsgBox.MessageTypes.Custom, "I001", "出力", Me.mForm.Text)
                            return 0;
                        }
                    case 1:
                        {
                            return 1;
                        }

                    default:
                        {
                            // ClsMsgBox.ShowMessage(ClsMsgBox.MessageTypes.Custom, "E005", "出力", Me.mForm.Text)
                            return -1;
                        }
                }
            }

            catch
            {
                return -1;
            }
            finally
            {
            }

        }


        #endregion

        #region 保存処理共通
        /// <summary>
        /// 保存処理共通
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        protected int SaveExcelFile()
        {

            try
            {

                // ダイアログを出すかどうか
                if (ClsCheck.IsNull(mFilePath))
                {


                    var xml = new ClsXml("Path.xml");

                    string f = xml.GetValue(ClsXml.XML_PATH_NODE_NAME, ClsXml.XML_PATH_MEMBER_DIR, ClsXml.XML_PATH_MEMBER_ID + "='" + mPathID + "'");


                    string file = mFileNm;

                    if (!ClsCheck.IsNull(f))
                    {

                        // file = ClsFile.GetFileName(f)
                        f = ClsFile.GetDirectoryName(f);
                    }


                    mFilePath = ClsDialog.SaveFileDialog(f, file, new string[] { "Excelのファイル(*.xlsx;*.xls)|*.xlsx;*.xls" });

                    // 出力ダイアログの表示
                    if (!ClsCheck.IsNull(mFilePath))
                    {

                        // ファイルの存在チェック
                        if (ClsFile.IsExist(mFilePath))
                        {
                            // すでにファイルがある時、一度ファイルを削除します。
                            ClsFile.Delete(mFilePath);
                        }
                        mBook.SaveAs(mFilePath);


                        xml.CanSavePathXml(ClsXml.XML_PATH_NODE_NAME, ClsXml.XML_PATH_MEMBER_ID, mPathID, ClsXml.XML_PATH_MEMBER_DIR, mFilePath);



                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }

                else
                {
                    // ダイアログを出力しないで保存する

                    // 'ファイルの存在チェック
                    // If ClsFile.IsExist(Me.mFilePath) Then
                    // ' すでにファイルがある時、一度ファイルを削除します。
                    // ClsFile.Delete(Me.mFilePath)
                    // End If
                    // Save the Workbook and quit Excel.

                    mBook.SaveAs(mFilePath);

                    // If CDbl(Me.mApp.Application.Version) < 12 Then
                    // Me.mBook._SaveAs(Me.mFilePath)
                    // Else
                    // Me.mBook.SaveAs(Me.mFilePath, 56) 'Excel2007で2003以前バージョン保存対応
                    // End If

                    return 0;
                }
            }

            catch
            {
                return -1;

                // If TypeOf (ex) Is System.Runtime.InteropServices.COMException AndAlso _
                // InStr(ex.Message, "にアクセスできません") > 0 Then
                // If ClsMsgBox.ShowMsg(Me.mForm.MsgBoxKbn, "Q999", 
                // Me.mFilePath & "を保存できませんでした。" & vbCrLf & _
                // "ファイルが開かれていないか確認してください。" & vbCrLf & _
                // "続行しますか？" & vbCrLf & _
                // "(続行する場合は開いているファイルを閉じて、はいをクリックしてください。)", 
                // Me.mForm.Text, 
                // ClsMsgBox.MsgButton.Button1 _
                // ) = MsgBoxResult.No Then
                // Return -1
                // End If
                // Else
                // Throw ex
                // End If

            }

        }

        #endregion



        #region Excelのセル形式を返す。

        /// <summary>
        /// Excelのセル形式を返す。
        /// ex.（A1、A1:B2）など
        /// </summary>
        /// <param name="r1">１つ目縦</param>
        /// <param name="c1">１つ目横</param>
        /// <param name="r2">２つ目縦（省略可能）</param>
        /// <param name="c2">２つ目横（省略可能）</param>
        /// <returns>ExcelのCell形式（A1、B1:C2）</returns>
        /// <remarks></remarks>
        protected string GetCellRange(int r1, int c1, int r2 = 0, int c2 = 0)


        {

            // A1形式のアドレスをR1C1形式に変換する関数
            int i1, i2;
            string d1, d2;
            i1 = Conversion.Int((c1 - 1) / 26);
            d1 = Interaction.IIf(c1 > 26, Strings.Chr(64 + i1), "").ToString();
            i1 = c1 - 26 * i1;
            d1 += Strings.Chr(64 + i1) + r1.ToString();

            if (r2 == 0 && c2 == 0)
            {
                return d1;
            }

            i2 = Conversion.Int((c2 - 1) / 26);
            d2 = Interaction.IIf(c2 > 26, Strings.Chr(64 + i2), "").ToString();
            i2 = c2 - 26 * i2;
            d2 += Strings.Chr(64 + i2) + r2.ToString();
            return d1 + ":" + d2;

        }

        #endregion

    
        #region セルの書式一括設定

        /// <summary>
        /// セルの書式一括設定
        /// </summary>
        /// <param name="_sheet"></param>
        /// <param name="_arry"></param>
        /// <param name="_format"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected bool SetCellFormat(ref IXLWorksheet _sheet, ArrayList _arry, string _format = "@")

        {

            IXLRange rng;


            // セルの書式設定
            if (!ClsCheck.IsNull(_arry) && _arry.Count != 0)
            {
                string strFormatString = string.Empty;
                int cnt = 0;
                for (int i = 0, loopTo = _arry.Count - 1; i <= loopTo; i++)
                {
                    // セルの範囲文字列をカンマ区切りで作成する
                    // Excel の仕様上(?)、255(256?)Byte を超えるとエラーになるので 255Byte に制限する
                    if ((strFormatString + "," + _arry[i].ToString()).Length > 255)
                    {
                        rng = _sheet.Range(strFormatString);

                        rng.Style.NumberFormat.SetFormat(_format);

                        cnt = 0;
                    }
                    if (cnt == 0)
                    {
                        strFormatString = _arry[i].ToString();
                    }
                    else
                    {
                        strFormatString += "," + _arry[i].ToString();
                    }
                    cnt += 1;
                }
                // 残りのセルの書式設定
                if (!string.IsNullOrEmpty(strFormatString))
                {
                     rng = _sheet.Range(strFormatString);

                     rng.Style.NumberFormat.SetFormat(_format);
                }
            }

            return true;

        }

        #endregion

    }
}