namespace TKBR_Lib.Forms
{
    partial class frmShiwakeStatus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnQuit = new CtrlLib.MyControls.BaseButton();
            this.baseButton1 = new CtrlLib.MyControls.BaseButton();
            this.label1 = new CtrlLib.MyControls.Label();
            this.customPanel1 = new CtrlLib.MyControls.CustomPanel();
            this.lblProgess_Percent = new CtrlLib.MyControls.Label();
            this.lblProgess = new CtrlLib.MyControls.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvList = new CtrlLib.MyControls.DataGridView();
            this.colLane = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNohinSaki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMiTonyu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnHeader.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // ucFunction1
            // 
            this.ucFunction1.Location = new System.Drawing.Point(0, 900);
            this.ucFunction1.Size = new System.Drawing.Size(1534, 0);
            // 
            // btnQuit
            // 
            this.btnQuit.Caption = null;
            this.btnQuit.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnQuit.Location = new System.Drawing.Point(1331, 832);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(180, 60);
            this.btnQuit.TabIndex = 99;
            this.btnQuit.Text = "戻る";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // baseButton1
            // 
            this.baseButton1.Caption = null;
            this.baseButton1.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.baseButton1.Location = new System.Drawing.Point(23, 832);
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.Size = new System.Drawing.Size(180, 60);
            this.baseButton1.TabIndex = 81;
            this.baseButton1.Text = "投入指示";
            this.baseButton1.UseVisualStyleBackColor = true;
            this.baseButton1.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label1.Location = new System.Drawing.Point(59, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 100;
            this.label1.Text = "全体の進捗";
            // 
            // customPanel1
            // 
            this.customPanel1.Controls.Add(this.lblProgess_Percent);
            this.customPanel1.Controls.Add(this.lblProgess);
            this.customPanel1.Location = new System.Drawing.Point(210, 51);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(660, 53);
            this.customPanel1.TabIndex = 102;
            // 
            // lblProgess_Percent
            // 
            this.lblProgess_Percent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.lblProgess_Percent.Font = new System.Drawing.Font("MS Gothic", 30F);
            this.lblProgess_Percent.Location = new System.Drawing.Point(434, 0);
            this.lblProgess_Percent.Name = "lblProgess_Percent";
            this.lblProgess_Percent.Size = new System.Drawing.Size(142, 53);
            this.lblProgess_Percent.TabIndex = 103;
            this.lblProgess_Percent.Text = "100%";
            this.lblProgess_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblProgess_Percent.Paint += new System.Windows.Forms.PaintEventHandler(this.lblBorder_Paint);
            // 
            // lblProgess
            // 
            this.lblProgess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(225)))), ((int)(((byte)(242)))));
            this.lblProgess.Font = new System.Drawing.Font("MS Gothic", 30F);
            this.lblProgess.Location = new System.Drawing.Point(0, 0);
            this.lblProgess.Name = "lblProgess";
            this.lblProgess.Size = new System.Drawing.Size(437, 53);
            this.lblProgess.TabIndex = 103;
            this.lblProgess.Text = "9,999,999 / 9,999,999";
            this.lblProgess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgess.Paint += new System.Windows.Forms.PaintEventHandler(this.lblBorder_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvList);
            this.panel1.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.panel1.Location = new System.Drawing.Point(23, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1488, 656);
            this.panel1.TabIndex = 108;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(215)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS Gothic", 18F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(215)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeight = 50;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLane,
            this.colNohinSaki,
            this.colProgress,
            this.colMiTonyu,
            this.colStatus,
            this.colButton});
            this.dgvList.DataGridColumns = null;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("MS Gothic", 18F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvList.EnableHeadersVisualStyles = false;
            this.dgvList.GridColor = System.Drawing.Color.Black;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Margin = new System.Windows.Forms.Padding(0);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("MS Gothic", 18F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.dgvList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvList.RowTemplate.Height = 60;
            this.dgvList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1488, 656);
            this.dgvList.TabIndex = 0;
            this.dgvList.TabStop = false;
            this.dgvList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvList_DataBindingComplete);
            // 
            // colLane
            // 
            this.colLane.DataPropertyName = "colLane";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS Gothic", 30.25F);
            this.colLane.DefaultCellStyle = dataGridViewCellStyle3;
            this.colLane.HeaderText = "レーン";
            this.colLane.MinimumWidth = 90;
            this.colLane.Name = "colLane";
            this.colLane.ReadOnly = true;
            this.colLane.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colLane.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colLane.Width = 90;
            // 
            // colNohinSaki
            // 
            this.colNohinSaki.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNohinSaki.DataPropertyName = "colNohinSaki";
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colNohinSaki.DefaultCellStyle = dataGridViewCellStyle4;
            this.colNohinSaki.HeaderText = "納品先";
            this.colNohinSaki.MinimumWidth = 100;
            this.colNohinSaki.Name = "colNohinSaki";
            this.colNohinSaki.ReadOnly = true;
            this.colNohinSaki.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNohinSaki.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colProgress
            // 
            this.colProgress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.colProgress.DataPropertyName = "colProgress";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.colProgress.DefaultCellStyle = dataGridViewCellStyle5;
            this.colProgress.HeaderText = "進捗（進捗率）";
            this.colProgress.MinimumWidth = 400;
            this.colProgress.Name = "colProgress";
            this.colProgress.ReadOnly = true;
            this.colProgress.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colProgress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colProgress.Width = 400;
            // 
            // colMiTonyu
            // 
            this.colMiTonyu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.colMiTonyu.DataPropertyName = "colMiTonyu";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("MS Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.colMiTonyu.DefaultCellStyle = dataGridViewCellStyle6;
            this.colMiTonyu.HeaderText = "未投入";
            this.colMiTonyu.MinimumWidth = 150;
            this.colMiTonyu.Name = "colMiTonyu";
            this.colMiTonyu.ReadOnly = true;
            this.colMiTonyu.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMiTonyu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMiTonyu.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "colStatus";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("MS Gothic", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.colStatus.DefaultCellStyle = dataGridViewCellStyle7;
            this.colStatus.HeaderText = "状態";
            this.colStatus.MinimumWidth = 150;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStatus.Width = 150;
            // 
            // colButton
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.colButton.DefaultCellStyle = dataGridViewCellStyle8;
            this.colButton.HeaderText = "";
            this.colButton.MinimumWidth = 100;
            this.colButton.Name = "colButton";
            this.colButton.ReadOnly = true;
            // 
            // frmShiwakeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 923);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baseButton1);
            this.Controls.Add(this.btnQuit);
            this.Name = "frmShiwakeStatus";
            this.Text = "frmShiwakeStatus";
            this.Load += new System.EventHandler(this.frmShiwakeStatus_Load);
            this.Controls.SetChildIndex(this.pnHeader, 0);
            this.Controls.SetChildIndex(this.ucFunction1, 0);
            this.Controls.SetChildIndex(this.btnQuit, 0);
            this.Controls.SetChildIndex(this.baseButton1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.customPanel1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.pnHeader.ResumeLayout(false);
            this.customPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtrlLib.MyControls.BaseButton btnQuit;
        private CtrlLib.MyControls.BaseButton baseButton1;
        private CtrlLib.MyControls.Label label1;
        private CtrlLib.MyControls.CustomPanel customPanel1;
        private CtrlLib.MyControls.Label lblProgess;
        private CtrlLib.MyControls.Label lblProgess_Percent;
        private System.Windows.Forms.Panel panel1;
        private CtrlLib.MyControls.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLane;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNohinSaki;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMiTonyu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewButtonColumn colButton;
    }
}