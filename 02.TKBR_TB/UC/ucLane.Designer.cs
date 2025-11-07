namespace TKBR_TB.UC
{
    partial class ucLane
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
            this.pnl_Footer = new CtrlLib.MyControls.CustomPanel();
            this.pnl_Info = new CtrlLib.MyControls.CustomPanel();
            this.SuspendLayout();
            // 
            // pnl_Footer
            // 
            this.pnl_Footer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Footer.Location = new System.Drawing.Point(0, 641);
            this.pnl_Footer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_Footer.Name = "pnl_Footer";
            this.pnl_Footer.Size = new System.Drawing.Size(1043, 239);
            this.pnl_Footer.TabIndex = 14;
            // 
            // pnl_Info
            // 
            this.pnl_Info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Info.Location = new System.Drawing.Point(0, 0);
            this.pnl_Info.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnl_Info.Name = "pnl_Info";
            this.pnl_Info.Size = new System.Drawing.Size(1043, 641);
            this.pnl_Info.TabIndex = 13;
            // 
            // ucLane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_Footer);
            this.Controls.Add(this.pnl_Info);
            this.Name = "ucLane";
            this.Size = new System.Drawing.Size(1043, 880);
            this.Load += new System.EventHandler(this.ucLane_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlLib.MyControls.CustomPanel pnl_Footer;
        private CtrlLib.MyControls.CustomPanel pnl_Info;
    }
}
