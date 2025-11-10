namespace TKBR_Lib.Forms
{
    partial class frmShiwakeToroku
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
            this.label3 = new CtrlLib.MyControls.Label();
            this.label1 = new CtrlLib.MyControls.Label();
            this.dateSekisaiPicker = new CtrlLib.ucDateTimePicker();
            this.cbbRen = new CtrlLib.MyControls.ucComboBox();
            this.dgvNohinsaki = new CtrlLib.MyControls.DataGridView();
            this.label5 = new CtrlLib.MyControls.Label();
            this.btnNohinsakiKensaku = new CtrlLib.MyControls.BaseButton();
            this.lblCBMGokei = new CtrlLib.MyControls.Label();
            this.label15 = new CtrlLib.MyControls.Label();
            this.lblKosuGokei = new CtrlLib.MyControls.Label();
            this.label13 = new CtrlLib.MyControls.Label();
            this.label9 = new CtrlLib.MyControls.Label();
            this.label7 = new CtrlLib.MyControls.Label();
            this.btnMeisaiKensaku = new CtrlLib.MyControls.BaseButton();
            this.dgvMeisai = new CtrlLib.MyControls.DataGridView();
            this.label6 = new CtrlLib.MyControls.Label();
            this.btnToroku = new CtrlLib.MyControls.BaseButton();
            this.btnModoru = new CtrlLib.MyControls.BaseButton();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNohinsaki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeisai)).BeginInit();
            this.SuspendLayout();
            // 
            // ucFunction1
            // 
            this.ucFunction1.Location = new System.Drawing.Point(0, 900);
            this.ucFunction1.Size = new System.Drawing.Size(1534, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label3.Location = new System.Drawing.Point(360, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 122;
            this.label3.Text = "レーン";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label1.Location = new System.Drawing.Point(28, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 120;
            this.label1.Text = "積載日";
            // 
            // dateSekisaiPicker
            // 
            this.dateSekisaiPicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateSekisaiPicker.Caption = "積載日";
            this.dateSekisaiPicker.Font = new System.Drawing.Font("MS Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dateSekisaiPicker.Location = new System.Drawing.Point(132, 60);
            this.dateSekisaiPicker.Name = "dateSekisaiPicker";
            this.dateSekisaiPicker.Size = new System.Drawing.Size(190, 36);
            this.dateSekisaiPicker.TabIndex = 0;
            this.dateSekisaiPicker.Value = new System.DateTime(2025, 8, 29, 0, 0, 0, 0);
            // 
            // cbbRen
            // 
            this.cbbRen.Caption = "レーン";
            this.cbbRen.ComboWidth = 96;
            this.cbbRen.CurrentIndex = 0;
            this.cbbRen.DropDownHeight = 106;
            this.cbbRen.DropDownWidth = 96;
            this.cbbRen.Font = new System.Drawing.Font("MS Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cbbRen.LabelVisible = false;
            this.cbbRen.Location = new System.Drawing.Point(467, 60);
            this.cbbRen.MoveFlg = false;
            this.cbbRen.Name = "cbbRen";
            this.cbbRen.SelectedIndex = -1;
            this.cbbRen.SelectedValue = "";
            this.cbbRen.Size = new System.Drawing.Size(96, 35);
            this.cbbRen.TabIndex = 1;
            // 
            // dgvNohinsaki
            // 
            this.dgvNohinsaki.BackgroundColor = System.Drawing.Color.White;
            this.dgvNohinsaki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNohinsaki.DataGridColumns = null;
            this.dgvNohinsaki.Location = new System.Drawing.Point(28, 158);
            this.dgvNohinsaki.Name = "dgvNohinsaki";
            this.dgvNohinsaki.ReadOnly = true;
            this.dgvNohinsaki.RowTemplate.Height = 21;
            this.dgvNohinsaki.Size = new System.Drawing.Size(1478, 196);
            this.dgvNohinsaki.TabIndex = 134;
            this.dgvNohinsaki.TabStop = false;
            this.dgvNohinsaki.DataSourceChanged += new System.EventHandler(this.dgvNohinsaki_DataSourceChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label5.Location = new System.Drawing.Point(28, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 133;
            this.label5.Text = "納品先";
            // 
            // btnNohinsakiKensaku
            // 
            this.btnNohinsakiKensaku.Caption = null;
            this.btnNohinsakiKensaku.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnNohinsakiKensaku.Location = new System.Drawing.Point(132, 111);
            this.btnNohinsakiKensaku.Name = "btnNohinsakiKensaku";
            this.btnNohinsakiKensaku.Size = new System.Drawing.Size(190, 40);
            this.btnNohinsakiKensaku.TabIndex = 2;
            this.btnNohinsakiKensaku.Text = "納品先検索";
            this.btnNohinsakiKensaku.UseVisualStyleBackColor = true;
            this.btnNohinsakiKensaku.Click += new System.EventHandler(this.btnNohinsakiKensaku_Click);
            // 
            // lblCBMGokei
            // 
            this.lblCBMGokei.BackColor = System.Drawing.Color.White;
            this.lblCBMGokei.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.lblCBMGokei.Location = new System.Drawing.Point(1355, 409);
            this.lblCBMGokei.Name = "lblCBMGokei";
            this.lblCBMGokei.Size = new System.Drawing.Size(150, 33);
            this.lblCBMGokei.TabIndex = 146;
            this.lblCBMGokei.Text = "0";
            this.lblCBMGokei.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label15.Location = new System.Drawing.Point(1354, 408);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(152, 34);
            this.label15.TabIndex = 145;
            // 
            // lblKosuGokei
            // 
            this.lblKosuGokei.BackColor = System.Drawing.Color.White;
            this.lblKosuGokei.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.lblKosuGokei.Location = new System.Drawing.Point(1205, 409);
            this.lblKosuGokei.Name = "lblKosuGokei";
            this.lblKosuGokei.Size = new System.Drawing.Size(149, 33);
            this.lblKosuGokei.TabIndex = 144;
            this.lblKosuGokei.Text = "0";
            this.lblKosuGokei.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label13.Location = new System.Drawing.Point(1204, 408);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 34);
            this.label13.TabIndex = 143;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label9.Location = new System.Drawing.Point(1384, 378);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 24);
            this.label9.TabIndex = 142;
            this.label9.Text = "CBM合計";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label7.Location = new System.Drawing.Point(1231, 378);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 141;
            this.label7.Text = "個数合計";
            // 
            // btnMeisaiKensaku
            // 
            this.btnMeisaiKensaku.Caption = null;
            this.btnMeisaiKensaku.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnMeisaiKensaku.Location = new System.Drawing.Point(131, 396);
            this.btnMeisaiKensaku.Name = "btnMeisaiKensaku";
            this.btnMeisaiKensaku.Size = new System.Drawing.Size(190, 40);
            this.btnMeisaiKensaku.TabIndex = 3;
            this.btnMeisaiKensaku.Text = "明細検索";
            this.btnMeisaiKensaku.UseVisualStyleBackColor = true;
            this.btnMeisaiKensaku.Click += new System.EventHandler(this.btnMeisaiKensaku_Click);
            // 
            // dgvMeisai
            // 
            this.dgvMeisai.BackgroundColor = System.Drawing.Color.White;
            this.dgvMeisai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeisai.DataGridColumns = null;
            this.dgvMeisai.Location = new System.Drawing.Point(28, 442);
            this.dgvMeisai.Name = "dgvMeisai";
            this.dgvMeisai.RowTemplate.Height = 21;
            this.dgvMeisai.Size = new System.Drawing.Size(1478, 372);
            this.dgvMeisai.TabIndex = 137;
            this.dgvMeisai.TabStop = false;
            this.dgvMeisai.DataSourceChanged += new System.EventHandler(this.dgvMeisai_DataSourceChanged);
            this.dgvMeisai.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeisai_CellValueChanged);
            this.dgvMeisai.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvMeisai_EditingControlShowing);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label6.Location = new System.Drawing.Point(28, 415);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 24);
            this.label6.TabIndex = 136;
            this.label6.Text = "明細";
            // 
            // btnToroku
            // 
            this.btnToroku.Caption = null;
            this.btnToroku.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnToroku.Location = new System.Drawing.Point(1141, 832);
            this.btnToroku.Name = "btnToroku";
            this.btnToroku.Size = new System.Drawing.Size(180, 60);
            this.btnToroku.TabIndex = 4;
            this.btnToroku.Text = "登録";
            this.btnToroku.UseVisualStyleBackColor = true;
            // 
            // btnModoru
            // 
            this.btnModoru.Caption = null;
            this.btnModoru.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnModoru.Location = new System.Drawing.Point(1327, 832);
            this.btnModoru.Name = "btnModoru";
            this.btnModoru.Size = new System.Drawing.Size(180, 60);
            this.btnModoru.TabIndex = 5;
            this.btnModoru.Text = "戻る";
            this.btnModoru.UseVisualStyleBackColor = true;
            this.btnModoru.Click += new System.EventHandler(this.btnModoru_Click);
            // 
            // frmShiwakeToroku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 923);
            this.Controls.Add(this.btnToroku);
            this.Controls.Add(this.btnModoru);
            this.Controls.Add(this.lblCBMGokei);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblKosuGokei);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnMeisaiKensaku);
            this.Controls.Add(this.dgvMeisai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnNohinsakiKensaku);
            this.Controls.Add(this.dgvNohinsaki);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbbRen);
            this.Controls.Add(this.dateSekisaiPicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmShiwakeToroku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShiwakeToroku";
            this.Controls.SetChildIndex(this.pnHeader, 0);
            this.Controls.SetChildIndex(this.ucFunction1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dateSekisaiPicker, 0);
            this.Controls.SetChildIndex(this.cbbRen, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.dgvNohinsaki, 0);
            this.Controls.SetChildIndex(this.btnNohinsakiKensaku, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.dgvMeisai, 0);
            this.Controls.SetChildIndex(this.btnMeisaiKensaku, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.lblKosuGokei, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.lblCBMGokei, 0);
            this.Controls.SetChildIndex(this.btnModoru, 0);
            this.Controls.SetChildIndex(this.btnToroku, 0);
            this.pnHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNohinsaki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeisai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CtrlLib.MyControls.Label label3;
        private CtrlLib.MyControls.Label label1;
        private CtrlLib.ucDateTimePicker dateSekisaiPicker;
        private CtrlLib.MyControls.ucComboBox cbbRen;
        private CtrlLib.MyControls.DataGridView dgvNohinsaki;
        private CtrlLib.MyControls.Label label5;
        private CtrlLib.MyControls.BaseButton btnNohinsakiKensaku;
        private CtrlLib.MyControls.Label lblCBMGokei;
        private CtrlLib.MyControls.Label label15;
        private CtrlLib.MyControls.Label lblKosuGokei;
        private CtrlLib.MyControls.Label label13;
        private CtrlLib.MyControls.Label label9;
        private CtrlLib.MyControls.Label label7;
        private CtrlLib.MyControls.BaseButton btnMeisaiKensaku;
        private CtrlLib.MyControls.DataGridView dgvMeisai;
        private CtrlLib.MyControls.Label label6;
        private CtrlLib.MyControls.BaseButton btnToroku;
        private CtrlLib.MyControls.BaseButton btnModoru;
    }
}