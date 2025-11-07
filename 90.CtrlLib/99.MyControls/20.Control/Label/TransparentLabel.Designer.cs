using System.Diagnostics;

namespace CtrlLib.MyControls
{

    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class TransparentLabel : System.Windows.Forms.Label
    {
        /// <summary>
        /// UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
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

        // Windows フォーム デザイナで必要です。
        private System.ComponentModel.IContainer components;

        // メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
        // Windows フォーム デザイナを使用して変更できます。  
        // コード エディタを使って変更しないでください。
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

    }

}