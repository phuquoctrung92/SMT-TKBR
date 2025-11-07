using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtrlLib
{
    public class GroupBoxWithBorder : GroupBox
    {
        uint _offset_TopRight = 135;
        uint _borderWidth = 1;
        Color _borderColor = Color.Black;
        public uint Offset_TopRight
        {
            get { return _offset_TopRight; }
            set
            {
                _offset_TopRight = value;
                Invalidate(); // Redraw the control to apply the new offset
            }
        }

        public uint BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;
                Invalidate(); // Redraw the control to apply the new offset}
            }
        }

        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate(); // Redraw the control to apply the new offset}
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Draw a border around the GroupBox
            using (var _pen = new Pen(_borderColor, _borderWidth))
            {
                e.Graphics.DrawLine(_pen, 0, 12, 0, Height - 2); //左線
                e.Graphics.DrawLine(_pen, Width - 1, 12, Width - 1, Height - 2); //右線
                e.Graphics.DrawLine(_pen, 0, Height - 2, Width, Height - 2); //下線
                e.Graphics.DrawLine(_pen, 0, 12, 4, 12); //上線１
                e.Graphics.DrawLine(_pen, Offset_TopRight, 12, Width, 12); //上線２
            }
        }
    }
}
