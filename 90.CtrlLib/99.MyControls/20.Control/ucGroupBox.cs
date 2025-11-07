using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtrlLib._99.MyControls._20.Control
{
    /// <summary>シングルライフ様向きグループボックス</summary>
    public partial class ucGroupBox : UserControl
    {
        /// <summary>タイトル</summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                lblTitle.Text = value;
            }
        }

        /// <summary>フォント</summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                lblTitle.Font = value;
            }
        }

        /// <summary>タイトルの文字色</summary>
        [Browsable(true)]
        public Color HeaderForeColor
        {
            get
            {
                return lblTitle.ForeColor;
            }
            set
            {
                lblTitle.ForeColor = value;
                pnlMark.BackColor = lblTitle.ForeColor;
            }
        }

        /// <summary>初期設定</summary>
        public ucGroupBox()
        {
            InitializeComponent();
        }
    }
}
