using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SmtLib
{
    /// <summary>
    /// 出力
    /// </summary>
    public class clsExport
    {
        /// <summary>
        /// 拡張子
        /// </summary>
        public enum TextType
        {
            /// <summary>
            /// .txt
            /// </summary>
            TXT,
            /// <summary>
            /// .csv
            /// </summary>
            CSV,
        }

        /// <summary>
        /// テキスト操作時の文字エンコーディング
        /// </summary>
        /// <remarks>
        /// テキスト操作を行う際の文字エンコーディングを設定・取得する。<br />
        /// 初期値：日本語 (シフトJIS)
        /// </remarks>
        public static Encoding TextEncoding { get; set; } = Const_Encoding.ShiftJIS;

        /// <summary>
        /// テキストファイルに出力
        /// </summary>
        /// <param name="filePath">出力先</param>
        /// <param name="type">拡張子</param>
        /// <param name="dt">出力データ</param>
        /// <param name="exportHeader"> カラムヘッダーを出力するかの判定 (初期値:true)</param>
        /// <param name="exportQuotation"> 文字を括るかの判定 (初期値:true) </param>
        /// <param name="delimiter">区切り(初期値:カンマ)</param>
        /// <param name="regexPattern">正規表現による特定の文字を除外する際の除外パターン (Emptyの場合、除外しない) </param>
        /// <param name="IsRejectControlChar"> 制御文字を除外するかの判定 (初期値:false) </param>
        /// <remarks>
        /// [TextType]で指定した形式のファイルを、指定したPATH(ディレクトリ + ファイル名)に出力する。<br />
        /// [exportHeader]が[真]の場合、DataTable.columnsの[column.Name]をヘッダ項目として１行目に出力する。<br />
        /// [exportQuotation]が[真]の場合、出力時に全ての値を["]:ダブルクォーテーションで括る。<br />
        /// [delimiter]で区切り文字を指定する。(初期値:カンマ)。<br />
        /// [regexPattern]を指定した場合、指定したパターンを正規表現として、指定した文字を除外する。(Emptyの場合、除外しない)<br />
        /// [IsRejectControlChar]が[真]の場合、制御文字を除外する。
        /// </remarks>
        public static void Text(string filePath, 
                                TextType type, 
                                DataTable dt, bool 
                                exportHeader = true, 
                                bool exportQuotation = true, 
                                string delimiter = ",",
                                string regexPattern  = "",
                                bool IsRejectControlChar = false)
        {
            try
            {
                filePath = filePath.Trim();
                string folderPath = Path.GetDirectoryName(filePath);
                string filename = Path.GetFileName(filePath);
                if (string.IsNullOrEmpty(filename))
                {
                    throw new Exception("ファイル名が入力されていません。");
                }

                string ext = Path.GetExtension(filePath);
                if (!string.IsNullOrEmpty(ext))
                {
                    ext = ext.ToLower();
                }
                switch (type)
                {
                    case TextType.TXT:
                        if(ext != ".txt")
                        {
                            filename += ".txt";
                        }
                        break;
                    case TextType.CSV:
                        if(ext != ".csv")
                        {
                            filename += ".csv";
                        }
                        break;
                    default:
                        throw new Exception("拡張子を確認してください。");
                }

                if (!string.IsNullOrEmpty(folderPath) && !Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                using (var fs = new FileStream(Path.Combine(folderPath, filename), FileMode.Create, FileAccess.ReadWrite))
                using (var sw = new StreamWriter(fs, clsExport.TextEncoding))
                {
                    var sbRow = new StringBuilder();
                    if (exportHeader)
                    {
                        var headers = dt.Columns;
                        for (int i = 0, loopTo = headers.Count - 1; i <= loopTo; i++)
                        {
                            var columnName = headers[i].ColumnName;

                            // 正規表現による特定の文字を除外する場合
                            if (!string.IsNullOrWhiteSpace(regexPattern))
                            {
                                columnName = Regex.Replace(columnName, regexPattern, string.Empty);
                            }

                            // 制御文字を除外する場合
                            if (IsRejectControlChar)
                            {
                                columnName = new string(columnName.Where(c => !char.IsControl(c)).ToArray());
                            }

                            if (exportQuotation)
                            {
                                // ヘッダ名にダブルクォーテーションがあった場合はエスケープ（ 「"」二個に）する
                                columnName = columnName.Replace("\"", "\"\"");

                                sbRow.Append($"\"{columnName}\"");
                            }
                            else
                            {
                                sbRow.Append($"{columnName}");
                            }
                            if (i != headers.Count - 1)
                            {
                                sbRow.Append(delimiter);
                            }
                        }
                        sw.WriteLine(sbRow.ToString());
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        sbRow = new StringBuilder();
                        for (int i = 0, loopTo1 = dt.Columns.Count - 1; i <= loopTo1; i++)
                        {
                            var value = row.ItemArray[i].ToString();

                            // 正規表現による特定の文字を除外する場合
                            if (!string.IsNullOrWhiteSpace(regexPattern))
                            {
                                value = Regex.Replace(value, regexPattern, string.Empty);
                            }

                            // 制御文字を除外する場合
                            if (IsRejectControlChar)
                            {
                                value = new string(value.Where(c => !char.IsControl(c)).ToArray());
                            }

                            // 文字列の括りを行う場合
                            if (exportQuotation)
                            {
                                // 出力内容にダブルクォーテーションがあった場合はエスケープ（ 「"」二個に）する
                                value = value.Replace("\"", "\"\"");

                                sbRow.Append($"\"{value}\"");
                            }
                            else
                            {
                                sbRow.Append($"{value}");
                            }
                            if (i != dt.Columns.Count - 1)
                            {
                                sbRow.Append(delimiter);
                            }
                        }
                        sw.WriteLine(sbRow.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                throw ex;
            }
        }

        /// <summary>
        /// シートフォーマット
        /// </summary>
        public class SheetFormat
        {
            /// <summary>
            /// 出力データ
            /// </summary>
            public DataTable data;
            /// <summary>
            /// 列フォーマット一覧
            /// </summary>
            public Columns lstColumn;
            /// <summary>
            /// セールマージ一覧
            /// </summary>
            public MergeCells lstMergeCell;
            public SheetFormat(DataTable dt)
            {
                data = dt;
            }

        }

        /// <summary>
        /// DataTableの内容で EXCEL出力（ClosedXML)
        /// 戻り値：
        /// 　　-1以下：失敗
        /// 　　0　　 ：成功
        /// 　　1　　 ：キャンセル
        /// </summary>
        public static int Excel(DataTable dt, string fileName = "", string pathID = "")
        {
            ExportExcel ee;

            if (ClsCheck.IsNull(pathID))
            {
                ee = new ExportExcel(dt, fileName);
            }
            else
            {
                ee = new ExportExcel(dt, fileName, pathID);
            }
            return ee.OutPutMain();
        }



        /// <summary>
        /// エクセルフォーマット
        /// </summary>
        /// <param name="lstSheets">シートフォーマット一覧</param>
        /// <param name="filePath">出力先</param>
        /// <param name="exportHeader">ヘッダーを出力するか</param>
        public static void Excel(List<SheetFormat> lstSheets, string filePath, bool exportHeader = false)
        {
            Excel(lstSheets, filePath, exportHeader, null);
        }
        public static void Excel(List<SheetFormat> lstSheets, string filePath, bool exportHeader, Stylesheet stylesheet)
        {
            filePath = filePath.Trim();
            // Create a new spreadsheet document
            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                uint _SheetId = 1;
                // Add a workbook part to the document
                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                // Add a style
                WorkbookStylesPart stylesPart = spreadsheetDocument.WorkbookPart.AddNewPart<WorkbookStylesPart>();
                if (stylesheet != null)
                {
                    stylesPart.Stylesheet = stylesheet;
                    stylesPart.Stylesheet.Save();
                }
                else
                {
                    stylesPart.Stylesheet = DefaultStyleSheet();
                    stylesPart.Stylesheet.Save();
                }

                string[] colExcel = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

                // Add a Sheets object to the workbook
                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
                foreach (SheetFormat _sheet in lstSheets)
                {
                    // Add a worksheet part to the workbook
                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());
                    // Append a new sheet and get its ID
                    Sheet sheet = new Sheet()
                    {
                        Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                        SheetId = _SheetId,
                        Name = string.IsNullOrEmpty(_sheet.data.TableName) ? $"book{_SheetId}" : _sheet.data.TableName
                    };

                    if(_sheet.lstMergeCell != null)
                    {
                        worksheetPart.Worksheet.InsertAfter(_sheet.lstMergeCell, worksheetPart.Worksheet.Elements<SheetData>().First());
                    }
                    if(_sheet.lstColumn != null)
                    {
                        worksheetPart.Worksheet.InsertAt(_sheet.lstColumn, 0);
                    }
                    sheets.Append(sheet);

                    //// Get the sheet data
                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                    CellValues dataType = CellValues.String;
                    uint styleIndex = 0;
                    int i = 0;
                    if (exportHeader)
                    {
                        //Add data header
                        Row dataRow = new Row();
                        for (int j = 0; j < _sheet.data.Columns.Count; j++)
                        {
                            string cellPosition = "";
                            if (j + 1 > colExcel.Length)
                            {
                                cellPosition = colExcel[(j + 1) / colExcel.Length - 1];
                            }
                            cellPosition += colExcel[(j + 1) % colExcel.Length - 1];
                            cellPosition += i + 1;
                            Cell cell = CreateCell(cellPosition, _sheet.data.Columns[j].ToString(), dataType, styleIndex);
                            dataRow.Append(cell);
                        }
                        // Add more data as needed
                        sheetData.AppendChild(dataRow);
                        i++;
                    }

                    // Add data rows
                    for (; i <= _sheet.data.Rows.Count; i++)
                    {
                        Row dataRow = new Row();
                        var rows = _sheet.data.Rows[i - 1];
                        for (int j = 0; j < rows.ItemArray.Length; j++)
                        {
                            string cellPosition = "";
                            if (j + 1 > colExcel.Length)
                            {
                                cellPosition = colExcel[(j + 1) / colExcel.Length - 1];
                            }
                            cellPosition += colExcel[(j + 1) % colExcel.Length - 1];
                            cellPosition += i + 1;
                            string value = rows.ItemArray[j].ToString();
                            Cell cell = CreateCell(cellPosition, value, dataType, styleIndex);
                            dataRow.Append(cell);
                        }
                        // Add more data as needed
                        sheetData.AppendChild(dataRow);
                    }
                    // Save the spreadsheet document
                    workbookPart.Workbook.Save();
                    _SheetId++;
                }

                // Close the spreadsheet document
                spreadsheetDocument.Dispose();
            }
        }

        private static Cell CreateCell(string cellReference, string cellValue, CellValues dataType, UInt32 styleIndex)
        {
            //return new Cell(new InlineString(new Text(cellValue))) { DataType = dataTye };
            return new Cell() { CellReference = cellReference, DataType = dataType, CellValue = new CellValue(cellValue)};
        }

        private static Stylesheet DefaultStyleSheet()
        {
            return new Stylesheet(
            new Fonts(
                // Index 0 - The default font.
                new Font(new FontSize() { Val = 11 }, new Color() { Rgb = new HexBinaryValue() { Value = "000000" } }, new FontName() { Val = "游ゴシック" })
            ),

            new Fills(
                // Index 0 - The default fill.
                new Fill(new PatternFill() { PatternType = PatternValues.None })
            ),
            new Borders(
                // Index 0 - The default border.
                new Border(
                    new LeftBorder(),
                    new RightBorder(),
                    new TopBorder(),
                    new BottomBorder(),
                    new DiagonalBorder()
                )
            ),
            new CellFormats(
                // Index 0 - The default cell style. If a cell does not have a style index applied it will use this style combination instead
                new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 }
                )
            );
        }

        private static Stylesheet GenerateStyleSheet() // Sample
        {
            return new Stylesheet(
            new Fonts(
                // Index 0 - The default font.
                new Font(new FontSize() { Val = 11 }, new Color() { Rgb = new HexBinaryValue() { Value = "000000" } }, new FontName() { Val = "游ゴシック" }),
                // Index 1 - The bold font.
                new Font(new Bold(), new FontSize() { Val = 11 }, new Color() { Rgb = new HexBinaryValue() { Value = "000000" } }, new FontName() { Val = "游ゴシック" }),
                // Index 2 - The Italic font.
                new Font(new Italic(), new FontSize() { Val = 11 }, new Color() { Rgb = new HexBinaryValue() { Value = "000000" } }, new FontName() { Val = "游ゴシック" }),
                // Index 3 - The Times Roman font. with 16 size
                new Font(new FontSize() { Val = 16 }, new Color() { Rgb = new HexBinaryValue() { Value = "000000" } }, new FontName() { Val = "游ゴシック" })
            ),

            new Fills(
                // Index 0 - The default fill.
                new Fill(new PatternFill() { PatternType = PatternValues.None }),
                // Index 1 - The default fill of gray 125 (required)
                new Fill(new PatternFill() { PatternType = PatternValues.MediumGray }),
                // Index 2 - The yellow fill.
                new Fill(new PatternFill(new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFFFFF00" } }) { PatternType = PatternValues.Solid }),
                // Index 3 - The grey fill.
                new Fill(new PatternFill(new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFE0E0E0" } }) { PatternType = PatternValues.Solid })
            ),
            new Borders(
                // Index 0 - The default border.
                new Border(
                    new LeftBorder(),
                    new RightBorder(),
                    new TopBorder(),
                    new BottomBorder(),
                    new DiagonalBorder()
                ),
                // Index 1 - Applies a Left, Right, Top, Bottom border to a cell
                new Border(
                    new LeftBorder(
                        new Color() { Auto = true }
                    ){ Style = BorderStyleValues.Thin },
                    new RightBorder(
                        new Color() { Auto = true }
                    ){ Style = BorderStyleValues.Thin },
                    new TopBorder(
                        new Color() { Auto = true }
                    ){ Style = BorderStyleValues.Thin },
                    new BottomBorder(
                        new Color() { Auto = true }
                    ){ Style = BorderStyleValues.Thin },
                    new DiagonalBorder())
            ),
            new CellFormats(
                // Index 0 - The default cell style. If a cell does not have a style index applied it will use this style combination instead
                new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 },
                // Index 1 - Background is Gray, Alignment is Center, Bolder (Header)
                new CellFormat() { FontId = 0, FillId = 3, BorderId = 1, ApplyFont = true, Alignment = new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center } },
                // Index 2 - Alignment is Center, Bolder (Content)
                new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyFont = true, Alignment = new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center } },
                // Index 3 - Alignment is Left, Bolder (Content)
                new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyFont = true, Alignment = new Alignment() { Horizontal = HorizontalAlignmentValues.Left, Vertical = VerticalAlignmentValues.Center } },
                // Index 4 - Alignment is Right, Bolder (Content)
                new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyFont = true, Alignment = new Alignment() { Horizontal = HorizontalAlignmentValues.Right, Vertical = VerticalAlignmentValues.Center } },
                // Index 5 - Alignment is Right, Bolder (Content), Currency Format
                new CellFormat() { NumberFormatId = 3, FontId = 0, FillId = 0, BorderId = 1, ApplyFont = true, Alignment = new Alignment() {Vertical = VerticalAlignmentValues.Center } }
                )
            ); // return
        }
    }
}