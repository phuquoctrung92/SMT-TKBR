using SmtLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using CtrlLib.MyForms;

namespace CtrlLib.MyControls
{
    /// <summary>
    /// DataGridViewカラム設定
    /// </summary>
    /// <remarks>
    /// コードにて[DatagridView]の項目を定義する為、カラムに対する設定値を設定するクラス
    /// ⇒ 当該のクラスを用いて良いか未確認(※ 既存のSourceに合わせるほうが望ましい？)の為、
    /// 内部クラスとして定義する。もし、当該のようなクラスが用いれる場合は、共通に定義したほうが嬉しいです。
    /// </remarks>
    public class GridColumnInfo
    {
        /// <summary>
        /// 定数：[dataGridView]列種類
        /// </summary>
        /// <remarks>
        /// Columnのプロパティ[ColumnType]はデザイナのみで、
        /// 各カラム列のクラスを一覧表示している為、プロパティを操作できない。
        /// よって、各カラムの定数を設定。
        /// </remarks>
        public enum ColumnType
        {
            /// <summary> テキスト型[DataGridViewTextBoxColumnクラス] </summary>
            TextBox,
            /// <summary> チェックボックス型[DataGridViewCheckBoxColumnクラス] </summary>
            CheckBox,
            /// <summary> イメージ型[DataGridViewImageColumnクラス] </summary>
            Image,
            /// <summary> ボタン型[DataGridViewButtonColumnクラス] </summary>
            Button,
            /// <summary> ドロップダウンリスト型[DataGridViewComboBoxColumnクラス] </summary>
            ComboBox,
            /// <summary> リンク(アドレス)型[DataGridViewLinkColumnクラス] </summary>
            Link
        }

        /// <summary>
        ///  カラム型(DataGridView　Column class)
        /// </summary>
        public ColumnType Type { get; set; } = ColumnType.TextBox;

        /// <summary>
        ///  カラム名(DataGridView)
        /// </summary>
        public string ColunmName { get; set; }

        /// <summary>
        ///  カラム表示名(DataGridView)
        /// </summary>
        public string HeaderDispName { get; set; }

        /// <summary>
        /// カラムのソート仕様
        /// </summary>
        public DataGridViewColumnSortMode SortMode { get; set; } = DataGridViewColumnSortMode.Automatic;

        /// <summary>
        /// カラムの読取可否
        /// </summary>
        public bool IsReadOnly { get; set; } = false;

        /// <summary>
        /// カラムの幅(px)
        /// </summary>
        public int Width { get; set; } = 100;

        /// <summary>
        /// カラムの可視可否
        /// </summary>
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// カラムのスタイル
        /// </summary>
        /// <remarks>
        /// 個別で項目セルのスタイルを定義する場合に用いる。
        /// カスタムされたスタイルを設定する。
        /// </remarks>
        public DataGridViewCellStyle CellStyle { get; set; } = null;

        /// <summary>
        /// カラムヘッダのスタイル
        /// </summary>
        /// <remarks>
        /// 個別で項目ヘッダのスタイルを定義する場合に用いる。
        /// カスタムされたスタイルを設定する。
        /// </remarks>
        public DataGridViewCellStyle HeaderStyle { get; set; } = null;

