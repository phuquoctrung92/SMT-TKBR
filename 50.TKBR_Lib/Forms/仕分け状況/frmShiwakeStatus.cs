using CtrlLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TKBR_Lib.Forms
{
    public partial class frmShiwakeStatus : MainForm
    {
        public frmShiwakeStatus()
        {
            InitializeComponent();
            Initialize("CL", "仕分け状況照会");
        }

        private void frmShiwakeStatus_Load(object sender, EventArgs e)
        {
            lblProgess.Text = "10,100 / 14,100";
            lblProgess_Percent.Text = "71.6%";
            dgvList.AutoGenerateColumns = false;
            setData();
        }

        private void lblBorder_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ((Label)sender).DisplayRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void setData()
        {
            try
            {
                dgvList.Rows.Clear();
                var dt = new DataTable();
                foreach (DataGridViewColumn item in dgvList.Columns)
                {
                    dt.Columns.Add(item.DataPropertyName);
                }
                dt.Rows.Add("1", "ゼビオ株式会社(大阪府)\n日本通運株式会社(大阪府)", "717／1026 (69.8%)", "299", "積込中");
                dt.Rows.Add("2", "", "", "", "");
                dt.Rows.Add("3", "ABC-MART(埼玉県)\nABCNETMART(埼玉県)", "0／1001 (0%)", "1,001", "積込待");
                dt.Rows.Add("4", "", "1025／1025 (100%)", "0", "積込済");
                dt.Rows.Add("5", "アルペン(千葉県)", "171／1235 (13.8%)", "1,015", "積込中");
                dt.Rows.Add("6", "ＵＮＩＴＥ御殿場(静岡県)", "1135／1140 (99.5%)", "0", "積込中");
                dt.Rows.Add("7", "", "", "", "");
                dt.Rows.Add("8", "", "", "", "");
                dt.Rows.Add("9", "", "", "", "");

                dgvList.DataSource = dt;
            }
            catch (Exception ex)
            {
                ClsMsgBox.ShowMessage(this.Text, "E999", ex);
            }
        }

        private void dgvList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (dgvList.Rows.Count == 0)
                    return;

                foreach (DataGridViewRow row in dgvList.Rows)
                {
                    switch (row.Cells[4].Value.ToString())
                    {
                        case "積込中":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(226, 239, 218);
                            row.Cells[5].Value = "停止";
                            break;
                        case "積込待":
                            row.DefaultCellStyle.BackColor = Color.FromArgb(252, 228, 214);
                            row.Cells[5].Value = "停止";
                            break;
                        case "積込済":
                            row.DefaultCellStyle.BackColor = Color.Transparent;
                            row.Cells[5].Value = "終了";
                            break;
                        default:
                            row.Cells[5].Style.Padding = new Padding(150, 0, 0 ,0);
                            break;
                    }
                }
                dgvList.ClearSelection();
            }
            catch (Exception ex)
            {
                ClsMsgBox.ShowMessage(this.Text, "E999", ex);
            }
        }

        private void baseButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmTonyuShiji();
                this.Hide();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                ClsMsgBox.ShowMessage(Text, "E999", ex);
            }
            finally
            {
                this.Show();
            }
        }
    }
}
