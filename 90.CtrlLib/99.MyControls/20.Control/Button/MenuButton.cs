
using model = System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// メニュー用ボタン
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class MenuButton : BaseButton
    {

        #region Variable Value

        /// <summary> メニュー番号 </summary>
        private int m_menu_id;
        /// <summary> メニュー番号 </summary>
        private Keys m_menu_func;
        /// <summary> メニュー名 </summary>
        private string m_menu_name;

        #endregion

        #region Extend Property

        /// <summary> メニュー番号 </summary>
        [model.Browsable(false)]
        public int MenuId
        {
            get
            {
                return m_menu_id;
            }
        }

        /// <summary>
        /// メニュー番号
        /// </summary>
        [model.Browsable(false)]
        public Keys MenuFunc
        {
            get
            {
                return m_menu_func;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// 初期設定
        /// </summary>
        public MenuButton()
        {

            m_menu_id = 0;
            m_menu_name = string.Empty;

            Enabled = false;

        }

        #endregion

        #region Method

        /// <summary>
        /// コントロール初期化
        /// </summary>
        /// <param name="_menu_id"> ボタンに割り当てる番号 </param>
        /// <param name="_menu_name"> 機能名 </param>
        /// <param name="_caption_length">キャプションの桁数</param>
        /// <param name="_show_menu_id"> 番号表示しない場合、False を指定 </param>
        /// <param name="_execution_authority"> 実行権限がない場合、False を指定 </param>
        /// <param name="_isVisible">表示・非表示</param>
        public void InitButton(int _menu_id, string _menu_name, int _caption_length = 20, bool _show_menu_id = true, bool _execution_authority = true, bool _isVisible = true)
        {

            m_menu_id = _menu_id;
            m_menu_name = _menu_name;
            Font = new Font("Meiryo", 15.75f, FontStyle.Regular, GraphicsUnit.Point, 128);
            if (_show_menu_id)
            {
                Text = "  &" + m_menu_id + "." + m_menu_name;
                TextAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                TextAlign = ContentAlignment.MiddleCenter;
                Text = m_menu_name;
            }

            int x = SmtLib.ClsCheck.GetLengthAsByte(Text);

            if (_caption_length >= x)
            {
                Text = Text + "".PadRight(_caption_length - x, ' ');
            }

            if (_execution_authority)
            {
                Enabled = true;
            }

            Visible = _isVisible;
        }

        /// <summary>
        /// コントロール初期化
        /// </summary>
        /// <param name="_menu_func"> ボタンに割り当てる番号 </param>
        /// <param name="_menu_name"> 機能名 </param>
        /// <param name="_caption_length">キャプションの桁数</param>
        /// <param name="_show_menu_id"> 番号表示しない場合、False を指定 </param>
        /// <param name="_execution_authority"> 実行権限がない場合、False を指定 </param>
        public void InitButton(Keys _menu_func, string _menu_name, int _caption_length = 20, bool _show_menu_id = true, bool _execution_authority = true)
        {
            m_menu_func = _menu_func;
            m_menu_name = _menu_name;

            if (_show_menu_id)
            {
                Text = m_menu_func.ToString() + ":" + m_menu_name;
            }
            else
            {
                Text = m_menu_name;
            }

            int x = SmtLib.ClsCheck.GetLengthAsByte(Text);

            if (_caption_length >= x)
            {
                Text = Text + "".PadRight(_caption_length - x, ' ');
            }

            if (_execution_authority)
            {
                Enabled = true;
            }
        }

        #endregion
    }

}