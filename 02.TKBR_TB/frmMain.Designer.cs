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
            this.pnlLane1 = new CtrlLib.MyControls.CustomPanel();
            this.lblLane2 = new CtrlLib.MyControls.Label();
            this.pnlLane2 = new CtrlLib.MyControls.CustomPanel();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnHeader.Size = new System.Drawing.Size(2194, 0);
            // 
            // lblScreenName
            // 
            this.lblScreenName.Padding = new System.Windows.Forms.Padding(0, 0, 26, 0);
            this.lblScreenName.Size = new System.Drawing.Size(2194, 0);
            // 
            // ucFunction1
            // 
            this.ucFunction1.Location = new System.Drawing.Point(0, 1415);
            this.ucFunction1.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.ucFunction1.Size = new System.Drawing.Size(2194, 0);
            // 
            // btnQuit
            // 
            this.btnQuit.Caption = null;
            this.btnQuit.Font = new System.Drawing.Font("MS UI Gothic", 30F);
            this.btnQuit.Location = new System.Drawing.Point(1783, 1170);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(369, 107);
            this.btnQuit.TabIndex = 0;
            this.btnQuit.Text = "終了";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // customPanel1
            // 
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.Location = new System.Drawing.Point(1097, 0);
            this.customPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(2, 1169);
            this.customPanel1.TabIndex = 9;
            // 
            // lblLane1
            // 
            this.lblLane1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.lblLane1.Font = new System.Drawing.Font("Meiryo", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLane1.ForeColor = System.Drawing.Color.White;
            this.lblLane1.Location = new System.Drawing.Point(24, 31);
            this.lblLane1.Name = "lblLane1";
            this.lblLane1.Size = new System.Drawing.Size(1045, 185);
            this.lblLane1.TabIndex = 10;
            this.lblLane1.Text = "3レーン";
            this.lblLane1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLane1
            // 
            this.pnlLane1.Location = new System.Drawing.Point(25, 249);
            this.pnlLane1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLane1.Name = "pnlLane1";
            this.pnlLane1.Size = new System.Drawing.Size(1043, 880);
            this.pnlLane1.TabIndex = 12;
            // 
            // lblLane2
            // 
            this.lblLane2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(114)))), ((int)(((byte)(196)))));
            this.lblLane2.Font = new System.Drawing.Font("Meiryo", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLane2.ForeColor = System.Drawing.Color.White;
            this.lblLane2.Location = new System.Drawing.Point(1126, 31);
            this.lblLane2.Name = "lblLane2";
            this.lblLane2.Size = new System.Drawing.Size(1045, 185);
            this.lblLane2.TabIndex = 10;
            this.lblLane2.Text = "4レーン";
            this.lblLane2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLane2
            // 
            this.pnlLane2.Location = new System.Drawing.Point(1127, 249);
            this.pnlLane2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlLane2.Name = "pnlLane2";
            this.pnlLane2.Size = new System.Drawing.Size(1043, 880);
            this.pnlLane2.TabIndex = 12;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2194, 1441);
            this.ControlBox = false;
            this.Controls.Add(this.pnlLane2);
            this.Controls.Add(this.pnlLane1);
            this.Controls.Add(this.lblLane2);
            this.Controls.Add(this.lblLane1);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.btnQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1989, 1276);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtrlLib.MyControls.BaseButton btnQuit;
        private CtrlLib.MyControls.CustomPanel customPanel1;
        private CtrlLib.MyControls.Label lblLane1;
        private CtrlLib.MyControls.CustomPanel pnlLane1;
        private CtrlLib.MyControls.Label lblLane2;
        private CtrlLib.MyControls.CustomPanel pnlLane2;
    }
}

