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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new CtrlLib.MyControls.Label();
            this.label3 = new CtrlLib.MyControls.Label();
            this.label4 = new CtrlLib.MyControls.Label();
            this.label6 = new CtrlLib.MyControls.Label();
            this.label7 = new CtrlLib.MyControls.Label();
            this.txtNohinsakimei = new CtrlLib.MyControls.StringBox();
            this.label9 = new CtrlLib.MyControls.Label();
            this.ucComboBox1 = new CtrlLib.MyControls.ucComboBox();
            this.btnKensaku = new CtrlLib.MyControls.BaseButton();
            this.dataGridView1 = new CtrlLib.MyControls.DataGridView();
            this.btnSentaku = new CtrlLib.MyControls.BaseButton();
            this.btnModoru = new CtrlLib.MyControls.BaseButton();
            this.pnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.label1.TabIndex = 9;
            this.label1.Text = "積載日";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(117, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 33);
            this.label3.TabIndex = 11;
            this.label3.Text = "2025/08/29";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(445, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 33);
            this.label4.TabIndex = 14;
            this.label4.Text = "3";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(357, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "レーン";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(5, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 15;
            this.label7.Text = "納品先名";
            // 
            // txtNohinsakimei
            // 
            this.txtNohinsakimei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNohinsakimei.Caption = null;
            this.txtNohinsakimei.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtNohinsakimei.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtNohinsakimei.InputPattern = CtrlLib.MyControls.InputPatterns.All;
            this.txtNohinsakimei.Location = new System.Drawing.Point(117, 159);
            this.txtNohinsakimei.Name = "txtNohinsakimei";
            this.txtNohinsakimei.PasteType = CtrlLib.MyControls.PasteTypes.Control;
            this.txtNohinsakimei.Size = new System.Drawing.Size(498, 33);
            this.txtNohinsakimei.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(726, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 24);
            this.label9.TabIndex = 18;
            this.label9.Text = "都道府県";
            // 
            // ucComboBox1
            // 
            this.ucComboBox1.Caption = null;
            this.ucComboBox1.ComboWidth = 138;
            this.ucComboBox1.CurrentIndex = 0;
            this.ucComboBox1.DropDownHeight = 106;
            this.ucComboBox1.DropDownWidth = 138;
            this.ucComboBox1.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ucComboBox1.LabelVisible = false;
            this.ucComboBox1.Location = new System.Drawing.Point(840, 161);
            this.ucComboBox1.MoveFlg = false;
            this.ucComboBox1.Name = "ucComboBox1";
            this.ucComboBox1.SelectedIndex = -1;
            this.ucComboBox1.SelectedValue = "";
            this.ucComboBox1.Size = new System.Drawing.Size(138, 32);
            this.ucComboBox1.TabIndex = 20;
            this.ucComboBox1.SelectedValueChanged += new CtrlLib.MyControls.ucComboBox.SelectedValueChangedEventHandler(this.ucComboBox1_SelectedValueChanged);
            // 
            // btnKensaku
            // 
            this.btnKensaku.BackColor = System.Drawing.Color.White;
            this.btnKensaku.Caption = null;
            this.btnKensaku.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnKensaku.Location = new System.Drawing.Point(1018, 153);
            this.btnKensaku.Name = "btnKensaku";
            this.btnKensaku.Size = new System.Drawing.Size(152, 40);
            this.btnKensaku.TabIndex = 22;
            this.btnKensaku.Text = "検索";
            this.btnKensaku.UseVisualStyleBackColor = false;
            this.btnKensaku.Click += new System.EventHandler(this.btnKensaku_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("MS Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(204)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("MS Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.DataGridColumns = null;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("MS Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridView1.Location = new System.Drawing.Point(10, 216);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("MS Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1458, 576);
            this.dataGridView1.TabIndex = 23;
            // 
            // btnSentaku
            // 
            this.btnSentaku.BackColor = System.Drawing.Color.White;
            this.btnSentaku.Caption = null;
            this.btnSentaku.Font = new System.Drawing.Font("MS Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSentaku.Location = new System.Drawing.Point(1126, 832);
            this.btnSentaku.Name = "btnSentaku";
            this.btnSentaku.Size = new System.Drawing.Size(152, 49);
            this.btnSentaku.TabIndex = 25;
            this.btnSentaku.Text = "選択";
            this.btnSentaku.UseVisualStyleBackColor = false;
            this.btnSentaku.Click += new System.EventHandler(this.btnSentaku_Click);
            // 
            // btnModoru
            // 
            this.btnModoru.BackColor = System.Drawing.Color.White;
            this.btnModoru.Caption = null;
            this.btnModoru.Font = new System.Drawing.Font("MS Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnModoru.Location = new System.Drawing.Point(1294, 832);
            this.btnModoru.Name = "btnModoru";
            this.btnModoru.Size = new System.Drawing.Size(152, 49);
            this.btnModoru.TabIndex = 27;
            this.btnModoru.Text = "戻る";
            this.btnModoru.UseVisualStyleBackColor = false;
            this.btnModoru.Click += new System.EventHandler(this.btnModoru_Click);
            // 
            // frmNohinSakiSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 921);
            this.Controls.Add(this.btnModoru);
            this.Controls.Add(this.btnSentaku);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnKensaku);
            this.Controls.Add(this.ucComboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNohinsakimei);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmNohinSakiSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNohinkensaku";
            this.Load += new System.EventHandler(this.frmNohinSakiSearch_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtNohinsakimei, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.ucComboBox1, 0);
            this.Controls.SetChildIndex(this.btnKensaku, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.btnSentaku, 0);
            this.Controls.SetChildIndex(this.btnModoru, 0);
            this.Controls.SetChildIndex(this.pnHeader, 0);
            this.Controls.SetChildIndex(this.ucFunction1, 0);
            this.pnHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CtrlLib.MyControls.Label label1;
        private CtrlLib.MyControls.Label label3;
        private CtrlLib.MyControls.Label label4;
        private CtrlLib.MyControls.Label label6;
        private CtrlLib.MyControls.Label label7;
        private CtrlLib.MyControls.StringBox txtNohinsakimei;
        private CtrlLib.MyControls.Label label9;
        private CtrlLib.MyControls.ucComboBox ucComboBox1;
        private CtrlLib.MyControls.BaseButton btnKensaku;
        private CtrlLib.MyControls.DataGridView dataGridView1;
        private CtrlLib.MyControls.BaseButton btnSentaku;
        private CtrlLib.MyControls.BaseButton btnModoru;
    }
}