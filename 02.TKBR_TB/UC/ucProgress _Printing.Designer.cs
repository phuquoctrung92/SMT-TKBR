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
            this.btnPrint = new CtrlLib.MyControls.BaseButton();
            this.ucLabelBlinking1 = new CtrlLib.MyControls.ucLabelBlinking();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.Caption = null;
            this.btnPrint.Font = new System.Drawing.Font("MS UI Gothic", 40F);
            this.btnPrint.ForeColor = System.Drawing.Color.Red;
            this.btnPrint.Location = new System.Drawing.Point(3, 41);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(905, 88);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "明細印刷";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // ucLabelBlinking1
            // 
            this.ucLabelBlinking1.BlinkingBgColor = System.Drawing.Color.Transparent;
            this.ucLabelBlinking1.BlinkingEnable = false;
            this.ucLabelBlinking1.BlinkingFontColor = System.Drawing.Color.Red;
            this.ucLabelBlinking1.BlinkingInterval = 1;
            this.ucLabelBlinking1.DefaultBgColor = System.Drawing.Color.Empty;
            this.ucLabelBlinking1.DefaultFontColor = System.Drawing.Color.Empty;
            this.ucLabelBlinking1.Font = new System.Drawing.Font("MS UI Gothic", 24F);
            this.ucLabelBlinking1.Location = new System.Drawing.Point(3, -8);
            this.ucLabelBlinking1.Margin = new System.Windows.Forms.Padding(2);
            this.ucLabelBlinking1.Name = "ucLabelBlinking1";
            this.ucLabelBlinking1.Size = new System.Drawing.Size(905, 41);
            this.ucLabelBlinking1.TabIndex = 1;
            this.ucLabelBlinking1.Text = "積み込み作業完了後、明細印刷ボタンを押してください";
            this.ucLabelBlinking1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucProgress_Printing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ucLabelBlinking1);
            this.Controls.Add(this.btnPrint);
            this.Name = "ucProgress_Printing";
            this.Size = new System.Drawing.Size(911, 144);
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlLib.MyControls.BaseButton btnPrint;
        private CtrlLib.MyControls.ucLabelBlinking ucLabelBlinking1;
    }
}
