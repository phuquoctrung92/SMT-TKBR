namespace TKBR_TB.UC
{
    partial class ucProgress_Printing
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
            this.ucLabelBlinking1 = new CtrlLib.MyControls.ucLabelBlinking();
            this.btnPrint = new CtrlLib.MyControls.BaseButton();
            this.SuspendLayout();
            // 
            // ucLabelBlinking1
            // 
            this.ucLabelBlinking1.BackColor = System.Drawing.Color.Black;
            this.ucLabelBlinking1.BlinkingBgColor = System.Drawing.Color.Black;
            this.ucLabelBlinking1.BlinkingEnable = true;
            this.ucLabelBlinking1.BlinkingFontColor = System.Drawing.Color.Yellow;
            this.ucLabelBlinking1.BlinkingInterval = 1;
            this.ucLabelBlinking1.DefaultBgColor = System.Drawing.Color.Empty;
            this.ucLabelBlinking1.DefaultFontColor = System.Drawing.Color.Red;
            this.ucLabelBlinking1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucLabelBlinking1.Font = new System.Drawing.Font("MS UI Gothic", 24F);
            this.ucLabelBlinking1.ForeColor = System.Drawing.Color.Yellow;
            this.ucLabelBlinking1.Location = new System.Drawing.Point(0, 0);
            this.ucLabelBlinking1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ucLabelBlinking1.Name = "ucLabelBlinking1";
            this.ucLabelBlinking1.Size = new System.Drawing.Size(1215, 51);
            this.ucLabelBlinking1.TabIndex = 1;
            this.ucLabelBlinking1.Text = "積み込み作業完了後、明細印刷ボタンを押してください";
            this.ucLabelBlinking1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.Caption = null;
            this.btnPrint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPrint.Font = new System.Drawing.Font("MS UI Gothic", 40F);
            this.btnPrint.ForeColor = System.Drawing.Color.Red;
            this.btnPrint.Location = new System.Drawing.Point(0, 70);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(1215, 110);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "明細印刷";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // ucProgress_Printing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ucLabelBlinking1);
            this.Controls.Add(this.btnPrint);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucProgress_Printing";
            this.Size = new System.Drawing.Size(1215, 180);
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlLib.MyControls.BaseButton btnPrint;
        private CtrlLib.MyControls.ucLabelBlinking ucLabelBlinking1;
    }
}
