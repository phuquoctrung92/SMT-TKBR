using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CtrlLib;
using CtrlLib.MyControls;

namespace TKBR_Lib.Forms
{
    public partial class frmShiwakeToroku : MainForm
    {
        #region Constructor
        private List<TorokuNohinsakiModel> lstNohinsaki;
        private List<TorokuMeisaiModel> lstMeisai;
        private int dgvNohinsakiWidth;
        private int dgvMeisaiWidth;
        public frmShiwakeToroku()
        {
            InitializeComponent();
            Initialize("CL", "仕分登録");
        }
        #endregion

        #region Events
        public override void formLoad(object sender, EventArgs e)
        {
            base.formLoad(sender, e);
            InitFunc();
            dgvMeisaiWidth = dgvMeisai.Size.Width;
            dgvNohinsakiWidth = dgvNohinsaki.Size.Width;

            LoadLaneCombobox();

            LoadData();

            LoadDGVNohinSaki();

            LoadDGVMeisai();
        }
        private void InitFunc()
        {
            ucFunction1.set_FunctionButtonControls(Keys.F1, btnToroku); //登録
            ucFunction1.set_FunctionButtonControls(Keys.F4, btnNohinsakiKensaku); //納品先検索
            ucFunction1.set_FunctionButtonControls(Keys.F5, btnMeisaiKensaku); //明細検索

            ucFunction1.set_FunctionButtonControls(Keys.F10, btnModoru); //戻る

            ucFunction1.SetFunctionButtons(
                new FunctionButtons("登録", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("納品先検索", _CrLf: false),
                new FunctionButtons("明細検索", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("戻る", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false)
                );
        }

        public override void ucFunction1_F4(EventArgsFunctionButtonClick e)
        {
            try
            {
                base.ucFunction1_F4(e);
                var frm = new frmNohinSakiSearch();
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
        public override void ucFunction1_F5(EventArgsFunctionButtonClick e)
        {
            try
            {
                base.ucFunction1_F5(e);
                var frm = new frmMeisaiKensaku();
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

        public override void ucFunction1_F10(EventArgsFunctionButtonClick e)
        {
            base.ucFunction1_F10(e);
            Close();
        }

        private void dgvMeisai_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var rowEdit = dgvMeisai.Rows[e.RowIndex];
            var mifuriwake_kosu = double.Parse(rowEdit.Cells["未振分個数"].Value.ToString());
            //空欄チェック
            var editValue = double.TryParse(rowEdit.Cells["仕分個数"].Value?.ToString(), out double v) ? v : 0;
            //適切チェック（未振分個数を従う）
            editValue = editValue > mifuriwake_kosu ? mifuriwake_kosu : editValue;
            //仕分個数と仕分CBMの値をアップデート
            rowEdit.Cells["仕分個数"].Value = editValue.ToString();
            rowEdit.Cells["仕分CBM"].Value = (double.Parse(rowEdit.Cells["未振分CBM"].Value.ToString()) / mifuriwake_kosu * editValue).ToString("N2");
            lblKosuGokei.Text = dgvMeisai.Rows.Cast<DataGridViewRow>().Sum(r => double.TryParse(r.Cells["仕分個数"].Value?.ToString(), out double v1) ? v1 : 0).ToString("N0");
            lblCBMGokei.Text = dgvMeisai.Rows.Cast<DataGridViewRow>().Sum(r => double.TryParse(r.Cells["仕分CBM"].Value?.ToString(), out double v2) ? v2 : 0).ToString("N2");
        }
        private void dgvMeisai_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvMeisai.CurrentCell.ColumnIndex == 6)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= Txt_KeyPress_NumberOnly;
                    txt.KeyPress += Txt_KeyPress_NumberOnly;
                }
            }
        }
        private void Txt_KeyPress_NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dgvNohinsaki_DataSourceChanged(object sender, EventArgs e)
        {
            dgvNohinsaki.Size = new Size(dgvNohinsaki.DisplayedRowCount(false) < dgvNohinsaki.RowCount ? dgvNohinsakiWidth + 17 : dgvNohinsakiWidth, dgvNohinsaki.Size.Height);
        }
        private void dgvMeisai_DataSourceChanged(object sender, EventArgs e)
        {
            dgvMeisai.Size = new Size(dgvMeisai.DisplayedRowCount(false) < dgvMeisai.RowCount ? dgvMeisaiWidth + 17 : dgvMeisaiWidth, dgvMeisai.Size.Height);
            lblKosuGokei.Text = dgvMeisai.Rows.Cast<DataGridViewRow>().Sum(r => double.TryParse(r.Cells["仕分個数"].Value?.ToString(), out double v) ? v : 0).ToString("N0");
            lblCBMGokei.Text = dgvMeisai.Rows.Cast<DataGridViewRow>().Sum(r => double.TryParse(r.Cells["仕分CBM"].Value?.ToString(), out double v) ? v : 0).ToString("N2");
        }
        #endregion

        #region Methods
        private void LoadLaneCombobox()
        {
            cbbRen.Clear();
            cbbRen.AddItem("", "");
            cbbRen.AddItem("  1", "1");
            cbbRen.AddItem("  2", "2");
            cbbRen.AddItem("  3", "3");
            cbbRen.AddItem("  4", "4");
            cbbRen.AddItem("  5", "5");
            cbbRen.SelectedValue = "3";
        }
        private void LoadData()
        {
            lstNohinsaki = new List<TorokuNohinsakiModel>();
            lstNohinsaki.Add(new TorokuNohinsakiModel("ABC-MART", "埼玉県", "草加市吉町４－１０－４５Ｎｅｔ－ＭＡＲＴ準備倉庫", "460", "29.30"));
            lstNohinsaki.Add(new TorokuNohinsakiModel("ABCNETMART／小山企業株式会社", "埼玉県", "草加市青柳１－５－３５草加第３センター", "6231", "362.85"));
            lstNohinsaki.Add(new TorokuNohinsakiModel("ABC-MART", "埼玉県", "草加市吉町４－１０－４５Ｎｅｔ－ＭＡＲＴ準備倉庫", "460", "29.30"));
            lstNohinsaki.Add(new TorokuNohinsakiModel("ABCNETMART／小山企業株式会社", "埼玉県", "草加市青柳１－５－３５草加第３センター", "6231", "362.85"));
            lstNohinsaki.Add(new TorokuNohinsakiModel("ABC-MART", "埼玉県", "草加市吉町４－１０－４５Ｎｅｔ－ＭＡＲＴ準備倉庫", "460", "29.30"));
            lstNohinsaki.Add(new TorokuNohinsakiModel("ABCNETMART／小山企業株式会社", "埼玉県", "草加市青柳１－５－３５草加第３センター", "6231", "362.85"));

            lstMeisai = new List<TorokuMeisaiModel>();
            lstMeisai.Add(new TorokuMeisaiModel("ABC-MART", "27103361", "142643123011", "5", "0.62", "5", "0.62"));
            lstMeisai.Add(new TorokuMeisaiModel("ABC-MART", "27115444", "142643163563", "393", "25.37", "393", "25.37"));
            lstMeisai.Add(new TorokuMeisaiModel("ABC-MART", "27118691", "142643177751", "42", "2.22", "42", "2.22"));
            lstMeisai.Add(new TorokuMeisaiModel("ABC-MART", "27121286", "142643192090", "20", "1.08", "20", "1.08"));
            lstMeisai.Add(new TorokuMeisaiModel("ABCNETMART", "27103360", "142643123000", "50", "4.25", "50", "4.25"));
            lstMeisai.Add(new TorokuMeisaiModel("ABCNETMART", "27115381", "142643162955", "310", "25.72", "310", "25.72"));
            lstMeisai.Add(new TorokuMeisaiModel("ABCNETMART", "27118221", "142643173131", "31", "1.86", "31", "1.86"));
            lstMeisai.Add(new TorokuMeisaiModel("小山企業株式会社", "27103359", "142643122996", "5,840", "331.12", "150", "8.50"));
        }
        private void LoadDGVNohinSaki()
        {
            DatagridviewUICustom(dgvNohinsaki);
            DataTable dt = new DataTable();
            dt.Columns.Add("No.", typeof(int));
            dt.Columns.Add("納品先名", typeof(string));
            dt.Columns.Add("都道府県", typeof(string));
            dt.Columns.Add("住所", typeof(string));
            dt.Columns.Add("個数", typeof(string));
            dt.Columns.Add("CBM", typeof(string));

            int index = 1;
            foreach (var item in lstNohinsaki)
            {
                dt.Rows.Add(index, item.Nohinsakimei, item.Todofuken, item.Jusho, item.Kosu, item.Cbm);
                index++;
            }
            dgvNohinsaki.DataSource = dt;

            dgvNohinsaki.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNohinsaki.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvNohinsaki.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvNohinsaki.Columns[1].Width = 370;

            dgvNohinsaki.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvNohinsaki.Columns[2].Width = 130;
            dgvNohinsaki.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvNohinsaki.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvNohinsaki.Columns[4].Width = 150;
            dgvNohinsaki.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvNohinsaki.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvNohinsaki.Columns[5].Width = 150;
            dgvNohinsaki.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void LoadDGVMeisai()
        {
            DatagridviewUICustom(dgvMeisai);
            DataTable dt = new DataTable();
            dt.Columns.Add("No.", typeof(int));
            dt.Columns.Add("納品先名", typeof(string));
            dt.Columns.Add("Packlist", typeof(string));
            dt.Columns.Add("問い合わせ番号", typeof(string));
            dt.Columns.Add("未振分個数", typeof(string));
            dt.Columns.Add("未振分CBM", typeof(string));
            dt.Columns.Add("仕分個数", typeof(string));
            dt.Columns.Add("仕分CBM", typeof(string));

            int index = 1;
            foreach (var item in lstMeisai)
            {
                double shiwakeCBM =  double.Parse(item.Mifuriwakecbm) / double.Parse(item.Mifuriwakekosu) * double.Parse(item.Shiwakekosu);
                dt.Rows.Add(index, item.Nohinsakimei, item.Packlist, item.Toiawasebango, item.Mifuriwakekosu, item.Mifuriwakecbm, item.Shiwakekosu, shiwakeCBM.ToString("N2"));
                index++;
            }
            dgvMeisai.DataSource = dt;

            foreach (DataGridViewColumn col in dgvMeisai.Columns)
            {
                col.ReadOnly = true;
            }
            dgvMeisai.Columns[6].ReadOnly = false;
            dgvMeisai.Columns[6].DefaultCellStyle.BackColor = Color.FromArgb(255, 242, 204);

            dgvMeisai.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMeisai.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvMeisai.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[2].Width = 160;
            dgvMeisai.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvMeisai.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[3].Width = 200;

            dgvMeisai.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[4].Width = 150;
            dgvMeisai.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMeisai.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[5].Width = 150;
            dgvMeisai.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMeisai.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[6].Width = 150;
            dgvMeisai.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;            

            dgvMeisai.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[7].Width = 150;
            dgvMeisai.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void DatagridviewUICustom(CtrlLib.MyControls.DataGridView datagridview)
        {
            datagridview.RowHeadersVisible = false;
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagridview.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridview.AllowUserToAddRows = false;
            datagridview.AllowUserToDeleteRows = false;
            datagridview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 242, 204);
            datagridview.DefaultCellStyle.SelectionForeColor = Color.Black;
            datagridview.DefaultCellStyle.Font = new Font("MS Gothic", 18);
            datagridview.ColumnHeadersDefaultCellStyle.Font = new Font("MS Gothic", 18);
            datagridview.RowTemplate.Height = 50;
            datagridview.ColumnHeadersHeight = 50;
            datagridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            datagridview.AllowUserToResizeRows = false;
        }
        #endregion
    }
    #region Models
    public class TorokuMeisaiModel
    {
        private string nohinsakimei;
        private string packlist;
        private string toiawasebango;
        private string mifuriwakekosu;
        private string mifuriwakecbm;
        private string shiwakekosu;
        private string shiwakecbm;

        public string Nohinsakimei { get => nohinsakimei; set => nohinsakimei = value; }
        public string Packlist { get => packlist; set => packlist = value; }
        public string Toiawasebango { get => toiawasebango; set => toiawasebango = value; }
        public string Mifuriwakekosu { get => mifuriwakekosu; set => mifuriwakekosu = value; }
        public string Mifuriwakecbm { get => mifuriwakecbm; set => mifuriwakecbm = value; }
        public string Shiwakekosu { get => shiwakekosu; set => shiwakekosu = value; }
        public string Shiwakecbm { get => shiwakecbm; set => shiwakecbm = value; }

        public TorokuMeisaiModel() { }

        public TorokuMeisaiModel(string nohinsakimei, string packlist, string toiawasebango, string mifuriwakekosu, string mifuriwakecbm, string shiwakekosu, string shiwakecbm)
        {
            this.Nohinsakimei = nohinsakimei;
            this.Packlist = packlist;
            this.Toiawasebango = toiawasebango;
            this.Mifuriwakekosu = mifuriwakekosu;
            this.Mifuriwakecbm = mifuriwakecbm;
            this.Shiwakekosu = shiwakekosu;
            this.Shiwakecbm = shiwakecbm;
        }
    }
    public class TorokuNohinsakiModel
    {
        private string nohinsakimei;
        private string todofuken;
        private string jusho;
        private string kosu;
        private string cbm;

        public string Nohinsakimei { get => nohinsakimei; set => nohinsakimei = value; }
        public string Todofuken { get => todofuken; set => todofuken = value; }
        public string Jusho { get => jusho; set => jusho = value; }
        public string Kosu { get => kosu; set => kosu = value; }
        public string Cbm { get => cbm; set => cbm = value; }

        public TorokuNohinsakiModel() { }

        public TorokuNohinsakiModel(string nohinsakimei, string todofuken, string jusho, string kosu, string cbm)
        {
            this.nohinsakimei = nohinsakimei;
            this.todofuken = todofuken;
            this.jusho = jusho;
            this.kosu = kosu;
            this.cbm = cbm;
        }
    }
    #endregion
}
