namespace TKBR_TB
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
            this.btnQuit = new CtrlLib.MyControls.BaseButton();
            this.customPanel1 = new CtrlLib.MyControls.CustomPanel();
            this.lblLane1 = new CtrlLib.MyControls.Label();
            this.pnlLane1_Info = new CtrlLib.MyControls.CustomPanel();
            this.pnlLane1 = new CtrlLib.MyControls.CustomPanel();
            this.pnlLane1_Footer = new CtrlLib.MyControls.CustomPanel();
            this.lblLane2 = new CtrlLib.MyControls.Label();
            this.pnlLane2 = new CtrlLib.MyControls.CustomPanel();
            this.pnlLane2_Footer = new CtrlLib.MyControls.CustomPanel();
            this.pnlLane2_Info = new CtrlLib.MyControls.CustomPanel();
            this.pnHeader.SuspendLayout();
            this.pnlLane1.SuspendLayout();
            this.pnlLane2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.Size = new System.Drawing.Size(1920, 0);
            // 
            // lblScreenName
            // 
            this.lblScreenName.Size = new System.Drawing.Size(1920, 0);
            // 
            // ucFunction1
            // 
            this.ucFunction1.Location = new System.Drawing.Point(0, 1057);
            this.ucFunction1.Size = new System.Drawing.Size(1920, 0);
            // 
            // btnQuit
            // 
            this.btnQuit.Caption = null;
            this.btnQuit.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.btnQuit.Location = new System.Drawing.Point(1560, 951);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(323, 87);
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "終了";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // customPanel1
            // 
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.Location = new System.Drawing.Point(960, 0);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(2, 950);
            this.customPanel1.TabIndex = 9;
            // 
            // lblLane1
            // 
            this.lblLane1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.lblLane1.Font = new System.Drawing.Font("Meiryo", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLane1.ForeColor = System.Drawing.Color.White;
            this.lblLane1.Location = new System.Drawing.Point(21, 25);
            this.lblLane1.Name = "lblLane1";
            this.lblLane1.Size = new System.Drawing.Size(914, 150);
            this.lblLane1.TabIndex = 10;
            this.lblLane1.Text = "3レーン";
            this.lblLane1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLane1_Info
            // 
            this.pnlLane1_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLane1_Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLane1_Info.Location = new System.Drawing.Point(0, 0);
            this.pnlLane1_Info.Name = "pnlLane1_Info";
            this.pnlLane1_Info.Size = new System.Drawing.Size(911, 560);
            this.pnlLane1_Info.TabIndex = 11;
            // 
            // pnlLane1
            // 
            this.pnlLane1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLane1.Controls.Add(this.pnlLane1_Footer);
            this.pnlLane1.Controls.Add(this.pnlLane1_Info);
            this.pnlLane1.Location = new System.Drawing.Point(22, 202);
            this.pnlLane1.Name = "pnlLane1";
            this.pnlLane1.Size = new System.Drawing.Size(913, 715);
            this.pnlLane1.TabIndex = 12;
            // 
            // pnlLane1_Footer
            // 
            this.pnlLane1_Footer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLane1_Footer.Location = new System.Drawing.Point(0, 560);
            this.pnlLane1_Footer.Name = "pnlLane1_Footer";
            this.pnlLane1_Footer.Size = new System.Drawing.Size(911, 153);
            this.pnlLane1_Footer.TabIndex = 12;
            // 
            // lblLane2
            // 
            this.lblLane2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.lblLane2.Font = new System.Drawing.Font("Meiryo", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLane2.ForeColor = System.Drawing.Color.White;
            this.lblLane2.Location = new System.Drawing.Point(985, 25);
            this.lblLane2.Name = "lblLane2";
            this.lblLane2.Size = new System.Drawing.Size(914, 150);
            this.lblLane2.TabIndex = 10;
            this.lblLane2.Text = "3レーン";
            this.lblLane2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLane2
            // 
            this.pnlLane2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLane2.Controls.Add(this.pnlLane2_Footer);
            this.pnlLane2.Controls.Add(this.pnlLane2_Info);
            this.pnlLane2.Location = new System.Drawing.Point(986, 202);
            this.pnlLane2.Name = "pnlLane2";
            this.pnlLane2.Size = new System.Drawing.Size(913, 715);
            this.pnlLane2.TabIndex = 12;
            // 
            // pnlLane2_Footer
            // 
            this.pnlLane2_Footer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLane2_Footer.Location = new System.Drawing.Point(0, 560);
            this.pnlLane2_Footer.Name = "pnlLane2_Footer";
            this.pnlLane2_Footer.Size = new System.Drawing.Size(911, 153);
            this.pnlLane2_Footer.TabIndex = 12;
            // 
            // pnlLane2_Info
            // 
            this.pnlLane2_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLane2_Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLane2_Info.Location = new System.Drawing.Point(0, 0);
            this.pnlLane2_Info.Name = "pnlLane2_Info";
            this.pnlLane2_Info.Size = new System.Drawing.Size(911, 560);
            this.pnlLane2_Info.TabIndex = 11;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.pnlLane2);
            this.Controls.Add(this.pnlLane1);
            this.Controls.Add(this.lblLane2);
            this.Controls.Add(this.lblLane1);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.btnQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1740, 1037);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Controls.SetChildIndex(this.btnQuit, 0);
            this.Controls.SetChildIndex(this.pnHeader, 0);
            this.Controls.SetChildIndex(this.ucFunction1, 0);
            this.Controls.SetChildIndex(this.customPanel1, 0);
            this.Controls.SetChildIndex(this.lblLane1, 0);
            this.Controls.SetChildIndex(this.lblLane2, 0);
            this.Controls.SetChildIndex(this.pnlLane1, 0);
            this.Controls.SetChildIndex(this.pnlLane2, 0);
            this.pnHeader.ResumeLayout(false);
            this.pnlLane1.ResumeLayout(false);
            this.pnlLane2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtrlLib.MyControls.BaseButton btnQuit;
        private CtrlLib.MyControls.CustomPanel customPanel1;
        private CtrlLib.MyControls.Label lblLane1;
        private CtrlLib.MyControls.CustomPanel pnlLane1_Info;
        private CtrlLib.MyControls.CustomPanel pnlLane1;
        private CtrlLib.MyControls.CustomPanel pnlLane1_Footer;
        private CtrlLib.MyControls.Label lblLane2;
        private CtrlLib.MyControls.CustomPanel pnlLane2;
        private CtrlLib.MyControls.CustomPanel pnlLane2_Footer;
        private CtrlLib.MyControls.CustomPanel pnlLane2_Info;
    }
}

