using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SmtLib
{

    /// <summary>
    /// Utilクラス
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class ClsUtil
    {
        #region Method

        /// <summary> Exeの実行 </summary>
        /// <param name="_target"> 起動するExe名 </param>
        /// <param name="_argument_list"> 起動引数 </param>
        /// <param name="isWaitForExit">プロセスの完了までに待ちる</param>
        public static int ExecuteProgram(string _target, ArrayList _argument_list = null, bool isWaitForExit = false)
        {
            var process = new Process();
            string execute_path = System.Windows.Forms.Application.StartupPath;

            try
            {
                // 起動するExeを設定
                process.StartInfo.FileName = string.Format(@"{0}\{1}" + ConstLib.EXTENSION_EXE, execute_path, _target);

                // ファイルの存在チェック
                if (!ClsFile.IsExist(process.StartInfo.FileName))
                {
                    return -1;
                }

                // 渡す値がある場合セットする
                if (_argument_list is not null)
                {
                    process.StartInfo.Arguments = string.Join(" ", (string[])_argument_list.ToArray(typeof(string)));
                }

                process.Start();

                if (isWaitForExit)
                    process.WaitForExit();

                return 0;
            }
            catch
            {
                return int.MinValue;
            }
            finally
            {
                process.Close();
                process.Dispose();
            }

        }

        /// <summary> 端数処理(切り捨て) </summary>
        /// <param name="_value"> 処理対象数値 </param>
        /// <param name="_digit"> 小数点有効桁数 </param>
        /// <returns> 切り捨てされた値 </returns>
        public static decimal ToRoundDown(decimal _value, decimal _digit)
        {
            decimal decCoef = ClsConvert.ToDecimal(Math.Pow(10d, (double)_digit).ToString());
            decimal decCalc = _value;

            decCalc = decimal.Multiply(decCalc, decCoef);
            decCalc = Conversion.Fix(decCalc);
            decCalc = decimal.Divide(decCalc, decCoef);

            return decCalc;
        }

        /// <summary> 端数処理(切り上げ) </summary>
        /// <param name="_value"> 処理対象数値 </param>
        /// <param name="_digit"> 小数点有効桁数 </param>
        /// <returns> 切り上げされた値 </returns>
        public static double ToRoundUp(double _value, int _digit)
        {
            double dCoef = Math.Pow(10d, _digit);

            if (_value > 0d)
            {
                return Math.Ceiling(_value * dCoef) / dCoef;
            }
            else
            {
                return Math.Floor(_value * dCoef) / dCoef;
            }
        }

        /// <summary>
        /// 端数処理（四捨五入）
        /// </summary>
        /// <param name="value">処理対象数値</param>
        /// <param name="digits">小数点有効桁数</param>
        /// <returns>四捨五入された値</returns>
        /// <remarks></remarks>
        public static decimal ToHalfAjust(decimal value, double digits)
        {
            decimal decCoef = Convert.ToDecimal(Math.Pow(10.0d, digits));
            decimal decCalc = value;

            decCalc = decimal.Multiply(decCalc, decCoef);

            if (value > 0m)
            {
                decCalc = decimal.Add(decCalc, 0.5m);
            }
            else
            {
                decCalc = decimal.Subtract(decCalc, 0.5m);
            }

            decCalc = Conversion.Fix(decCalc);
            decCalc = decimal.Divide(decCalc, decCoef);

            return decCalc;
        }
        #endregion

    }
}