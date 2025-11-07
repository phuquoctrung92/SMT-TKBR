using System;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace SmtLib
{
    /// <summary>
    /// 共通
    /// </summary>
    public class clsCommon
    {
        /// <summary>
        /// データベースの接続文字列
        /// </summary>
        /// <returns></returns>
        public static string ConnectionString()
        {
            return string.Format("Data Source={0}; Initial Catalog={1}; User Id={2}; Password={3};", xmlSystem.SQLServer_Host, xmlSystem.SQLServer_Database, xmlSystem.SQLServer_UserID, xmlSystem.SQLServer_Password);
        }

        /// <summary>
        /// 指定フォルダーに画像をアップ
        /// </summary>
        /// <param name="img">画像</param>
        /// <param name="folderPath">指定フォルダー</param>
        /// <param name="filename">画像の名前</param>
        public static void UploadImage(Image img, string folderPath, string filename)
        {
            using (var ms = new MemoryStream())
            {
                byte[] b;
                img.Save(ms, img.RawFormat);
                b = ms.ToArray();

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                File.WriteAllBytes(Path.Combine(folderPath, filename), b);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public static Point CalcLeftTop(System.Windows.Forms.Form owner, System.Windows.Forms.Form client)
        {

            var lt = default(Point);
            double widthHalf = (owner.Width - client.Width) / 2d;
            double heightHalf = (owner.Height - client.Height) / 2d;
            lt.X = (int)Math.Round(owner.Location.X + widthHalf);
            lt.Y = (int)Math.Round(owner.Location.Y + heightHalf);
            var scrn = System.Windows.Forms.Screen.FromControl(owner);
            if (lt.X < 0)
            {
                lt.X = 0;
            }
            else if (lt.X > scrn.Bounds.Width - client.Width)
            {
                lt.X = scrn.Bounds.Width - client.Width;
            }
            if (lt.Y < 0)
            {
                lt.Y = 0;
            }
            else if (lt.Y > scrn.Bounds.Height - client.Height)
            {
                lt.Y = scrn.Bounds.Height - client.Height;
            }
            return lt;

        }

        /// <summary>
        /// JIS8コードからテキストに変換
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string JIS8ToString(ushort code)
        {
            string hex = code.ToString("X");
            var b = new byte[(int)Math.Round(hex.Length / 2d - 1d + 1)];
            for (int i = 0, loopTo = hex.Length - 1; i <= loopTo; i += 2)
                b[(int)Math.Round(i / 2d)] = Convert.ToByte(Conversions.ToString(hex[i]) + hex[i + 1], 16);

            return Encoding.GetEncoding(932).GetString(b);
        }
        /// <summary>
        /// JIS8コードからテキストに変換
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string[] JIS8ToString(ushort[] code)
        {
            var ret = new string[code.Length];

            for (int i = 0, loopTo = code.Length - 1; i <= loopTo; i++)
                ret[i] = JIS8ToString(code[i]);

            return ret;
        }
        /// <summary>
        /// 文字からJISHEXに変換
        /// </summary>
        /// <param name="c">文字</param>
        /// <returns></returns>
        public static string CharToJISHex(char c)
        {
            byte[] jis = Encoding.GetEncoding(932).GetBytes(Conversions.ToString(c));
            string hex = jis[0].ToString("X");
            return hex;
        }
        /// <summary>
        /// 文字列からJISHEXに変換
        /// </summary>
        /// <param name="c">文字列</param>
        /// <returns></returns>
        public static string CharToJISHex(char[] c)
        {
            string hex = "";
            for (int i = 0, loopTo = c.Length - 1; i <= loopTo; i++)
                hex += CharToJISHex(c[i]);

            return hex;
        }
        /// <summary>
        /// 16進数から数字に変換
        /// </summary>
        /// <param name="hex">16進数</param>
        /// <returns></returns>
        public static ushort HexToDecimal(string hex)
        {
            return ushort.Parse(hex.Trim(), System.Globalization.NumberStyles.HexNumber);
        }

        /// <summary>
        /// 数字から通貨に変換
        /// </summary>
        /// <param name="number">数字</param>
        /// <param name="unit">通貨単位（ex: 円、＄）</param>
        /// <returns></returns>
        public static string NumberToCurrency(object number, string unit = "")
        {
            string currency = string.Format("{0:N0}", number);
            currency += !string.IsNullOrEmpty(currency) ? unit : "";
            return currency;
        }

        /// <summary>
        /// 有効なメールアドレスかをチェック
        /// </summary>
        /// <param name="email">メールアドレス</param>
        /// <returns>True: 有効。False: 無効</returns>
        public static bool isValidEmailAddress(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return (addr.Address ?? "") == (email ?? "");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 整数かをチェック
        /// </summary>
        /// <param name="text">チェックデータ</param>
        /// <returns>True: 有効。False: 無効</returns>
        public static bool isInteger(string text)
        {
            try
            {
                return int.TryParse(text, out int result);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// １０進数かをチェック
        /// </summary>
        /// <param name="text">チェックデータ</param>
        /// <returns>True: 有効。False: 無効</returns>
        public static bool isDecimal(string text)
        {
            try
            {
                return decimal.TryParse(text, out decimal result);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 日付から曜日を取得（日本）
        /// </summary>
        /// <param name="date">日付</param>
        /// <returns>曜日</returns>
        public static string DayOfWeek(string date)
        {
            try
            {
                string result = "";

                DateTime dt = DateTime.Parse(date);
                result = dt.ToString("yyyy/MM/dd");
                switch (dt.DayOfWeek)
                {
                    case System.DayOfWeek.Sunday:
                        result += "（日）";
                        break;
                    case System.DayOfWeek.Monday:
                        result += "（月）";
                        break;
                    case System.DayOfWeek.Tuesday:
                        result += "（火）";
                        break;
                    case System.DayOfWeek.Wednesday:
                        result += "（水）";
                        break;
                    case System.DayOfWeek.Thursday:
                        result += "（木）";
                        break;
                    case System.DayOfWeek.Friday:
                        result += "（金）";
                        break;
                    case System.DayOfWeek.Saturday:
                        result += "（土）";
                        break;
                }
                return result;
            }
            catch
            {
                return "";
            }

        }

        /// <summary>
        /// 日付から曜日を取得（US）
        /// </summary>
        /// <param name="dt">日付</param>
        /// <returns>曜日</returns>
        public static string DayOfWeek_En(DateTime dt)
        {
            try
            {
                string result = "";

                switch (dt.DayOfWeek)
                {
                    case System.DayOfWeek.Sunday:
                        result = "Sunday";
                        break;
                    case System.DayOfWeek.Monday:
                        result = "Monday";
                        break;
                    case System.DayOfWeek.Tuesday:
                        result = "Tuesday";
                        break;
                    case System.DayOfWeek.Wednesday:
                        result = "Wednesday";
                        break;
                    case System.DayOfWeek.Thursday:
                        result = "Thursday";
                        break;
                    case System.DayOfWeek.Friday:
                        result = "Friday";
                        break;
                    case System.DayOfWeek.Saturday:
                        result = "Saturday";
                        break;
                }
                return result;
            }
            catch
            {
                return "";
            }
        }
    }
}