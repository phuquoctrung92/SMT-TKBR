
namespace SmtLib
{

    public static class xmlSystem
    {

        /// <summary> XML DataBase ノード名 </summary>
        private const string XML_SQLSERVER_NODE = "SQLServer";
        /// <summary> XML DataBase ノード名 </summary>
        private const string XML_TCPIP_NODE = "TcpIp";

        public static string SQLServer_Host => GetPath(XML_SQLSERVER_NODE, "Host");
        public static string SQLServer_Port => GetPath(XML_SQLSERVER_NODE, "Port");
        public static string SQLServer_Database => GetPath(XML_SQLSERVER_NODE, "Database");
        public static string SQLServer_UserID => GetPath(XML_SQLSERVER_NODE, "UserID");
        public static string SQLServer_Password => GetPath(XML_SQLSERVER_NODE, "Password");
        public static string TCPIP_Port => GetPath(XML_TCPIP_NODE, "Port");
        public static string TCPIP_LogDisplay => GetPath(XML_TCPIP_NODE, "LogDisplay");

        private static string GetPath(string pnode, string pmember)
        {
            var xml = new SmtLib.ClsXml(SmtLib.Const_XML.FILE_SYSTEM);
            return xml.GetValue(pnode, pmember);
        }

        private static void SetPath(string pnode, string pmember, string pval)
        {
            var xml = new SmtLib.ClsXml(SmtLib.Const_XML.FILE_SYSTEM);
            // xml.CanSavePathXml(pnode, pmember, pkey, ClsXml.XML_PATH_MEMBER_DIR, pval)
            xml.CanSavePathXml(pnode, pmember, pmember, pmember, pval);
        }


    }
}