        /// <summary>
        ///  データ連携(DataColumn)時の項目名(DataTableのカラム名)
        /// </summary>
        public string DataBindColunmName { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GridColumnInfo()
        {

        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="colName"> カラム名 </param>
        /// <param name="headerDispName"> ヘッダ表示文字 </param>
        /// <param name="width"> 列幅 </param>
        /// <param name="IsReadOnly"> 読み取り専用判定 </param>
        public GridColumnInfo(string colName, string headerDispName, int width, bool IsReadOnly)
        {
            this.ColunmName = colName;
            this.HeaderDispName = headerDispName;
            this.Width = width;
            this.IsReadOnly = IsReadOnly;
        }
        /// <param name="colName"> カラム名 </param>
        /// <param name="headerDispName"> ヘッダ表示文字 </param>
        /// <param name="bindName"> DataSource(DataTable)での項目名</param>
        /// <param name="width"> 列幅 </param>
        /// <param name="IsReadOnly"> 読み取り専用判定 </param>
        public GridColumnInfo(string colName, string headerDispName, string bindName, int width, bool IsReadOnly)
        {
            this.ColunmName = colName;
            this.HeaderDispName = headerDispName;
            this.DataBindColunmName = bindName;
            this.Width = width;
            this.IsReadOnly = IsReadOnly;
        }


        /// <summary>
        /// 表示設定(上下/中央・左右/右詰)
        /// </summary>
        /// <param name="format"> 表示書式(初期値：なし) </param>
        /// <returns> CellStyle </returns>
        /// <remarks>
        /// 基本的なカラムスタイル(上下/中央・左右/右詰)の定義。
        /// public [static]で定義するが、インスタンス化が望ましい場合は[static]定義を用いないこと。
        /// [static] ⇒ CellStyle = GridColumnInfo.CellStyle_Center("yyyy/MM/dd")
        /// 非[static] ⇒ CellStyle = new GridColumnInfo().CellStyle_Center("yyyy/MM/dd")。
        ///  ※ 使用される箇所の度に、当該クラスのインスタンス作成⇒破棄の想定。
        /// </remarks>
        public static DataGridViewCellStyle CellStyle_MiddleRight(string format = "")
        {
            return new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleRight,
                NullValue = null,
                Format = format
            };
        }

        /// <summary>
        /// 表示位置設定(上下/中央・左右/中央)
        /// </summary>
        /// <param name="format"> 表示書式(初期値：なし) </param>
        /// <returns> CellStyle </returns>
        /// <remarks>
        /// 基本的なカラムスタイル(上下/中央・左右/中央)の定義。
        /// public [static]で定義するが、インスタンス化が望ましい場合は[static]定義を用いないこと。
        /// [static] ⇒ CellStyle = GridColumnInfo.CellStyle_Center("yyyy/MM/dd")
        /// 非[static] ⇒ CellStyle = new GridColumnInfo().CellStyle_Center("yyyy/MM/dd")。
        ///  ※ 使用される箇所の度に、当該クラスのインスタンス作成⇒破棄の想定。
        /// </remarks>
        public static DataGridViewCellStyle CellStyle_Center(string format = "")
        {
            return new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                NullValue = null,
                Format = format
            };
        }

        /// <summary>
        /// カラム設定(TextBoxカラム)
        /// </summary>
        /// <returns> 各プロパティの値を用いた[DataGridViewTextBoxColumn] </returns>
        public DataGridViewTextBoxColumn CleateTextBoxColumn()
        {
            var col = new DataGridViewTextBoxColumn();

            if (!string.IsNullOrWhiteSpace(this.ColunmName))
            {
                col.Name = this.ColunmName;
            }

            if (!string.IsNullOrWhiteSpace(this.HeaderDispName))
            {
                col.HeaderText = this.HeaderDispName;
            }

            col.SortMode = this.SortMode;
            col.ReadOnly = this.IsReadOnly;
            col.Width = this.Width;

            col.Visible = this.IsVisible;

            if (!(this.HeaderStyle is null))
            {
                col.HeaderCell.Style = this.HeaderStyle;
            }

            if (!(this.CellStyle is null))
            {
                col.DefaultCellStyle = this.CellStyle;
            }

            if (!string.IsNullOrWhiteSpace(this.DataBindColunmName))
            {
                col.DataPropertyName = this.DataBindColunmName;
            }

            return col;
        }

        /// <summary>
        /// カラム設定(CheckBoxカラム)
        /// </summary>
        /// <returns> 各プロパティの値を用いた[DataGridViewCheckBoxColumn] </returns>
        public DataGridViewCheckBoxColumn CleateCheckBoxColumn()
        {
            var col = new DataGridViewCheckBoxColumn();

            if (!string.IsNullOrWhiteSpace(this.ColunmName))
            {
                col.Name = this.ColunmName;
            }

            if (!string.IsNullOrWhiteSpace(this.HeaderDispName))
            {
                col.HeaderText = this.HeaderDispName;
            }

            col.SortMode = this.SortMode;
            col.ReadOnly = this.IsReadOnly;
            col.Width = this.Width;

            col.Visible = this.IsVisible;

            if (!(this.HeaderStyle is null))
            {
                col.HeaderCell.Style = this.HeaderStyle;
            }

            if (!(this.CellStyle is null))
            {
                col.DefaultCellStyle = this.CellStyle;
            }

            if (!string.IsNullOrWhiteSpace(this.DataBindColunmName))
            {
                col.DataPropertyName = this.DataBindColunmName;
            }
            
            // チェック ボックス セルのフラット スタイルの外観を取得または設定
            col.FlatStyle = FlatStyle.Standard;

            // 3 種類のチェック状態を表示できるかどうか
            col.ThreeState = false;
            
            //col.CellTemplate = new DataGridViewCheckBoxCell();
            col.CellTemplate.Style.BackColor = Color.Beige;

            return col;
        }
    }

    /// <summary>
    /// 出力機能があるデータグリッドビュー
    /// </summary>
    public class DataGridView : System.Windows.Forms.DataGridView
    {
        private List<GridColumnInfo> _DataGridColumns;

