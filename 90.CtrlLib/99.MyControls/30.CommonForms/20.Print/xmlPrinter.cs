using System.Collections.Generic;
using System.Linq;
using SmtLib;

namespace CtrlLib
{
    /// <summary> Printer.xml ノード設定 </summary>
    public static class xmlPrinter
    {
        /// <summary> XML ID ノード名 </summary>
        private const string XML_PRINTER_ID = "ID";
        /// <summary> XML PrinterDriverPath ノード名 </summary>
        private const string XML_PRINTER_DRIVER_PATH = "PrinterDriverPath";
        /// <summary> XML PrinterOffsetXPath ノード名 </summary>
        private const string XML_PRINTER_OFFSET_X_PATH = "PrinterOffsetXPath";
        /// <summary> XML PrinterOffsetYPath ノード名 </summary>
        private const string XML_PRINTER_OFFSET_Y_PATH = "PrinterOffsetYPath";
        /// <summary> XML PrinterTrayName ノード名 </summary>
        private const string XML_PRINTER_TRAY_NAME = "PrinterTrayName";
        /// <summary> XML PrinterRyomen ノード名 </summary>
        private const string XML_PRINTER_RYOMEN = "PrinterRyomen";
        /// <summary> XML PrinterYoshiName ノード名 </summary>
        private const string XML_PRINTER_YOSHI_NAME = "PrinterYoshiName";

        /// <summary>
        /// Printer.xml 設定値取得 帳票名
        /// </summary>
        /// <param name="reportId">レポートID</param>
        public static string get_PrinterID(string reportId) => GetPath(reportId, XML_PRINTER_ID);

        /// <summary>
        /// Printer.xml 設定値取得 プリンタドライバ名
        /// </summary>
        /// <param name="reportId">レポートID</param>
        public static string get_PrinterDriverPath(string reportId)
        {
            return GetPath(reportId, XML_PRINTER_DRIVER_PATH);
        }

        /// <summary>
        /// Printer.xml 設定値更新 プリンタドライバ名
        /// </summary>
        /// <param name="reportId">レポートID</param>
        /// <param name="value">設定値</param>
        public static void set_PrinterDriverPath(string reportId, string value)
        {
            SetPath(reportId, XML_PRINTER_DRIVER_PATH, value);
        }

        /// <summary>
        /// Printer.xml 設定値取得 横オフセット（mm）
        /// </summary>
        /// <param name="reportId">レポートID</param>
        public static string get_PrinterOffsetXPath(string reportId)
        {
            return GetPath(reportId, XML_PRINTER_OFFSET_X_PATH);
        }

        /// <summary>
        /// Printer.xml 設定値取得 横オフセット（mm）
        /// </summary>
        /// <param name="reportId">レポートID</param>
        /// <param name="value"></param>
        public static void set_PrinterOffsetXPath(string reportId, string value)
        {
            SetPath(reportId, XML_PRINTER_OFFSET_X_PATH, value);
        }

        /// <summary>
        /// Printer.xml 設定値取得 縦オフセット（mm）
        /// </summary>
        /// <param name="reportId">レポートID</param>
        /// <returns>縦オフセット（mm）</returns>
        public static string get_PrinterOffsetYPath(string reportId)
        {
            return GetPath(reportId, XML_PRINTER_OFFSET_Y_PATH);
        }

        /// <summary>
        /// Printer.xml 設定値更新 縦オフセット（mm）
        /// </summary>
        /// <param name="reportId">レポートID</param>
        /// <param name="value">設定値</param>
        public static void set_PrinterOffsetYPath(string reportId, string value)
        {
            SetPath(reportId, XML_PRINTER_OFFSET_Y_PATH, value);
        }

        /// <summary>
        /// Printer.xml 設定値取得 給紙トレイ
        /// </summary>
        /// <param name="reportId">レポートID</param>
        /// <returns>トレイ名</returns>
        public static string get_PrinterTrayName(string reportId)
        {
            return GetPath(reportId, XML_PRINTER_TRAY_NAME);
        }

        /// <summary>Printer.xml 設定値更新 給紙トレイ</summary>
        /// <param name="reportId">レポートID</param>
        /// <param name="value">設定値</param>
        public static void set_PrinterTrayName(string reportId, string value)
        {
            SetPath(reportId, XML_PRINTER_TRAY_NAME, value);
        }

        /// <summary>
        /// Printer.xml 設定値取得 両面
        /// </summary>
        /// <param name="reportId">レポートID</param>
        public static string get_PrinterRyomen(string reportId)
        {
            return GetPath(reportId, XML_PRINTER_RYOMEN);
        }

        /// <summary>
        /// Printer.xml 設定値更新 両面
        /// </summary>
        /// <param name="reportId">レポートID</param>
        /// <param name="value">設定値</param>
        public static void set_PrinterRyomen(string reportId, string value)
        {
            SetPath(reportId, XML_PRINTER_RYOMEN, value);
        }

        /// <summary>
        /// Printer.xml 設定値取得 用紙名
        /// </summary>
        /// <param name="reportId">レポートID</param>
        public static string get_PrinterYoshiNm(string reportId) => GetPath(reportId, XML_PRINTER_YOSHI_NAME);

        /// <summary>
        /// Printer.xml 設定値更新 用紙名
        /// </summary>
        /// <param name="reportId">レポートID</param>
        /// <param name="value">設定値</param>
        public static void set_PrinterYoshiNm(string reportId, string value) => SetPath(reportId, XML_PRINTER_YOSHI_NAME, value);

        private static string GetPath(string pnode, string pmember)
        {
            var xml = new ClsXml(Const_XML.FILE_PRINTER);
            return xml.GetValue(pnode, pmember);
        }

        private static void SetPath(string pnode, string pmember, string pval)
        {
            var xml = new ClsXml(Const_XML.FILE_PRINTER);
            var member = new Dictionary<string, string>();
            member.Add(XML_PRINTER_DRIVER_PATH, ClsCheck.IsNull(get_PrinterDriverPath(pnode)) ? "" : get_PrinterDriverPath(pnode));
            member.Add(XML_PRINTER_OFFSET_X_PATH, ClsCheck.IsNull(get_PrinterOffsetXPath(pnode)) ? "0" : get_PrinterOffsetXPath(pnode));
            member.Add(XML_PRINTER_OFFSET_Y_PATH, ClsCheck.IsNull(get_PrinterOffsetYPath(pnode)) ? "0" : get_PrinterOffsetYPath(pnode));
            member.Add(XML_PRINTER_TRAY_NAME, ClsCheck.IsNull(get_PrinterTrayName(pnode)) ? "" : get_PrinterTrayName(pnode));
            member.Add(XML_PRINTER_RYOMEN, ClsCheck.IsNull(get_PrinterRyomen(pnode)) ? "" : get_PrinterRyomen(pnode));
            member[pmember] = pval;

            xml.CanSavePathXml(pnode, ClsXml.XML_IMG_SETTINGS_MEMBER_ID, pnode, member.Keys.ToArray(), member.Values.ToArray());
            // xml.CanSavePathXml(pnode, pmember, pmember, pmember, pval)
        }
    }
}