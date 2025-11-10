using CtrlLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TKBR_Lib
{
    public partial class frmMeisaiKensaku : MainForm
    {
      
        public frmMeisaiKensaku(DateTime time)
        {
            InitializeComponent();
            Initialize("CL", "明細検索画面");
           lblDatetime.Text = time.ToString("yyyy/MM/dd HH:mm:ss");
        }
       
        private DataTable CreateDataTable1()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("No", typeof(int));
            dt.Columns.Add("Nohinsakiname", typeof(string));
            dt.Columns.Add("Prefectures", typeof(string));
            dt.Columns.Add("Jusho", typeof(string));
            dt.Columns.Add("Kosu", typeof(int));
            dt.Columns.Add("CBM", typeof(double));


            dt.Rows.Add("1", "ABC-MART", "埼玉県", "草加市吉町４－１０－４５Ｎｅｔ－ＭＡＲＴ準備倉庫", 460, 29.30);
            dt.Rows.Add("2", "ABCNETMART", "埼玉県", "草加市青柳１－５－３５草加第３Ｓ内ｎｅｔ－ＭＡＲＴ", 391, 31.83);
            dt.Rows.Add("3", "小山企業株式会社", "埼玉県", "草加市青柳１－５－３５草加第３センター", 5840, 331.12);



            return dt;
        }
        private DataTable CreateDataTable2()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("No", typeof(int));                          //No
            dt.Columns.Add("Nohinsakiname", typeof(string));            //納品先名	
            dt.Columns.Add("Packlist", typeof(string));                 //Packlist				
            dt.Columns.Add("Toiawase_bango", typeof(string));           //問い合わせ番号
            dt.Columns.Add("Chakubi", typeof(string));                  //着日
            dt.Columns.Add("Mi_furiwake_kosu", typeof(int));         //未振分個数
            dt.Columns.Add("Mi_furiwake_CBM", typeof(double));          //未振分CBM


            dt.Rows.Add("1", "ABC-MART", 27103361, 142643123011, "９／１午前指定", 5, 0.62);
            dt.Rows.Add("2", "ABC-MART", 27115444, 142643163563, "９／１午前指定", 393, 25.37);
            dt.Rows.Add("3", "ABC-MART", 27118691, 142643177751, "９／１午前指定", 42, 2.22);
            dt.Rows.Add("4", "ABC-MART", 27121286, 142643192090, "９／１午前指定", 20, 1.08);
            dt.Rows.Add("5", "ABCNETMART", 27103360, 142643123000, "９／１午前指定", 50, 4.25);
            dt.Rows.Add("6", "ABCNETMART", 27115381, 142643162955, "９／１午前指定", 310, 25.72);
            dt.Rows.Add("7", "ABCNETMART", 27118221, 142643173131, "９／１午前指定", 31, 1.86);
            dt.Rows.Add("8", "小山企業株式会社", 27103359, 142643122996, "９／１午前指定", 5840, 331.12);

            return dt;
        }


        private DataTable dtSource;
        private void btnModoru_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMeisaiKensaku_Load(object sender, EventArgs e)
        {
            dtSource = CreateDataTable1();
            dataGridView1.DataSource = dtSource;

            dataGridView1.Font = new System.Drawing.Font("MS Gothic", 14);

            dataGridView1.AlternatingRowsDefaultCellStyle = null;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 35;
            }
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Columns[0].HeaderText = "No。";
            dataGridView1.Columns[1].HeaderText = "納品先名";
            dataGridView1.Columns[2].HeaderText = "都道府県";
            dataGridView1.Columns[3].HeaderText = "住所";
            dataGridView1.Columns[4].HeaderText = "個数";
            dataGridView1.Columns[5].HeaderText = "CBM";

            dataGridView1.Columns[0].Width = 72; // No。
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[1].Width = 452; // 納品先名
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[2].Width = 150; // 都道府県
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[4].Width = 100; // 個数
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[4].DefaultCellStyle.Format = "N0";



            dataGridView1.Columns[5].Width = 100; // CBM
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;


            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // 住所

            ////////////////////////////////////////////////////////////
            //CreateDataTable_2
            dtSource = CreateDataTable2();
            dataGridView2.DataSource = dtSource;

            dataGridView2.Font = new System.Drawing.Font("MS Gothic", 14);

            dataGridView2.AlternatingRowsDefaultCellStyle = null;
            dataGridView2.RowHeadersVisible = false;

            foreach (DataGridViewColumn col in dataGridView2.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Height = 35;
            }
            dataGridView2.RowTemplate.Height = 35;
            dataGridView2.Columns[0].HeaderText = "No。";
            dataGridView2.Columns[1].HeaderText = "納品先名";
            dataGridView2.Columns[2].HeaderText = "Packlist";
            dataGridView2.Columns[3].HeaderText = "問い合わせ番号";
            dataGridView2.Columns[4].HeaderText = "着日";
            dataGridView2.Columns[5].HeaderText = "未振分個数";
            dataGridView2.Columns[6].HeaderText = "未振分CBM";
           
            dataGridView1.AllowUserToAddRows = false;


            dataGridView2.Columns[0].Width = 75;   // No
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView2.Columns[1].Width = 452;  // 納品先名
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView2.Columns[2].Width = 150;  // Packlist
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView2.Columns[3].Width = 200;  // 問い合わせ番号
            dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView2.Columns[4].Width = 281;  // 着日
            dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView2.Columns[5].Width = 140;  // 未振分個数
            dataGridView2.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView2.Columns[5].DefaultCellStyle.Format = "N0";


            dataGridView2.Columns[6].Width = 140;  // 未振分CBM
            dataGridView2.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;



            //dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView2.AllowUserToAddRows = false;

            dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView2.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Kosu_gokei();
            CBM_gokei();
        }
        private void Kosu_gokei()
        {
            int Kosu_gokei = 0;

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                Kosu_gokei = Kosu_gokei + Convert.ToInt32(dataGridView2.Rows[i].Cells[5].Value);
            }
            lblKosu_gokei2.Text = Kosu_gokei.ToString("N0");

        }
        private void CBM_gokei()
        {
            double CBM_gokei = 0;

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                double CBM = 0;
                double.TryParse(dataGridView2.Rows[i].Cells[6].Value?.ToString(), out CBM);

                CBM_gokei = CBM_gokei + CBM;
                lblCBM_gokei.Text = CBM_gokei.ToString("0.##");
            }

        }

        private void btnSubeteSentaku_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                dataGridView2.Rows[i].Selected = true; 
            }
        }

        private void btnSubeteKaijo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                dataGridView2.Rows[i].Selected = false;
            }
        }
    }
}
