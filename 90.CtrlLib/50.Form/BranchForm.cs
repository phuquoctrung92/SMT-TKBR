using CtrlLib.MyForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtrlLib
{
    /// <summary>ダイアログ用のフォーム</summary>
    public partial class BranchForm : BaseForm
    {
        /// <summary>初期設定</summary>
        public BranchForm()
        {
            InitializeComponent();
        }

        public void Initialize(string pProgramID, string pTitle, string pProgramName = "東開物流検品システム")
        {
            this.Initialize(pProgramID, pTitle, pProgramName, "Default");
            this.Refresh();
            lblScreenName.Text = pTitle;
        }

        protected virtual void ucFunction1_F1(EventArgsFunctionButtonClick e) { }
        protected virtual void ucFunction1_F2(EventArgsFunctionButtonClick e) { }
        protected virtual void ucFunction1_F3(EventArgsFunctionButtonClick e) { }
        protected virtual void ucFunction1_F4(EventArgsFunctionButtonClick e) { }
        protected virtual void ucFunction1_F5(EventArgsFunctionButtonClick e) { }
        protected virtual void ucFunction1_F6(EventArgsFunctionButtonClick e) { }
        protected virtual void ucFunction1_F7(EventArgsFunctionButtonClick e) { }
        protected virtual void ucFunction1_F8(EventArgsFunctionButtonClick e) { }
        protected virtual void ucFunction1_F9(EventArgsFunctionButtonClick e) { }
        protected virtual void ucFunction1_F10(EventArgsFunctionButtonClick e) { }
        protected virtual void ucFunction1_F11(EventArgsFunctionButtonClick e) { }
        protected virtual void ucFunction1_F12(EventArgsFunctionButtonClick e) { }

    }
}
