namespace TKBR_Lib.Forms
{
    partial class frmMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnImportShukka = new CtrlLib.MyControls.BaseButton();
            this.btnLaneSetting = new CtrlLib.MyControls.BaseButton();
            this.btnShowProgress = new CtrlLib.MyControls.BaseButton();
            this.btnCancelProgress = new CtrlLib.MyControls.BaseButton();
            this.btnQuit = new CtrlLib.MyControls.BaseButton();
            this.btnMstNohinSaki = new CtrlLib.MyControls.BaseButton();
            this.btnCompleteProgress = new CtrlLib.MyControls.BaseButton();
            this.btnMstSettings = new CtrlLib.MyControls.BaseButton();
            this.label1 = new CtrlLib.MyControls.Label();
            this.dtpSekisai = new CtrlLib.ucDateTimePicker();
            this.baseButton8 = new CtrlLib.MyControls.BaseButton();
            this.btnSearch = new CtrlLib.MyControls.BaseButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new CtrlLib.MyControls.Label();
            this.label4 = new CtrlLib.MyControls.Label();
            this.label2 = new CtrlLib.MyControls.Label();
            this.dgvList = new CtrlLib.MyControls.DataGridView();
            this.colShukka_dt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTorikomi_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNohinSaki_upd_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNIKE_Shukka_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNIKE_Carton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOther_Shukka_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal_Shukka_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal_Carton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customPanel1 = new CtrlLib.MyControls.CustomPanel();
            this.pnHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // ucFunction1
            // 
            this.ucFunction1.Location = new System.Drawing.Point(0, 900);
            this.ucFunction1.Size = new System.Drawing.Size(1534, 0);
            this.ucFunction1.TabIndex = 99;
            this.ucFunction1.TabStop = false;
            // 
            // btnImportShukka
            // 
            this.btnImportShukka.Caption = null;
            this.btnImportShukka.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnImportShukka.Location = new System.Drawing.Point(1252, 133);
            this.btnImportShukka.Name = "btnImportShukka";
            this.btnImportShukka.Size = new System.Drawing.Size(260, 60);
            this.btnImportShukka.TabIndex = 81;
            this.btnImportShukka.Text = "出荷データ取込";
            this.btnImportShukka.UseVisualStyleBackColor = true;
            // 
            // btnLaneSetting
            // 
            this.btnLaneSetting.Caption = null;
            this.btnLaneSetting.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnLaneSetting.Location = new System.Drawing.Point(1252, 217);
            this.btnLaneSetting.Name = "btnLaneSetting";
            this.btnLaneSetting.Size = new System.Drawing.Size(260, 60);
            this.btnLaneSetting.TabIndex = 82;
            this.btnLaneSetting.Text = "レーン設定";
            this.btnLaneSetting.UseVisualStyleBackColor = true;
            // 
            // btnShowProgress
            // 
            this.btnShowProgress.Caption = null;
            this.btnShowProgress.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnShowProgress.Location = new System.Drawing.Point(1252, 301);
            this.btnShowProgress.Name = "btnShowProgress";
            this.btnShowProgress.Size = new System.Drawing.Size(260, 60);
            this.btnShowProgress.TabIndex = 83;
            this.btnShowProgress.Text = "状況照会";
            this.btnShowProgress.UseVisualStyleBackColor = true;
            // 
            // btnCancelProgress
            // 
            this.btnCancelProgress.Caption = null;
            this.btnCancelProgress.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnCancelProgress.Location = new System.Drawing.Point(1252, 385);
            this.btnCancelProgress.Name = "btnCancelProgress";
            this.btnCancelProgress.Size = new System.Drawing.Size(260, 60);
            this.btnCancelProgress.TabIndex = 84;
            this.btnCancelProgress.Text = "消込処理";
            this.btnCancelProgress.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Caption = null;
            this.btnQuit.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnQuit.Location = new System.Drawing.Point(1252, 830);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(260, 60);
            this.btnQuit.TabIndex = 100;
            this.btnQuit.Text = "システム終了";
            this.btnQuit.UseVisualStyleBackColor = true;
            // 
            // btnMstNohinSaki
            // 
            this.btnMstNohinSaki.Caption = null;
            this.btnMstNohinSaki.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnMstNohinSaki.Location = new System.Drawing.Point(10, 830);
            this.btnMstNohinSaki.Name = "btnMstNohinSaki";
            this.btnMstNohinSaki.Size = new System.Drawing.Size(260, 60);
            this.btnMstNohinSaki.TabIndex = 91;
            this.btnMstNohinSaki.Text = "納品先マスタ";
            this.btnMstNohinSaki.UseVisualStyleBackColor = true;
            // 
            // btnCompleteProgress
            // 
            this.btnCompleteProgress.Caption = null;
            this.btnCompleteProgress.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnCompleteProgress.Location = new System.Drawing.Point(1252, 469);
            this.btnCompleteProgress.Name = "btnCompleteProgress";
            this.btnCompleteProgress.Size = new System.Drawing.Size(260, 60);
            this.btnCompleteProgress.TabIndex = 85;
            this.btnCompleteProgress.Text = "完了処理";
            this.btnCompleteProgress.UseVisualStyleBackColor = true;
            // 
            // btnMstSettings
            // 
            this.btnMstSettings.Caption = null;
            this.btnMstSettings.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnMstSettings.Location = new System.Drawing.Point(301, 830);
            this.btnMstSettings.Name = "btnMstSettings";
            this.btnMstSettings.Size = new System.Drawing.Size(260, 60);
            this.btnMstSettings.TabIndex = 92;
            this.btnMstSettings.Text = "設定マスタ";
            this.btnMstSettings.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 118;
            this.label1.Text = "積載日";
            // 
            // dtpSekisai
            // 
            this.dtpSekisai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dtpSekisai.Caption = "積載日";
            this.dtpSekisai.Font = new System.Drawing.Font("MS Gothic", 22F);
            this.dtpSekisai.Location = new System.Drawing.Point(100, 67);
            this.dtpSekisai.Name = "dtpSekisai";
            this.dtpSekisai.Size = new System.Drawing.Size(219, 37);
            this.dtpSekisai.TabIndex = 1;
            this.dtpSekisai.Value = null;
            // 
            // baseButton8
            // 
            this.baseButton8.Caption = null;
            this.baseButton8.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.baseButton8.Location = new System.Drawing.Point(1141, -658);
            this.baseButton8.Name = "baseButton8";
            this.baseButton8.Size = new System.Drawing.Size(299, 49);
            this.baseButton8.TabIndex = 108;
            this.baseButton8.Text = "baseButton1";
            this.baseButton8.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Caption = null;
            this.btnSearch.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnSearch.Location = new System.Drawing.Point(335, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 50);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "表示";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvList);
            this.panel1.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.panel1.Location = new System.Drawing.Point(0, 133);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 5);
            this.panel1.Size = new System.Drawing.Size(1243, 656);
            this.panel1.TabIndex = 107;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(215)))), ((int)(((byte)(238)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("MS Gothic", 20F);
            this.label3.Location = new System.Drawing.Point(723, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 52);
            this.label3.TabIndex = 1;
            this.label3.Text = "その他";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Paint += new System.Windows.Forms.PaintEventHandler(this.label2_Paint);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(215)))), ((int)(((byte)(238)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("MS Gothic", 20F);
            this.label4.Location = new System.Drawing.Point(863, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 52);
            this.label4.TabIndex = 1;
            this.label4.Text = "合計";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Paint += new System.Windows.Forms.PaintEventHandler(this.label2_Paint);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(215)))), ((int)(((byte)(238)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("MS Gothic", 20F);
            this.label2.Location = new System.Drawing.Point(443, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 52);
            this.label2.TabIndex = 1;
            this.label2.Text = "NIKE様";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Paint += new System.Windows.Forms.PaintEventHandler(this.label2_Paint);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(215)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle28.Font = new System.Drawing.Font("MS Gothic", 18F);
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(215)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvList.ColumnHeadersHeight = 100;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colShukka_dt,
            this.colTorikomi_num,
            this.colNohinSaki_upd_num,
            this.colNIKE_Shukka_Data,
            this.colNIKE_Carton,
            this.colOther_Shukka_Data,
            this.colTotal_Shukka_Data,
            this.colTotal_Carton,
            this.colProgress});
            this.dgvList.DataGridColumns = null;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("MS Gothic", 18F);
            dataGridViewCellStyle38.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle38;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.Color.Black;
            this.dgvList.Location = new System.Drawing.Point(10, 0);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle39.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("MS Gothic", 18F);
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle39;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvList.RowTemplate.Height = 60;
            this.dgvList.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1223, 651);
            this.dgvList.TabIndex = 0;
            this.dgvList.TabStop = false;
            this.dgvList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvList_DataBindingComplete);
            // 
            // colShukka_dt
            // 
            this.colShukka_dt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colShukka_dt.DataPropertyName = "colShukka_dt";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colShukka_dt.DefaultCellStyle = dataGridViewCellStyle29;
            this.colShukka_dt.HeaderText = "出荷日";
            this.colShukka_dt.MinimumWidth = 180;
            this.colShukka_dt.Name = "colShukka_dt";
            this.colShukka_dt.ReadOnly = true;
            this.colShukka_dt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colShukka_dt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTorikomi_num
            // 
            this.colTorikomi_num.DataPropertyName = "colTorikomi_num";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTorikomi_num.DefaultCellStyle = dataGridViewCellStyle30;
            this.colTorikomi_num.HeaderText = "取込\n回数";
            this.colTorikomi_num.MinimumWidth = 100;
            this.colTorikomi_num.Name = "colTorikomi_num";
            this.colTorikomi_num.ReadOnly = true;
            this.colTorikomi_num.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTorikomi_num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colNohinSaki_upd_num
            // 
            this.colNohinSaki_upd_num.DataPropertyName = "colNohinSaki_upd_num";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colNohinSaki_upd_num.DefaultCellStyle = dataGridViewCellStyle31;
            this.colNohinSaki_upd_num.HeaderText = "納品先開始";
            this.colNohinSaki_upd_num.MinimumWidth = 100;
            this.colNohinSaki_upd_num.Name = "colNohinSaki_upd_num";
            this.colNohinSaki_upd_num.ReadOnly = true;
            this.colNohinSaki_upd_num.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNohinSaki_upd_num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colNIKE_Shukka_Data
            // 
            this.colNIKE_Shukka_Data.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colNIKE_Shukka_Data.DataPropertyName = "colNIKE_Shukka_Data";
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colNIKE_Shukka_Data.DefaultCellStyle = dataGridViewCellStyle32;
            this.colNIKE_Shukka_Data.HeaderText = "\n\n出荷データ";
            this.colNIKE_Shukka_Data.MinimumWidth = 140;
            this.colNIKE_Shukka_Data.Name = "colNIKE_Shukka_Data";
            this.colNIKE_Shukka_Data.ReadOnly = true;
            this.colNIKE_Shukka_Data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNIKE_Shukka_Data.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNIKE_Shukka_Data.Width = 140;
            // 
            // colNIKE_Carton
            // 
            this.colNIKE_Carton.DataPropertyName = "colNIKE_Carton";
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colNIKE_Carton.DefaultCellStyle = dataGridViewCellStyle33;
            this.colNIKE_Carton.HeaderText = "\n\nカートン";
            this.colNIKE_Carton.MinimumWidth = 140;
            this.colNIKE_Carton.Name = "colNIKE_Carton";
            this.colNIKE_Carton.ReadOnly = true;
            this.colNIKE_Carton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNIKE_Carton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNIKE_Carton.Width = 140;
            // 
            // colOther_Shukka_Data
            // 
            this.colOther_Shukka_Data.DataPropertyName = "colOther_Shukka_Data";
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colOther_Shukka_Data.DefaultCellStyle = dataGridViewCellStyle34;
            this.colOther_Shukka_Data.HeaderText = "\n\n出荷データ";
            this.colOther_Shukka_Data.MinimumWidth = 140;
            this.colOther_Shukka_Data.Name = "colOther_Shukka_Data";
            this.colOther_Shukka_Data.ReadOnly = true;
            this.colOther_Shukka_Data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colOther_Shukka_Data.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colOther_Shukka_Data.Width = 140;
            // 
            // colTotal_Shukka_Data
            // 
            this.colTotal_Shukka_Data.DataPropertyName = "colTotal_Shukka_Data";
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotal_Shukka_Data.DefaultCellStyle = dataGridViewCellStyle35;
            this.colTotal_Shukka_Data.HeaderText = "\n\n出荷データ";
            this.colTotal_Shukka_Data.MinimumWidth = 140;
            this.colTotal_Shukka_Data.Name = "colTotal_Shukka_Data";
            this.colTotal_Shukka_Data.ReadOnly = true;
            this.colTotal_Shukka_Data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTotal_Shukka_Data.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTotal_Shukka_Data.Width = 140;
            // 
            // colTotal_Carton
            // 
            this.colTotal_Carton.DataPropertyName = "colTotal_Carton";
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotal_Carton.DefaultCellStyle = dataGridViewCellStyle36;
            this.colTotal_Carton.HeaderText = "\n\nカートン";
            this.colTotal_Carton.MinimumWidth = 140;
            this.colTotal_Carton.Name = "colTotal_Carton";
            this.colTotal_Carton.ReadOnly = true;
            this.colTotal_Carton.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTotal_Carton.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTotal_Carton.Width = 140;
            // 
            // colProgress
            // 
            this.colProgress.DataPropertyName = "colProgress";
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle37.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("MS Gothic", 18F);
            dataGridViewCellStyle37.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colProgress.DefaultCellStyle = dataGridViewCellStyle37;
            this.colProgress.HeaderText = "進捗率";
            this.colProgress.MinimumWidth = 90;
            this.colProgress.Name = "colProgress";
            this.colProgress.ReadOnly = true;
            this.colProgress.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colProgress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colProgress.Width = 90;
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.Color.Black;
            this.customPanel1.Location = new System.Drawing.Point(10, 820);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(1502, 1);
            this.customPanel1.TabIndex = 120;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 923);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.dtpSekisai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnMstSettings);
            this.Controls.Add(this.btnMstNohinSaki);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnCompleteProgress);
            this.Controls.Add(this.btnCancelProgress);
            this.Controls.Add(this.btnShowProgress);
            this.Controls.Add(this.baseButton8);
            this.Controls.Add(this.btnLaneSetting);
            this.Controls.Add(this.btnImportShukka);
            this.Controls.Add(this.panel1);
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmJuchuList";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnImportShukka, 0);
            this.Controls.SetChildIndex(this.btnLaneSetting, 0);
            this.Controls.SetChildIndex(this.baseButton8, 0);
            this.Controls.SetChildIndex(this.btnShowProgress, 0);
            this.Controls.SetChildIndex(this.btnCancelProgress, 0);
            this.Controls.SetChildIndex(this.btnCompleteProgress, 0);
            this.Controls.SetChildIndex(this.btnQuit, 0);
            this.Controls.SetChildIndex(this.btnMstNohinSaki, 0);
            this.Controls.SetChildIndex(this.btnMstSettings, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpSekisai, 0);
            this.Controls.SetChildIndex(this.pnHeader, 0);
            this.Controls.SetChildIndex(this.ucFunction1, 0);
            this.Controls.SetChildIndex(this.customPanel1, 0);
            this.pnHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CtrlLib.MyControls.BaseButton btnImportShukka;
        private CtrlLib.MyControls.BaseButton btnLaneSetting;
        private CtrlLib.MyControls.BaseButton btnShowProgress;
        private CtrlLib.MyControls.BaseButton btnCancelProgress;
        private CtrlLib.MyControls.BaseButton btnQuit;
        private CtrlLib.MyControls.BaseButton btnMstNohinSaki;
        private CtrlLib.MyControls.BaseButton btnCompleteProgress;
        private CtrlLib.MyControls.BaseButton btnMstSettings;
        private CtrlLib.MyControls.Label label1;
        private CtrlLib.ucDateTimePicker dtpSekisai;
        private CtrlLib.MyControls.BaseButton baseButton8;
        private CtrlLib.MyControls.BaseButton btnSearch;
        private System.Windows.Forms.Panel panel1;
        private CtrlLib.MyControls.DataGridView dgvList;
        private CtrlLib.MyControls.Label label2;
        private CtrlLib.MyControls.Label label3;
        private CtrlLib.MyControls.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShukka_dt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTorikomi_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNohinSaki_upd_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNIKE_Shukka_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNIKE_Carton;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOther_Shukka_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal_Shukka_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal_Carton;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProgress;
        private CtrlLib.MyControls.CustomPanel customPanel1;
    }
}