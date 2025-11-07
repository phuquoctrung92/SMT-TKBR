using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CtrlLib.Input
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class frmNumberInput : Form
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
            btn0 = new MyControls.BaseButton();
            btn0.Click += new EventHandler(btn0_Click);
            btnOK = new MyControls.BaseButton();
            btnOK.Click += new EventHandler(btnOK_Click);
            btnCancel = new MyControls.BaseButton();
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnC = new MyControls.BaseButton();
            btnC.Click += new EventHandler(btnC_Click);
            btn6 = new MyControls.BaseButton();
            btn6.Click += new EventHandler(btn6_Click);
            btn5 = new MyControls.BaseButton();
            btn5.Click += new EventHandler(btn5_Click);
            btn4 = new MyControls.BaseButton();
            btn4.Click += new EventHandler(btn4_Click);
            btn9 = new MyControls.BaseButton();
            btn9.Click += new EventHandler(btn9_Click);
            btn8 = new MyControls.BaseButton();
            btn8.Click += new EventHandler(btn8_Click);
            btn7 = new MyControls.BaseButton();
            btn7.Click += new EventHandler(btn7_Click);
            txtNumber = new MyControls.StringBox();
            btn3 = new MyControls.BaseButton();
            btn3.Click += new EventHandler(btn3_Click);
            btn2 = new MyControls.BaseButton();
            btn2.Click += new EventHandler(btn2_Click);
            btn1 = new MyControls.BaseButton();
            btn1.Click += new EventHandler(btn1_Click);
            SuspendLayout();
            // 
            // btn0
            // 
            btn0.Caption = null;
            btn0.FlatStyle = FlatStyle.System;
            btn0.Font = new Font("MS Gothic", 36.0f, FontStyle.Bold);
            btn0.Location = new Point(150, 400);
            btn0.Name = "btn0";
            btn0.Size = new Size(80, 60);
            btn0.TabIndex = 3;
            btn0.Text = "０";
            btn0.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Caption = null;
            btnOK.FlatStyle = FlatStyle.System;
            btnOK.Font = new Font("MS Gothic", 20.25f, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnOK.Location = new Point(15, 480);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(140, 50);
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Caption = null;
            btnCancel.FlatStyle = FlatStyle.System;
            btnCancel.Font = new Font("MS Gothic", 18.0f, FontStyle.Regular, GraphicsUnit.Point, 128);
            btnCancel.Location = new Point(225, 480);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(140, 50);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "キャンセル";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnC
            // 
            btnC.Caption = null;
            btnC.FlatStyle = FlatStyle.System;
            btnC.Font = new Font("MS Gothic", 36.0f, FontStyle.Bold);
            btnC.Location = new Point(255, 65);
            btnC.Name = "btnC";
            btnC.Size = new Size(80, 60);
            btnC.TabIndex = 0;
            btnC.Text = "Ｃ";
            btnC.UseVisualStyleBackColor = true;
            // 
            // btn6
            // 
            btn6.Caption = null;
            btn6.FlatStyle = FlatStyle.System;
            btn6.Font = new Font("MS Gothic", 36.0f, FontStyle.Bold);
            btn6.Location = new Point(255, 240);
            btn6.Name = "btn6";
            btn6.Size = new Size(80, 60);
            btn6.TabIndex = 9;
            btn6.Text = "６";
            btn6.UseVisualStyleBackColor = true;
            // 
            // btn5
            // 
            btn5.Caption = null;
            btn5.FlatStyle = FlatStyle.System;
            btn5.Font = new Font("MS Gothic", 36.0f, FontStyle.Bold);
            btn5.Location = new Point(150, 240);
            btn5.Name = "btn5";
            btn5.Size = new Size(80, 60);
            btn5.TabIndex = 8;
            btn5.Text = "５";
            btn5.UseVisualStyleBackColor = true;
            // 
            // btn4
            // 
            btn4.Caption = null;
            btn4.FlatStyle = FlatStyle.System;
            btn4.Font = new Font("MS Gothic", 36.0f, FontStyle.Bold, GraphicsUnit.Point, 128);
            btn4.Location = new Point(45, 240);
            btn4.Name = "btn4";
            btn4.Size = new Size(80, 60);
            btn4.TabIndex = 7;
            btn4.Text = "４";
            btn4.UseVisualStyleBackColor = true;
            // 
            // btn9
            // 
            btn9.Caption = null;
            btn9.FlatStyle = FlatStyle.System;
            btn9.Font = new Font("MS Gothic", 36.0f, FontStyle.Bold);
            btn9.Location = new Point(255, 160);
            btn9.Name = "btn9";
            btn9.Size = new Size(80, 60);
            btn9.TabIndex = 12;
            btn9.Text = "９";
            btn9.UseVisualStyleBackColor = true;
            // 
            // btn8
            // 
            btn8.Caption = null;
            btn8.FlatStyle = FlatStyle.System;
            btn8.Font = new Font("MS Gothic", 36.0f, FontStyle.Bold);
            btn8.Location = new Point(150, 160);
            btn8.Name = "btn8";
            btn8.Size = new Size(80, 60);
            btn8.TabIndex = 11;
            btn8.Text = "８";
            btn8.UseVisualStyleBackColor = true;
            // 
            // btn7
            // 
            btn7.Caption = null;
            btn7.FlatStyle = FlatStyle.System;
            btn7.Font = new Font("MS Gothic", 36.0f, FontStyle.Bold, GraphicsUnit.Point, 128);
            btn7.Location = new Point(45, 160);
            btn7.Name = "btn7";
            btn7.Size = new Size(80, 60);
            btn7.TabIndex = 10;
            btn7.Text = "７";
            btn7.UseVisualStyleBackColor = true;
            // 
            // txtNumber
            // 
            txtNumber.Caption = null;
            txtNumber.Font = new Font("MS Gothic", 24.0f, FontStyle.Bold, GraphicsUnit.Point, 128);
            txtNumber.ImeMode = ImeMode.Hiragana;
            txtNumber.InputPattern = MyControls.InputPatterns.All;
            txtNumber.Location = new Point(15, 15);
            txtNumber.Name = "txtNumber";
            txtNumber.PasteType = MyControls.PasteTypes.Control;
            txtNumber.ReadOnly = true;
            txtNumber.Size = new Size(357, 40);
            txtNumber.TabIndex = 7;
            txtNumber.TabStop = false;
            txtNumber.Text = "123456789";
            txtNumber.TextAlign = HorizontalAlignment.Right;
            // 
            // btn3
            // 
            btn3.Caption = null;
            btn3.FlatStyle = FlatStyle.System;
            btn3.Font = new Font("MS Gothic", 36.0f, FontStyle.Bold);
            btn3.Location = new Point(255, 320);
            btn3.Name = "btn3";
            btn3.Size = new Size(80, 60);
            btn3.TabIndex = 6;
            btn3.Text = "３";
            btn3.UseVisualStyleBackColor = true;
            // 
            // btn2
            // 
            btn2.Caption = null;
            btn2.FlatStyle = FlatStyle.System;
            btn2.Font = new Font("MS Gothic", 36.0f, FontStyle.Bold);
            btn2.Location = new Point(150, 320);
            btn2.Name = "btn2";
            btn2.Size = new Size(80, 60);
            btn2.TabIndex = 5;
            btn2.Text = "２";
            btn2.UseVisualStyleBackColor = true;
            // 
            // btn1
            // 
            btn1.Caption = null;
            btn1.FlatStyle = FlatStyle.System;
            btn1.Font = new Font("MS Gothic", 36.0f, FontStyle.Bold, GraphicsUnit.Point, 128);
            btn1.Location = new Point(45, 320);
            btn1.Name = "btn1";
            btn1.Size = new Size(80, 60);
            btn1.TabIndex = 4;
            btn1.Text = "１";
            btn1.UseVisualStyleBackColor = true;
            // 
            // frmNumberInput
            // 
            AutoScaleDimensions = new SizeF(10.0f, 19.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 561);
            ControlBox = false;
            Controls.Add(btn0);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Controls.Add(btnC);
            Controls.Add(btn6);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn9);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(txtNumber);
            Controls.Add(btn3);
            Controls.Add(btn2);
            Controls.Add(btn1);
            Font = new Font("MS Gothic", 14.25f, FontStyle.Regular, GraphicsUnit.Point, 128);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            Margin = new Padding(5);
            Name = "frmNumberInput";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "数字入力";
            TopMost = true;
            Load += new EventHandler(frmMessage_Load);
            ResumeLayout(false);

        }
        internal MyControls.BaseButton btn1;
        internal MyControls.BaseButton btn2;
        internal MyControls.BaseButton btn3;
        internal MyControls.StringBox txtNumber;
        internal MyControls.BaseButton btn9;
        internal MyControls.BaseButton btn8;
        internal MyControls.BaseButton btn7;
        internal MyControls.BaseButton btn6;
        internal MyControls.BaseButton btn5;
        internal MyControls.BaseButton btn4;
        internal MyControls.BaseButton btnC;
        internal MyControls.BaseButton btnCancel;
        internal MyControls.BaseButton btnOK;
        internal MyControls.BaseButton btn0;
    }

}