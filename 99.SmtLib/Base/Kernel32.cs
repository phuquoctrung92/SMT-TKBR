using System;

namespace SmtLib
{

    public abstract class kernel32
    {

        private const string DllName = "kernel32";

        private string IniFile;

        public kernel32(string pFile)
        {
            IniFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, pFile);
        }

        #region  GetPrivateProfileInt 

        // 指定された .ini ファイル（初期化ファイル）の指定されたセクション内にある、指定されたキーに関連付けられている整数を取得します。
        // 
        // UINT GetPrivateProfileInt(
        // LPCTSTR lpAppName,  // セクション名
        // LPCTSTR lpKeyName,  // キー名
        // INT nDefault,       // キー名が見つからなかった場合に返すべき値
        // LPCTSTR lpFileName  // .ini ファイルの名前
        // );
        [System.Runtime.InteropServices.DllImport(DllName, CharSet = System.Runtime.InteropServices.CharSet.Auto)]

        private static extern int GetPrivateProfileInt([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)] string lpAppName, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)] string lpKeyName, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.I4)] int nDefault, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)] string lpFileName);





        #endregion

        #region  GetPrivateProfileString 

        // 指定された .ini ファイル（初期化ファイル）の指定されたセクション内にある、指定されたキーに関連付けられている文字列を取得します。
        // 
        // DWORD GetPrivateProfileString(
        // LPCTSTR lpAppName,        // セクション名
        // LPCTSTR lpKeyName,        // キー名
        // LPCTSTR lpDefault,        // 既定の文字列
        // LPTSTR lpReturnedString,  // 情報が格納されるバッファ
        // DWORD nSize,              // 情報バッファのサイズ
        // LPCTSTR lpFileName        // .ini ファイルの名前
        // );
        [System.Runtime.InteropServices.DllImport(DllName, CharSet = System.Runtime.InteropServices.CharSet.Auto)]

        private static extern int GetPrivateProfileString([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)] string lpAppName, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)] string lpKeyName, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)] string lpDefault, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)] System.Text.StringBuilder lpReturnedString, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)] int nSize, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)] string lpFileName);







        #endregion

        #region  WritePrivateProfileString 

        // 指定された .ini ファイル（初期化ファイル）の、指定されたセクション内に、指定されたキー名とそれに関連付けられた文字列を格納します。
        // 
        // BOOL WritePrivateProfileString(
        // LPCTSTR lpAppName,  // セクション名
        // LPCTSTR lpKeyName,  // キー名
        // LPCTSTR lpString,   // 追加するべき文字列
        // LPCTSTR lpFileName  // .ini ファイル
        // );
        [System.Runtime.InteropServices.DllImport(DllName, CharSet = System.Runtime.InteropServices.CharSet.Auto)]

        private static extern bool WritePrivateProfileString([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)] string lpAppName, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)] string lpKeyName, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)] string lpString, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)] string lpFileName);





        #endregion

        /// <summary>
    /// .ini ファイルより、指定されたセクション、キーに関連付いた値を取得します。
    /// </summary>
        protected int IniReadKeyInteger(string sectionName, string keyName, int defaultValue = 0)
        {

            return GetPrivateProfileInt(sectionName, keyName, defaultValue, IniFile);

        }

        /// <summary>
    /// .ini ファイルより、指定されたセクション、キーに関連付いた値を取得します。
    /// </summary>
        protected string IniReadKeyString(string sectionName, string keyName, string defaultValue = null)
        {

            System.Text.StringBuilder buffer;
            int length;
            int endCharCount;

            // 
            if (sectionName is not null && keyName is not null)
            {
                // lpAppName と lpKeyName パラメータのどちらも NULL ではない場合、バッファのサイズが不足して、要求された文字列全体を格納できないと、文字列は途中で切り捨てられ、最後に 1 個の NULL 文字が追加され、戻り値は nSize-1 の値になります。
                endCharCount = 1;
            }
            else
            {
                // lpAppName または lpKeyName パラメータのどちらかが NULL の場合、バッファのサイズが不足して、要求された文字列全体を格納できないと、文字列は途中で切り捨てられ、最後に 2 個の NULL 文字が追加され、戻り値は nSize-2 の値になります。
                endCharCount = 2;
            }

            buffer = new System.Text.StringBuilder(1024);
            length = GetPrivateProfileString(sectionName, keyName, defaultValue, buffer, buffer.Capacity, IniFile);
            while (buffer.Capacity - endCharCount == length)
            {
                buffer.Capacity = buffer.Capacity << 1;
                length = GetPrivateProfileString(sectionName, keyName, defaultValue, buffer, buffer.Capacity, IniFile);
            }

            return buffer.ToString();

        }

        /// <summary>
    /// .ini ファイルへ、指定されたセクション、キーに関連付いた値を設定します。
    /// </summary>
        protected bool IniWriteKeyString(string sectionName, string keyName, string value)
        {

            return WritePrivateProfileString(sectionName, keyName, value, IniFile);

        }

    }
}