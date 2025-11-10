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
    public partial class frmTonyuShiji : MainForm
    {
        #region Constructor
        private List<TonyuShijiModel> lstTonyuShiji;
        public frmTonyuShiji()
        {
            InitializeComponent();
            Initialize("CL", "投入指示");
        }
        #endregion

        #region Events
        public override void formLoad(object sender, EventArgs e)
        {
            base.formLoad(sender, e);
            InitFunc();
            LoadData();
            LoadDGVNohinSaki();
        }
        public override void ucFunction1_F10(EventArgsFunctionButtonClick e)
        {
            base.ucFunction1_F10(e);
            Close();
        }
        #endregion

        #region Methods
        private void InitFunc()
        {
            ucFunction1.set_FunctionButtonControls(Keys.F10, btnModoru); //戻る

            ucFunction1.SetFunctionButtons(
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("戻る", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false)
                );
        }
        private void LoadData()
        {
            lstTonyuShiji = new List<TonyuShijiModel>();
            lstTonyuShiji.Add(new TonyuShijiModel("ABC-MART", "埼玉県", "27103361", "142643123011", "3", "5", "5", "0"));
            lstTonyuShiji.Add(new TonyuShijiModel("ABC-MART", "埼玉県", "27115444", "142643163563", "3", "393", "393", "0"));
            lstTonyuShiji.Add(new TonyuShijiModel("ABC-MART", "埼玉県", "27118691", "142643177751", "3", "42", "42", "0"));
            lstTonyuShiji.Add(new TonyuShijiModel("ABC-MART", "埼玉県", "27121286", "142643192090", "3", "20", "20", "0"));
            lstTonyuShiji.Add(new TonyuShijiModel("ABCNETMART", "埼玉県", "27103360", "142643123000", "3", "50", "50", "0"));
            lstTonyuShiji.Add(new TonyuShijiModel("ABCNETMART", "埼玉県", "27115381", "142643162955", "3", "310", "100", "210"));
            lstTonyuShiji.Add(new TonyuShijiModel("ABCNETMART", "埼玉県", "27118221", "142643173131", "3", "31", "31", "0"));
            lstTonyuShiji.Add(new TonyuShijiModel("小山企業株式会社", "埼玉県", "27103359", "142643122996", "3", "150", "150", "0"));
        }
        private void LoadDGVNohinSaki()
        {
            dgvTonyuShiji.RowTemplate.Height = 35;
            dgvTonyuShiji.RowHeadersVisible = false;
            dgvTonyuShiji.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTonyuShiji.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTonyuShiji.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(189, 215, 238);
            dgvTonyuShiji.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvTonyuShiji.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvTonyuShiji.ColumnHeadersDefaultCellStyle.BackColor;
            dgvTonyuShiji.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTonyuShiji.ReadOnly = true;
            dgvTonyuShiji.AllowUserToAddRows = false;
            dgvTonyuShiji.AllowUserToDeleteRows = false;
            dgvTonyuShiji.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 242, 204);
            dgvTonyuShiji.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTonyuShiji.EnableHeadersVisualStyles = false;
            dgvTonyuShiji.AllowUserToResizeRows = false;
            dgvTonyuShiji.EnableHeadersVisualStyles = false;
            dgvTonyuShiji.DefaultCellStyle.Font = new Font("MS Gothic", 18);
            dgvTonyuShiji.ColumnHeadersDefaultCellStyle.Font = new Font("MS Gothic", 18);
            dgvTonyuShiji.RowTemplate.Height = 50;
            dgvTonyuShiji.ColumnHeadersHeight = 50;
            dgvTonyuShiji.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTonyuShiji.AllowUserToResizeRows = false;


            DataTable dt = new DataTable();

            dt.Columns.Add("納品先", typeof(string));
            dt.Columns.Add("都道府県", typeof(string));
            dt.Columns.Add("Packlist", typeof(string));
            dt.Columns.Add("問い合わせ番号", typeof(string));
            dt.Columns.Add("レーン", typeof(string));
            dt.Columns.Add("個口数", typeof(string));
            dt.Columns.Add("未投入", typeof(string));
            dt.Columns.Add("投入済", typeof(string));

            foreach (var item in lstTonyuShiji)
            {
                dt.Rows.Add(item.Nohinsakimei, item.Todofuken, item.Packlist, item.Toiawasebango, item.Ren, item.Koguchisu, item.Mitonyu, item.Tonyuzumi);
            }
            dgvTonyuShiji.DataSource = dt;

            dgvTonyuShiji.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTonyuShiji.Columns[1].Width = 150;
            dgvTonyuShiji.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTonyuShiji.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTonyuShiji.Columns[2].Width = 150;
            dgvTonyuShiji.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTonyuShiji.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTonyuShiji.Columns[3].Width = 200;
            dgvTonyuShiji.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTonyuShiji.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTonyuShiji.Columns[4].Width = 100;
            dgvTonyuShiji.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTonyuShiji.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTonyuShiji.Columns[5].Width = 150;
            dgvTonyuShiji.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTonyuShiji.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTonyuShiji.Columns[6].Width = 150;
            dgvTonyuShiji.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTonyuShiji.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvTonyuShiji.Columns[7].Width = 150;
            dgvTonyuShiji.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        #endregion
    }
    #region Models
    public class TonyuShijiModel
    {
        private string nohinsakimei;
        private string todofuken;
        private string packlist;
        private string toiawasebango;
        private string ren;
        private string koguchisu;
        private string mitonyu;
        private string tonyuzumi;
        public string Nohinsakimei { get => nohinsakimei; set => nohinsakimei = value; }
        public string Todofuken { get => todofuken; set => todofuken = value; }
        public string Packlist { get => packlist; set => packlist = value; }
        public string Toiawasebango { get => toiawasebango; set => toiawasebango = value; }
        public string Ren { get => ren; set => ren = value; }
        public string Koguchisu { get => koguchisu; set => koguchisu = value; }
        public string Mitonyu { get => mitonyu; set => mitonyu = value; }
        public string Tonyuzumi { get => tonyuzumi; set => tonyuzumi = value; }

        public TonyuShijiModel() { }

        public TonyuShijiModel(string nohinsakimei, string todofuken, string packlist, string toiawasebango, string ren, string koguchisu, string mitonyu, string tonyuzumi)
        {
            this.Nohinsakimei = nohinsakimei;
            this.Todofuken = todofuken;
            this.Packlist = packlist;
            this.Toiawasebango=toiawasebango;
            this.Ren = ren;
            this.Koguchisu=koguchisu;
            this.Mitonyu=mitonyu;
            this.Tonyuzumi=tonyuzumi;
        }

        
    }
    #endregion
}
