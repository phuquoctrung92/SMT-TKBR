
using model = System.ComponentModel;
using System.Diagnostics;
using System.Drawing;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// ラベルボックス共通機能
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class LabelBox : System.Windows.Forms.Label
    {
        #region Variable Value

        #endregion

        #region Extend Property

        #endregion
        /// <summary>
        /// テキストの配置
        /// </summary>
        [model.DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public override ContentAlignment TextAlign { get; set; }

        #region Property
        /// <summary>
        /// 文字サイズの自動判断
        /// </summary>
        [model.Browsable(false)]
        [model.ReadOnly(true)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// 初期設定
        /// </summary>
        public LabelBox() : base()
        {
            // MSC 標準のフォント サイズを初期値としています。
            Font = new Font("ＭＳ ゴシック", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 128);
            // ＭＳ ゴシック 9.75! 10桁 のサイズを初期値としています。
            Size = new Size(76, 20);

            AutoSize = false;
            Text = string.Empty;
        }

        #endregion

    }

}