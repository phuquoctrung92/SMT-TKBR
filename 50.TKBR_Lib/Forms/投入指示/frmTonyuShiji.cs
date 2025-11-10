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
using System.Windows.Forms;

namespace TKBR_Lib.Forms
{
    public partial class frmTonyuShiji : MainForm
    {
        public frmTonyuShiji()
        {
            InitializeComponent();
            Initialize("CL", "投入指示画面");

        }
        private DataTable CreateDataTable1()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Nohinsakiname", typeof(string));
            dt.Columns.Add("Prefectures", typeof(string));
            dt.Columns.Add("Packlist", typeof(string));
            dt.Columns.Add("Toiawase_bango", typeof(string));
            dt.Columns.Add("reshi", typeof(int));
            dt.Columns.Add("Kokuchisu", typeof(int));
            dt.Columns.Add("Mitounyu", typeof(int));
            dt.Columns.Add("Tonyusumi", typeof(int));

            dt.Rows.Add("ABC-MART", "埼玉県", "27103361", "142643123011", 3, 5, 5, 0);
            dt.Rows.Add("ABC-MART", "埼玉県", "27115444", "142643163563", 3, 393, 393, 0);
            dt.Rows.Add("ABC-MART", "埼玉県", "27118691", "142643177751", 3, 42, 42, 0);
            dt.Rows.Add("ABC-MART", "埼玉県", "27121286", "142643192090", 3, 20, 20, 0);
            dt.Rows.Add("ABCNETMART", "埼玉県", "27103360", "142643123000", 3, 50, 50, 0);
            dt.Rows.Add("ABCNETMART", "埼玉県", "27115381", "142643162955", 3, 310, 100, 210);
            dt.Rows.Add("ABCNETMART", "埼玉県", "27118221", "142643173131", 3, 31, 31, 0);
            dt.Rows.Add("小山企業株式会社", "埼玉県", "27103359", "142643122996", 3, 150, 150, 0);




            return dt;
        }
        private DataTable dtSource;
        private void frmTonyuShiji_Load(object sender, EventArgs e)
        {
            dtSource = CreateDataTable1();
            dataGridView1.DataSource = dtSource;

            dataGridView1.Font = new System.Drawing.Font("MS Gothic", 14);

            dataGridView1.AlternatingRowsDefaultCellStyle = null;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 50; // chiều cao tùy chỉnh
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("MS Gothic", 18);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(189, 215, 238); 
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
            
            dataGridView1.Columns[0].HeaderText = "納品先";
            dataGridView1.Columns[1].HeaderText = "都道府県";
            dataGridView1.Columns[2].HeaderText = "Packlist";
            dataGridView1.Columns[3].HeaderText = "問い合わせ番号";
            dataGridView1.Columns[4].HeaderText = "レーン";
            dataGridView1.Columns[5].HeaderText = "個口数";
            dataGridView1.Columns[6].HeaderText = "未投入";
            dataGridView1.Columns[7].HeaderText = "投入済";

            //dataGridView1.Columns[0].Width = 400; // No。
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // 住所

            dataGridView1.Columns[1].Width = 150; // No。
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dataGridView1.Columns[2].Width = 200; // No。
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[3].Width = 250; // No。
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dataGridView1.Columns[4].Width = 110; // No。
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dataGridView1.Columns[5].Width = 110; // No。
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dataGridView1.Columns[6].Width = 110; // No。
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            dataGridView1.Columns[7].Width = 110; // No。
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }

        private void btnModoru_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
