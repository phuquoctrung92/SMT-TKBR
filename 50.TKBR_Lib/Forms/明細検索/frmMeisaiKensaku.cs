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
    public partial class frmMeisaiKensaku : MainForm
    {
        #region Constructor
        private List<NohinsakiModel> lstNohinsaki;
        private List<MeisaiModel> lstMeisai;
        public frmMeisaiKensaku()
        {
            InitializeComponent();
            Initialize("CL", "明細検索画面");
        }
        #endregion

        #region Events
        public override void formLoad(object sender, EventArgs e)
        {
            base.formLoad(sender, e);

            loadData();

            LoadDGVNohinSaki();
        }
        private void btnModoru_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNohinsakiSelectAll_Click(object sender, EventArgs e)
        {
            dgvNohinsaki.SelectAll();
        }
        private void btnMeisaiSelectAll_Click(object sender, EventArgs e)
        {
            dgvMeisai.SelectAll();
        }
        private void btnMeisaiKaijoAll_Click(object sender, EventArgs e)
        {
            dgvMeisai.ClearSelection();
        }
        private void dgvNohinsaki_SelectionChanged(object sender, EventArgs e)
        {
            List<string> lstNohinsakimei = new List<string>();
            if (dgvNohinsaki.SelectedRows.Count > 0)
            {                
                foreach (DataGridViewRow row in dgvNohinsaki.SelectedRows) {
                    lstNohinsakimei.Add(row.Cells["納品先名"].Value?.ToString());
                }
            }
            LoadDGVMeisai(lstNohinsakimei);
        }
        private void dgvMeisai_SelectionChanged(object sender, EventArgs e)
        {
            lblMeisaisu.Text = dgvMeisai.SelectedRows.Count > 0 ? dgvMeisai.SelectedRows.Count.ToString() : "0";
            lblKosuGokei.Text = dgvMeisai.SelectedRows.Count > 0 ? dgvMeisai.SelectedRows.Cast<DataGridViewRow>().Sum(r => double.TryParse(r.Cells["未振分個数"].Value?.ToString(), out double v) ? v : 0).ToString("N0") : "0";
            lblCBMGokei.Text = dgvMeisai.SelectedRows.Count > 0 ? dgvMeisai.SelectedRows.Cast<DataGridViewRow>().Sum(r => double.TryParse(r.Cells["未振分CBM"].Value?.ToString(), out double v) ? v : 0).ToString("N2") : "0";
        }
        #endregion

        #region Methods
        private void loadData()
        {
            lstNohinsaki = new List<NohinsakiModel>();
            lstNohinsaki.Add(new NohinsakiModel("ABC-MART", "埼玉県", "草加市吉町４－１０－４５Ｎｅｔ－ＭＡＲＴ準備倉庫", "460", "29.30"));
            lstNohinsaki.Add(new NohinsakiModel("ABCNETMART", "埼玉県", "草加市青柳１－５－３５草加第３Ｓ内ｎｅｔ－ＭＡＲＴ ", "391", "31.83"));
            lstNohinsaki.Add(new NohinsakiModel("小山企業株式会社", "埼玉県", "草加市青柳１－５－３５草加第３センター", "5,840", "331.12"));
            
            lstMeisai = new List<MeisaiModel>();
            lstMeisai.Add(new MeisaiModel("ABC-MART", "27103361", "142643123011", "９／１午前指定", "5", "0.62"));
            lstMeisai.Add(new MeisaiModel("ABC-MART", "27115444", "142643163563", "９／１午前指定", "393", "25.37"));
            lstMeisai.Add(new MeisaiModel("ABC-MART", "27118691", "142643177751", "９／１午前指定", "42", "2.22"));
            lstMeisai.Add(new MeisaiModel("ABC-MART", "27121286", "142643192090", "９／１午前指定", "20", "1.08"));
            lstMeisai.Add(new MeisaiModel("ABCNETMART", "27103360", "142643123000", "９／１午前指定", "50", "4.25"));
            lstMeisai.Add(new MeisaiModel("ABCNETMART", "27115381", "142643162955", "９／１午前指定", "310", "25.72"));
            lstMeisai.Add(new MeisaiModel("ABCNETMART", "27118221", "142643173131", "９／１午前指定", "31", "1.86"));
            lstMeisai.Add(new MeisaiModel("小山企業株式会社", "27103359", "142643122996", "９／１午前指定", "5,840", "331.12"));
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
            dgvNohinsaki.Columns[1].Width = 300;

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
        private void LoadDGVMeisai(List<string> lstNohinsakimei)
        {
            dgvMeisai.RowHeadersVisible = false;
            dgvMeisai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMeisai.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMeisai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMeisai.ReadOnly = true;
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
            dt.Columns.Add("着日", typeof(string));
            dt.Columns.Add("未振分個数", typeof(string));
            dt.Columns.Add("未振分CBM", typeof(string));

            int index = 1;
            foreach (var item in lstMeisai)
            {
                if (lstNohinsakimei.Contains(item.Nohinsakimei))
                {
                    dt.Rows.Add(index, item.Nohinsakimei, item.Packlist, item.Toiawasebango, item.Chyakubi, item.Mifuriwakekosu, item.Mifuriwakecbm);
                    index++;
                }
            }
            dgvMeisai.DataSource = dt;

            dgvMeisai.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[0].Width = 60;
            dgvMeisai.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvMeisai.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[2].Width = 150;
            dgvMeisai.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvMeisai.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[3].Width = 200;

            dgvMeisai.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[4].Width = 200;

            dgvMeisai.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[5].Width = 150;
            dgvMeisai.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMeisai.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvMeisai.Columns[6].Width = 150;
            dgvMeisai.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        #endregion
    }
    #region Models
    public class MeisaiModel
    {
        private string nohinsakimei;
        private string packlist;
        private string toiawasebango;
        private string chyakubi;
        private string mifuriwakekosu;
        private string mifuriwakecbm;

        public string Nohinsakimei { get => nohinsakimei; set => nohinsakimei = value; }
        public string Packlist { get => packlist; set => packlist = value; }
        public string Toiawasebango { get => toiawasebango; set => toiawasebango = value; }
        public string Chyakubi { get => chyakubi; set => chyakubi = value; }
        public string Mifuriwakekosu { get => mifuriwakekosu; set => mifuriwakekosu = value; }
        public string Mifuriwakecbm { get => mifuriwakecbm; set => mifuriwakecbm = value; }

        public MeisaiModel() { }

        public MeisaiModel(string nohinsakimei, string packlist, string toiawasebango, string chyakubi, string mifuriwakekosu, string mifuriwakecbm)
        {
            this.Nohinsakimei = nohinsakimei;
            this.Packlist = packlist;
            this.Toiawasebango = toiawasebango;
            this.Chyakubi = chyakubi;
            this.Mifuriwakekosu = mifuriwakekosu;
            this.Mifuriwakecbm = mifuriwakecbm;
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
