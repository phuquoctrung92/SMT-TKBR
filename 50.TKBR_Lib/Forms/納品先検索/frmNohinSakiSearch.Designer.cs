namespace TKBR_Lib.Forms
{
    partial class frmNohinSakiSearch
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
            this.label7 = new CtrlLib.MyControls.Label();
            this.txtNohinsakimei = new CtrlLib.MyControls.StringBox();
            this.label9 = new CtrlLib.MyControls.Label();
            this.cbbTodofuken = new CtrlLib.MyControls.ucComboBox();
            this.btnKensaku = new CtrlLib.MyControls.BaseButton();
            this.lblRen = new CtrlLib.MyControls.Label();
            this.lblSekisaiDate = new CtrlLib.MyControls.Label();
            this.label3 = new CtrlLib.MyControls.Label();
            this.label1 = new CtrlLib.MyControls.Label();
            this.btnSentaku = new CtrlLib.MyControls.BaseButton();
            this.btnModoru = new CtrlLib.MyControls.BaseButton();
            this.dgvNohinsaki = new CtrlLib.MyControls.DataGridView();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNohinsaki)).BeginInit();
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(5, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 15;
            this.label7.Text = "納品先名";
            // 
            // txtNohinsakimei
            // 
            this.txtNohinsakimei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNohinsakimei.Caption = "納品先名";
            this.txtNohinsakimei.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtNohinsakimei.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtNohinsakimei.InputPattern = CtrlLib.MyControls.InputPatterns.All;
            this.txtNohinsakimei.Location = new System.Drawing.Point(132, 120);
            this.txtNohinsakimei.Name = "txtNohinsakimei";
            this.txtNohinsakimei.PasteType = CtrlLib.MyControls.PasteTypes.Control;
            this.txtNohinsakimei.Size = new System.Drawing.Size(527, 33);
            this.txtNohinsakimei.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(726, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 24);
            this.label9.TabIndex = 18;
            this.label9.Text = "都道府県";
            // 
            // cbbTodofuken
            // 
            this.cbbTodofuken.Caption = "都道府県";
            this.cbbTodofuken.ComboWidth = 153;
            this.cbbTodofuken.CurrentIndex = 0;
            this.cbbTodofuken.DropDownHeight = 106;
            this.cbbTodofuken.DropDownWidth = 153;
            this.cbbTodofuken.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cbbTodofuken.LabelVisible = false;
            this.cbbTodofuken.Location = new System.Drawing.Point(857, 121);
            this.cbbTodofuken.MoveFlg = false;
            this.cbbTodofuken.Name = "cbbTodofuken";
            this.cbbTodofuken.SelectedIndex = -1;
            this.cbbTodofuken.SelectedValue = "";
            this.cbbTodofuken.Size = new System.Drawing.Size(153, 32);
            this.cbbTodofuken.TabIndex = 1;
            // 
            // btnKensaku
            // 
            this.btnKensaku.BackColor = System.Drawing.Color.White;
            this.btnKensaku.Caption = null;
            this.btnKensaku.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnKensaku.Location = new System.Drawing.Point(1078, 114);
            this.btnKensaku.Name = "btnKensaku";
            this.btnKensaku.Size = new System.Drawing.Size(152, 40);
            this.btnKensaku.TabIndex = 2;
            this.btnKensaku.Text = "検索";
            this.btnKensaku.UseVisualStyleBackColor = false;
            this.btnKensaku.Click += new System.EventHandler(this.btnKensaku_Click);
            // 
            // lblRen
            // 
            this.lblRen.BackColor = System.Drawing.Color.Yellow;
            this.lblRen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRen.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.lblRen.Location = new System.Drawing.Point(467, 62);
            this.lblRen.Name = "lblRen";
            this.lblRen.Size = new System.Drawing.Size(86, 33);
            this.lblRen.TabIndex = 123;
            this.lblRen.Text = "3";
            this.lblRen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSekisaiDate
            // 
            this.lblSekisaiDate.BackColor = System.Drawing.Color.Yellow;
            this.lblSekisaiDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSekisaiDate.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.lblSekisaiDate.Location = new System.Drawing.Point(132, 62);
            this.lblSekisaiDate.Name = "lblSekisaiDate";
            this.lblSekisaiDate.Size = new System.Drawing.Size(153, 33);
            this.lblSekisaiDate.TabIndex = 122;
            this.lblSekisaiDate.Text = "2025/08/29";
            this.lblSekisaiDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label3.Location = new System.Drawing.Point(359, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 121;
            this.label3.Text = "レーン";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label1.Location = new System.Drawing.Point(28, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 120;
            this.label1.Text = "積載日";
            // 
            // btnSentaku
            // 
            this.btnSentaku.Caption = null;
            this.btnSentaku.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnSentaku.Location = new System.Drawing.Point(1100, 830);
            this.btnSentaku.Name = "btnSentaku";
            this.btnSentaku.Size = new System.Drawing.Size(180, 60);
            this.btnSentaku.TabIndex = 3;
            this.btnSentaku.Text = "選択";
            this.btnSentaku.UseVisualStyleBackColor = true;
            // 
            // btnModoru
            // 
            this.btnModoru.Caption = null;
            this.btnModoru.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnModoru.Location = new System.Drawing.Point(1286, 830);
            this.btnModoru.Name = "btnModoru";
            this.btnModoru.Size = new System.Drawing.Size(180, 60);
            this.btnModoru.TabIndex = 4;
            this.btnModoru.Text = "戻る";
            this.btnModoru.UseVisualStyleBackColor = true;
            this.btnModoru.Click += new System.EventHandler(this.btnModoru_Click);
            // 
            // dgvNohinsaki
            // 
            this.dgvNohinsaki.BackgroundColor = System.Drawing.Color.White;
            this.dgvNohinsaki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNohinsaki.DataGridColumns = null;
            this.dgvNohinsaki.Location = new System.Drawing.Point(10, 178);
            this.dgvNohinsaki.Name = "dgvNohinsaki";
            this.dgvNohinsaki.RowTemplate.Height = 21;
            this.dgvNohinsaki.Size = new System.Drawing.Size(1458, 636);
            this.dgvNohinsaki.TabIndex = 126;
            this.dgvNohinsaki.TabStop = false;
            // 
            // frmNohinSakiSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 921);
            this.Controls.Add(this.dgvNohinsaki);
            this.Controls.Add(this.btnSentaku);
            this.Controls.Add(this.btnModoru);
            this.Controls.Add(this.lblRen);
            this.Controls.Add(this.lblSekisaiDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKensaku);
            this.Controls.Add(this.cbbTodofuken);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNohinsakimei);
            this.Controls.Add(this.label7);
            this.Name = "frmNohinSakiSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNohinkensaku";
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtNohinsakimei, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.cbbTodofuken, 0);
            this.Controls.SetChildIndex(this.btnKensaku, 0);
            this.Controls.SetChildIndex(this.pnHeader, 0);
            this.Controls.SetChildIndex(this.ucFunction1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.lblSekisaiDate, 0);
            this.Controls.SetChildIndex(this.lblRen, 0);
            this.Controls.SetChildIndex(this.btnModoru, 0);
            this.Controls.SetChildIndex(this.btnSentaku, 0);
            this.Controls.SetChildIndex(this.dgvNohinsaki, 0);
            this.pnHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNohinsaki)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CtrlLib.MyControls.Label label7;
        private CtrlLib.MyControls.StringBox txtNohinsakimei;
        private CtrlLib.MyControls.Label label9;
        private CtrlLib.MyControls.ucComboBox cbbTodofuken;
        private CtrlLib.MyControls.BaseButton btnKensaku;
        private CtrlLib.MyControls.Label lblRen;
        private CtrlLib.MyControls.Label lblSekisaiDate;
        private CtrlLib.MyControls.Label label3;
        private CtrlLib.MyControls.Label label1;
        private CtrlLib.MyControls.BaseButton btnSentaku;
        private CtrlLib.MyControls.BaseButton btnModoru;
        private CtrlLib.MyControls.DataGridView dgvNohinsaki;
    }
}