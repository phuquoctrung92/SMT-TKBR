
using model = System.ComponentModel;
using System.Drawing;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// ラベル共通機能
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class Label : System.Windows.Forms.Label
    {
        /// <summary>テキストの配置</summary>
        [model.DefaultValue(ContentAlignment.MiddleLeft)]
        public override ContentAlignment TextAlign { get; set; }

        /// <summary>初期設定</summary>
        public Label() : base()
        {
            TextAlign = ContentAlignment.MiddleLeft;
            AutoSize = false;
            Text = string.Empty;
            BackColor = Color.White;
        }

    }

}