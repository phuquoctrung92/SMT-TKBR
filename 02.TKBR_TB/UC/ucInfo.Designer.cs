namespace TKBR_TB.UC
{
    partial class ucInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNohinSaki = new CtrlLib.MyControls.Label();
            this.label5 = new CtrlLib.MyControls.Label();
            this.lblZansu = new CtrlLib.MyControls.Label();
            this.label1 = new CtrlLib.MyControls.Label();
            this.SuspendLayout();
            // 
            // lblNohinSaki
            // 
            this.lblNohinSaki.BackColor = System.Drawing.Color.White;
            this.lblNohinSaki.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNohinSaki.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNohinSaki.Font = new System.Drawing.Font("Meiryo", 30F, System.Drawing.FontStyle.Bold);
            this.lblNohinSaki.Location = new System.Drawing.Point(0, 59);
            this.lblNohinSaki.Name = "lblNohinSaki";
            this.lblNohinSaki.Size = new System.Drawing.Size(911, 256);
            this.lblNohinSaki.TabIndex = 9;
            this.lblNohinSaki.Text = "ABC-MART\r\nABCNETMART\r\n小山企業株式会社\r\n";
            this.lblNohinSaki.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(198)))), ((int)(((byte)(231)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Font = new System.Drawing.Font("Meiryo", 26F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(0, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(911, 59);
            this.label5.TabIndex = 8;
            this.label5.Text = "出庫残数";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZansu
            // 
            this.lblZansu.BackColor = System.Drawing.Color.White;
            this.lblZansu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZansu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblZansu.Font = new System.Drawing.Font("Meiryo", 100F, System.Drawing.FontStyle.Bold);
            this.lblZansu.Location = new System.Drawing.Point(0, 374);
            this.lblZansu.Name = "lblZansu";
            this.lblZansu.Size = new System.Drawing.Size(911, 186);
            this.lblZansu.TabIndex = 7;
            this.lblZansu.Text = "680";
            this.lblZansu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(198)))), ((int)(((byte)(231)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Meiryo", 26F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(911, 59);
            this.label1.TabIndex = 6;
            this.label1.Text = "納品先";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNohinSaki);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblZansu);
            this.Controls.Add(this.label1);
            this.Name = "ucInfo";
            this.Size = new System.Drawing.Size(911, 560);
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlLib.MyControls.Label lblNohinSaki;
        private CtrlLib.MyControls.Label label5;
        private CtrlLib.MyControls.Label lblZansu;
        private CtrlLib.MyControls.Label label1;
    }
}
