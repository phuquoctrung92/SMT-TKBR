using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CtrlLib
{
    /// <summary> ファンクションボタン設定用構造体 </summary>
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ucFunction : UserControl
    {
        /// <summary>UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。</summary>
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

        // Windows フォーム デザイナーで必要です。
        private System.ComponentModel.IContainer components = null;

        // メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
        // Windows フォーム デザイナーを使用して変更できます。  
        // コード エディターを使って変更しないでください。
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // ucFunction
            // 
            AutoScaleDimensions = new SizeF(6.0f, 12.0f);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Name = "ucFunction";
            Size = new Size(1000, 39);
            ResumeLayout(false);
        }

    }
}