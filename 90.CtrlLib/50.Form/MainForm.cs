using CtrlLib.MyForms;
using System.Drawing;

namespace CtrlLib
{
    /// <summary>画面用のフォーム</summary>
    public partial class MainForm : BaseForm
    {
        /// <summary>初期設定</summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>初期設定</summary>
        /// <param name="pProgramID">画面ID</param>
        /// <param name="pTitle">画面タイトル</param>
        /// <param name="pProgramName">プログラム名</param>
        public void Initialize(string pProgramID, string pTitle, string pProgramName = "東開物流検品システム")
        {
            this.Initialize(pProgramID, pTitle, pProgramName, "Default");
            this.Refresh();
            lblScreenName.Text = pTitle;
        }

        public virtual void ucFunction1_F1(EventArgsFunctionButtonClick e) { }
        public virtual void ucFunction1_F2(EventArgsFunctionButtonClick e) { }
        public virtual void ucFunction1_F3(EventArgsFunctionButtonClick e) { }
        public virtual void ucFunction1_F4(EventArgsFunctionButtonClick e) { }
        public virtual void ucFunction1_F5(EventArgsFunctionButtonClick e) { }
        public virtual void ucFunction1_F6(EventArgsFunctionButtonClick e) { }
        public virtual void ucFunction1_F7(EventArgsFunctionButtonClick e) { }
        public virtual void ucFunction1_F8(EventArgsFunctionButtonClick e) { }
        public virtual void ucFunction1_F9(EventArgsFunctionButtonClick e) { }
        public virtual void ucFunction1_F10(EventArgsFunctionButtonClick e) { }
        public virtual void ucFunction1_F11(EventArgsFunctionButtonClick e) { }
        public virtual void ucFunction1_F12(EventArgsFunctionButtonClick e) { }

        public virtual void formLoad(object sender, System.EventArgs e)
        {

        }

        public virtual void clearScreen()
        {
        }
    }
}
