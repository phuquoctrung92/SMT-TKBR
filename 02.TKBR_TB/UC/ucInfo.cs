using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TKBR_TB.UC
{
    public partial class ucInfo : UserControl
    {
        public ucInfo(string nohinSaki = "", int zansu = 0)
        {
            InitializeComponent();
            lblNohinSaki.Text = nohinSaki;
            lblZansu.Text = zansu.ToString();
        }
    }
}
