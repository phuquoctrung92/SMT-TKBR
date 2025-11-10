namespace TKBR_Lib.Forms
{
    partial class frmMenu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvList = new CtrlLib.MyControls.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubCase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baseButton1 = new CtrlLib.MyControls.BaseButton();
            this.baseButton2 = new CtrlLib.MyControls.BaseButton();
            this.baseButton3 = new CtrlLib.MyControls.BaseButton();
            this.baseButton4 = new CtrlLib.MyControls.BaseButton();
            this.baseButton10 = new CtrlLib.MyControls.BaseButton();
            this.baseButton6 = new CtrlLib.MyControls.BaseButton();
            this.baseButton5 = new CtrlLib.MyControls.BaseButton();
            this.baseButton7 = new CtrlLib.MyControls.BaseButton();
            this.pnHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // ucFunction1
            // 
            this.ucFunction1.Location = new System.Drawing.Point(0, 900);
            this.ucFunction1.Size = new System.Drawing.Size(1478, 0);
            this.ucFunction1.TabIndex = 99;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvList);
            this.panel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            this.panel1.Location = new System.Drawing.Point(0, 133);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 5);
            this.panel1.Size = new System.Drawing.Size(1143, 767);
            this.panel1.TabIndex = 107;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeight = 60;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colSubCase,
            this.colDataType,
            this.colStatus});
            this.dgvList.DataGridColumns = null;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvList.Location = new System.Drawing.Point(10, 0);
            this.dgvList.Name = "dgvList";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvList.RowTemplate.Height = 40;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(1123, 762);
            this.dgvList.TabIndex = 0;
            // 
            // colNo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.colNo.HeaderText = "";
            this.colNo.MinimumWidth = 50;
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Width = 50;
            // 
            // colSubCase
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colSubCase.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSubCase.HeaderText = "処理日";
            this.colSubCase.MinimumWidth = 150;
            this.colSubCase.Name = "colSubCase";
            this.colSubCase.ReadOnly = true;
            this.colSubCase.Width = 150;
            // 
            // colDataType
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDataType.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDataType.HeaderText = "バッチNo";
            this.colDataType.MinimumWidth = 140;
            this.colDataType.Name = "colDataType";
            this.colDataType.ReadOnly = true;
            this.colDataType.Width = 140;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colStatus.HeaderText = "作業状況";
            this.colStatus.MinimumWidth = 140;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 140;
            // 
            // baseButton1
            // 
            this.baseButton1.Caption = null;
            this.baseButton1.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            this.baseButton1.Location = new System.Drawing.Point(1167, 154);
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.Size = new System.Drawing.Size(299, 49);
            this.baseButton1.TabIndex = 108;
            this.baseButton1.Text = "baseButton1";
            this.baseButton1.UseVisualStyleBackColor = true;
            // 
            // baseButton2
            // 
            this.baseButton2.Caption = null;
            this.baseButton2.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            this.baseButton2.Location = new System.Drawing.Point(1167, 231);
            this.baseButton2.Name = "baseButton2";
            this.baseButton2.Size = new System.Drawing.Size(299, 49);
            this.baseButton2.TabIndex = 109;
            this.baseButton2.Text = "baseButton2";
            this.baseButton2.UseVisualStyleBackColor = true;
            // 
            // baseButton3
            // 
            this.baseButton3.Caption = null;
            this.baseButton3.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            this.baseButton3.Location = new System.Drawing.Point(1167, 308);
            this.baseButton3.Name = "baseButton3";
            this.baseButton3.Size = new System.Drawing.Size(299, 49);
            this.baseButton3.TabIndex = 110;
            this.baseButton3.Text = "baseButton3";
            this.baseButton3.UseVisualStyleBackColor = true;
            // 
            // baseButton4
            // 
            this.baseButton4.Caption = null;
            this.baseButton4.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            this.baseButton4.Location = new System.Drawing.Point(1167, 385);
            this.baseButton4.Name = "baseButton4";
            this.baseButton4.Size = new System.Drawing.Size(299, 49);
            this.baseButton4.TabIndex = 111;
            this.baseButton4.Text = "baseButton4";
            this.baseButton4.UseVisualStyleBackColor = true;
            // 
            // baseButton10
            // 
            this.baseButton10.Caption = null;
            this.baseButton10.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            this.baseButton10.Location = new System.Drawing.Point(1167, 843);
            this.baseButton10.Name = "baseButton10";
            this.baseButton10.Size = new System.Drawing.Size(299, 49);
            this.baseButton10.TabIndex = 116;
            this.baseButton10.Text = "baseButton10";
            this.baseButton10.UseVisualStyleBackColor = true;
            // 
            // baseButton6
            // 
            this.baseButton6.Caption = null;
            this.baseButton6.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            this.baseButton6.Location = new System.Drawing.Point(1167, 539);
            this.baseButton6.Name = "baseButton6";
            this.baseButton6.Size = new System.Drawing.Size(299, 49);
            this.baseButton6.TabIndex = 117;
            this.baseButton6.Text = "baseButton6";
            this.baseButton6.UseVisualStyleBackColor = true;
            // 
            // baseButton5
            // 
            this.baseButton5.Caption = null;
            this.baseButton5.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            this.baseButton5.Location = new System.Drawing.Point(1167, 462);
            this.baseButton5.Name = "baseButton5";
            this.baseButton5.Size = new System.Drawing.Size(299, 49);
            this.baseButton5.TabIndex = 111;
            this.baseButton5.Text = "baseButton5";
            this.baseButton5.UseVisualStyleBackColor = true;
            // 
            // baseButton7
            // 
            this.baseButton7.Caption = null;
            this.baseButton7.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F);
            this.baseButton7.Location = new System.Drawing.Point(1167, 616);
            this.baseButton7.Name = "baseButton7";
            this.baseButton7.Size = new System.Drawing.Size(299, 49);
            this.baseButton7.TabIndex = 117;
            this.baseButton7.Text = "baseButton7";
            this.baseButton7.UseVisualStyleBackColor = true;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 923);
            this.Controls.Add(this.baseButton7);
            this.Controls.Add(this.baseButton6);
            this.Controls.Add(this.baseButton10);
            this.Controls.Add(this.baseButton5);
            this.Controls.Add(this.baseButton4);
            this.Controls.Add(this.baseButton3);
            this.Controls.Add(this.baseButton2);
            this.Controls.Add(this.baseButton1);
            this.Controls.Add(this.panel1);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmJuchuList";
            this.Controls.SetChildIndex(this.pnHeader, 0);
            this.Controls.SetChildIndex(this.ucFunction1, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.baseButton1, 0);
            this.Controls.SetChildIndex(this.baseButton2, 0);
            this.Controls.SetChildIndex(this.baseButton3, 0);
            this.Controls.SetChildIndex(this.baseButton4, 0);
            this.Controls.SetChildIndex(this.baseButton5, 0);
            this.Controls.SetChildIndex(this.baseButton10, 0);
            this.Controls.SetChildIndex(this.baseButton6, 0);
            this.Controls.SetChildIndex(this.baseButton7, 0);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CtrlLib.MyControls.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubCase;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private CtrlLib.MyControls.BaseButton baseButton1;
        private CtrlLib.MyControls.BaseButton baseButton2;
        private CtrlLib.MyControls.BaseButton baseButton3;
        private CtrlLib.MyControls.BaseButton baseButton4;
        private CtrlLib.MyControls.BaseButton baseButton10;
        private CtrlLib.MyControls.BaseButton baseButton6;
        private CtrlLib.MyControls.BaseButton baseButton5;
        private CtrlLib.MyControls.BaseButton baseButton7;
    }
}