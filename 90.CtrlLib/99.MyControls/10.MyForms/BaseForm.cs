using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using CtrlLib.My;
using CtrlLib.MyControls;
using SmtLib;

namespace CtrlLib.MyForms
{

    /// <summary>
    /// BaseForm
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public partial class BaseForm
    {

        /// <summary>
        /// 位置調整用の親フォーム（直Ownerに入れると元の画面非表示なるからこっちにね)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        [Browsable(false)]
        public BaseForm OyaForm { get; set; }

        /// <summary>
        /// 画面を表示
        /// </summary>
        /// <param name="frm">位置調整用の親フォーム（直Ownerに入れると元の画面非表示なるからこっちにね)</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DialogResult ShowDialog(BaseForm frm)
        {
            OyaForm = frm;
            return ShowDialog();
        }


        #region Variable Value

        private Enums.OperatingModes m_operating_mode;

        private string m_ColorKbName;


        #endregion


        #region Extend Property

        /// <summary> 画面表示のモード </summary>
        [Browsable(false)]
        public Enums.OperatingModes OperatingMode
        {
            get
            {
                return m_operating_mode;
            }
            set
            {
                if (Enum.IsDefined(typeof(Enums.OperatingModes), value))
                {
                    m_operating_mode = value;
                    OnOperatingModeChanged?.Invoke();
                }
            }
        }

        /// <summary> 画面終了時に戻りモード </summary>
        [Browsable(false)]
        public Enums.FormResults FormResult { get; set; }

        /// <summary> コントロールの値が変わったかどうかを示します。 </summary>
        [Browsable(false)]
        public bool ChangeFlg { get; set; }

        /// <summary> システム日付 </summary>
        [Browsable(false)]
        public DateTime SysDate { get; set; }

        /// <summary> 情報 </summary>
        [Browsable(false)]
        public Microsoft.VisualBasic.ApplicationServices.AssemblyInfo Info { get; set; }

        /// <summary> 閉じるボタン有効無効 </summary>
        [Browsable(false)]
        public bool CloseButton { get; set; }

        /// <summary> 画面ID </summary>
        [Browsable(false)]
        public string ProgramID { get; set; }


        #endregion

        #region Constructor
        /// <summary>
        /// 初期設定
        /// </summary>
        public BaseForm()
        {

            // この呼び出しは、Windows フォーム デザイナで必要です。
            InitializeComponent();

            CloseButton = false;
            StatusStrip1 = _StatusStrip1;
            ToolStripStatusLabel1 = _ToolStripStatusLabel1;
            ToolStripProgressBar1 = _ToolStripProgressBar1;
            ToolStripStatusLabel2 = _ToolStripStatusLabel2;
            _StatusStrip1.Name = "StatusStrip1";
            _ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            _ToolStripProgressBar1.Name = "ToolStripProgressBar1";
            _ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
        }

        #endregion

        #region Extend Events

        /// <summary> 処理モード変更時に発生するイベント </summary>
        protected event OnOperatingModeChangedEventHandler OnOperatingModeChanged;
        /// <summary>
        /// OnOperatingModeChangedイベントの代表者
        /// </summary>
        protected delegate void OnOperatingModeChangedEventHandler();

        #endregion

        #region Form Events

        /// <summary> Form_Load </summary>
        private void Form_Load(object sender, EventArgs e)
        {

            // GlobalContext.WriteLog(log4net.Core.Level.Trace, String.Format("{0} - Form_Load", Me.Name))
            // clsLogger.Info(String.Format("{0}", Me.Name))
            clsLogger.InfoFormat("フォーム開く：{0}", Text);

            // 親フォームの非表示処理を行います。
            if (Owner is not null)
            {
                switch (OperatingMode)
                {
                    case Enums.OperatingModes.Searching:
                        {
                            // デフォルト位置に。(タスクバーに隠れることがありません)
                            // 検索画面の時は親フォームは非表示にしません。
                            StartPosition = FormStartPosition.WindowsDefaultLocation;
                            break;
                        }

                    default:
                        {
                            // 表示位置を親フォームと同じ位置に。(タスクバーに隠れていても常に親フォームと同じ位置に)
                            // Me.Location = Me.Owner.Location
                            Owner.Hide();
                            break;
                        }
                }
            }

            if (OperatingMode == Enums.OperatingModes.Searching)
            {
                // 検索モードはラベルの名前を変える
                MinimizeBox = false;
            }

        //    AppContext.SetSwitch("Switch.UseLegacyAccessibilityFeatures", true);


        //AppContext.SetSwitch("Switch.UseLegacyAccessibilityFeatures.2", true);
        //AppContext.SetSwitch("Switch.UseLegacyAccessibilityFeatures.3", true);


        }

        /// <summary> FormClosed </summary>
        [DebuggerStepThrough()]
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsLogger.InfoFormat("フォーム閉じる：{0}", Text);
            // 親フォームの表示処理を行います。

            if (Owner is not null)
            {
                Owner.Show();
            }
        }

