using System;
using System.Collections.Generic;
using System.Data;

namespace SmtLib
{

    /// <summary>
    /// Message管理クラス
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create  1.00
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public static class XmlMessageLib
    {

        #region Constant Value

        /// <summary> XML MESSAGE ノード名 </summary>
        private const string XML_MESSAGE_NODE = "Message";
        /// <summary> XML MESSAGE メンバ カテゴリ </summary>
        private const string XML_MESSAGE_MEMBER_CATEGORY = "Category";
        /// <summary> XML MESSAGE メンバ コード </summary>
        private const string XML_MESSAGE_MEMBER_CD = "Cd";
        /// <summary> XML MESSAGE メンバ メッセージ内容 </summary>
        private const string XML_MESSAGE_MEMBER_DESCRIPTION = "Description";

        #endregion

        #region Variable Value

        private static ClsXml m_xml_object;

        private static Dictionary<string, string> m_message_infomation = new Dictionary<string, string>();
        private static Dictionary<string, string> m_message_exclamation = new Dictionary<string, string>();
        private static Dictionary<string, string> m_message_question = new Dictionary<string, string>();
        private static Dictionary<string, string> m_message_critical = new Dictionary<string, string>();

        #endregion

        #region Method

        /// <summary>メッセージコードよりメッセージを返す</summary>
        /// <param name="_category">メッセージカテゴリ</param>
        /// <param name="_cd">メッセージコード</param>
        /// <returns>メッセージ/取得できなかったら空白</returns>
        /// <remarks></remarks>
        public static string GetMessage(string _category, int _cd)


        {

            try
            {
                switch (_category ?? "")
                {
                    case ConstLib.MESSAGE_CATEGORY_INFORMATION:
                        {
                            return m_message_infomation[_cd.ToString()];
                        }
                    case ConstLib.MESSAGE_CATEGORY_EXCLAMATION:
                        {
                            return m_message_exclamation[_cd.ToString()];
                        }
                    case ConstLib.MESSAGE_CATEGORY_QUESTION:
                        {
                            return m_message_question[_cd.ToString()];
                        }
                    case ConstLib.MESSAGE_CATEGORY_CRITICAL:
                        {
                            return m_message_critical[_cd.ToString()];
                        }
                }

                return string.Empty;
            }

            catch
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// XMLよりメッセージを取得して保管
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool SetXmlMessage()
        {

            DataRow[] row;
            var table = new DataTable();

            if (m_xml_object is null)
            {
                m_xml_object = new ClsXml(Const_XML.FILE_MESSAGE);
            }

            table = m_xml_object.GetValues(XML_MESSAGE_NODE);

            if (table is null || table.Rows.Count == 0)
            {
                return false;
            }

            row = table.Select(XML_MESSAGE_MEMBER_CATEGORY + " = '" + ConstLib.MESSAGE_CATEGORY_INFORMATION + "'");
            for (int i = 0, loopTo = row.Length - 1; i <= loopTo; i++)
            {
                string key = row[i][XML_MESSAGE_MEMBER_CD].ToString();
                if (!m_message_infomation.ContainsKey(key))
                {
                    m_message_infomation.Add(key, row[i][XML_MESSAGE_MEMBER_DESCRIPTION].ToString());
                }
            }

            row = table.Select(XML_MESSAGE_MEMBER_CATEGORY + " = '" + ConstLib.MESSAGE_CATEGORY_EXCLAMATION + "'");
            for (int i = 0, loopTo1 = row.Length - 1; i <= loopTo1; i++)
            {
                string key = row[i][XML_MESSAGE_MEMBER_CD].ToString();
                if (!m_message_exclamation.ContainsKey(key))
                {
                    m_message_exclamation.Add(key, row[i][XML_MESSAGE_MEMBER_DESCRIPTION].ToString());
                }
            }

            row = table.Select(XML_MESSAGE_MEMBER_CATEGORY + " = '" + ConstLib.MESSAGE_CATEGORY_QUESTION + "'");
            for (int i = 0, loopTo2 = row.Length - 1; i <= loopTo2; i++)
            {
                string key = row[i][XML_MESSAGE_MEMBER_CD].ToString();
                if (!m_message_question.ContainsKey(key))
                {
                    m_message_question.Add(key, row[i][XML_MESSAGE_MEMBER_DESCRIPTION].ToString());
                }
            }

            row = table.Select(XML_MESSAGE_MEMBER_CATEGORY + " = '" + ConstLib.MESSAGE_CATEGORY_CRITICAL + "'");
            for (int i = 0, loopTo3 = row.Length - 1; i <= loopTo3; i++)
            {
                string key = row[i][XML_MESSAGE_MEMBER_CD].ToString();
                if (!m_message_critical.ContainsKey(key))
                {
                    m_message_critical.Add(key, row[i][XML_MESSAGE_MEMBER_DESCRIPTION].ToString());
                }
            }

            return default;

        }

        #endregion

    }
}