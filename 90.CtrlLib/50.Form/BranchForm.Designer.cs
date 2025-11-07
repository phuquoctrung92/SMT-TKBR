
namespace CtrlLib
{
    partial class BranchForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblScreenName = new CtrlLib.MyControls.Label();
            this.ucFunction1 = new CtrlLib.ucFunction();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.lblScreenName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 50);
            this.panel1.TabIndex = 1;
            // 
            // lblScreenName
            // 
            this.lblScreenName.AutoSize = true;
            this.lblScreenName.BackColor = System.Drawing.Color.Transparent;
            this.lblScreenName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScreenName.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.lblScreenName.ForeColor = System.Drawing.Color.White;
            this.lblScreenName.Location = new System.Drawing.Point(0, 0);
            this.lblScreenName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.lblScreenName.Name = "lblScreenName";
            this.lblScreenName.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
            this.lblScreenName.Size = new System.Drawing.Size(126, 36);
            this.lblScreenName.TabIndex = 3;
            this.lblScreenName.Text = "■画面名";
            // 
            // ucFunction1
            // 
            this.ucFunction1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucFunction1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ucFunction1.FunctionButtonCount = 5;
            this.ucFunction1.FunctionButtonFont = new System.Drawing.Font("MS Gothic", 18F);
            this.ucFunction1.FunctionButtonSize = new System.Drawing.Size(100, 60);
            this.ucFunction1.Location = new System.Drawing.Point(0, 540);
            this.ucFunction1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ucFunction1.Name = "ucFunction1";
            this.ucFunction1.Size = new System.Drawing.Size(692, 63);
            this.ucFunction1.TabIndex = 9;
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
            // BranchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(692, 626);
            this.Controls.Add(this.ucFunction1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "BranchForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BranchForm";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.ucFunction1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Panel panel1;
        public MyControls.Label lblScreenName;
        public ucFunction ucFunction1;
    }
}