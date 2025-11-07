using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtrlLib._99.MyControls._20.Control
{
    /// <summary>Nullをセットできる</summary>
    public partial class NullableNumericUpDown : NumericUpDown
    {
        private int? _value;
        /// <summary>値</summary>
        public new int? Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                if (value != null)
                {
                    base.Value = (int)value;
                    Text = Value.ToString();
                }
                else
                {
                    Text = "";
                }
            }
        }

        private void NullableNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _value = (int)base.Value;
        }

        void NullableNumericUpDown_TextChanged(object sender, System.EventArgs e)
        {
            if (Text == "")
            {
                _value = null;
            }
        }
    }
}
