using System;
using System.Collections;
using Microsoft.VisualBasic.CompilerServices;

namespace SmtLib
{
    /// <summary>比較共通機能</summary>
    public static class Comparer
    {
        /// <summary>文字列を比較</summary>
        /// <param name="x">比較値１</param>
        /// <param name="y">比較値２</param>
        /// <returns></returns>
        public static int String(object x, object y)
        {
            string sx = "";
            string sy = "";

            if (x is not null)
            {
                sx = x.ToString();
            }

            if (y is not null)
            {
                sy = y.ToString();
            }

            // Nothingが最も小さいとする
            if (string.IsNullOrEmpty(sx) && string.IsNullOrEmpty(sy))
            {
                return 0;
            }
            if (string.IsNullOrEmpty(sx))
            {
                return -1;
            }
            if (string.IsNullOrEmpty(sy))
            {
                return 1;
            }

            return string.Compare(sx, sy);
        }

        /// <summary>数字を比較</summary>
        /// <param name="x">比較値１</param>
        /// <param name="y">比較値２</param>
        /// <returns></returns>
        public static int Number(object x, object y)
        {
            double? nx = default;
            double? ny = default;
            double dx;
            double dy;
            if (double.TryParse(Conversions.ToString(x), out dx))
            {
                nx = dx;
            }
            if (double.TryParse(Conversions.ToString(y), out dy))
            {
                ny = dy;
            }

            // Nothingが最も小さいとする
            if (nx is null && ny is null)
            {
                return 0;
            }
            if (nx is null)
            {
                return -1;
            }
            if (ny is null)
            {
                return 1;
            }

            if (nx.Value > ny.Value)
            {
                return 1;
            }
            else if (nx.Value < ny.Value)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 日付を比較
        /// </summary>
        /// <param name="x">比較値１</param>
        /// <param name="y">比較値２</param>
        /// <returns></returns>
        public static int Date(object x, object y)
        {
            DateTime dx = DateTime.MinValue;
            DateTime dy = DateTime.MinValue;

            DateTime.TryParse(Conversions.ToString(x), out dx);
            DateTime.TryParse(Conversions.ToString(y), out dy);

            // Nothingが最も小さいとする
            if (dx == DateTime.MinValue && dy == DateTime.MinValue)
            {
                return 0;
            }
            if (dx == DateTime.MinValue)
            {
                return -1;
            }
            if (dy == DateTime.MinValue)
            {
                return 1;
            }

            if (dx > dy)
            {
                return 1;
            }
            else if (dx < dy)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}