namespace TKBR_SV
{
    partial class frmMain
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
            this.lblPort = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btn_recvTest = new System.Windows.Forms.Button();
            this.txt_recvTest = new System.Windows.Forms.TextBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnTcpip = new System.Windows.Forms.Button();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.lblIpAddress = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.tlpLog = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLogMain = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.pnlLogBottom = new System.Windows.Forms.Panel();
            this.btnLogClear = new System.Windows.Forms.Button();
            this.pnlTagList = new System.Windows.Forms.Panel();
            this.lsvTag = new System.Windows.Forms.ListView();
            this.columnSerialNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderReceive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSend = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tlpMain.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.tlpLog.SuspendLayout();
            this.pnlLogMain.SuspendLayout();
            this.pnlLogBottom.SuspendLayout();
            this.pnlTagList.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPort
            // 
            this.lblPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPort.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPort.Location = new System.Drawing.Point(9, 33);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(119, 26);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "ポート";
            this.lblPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpMain.Controls.Add(this.pnlLog, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(839, 450);
            this.tlpMain.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btn_recvTest);
            this.pnlHeader.Controls.Add(this.txt_recvTest);
            this.pnlHeader.Controls.Add(this.btnEnd);
            this.pnlHeader.Controls.Add(this.btnTcpip);
            this.pnlHeader.Controls.Add(this.txtIpAddress);
            this.pnlHeader.Controls.Add(this.lblIpAddress);
            this.pnlHeader.Controls.Add(this.txtPort);
            this.pnlHeader.Controls.Add(this.lblPort);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(833, 94);
            this.pnlHeader.TabIndex = 1;
            // 
            // btn_recvTest
            // 
            this.btn_recvTest.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_recvTest.Location = new System.Drawing.Point(146, 65);
            this.btn_recvTest.Name = "btn_recvTest";
            this.btn_recvTest.Size = new System.Drawing.Size(119, 26);
            this.btn_recvTest.TabIndex = 7;
            this.btn_recvTest.Text = "受信テスト";
            this.btn_recvTest.UseVisualStyleBackColor = true;
            this.btn_recvTest.Click += new System.EventHandler(this.btn_recvTest_Click);
            // 
            // txt_recvTest
            // 
            this.txt_recvTest.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txt_recvTest.Location = new System.Drawing.Point(9, 65);
            this.txt_recvTest.Name = "txt_recvTest";
            this.txt_recvTest.Size = new System.Drawing.Size(131, 26);
            this.txt_recvTest.TabIndex = 6;
            this.txt_recvTest.TabStop = false;
            this.txt_recvTest.Text = "99999";
            this.txt_recvTest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEnd
            // 
            this.btnEnd.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnEnd.Location = new System.Drawing.Point(665, 18);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(98, 55);
            this.btnEnd.TabIndex = 5;
            this.btnEnd.Text = "終了";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.BtnEnd_Click);
            // 
            // btnTcpip
            // 
            this.btnTcpip.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTcpip.Location = new System.Drawing.Point(561, 18);
            this.btnTcpip.Name = "btnTcpip";
            this.btnTcpip.Size = new System.Drawing.Size(98, 55);
            this.btnTcpip.TabIndex = 4;
            this.btnTcpip.Text = "開始";
            this.btnTcpip.UseVisualStyleBackColor = true;
            this.btnTcpip.Click += new System.EventHandler(this.btnTcpip_Click);
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtIpAddress.Location = new System.Drawing.Point(352, 33);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(183, 26);
            this.txtIpAddress.TabIndex = 3;
            this.txtIpAddress.TabStop = false;
            this.txtIpAddress.Text = "999.999.999.999";
            this.txtIpAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIpAddress.Visible = false;
            // 
            // lblIpAddress
            // 
            this.lblIpAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblIpAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIpAddress.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblIpAddress.Location = new System.Drawing.Point(227, 33);
            this.lblIpAddress.Name = "lblIpAddress";
            this.lblIpAddress.Size = new System.Drawing.Size(119, 26);
            this.lblIpAddress.TabIndex = 2;
            this.lblIpAddress.Text = "IPアドレス";
            this.lblIpAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblIpAddress.Visible = false;
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPort.Location = new System.Drawing.Point(134, 33);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(73, 26);
            this.txtPort.TabIndex = 1;
            this.txtPort.TabStop = false;
            this.txtPort.Text = "99999";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlLog
            // 
            this.pnlLog.Controls.Add(this.tlpLog);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLog.Location = new System.Drawing.Point(3, 103);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(833, 344);
            this.pnlLog.TabIndex = 2;
            // 
            // tlpLog
            // 
            this.tlpLog.ColumnCount = 2;
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLog.Controls.Add(this.pnlLogMain, 0, 0);
            this.tlpLog.Controls.Add(this.pnlTagList, 1, 0);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(0, 0);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 1;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLog.Size = new System.Drawing.Size(833, 344);
            this.tlpLog.TabIndex = 0;
            // 
            // pnlLogMain
            // 
            this.pnlLogMain.Controls.Add(this.txtLog);
            this.pnlLogMain.Controls.Add(this.pnlLogBottom);
            this.pnlLogMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogMain.Location = new System.Drawing.Point(3, 3);
            this.pnlLogMain.Name = "pnlLogMain";
            this.pnlLogMain.Size = new System.Drawing.Size(410, 338);
            this.pnlLogMain.TabIndex = 9;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Black;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtLog.ForeColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(410, 301);
            this.txtLog.TabIndex = 7;
            this.txtLog.TabStop = false;
            this.txtLog.Text = "";
            // 
            // pnlLogBottom
            // 
            this.pnlLogBottom.Controls.Add(this.btnLogClear);
            this.pnlLogBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLogBottom.Location = new System.Drawing.Point(0, 301);
            this.pnlLogBottom.Name = "pnlLogBottom";
            this.pnlLogBottom.Size = new System.Drawing.Size(410, 37);
            this.pnlLogBottom.TabIndex = 8;
            // 
            // btnLogClear
            // 
            this.btnLogClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLogClear.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnLogClear.Location = new System.Drawing.Point(312, 0);
            this.btnLogClear.Name = "btnLogClear";
            this.btnLogClear.Size = new System.Drawing.Size(98, 37);
            this.btnLogClear.TabIndex = 5;
            this.btnLogClear.Text = "クリア";
            this.btnLogClear.UseVisualStyleBackColor = true;
            this.btnLogClear.Click += new System.EventHandler(this.btnLogClear_Click);
            // 
            // pnlTagList
            // 
            this.pnlTagList.Controls.Add(this.lsvTag);
            this.pnlTagList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTagList.Location = new System.Drawing.Point(419, 3);
            this.pnlTagList.Name = "pnlTagList";
            this.pnlTagList.Size = new System.Drawing.Size(411, 338);
            this.pnlTagList.TabIndex = 10;
            // 
            // lsvTag
            // 
            this.lsvTag.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSerialNo,
            this.columnHeaderReceive,
            this.columnHeaderSend,
            this.columnHeaderStatus,
            this.columnHeaderTime});
            this.lsvTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvTag.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lsvTag.FullRowSelect = true;
            this.lsvTag.GridLines = true;
            this.lsvTag.HideSelection = false;
            this.lsvTag.Location = new System.Drawing.Point(0, 0);
            this.lsvTag.Name = "lsvTag";
            this.lsvTag.Size = new System.Drawing.Size(411, 338);
            this.lsvTag.TabIndex = 10;
            this.lsvTag.UseCompatibleStateImageBehavior = false;
            this.lsvTag.View = System.Windows.Forms.View.Details;
            // 
            // columnSerialNo
            // 
            this.columnSerialNo.Text = "BHT Serial No.";
            this.columnSerialNo.Width = 100;
            // 
            // columnHeaderReceive
            // 
            this.columnHeaderReceive.Text = "受信回数";
            // 
            // columnHeaderSend
            // 
            this.columnHeaderSend.Text = "送信回数";
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "状態";
            this.columnHeaderStatus.Width = 50;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "日時";
            this.columnHeaderTime.Width = 130;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "frmMain";
            this.Text = "HT・SV連携";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Load);
            this.tlpMain.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLog.ResumeLayout(false);
            this.tlpLog.ResumeLayout(false);
            this.pnlLogMain.ResumeLayout(false);
            this.pnlLogBottom.ResumeLayout(false);
            this.pnlTagList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnTcpip;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Label lblIpAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Panel pnlLogBottom;
        private System.Windows.Forms.Button btnLogClear;
        private System.Windows.Forms.Panel pnlLogMain;
        private System.Windows.Forms.TableLayoutPanel tlpLog;
        private System.Windows.Forms.Panel pnlTagList;
        private System.Windows.Forms.ListView lsvTag;
        private System.Windows.Forms.ColumnHeader columnSerialNo;
        private System.Windows.Forms.ColumnHeader columnHeaderReceive;
        private System.Windows.Forms.ColumnHeader columnHeaderSend;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.Button btn_recvTest;
        private System.Windows.Forms.TextBox txt_recvTest;
    }
}