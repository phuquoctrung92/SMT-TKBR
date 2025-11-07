using System;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace SmtLib
{

    /// <summary>
    /// 変換関連
    /// </summary>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class ClsConvert
    {
        #region Variable Value
        /// <summary>日本のフォーマット</summary>
        public static readonly System.Globalization.CultureInfo ja_JP = System.Globalization.CultureInfo.GetCultureInfo(1041);

        #endregion

        #region Method

        /// <summary>
        /// 文字列の右端から指定されたバイト数分の文字列を返します。
        /// </summary>
        /// <param name="sTarget">取り出す元になる文字列</param>
        /// <param name="iByteSize">取り出すバイト数</param>
        /// <returns>右端から指定されたバイト数分の文字列</returns>
        public static string RightB(string sTarget, int iByteSize)
        {
            try
            {
                if (sTarget.Equals(string.Empty))
                    return string.Empty;

                System.Text.Encoding hEncoding = System.Text.Encoding.GetEncoding("Shift_JIS");
                byte[] bBytes = hEncoding.GetBytes(sTarget);

                return hEncoding.GetString(bBytes, bBytes.Length - iByteSize, iByteSize);
            }
            catch
            {
                return sTarget;
            }
        }

        /// <summary> Mid関数のバイト版。文字数と位置をバイト数で指定して文字列を切り抜く。 </summary>
        /// <param name="_source"> 対象の文字列 </param>
        /// <param name="_start"> 切り抜き開始位置。全角文字を分割するよう位置が指定された場合、戻り値の文字列の先頭は意味不明の半角文字となる。 </param>
        /// <param name="_length"> 切り抜く文字列のバイト数 </param>
        /// <returns> 切り抜かれた文字列 </returns>
        /// <remarks> 最後の１バイトが全角文字の半分になる場合、その１バイトは無視される。 </remarks>
        public static string MidB(string _source, int _start, [Optional, DefaultParameterValue(0)] ref int _length)
        {
            // 空文字に対しては常に空文字を返す
            if (string.IsNullOrEmpty(_source))
            {
                return "";
            }

            // Lengthのチェック
            // Lengthが0か、Start以降のバイト数をオーバーする場合はStart以降の全バイトが指定されたものとみなす。
            int result_length = Const_Encoding.ShiftJIS.GetByteCount(_source) - _start;
            if (_length == 0 || _length > result_length)
            {
                _length = result_length;
            }

            // 切り抜き
            byte[] bytes = (byte[])Array.CreateInstance(typeof(byte), _length);

            Array.Copy(Const_Encoding.ShiftJIS.GetBytes(_source), _start, bytes, 0, _length);

            string encoding_value = Const_Encoding.ShiftJIS.GetString(bytes);

            // 切り抜いた結果、最後の１バイトが全角文字の半分だった場合、その半分は切り捨てる。
            result_length = Const_Encoding.ShiftJIS.GetByteCount(encoding_value) - _start;

            if (Strings.Asc(Strings.Right(encoding_value, 1)) == 0)
            {
                // VB.NET2002,2003の場合、最後の１バイトが全角の半分の時
                _length = _length - 1;
                return encoding_value.Substring(0, encoding_value.Length - 1);
            }
            else if (_length == result_length - 1)
            {
                // VB2005の場合で最後の１バイトが全角の半分の時
                _length = _length - 1;
                return encoding_value.Substring(0, encoding_value.Length - 1);
            }
            else
            {
                // その他の場合
                return encoding_value;
            }
        }

        /// <summary>
        /// 文字列のバイト数を取得する
        /// </summary>
        /// <returns></returns>
        public static int LenB(string _source)
        {
            // 空文字は0
            if (string.IsNullOrEmpty(_source))
            {
                return 0;
            }
            return Const_Encoding.ShiftJIS.GetByteCount(_source);
        }


        /// <summary> 文字列を Date 型へ変換します。 </summary>
        /// <param name="_source">文字列</param>
        /// <param name="_default"> 既定値は Null ではなく、0 と等価の Date値(#12:00:00 AM#)を返します。 </param>
        /// <param name="_style"> 既定値は 文字列の前後の空白を許容します。 </param>
        public static DateTime ToDate(string _source, DateTime _default = default, System.Globalization.DateTimeStyles _style = System.Globalization.DateTimeStyles.AllowLeadingWhite | System.Globalization.DateTimeStyles.AllowTrailingWhite)
        {
            DateTime result;
            return DateTime.TryParse(_source, ja_JP, _style, out result) ? result : _default;
        }

        /// <summary> 文字列を指定した書式と完全に一致する Date 型の値へ変換します。 </summary>
        /// <param name="_source">指定した文字列</param>
        /// <param name="_format"> 必要な書式。 ex. "yyyy/MM/dd HH:mm:ss" </param>
        /// <param name="_default"> 既定値は Null ではなく、0 と等価の Date値を返します。 </param>
        public static DateTime ToDateExact(string _source, string _format, DateTime _default = default)
        {
            const System.Globalization.DateTimeStyles style = System.Globalization.DateTimeStyles.None;
            DateTime result;
            return (!string.IsNullOrEmpty(_source) && DateTime.TryParseExact(_source, _format, ja_JP, style, out result)) ? result : _default;
        }

        /// <summary> 文字列を Decimal 型へ変換します。 </summary>
        /// <param name="_source"></param>
        /// <param name="_default"></param>
        /// <param name="_style"></param>
        public static decimal ToDecimal(string _source, decimal _default = 0m, System.Globalization.NumberStyles _style = System.Globalization.NumberStyles.Number)
        {
            decimal result;
            return decimal.TryParse(_source, _style, ja_JP, out result) ? result : _default;
        }

        /// <summary> 文字列を Double 型へ変換します。 </summary>
        /// <param name="_source"></param>
        /// <param name="_default"></param>
        /// <param name="_style"></param>
        public static double ToDouble(string _source, double _default = 0.0d, System.Globalization.NumberStyles _style = System.Globalization.NumberStyles.Number)
        {
            double result;
            return double.TryParse(_source, _style, ja_JP, out result) ? result : _default;
        }

        /// <summary> 文字列を Integer 型へ変換します。 </summary>
        /// <param name="_source"></param>
        /// <param name="_default"></param>
        /// <param name="_style"></param>
        public static int ToInteger(string _source, int _default = 0, System.Globalization.NumberStyles _style = System.Globalization.NumberStyles.Number)
        {
            int result;
            return int.TryParse(_source, _style, ja_JP, out result) ? result : _default;
        }

        /// <summary>日付からテキストに変換</summary>
        /// <param name="dt">日付</param>
        /// <param name="format">フォーマット</param>
        /// <param name="defaultValue">変換が失敗に返す値</param>
        /// <returns>文字列</returns>
        public static string DateTimeToString(object dt, string format, string defaultValue = "")
        {
            try
            {
                if (dt == null)
                    return defaultValue;

                return dt is DateTime ? ((DateTime)dt).ToString(format) : DateTime.Parse(dt.ToString()).ToString(format);
            }
            catch
            {
                //例外が発生されたらdefaultValueを返す
                return defaultValue;
            }
        }


        /// <summary>NULLできる整数に変換</summary>
        /// <param name="_source">変換したい値</param>
        /// <returns>NULLできる整数</returns>
        public static int? ToNullableInteger(string _source)
        {
            int result;
            return int.TryParse(_source, out result) ? result : default;
        }

        /// <summary> 文字列を Long 型へ変換します。 </summary>
        /// <param name="_source">変換したい値</param>
        /// <param name="_default">変換できない時にdefault値を返す</param>
        /// <param name="_style">数字種別</param>
        public static long ToLong(string _source, long _default = 0L, System.Globalization.NumberStyles _style = System.Globalization.NumberStyles.Number)
        {
            long result;
            return long.TryParse(_source, _style, ja_JP, out result) ? result : _default;
        }

        /// <summary> 全角変換 </summary>
        /// <param name="_source"> 文字列 </param>
        /// <returns> 整形された文字列 </returns>
        public static string ToKanaWide(string _source)
        {
            int i;
            string s;
            string RetStr = string.Empty;

            if (string.IsNullOrEmpty(_source))
            {
                return string.Empty;
            }

            var loopTo = Strings.Len(_source);
            for (i = 1; i <= loopTo; i += 1)
            {
                s = Strings.Mid(_source, i, 1);
                if (Strings.Asc(s) == Strings.Asc(' ') | Strings.Asc(s) >= Strings.Asc(Strings.Chr(166)) & Strings.Asc(s) <= Strings.Asc(Strings.Chr(221)))
                {
                    // 半角カナ、スペースの場合全角に変換
                    s = Strings.StrConv(s, Microsoft.VisualBasic.Constants.vbWide);
                }
                RetStr += s;
            }
            return RetStr;
        }

        /// <summary> 文字列を Short 型へ変換します。 </summary>
        /// <param name="_source"> 変換する数値を格納する文字列。 </param>
        /// <param name="_default"> 変換できない場合に返す値を指定します。 </param>
        /// <param name="_style">
        /// <para> 使用可能な書式を示す、System.Globalization.NumberStyles 値のビットごとの組み合わせ。通常指定する値は、System.Globalization.NumberStyles.Integer です。 </para>
        /// <para> (規定値 'Number' は小数点とカンマ編集を許可します。) </para>
        /// </param>
        /// <remarks>
        /// Short型に対応した変換関数がなかったので用意。
        /// TryParse を使うことで CShort よりパフォーマンスが良く、例外も出しません。
        /// CShort, CInt, CDbl, CDec との違いとして、指数表記、16進数表記を許可しない点があります。(style で指定可能です)
        /// 変換できるかどうかのみを取得したい時は、TryParse を使う。
        /// さらに詳しい書式を調べるなら IsMatch を使う。
        /// </remarks>
        public static short ToShort(string _source, short _default = 0, System.Globalization.NumberStyles _style = System.Globalization.NumberStyles.Number)
        {
            short result;
            return short.TryParse(_source, _style, ja_JP, out result) ? result : _default;
        }

        /// <summary> 文字列を Boolean 型へ変換します。 </summary>
        /// <param name="_source"></param>
        /// <param name="_default"></param>
        public static bool ToBoolean(string _source, bool _default = false)
        {
            bool result;
            return bool.TryParse(_source, out result) ? result : _default;
        }
        #endregion

        /// <summary>大文字と全角に変換</summary>
        /// <param name="_value">変換したい値</param>
        /// <returns>文字列</returns>
        public static string StringConvWideAndUpper(object _value)
        {
            if (ClsCheck.IsNull(_value))
            {
                return string.Empty;
            }

            string wk = Conversions.ToString(_value);
            wk = Strings.StrConv(wk, VbStrConv.Uppercase);
            return Strings.StrConv(wk, VbStrConv.Wide);
        }

        /// <summary>全角に変換</summary>
        /// <param name="_value">変換したい値</param>
        /// <returns>文字列</returns>
        public static string StringConvWide(object _value)
        {
            if (ClsCheck.IsNull(_value))
            {
                return string.Empty;
            }

            return Strings.StrConv(Conversions.ToString(_value), VbStrConv.Wide);
        }

    }
}