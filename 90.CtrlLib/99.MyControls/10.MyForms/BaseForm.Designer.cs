using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CtrlLib.MyForms
{
    /// <summary>
    /// フォーム共通機能
    /// </summary>
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class BaseForm : Form
    {
        /// <summary>
        /// フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
        /// </summary>
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

        /// <summary>Windows フォーム デザイナで必要です。</summary>
        private System.ComponentModel.IContainer components = null;

        // メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
        /// <summary>
        /// Windows フォーム デザイナを使用して変更できます。
        /// </summary>
        /// <remarks>コード エディタを使って変更しないでください。</remarks>
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            _StatusStrip1 = new StatusStrip();
            _ToolStripStatusLabel1 = new ToolStripStatusLabel();
            _ToolStripProgressBar1 = new ToolStripProgressBar();
            _ToolStripStatusLabel2 = new ToolStripStatusLabel();
            _StatusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // StatusStrip1
            // 
            _StatusStrip1.BackColor = Color.Transparent;
            _StatusStrip1.BackgroundImageLayout = ImageLayout.None;
            _StatusStrip1.Items.AddRange(new ToolStripItem[] { _ToolStripStatusLabel1, _ToolStripProgressBar1, _ToolStripStatusLabel2 });
            _StatusStrip1.Location = new Point(0, 838);
            _StatusStrip1.Name = "_StatusStrip1";
            _StatusStrip1.ShowItemToolTips = true;
            _StatusStrip1.Size = new Size(1264, 23);
            _StatusStrip1.SizingGrip = false;
            _StatusStrip1.TabIndex = 3;
            _StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            _ToolStripStatusLabel1.Name = "_ToolStripStatusLabel1";
            _ToolStripStatusLabel1.Size = new Size(119, 18);
            _ToolStripStatusLabel1.Text = "ToolStripStatusLabel1";
            // 
            // ToolStripProgressBar1
            // 
            _ToolStripProgressBar1.Name = "_ToolStripProgressBar1";
            _ToolStripProgressBar1.Size = new Size(300, 17);
            // 
            // ToolStripStatusLabel2
            // 
            _ToolStripStatusLabel2.AutoSize = false;
            _ToolStripStatusLabel2.Name = "_ToolStripStatusLabel2";
            _ToolStripStatusLabel2.Size = new Size(828, 18);
            _ToolStripStatusLabel2.Spring = true;
            _ToolStripStatusLabel2.Text = "Ver:1.00.0";
            _ToolStripStatusLabel2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(7.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1264, 861);
            Controls.Add(_StatusStrip1);
            Font = new Font("MS Gothic", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 128);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "BaseForm";
            StartPosition = FormStartPosition.CenterScreen;
            _StatusStrip1.ResumeLayout(false);
            _StatusStrip1.PerformLayout();
            Load += new EventHandler(Form_Load);
            FormClosed += new FormClosedEventHandler(Form_FormClosed);
            KeyDown += new KeyEventHandler(Form_KeyDown);
            ResumeLayout(false);
            PerformLayout();

        }
        private StatusStrip _StatusStrip1;

        /// <summary>
        /// 状況エリア
        /// </summary>
        public virtual StatusStrip StatusStrip1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StatusStrip1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _StatusStrip1 = value;
            }
        }
        private ToolStripStatusLabel _ToolStripStatusLabel1;

        /// <summary>
        /// 状況テキスト
        /// </summary>
        public virtual ToolStripStatusLabel ToolStripStatusLabel1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripStatusLabel1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ToolStripStatusLabel1 = value;
            }
        }
        private ToolStripProgressBar _ToolStripProgressBar1;

        /// <summary>
        /// 状況プロセス
        /// </summary>
        public virtual ToolStripProgressBar ToolStripProgressBar1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripProgressBar1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ToolStripProgressBar1 = value;
            }
        }
        private ToolStripStatusLabel _ToolStripStatusLabel2;

        internal virtual ToolStripStatusLabel ToolStripStatusLabel2
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ToolStripStatusLabel2;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                _ToolStripStatusLabel2 = value;
            }
        }
    }

}