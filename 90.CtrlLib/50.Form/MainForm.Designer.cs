using System.ComponentModel;

namespace CtrlLib
{
    partial class MainForm
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
            this.pnHeader = new System.Windows.Forms.Panel();
            this.lblScreenName = new CtrlLib.MyControls.Label();
            this.ucFunction1 = new CtrlLib.ucFunction();
            this.pnHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.pnHeader.Controls.Add(this.lblScreenName);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1534, 45);
            this.pnHeader.TabIndex = 7;
            // 
            // lblScreenName
            // 
            this.lblScreenName.BackColor = System.Drawing.Color.Transparent;
            this.lblScreenName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScreenName.Font = new System.Drawing.Font("MS Gothic", 24F);
            this.lblScreenName.ForeColor = System.Drawing.Color.White;
            this.lblScreenName.Location = new System.Drawing.Point(0, 0);
            this.lblScreenName.Margin = new System.Windows.Forms.Padding(0);
            this.lblScreenName.Name = "lblScreenName";
            this.lblScreenName.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblScreenName.Size = new System.Drawing.Size(1534, 45);
            this.lblScreenName.TabIndex = 2;
            this.lblScreenName.Text = "画面名";
            this.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucFunction1
            // 
            this.ucFunction1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucFunction1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucFunction1.FunctionButtonCount = 10;
            this.ucFunction1.FunctionButtonFont = new System.Drawing.Font("MS Gothic", 18F);
            this.ucFunction1.FunctionButtonSize = new System.Drawing.Size(140, 65);
            this.ucFunction1.Location = new System.Drawing.Point(0, 810);
            this.ucFunction1.Margin = new System.Windows.Forms.Padding(5);
            this.ucFunction1.Name = "ucFunction1";
            this.ucFunction1.Size = new System.Drawing.Size(1534, 90);
            this.ucFunction1.TabIndex = 8;
            this.ucFunction1.F1 += new CtrlLib.ucFunction.F1EventHandler(this.ucFunction1_F1);
            this.ucFunction1.F2 += new CtrlLib.ucFunction.F2EventHandler(this.ucFunction1_F2);
            this.ucFunction1.F3 += new CtrlLib.ucFunction.F3EventHandler(this.ucFunction1_F3);
            this.ucFunction1.F4 += new CtrlLib.ucFunction.F4EventHandler(this.ucFunction1_F4);
            this.ucFunction1.F5 += new CtrlLib.ucFunction.F5EventHandler(this.ucFunction1_F5);
            this.ucFunction1.F6 += new CtrlLib.ucFunction.F6EventHandler(this.ucFunction1_F6);
            this.ucFunction1.F7 += new CtrlLib.ucFunction.F7EventHandler(this.ucFunction1_F7);
            this.ucFunction1.F8 += new CtrlLib.ucFunction.F8EventHandler(this.ucFunction1_F8);
            this.ucFunction1.F9 += new CtrlLib.ucFunction.F9EventHandler(this.ucFunction1_F9);
            this.ucFunction1.F10 += new CtrlLib.ucFunction.F10EventHandler(this.ucFunction1_F10);
            this.ucFunction1.F11 += new CtrlLib.ucFunction.F11EventHandler(this.ucFunction1_F11);
            this.ucFunction1.F12 += new CtrlLib.ucFunction.F12EventHandler(this.ucFunction1_F12);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1534, 923);
            this.Controls.Add(this.ucFunction1);
            this.Controls.Add(this.pnHeader);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1494, 960);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.formLoad);
            this.Controls.SetChildIndex(this.pnHeader, 0);
            this.Controls.SetChildIndex(this.ucFunction1, 0);
            this.pnHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        /// <summary>ヘッダーパネル</summary>
        public System.Windows.Forms.Panel pnHeader;
        /// <summary>画面名</summary>
        public MyControls.Label lblScreenName;
        public ucFunction ucFunction1;
    }
}
