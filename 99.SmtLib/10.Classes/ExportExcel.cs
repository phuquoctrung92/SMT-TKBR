using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using SmtLib;
using SmtLib.DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmtLib
{
    internal class ExportExcel : ExcelBase
    {
        private DataTable ExpData;


        public ExportExcel(DataTable dt,string fileName,string pathid = "dataExcel") :base() {

            mbolGetData = true;
            mPathID = pathid;
            mFileNm = fileName;
            ExpData = dt;
        }


        protected override DataTable CanGetData()
        {
            return ExpData;
        }

        protected override int SetSheet()
        {
             try{
                openFile();

                Dictionary<string, (int sheetNo, int lastRow)> sheetsParam = new Dictionary<string, (int sheetNo, int lastRow)>();

                var colsTeigi = new List<(string name,int lenb)>();

                foreach (DataColumn col in mMainDt.Columns)
                {
                    colsTeigi.Add((col.ToString(), ClsConvert.LenB(col.ToString())) );
                    mSheet[0].Range(GetCellRange(1, colsTeigi.Count())).Value = col.Caption;
                }
                // ヘッダ部分の書式設定
                mSheet[0].Range(GetCellRange(1, 1, 1, colsTeigi.Count())).Style.Fill.BackgroundColor = XLColor.WhiteSmoke;
                mSheet[0].Range(GetCellRange(1, 1, 1, colsTeigi.Count())).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                int row = 2;
                foreach(DataRow dr in mMainDt.Rows)
                {
                    // 対象シート名を取得
                    for(int i = 0; i <  colsTeigi.Count; i++)
                    {
                        mSheet[0].Range(GetCellRange(row, i + 1)).Value = dr[colsTeigi[i].name].ToString();
                        if(colsTeigi[i].lenb < ClsConvert.LenB(dr[colsTeigi[i].name].ToString()))
                        {
                            var tmp = colsTeigi[i];
                            tmp.lenb = ClsConvert.LenB(dr[colsTeigi[i].name].ToString());
                            colsTeigi[i] = tmp;
                        }

                    }
                    row++;
                }


                // フォント
                mSheet[0].Range(GetCellRange(1, 1, row - 1, colsTeigi.Count())).Style.Font.FontName = "游ゴシック";

                // 罫線
                mSheet[0].Range(GetCellRange(1, 1, row - 1, colsTeigi.Count())).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                mSheet[0].Range(GetCellRange(1, 1, row - 1, colsTeigi.Count())).Style.Border.InsideBorder = XLBorderStyleValues.Thin;


                // 幅調整
                // ※ mSheet[0].ColumnsUsed().AdjustToContents(); とすると自動調整されるが、日本語混じると正しく調整してくれない。
                for(int i = 0;i < colsTeigi.Count; i++)
                {
                    mSheet[0].Column(i + 1).Width = colsTeigi[i].lenb * 1.4; // ちょうせいむずい
                }


                return 0;
            }catch(Exception ex){
                clsLogger.Error(ex.ToString());

                return -1;
            }
        }

        
        private void openFile(){


            try{
                var xlMotoBook = new XLWorkbook();

                //１シート目の処理
                mBook = xlMotoBook;
                if (ClsCheck.IsNull(ExpData.TableName))
                {
                    mBook.AddWorksheet("sheet1");
                }
                else
                {
                    mBook.AddWorksheet(ExpData.TableName);
                }

                Array.Resize(ref mSheet, 1);
                mSheet[0] = mBook.Worksheet(1);
            }
            catch(Exception ex){

                throw ex;
            }
     
        }
    }
}
