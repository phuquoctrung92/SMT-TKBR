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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new CtrlLib.MyControls.Label();
            this.ucDateTimePicker1 = new CtrlLib.ucDateTimePicker();
            this.label6 = new CtrlLib.MyControls.Label();
            this.ucComboBox1 = new CtrlLib.MyControls.ucComboBox();
            this.label7 = new CtrlLib.MyControls.Label();
            this.btnNohinsaki_Kensaku = new CtrlLib.MyControls.BaseButton();
            this.dataGridView1 = new CtrlLib.MyControls.DataGridView();
            this.dataGridView2 = new CtrlLib.MyControls.DataGridView();
            this.btnMeisai_Kensaku = new CtrlLib.MyControls.BaseButton();
            this.label2 = new CtrlLib.MyControls.Label();
            this.btnModoru = new CtrlLib.MyControls.BaseButton();
            this.btnSentaku = new CtrlLib.MyControls.BaseButton();
            this.label3 = new CtrlLib.MyControls.Label();
            this.label4 = new CtrlLib.MyControls.Label();
            this.label5 = new CtrlLib.MyControls.Label();
            this.lblKosu_gokei = new CtrlLib.MyControls.Label();
            this.lblCBM_gokei = new CtrlLib.MyControls.Label();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(29, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "積載日";
            // 
            // ucDateTimePicker1
            // 
            this.ucDateTimePicker1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ucDateTimePicker1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDateTimePicker1.Caption = null;
            this.ucDateTimePicker1.Font = new System.Drawing.Font("MS Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ucDateTimePicker1.Location = new System.Drawing.Point(117, 93);
            this.ucDateTimePicker1.Name = "ucDateTimePicker1";
            this.ucDateTimePicker1.Size = new System.Drawing.Size(190, 36);
            this.ucDateTimePicker1.TabIndex = 11;
            this.ucDateTimePicker1.Value = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(357, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "レーン";
            // 
            // ucComboBox1
            // 
            this.ucComboBox1.Caption = null;
            this.ucComboBox1.ComboWidth = 68;
            this.ucComboBox1.CurrentIndex = 0;
            this.ucComboBox1.DropDownHeight = 106;
            this.ucComboBox1.DropDownWidth = 68;
            this.ucComboBox1.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ucComboBox1.LabelVisible = false;
            this.ucComboBox1.Location = new System.Drawing.Point(452, 93);
            this.ucComboBox1.MoveFlg = false;
            this.ucComboBox1.Name = "ucComboBox1";
            this.ucComboBox1.SelectedIndex = -1;
            this.ucComboBox1.SelectedValue = "";
            this.ucComboBox1.Size = new System.Drawing.Size(68, 32);
            this.ucComboBox1.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(6, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 17;
            this.label7.Text = "納品先名";
            // 
            // btnNohinsaki_Kensaku
            // 
            this.btnNohinsaki_Kensaku.Caption = null;
            this.btnNohinsaki_Kensaku.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNohinsaki_Kensaku.Location = new System.Drawing.Point(116, 150);
            this.btnNohinsaki_Kensaku.Name = "btnNohinsaki_Kensaku";
            this.btnNohinsaki_Kensaku.Size = new System.Drawing.Size(152, 40);
            this.btnNohinsaki_Kensaku.TabIndex = 18;
            this.btnNohinsaki_Kensaku.Text = "納品先検索";
            this.btnNohinsaki_Kensaku.UseVisualStyleBackColor = true;
            this.btnNohinsaki_Kensaku.Click += new System.EventHandler(this.btnNohinsaki_Kensaku_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataGridColumns = null;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(10, 199);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1458, 160);
            this.dataGridView1.TabIndex = 19;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.DataGridColumns = null;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Location = new System.Drawing.Point(10, 464);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1458, 300);
            this.dataGridView2.TabIndex = 22;
            // 
            // btnMeisai_Kensaku
            // 
            this.btnMeisai_Kensaku.Caption = null;
            this.btnMeisai_Kensaku.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnMeisai_Kensaku.Location = new System.Drawing.Point(117, 415);
            this.btnMeisai_Kensaku.Name = "btnMeisai_Kensaku";
            this.btnMeisai_Kensaku.Size = new System.Drawing.Size(152, 40);
            this.btnMeisai_Kensaku.TabIndex = 21;
            this.btnMeisai_Kensaku.Text = "明細検索";
            this.btnMeisai_Kensaku.UseVisualStyleBackColor = true;
            this.btnMeisai_Kensaku.Click += new System.EventHandler(this.btnMeisai_Kensaku_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(5, 430);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "明細";
            // 
            // btnModoru
            // 
            this.btnModoru.BackColor = System.Drawing.Color.White;
            this.btnModoru.Caption = null;
            this.btnModoru.Font = new System.Drawing.Font("MS Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnModoru.Location = new System.Drawing.Point(1314, 832);
            this.btnModoru.Name = "btnModoru";
            this.btnModoru.Size = new System.Drawing.Size(152, 49);
            this.btnModoru.TabIndex = 29;
            this.btnModoru.Text = "戻る";
            this.btnModoru.UseVisualStyleBackColor = false;
            this.btnModoru.Click += new System.EventHandler(this.btnModoru_Click);
            // 
            // btnSentaku
            // 
            this.btnSentaku.BackColor = System.Drawing.Color.White;
            this.btnSentaku.Caption = null;
            this.btnSentaku.Font = new System.Drawing.Font("MS Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSentaku.Location = new System.Drawing.Point(1126, 832);
            this.btnSentaku.Name = "btnSentaku";
            this.btnSentaku.Size = new System.Drawing.Size(152, 49);
            this.btnSentaku.TabIndex = 28;
            this.btnSentaku.Text = "選択";
            this.btnSentaku.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(1169, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 27);
            this.label3.TabIndex = 31;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(1170, 407);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 25);
            this.label4.TabIndex = 35;
            this.label4.Text = "個数合計";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(1311, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 25);
            this.label5.TabIndex = 36;
            this.label5.Text = "CBM合計";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKosu_gokei
            // 
            this.lblKosu_gokei.BackColor = System.Drawing.Color.White;
            this.lblKosu_gokei.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblKosu_gokei.Location = new System.Drawing.Point(1170, 439);
            this.lblKosu_gokei.Name = "lblKosu_gokei";
            this.lblKosu_gokei.Size = new System.Drawing.Size(139, 25);
            this.lblKosu_gokei.TabIndex = 37;
            this.lblKosu_gokei.Text = "label8";
            this.lblKosu_gokei.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCBM_gokei
            // 
            this.lblCBM_gokei.BackColor = System.Drawing.Color.White;
            this.lblCBM_gokei.Font = new System.Drawing.Font("MS Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCBM_gokei.Location = new System.Drawing.Point(1310, 439);
            this.lblCBM_gokei.Name = "lblCBM_gokei";
            this.lblCBM_gokei.Size = new System.Drawing.Size(139, 25);
            this.lblCBM_gokei.TabIndex = 38;
            this.lblCBM_gokei.Text = "label9";
            this.lblCBM_gokei.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmShiwakeToroku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMinSize = new System.Drawing.Size(0, 20);
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(1478, 921);
            this.Controls.Add(this.lblCBM_gokei);
            this.Controls.Add(this.lblKosu_gokei);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnModoru);
            this.Controls.Add(this.btnSentaku);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnMeisai_Kensaku);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnNohinsaki_Kensaku);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ucComboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ucDateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "frmShiwakeToroku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShiwakeToroku";
            this.Load += new System.EventHandler(this.frmShiwakeToroku_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.ucDateTimePicker1, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.ucComboBox1, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.btnNohinsaki_Kensaku, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnMeisai_Kensaku, 0);
            this.Controls.SetChildIndex(this.dataGridView2, 0);
            this.Controls.SetChildIndex(this.btnSentaku, 0);
            this.Controls.SetChildIndex(this.btnModoru, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.pnHeader, 0);
            this.Controls.SetChildIndex(this.ucFunction1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.lblKosu_gokei, 0);
            this.Controls.SetChildIndex(this.lblCBM_gokei, 0);
            this.pnHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtrlLib.MyControls.Label label1;
        private CtrlLib.ucDateTimePicker ucDateTimePicker1;
        private CtrlLib.MyControls.Label label6;
        private CtrlLib.MyControls.ucComboBox ucComboBox1;
        private CtrlLib.MyControls.Label label7;
        private CtrlLib.MyControls.BaseButton btnNohinsaki_Kensaku;
        private CtrlLib.MyControls.DataGridView dataGridView1;
        private CtrlLib.MyControls.DataGridView dataGridView2;
        private CtrlLib.MyControls.BaseButton btnMeisai_Kensaku;
        private CtrlLib.MyControls.Label label2;
        private CtrlLib.MyControls.BaseButton btnModoru;
        private CtrlLib.MyControls.BaseButton btnSentaku;
        private CtrlLib.MyControls.Label label3;
        private CtrlLib.MyControls.Label label4;
        private CtrlLib.MyControls.Label label5;
        private CtrlLib.MyControls.Label lblKosu_gokei;
        private CtrlLib.MyControls.Label lblCBM_gokei;
    }
}