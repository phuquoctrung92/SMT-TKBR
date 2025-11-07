using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CtrlLib.MyControls
{
    /// <summary>
    /// 背景色なしラベル
    /// </summary>
    public partial class TransparentLabel
    {
        /// <summary>
        /// 初期設定
        /// </summary>
        public TransparentLabel()
        {
            InitializeComponent();
        }

        private void UpdateRegion()
        {
            var r = new Region(ClientRectangle);
            int w = ClientSize.Width;
            int h = ClientSize.Height;

            // クライアント領域と同じ大きさの Bitmap クラスを生成します。
            var foreBitmap = new Bitmap(w, h, PixelFormat.Format32bppArgb);

            // 文字列を描画します。
            using (var g = Graphics.FromImage(foreBitmap))
            {
                using (var sb = new SolidBrush(ForeColor))
                {
                    var rect = new Rectangle(Padding.Left, Padding.Top, ClientRectangle.Width - Padding.Left - Padding.Right, ClientRectangle.Height - Padding.Top - Padding.Bottom);

                    g.DrawString(Text, Font, sb, rect);
                }
            }

            // できた Bitmap クラスからピクセルの色情報を取得します。
            var bd = foreBitmap.LockBits(ClientRectangle, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int stride = bd.Stride;
            int bytes = stride * h;
            byte[] bgraValues = new byte[bytes];
            Marshal.Copy(bd.Scan0, bgraValues, 0, bytes);
            foreBitmap.UnlockBits(bd);
            foreBitmap.Dispose();

            // 描画された部分だけの領域を作成します。
            for (int y = 0, loopTo = h - 1; y <= loopTo; y++)
            {
                int line = stride * y;
                for (int x = 0, loopTo1 = w - 1; x <= loopTo1; x++)
                {
                    // アルファ値が 0 は背景
                    if (bgraValues[line + x * 4 + 3] == 0)
                    {
                        r.Exclude(new Rectangle(x, y, 1, 1));
                    }
                }
            }

            // Region に文字列の領域を設定します。
            Region = r;
        }

        /// <summary>
        /// テキストを変更のイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            if (!DesignMode && BackColor == Color.Transparent)
            {
                UpdateRegion();
            }

            base.OnTextChanged(e);
        }

        /// <summary>
        /// コントロールのサイズを変更のイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if (!DesignMode && BackColor == Color.Transparent)
            {
                UpdateRegion();
            }

            base.OnSizeChanged(e);
        }

        /// <summary>
        /// コントロールのパディングを変更のイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaddingChanged(EventArgs e)
        {
            if (!DesignMode && BackColor == Color.Transparent)
            {
                UpdateRegion();
            }

            base.OnPaddingChanged(e);
        }

        /// <summary>
        /// 背景色を描くのイベント
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (BackColor == Color.Transparent)
            {
                if (DesignMode)
                {
                    // デザイン時は通常の描画
                    base.OnPaintBackground(pevent);
                }
                else
                {
                    // 文字列を塗りつぶす
                    using (var sb = new SolidBrush(ForeColor))
                    {
                        pevent.Graphics.FillRectangle(sb, ClientRectangle);
                    }
                }
            }
            else
            {
                base.OnPaintBackground(pevent);
            }
        }

        /// <summary>
        /// コントロールを描くのイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (BackColor == Color.Transparent)
            {
                if (DesignMode)
                {
                    // デザイン時は通常の描画
                    base.OnPaint(e);
                }
            }
            else
            {
                base.OnPaint(e);
            }
        }

    }

}