using System;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace SmtLib
{

    /// <summary>
    /// チェック関数
    /// </summary>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class ClsCheck
    {
        #region Method
        /// <summary> 文字数(バイト)を取得します。(Shift_JIS) </summary>
        /// <param name="_value"> チェックしたい値 </param>
        /// <returns> 文字数 </returns>
        public static int GetLengthAsByte(string _value)
        {
            return Const_Encoding.ShiftJIS.GetByteCount(_value);
        }

        /// <summary> WindowsのKeyPress イベントで入力されたキーコードがEmail判断 </summary>
        /// <param name="c"> 入力キーコード </param>
        /// <returns> True:数値 False:数値以外 </returns>
        public static bool IsEmailKey(char c)
        {
            return (Strings.AscW(c) >= Strings.AscW("0") && Strings.AscW(c) <= Strings.AscW("9") || Strings.AscW(c) >= Strings.AscW("A") && Strings.AscW(c) <= Strings.AscW("Z") || Strings.AscW(c) >= Strings.AscW("a") && Strings.AscW(c) <= Strings.AscW("z") || Strings.AscW(c) == Strings.AscW("-") || Strings.AscW(c) == Strings.AscW("@") || Strings.AscW(c) == Strings.AscW(".") || Strings.AscW(c) == Strings.AscW("_"));
        }

        /// <summary> WindowsのKeyPress イベントで入力されたキーコードがFILE入力の判断 </summary>
        /// <param name="c"> 入力キーコード </param>
        /// <returns> True:FILE入力に適しているキー False:FILE入力に不適なキー </returns>
        public static bool IsFileKey(char c)
        {
            return !(Strings.AscW(c) == Strings.AscW("*") || Strings.AscW(c) == Strings.AscW("'") || Strings.AscW(c) == Strings.AscW("/") || Strings.AscW(c) == Strings.AscW("|") || Strings.AscW(c) == Strings.AscW("<") || Strings.AscW(c) == Strings.AscW(">"));
        }

        /// <summary> WindowsのKeyPress イベントで入力されたキーコードがカナの判断 </summary>
        /// <param name="c"> 入力キーコード </param>
        /// <returns> True:カナ False:カナ以外 </returns>
        public static bool IsKanaKey(char c)
        {
            return (Strings.AscW(c) >= Strings.AscW("ｦ") && Strings.AscW(c) <= Strings.AscW("ﾝ") || Strings.AscW(c) == Strings.AscW("ﾟ") || Strings.AscW(c) == Strings.AscW("ﾞ"));
        }

        /// <summary> 半角文字かチェックし、値をブール型(Boolean)の値で返します。 </summary>
        /// <param name="_source"> チェックしたい値 </param>
        /// <param name="_allow_empty"> Nullチェック </param>
        /// <returns> True:OK False:NG </returns>
        public static bool IsNarrow(string _source, bool _allow_empty = true)
        {
            string strValue;

            if (IsNull(_source))
            {
                return _allow_empty;
            }

            // 半角文字チェック
            for (int intCnt = 1, loopTo = _source.Length; intCnt <= loopTo; intCnt++)
            {
                strValue = Strings.Mid(_source, intCnt, 1);
                if (Strings.Len(Conversion.Hex(Strings.Asc(strValue))) > 2)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary> 半角英字かチェックし、値をブール型(Boolean)の値で返します。 </summary>
        /// <param name="_source"> チェックしたい値 </param>
        /// <param name="_allow_empty"> Nullチェック </param>
        /// <returns> True:OK False:NG </returns>
        public static bool IsNarrowAlpha(object _source, bool _allow_empty = true)
        {
            if (IsNull(_source))
            {
                return _allow_empty;
            }
            else if (Regex.IsMatch(_source.ToString(), "^[a-zA-Z]+$"))
            {
                return true;
            }

            return false;
        }

        // <System.Obsolete(".NET Framework 4.0 以降では String.IsNullOrWhiteSpace を使用してください。")> _
        /// <summary>Nullかをチェック</summary>
        /// <param name="value">チェックしたい値</param>
        /// <returns> True:OK False:NG </returns>
        public static bool IsNull(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary> Nothing又はNULL又は空白文字列かチェックし、値をブール型(Boolean)の値で返します。 </summary>
        /// <param name="_value"> チェックしたい値 </param>
        /// <returns> True:OK False:NG </returns>
        public static bool IsNull(object _value)
        {
            // Nothing判定
            // NULL
            // 空文字("")判定
            if (_value == null || _value is DBNull || string.IsNullOrEmpty(_value.ToString()))
            {
                return true;
            }
            return false;
        }

        /// <summary> WindowsのKeyPress イベントで入力されたキーコードが数字判断 </summary>
        /// <param name="c"> 入力キーコード </param>
        /// <returns> True:数値 False:数値以外 </returns>
        public static bool IsNumberKey(char c)
        {
            if (Strings.AscW(c) >= Strings.AscW("0") & Strings.AscW(c) <= Strings.AscW("9"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary> 半角英数字かチェックし、値をブール型(Boolean)の値で返します。 </summary>
        /// <param name="_source"> チェックしたい値 </param>
        /// <param name="_allow_empty"> Nullチェック </param>
        /// <returns> True:OK False:NG </returns>
        public static bool IsNumericAlpha(object _source, bool _allow_empty = true)
        {
            if (IsNull(_source))
            {
                return _allow_empty;
            }
            else if (Regex.IsMatch(_source.ToString(), "^[a-zA-Z0-9]+$"))
            {
                return true;
            }

            return false;
        }

        /// <summary> WindowsのKeyPress イベントで入力されたキーコードが数値判断 </summary>
        /// <param name="c"> 入力キーコード </param>
        /// <returns> True:数値 False:数値以外 </returns>
        public static bool IsNumericKey(char c)
        {
            if (Strings.AscW(c) >= Strings.AscW("0") & Strings.AscW(c) <= Strings.AscW("9") || Strings.AscW(c) == Strings.AscW("-") || Strings.AscW(c) == Strings.AscW(","))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary> 禁則文字列(","又は"'"又はTab)が含まれているかチェックし、値をブール型(Boolean)の値で返します。 </summary>
        /// <param name="_source"> チェックしたい値 </param>
        /// <param name="_check_value"> 指定文字列が入れる </param>
        /// <param name="_allow_quotation"> クォーテーションが入れる </param>
        /// <param name="_allow_VerticalBar"> バーティカルバーが入れる </param>
        /// <returns> True:禁則文字あり False:禁則文字なし </returns>
        public static bool IsProhibitionCharacter(string _source, string _check_value = "", bool _allow_quotation = false, bool _allow_VerticalBar = true)
        {
            int error_count = 0;

            if (!_allow_quotation)
            {
                error_count += Strings.InStr(1, _source, ConstLib.STR_SINGLECORTATION);
                error_count += Strings.InStr(1, _source, ConstLib.STR_DOUBLECORTATION);
            }
            if (!_allow_VerticalBar)
            {
                error_count += Strings.InStr(1, _source, ConstLib.STR_VERTICALBAR);
            }
            if (!string.IsNullOrEmpty(_check_value))
            {
                error_count += Strings.InStr(1, _source, _check_value);
            }
            error_count += Strings.InStr(1, _source, Conversions.ToString(ControlChars.Tab));

            if (error_count == 0)
            {
                return false;
            }
            else
            {
                // 禁則文字が含まれていればエラー
                return true;
            }
        }

        /// <summary> WindowsのKeyPress イベントで入力されたキーコードが入力可能記号の判断 </summary>
        /// <param name="c"> 入力キーコード </param>
        /// <returns> True:記号 False:以外 </returns>
        public static bool IsSignKey(char c)
        {
            if (Strings.AscW(c) == Strings.AscW("･") || Strings.AscW(c) == Strings.AscW("(") || Strings.AscW(c) == Strings.AscW(")") || Strings.AscW(c) == Strings.AscW("&") || Strings.AscW(c) == Strings.AscW(".") || Strings.AscW(c) == Strings.AscW("_") || Strings.AscW(c) == Strings.AscW(":") || Strings.AscW(c) == Strings.AscW("-"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary> WindowsのKeyPress イベントで入力されたキーコードが数値判断 </summary>
        /// <param name="c"> 入力キーコード </param>
        /// <returns> True:数値 False:数値以外 </returns>
        public static bool IsTellKey(char c)
        {
            if (Strings.AscW(c) >= Strings.AscW("0") & Strings.AscW(c) <= Strings.AscW("9") || Strings.AscW(c) == Strings.AscW("-") || Strings.AscW(c) == Strings.AscW("(") || Strings.AscW(c) == Strings.AscW(")"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary> 電話番号かチェックし、値をブール型(Boolean)の値で返します。 </summary>
        /// <param name="_source"> チェックしたい値 </param>
        /// <returns> True:OK False:NG </returns>
        public static bool IsTelNo(object _source)
        {
            if (!IsNull(_source) && Regex.IsMatch(_source.ToString(), @"^[0-9\-\(\)]+$"))
            {
                return true;
            }

            return false;
        }

        /// <summary> WindowsのKeyPress イベントで入力されたキーコードが数値判断 </summary>
        /// <param name="c"> 入力キーコード </param>
        /// <returns> True:数値 False:数値以外 </returns>
        public static bool IsZipKey(char c)
        {
            if (Strings.AscW(c) >= Strings.AscW("0") & Strings.AscW(c) <= Strings.AscW("9") || Strings.AscW(c) == Strings.AscW("-"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary> 半角数字かチェックし、値をブール型(Boolean)の値で返します。 </summary>
        /// <param name="_source"> チェックしたい値 </param>
        /// <param name="_allow_empty"> Nullチェック </param>
        /// <returns> True:OK False:NG </returns>
        public static bool IsNumeric(string _source, bool _allow_empty = true)
        {
            if (IsNull(_source))
            {
                return _allow_empty;
            }
            else if (Regex.IsMatch(_source.ToString(), "[0-9]+"))
            {
                return true;
            }

            return false;
        }

        /// <summary> 半角数字とドット.かチェックし、値をブール型(Boolean)の値で返します。 </summary>
        /// <param name="_source"> チェックしたい値 </param>
        /// <param name="_allow_empty"> Nullチェック </param>
        /// <returns> True:OK False:NG </returns>
        public static bool IsDecimal(string _source, bool _allow_empty = true)
        {

            if (IsNull(_source))
            {
                return _allow_empty;
            }
            else if (Regex.IsMatch(_source.ToString(), @"^\d+(\.\d+)?$"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 精度チェック
        /// </summary>
        /// <param name="teigi">4.1とか</param>
        /// <param name="value">値</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsCheckSeido(string teigi, string value)
        {
            try
            {
                string[] strArray = teigi.ToString().Split('.');

                return IsCheckSeido(ClsConvert.ToInteger(strArray[0]), ClsConvert.ToInteger(strArray[1]), value);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 精度チェック
        /// </summary>
        /// <param name="_int">整数部の桁数</param>
        /// <param name="_dec">小数部の桁数</param>
        /// <param name="value">値</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static bool IsCheckSeido(int _int, int _dec, string value)
        {
            string[] strArray = value.ToString().Split('.');

            if (strArray[0].Length > _int || (strArray.Length > 1 && strArray[1].Length > _dec))
            {
                return false;
            }

            return true;
        }
        #endregion

    }
}