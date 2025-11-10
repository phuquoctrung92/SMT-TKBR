using CtrlLib;
using CtrlLib.Input;
using SmtLib.DataBaseObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TKBR_Lib.Forms
{
    public partial class frmMenu : MainForm
    {
        public enum Column
        {
            colNo,
            colBatch,
            colHasso_dt,
            colStatus,
            file_onde,
            file_ippn,
            bat_shori_dt,
            bat_no
            
        }

        public frmMenu()
        {
            InitializeComponent();
            Initialize("CL", "メインメニュー");
        }

        public override void formLoad(object sender, EventArgs e)
        {
            base.formLoad(sender, e);
            // 画面の初期化
            InitFunc();

            InitDataGridView();
            SetData();

        }

        private void InitFunc()
        {
          
            ucFunction1.set_FunctionButtonControls(Keys.F1, baseButton1);
            ucFunction1.set_FunctionButtonControls(Keys.F2, baseButton2);
            ucFunction1.set_FunctionButtonControls(Keys.F3, baseButton3);
            ucFunction1.set_FunctionButtonControls(Keys.F4, baseButton4);
            ucFunction1.set_FunctionButtonControls(Keys.F5, baseButton5);
            ucFunction1.set_FunctionButtonControls(Keys.F6, baseButton6);
            ucFunction1.set_FunctionButtonControls(Keys.F7, baseButton7);

            ucFunction1.set_FunctionButtonControls(Keys.F10, baseButton10);

            this.ucFunction1.SetFunctionButtons(
                new FunctionButtons( "データ取込" , _CrLf: false),
                new FunctionButtons( "データ送信・PDF出力", _CrLf: false),
                new FunctionButtons( "出荷一覧", _CrLf: false),
                new FunctionButtons( "締め処理", _CrLf: false),
                new FunctionButtons( "内訳票出力", _CrLf:false),
                new FunctionButtons( "入荷予定登録", _CrLf: false),
                new FunctionButtons( "返還登録", _CrLf: false),
                new FunctionButtons( string.Empty, _CrLf:false),
                new FunctionButtons( string.Empty, _CrLf:false),
                new FunctionButtons( "終了", _CrLf:false),
                new FunctionButtons( "選択", _CrLf:false),
                new FunctionButtons( "選択", _CrLf:false)
               
            );

            clearScreen();
        }


        private void InitDataGridView()
        {
            dgvList.Columns.Clear();

            dgvList.MultiSelect = false;
            dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvList.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dgvList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvList.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Blue;
            dgvList.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
             
            DataGridViewCellStyle dgcs_right = new DataGridViewCellStyle();
            dgcs_right.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgcs_right.NullValue = null;

            //右寄せ数値
            DataGridViewCellStyle dgcs_cen = new DataGridViewCellStyle();
            dgcs_cen.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgcs_cen.NullValue = null;

            DataGridViewTextBoxColumn Col;

            //No.
            Col = new DataGridViewTextBoxColumn() { DataPropertyName = Column.colNo.ToString(), HeaderText = "No.", SortMode = DataGridViewColumnSortMode.NotSortable, ReadOnly = true, Width = 80, DefaultCellStyle = dgcs_cen };
            Col.Name = Col.DataPropertyName;
            dgvList.Columns.Add(Col);

            //出荷No
            Col = new DataGridViewTextBoxColumn() { DataPropertyName = Column.colBatch.ToString(), HeaderText = "バッチ", SortMode = DataGridViewColumnSortMode.NotSortable, ReadOnly = true, Width = 200, DefaultCellStyle = dgcs_cen };
            Col.Name = Col.DataPropertyName;
            dgvList.Columns.Add(Col);

            
            //得意先
            Col = new DataGridViewTextBoxColumn() { DataPropertyName = Column.colHasso_dt.ToString(), HeaderText = "発送日", SortMode = DataGridViewColumnSortMode.NotSortable, ReadOnly = true, Width = 150, DefaultCellStyle = dgcs_cen };
            Col.Name = Col.DataPropertyName;
            dgvList.Columns.Add(Col);

             
            //得意先
            Col = new DataGridViewTextBoxColumn() { DataPropertyName = Column.colStatus.ToString(), HeaderText = "ステータス", SortMode = DataGridViewColumnSortMode.NotSortable, ReadOnly = true, Width = 250 };
            Col.Name = Col.DataPropertyName;
            dgvList.Columns.Add(Col);

            //得意先
            Col = new DataGridViewTextBoxColumn() { DataPropertyName = Column.file_onde.ToString(), HeaderText = "オンデマンド", SortMode = DataGridViewColumnSortMode.NotSortable, ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            Col.Name = Col.DataPropertyName;
            dgvList.Columns.Add(Col);

            //得意先
            Col = new DataGridViewTextBoxColumn() { DataPropertyName = Column.file_ippn.ToString(), HeaderText = "一般送付", SortMode = DataGridViewColumnSortMode.NotSortable, ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            Col.Name = Col.DataPropertyName;
            dgvList.Columns.Add(Col);

            //得意先
            Col = new DataGridViewTextBoxColumn() { DataPropertyName = Column.bat_shori_dt.ToString(), HeaderText = "処理日", SortMode = DataGridViewColumnSortMode.NotSortable, ReadOnly = true, Visible = false };
            Col.Name = Col.DataPropertyName;
            dgvList.Columns.Add(Col);

            //得意先
            Col = new DataGridViewTextBoxColumn() { DataPropertyName = Column.bat_no.ToString(), HeaderText = "バッチNo", SortMode = DataGridViewColumnSortMode.NotSortable, ReadOnly = true, Visible = false };
            Col.Name = Col.DataPropertyName;
            dgvList.Columns.Add(Col);


         
        }


        public override void ucFunction1_F1(EventArgsFunctionButtonClick e)
        {

        }

        public override void ucFunction1_F2(EventArgsFunctionButtonClick e)
        {
            base.ucFunction1_F2(e);
            // データ送信・PDF出力 ボタンの処理
            try
            {

            }
            catch (Exception ex)
            {
                ClsMsgBox.ShowMessage(this.Text, "E999", ex);
            }
            finally
            {
                this.Show();
            }
        }

        public override void ucFunction1_F3(EventArgsFunctionButtonClick e)
        {
            base.ucFunction1_F3(e);
            // 出荷一覧ボタンの処理
            try
            {
            }
            catch (Exception ex)
            {
                ClsMsgBox.ShowMessage(this.Text, "E999", ex);
            }
            finally
            {
                this.Show();
            }
        }

        public override void ucFunction1_F4(EventArgsFunctionButtonClick e)
        {
            base.ucFunction1_F4(e);
            // 締め処理ボタンの処理
            try
            {
        
            }
            catch (Exception ex)
            {
                ClsMsgBox.ShowMessage(this.Text, "E999", ex);
            }
            finally
            {
                this.Show();
            }
        }
        public override void ucFunction1_F5(EventArgsFunctionButtonClick e)
        {
            base.ucFunction1_F5(e);
            // シーケンス表出力ボタンの処理
            try
            {

            }
            catch (Exception ex)
            {
                ClsMsgBox.ShowMessage(this.Text, "E999", ex);
            }
            finally
            {
                this.Show();
            }
        }
        public override void ucFunction1_F6(EventArgsFunctionButtonClick e)
        {
        }

        public override void ucFunction1_F7(EventArgsFunctionButtonClick e)
        {

        }


        public override void ucFunction1_F10(EventArgsFunctionButtonClick e)
        {
            base.ucFunction1_F10(e);
            // 閉じるボタンの処理
            if (ClsMsgBox.ShowMessage("終了", "Q999", "終了しますか？") == DialogResult.Yes)
            {
                Close();
            }
        }

        private void loadScreen(Form form)
        {
            try
            {
                this.Hide();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                ClsMsgBox.ShowMessage(this.Text, "E999", ex);
            }
            finally
            {
                this.Show();
                SetData();
            }
        }

        private void SetData(){
        
            InitDataGridView();
           
            //データ取得
            
        }

    }
}
