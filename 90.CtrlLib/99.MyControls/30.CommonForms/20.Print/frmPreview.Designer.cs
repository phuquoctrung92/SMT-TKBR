using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CtrlLib
{
    /* TODO ERROR: Skipped DefineDirectiveTrivia
    #Const WONDERFULREPORT2005 = -1
    */
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmPreview : Form
    {
        /// <summary>フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。</summary>
        /// <param name="disposing"></param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreview));
            this.btnPrintout = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbZoom = new System.Windows.Forms.ComboBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblPageNo = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.AxWfrControl1 = new AxWfr2016c.AxWfrControl();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxWfrControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrintout
            // 
            this.btnPrintout.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrintout.Location = new System.Drawing.Point(422, 15);
            this.btnPrintout.Name = "btnPrintout";
            this.btnPrintout.Size = new System.Drawing.Size(120, 60);
            this.btnPrintout.TabIndex = 5;
            this.btnPrintout.Text = "F1\r\n印刷";
            this.btnPrintout.UseVisualStyleBackColor = true;
            this.btnPrintout.Click += new System.EventHandler(this.btnPrintout_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnClose.Location = new System.Drawing.Point(935, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 60);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "F10\r\n閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbZoom
            // 
            this.cmbZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZoom.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbZoom.FormattingEnabled = true;
            this.cmbZoom.Location = new System.Drawing.Point(15, 34);
            this.cmbZoom.Name = "cmbZoom";
            this.cmbZoom.Size = new System.Drawing.Size(190, 32);
            this.cmbZoom.TabIndex = 1;
            this.cmbZoom.SelectedIndexChanged += new System.EventHandler(this.cmbZoom_SelectedIndexChanged);
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblErrorMessage.Location = new System.Drawing.Point(18, 48);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(112, 13);
            this.lblErrorMessage.TabIndex = 5;
            this.lblErrorMessage.Text = "lblErrorMessage";
            this.lblErrorMessage.Visible = false;
            // 
            // lblPageNo
            // 
            this.lblPageNo.AutoSize = true;
            this.lblPageNo.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblPageNo.Location = new System.Drawing.Point(211, 38);
            this.lblPageNo.Name = "lblPageNo";
            this.lblPageNo.Size = new System.Drawing.Size(118, 24);
            this.lblPageNo.TabIndex = 2;
            this.lblPageNo.Text = "1234/1234";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrevious.Location = new System.Drawing.Point(610, 15);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(120, 60);
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.Text = "F6\r\n<<前へ";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnNext.Location = new System.Drawing.Point(744, 15);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 60);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "F7\r\n次へ>>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.cmbZoom);
            this.Panel1.Controls.Add(this.btnPrintout);
            this.Panel1.Controls.Add(this.lblPageNo);
            this.Panel1.Controls.Add(this.btnNext);
            this.Panel1.Controls.Add(this.btnPrevious);
            this.Panel1.Controls.Add(this.btnClose);
            this.Panel1.Location = new System.Drawing.Point(6, 771);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1072, 89);
            this.Panel1.TabIndex = 7;
            // 
            // AxWfrControl1
            // 
            this.AxWfrControl1.Enabled = true;
            this.AxWfrControl1.Location = new System.Drawing.Point(12, 12);
            this.AxWfrControl1.Name = "AxWfrControl1";
            this.AxWfrControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxWfrControl1.OcxState")));
            this.AxWfrControl1.Size = new System.Drawing.Size(1060, 753);
            this.AxWfrControl1.TabIndex = 8;
            // 
            // frmPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1084, 862);
            this.Controls.Add(this.AxWfrControl1);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.lblErrorMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "プレビュー";
            this.Load += new System.EventHandler(this.frmPreviewWfr_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPreviewWfr_KeyDown);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AxWfrControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal Button btnPrintout;
        internal Button btnClose;
        internal ComboBox cmbZoom;
        internal Label lblErrorMessage;
        internal Label lblPageNo;
        internal Button btnPrevious;
        internal Button btnNext;
        internal Panel Panel1;
        private AxWfr2016c.AxWfrControl AxWfrControl1;
    }
}