using CtrlLib;
using CtrlLib.MyControls;
using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class frmNohinSakiSearch : MainForm
    {
        private BindingSource bs = new BindingSource();

        public frmNohinSakiSearch()
        {
            InitializeComponent();
            Initialize("CL", "納品先検索画面");

        }
        //public class Test
        //{
        //    public string No { get; set; }
        //    public int Nohinsakicode { get; set; }
        //    public string Nohinsakiname { get; set; }
        //    public string Prefectures { get; set; }
        //    public string Address { get; set; }
        //}

        //public class TestList
        //{
        //    public List<Test> Data { get; set; }

        //    public TestList()
        //    {
        //        Data = new List<Test> {
        //        new Test { No="1", Nohinsakicode=5093835, Nohinsakiname="アルペン", Prefectures="愛知県", Address="春日井市明知町１１８９－１９プロロジスパーク春日井３Ｆ" },
        //        new Test { No="2", Nohinsakicode=5098865, Nohinsakiname="ABC-MART", Prefectures="愛知県", Address="小牧市新小木２－３５－３８ターミナル東福玉精穀倉庫" },
        //        new Test { No="3", Nohinsakicode=5097846, Nohinsakiname="ゼビオ", Prefectures="茨城県", Address="稲敷郡阿見町よしわら２－１６－１ＤＰＬつくば阿見３Ｂ棟" },
        //        new Test { No="4", Nohinsakicode=8006186, Nohinsakiname="ＵＮＩＴＥ越谷", Prefectures="埼玉県", Address="越谷市レイクタウン４－１－１ＬＴアウトレット４２１９" },
        //        new Test { No="5", Nohinsakicode=8006199, Nohinsakiname="ＵＮＩＴＥ深谷", Prefectures="埼玉県", Address="深谷市花園１ふかや花園Ｐアウトレット２１０" },
        //        new Test { No="6", Nohinsakicode=5092898, Nohinsakiname="ＦＬアトモスジャパンＬＬＣ", Prefectures="埼玉県", Address="川越市今福９９０－１０" },
        //        new Test { No="7", Nohinsakicode=5066146, Nohinsakiname="ABC-MART", Prefectures="埼玉県", Address="草加市吉町４－１０－４５Ｎｅｔ－ＭＡＲＴ準備倉庫" },
        //        new Test { No="8", Nohinsakicode=5032654, Nohinsakiname="ABCNETMART／小山企業株式会社", Prefectures="埼玉県", Address="草加市青柳１－５－３５草加第３Ｓ内ｎｅｔ－ＭＡＲＴ" },
        //        new Test { No="9", Nohinsakicode=8006115, Nohinsakiname="ＵＮＩＴＥ入間", Prefectures="埼玉県", Address="入間市宮寺３１６９－１三井アウトレットパーク入間" },
        //        new Test { No="10", Nohinsakicode=8006008, Nohinsakiname="ＵＮＩＴＥ横浜", Prefectures="神奈川県", Address="横浜市金沢区白帆５－２Ａ－３Ｆ１２１６０" },
        //        new Test { No="11", Nohinsakicode=8006011, Nohinsakiname="ＵＮＩＴＥ平塚", Prefectures="神奈川県", Address="平塚市大神８－１－１－２５１１区画" },
        //        new Test { No="12", Nohinsakicode=8006002, Nohinsakiname="ＵＮＩＴＥ御殿場", Prefectures="静岡県", Address="御殿場市深沢１３１２０" },
        //        new Test { No="13", Nohinsakicode=5085433, Nohinsakiname="アルペン", Prefectures="千葉県", Address="印西市鹿黒南１－３ＧＢＰサウス４ＦＡＢ区画" },
        //        new Test { No="14", Nohinsakicode=8006183, Nohinsakiname="ＮＦＳ酒々井", Prefectures="千葉県", Address="印旛郡酒々井町飯積２－４－１酒々井アウトレット２２００" },
        //        new Test { No="15", Nohinsakicode=8006004, Nohinsakiname="ＮＦＳ幕張", Prefectures="千葉県", Address="千葉市美浜区ひび野２－５０" },
        //        //new Test { No="16", Nohinsakicode=8006183, Nohinsakiname="ＮＦＳ酒々井", Prefectures="千葉県", Address="印旛郡酒々井町飯積２－４－１酒々井アウトレット２２００" },
        //        //new Test { No="17", Nohinsakicode=8006004, Nohinsakiname="ＮＦＳ幕張", Prefectures="千葉県", Address="千葉市美浜区ひび野２－５０" },
        //        //new Test { No="18", Nohinsakicode=8006004, Nohinsakiname="ＮＦＳ幕張", Prefectures="千葉県", Address="千葉市美浜区ひび野２－５０" },
        //        //new Test { No="19", Nohinsakicode=8006183, Nohinsakiname="ＮＦＳ酒々井", Prefectures="千葉県", Address="印旛郡酒々井町飯積２－４－１酒々井アウトレット２２００" },
        //        //new Test { No="20", Nohinsakicode=8006004, Nohinsakiname="ＮＦＳ幕張", Prefectures="千葉県", Address="千葉市美浜区ひび野２－５０" },

        //    };
        //    }
        //}
        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("No", typeof(int));
            dt.Columns.Add("Nohinsakicode", typeof(int));
            dt.Columns.Add("Nohinsakiname", typeof(string));
            dt.Columns.Add("Prefectures", typeof(string));
            dt.Columns.Add("Address", typeof(string));


            dt.Rows.Add("1", 5093835, "アルペン", "愛知県", "春日井市明知町１１８９－１９プロロジスパーク春日井３Ｆ");
            dt.Rows.Add("2", 5098865, "ABC-MART", "愛知県", "小牧市新小木２－３５－３８ターミナル東福玉精穀倉庫");
            dt.Rows.Add("3", 5097846, "ゼビオ", "茨城県", "稲敷郡阿見町よしわら２－１６－１ＤＰＬつくば阿見３Ｂ棟");
            dt.Rows.Add("4", 8006186, "ＵＮＩＴＥ越谷", "埼玉県", "越谷市レイクタウン４－１－１ＬＴアウトレット４２１９");
            dt.Rows.Add("5", 8006199, "ＵＮＩＴＥ深谷", "埼玉県", "深谷市花園１ふかや花園Ｐアウトレット２１０");
            dt.Rows.Add("6", 5092898, "ＦＬアトモスジャパンＬＬＣ", "埼玉県", "川越市今福９９０－１0");
            dt.Rows.Add("7", 5066146, "ABC-MART", "埼玉県", "草加市吉町４－１０－４５Ｎｅｔ－ＭＡＲＴ準備倉庫");
            dt.Rows.Add("8", 5032654, "ABCNETMART／小山企業株式会社", "埼玉県", "草加市青柳１－５－３５草加第３Ｓ内ｎｅｔ－ＭＡＲＴ");
            dt.Rows.Add("9", 8006115, "ＵＮＩＴＥ入間", "埼玉県", "入間市宮寺３１６９－１三井アウトレットパーク入間");
            dt.Rows.Add("10", 8006008, "ＵＮＩＴＥ横浜", "神奈川県", "横浜市金沢区白帆５－２Ａ－３Ｆ１２１６０");
            dt.Rows.Add("11", 8006011, "ＵＮＩＴＥ平塚", "神奈川県", "平塚市大神８－１－１－２５１１区画");
            dt.Rows.Add("12", 8006002, "ＵＮＩＴＥ御殿場", "静岡県", "御殿場市深沢１３１２0");
            dt.Rows.Add("13", 5085433, "アルペン", "千葉県", "印西市鹿黒南１－３ＧＢＰサウス４ＦＡＢ区画");
            dt.Rows.Add("14", 8006183, "ＮＦＳ酒々井", "千葉県", "印旛郡酒々井町飯積２－４－１酒々井アウトレット２２００");
            dt.Rows.Add("15", 8006004, "ＮＦＳ幕張", "千葉県", "千葉市美浜区ひび野２－５0");

            return dt;
        }
        private DataTable dtSource;
        private void frmNohinSakiSearch_Load(object sender, EventArgs e)
        {
            //TestList testlist = new TestList();
            //dataGridView1.DataSource = testlist.Data;

            dtSource = CreateDataTable();
            dataGridView1.DataSource = dtSource;

            dataGridView1.Font = new System.Drawing.Font("MS Gothic", 14);

            dataGridView1.AlternatingRowsDefaultCellStyle = null;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns[0].HeaderText = "No。";
            dataGridView1.Columns[1].HeaderText = "納品先コード";
            dataGridView1.Columns[2].HeaderText = "納品先名";
            dataGridView1.Columns[3].HeaderText = "都道府県";
            dataGridView1.Columns[4].HeaderText = "住所";

            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridView1.RowTemplate.Height = 35;

            //dataGridView1.AllowUserToAddRows = false;
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 35;
            }

            dataGridView1.Columns[0].Width = 75;
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 320;
            dataGridView1.Columns[3].Width = 150;

            //DataGridViewColumn column = dataGridView1.Columns[4];
            //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            List<string> prefectures = new List<string>();
            foreach (DataRow row in dtSource.Rows)
            {
                string pref = row["Prefectures"].ToString();
                if (!prefectures.Contains(pref))
                {
                    prefectures.Add(pref);
                }
            }
            ucComboBox1.AddItem("", "");
            foreach (string pref in prefectures)
            {
                ucComboBox1.AddItem(pref, pref);
            }
            //foreach (var item in testlist.Data)
            //{
            //    string pref = item.Prefectures;
            //    if (!prefectures.Contains(pref))
            //    {
            //        prefectures.Add(pref);
            //    }
            //}
            //ucComboBox1.AddItem("", "");
            //foreach (string pref in prefectures)
            //{
            //    ucComboBox1.AddItem(pref, pref);
            //}

        }
       
        private void ucComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedPref = ucComboBox1.SelectedValue?.ToString() ?? "";

            if (string.IsNullOrEmpty(selectedPref))
            {
                dataGridView1.DataSource = dtSource;
            }
            else
            {
                DataView dv = new DataView(dtSource);
                dv.RowFilter = $"Prefectures = '{selectedPref}'";
                dataGridView1.DataSource = dv;
            }
            //TestList testlist = new TestList();
            //string selectedPref = "";
            //if (ucComboBox1.SelectedValue != null)
            //{
            //    selectedPref = ucComboBox1.SelectedValue.ToString();
            //}
            //if (selectedPref == "")
            //{
            //    dataGridView1.DataSource = testlist.Data;
            //    return;
            //}
            //List<Test> filteredList = new List<Test>();
            //for (int i = 0; i < testlist.Data.Count; i++)
            //{
            //    if (testlist.Data[i].Prefectures == selectedPref)
            //    {
            //        filteredList.Add(testlist.Data[i]);
            //    }
            //}

        }

        private void btnKensaku_Click(object sender, EventArgs e)
        {
            //TestList testlist = new TestList();
            //List<Test> filteredList = new List<Test>();
            //string searchName = txtNohinsakimei.Text.Trim();
            //string selectedPref = ucComboBox1.SelectedValue != null ? ucComboBox1.SelectedValue.ToString() : "";
            //for (int i = 0; i < testlist.Data.Count; i++)
            //{
            //    Test t = testlist.Data[i];
            //    if (!string.IsNullOrEmpty(selectedPref) && t.Prefectures != selectedPref)
            //    {
            //        continue; 
            //    }
            //    if (!string.IsNullOrEmpty(searchName) && !t.Nohinsakiname.Contains(searchName))
            //    {
            //        continue; 
            //    }
            //    filteredList.Add(t);
            //}
            //dataGridView1.DataSource = filteredList;
            List<DataRow> filteredList = new List<DataRow>();
            string searchName = txtNohinsakimei.Text.Trim();
            string selectedPref = ucComboBox1.SelectedValue?.ToString() ?? "";

           
            foreach (DataRow row in dtSource.Rows)
            {
              
                if (!string.IsNullOrEmpty(selectedPref) && row["Prefectures"].ToString() != selectedPref)
                    continue;

               
                if (!string.IsNullOrEmpty(searchName) && !row["Nohinsakiname"].ToString().Contains(searchName))
                    continue;

                filteredList.Add(row);
            }

         
            DataTable dtFiltered = filteredList.CopyToDataTable();
            dataGridView1.DataSource = dtFiltered;
        }


        private void btnModoru_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSentaku_Click(object sender, EventArgs e)
        {

        }

    }
}