        /// <summary>
        /// カラム設定(定義)
        /// </summary>
        /// <remarks>
        /// Setアクセサ内で、自身のプロパティを呼び出すと再帰LOOP(StackOverflow)が発生する。
        /// 当該の回避の為、プロパティにバッキング(静的変数)を用いる。
        /// もしくは、自動実装(public List＜GridColumnInfo＞ DataGridColumns { get; set; })にて定義後、
        /// 別のフェーズ(設定処理)などでカラム設定をおこなうようにすること。
        /// ※ [CleateTextBoxColumn]以外のセルを使用する場合は、修正を要す。
        ///    List＜GridColumnInfo＞に型の引数を用意 ⇒　
        ///    [CleateTextBoxColumn]を変更(修正)し、ほかの型のカラムを設定する　等
        ///    画面のコンストラクタ(InitializeComponent)でも呼び出される。その際のSetの値はNull。
        ///    ⇒ Nullの値が設定された場合、何もしないとする。
        /// ※ デザイナでカラムを定義・設定した場合、当該プロパティに値をSetするとカラム定義は書換られます。
        /// </remarks>
        [Browsable(false)]
        public List<GridColumnInfo> DataGridColumns 
        {
            get 
            { 
                return _DataGridColumns;
            } 
            set 
            {
                if (value is null )
                {
                    return;
                }
                _DataGridColumns = value;
                this.Columns.Clear();
                _DataGridColumns.ForEach(e => 
                { 
                    switch(e.Type)
                    {
                        case GridColumnInfo.ColumnType.TextBox:
                            this.Columns.Add(e.CleateTextBoxColumn());
                            break;

                        case GridColumnInfo.ColumnType.CheckBox:
                            this.Columns.Add(e.CleateCheckBoxColumn());
                            break;
                        default:
                            break;
                    }
                });
            }
        }

        /// <summary>
        /// 明細(GRID)設定 / 一覧表示用
        /// </summary>
        /// <remarks>
        /// 一覧表示用の明細設定
        /// ・ 複数行の選択 ⇒ 非許可。
        /// ・ セルの選択単位 ⇒ 行選択。
        /// ・ ヘッダ表示設定(白：背景 / 選択色：青)
        /// ・ ヘッダ高さ調整 ⇒ 非許可。　 
        /// ・ 列幅調整 ⇒ 許可。。
        /// </remarks>
        public void UseRowSelectedDefaultGridStyle()
        {
            this.MultiSelect = false;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            this.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            this.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Blue;
            this.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.AllowUserToResizeColumns = true;

            if (this.RowHeadersVisible)
            {
                this.RowHeadersWidth = 80;
                this.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.Grid_CellPainting);
            }
        }

