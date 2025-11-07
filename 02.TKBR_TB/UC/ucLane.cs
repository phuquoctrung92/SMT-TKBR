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
    public partial class ucLane : UserControl
    {
        string _nohinSaki = "";
        int _completed = 0;
        int _total = 0;
        bool _isDone = false;
        public ucLane(string nohinSaki = "", int completed = 0, int total = 0, bool isDone = false)
        {
            InitializeComponent();
            _nohinSaki = nohinSaki;
            _completed = completed;
            _total = total;
            _isDone = isDone;
        }

        private void ucLane_Load(object sender, EventArgs e)
        {
            pnl_Info.Controls.Clear();
            pnl_Footer.Controls.Clear();

            pnl_Info.Controls.Add(new ucInfo(nohinSaki: _nohinSaki, zansu: _total - _completed) { Dock = DockStyle.Fill });
            if (_isDone)
            {
                pnl_Footer.Controls.Add(new ucProgress_Printing() { Dock = DockStyle.Fill });
            }
            else
            {
                pnl_Footer.Controls.Add(new ucProgress($"{_completed} / {_total}") { Dock = DockStyle.Fill });
            }
        }
    }
}
