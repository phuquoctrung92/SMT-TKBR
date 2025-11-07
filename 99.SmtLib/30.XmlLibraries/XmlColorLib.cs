using System;
using System.Data;

namespace SmtLib
{

    /// <summary>
    /// カラー管理クラス
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// 
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    /// <memo>
    /// 色の追加方法
    /// CST_MAX_COLORINDEX の変更
    /// EnumColor     に項目追加
    ///   CommonColorInit     にて初期値を設定
    /// </memo>
    public static class XmlColorLib
    {

        #region Variable Value

        private static ClsXml m_xml_object;

        private static ColorList[] m_color_lists = new ColorList[Enum.GetValues(typeof(Colors)).GetUpperBound(0) + 1];

        #endregion

        #region Structure

        /// <summary>
        /// 色データ構造体
        /// </summary>
        /// <remarks></remarks>
        private struct ColorList
        {
            public string color_name;
            public System.Drawing.Color color;
        }

        #endregion

        #region Enumerated type

        /// <summary>
        /// 色設定(COLOR.XML内のCONTROLと同一)
        /// </summary>
        /// <remarks></remarks>
        public enum Colors
        {

            /// <summary> 入力コントロールのフォーカス背景色 </summary>
            GotFocusColor,
            /// <summary> 入力コントロールの通常背景色 </summary>
            LostFocusColor,
            /// <summary> 入力コントロールのReadOnly背景色 </summary>
            ReadOnlyColor,
            /// <summary> 入力コントロールの非活性(Enabled=false)背景色 </summary>
            EnableFalseColor,
            /// <summary> ラベルの背景色 </summary>
            LabelColor,

            /// <summary> SPREAD の表のタイトル色 </summary>
            SpdHeadColor,
            /// <summary> 行選択時の色 </summary>
            SpdSelectColor,
            /// <summary> 一覧デフォルト色(White) </summary>
            SpdDefaultColor,

            /// <summary> スプレッド表示セル背景色(デフォルト-黄色) </summary>
            SpdDispColor,

            /// <summary> 必須カラー </summary>
            HissuColor,

            /// <summary> フォームの背景色 </summary>
            FormBackColor,
            /// <summary> パネルのフッター </summary>
            FooterPanel,
            /// <summary> パネルのヘッダー </summary>
            HeaderPanel
        }

        #endregion

        #region Method

        /// <summary>
        /// 色のデータを取得
        /// </summary>
        /// <param name="colorNumber"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static System.Drawing.Color GetColor(Colors colorNumber)
        {
            return m_color_lists[(int)colorNumber].color;
        }