        /// <summary>
        /// DataTableを取得
        /// </summary>
        /// <remarks>
        /// DataGridViewの内容を[DataTable]に変換する。
        /// </remarks>
        [Browsable(false)]
        public DataTable DataTable
        {
            get
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn col in Columns)
                {
                    dt.Columns.Add(col.DataPropertyName);
                }
                foreach (DataGridViewRow row in Rows)
                {
                    List<string> arrVal = new List<string>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        arrVal.Add(cell.Value != null ? cell.Value.ToString().Trim() : "");
                    }
                    dt.Rows.Add(arrVal.ToArray());
                }
                return dt;
            }
        }

        /// <summary>
        /// DataSourceよりDataTableを生成
        /// </summary>
        /// <remarks>
        /// DataSourceに設定されている[DataTable]の
        /// Column名をDataGridViewに表示されているヘッダの表示めいに変更して
        /// DataTableを返す。
        /// ※ Data自体はそのままの内容。
        /// </remarks>
        [Browsable(false)]
        public DataTable SourceConvertToDataTable
        {
            get
            {
                if (this.DataSource is null)
                {
                    return null;
                }

                if (!(this.DataSource is DataTable))
                {
                    return null;
                }

                var dt = ((DataTable)this.DataSource).Copy();

                dt.Columns.Cast<DataColumn>().
                           ToList().
                           ForEach(dc =>
                           {
                               var gridColumn = this.Columns.Cast<DataGridViewColumn>().
                                                             Where(gc => gc.DataPropertyName.Equals(dc.ColumnName)).
                                                             FirstOrDefault();
                               if (!(gridColumn is null))
                               {
                                   dc.ColumnName = gridColumn.HeaderText.Replace("\n", "").Replace("\r\n", "");
                               }
                           });

                return dt;
            }
        }

        /// <summary>
        /// テキストフォーマットに出力
        /// </summary>
        /// <param name="filePath">出力先</param>
        /// <param name="type">ファイルの拡張子</param>
        /// <param name="delimiter">区切り</param>
        /// <param name="exportHeader">ヘッダを出力</param>
        /// <param name="exportQuotation">データがクォーテーションに入れる</param>
        public void ExportText(string filePath, clsExport.TextType type, string delimiter = ",", bool exportHeader = true, bool exportQuotation = true)
        {
            clsExport.Text(filePath, type, DataTable, exportHeader, exportQuotation, delimiter);
        }

        /// <summary>
        /// 一覧の内容をそのままEXCEL出力
        /// 戻り値：
        /// 　　-1以下：失敗、　
        /// 　　0　　 ：成功、　
        /// 　　1　　 ：キャンセル
        /// </summary>
        public int ExportExcel(string fileName = "",List<string> dispCols = null, string pathID = "")
        {
            DataTable dt = SourceConvertToDataTable;

            if(dispCols != null)
            {
                // 指定ある場合、表示項目以外の列を削除

                List<string> dispColsName = new List<string>();
                foreach(var val in dispCols)
                {
                    var ht = getHeaderText(val);
                    if (!ClsCheck.IsNull(ht))
                    {
                        dispColsName.Add(ht);
                    }
                }

                List<DataColumn> RemoveList = new List<DataColumn>();
                foreach(DataColumn col in dt.Columns)
                {
                    if (!dispColsName.Contains(col.ToString()))
                    {
                        RemoveList.Add(col);
                    }
                }

                foreach(DataColumn remove in RemoveList)
                {
                    dt.Columns.Remove(remove);
                }
            }

            return clsExport.Excel(dt, fileName, pathID);
        }

        /// <summary>
        /// エクセルフォーマットに出力
        /// </summary>
        /// <param name="lstSheet">シート一覧</param>
        /// <param name="filepath">出力先</param>
        /// <param name="exportHeader">ヘッダを出力</param>
        public void ExportExcel(List<clsExport.SheetFormat> lstSheet, string filepath, bool exportHeader = false)
        {
            clsExport.Excel(lstSheet, filepath, exportHeader);
        }


        private void Grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.ColumnIndex < 0 && 0 <= e.RowIndex)
            {
                // セルを描画
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);

                // 行番号を描画
                TextRenderer.DrawText(
                    e.Graphics,
                    (e.RowIndex + 1).ToString(),
                    e.CellStyle.Font,
                    e.CellBounds,
                    e.CellStyle.ForeColor,
                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter);

                // 描画完了
                e.Handled = true;
            }

        }



       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool IsInputKey(Keys keyData)
        {
          
            if (keyData == Keys.F2 || keyData == Keys.F3) 
            {
                // ↓BaseForm の ControlsのみだとPanel内のコントロールを取得できなかったので、再起で調べます。
                searchFuncButton(this.Parent, keyData);

                foreach (Control a in Controls)
                {
                    // ↓ ucFunction方式
                    if (a is ucFunction)
                    {
                        return ((ucFunction)a).ProcessDialogKey(keyData);
                    }
                }
            }

            return base.IsInputKey(keyData);
        }

        /// <summary>
        /// 列定義名から列表示名を取得
        /// なければ空文字返却
        /// </summary>
        private string getHeaderText(string colName)
        {
            string ret = "";
            var gridColumn = this.Columns.Cast<DataGridViewColumn>().
                              Where(gc => gc.DataPropertyName.Equals(colName)).
                              FirstOrDefault();
            if (!(gridColumn is null))
            {
                ret = gridColumn.HeaderText.Replace("\n", "").Replace("\r\n", "");
            }

            return ret;
        }


        /// <summary>
        /// 入力されたキーに対応するファンクションを捜索します。
        /// 見つかった場合はファンクションを実行します。
        /// </summary>
        private bool searchFuncButton(Control cs, Keys keyData)
        {
            if (cs is not BaseForm) { searchFuncButton(cs.Parent, keyData); }


            searchFuncButton(cs.Controls, keyData);

            return false;
        }

        /// <summary>
        /// 入力されたキーに対応するファンクションを捜索します。
        /// 見つかった場合はファンクションを実行します。
        /// </summary>
        private bool searchFuncButton(Control.ControlCollection cs, Keys keyData)
        {
            foreach (Control c in cs)
            {
                // ↓ ucFunction方式
                if (c is ucFunction)
                {
                    return ((ucFunction)c).ProcessDialogKey(keyData);
                }
               

                if (c is Panel)
                {
                    if (searchFuncButton(c.Controls, keyData))
                    {
                        return true;
                    }
                }
            }
            return false;
        }



    }
}