        /// <summary> KeyDown </summary>
        [DebuggerStepThrough()]
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // 割当たってないファンクションがWindowsの動作を行うためイベントのキャンセルを行う
            switch (e.KeyData)
            {
                case var @case when Keys.F1 <= @case && @case <= Keys.F24:
                    {
                        e.Handled = true;
                        break;
                    }
            }
        }

        #endregion

        #region Method

        /// <summary> フォームの初期化 </summary>
        /// <param name="_prg_id">画面ID</param>
        /// <param name="_form_title"> フォーム名 </param>
        /// <param name="_assembly_info">アッセンブリ情報</param>
        /// <param name="_colorKbName">色区分</param>
        public void Initialize(string _prg_id, string _form_title, Microsoft.VisualBasic.ApplicationServices.AssemblyInfo _assembly_info, string _colorKbName = "Default")
        {

            m_ColorKbName = _colorKbName;
            XmlColorLib.ReadXml(m_ColorKbName);

            Info = _assembly_info;

            ProgramID = _prg_id;

            // Me.BackColor = XmlColorLib.GetColor(Colors.FormBackColor)

            // タイトル設定
            Text = string.Format("{0} - {1}", _assembly_info.Title, _form_title);

            int w = Screen.GetBounds(this).Width;
            int h = Screen.GetBounds(this).Height - 40;
            if (w < Width)
            {
                Width = w;
            }

            if (h < Height)
            {
                Height = h;
            }

            ToolStripStatusLabel1.Text = string.Empty;
            ToolStripProgressBar1.Visible = false;

            ToolStripStatusLabel2.Text = string.Empty;
            if (800 <= Width)
            {
                ToolStripStatusLabel2.Text = string.Format("{0}  Ver.{1}.{2}.{3}", _assembly_info.Copyright, _assembly_info.Version.Major, _assembly_info.Version.Minor, _assembly_info.Version.Build);
            }

            OperatingMode = Enums.OperatingModes.NonSelected;


        }

        /// <summary> フォームの初期化 </summary>
        /// <param name="_prg_id">画面ID</param>
        /// <param name="_form_title"> フォーム名 </param>
        /// <param name="program_name">画面名</param>
        /// <param name="_colorKbName">色区分</param>
        public void Initialize(string _prg_id, string _form_title, string program_name, string _colorKbName = "Default")
        {

            m_ColorKbName = _colorKbName;
            XmlColorLib.ReadXml(m_ColorKbName);

            Info = MyProject.Application.Info;

            ProgramID = _prg_id;

            // Me.BackColor = XmlColorLib.GetColor(Colors.FormBackColor)

            // タイトル設定
            Text = string.Format("{0} - {1}", program_name, _form_title);

            ToolStripStatusLabel1.Text = string.Empty;
            ToolStripProgressBar1.Visible = false;

            ToolStripStatusLabel2.Text = string.Empty;
            if (850 <= Width)
            {
                ToolStripStatusLabel2.Text = string.Format("{0}  Ver.{1}.{2}.{3}", Info.Copyright, Info.Version.Major, Info.Version.Minor, Info.Version.Build);
            }

            OperatingMode = Enums.OperatingModes.NonSelected;
        }

        /// <summary> 処理実行中のフォームの設定 </summary>
        public void FormProcessStart()
        {
            Cursor = Cursors.WaitCursor;
            Enabled = false;
            SuspendLayout();
        }

        /// <summary> 処理未実行時のフォームの設定 </summary>
        public void FormProcessEnd()
        {
            Cursor = Cursors.Default;
            Enabled = true;
            ResumeLayout(true);
        }

        /// <summary> 閉じるボタン使用不可化 </summary>
        /// <remarks>コントロールボックスの閉じるボタンを使用不可状態にします。</remarks>
        protected override CreateParams CreateParams
        {
            get
            {
                if (!CloseButton)
                {
                    const int CS_NOCLOSE = 0x200;
                    var cp = base.CreateParams;
                    cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
                    return cp;
                }
                else
                {
                    return base.CreateParams;
                }
            }
        }
        /// <summary>
        /// ファンクションボタンを取得
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public BaseButton GetFunctionButtonControls(Keys key)
        {
            foreach (Control a in Controls)
            {
                if (a is ucFunction)
                {
                    return ((ucFunction)a).get_FunctionButtonControls(key);
                }
            }

            return null;
        }

        /// <summary> フォーム上でファンクション キーが押された時の処理を行います。 </summary>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case var @case when Keys.F1 <= @case && @case <= Keys.F24:
                    {
                        // ↓BaseForm の ControlsのみだとPanel内のコントロールを取得できなかったので、再起で調べます。
                        // searchFuncButton(Controls, keyData);
                        
                        foreach (Control a in Controls)
                        {
                            // ↓ ucFunction方式
                            if (a is ucFunction)
                            {
                                return ((ucFunction)a).ProcessDialogKey(keyData);
                            }
                         } 

                        break;
                    }
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 入力されたキーに対応するファンクションを捜索します。
        /// 見つかった場合はファンクションを実行します。
        /// </summary>
        private bool searchFuncButton(Control.ControlCollection cs, Keys keyData)
        {
            foreach (Control c in cs)
            {
                if (c is ucFunction)
                {
                    if (((ucFunction)c).ProcessDialogKey(keyData)) { }// return true;
                }
                //if (c is ucFunction)
                //{
                //    ((ucFunction)c).ProcessDialogKey(keyData);
                //}

                if (c is Panel)
                {
                    if (searchFuncButton(((Panel)c).Controls, keyData))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region ProgressBar

        /// <summary>
        /// プログレスバー・ラベルの初期化
        /// </summary>
        /// <param name="_Maximum">プログレスバーのマックス</param>
        /// <param name="_LabelDisp">ラベルに表示する値</param>
        /// <remarks></remarks>
        public void ProgressBarInit(int _Maximum, string _LabelDisp)
        {
            ToolStripStatusLabel1.Text = _LabelDisp;

            var withBlock = ToolStripProgressBar1;
            withBlock.Maximum = _Maximum;
            withBlock.Minimum = 0;
            withBlock.Value = 0;
            withBlock.Visible = true;

            Refresh();
        }

        /// <summary>
        /// プログレスバーのValue＋１とリフレッシュ
        /// </summary>
        /// <remarks></remarks>
        public void ProgressBarAddValue(string _LabelDisp = "")
        {

            if (!ClsCheck.IsNull(_LabelDisp))
            {
                ToolStripStatusLabel1.Text = _LabelDisp;
            }

            if (ToolStripProgressBar1.Maximum >= ToolStripProgressBar1.Value + 1)
            {
                ToolStripProgressBar1.Value += 1;
            }

            Refresh();
        }

        /// <summary>
        /// プログレスバー・ラベルの非表示
        /// </summary>
        /// <remarks></remarks>
        public void ProgressBarExit()
        {
            ToolStripStatusLabel1.Text = string.Empty;
            ToolStripProgressBar1.Visible = false;
            Refresh();
        }

        #endregion

        // Private Sub BaseForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        // If Me.WindowState = FormWindowState.Minimized Then
        // For Each f As Form In Application.OpenForms
        // f.WindowState = FormWindowState.Minimized
        // Next
        // End If
        // End Sub
    }

}