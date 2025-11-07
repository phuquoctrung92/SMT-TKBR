namespace TKBR_Lib.Forms.明細検索
{
    partial class frmMeisaiKensaku
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
            this.label1 = new CtrlLib.MyControls.Label();
            this.label2 = new CtrlLib.MyControls.Label();
            this.label3 = new CtrlLib.MyControls.Label();
            this.label5 = new CtrlLib.MyControls.Label();
            this.dgvNohinsaki = new CtrlLib.MyControls.DataGridView();
            this.btnNohinsakiSelectAll = new CtrlLib.MyControls.BaseButton();
            this.dgvMeisai = new CtrlLib.MyControls.DataGridView();
            this.label6 = new CtrlLib.MyControls.Label();
            this.btnMeisaiSelectAll = new CtrlLib.MyControls.BaseButton();
            this.btnMeisaiKaijoAll = new CtrlLib.MyControls.BaseButton();
            this.btnModoru = new CtrlLib.MyControls.BaseButton();
            this.btnToroku = new CtrlLib.MyControls.BaseButton();
            this.lblSekisaiDate = new CtrlLib.MyControls.Label();
            this.label4 = new CtrlLib.MyControls.Label();
            this.label7 = new CtrlLib.MyControls.Label();
            this.label9 = new CtrlLib.MyControls.Label();
            this.lblKosuGokei = new CtrlLib.MyControls.Label();
            this.label13 = new CtrlLib.MyControls.Label();
            this.lblCBMGokei = new CtrlLib.MyControls.Label();
            this.label15 = new CtrlLib.MyControls.Label();
            this.lblMeisaisu = new CtrlLib.MyControls.Label();
            this.label12 = new CtrlLib.MyControls.Label();
            this.label8 = new CtrlLib.MyControls.Label();
            this.lblRen = new CtrlLib.MyControls.Label();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNohinsaki)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeisai)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.Size = new System.Drawing.Size(1534, 45);
            // 
            // lblScreenName
            // 
            this.lblScreenName.Size = new System.Drawing.Size(1534, 45);
            // 
            // ucFunction1
            // 
            this.ucFunction1.Location = new System.Drawing.Point(0, 900);
            this.ucFunction1.Size = new System.Drawing.Size(1534, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label1.Location = new System.Drawing.Point(12, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "積載日";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label2.Location = new System.Drawing.Point(116, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 35);
            this.label2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label3.Location = new System.Drawing.Point(344, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "レーン";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label5.Location = new System.Drawing.Point(12, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "納品先";
            // 
            // dgvNohinsaki
            // 
            this.dgvNohinsaki.BackgroundColor = System.Drawing.Color.White;
            this.dgvNohinsaki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNohinsaki.DataGridColumns = null;
            this.dgvNohinsaki.Location = new System.Drawing.Point(12, 165);
            this.dgvNohinsaki.Name = "dgvNohinsaki";
            this.dgvNohinsaki.RowTemplate.Height = 21;
            this.dgvNohinsaki.Size = new System.Drawing.Size(1510, 181);
            this.dgvNohinsaki.TabIndex = 14;
            this.dgvNohinsaki.SelectionChanged += new System.EventHandler(this.dgvNohinsaki_SelectionChanged);
            // 
            // btnNohinsakiSelectAll
            // 
            this.btnNohinsakiSelectAll.Caption = null;
            this.btnNohinsakiSelectAll.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnNohinsakiSelectAll.Location = new System.Drawing.Point(1371, 119);
            this.btnNohinsakiSelectAll.Name = "btnNohinsakiSelectAll";
            this.btnNohinsakiSelectAll.Size = new System.Drawing.Size(152, 40);
            this.btnNohinsakiSelectAll.TabIndex = 110;
            this.btnNohinsakiSelectAll.Text = "全て表示";
            this.btnNohinsakiSelectAll.UseVisualStyleBackColor = true;
            this.btnNohinsakiSelectAll.Click += new System.EventHandler(this.btnNohinsakiSelectAll_Click);
            // 
            // dgvMeisai
            // 
            this.dgvMeisai.BackgroundColor = System.Drawing.Color.White;
            this.dgvMeisai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeisai.DataGridColumns = null;
            this.dgvMeisai.Location = new System.Drawing.Point(12, 434);
            this.dgvMeisai.Name = "dgvMeisai";
            this.dgvMeisai.RowTemplate.Height = 21;
            this.dgvMeisai.Size = new System.Drawing.Size(1510, 372);
            this.dgvMeisai.TabIndex = 112;
            this.dgvMeisai.SelectionChanged += new System.EventHandler(this.dgvMeisai_SelectionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label6.Location = new System.Drawing.Point(12, 407);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 24);
            this.label6.TabIndex = 111;
            this.label6.Text = "明細";
            // 
            // btnMeisaiSelectAll
            // 
            this.btnMeisaiSelectAll.Caption = null;
            this.btnMeisaiSelectAll.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnMeisaiSelectAll.Location = new System.Drawing.Point(115, 388);
            this.btnMeisaiSelectAll.Name = "btnMeisaiSelectAll";
            this.btnMeisaiSelectAll.Size = new System.Drawing.Size(152, 40);
            this.btnMeisaiSelectAll.TabIndex = 113;
            this.btnMeisaiSelectAll.Text = "全て選択";
            this.btnMeisaiSelectAll.UseVisualStyleBackColor = true;
            this.btnMeisaiSelectAll.Click += new System.EventHandler(this.btnMeisaiSelectAll_Click);
            // 
            // btnMeisaiKaijoAll
            // 
            this.btnMeisaiKaijoAll.Caption = null;
            this.btnMeisaiKaijoAll.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnMeisaiKaijoAll.Location = new System.Drawing.Point(273, 388);
            this.btnMeisaiKaijoAll.Name = "btnMeisaiKaijoAll";
            this.btnMeisaiKaijoAll.Size = new System.Drawing.Size(152, 40);
            this.btnMeisaiKaijoAll.TabIndex = 114;
            this.btnMeisaiKaijoAll.Text = "全て解除";
            this.btnMeisaiKaijoAll.UseVisualStyleBackColor = true;
            this.btnMeisaiKaijoAll.Click += new System.EventHandler(this.btnMeisaiKaijoAll_Click);
            // 
            // btnModoru
            // 
            this.btnModoru.Caption = null;
            this.btnModoru.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnModoru.Location = new System.Drawing.Point(1371, 821);
            this.btnModoru.Name = "btnModoru";
            this.btnModoru.Size = new System.Drawing.Size(152, 49);
            this.btnModoru.TabIndex = 115;
            this.btnModoru.Text = "戻る";
            this.btnModoru.UseVisualStyleBackColor = true;
            this.btnModoru.Click += new System.EventHandler(this.btnModoru_Click);
            // 
            // btnToroku
            // 
            this.btnToroku.Caption = null;
            this.btnToroku.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.btnToroku.Location = new System.Drawing.Point(1213, 821);
            this.btnToroku.Name = "btnToroku";
            this.btnToroku.Size = new System.Drawing.Size(152, 49);
            this.btnToroku.TabIndex = 116;
            this.btnToroku.Text = "登録";
            this.btnToroku.UseVisualStyleBackColor = true;
            // 
            // lblSekisaiDate
            // 
            this.lblSekisaiDate.BackColor = System.Drawing.Color.Yellow;
            this.lblSekisaiDate.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.lblSekisaiDate.Location = new System.Drawing.Point(117, 77);
            this.lblSekisaiDate.Name = "lblSekisaiDate";
            this.lblSekisaiDate.Size = new System.Drawing.Size(153, 33);
            this.lblSekisaiDate.TabIndex = 117;
            this.lblSekisaiDate.Text = "2025/08/29";
            this.lblSekisaiDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label4.Location = new System.Drawing.Point(1109, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 24);
            this.label4.TabIndex = 120;
            this.label4.Text = "明細数";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label7.Location = new System.Drawing.Point(1247, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 121;
            this.label7.Text = "個数合計";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label9.Location = new System.Drawing.Point(1400, 370);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 24);
            this.label9.TabIndex = 122;
            this.label9.Text = "CBM合計";
            // 
            // lblKosuGokei
            // 
            this.lblKosuGokei.BackColor = System.Drawing.Color.White;
            this.lblKosuGokei.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.lblKosuGokei.Location = new System.Drawing.Point(1221, 401);
            this.lblKosuGokei.Name = "lblKosuGokei";
            this.lblKosuGokei.Size = new System.Drawing.Size(149, 33);
            this.lblKosuGokei.TabIndex = 126;
            this.lblKosuGokei.Text = "0";
            this.lblKosuGokei.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label13.Location = new System.Drawing.Point(1220, 400);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 34);
            this.label13.TabIndex = 125;
            // 
            // lblCBMGokei
            // 
            this.lblCBMGokei.BackColor = System.Drawing.Color.White;
            this.lblCBMGokei.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.lblCBMGokei.Location = new System.Drawing.Point(1371, 401);
            this.lblCBMGokei.Name = "lblCBMGokei";
            this.lblCBMGokei.Size = new System.Drawing.Size(150, 33);
            this.lblCBMGokei.TabIndex = 128;
            this.lblCBMGokei.Text = "0";
            this.lblCBMGokei.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label15.Location = new System.Drawing.Point(1370, 400);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(152, 34);
            this.label15.TabIndex = 127;
            // 
            // lblMeisaisu
            // 
            this.lblMeisaisu.BackColor = System.Drawing.Color.White;
            this.lblMeisaisu.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.lblMeisaisu.Location = new System.Drawing.Point(1071, 401);
            this.lblMeisaisu.Name = "lblMeisaisu";
            this.lblMeisaisu.Size = new System.Drawing.Size(149, 33);
            this.lblMeisaisu.TabIndex = 130;
            this.lblMeisaisu.Text = "0";
            this.lblMeisaisu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label12.Location = new System.Drawing.Point(1070, 400);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 34);
            this.label12.TabIndex = 129;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.label8.Location = new System.Drawing.Point(451, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 35);
            this.label8.TabIndex = 118;
            // 
            // lblRen
            // 
            this.lblRen.BackColor = System.Drawing.Color.Yellow;
            this.lblRen.Font = new System.Drawing.Font("MS Gothic", 18F);
            this.lblRen.Location = new System.Drawing.Point(452, 77);
            this.lblRen.Name = "lblRen";
            this.lblRen.Size = new System.Drawing.Size(153, 33);
            this.lblRen.TabIndex = 119;
            this.lblRen.Text = "3";
            this.lblRen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMeisaiKensaku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 923);
            this.Controls.Add(this.lblMeisaisu);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblCBMGokei);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblKosuGokei);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblRen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSekisaiDate);
            this.Controls.Add(this.btnToroku);
            this.Controls.Add(this.btnModoru);
            this.Controls.Add(this.btnMeisaiKaijoAll);
            this.Controls.Add(this.btnMeisaiSelectAll);
            this.Controls.Add(this.dgvMeisai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnNohinsakiSelectAll);
            this.Controls.Add(this.dgvNohinsaki);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmMeisaiKensaku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMeisaiKensaku";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.dgvNohinsaki, 0);
            this.Controls.SetChildIndex(this.btnNohinsakiSelectAll, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.dgvMeisai, 0);
            this.Controls.SetChildIndex(this.btnMeisaiSelectAll, 0);
            this.Controls.SetChildIndex(this.btnMeisaiKaijoAll, 0);
            this.Controls.SetChildIndex(this.btnModoru, 0);
            this.Controls.SetChildIndex(this.btnToroku, 0);
            this.Controls.SetChildIndex(this.lblSekisaiDate, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.lblRen, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.lblKosuGokei, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.lblCBMGokei, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.lblMeisaisu, 0);
            this.Controls.SetChildIndex(this.pnHeader, 0);
            this.Controls.SetChildIndex(this.ucFunction1, 0);
            this.pnHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNohinsaki)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeisai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtrlLib.MyControls.Label label1;
        private CtrlLib.MyControls.Label label2;
        private CtrlLib.MyControls.Label label3;
        private CtrlLib.MyControls.Label label5;
        private CtrlLib.MyControls.DataGridView dgvNohinsaki;
        private CtrlLib.MyControls.BaseButton btnNohinsakiSelectAll;
        private CtrlLib.MyControls.DataGridView dgvMeisai;
        private CtrlLib.MyControls.Label label6;
        private CtrlLib.MyControls.BaseButton btnMeisaiSelectAll;
        private CtrlLib.MyControls.BaseButton btnMeisaiKaijoAll;
        private CtrlLib.MyControls.BaseButton btnModoru;
        private CtrlLib.MyControls.BaseButton btnToroku;
        private CtrlLib.MyControls.Label lblSekisaiDate;
        private CtrlLib.MyControls.Label label4;
        private CtrlLib.MyControls.Label label7;
        private CtrlLib.MyControls.Label label9;
        private CtrlLib.MyControls.Label lblKosuGokei;
        private CtrlLib.MyControls.Label label13;
        private CtrlLib.MyControls.Label lblCBMGokei;
        private CtrlLib.MyControls.Label label15;
        private CtrlLib.MyControls.Label lblMeisaisu;
        private CtrlLib.MyControls.Label label12;
        private CtrlLib.MyControls.Label label8;
        private CtrlLib.MyControls.Label lblRen;
    }
}