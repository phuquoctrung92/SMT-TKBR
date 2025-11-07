
namespace SmtLib
{
    /// <summary>パス共通</summary>
    public static class xmlPath
    {
        /// <summary>
        /// パスファイルから値を取得
        /// </summary>
        /// <param name="pkey">項目</param>
        /// <returns></returns>
        public static string GetPath(string pkey)
        {
            var xml = new ClsXml("Path.xml");
            return xml.GetValue(ClsXml.XML_PATH_NODE_NAME, ClsXml.XML_PATH_MEMBER_DIR, string.Format(" {0} = '{1}' ", ClsXml.XML_PATH_MEMBER_ID, pkey));
        }

        /// <summary>
        /// パスファイルに保存
        /// </summary>
        /// <param name="pkey">項目</param>
        /// <param name="pval">値</param>
        public static void SetPath(string pkey, string pval)
        {
            var xml = new ClsXml("Path.xml");
            xml.CanSavePathXml(ClsXml.XML_PATH_NODE_NAME, ClsXml.XML_PATH_MEMBER_ID, pkey, ClsXml.XML_PATH_MEMBER_DIR, pval);
        }
    }
}