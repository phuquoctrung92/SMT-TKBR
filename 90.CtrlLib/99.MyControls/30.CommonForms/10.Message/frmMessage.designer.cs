using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CtrlLib.Message
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmMessage : Form
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
            PictureBox1 = new PictureBox();
            lblMsg = new Label();
            btn3 = new MyControls.BaseButton();
            btn3.Click += new EventHandler(btn3_Click);
            btn2 = new MyControls.BaseButton();
            btn2.Click += new EventHandler(btn2_Click);
            btn1 = new MyControls.BaseButton();
            btn1.Click += new EventHandler(btn1_Click);
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PictureBox1
            // 
            PictureBox1.Location = new Point(16, 72);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(48, 48);
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox1.TabIndex = 6;
            PictureBox1.TabStop = false;
            // 
            // lblMsg
            // 
            lblMsg.Font = new Font("ＭＳ ゴシック", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblMsg.Location = new Point(64, 16);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(540, 160);
            lblMsg.TabIndex = 0;
            lblMsg.Text = "１２３４５６７８９０１２３４５６７８９０１２３４５１２３４５６７８９０１２３４５６７８９０１２３４５１２３４５６７８９０１２３４５６７８９０１２３４５１２３４５６" + "７８９０１２３４５６７８９０１２３４５１２３４５６７８９０１２３４５６７８９０１２３４５１２３４５６７８９０１２３４５６７８９０１２３４５１２３４５６７８９０１" + "２３４５６７８９０１２３４５１２３４５６７８９０１２３４５６７８９０１２３４５";

            lblMsg.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn3
            // 
            btn3.FlatStyle = FlatStyle.System;
            btn3.Font = new Font("ＭＳ ゴシック", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 128);
            btn3.Location = new Point(428, 192);
            btn3.Name = "btn3";
            btn3.Size = new Size(184, 48);
            btn3.TabIndex = 3;
            btn3.UseVisualStyleBackColor = true;
            // 
            // btn2
            // 
            btn2.FlatStyle = FlatStyle.System;
            btn2.Font = new Font("ＭＳ ゴシック", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 128);
            btn2.Location = new Point(224, 192);
            btn2.Name = "btn2";
            btn2.Size = new Size(184, 48);
            btn2.TabIndex = 2;
            btn2.UseVisualStyleBackColor = true;
            // 
            // btn1
            // 
            btn1.FlatStyle = FlatStyle.System;
            btn1.Font = new Font("ＭＳ ゴシック", 14.25f, FontStyle.Bold, GraphicsUnit.Point, 128);
            btn1.Location = new Point(16, 192);
            btn1.Name = "btn1";
            btn1.Size = new Size(184, 48);
            btn1.TabIndex = 1;
            btn1.UseVisualStyleBackColor = true;
            // 
            // frmMessage
            // 
            AutoScaleDimensions = new SizeF(10.0f, 19.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 256);
            ControlBox = false;
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Controls.Add(lblMsg);
            Controls.Add(PictureBox1);
            Font = new Font("ＭＳ ゴシック", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 128);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            Margin = new Padding(5);
            Name = "frmMessage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmMessage";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            Load += new EventHandler(frmMessage_Load);
            ResumeLayout(false);

        }
        internal PictureBox PictureBox1;
        internal Label lblMsg;
        internal MyControls.BaseButton btn1;
        internal MyControls.BaseButton btn2;
        internal MyControls.BaseButton btn3;

    }

}