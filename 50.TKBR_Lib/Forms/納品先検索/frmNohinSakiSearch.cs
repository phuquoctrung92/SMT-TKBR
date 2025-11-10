using CtrlLib;
using CtrlLib.MyControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace TKBR_Lib.Forms
{
    public partial class frmNohinSakiSearch : MainForm
    {
        #region Constructor
        private List<NohinsakiKensakuModel> lstNohinsakiKensaku;
        public frmNohinSakiSearch()
        {
            InitializeComponent();
            Initialize("CL", "納品先検索");

        }
        #endregion

        #region Events
        public override void formLoad(object sender, EventArgs e)
        {
            base.formLoad(sender, e);
            InitFunc();
            LoadData();

            LoadTodofuken();

            LoadDGVNohinSaki(lstNohinsakiKensaku);
        }

        public override void ucFunction1_F5(EventArgsFunctionButtonClick e)
        {
            base.ucFunction1_F5(e);
            var lstKensaku = lstNohinsakiKensaku.Where(x =>
                (string.IsNullOrEmpty(txtNohinsakimei.Text) || x.Nohinsakimei.Contains(txtNohinsakimei.Text))
             && (string.IsNullOrEmpty(cbbTodofuken.SelectedValue) || x.Todofuken == cbbTodofuken.SelectedValue)).ToList();

            LoadDGVNohinSaki(lstKensaku);
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
            ucFunction1.set_FunctionButtonControls(Keys.F1, btnSentaku); //選択
            ucFunction1.set_FunctionButtonControls(Keys.F5, btnKensaku); //検索
            ucFunction1.set_FunctionButtonControls(Keys.F10, btnModoru); //戻る

            ucFunction1.SetFunctionButtons(
                new FunctionButtons("選択", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("", _CrLf: false),
                new FunctionButtons("検索", _CrLf: false),
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
            lstNohinsakiKensaku = new List<NohinsakiKensakuModel>();
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("5093835", "アルペン", "愛知県", "春日井市明知町１１８９－１９プロロジスパーク春日井３Ｆ"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("5098865", "ABC - MART", "愛知県", "小牧市新小木２－３５－３８ターミナル東福玉精穀倉庫"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("5097846", "ゼビオ", "茨城県", "稲敷郡阿見町よしわら２－１６－１ＤＰＬつくば阿見３Ｂ棟"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("8006186", "ＵＮＩＴＥ越谷", "埼玉県", "越谷市レイクタウン４－１－１ＬＴアウトレット４２１９"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("8006199", "ＵＮＩＴＥ深谷", "埼玉県", "深谷市花園１ふかや花園Ｐアウトレット２１０"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("5092898", "ＦＬアトモスジャパンＬＬＣ", "埼玉県", "川越市今福９９０－１0"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("5066146", "ABC - MART", "埼玉県", "草加市吉町４－１０－４５Ｎｅｔ－ＭＡＲＴ準備倉庫"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("5032654", "ABCNETMART／小山企業株式会社", "埼玉県", "草加市青柳１－５－３５草加第３Ｓ内ｎｅｔ－ＭＡＲＴ"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("8006115", "ＵＮＩＴＥ入間", "埼玉県", "入間市宮寺３１６９－１三井アウトレットパーク入間"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("8006008", "ＵＮＩＴＥ横浜", "神奈川県", "横浜市金沢区白帆５－２Ａ－３Ｆ１２１６０"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("8006011", "ＵＮＩＴＥ平塚", "神奈川県", "平塚市大神８－１－１－２５１１区画"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("8006002", "ＵＮＩＴＥ御殿場", "静岡県", "御殿場市深沢１３１２0"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("5085433", "アルペン", "千葉県", "印西市鹿黒南１－３ＧＢＰサウス４ＦＡＢ区画"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("8006183", "ＮＦＳ酒々井", "千葉県", "印旛郡酒々井町飯積２－４－１酒々井アウトレット２２００"));
            lstNohinsakiKensaku.Add(new NohinsakiKensakuModel("8006004", "ＮＦＳ幕張", "千葉県", "千葉市美浜区ひび野２－５0"));
        }
        private void LoadTodofuken()
        {
            cbbTodofuken.Clear();
            var grbTodofuken = lstNohinsakiKensaku.Select(x => x.Todofuken).Distinct().ToList();
            if (grbTodofuken != null)
            {
                cbbTodofuken.AddItem("", "");
                foreach (var item in grbTodofuken)
                {
                    cbbTodofuken.AddItem(item, item);
                }
            }
        }
        private void LoadDGVNohinSaki(List<NohinsakiKensakuModel> lstNohinsakiKensaku)
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
            dgvNohinsaki.DefaultCellStyle.Font = new Font("MS Gothic", 18);
            dgvNohinsaki.ColumnHeadersDefaultCellStyle.Font = new Font("MS Gothic", 18);
            dgvNohinsaki.RowTemplate.Height = 50;
            dgvNohinsaki.ColumnHeadersHeight = 50;
            dgvNohinsaki.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNohinsaki.AllowUserToResizeRows = false;

            DataTable dt = new DataTable();

            dt.Columns.Add("No.", typeof(int));
            dt.Columns.Add("納品先コード", typeof(string));
            dt.Columns.Add("納品先名", typeof(string));
            dt.Columns.Add("都道府県", typeof(string));
            dt.Columns.Add("住所", typeof(string));

            int index = 1;
            foreach (var item in lstNohinsakiKensaku)
            {
                dt.Rows.Add(index, item.Nohinsakicode, item.Nohinsakimei, item.Todofuken, item.Jusho);
                index++;
            }
            dgvNohinsaki.DataSource = dt;

            dgvNohinsaki.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNohinsaki.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvNohinsaki.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvNohinsaki.Columns[1].Width = 160;

            dgvNohinsaki.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvNohinsaki.Columns[2].Width = 360;

            dgvNohinsaki.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvNohinsaki.Columns[3].Width = 150;
            dgvNohinsaki.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion
    }
    #region Models
    public class NohinsakiKensakuModel
    {
        private string nohinsakicode;
        private string nohinsakimei;
        private string todofuken;
        private string jusho;

        public string Nohinsakimei { get => nohinsakimei; set => nohinsakimei = value; }
        public string Todofuken { get => todofuken; set => todofuken = value; }
        public string Jusho { get => jusho; set => jusho = value; }
        public string Nohinsakicode { get => nohinsakicode; set => nohinsakicode = value; }

        public NohinsakiKensakuModel() { }

        public NohinsakiKensakuModel(string nohinsakicode, string nohinsakimei, string todofuken, string jusho)
        {
            this.Nohinsakicode = nohinsakicode;
            this.Nohinsakimei = nohinsakimei;
            this.Todofuken = todofuken;
            this.Jusho = jusho;
        }
    }
    #endregion
}
