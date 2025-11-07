using CtrlLib;
using CtrlLib.Input;
using CtrlLib.MyControls;
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
    public partial class frmMainMenu : MainForm
    {
        public enum Column
        {
            colShukka_dt,
            colTorikomi_num,
            colNohinSaki_upd_num,
            colNike_Shukka_Data,
            colNike_Carton,
            colOther_Shukka_Data,
            colTotal_Shukka_Data,
            colTotal_Carton,
            colProgress
        }

        public frmMainMenu()
        {
            InitializeComponent();
            Initialize("CL", "メインメニュー");
        }

        public override void formLoad(object sender, EventArgs e)
        {
            base.formLoad(sender, e);
            // 画面の初期化
            InitFunc();

            //InitDataGridView();
            SetData();

        }

        private void InitFunc()
        {
            clearScreen();
            dgvList.AutoGenerateColumns = false;
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
                //SetData();
            }
        }

        private void SetData()
        {

            //InitDataGridView();
            dtpSekisai.Value = DateTime.Parse("2025/11/10");
            //データ取得
            dgvList.Rows.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add(Column.colShukka_dt.ToString());
            dt.Columns.Add(Column.colTorikomi_num.ToString());
            dt.Columns.Add(Column.colNohinSaki_upd_num.ToString());
            dt.Columns.Add(Column.colNike_Shukka_Data.ToString());
            dt.Columns.Add(Column.colNike_Carton.ToString());
            dt.Columns.Add(Column.colOther_Shukka_Data.ToString());
            dt.Columns.Add(Column.colTotal_Shukka_Data.ToString());
            dt.Columns.Add(Column.colTotal_Carton.ToString());
            dt.Columns.Add(Column.colProgress.ToString());

            dt.Rows.Add("2025/11/10（月）", "8", "0", "420", "3,140", "1,240", "1,660", "3,140", "100%");
            dt.Rows.Add("2025/11/11（火）", "7", "2", "1,460", "42,000", "1,200", "2,660", "42,000", "85.0%");
            dt.Rows.Add("2025/11/12（水）", "6", "0", "310", "1,420", "840", "1,150", "1,420", "-");
            dt.Rows.Add("2025/11/13（木）", "5", "0", "100", "710", "140", "240", "710", "-");
            dt.Rows.Add("2025/11/14（金）", "5", "1", "24", "410", "42", "66", "410", "-");
            dt.Rows.Add("2025/11/15（土）", "1", "0", "4", "40", "0", "4", "40", "-");
            dt.Rows.Add("2025/11/16（日）", "0", "0", "0", "0", "0", "0", "0", "-");
            dt.Rows.Add("2025/11/17　以降", "1", "0", "2", "120", "0", "2", "120", "-");

            dt.Rows.Add("合計", "33", "3", "2,320", "47,840", "3,462", "5,782", "47,840", "-");

            dgvList.DataSource = dt;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            // 閉じるボタンの処理
            if (ClsMsgBox.ShowMessage("終了", "Q999", "終了しますか？") == DialogResult.Yes)
            {
                Close();
            }
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((System.Windows.Forms.Label)sender).DisplayRectangle, Color.Black, 0, ButtonBorderStyle.None, Color.Black, 0, ButtonBorderStyle.None, Color.Black, 0, ButtonBorderStyle.None, Color.Black, 1, ButtonBorderStyle.Solid);
        }

        private void dgvList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvList.Rows[0].DefaultCellStyle.BackColor = Color.LightGray;

                dgvList.Rows[2].DefaultCellStyle.BackColor = Color.FromArgb(248, 203, 173);

                // 合計行のスタイル設定
                int lastRowIndex = dgvList.Rows.GetLastRow(DataGridViewElementStates.Visible);
                dgvList.Rows[lastRowIndex].Cells[0].Style.BackColor = Color.FromArgb(189, 215, 238);
                dgvList.ClearSelection();

            }
            catch (Exception ex)
            {
                ClsMsgBox.ShowMessage(this.Text, "E999", ex);
            }
        }

        private void btnMenu_Button_Click(object sender, EventArgs e)
        {
            Form form = null;
            if (sender.Equals(btnShowProgress))
            {
                form = new frmShiwakeStatus();
            }
            else if (sender.Equals(btnLaneSetting))
            {
                form = new frmShiwakeToroku();
            }
            if (form != null)
            {
                loadScreen(form);
            }
        }
    }
}
