using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CtrlLib
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmprint : Form
    {

        // フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。

        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Windows フォーム デザイナで必要です。

        private System.ComponentModel.IContainer components = null;

        // メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。

        // Windows フォーム デザイナを使用して変更できます。  
        // コード エディタを使って変更しないでください。

        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtRange_To = new System.Windows.Forms.TextBox();
            this.txtRange_From = new System.Windows.Forms.TextBox();
            this.rdoPage_Range = new System.Windows.Forms.RadioButton();
            this.rdoPage_Current = new System.Windows.Forms.RadioButton();
            this.rdoPage_All = new System.Windows.Forms.RadioButton();
            this.btnPrintout = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbPrinter = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtOffsetY = new System.Windows.Forms.TextBox();
            this.txtOffsetX = new System.Windows.Forms.TextBox();
            this.cmbTray = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbRyomen = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPrintOutDetail = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txtRange_To);
            this.GroupBox1.Controls.Add(this.txtRange_From);
            this.GroupBox1.Controls.Add(this.rdoPage_Range);
            this.GroupBox1.Controls.Add(this.rdoPage_Current);
            this.GroupBox1.Controls.Add(this.rdoPage_All);
            this.GroupBox1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GroupBox1.Location = new System.Drawing.Point(92, 155);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(375, 132);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(286, 79);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(64, 21);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "頁まで";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(172, 79);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(63, 21);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "頁から";
            // 
            // txtRange_To
            // 
            this.txtRange_To.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtRange_To.Location = new System.Drawing.Point(233, 76);
            this.txtRange_To.MaxLength = 4;
            this.txtRange_To.Name = "txtRange_To";
            this.txtRange_To.Size = new System.Drawing.Size(50, 26);
            this.txtRange_To.TabIndex = 5;
            this.txtRange_To.Text = "1234";
            this.txtRange_To.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRange_To.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRange_KeyPress);
            this.txtRange_To.Validating += new System.ComponentModel.CancelEventHandler(this.txtRange_To_Validating);
            // 
            // txtRange_From
            // 
            this.txtRange_From.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtRange_From.Location = new System.Drawing.Point(124, 76);
            this.txtRange_From.MaxLength = 4;
            this.txtRange_From.Name = "txtRange_From";
            this.txtRange_From.Size = new System.Drawing.Size(45, 26);
            this.txtRange_From.TabIndex = 3;
            this.txtRange_From.Text = "1234";
            this.txtRange_From.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRange_From.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRange_KeyPress);
            this.txtRange_From.Validating += new System.ComponentModel.CancelEventHandler(this.txtRange_From_Validating);
            // 
            // rdoPage_Range
            // 
            this.rdoPage_Range.AutoSize = true;
            this.rdoPage_Range.Location = new System.Drawing.Point(6, 76);
            this.rdoPage_Range.Name = "rdoPage_Range";
            this.rdoPage_Range.Size = new System.Drawing.Size(112, 25);
            this.rdoPage_Range.TabIndex = 2;
            this.rdoPage_Range.Text = "範囲指定";
            this.rdoPage_Range.UseVisualStyleBackColor = true;
            this.rdoPage_Range.CheckedChanged += new System.EventHandler(this.rdoPage_CheckedChanged);
            // 
            // rdoPage_Current
            // 
            this.rdoPage_Current.AutoSize = true;
            this.rdoPage_Current.Location = new System.Drawing.Point(6, 47);
            this.rdoPage_Current.Name = "rdoPage_Current";
            this.rdoPage_Current.Size = new System.Drawing.Size(108, 25);
            this.rdoPage_Current.TabIndex = 1;
            this.rdoPage_Current.Text = "現在の頁";
            this.rdoPage_Current.UseVisualStyleBackColor = true;
            this.rdoPage_Current.CheckedChanged += new System.EventHandler(this.rdoPage_CheckedChanged);
            // 
            // rdoPage_All
            // 
            this.rdoPage_All.AutoSize = true;
            this.rdoPage_All.Location = new System.Drawing.Point(6, 19);
            this.rdoPage_All.Name = "rdoPage_All";
            this.rdoPage_All.Size = new System.Drawing.Size(70, 25);
            this.rdoPage_All.TabIndex = 0;
            this.rdoPage_All.Text = "全頁";
            this.rdoPage_All.UseVisualStyleBackColor = true;
            this.rdoPage_All.CheckedChanged += new System.EventHandler(this.rdoPage_CheckedChanged);
            // 
            // btnPrintout
            // 
            this.btnPrintout.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrintout.Location = new System.Drawing.Point(14, 393);
            this.btnPrintout.Name = "btnPrintout";
            this.btnPrintout.Size = new System.Drawing.Size(120, 60);
            this.btnPrintout.TabIndex = 7;
            this.btnPrintout.Text = "F1\r\n印刷";
            this.btnPrintout.UseVisualStyleBackColor = true;
            this.btnPrintout.Click += new System.EventHandler(this.btnPrintout_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnExit.Location = new System.Drawing.Point(428, 393);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(120, 60);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "F5\r\n終了";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbPrinter
            // 
            this.cmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinter.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbPrinter.FormattingEnabled = true;
            this.cmbPrinter.Location = new System.Drawing.Point(112, 12);
            this.cmbPrinter.Name = "cmbPrinter";
            this.cmbPrinter.Size = new System.Drawing.Size(436, 29);
            this.cmbPrinter.TabIndex = 1;
            this.cmbPrinter.SelectedIndexChanged += new System.EventHandler(this.cmbPrinter_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label1.Location = new System.Drawing.Point(12, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(69, 21);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "プリンタ";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label2.Location = new System.Drawing.Point(88, 140);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(256, 21);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "印刷範囲を指定してください。";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label5.Location = new System.Drawing.Point(74, 318);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(413, 21);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "補正値　　　縦　　　　　　mm　　横　　　　　　mm";
            // 
            // txtOffsetY
            // 
            this.txtOffsetY.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtOffsetY.Location = new System.Drawing.Point(218, 314);
            this.txtOffsetY.MaxLength = 4;
            this.txtOffsetY.Name = "txtOffsetY";
            this.txtOffsetY.Size = new System.Drawing.Size(60, 28);
            this.txtOffsetY.TabIndex = 5;
            this.txtOffsetY.Text = "1234";
            this.txtOffsetY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOffsetX
            // 
            this.txtOffsetX.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtOffsetX.Location = new System.Drawing.Point(384, 314);
            this.txtOffsetX.MaxLength = 4;
            this.txtOffsetX.Name = "txtOffsetX";
            this.txtOffsetX.Size = new System.Drawing.Size(60, 28);
            this.txtOffsetX.TabIndex = 6;
            this.txtOffsetX.Text = "1234";
            this.txtOffsetX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmbTray
            // 
            this.cmbTray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTray.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbTray.FormattingEnabled = true;
            this.cmbTray.Location = new System.Drawing.Point(112, 50);
            this.cmbTray.Name = "cmbTray";
            this.cmbTray.Size = new System.Drawing.Size(436, 29);
            this.cmbTray.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(0, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "給紙トレイ";
            // 
            // cmbRyomen
            // 
            this.cmbRyomen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRyomen.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbRyomen.FormattingEnabled = true;
            this.cmbRyomen.Location = new System.Drawing.Point(112, 88);
            this.cmbRyomen.Name = "cmbRyomen";
            this.cmbRyomen.Size = new System.Drawing.Size(436, 29);
            this.cmbRyomen.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(1, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "両面印刷";
            // 
            // btnPrintOutDetail
            // 
            this.btnPrintOutDetail.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrintOutDetail.Location = new System.Drawing.Point(143, 393);
            this.btnPrintOutDetail.Name = "btnPrintOutDetail";
            this.btnPrintOutDetail.Size = new System.Drawing.Size(120, 60);
            this.btnPrintOutDetail.TabIndex = 11;
            this.btnPrintOutDetail.Text = "F2\r\n詳細設定";
            this.btnPrintOutDetail.UseVisualStyleBackColor = true;
            this.btnPrintOutDetail.Click += new System.EventHandler(this.btnPrintOutDetail_Click);
            // 
            // frmprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(560, 475);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnPrintOutDetail);
            this.Controls.Add(this.cmbRyomen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtOffsetX);
            this.Controls.Add(this.txtOffsetY);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.cmbTray);
            this.Controls.Add(this.cmbPrinter);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrintout);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmprint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "印刷設定";
            this.Load += new System.EventHandler(this.frmPrintPage_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrintPage_KeyDown);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal GroupBox GroupBox1;
        internal RadioButton rdoPage_Current;
        internal RadioButton rdoPage_All;
        internal Label Label3;
        internal TextBox txtRange_From;
        internal RadioButton rdoPage_Range;
        internal Label Label4;
        internal TextBox txtRange_To;
        internal Button btnPrintout;
        internal Button btnExit;
        internal ComboBox cmbPrinter;
        internal Label Label1;
        internal Label Label2;
        internal Label Label5;
        internal TextBox txtOffsetY;
        internal TextBox txtOffsetX;
        internal ComboBox cmbTray;
        internal Label label6;
        internal ComboBox cmbRyomen;
        internal Label label7;
        internal Button btnPrintOutDetail;
    }
}