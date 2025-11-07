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
using TKBR_Lib.Forms.明細検索;

namespace TKBR_Lib.Forms.仕分登録
{
    public partial class frmShiwakeToroku : MainForm
    {
        #region Constructor
        private List<NohinsakiModel> lstNohinsaki;
        private List<MeisaiModel> lstMeisai;
        public frmShiwakeToroku()
        {
            InitializeComponent();
            Initialize("CL", "仕分登録画面");
        }
        #endregion

        #region Events
        public override void formLoad(object sender, EventArgs e)
        {
            base.formLoad(sender, e);

            LoadLaneCombobox();

            LoadData();

            LoadDGVNohinSaki();

            LoadDGVMeisai();
        }
        private void btnModoru_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMeisaiKensaku_Click(object sender, EventArgs e)
        {
            var frm = new frmMeisaiKensaku();
            frm.ShowDialog();
        }
        private void dgvMeisai_DataSourceChanged(object sender, EventArgs e)
        {
            lblKosuGokei.Text = dgvMeisai.Rows.Cast<DataGridViewRow>().Sum(r => double.TryParse(r.Cells["仕分個数"].Value?.ToString(), out double v) ? v : 0).ToString("N0");
            lblCBMGokei.Text = dgvMeisai.Rows.Cast<DataGridViewRow>().Sum(r => double.TryParse(r.Cells["仕分CBM"].Value?.ToString(), out double v) ? v : 0).ToString("N2");
        }
        private void dgvMeisai_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var rowEdit = dgvMeisai.Rows[e.RowIndex];
            rowEdit.Cells[7].Value = (double.Parse(rowEdit.Cells[5].Value.ToString()) / double.Parse(rowEdit.Cells[4].Value.ToString()) * double.Parse(rowEdit.Cells[6].Value.ToString())).ToString("N2");
            lblKosuGokei.Text = dgvMeisai.Rows.Cast<DataGridViewRow>().Sum(r => double.TryParse(r.Cells["仕分個数"].Value?.ToString(), out double v) ? v : 0).ToString("N0");
            lblCBMGokei.Text = dgvMeisai.Rows.Cast<DataGridViewRow>().Sum(r => double.TryParse(r.Cells["仕分CBM"].Value?.ToString(), out double v) ? v : 0).ToString("N2");
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
        #endregion

        #region Methods
        private void LoadLaneCombobox()
        {
            cbbRen.Clear();
            cbbRen.AddItem("", "");
            cbbRen.AddItem("    1", "1");
            cbbRen.AddItem("    2", "2");
            cbbRen.AddItem("    3", "3");
            cbbRen.AddItem("    4", "4");
            cbbRen.AddItem("    5", "5");
        }
        private void LoadData()
        {
            lstNohinsaki = new List<NohinsakiModel>();
            lstNohinsaki.Add(new NohinsakiModel("ABC-MART", "埼玉県", "草加市吉町４－１０－４５Ｎｅｔ－ＭＡＲＴ準備倉庫", "460", "29.30"));
            lstNohinsaki.Add(new NohinsakiModel("ABCNETMART／小山企業株式会社", "埼玉県", "草加市青柳１－５－３５草加第３センター", "6231", "362.85"));

            lstMeisai = new List<MeisaiModel>();
            lstMeisai.Add(new MeisaiModel("ABC-MART", "27103361", "142643123011", "5", "0.62", "5", "0.62"));
            lstMeisai.Add(new MeisaiModel("ABC-MART", "27115444", "142643163563", "393", "25.37", "393", "25.37"));
            lstMeisai.Add(new MeisaiModel("ABC-MART", "27118691", "142643177751", "42", "2.22", "42", "2.22"));
            lstMeisai.Add(new MeisaiModel("ABC-MART", "27121286", "142643192090", "20", "1.08", "20", "1.08"));
            lstMeisai.Add(new MeisaiModel("ABCNETMART", "27103360", "142643123000", "50", "4.25", "50", "4.25"));
            lstMeisai.Add(new MeisaiModel("ABCNETMART", "27115381", "142643162955", "310", "25.72", "310", "25.72"));
            lstMeisai.Add(new MeisaiModel("ABCNETMART", "27118221", "142643173131", "31", "1.86", "31", "1.86"));
            lstMeisai.Add(new MeisaiModel("小山企業株式会社", "27103359", "142643122996", "5,840", "331.12", "150", "8.50"));
        }
        private void LoadDGVNohinSaki()
        {
            dgvNohinsaki.RowHeadersVisible = false;
            dgvNohinsaki.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNohinsaki.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNohinsaki.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNohinsaki.ReadOnly = true;
            dgvNohinsaki.AllowUserToAddRows = false;
            dgvNohinsaki.AllowUserToDeleteRows = false;
            dgvNohinsaki.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 242, 204);
            dgvNohinsaki.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvNohinsaki.DefaultCellStyle.Font = new Font("MS Gothic", 14);
            dgvNohinsaki.ColumnHeadersDefaultCellStyle.Font = new Font("MS Gothic", 14);
            dgvNohinsaki.RowTemplate.Height = 35;

            DataTable dt = new DataTable();

            dt.Columns.Add("No.", typeof(string));
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

            dgvNohinsaki.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvNohinsaki.Columns[0].Width = 60;
            dgvNohinsaki.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvNohinsaki.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvNohinsaki.Columns[1].Width = 350;

            dgvNohinsaki.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvNohinsaki.Columns[2].Width = 150;
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
            dgvMeisai.RowHeadersVisible = false;
            dgvMeisai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMeisai.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMeisai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMeisai.AllowUserToAddRows = false;
            dgvMeisai.AllowUserToDeleteRows = false;
            dgvMeisai.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 242, 204);
            dgvMeisai.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvMeisai.DefaultCellStyle.Font = new Font("MS Gothic", 14);
            dgvMeisai.ColumnHeadersDefaultCellStyle.Font = new Font("MS Gothic", 14);
            dgvMeisai.RowTemplate.Height = 35;

            DataTable dt = new DataTable();

            dt.Columns.Add("No.", typeof(string));
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

            dgvMeisai.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[0].Width = 60;
            dgvMeisai.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvMeisai.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[2].Width = 150;
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
        #endregion
    }
    #region Models
    public class MeisaiModel
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

        public MeisaiModel() { }

        public MeisaiModel(string nohinsakimei, string packlist, string toiawasebango, string mifuriwakekosu, string mifuriwakecbm, string shiwakekosu, string shiwakecbm)
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
    public class NohinsakiModel
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

        public NohinsakiModel() { }

        public NohinsakiModel(string nohinsakimei, string todofuken, string jusho, string kosu, string cbm)
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
