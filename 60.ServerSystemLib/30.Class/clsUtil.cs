using Microsoft.VisualBasic;
using SmtLib;
using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ServerSystemLib
{
    /// <summary>
    /// 大和屋向け共通処理クラス
    /// </summary>
    public class clsUtil
    {
        #region チェック処理関連
        public static Boolean IsNull(Object val)
        {
            if (val == null)
            {
                return true;
            }
            if (val == DBNull.Value)
            {
                return true;
            }

            return string.IsNullOrWhiteSpace(val.ToString());
        }

        public static Boolean IsNumeric(string val)
        {
            return Regex.IsMatch(val, @"^\d+$");
        }

        #endregion

        #region 共通処理
        public static byte[] convertFileToBinary(string filePath)
        {
            byte[] bytes = null;
            if (File.Exists(filePath))
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                }
            }
            return bytes;
        }

        public static bool moveFileToBK(FileInfo fInfo)
        {
            if (!string.IsNullOrEmpty(IniSVSetting.Torikomi_Path_BK))
            {
                if (!ClsDirectory.isExist(IniSVSetting.Torikomi_Path_BK) && !ClsDirectory.CreateDirectory(IniSVSetting.Torikomi_Path_BK))
                {
                    return false;
                }

                string fname = ClsFile.GetFileName(fInfo.FullName);
                string dir_name = ClsFile.GetDirectoryName(fInfo.FullName);
                string move_path = Path.Combine(dir_name, IniSVSetting.Torikomi_Path_BK, fname + ".bk");
                return ClsFile.Move(fInfo.FullName, move_path);
            }
            else
            {
                return ClsFile.Delete(fInfo.FullName);
            }
        }
        #endregion
    }
}
