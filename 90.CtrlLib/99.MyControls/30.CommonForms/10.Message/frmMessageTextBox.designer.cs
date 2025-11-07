using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CtrlLib.Message
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmMessageTextBox : Form
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
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btn3 = new CtrlLib.MyControls.BaseButton();
            this.btn2 = new CtrlLib.MyControls.BaseButton();
            this.btn1 = new CtrlLib.MyControls.BaseButton();
            this.txtInputData = new CtrlLib.MyControls.StringBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(16, 72);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(48, 48);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 6;
            this.PictureBox1.TabStop = false;
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblMsg.Location = new System.Drawing.Point(64, 16);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(540, 122);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５１２３４５６７８９０１２３４５６７８９０１２３４５１２３４５６７８９０１２３４５６７８９０１２３４５１２３４５６" +
    "７８９０１２３４５６７８９０１２３４５１２３４５６７８９０１２３４５６７８９０１２３４５１２３４５６７８９０１２３４５６７８９０１２３４５１２３４５６７８９０１" +
    "２３４５６７８９０１２３４５１２３４５６７８９０１２３４５６７８９０１２３４５";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn3
            // 
            this.btn3.Caption = null;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn3.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn3.Location = new System.Drawing.Point(428, 192);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(184, 48);
            this.btn3.TabIndex = 3;
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn2
            // 
            this.btn2.Caption = null;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn2.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn2.Location = new System.Drawing.Point(224, 192);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(184, 48);
            this.btn2.TabIndex = 2;
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn1
            // 
            this.btn1.Caption = null;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn1.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn1.Location = new System.Drawing.Point(16, 192);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(184, 48);
            this.btn1.TabIndex = 1;
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // txtInputData
            // 
            this.txtInputData.Caption = null;
            this.txtInputData.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F);
            this.txtInputData.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.txtInputData.InputPattern = CtrlLib.MyControls.InputPatterns.All;
            this.txtInputData.Location = new System.Drawing.Point(68, 142);
            this.txtInputData.Name = "txtInputData";
            this.txtInputData.PasteType = CtrlLib.MyControls.PasteTypes.Control;
            this.txtInputData.Size = new System.Drawing.Size(544, 36);
            this.txtInputData.TabIndex = 7;
            // 
            // frmMessageTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 256);
            this.ControlBox = false;
            this.Controls.Add(this.txtInputData);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.PictureBox1);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmMessageTextBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMessage";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMessage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        internal PictureBox PictureBox1;
        internal Label lblMsg;
        internal MyControls.BaseButton btn1;
        internal MyControls.BaseButton btn2;
        internal MyControls.BaseButton btn3;
        private MyControls.StringBox txtInputData;
    }

}