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
    public partial class ucProgress : UserControl
    {
        public ucProgress(string progress)
        {
            InitializeComponent();
            lblProgress.Text = progress;
        }
    }
}
