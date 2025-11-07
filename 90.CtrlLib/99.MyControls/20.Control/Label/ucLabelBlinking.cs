using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtrlLib.MyControls
{
    public partial class ucLabelBlinking : UserControl
    {
        int blinkingInterval = 1;
        public Color DefaultBgColor { get; set; }
        public Color DefaultFontColor { get; set; }
        public Color BlinkingBgColor { get; set; }
        public Color BlinkingFontColor { get; set; }
        public bool BlinkingEnable { get; set; }
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text { get => lblContent.Text; set { lblContent.Text = value; } }
        public int BlinkingInterval { get { return blinkingInterval; } set { blinkingInterval = value; } }
        public ContentAlignment TextAlign { get { return lblContent.TextAlign; } set { lblContent.TextAlign = value; } }

        bool isOn;

        Timer timer1 = new Timer();
        public ucLabelBlinking()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!BlinkingEnable)
            {
                BackColor = DefaultBgColor;
                ForeColor = DefaultFontColor;
            }
            else
            {
                BackColor = isOn ? BlinkingBgColor : DefaultBgColor;
                ForeColor = isOn ? BlinkingFontColor : DefaultFontColor;
                isOn = !isOn;
            }

            timer1.Interval = BlinkingInterval * 1000;
        }

        private void ucLabelBlinking_Load(object sender, EventArgs e)
        {
            timer1.Interval = BlinkingInterval * 1000;
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;
        }
    }
}
