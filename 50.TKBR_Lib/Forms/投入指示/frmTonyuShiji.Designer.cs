namespace TKBR_Lib.Forms
{
    partial class frmTonyuShiji
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
            this.dgvTonyuShiji = new CtrlLib.MyControls.DataGridView();
            this.btnModoru = new CtrlLib.MyControls.BaseButton();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonyuShiji)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.Size = new System.Drawing.Size(1478, 45);
            // 
            // lblScreenName
            // 
            this.lblScreenName.Size = new System.Drawing.Size(1478, 45);
            // 
            // ucFunction1
            // 
            this.ucFunction1.Location = new System.Drawing.Point(0, 898);
            this.ucFunction1.Size = new System.Drawing.Size(1478, 0);
            // 
            // dgvTonyuShiji
            // 
            this.dgvTonyuShiji.BackgroundColor = System.Drawing.Color.White;
            this.dgvTonyuShiji.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTonyuShiji.DataGridColumns = null;
            this.dgvTonyuShiji.Location = new System.Drawing.Point(28, 66);
            this.dgvTonyuShiji.Name = "dgvTonyuShiji";
            this.dgvTonyuShiji.RowTemplate.Height = 21;
            this.dgvTonyuShiji.Size = new System.Drawing.Size(1422, 746);
            this.dgvTonyuShiji.TabIndex = 15;
            this.dgvTonyuShiji.TabStop = false;
            // 
            // btnModoru
            // 
            this.btnModoru.Caption = null;
            this.btnModoru.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnModoru.Location = new System.Drawing.Point(1271, 830);
            this.btnModoru.Name = "btnModoru";
            this.btnModoru.Size = new System.Drawing.Size(180, 60);
            this.btnModoru.TabIndex = 16;
            this.btnModoru.Text = "戻る";
            this.btnModoru.UseVisualStyleBackColor = true;
            this.btnModoru.Click += new System.EventHandler(this.btnModoru_Click);
            // 
            // frmTonyuShiji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 921);
            this.Controls.Add(this.btnModoru);
            this.Controls.Add(this.dgvTonyuShiji);
            this.Name = "frmTonyuShiji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTonyuShiji";
            this.Controls.SetChildIndex(this.pnHeader, 0);
            this.Controls.SetChildIndex(this.ucFunction1, 0);
            this.Controls.SetChildIndex(this.dgvTonyuShiji, 0);
            this.Controls.SetChildIndex(this.btnModoru, 0);
            this.pnHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonyuShiji)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtrlLib.MyControls.DataGridView dgvTonyuShiji;
        private CtrlLib.MyControls.BaseButton btnModoru;
    }
}