        // *******************************************************************
        // *  関数名   ：CommonColorIni
        // * 機 能   ：色の初期設定
        // * 引数( In)：NONE
        // * 引数(Out)：NONE
        // *
        // *******************************************************************
        private static bool CommonColorInit()
        {
            m_color_lists = new ColorList[Enum.GetValues(typeof(Colors)).GetUpperBound(0) + 1];

            for (int i = 0, loopTo = m_color_lists.Length - 1; i <= loopTo; i++)
            {
                switch (i)
                {
                    case (int)Colors.GotFocusColor:
                        {
                            m_color_lists[i].color_name = Colors.GotFocusColor.ToString();
                            m_color_lists[i].color = System.Drawing.Color.LightCyan;
                            break;
                        }

                    case (int)Colors.LostFocusColor:
                        {
                            m_color_lists[i].color_name = Colors.LostFocusColor.ToString();
                            m_color_lists[i].color = System.Drawing.Color.White;
                            break;
                        }

                    case (int)Colors.ReadOnlyColor:
                        {
                            m_color_lists[i].color_name = Colors.ReadOnlyColor.ToString();
                            m_color_lists[i].color = System.Drawing.Color.LemonChiffon;
                            break;
                        }

                    case (int)Colors.EnableFalseColor:
                        {
                            m_color_lists[i].color_name = Colors.EnableFalseColor.ToString();
                            m_color_lists[i].color = System.Drawing.Color.Silver;
                            break;
                        }

                    case (int)Colors.LabelColor:
                        {
                            m_color_lists[i].color_name = Colors.LabelColor.ToString();
                            m_color_lists[i].color = System.Drawing.Color.Yellow;
                            break;
                        }

                    case (int)Colors.SpdHeadColor:
                        {
                            m_color_lists[i].color_name = Colors.SpdHeadColor.ToString();
                            m_color_lists[i].color = System.Drawing.Color.LightSalmon;
                            break;
                        }

                    case (int)Colors.SpdSelectColor:
                        {
                            m_color_lists[i].color_name = Colors.SpdSelectColor.ToString();
                            m_color_lists[i].color = System.Drawing.Color.Orchid;
                            break;
                        }

                    case (int)Colors.SpdDefaultColor:
                        {
                            m_color_lists[i].color_name = Colors.SpdDefaultColor.ToString();
                            m_color_lists[i].color = System.Drawing.Color.White;
                            break;
                        }

                    case (int)Colors.SpdDispColor:
                        {
                            m_color_lists[i].color_name = Colors.SpdDispColor.ToString();
                            m_color_lists[i].color = System.Drawing.Color.Yellow;
                            break;
                        }

                    case (int)Colors.HissuColor:
                        {
                            m_color_lists[i].color_name = Colors.HissuColor.ToString();
                            m_color_lists[i].color = System.Drawing.Color.Pink;
                            break;
                        }
                    case (int)Colors.FormBackColor:
                        {
                            m_color_lists[i].color_name = Colors.FormBackColor.ToString();
                            m_color_lists[i].color = System.Drawing.Color.LightYellow;
                            break;
                        }
                    case (int)Colors.FooterPanel:
                        {
                            m_color_lists[i].color_name = Colors.FooterPanel.ToString();
                            m_color_lists[i].color = System.Drawing.Color.White;
                            break;
                        }
                    case (int)Colors.HeaderPanel:
                        {
                            m_color_lists[i].color_name = Colors.HeaderPanel.ToString();
                            m_color_lists[i].color = System.Drawing.Color.White;
                            break;
                        }
                }
            }

            return default;
        }

        // *******************************************************************
        // *  関数名   ：CommonColorRead
        // * 機 能   ：共通の色をXMLより呼び出す
        // * 引数( In)：NONE
        // * 引数(Out)：NONE
        // *
        // *******************************************************************
        /// <summary>共通の色をXMLより呼び出す</summary>
        /// <param name="_kbnName"></param>
        /// <returns></returns>
        public static bool ReadXml(string _kbnName)
        {
            int RColor;
            int GColor;
            int BColor;

            // 色の初期設定
            CommonColorInit();

            try
            {

                if (m_xml_object is null)
                {
                    m_xml_object = new ClsXml(Const_XML.FILE_COLOR);
                }

                // 色一覧を丸ごと取得
                DataTable dt;
                dt = m_xml_object.GetValues(_kbnName);

                DataRow[] dr;

                for (int i = 0, loopTo = m_color_lists.Length - 1; i <= loopTo; i++)
                {

                    // 名前ごとに色を設定
                    dr = dt.Select("NAME = '" + m_color_lists[i].color_name.ToUpper() + "'");

                    if (dr.Length == 0)
                    {
                        continue;
                    }

                    {
                        ref var withBlock = ref dr[0];

                        if (!int.TryParse(withBlock["R"].ToString(), out RColor))
                        {
                            RColor = 0;
                        }

                        if (!int.TryParse(withBlock["G"].ToString(), out GColor))
                        {
                            GColor = 0;
                        }

                        if (!int.TryParse(withBlock["B"].ToString(), out BColor))
                        {
                            BColor = 0;
                        }

                        m_color_lists[i].color = System.Drawing.Color.FromArgb(RColor, GColor, BColor);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }

        }

        #endregion

    }
}