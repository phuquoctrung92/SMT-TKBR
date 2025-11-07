using System.ComponentModel;
using System.Windows.Forms;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// カスタムパネル
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class CustomPanel : Panel
    {
        #region Extend Property
        /// <summary>
        /// ボーダーラインを無効化・有効化
        /// </summary>
        [Category("拡張")]
        [DefaultValue(false)]
        [Description("パターンを設定、取得します。")]
        public bool Border3D { get; set; }

        #endregion
        /// <summary>ペイントのイベント</summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Border3D)
            {
                ControlPaint.DrawBorder3D(e.Graphics, e.ClipRectangle, Border3DStyle.Raised);
            }
        }
    }

}