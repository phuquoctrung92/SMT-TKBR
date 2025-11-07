
using SmtLib;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// 背景色がありラベルボックス
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class ColorLabelBox : LabelBox
    {



        #region Constructor

        /// <summary>
        /// 初期設定
        /// </summary>
        /// <remarks>Color.xmlファイルから背景色を表示</remarks>
        public ColorLabelBox() : base()
        {

            // 255, 255, 128
            BackColor = XmlColorLib.GetColor(XmlColorLib.Colors.LabelColor);

        }

        #endregion

    }

}