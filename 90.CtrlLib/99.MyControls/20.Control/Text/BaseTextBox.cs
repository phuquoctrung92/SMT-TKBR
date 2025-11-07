using System;
using model = System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SmtLib;
using static SmtLib.XmlColorLib;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// テキストボックス共通機能
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public abstract class BaseTextBox : TextBox
    {

        #region Variable Value

        private bool m_untested;
        private ErrorNumbers m_error_number;

        private Color m_foreColorTmp;
        

        #endregion

        #region Enumerated type

        /// <summary> WindowMessages(WndProc) </summary>
        private enum WindowMessages
        {

            WM_NULL = 0x0,
            WM_CREATE = 0x1,
            WM_DESTROY = 0x2,
            WM_MOVE = 0x3,
            WM_SIZE = 0x5,

            WM_ACTIVATE = 0x6,
            // /*
            // * WM_ACTIVATE state values
            // */
            // #define     WA_INACTIVE     0
            // #define     WA_ACTIVE       1
            // #define     WA_CLICKACTIVE  2

            WM_SETFOCUS = 0x7,
            WM_KILLFOCUS = 0x8,
            WM_ENABLE = 0xA,
            WM_SETREDRAW = 0xB,
            WM_SETTEXT = 0xC,
            WM_GETTEXT = 0xD,
            WM_GETTEXTLENGTH = 0xE,
            WM_PAINT = 0xF,
            WM_CLOSE = 0x10,
            // #ifndef _WIN32_WCE
            WM_QUERYENDSESSION = 0x11,
            WM_QUERYOPEN = 0x13,
            WM_ENDSESSION = 0x16,
            // #endif
            WM_QUIT = 0x12,
            WM_ERASEBKGND = 0x14,
            WM_SYSCOLORCHANGE = 0x15,
            WM_SHOWWINDOW = 0x18,
            WM_WININICHANGE = 0x1A,
            WM_SETTINGCHANGE = WM_WININICHANGE,

            WM_DEVMODECHANGE = 0x1B,
            WM_ACTIVATEAPP = 0x1C,
            WM_FONTCHANGE = 0x1D,
            WM_TIMECHANGE = 0x1E,
            WM_CANCELMODE = 0x1F,
            WM_SETCURSOR = 0x20,
            WM_MOUSEACTIVATE = 0x21,
            WM_CHILDACTIVATE = 0x22,
            WM_QUEUESYNC = 0x23,

            WM_GETMINMAXINFO = 0x24,
            WM_PAINTICON = 0x26,
            WM_ICONERASEBKGND = 0x27,
            WM_NEXTDLGCTL = 0x28,
            WM_SPOOLERSTATUS = 0x2A,
            WM_DRAWITEM = 0x2B,
            WM_MEASUREITEM = 0x2C,
            WM_DELETEITEM = 0x2D,
            WM_VKEYTOITEM = 0x2E,
            WM_CHARTOITEM = 0x2F,
            WM_SETFONT = 0x30,
            WM_GETFONT = 0x31,
            WM_SETHOTKEY = 0x32,
            WM_GETHOTKEY = 0x33,
            WM_QUERYDRAGICON = 0x37,
            WM_COMPAREITEM = 0x39,

            WM_GETOBJECT = 0x3D,

            WM_COMPACTING = 0x41,
            WM_COMMNOTIFY = 0x44,  // /* no longer suported */
            WM_WINDOWPOSCHANGING = 0x46,
            WM_WINDOWPOSCHANGED = 0x47,

            WM_POWER = 0x48,

            WM_COPYDATA = 0x4A,
            WM_CANCELJOURNAL = 0x4B,

            WM_NOTIFY = 0x4E,
            WM_INPUTLANGCHANGEREQUEST = 0x50,
            WM_INPUTLANGCHANGE = 0x51,
            WM_TCARD = 0x52,
            WM_HELP = 0x53,
            WM_USERCHANGED = 0x54,
            WM_NOTIFYFORMAT = 0x55,

            WM_CONTEXTMENU = 0x7B,
            WM_STYLECHANGING = 0x7C,
            WM_STYLECHANGED = 0x7D,
            WM_DISPLAYCHANGE = 0x7E,
            WM_GETICON = 0x7F,
            WM_SETICON = 0x80,

            WM_NCCREATE = 0x81,
            WM_NCDESTROY = 0x82,
            WM_NCCALCSIZE = 0x83,
            WM_NCHITTEST = 0x84,
            WM_NCPAINT = 0x85,
            WM_NCACTIVATE = 0x86,
            WM_GETDLGCODE = 0x87,
            WM_SYNCPAINT = 0x88,
            WM_NCMOUSEMOVE = 0xA0,
            WM_NCLBUTTONDOWN = 0xA1,
            WM_NCLBUTTONUP = 0xA2,
            WM_NCLBUTTONDBLCLK = 0xA3,
            WM_NCRBUTTONDOWN = 0xA4,
            WM_NCRBUTTONUP = 0xA5,
            WM_NCRBUTTONDBLCLK = 0xA6,
            WM_NCMBUTTONDOWN = 0xA7,
            WM_NCMBUTTONUP = 0xA8,
            WM_NCMBUTTONDBLCLK = 0xA9,

            WM_KEYFIRST = 0x100,
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WM_CHAR = 0x102,
            WM_DEADCHAR = 0x103,
            WM_SYSKEYDOWN = 0x104,
            WM_SYSKEYUP = 0x105,
            WM_SYSCHAR = 0x106,
            WM_SYSDEADCHAR = 0x107,

            WM_KEYLAST = 0x108,

            WM_IME_STARTCOMPOSITION = 0x10D,
            WM_IME_ENDCOMPOSITION = 0x10E,
            WM_IME_COMPOSITION = 0x10F,
            WM_IME_KEYLAST = 0x10F,

            WM_INITDIALOG = 0x110,
            WM_COMMAND = 0x111,
            WM_SYSCOMMAND = 0x112,
            WM_TIMER = 0x113,
            WM_HSCROLL = 0x114,
            WM_VSCROLL = 0x115,
            WM_INITMENU = 0x116,
            WM_INITMENUPOPUP = 0x117,
            WM_MENUSELECT = 0x11F,
            WM_MENUCHAR = 0x120,
            WM_ENTERIDLE = 0x121,

            WM_MENURBUTTONUP = 0x122,
            WM_MENUDRAG = 0x123,
            WM_MENUGETOBJECT = 0x124,
            WM_UNINITMENUPOPUP = 0x125,
            WM_MENUCOMMAND = 0x126,

            WM_CTLCOLORMSGBOX = 0x132,
            WM_CTLCOLOREDIT = 0x133,
            WM_CTLCOLORLISTBOX = 0x134,
            WM_CTLCOLORBTN = 0x135,
            WM_CTLCOLORDLG = 0x136,
            WM_CTLCOLORSCROLLBAR = 0x137,
            WM_CTLCOLORSTATIC = 0x138,

            WM_MOUSEFIRST = 0x200,
            WM_MOUSEMOVE = 0x200,
            WM_LBUTTONDOWN = 0x201,
            WM_LBUTTONUP = 0x202,
            WM_LBUTTONDBLCLK = 0x203,
            WM_RBUTTONDOWN = 0x204,
            WM_RBUTTONUP = 0x205,
            WM_RBUTTONDBLCLK = 0x206,
            WM_MBUTTONDOWN = 0x207,
            WM_MBUTTONUP = 0x208,
            WM_MBUTTONDBLCLK = 0x209,

            WM_MOUSELAST = 0x209,

            WM_PARENTNOTIFY = 0x210,
            WM_ENTERMENULOOP = 0x211,
            WM_EXITMENULOOP = 0x212,

            WM_NEXTMENU = 0x213,
            WM_SIZING = 0x214,
            WM_CAPTURECHANGED = 0x215,
            WM_MOVING = 0x216,

            WM_POWERBROADCAST = 0x218,

            WM_DEVICECHANGE = 0x219,

            WM_MDICREATE = 0x220,
            WM_MDIDESTROY = 0x221,
            WM_MDIACTIVATE = 0x222,
            WM_MDIRESTORE = 0x223,
            WM_MDINEXT = 0x224,
            WM_MDIMAXIMIZE = 0x225,
            WM_MDITILE = 0x226,
            WM_MDICASCADE = 0x227,
            WM_MDIICONARRANGE = 0x228,
            WM_MDIGETACTIVE = 0x229,

            WM_MDISETMENU = 0x230,
            WM_ENTERSIZEMOVE = 0x231,
            WM_EXITSIZEMOVE = 0x232,
            WM_DROPFILES = 0x233,
            WM_MDIREFRESHMENU = 0x234,

            WM_IME_SETCONTEXT = 0x281,
            WM_IME_NOTIFY = 0x282,
            WM_IME_CONTROL = 0x283,
            WM_IME_COMPOSITIONFULL = 0x284,
            WM_IME_SELECT = 0x285,
            WM_IME_CHAR = 0x286,

            WM_IME_REQUEST = 0x288,

            WM_IME_KEYDOWN = 0x290,
            WM_IME_KEYUP = 0x291,

            WM_MOUSEHOVER = 0x2A1,
            WM_MOUSELEAVE = 0x2A3,

            WM_NCMOUSEHOVER = 0x2A0,
            WM_NCMOUSELEAVE = 0x2A2,

            WM_CUT = 0x300,
            WM_COPY = 0x301,
            WM_PASTE = 0x302,
            WM_CLEAR = 0x303,
            WM_UNDO = 0x304,
            WM_RENDERFORMAT = 0x305,
            WM_RENDERALLFORMATS = 0x306,
            WM_DESTROYCLIPBOARD = 0x307,
            WM_DRAWCLIPBOARD = 0x308,
            WM_PAINTCLIPBOARD = 0x309,
            WM_VSCROLLCLIPBOARD = 0x30A,
            WM_SIZECLIPBOARD = 0x30B,
            WM_ASKCBFORMATNAME = 0x30C,
            WM_CHANGECBCHAIN = 0x30D,
            WM_HSCROLLCLIPBOARD = 0x30E,
            WM_QUERYNEWPALETTE = 0x30F,
            WM_PALETTEISCHANGING = 0x310,
            WM_PALETTECHANGED = 0x311,
            WM_HOTKEY = 0x312,

            WM_PRINT = 0x317,
            WM_PRINTCLIENT = 0x318,

            WM_HANDHELDFIRST = 0x358,
            WM_HANDHELDLAST = 0x35F,

            WM_AFXFIRST = 0x360,
            WM_AFXLAST = 0x37F,

            WM_PENWINFIRST = 0x380,
            WM_PENWINLAST = 0x38F,

            WM_APP = 0x8000,

            WM_USER = 0x400
        }
        #endregion

        #region Property
        /// <remarks> デザイン時に BackColor プロパティを非表示にします。 </remarks>
        /// <summary> コントロールの背景色 </summary>
        [model.Browsable(false)]
        public override Color BackColor
        {
            [DebuggerStepThrough()]
            get
            {
                return base.BackColor;
            }
            [DebuggerStepThrough()]
            set
            {
                base.BackColor = value;
            }
        }
        #endregion

        #region Extend Propery
        /// <summary> 空の文字列を許可するかどうかを示す値を取得または設定します。 </summary>
        [model.Category("拡張")]
        [model.DefaultValue(true)]
        [model.Description("空の文字列を許可するかどうかを示します。")]
        public bool AllowEmpty { get; set; }

        /// <summary> 改行入力の許可の取得/設定。Enterによる入力チェックはできなくなります。 </summary>
        [model.Category("拡張")]
        [model.DefaultValue(false)]
        [model.Description("改行入力の許可の取得/設定。Enterによる入力チェックはできなくなります。")]
        public bool AllowEnterInput { get; set; }

        /// <summary>
        /// コントロールに関連付けられた '表示名' を取得または設定します。
        /// </summary>
        [model.Category("拡張")]
        [model.Description("オブジェクトに関連付けられた、ユーザー定義の '表示名' です。")]
        public virtual string Caption { get; set; }

        /// <summary> 有効な文字かどうかを調べるためのメソッドを取得または設定します。 </summary>
        [model.Browsable(false)]
        [model.Category("拡張")]
        [model.ReadOnly(true)]
        public IsValidCharDelegate IsValidCharacter { get; set; }

        /// <summary> 貼り付けの動作を示す値を取得または設定します。 </summary>
        [model.Category("拡張")]
        [model.DefaultValue(PasteTypes.Default)]
        [model.Description("貼り付けの動作を示す値です。")]
        public PasteTypes PasteType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [model.Browsable(false)]
        [model.ReadOnly(true)]
        public TextEditFormatDelegate TextEditFormat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [model.Browsable(false)]
        [model.ReadOnly(true)]
        public TextDisplayFormatDelegate TextDisplayFormat { get; set; }

        /// <summary> コントロールの検証によって得られる、エラー コードを取得します。 </summary>
        [model.Browsable(false)]
        public ErrorNumbers LastErrorNumber
        {
            get
            {
                if (m_untested)   // テキストが検証されていない場合
                {
                    ValidateText(Text);
                    m_untested = false;
                }
                return m_error_number;
            }
        }

        /// <remarks> コントロールの値が変わったかどうかを示します。 </remarks>
        [model.Browsable(false)]
        [model.ReadOnly(true)]
        public bool ChangeFlg { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// 作成
        /// </summary>
        public BaseTextBox()
        {
            OnPasted += StringBox_OnPasted;

            AllowEmpty = true;
            Caption = null;
            IsValidCharacter = null;
            PasteType = PasteTypes.RangeAndRemove;
            TextEditFormat = null;
            TextDisplayFormat = null;

            // MSC 標準のフォント サイズを初期値としています。
            Font = new Font("ＭＳ ゴシック", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 128);
            // ＭＳ ゴシック 9.75! 10桁 のサイズを初期値としています。
            Size = new Size(76, 20);

            m_untested = true;

            ChangeFlg = false;

            AutoSize = false;
        }

        #endregion

        #region Overrides
        /// <summary>
        /// 作成イベント
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            //m_foreColorTmp = ForeColor;

            if (!Enabled)
            {
                BackColor = GetColor(Colors.EnableFalseColor);
                ForeColor = Color.FromArgb(0x6d, 0x6d, 0x6d);
            }
            else if (ReadOnly)
            {
                BackColor = GetColor(Colors.ReadOnlyColor);
            }
            else if (AllowEmpty)
            {
                BackColor = GetColor(Colors.LostFocusColor);
            }
            else
            {
                BackColor = GetColor(Colors.HissuColor);
            }
        }

        /// <summary>
        /// フォーカス中のイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            if (!ReadOnly)
            {
                Common.SetToolStripStatusLabel(this, string.Format("{0}を入力して下さい。", Caption));
                BackColor = GetColor(Colors.GotFocusColor);
            }

            if (TextEditFormat is not null)
            {
                Text = TextEditFormat.Invoke(this, Text);
            }

            SelectAll();
            base.OnEnter(e);

        }

        /// <summary>
        /// フォーカスが切れたのイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLeave(EventArgs e)

        {
            Common.SetToolStripStatusLabel(this);
            if (!ReadOnly)
            {
                if (AllowEmpty)
                {
                    BackColor = GetColor(Colors.LostFocusColor);
                }
                else if (Enabled)  // Enabled=false時はwhitesmoke色のままとする。
                {
                    BackColor = GetColor(Colors.HissuColor);
                }
            }

            if (TextDisplayFormat is not null)
            {
                Text = TextDisplayFormat.Invoke(this, Text);
            }

            // 選択範囲のクリア
            SelectionStart = 0;
            SelectionLength = 0;
            base.OnLeave(e);

        }

        /// <summary>
        /// キー押下時イベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Back:
                case Keys.Delete:
                    {
                        base.OnKeyDown(e);
                        DeleteOrBackKeyDownBefore?.Invoke(this, e);
                        if (e.Handled)
                        {
                            return;
                        }

                        break;
                    }

                case Keys.Enter:
                    {
                        if (AllowEnterInput)
                        {
                            base.OnKeyDown(e);
                            e.Handled = true;
                            return;
                        }
                        EnterKeyDown?.Invoke(this, e);
                        if (e.Handled)
                        {
                            SelectAll();
                            return;
                        }

                        // Me.Parent.SelectNextControl(Me, Not e.Shift, True, True, True)
                        Control arg_current_control = this;
                        Common.SelectNextControl(ref arg_current_control, this, !e.Shift);
                        e.Handled = true;
                        return;
                    }

                case var @case when Keys.Left <= @case && @case <= Keys.Down:
                    {
                        AllowKeyDown?.Invoke(this, e);
                        if (e.Handled)
                        {
                            SelectAll();
                            return;
                        }

                        switch (e.KeyCode)
                        {
                            case Keys.Up:
                                {
                                    if (!Multiline || SelectionStart == 0)
                                    {
                                        // Me.Parent.SelectNextControl(Me, False, True, True, True)
                                        Control arg_current_control1 = this;
                                        Common.SelectNextControl(ref arg_current_control1, this, false);
                                        e.Handled = true;
                                        return;
                                    }

                                    break;
                                }

                            case Keys.Down:
                                {
                                    if (!Multiline || SelectionStart == TextLength)
                                    {
                                        // Me.Parent.SelectNextControl(Me, True, True, True, True)
                                        Control arg_current_control2 = this;
                                        Common.SelectNextControl(ref arg_current_control2, this, true);
                                        e.Handled = true;
                                        return;
                                    }

                                    break;
                                }

                        }

                        break;
                    }

                case var case1 when Keys.F1 <= case1 && case1 <= Keys.F24:
                    {

                        FunctionKeyDown?.Invoke(this, e);
                        if (e.Handled)
                        {
                            SelectAll();
                            return;
                        }

                        break;
                    }

            }

            base.OnKeyDown(e);

            switch (e.KeyData)
            {
                case Keys.Control | Keys.A:
                    {
                        SelectAll();
                        break;
                    }

            }
        }

        /// <summary>
        /// キー押下時のイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            int count;

            if (e.KeyChar == ControlChars.Cr)
            {
                if (AllowEnterInput)
                {
                    base.OnKeyPress(e);
                }
                else
                {
                    e.Handled = true;
                }

                return;
            }

            if (e.KeyChar == '\b')  // Back Space
            {
                return;
            }

            // control chars.
            if (char.IsControl(e.KeyChar))
            {
                base.OnKeyPress(e);
                return;
            }

            // is valid chars.
            if (IsValidCharacter is not null && !IsValidCharacter.Invoke(this, e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // max byte counts.
            if (0 < MaxLength)
            {
                count = MaxLength - ClsCheck.GetLengthAsByte(Text) + ClsCheck.GetLengthAsByte(SelectedText);
                if (count < ClsCheck.GetLengthAsByte(Conversions.ToString(e.KeyChar)))
                {
                    e.Handled = true;
                    return;
                }
            }
            base.OnKeyPress(e);
        }

        /// <summary>
        /// テキストを変更した時のイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(EventArgs e)
        {
            m_untested = true;
            ChangeFlg = true;
            base.OnTextChanged(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        [DebuggerStepThrough()]
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch ((WindowMessages)m.Msg)
            {
                case WindowMessages.WM_PASTE:
                    {
                        EventArgsHandled e;
                        e = new EventArgsHandled();
                        OnPasted?.Invoke(e);
                        if (e.Handled)
                            return;
                        break;
                    }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 有効化のステータスを変更した時のイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            // EnabledがFalseの時だけ自分で描画する
            if (Enabled)
            {
                if (ReadOnly)
                {
                    BackColor = GetColor(Colors.ReadOnlyColor);
                }
                else if (AllowEmpty)
                {
                    BackColor = GetColor(Colors.LostFocusColor);
                }
                else
                {
                    BackColor = GetColor(Colors.HissuColor);
                }

                ForeColor = m_foreColorTmp;
                SetStyle(ControlStyles.UserPaint, false);
            }
            else
            {
                BackColor = GetColor(Colors.EnableFalseColor);
                m_foreColorTmp = ForeColor;
                ForeColor = Color.FromArgb(0x6d, 0x6d, 0x6d);
                SetStyle(ControlStyles.UserPaint, true);
            }
            RecreateHandle();
            // 再描画
            Invalidate();
        }



        /// <summary>
        /// Readonlyを変更した時のイベント
        /// </summary>
        /// <param name="e"></param>
        protected override void OnReadOnlyChanged(EventArgs e)
        {
            base.OnReadOnlyChanged(e);
            // EnabledがFalseの時だけ自分で描画する

            // ReadOnlyのときはタブ移動対象外にする
            TabStop = !ReadOnly;

            if (Enabled)
            {
                if (ReadOnly)
                {
                    BackColor = GetColor(Colors.ReadOnlyColor);
                }
                else if (AllowEmpty)
                {
                    BackColor = GetColor(Colors.LostFocusColor);
                }
                else
                {
                    BackColor = GetColor(Colors.HissuColor);
                }

                SetStyle(ControlStyles.UserPaint, false);
            }
            else
            {
                BackColor = GetColor(Colors.EnableFalseColor);
                SetStyle(ControlStyles.UserPaint, true);
            }
            RecreateHandle();
            // 再描画
            Invalidate();
        }

        /// <summary>
        /// TextBoxを描画する
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var b = new SolidBrush(ForeColor);
            // 文字列を描画する
            e.Graphics.DrawString(Text, Font, b, -1, 1f);
            b.Dispose();
        }

        #endregion

        #region Extend Events

        /// <summary> コントロールに '貼り付け' が行われた場合に発生します。 </summary>
        public event PastedEventHandler Pasted;
        /// <summary>
        /// Pastedイベントの代表者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void PastedEventHandler(object sender, EventArgsHandled e);

        /// <summary>
        /// コントロールに '貼り付け' が行っている場合に発生します。
        /// </summary>
        protected event OnPastedEventHandler OnPasted;
        /// <summary>
        /// OnPastedイベントの代表者
        /// </summary>
        /// <param name="e"></param>
        protected delegate void OnPastedEventHandler(EventArgsHandled e);

        /// <summary> コントロールにフォーカスがあるときに カーソル キーが押されると KeyDown イベントの前に発生します。 </summary>
        public event AllowKeyDownEventHandler AllowKeyDown;
        /// <summary>
        /// AllowKeyDownイベントの代表者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void AllowKeyDownEventHandler(object sender, KeyEventArgs e);

        /// <summary> コントロールにフォーカスがあるときに Enterキーが押されると KeyDown イベントの前に発生します。 </summary>
        public event EnterKeyDownEventHandler EnterKeyDown;
        /// <summary>
        /// EnterKeyDownイベントの代表者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void EnterKeyDownEventHandler(object sender, KeyEventArgs e);

        /// <summary> コントロールにフォーカスがあるときに ファンクション キーが押されると KeyDown イベントの前に発生します。 </summary>
        public event FunctionKeyDownEventHandler FunctionKeyDown;
        /// <summary>
        /// FunctionKeyDownの代表者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void FunctionKeyDownEventHandler(object sender, KeyEventArgs e);

        /// <summary> Enter処理の最初 </summary>
        public event DeleteOrBackKeyDownBeforeEventHandler DeleteOrBackKeyDownBefore;
        /// <summary>
        /// DeleteOrBackKeyDownBeforeイベントの代表者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DeleteOrBackKeyDownBeforeEventHandler(object sender, KeyEventArgs e);
        #endregion

        #region Method
        /// <summary>
        /// フォーカス
        /// </summary>
        public new void Focus()
        {
            SelectAll();
            base.Focus();
        }

        private void StringBox_OnPasted(EventArgsHandled e)
        {
            string s;
            char[] chars;
            int count, length;
            System.Text.StringBuilder sb;

            Pasted?.Invoke(this, e);
            if (e.Handled)
                return;

            switch (PasteType)
            {

                case PasteTypes.Default:
                    {
                        // OnPaste で処理をせず、既定の処理を呼び出します。
                        return;
                    }

                case PasteTypes.Disabled:
                    {
                        e.Handled = true;
                        return;
                    }

                case PasteTypes.Range:
                    {
                        e.Handled = true;
                        return;
                    }

                case PasteTypes.RangeAndRemove:
                    {
                        s = Clipboard.GetText();
                        if (IsValidCharacter is not null)
                        {
                            sb = new System.Text.StringBuilder();
                            for (int i = 0, loopTo = s.Length - 1; i <= loopTo; i++)
                            {
                                if (IsValidCharacter.Invoke(this, s[i]))
                                    sb.Append(s[i]);
                            }
                            s = sb.ToString();
                        }
                        if (0 < MaxLength)
                        {
                            count = MaxLength - ClsCheck.GetLengthAsByte(Text) + ClsCheck.GetLengthAsByte(SelectedText);
                            chars = s.ToCharArray();
                            var loopTo1 = chars.Length - 1;
                            for (length = 0; length <= loopTo1; length++)
                            {
                                count --;
                                if (count < 0)
                                {
                                    s = s.Substring(0, length);
                                    break;
                                }
                            }
                        }
                        SelectedText = s;
                        e.Handled = true;
                        return;
                    }

                case PasteTypes.Control:
                    {
                        // 継承コントロール側に依存
                        e.Handled = true;
                        return;
                    }
            }
        }

        /// <summary>
        /// 最終のエラーをセット
        /// </summary>
        /// <param name="_error_number"></param>
        protected void SetLastError(ErrorNumbers _error_number)
        {
            m_error_number = _error_number;
            m_untested = false;
        }
        #endregion

        #region Control Validation
        /// <summary>
        /// コントロールの検証を行い、結果をエラー コードとして返します。
        /// </summary>
        /// <remarks>オーバーライドをしてユーザー独自の検証を行う場合、SetLastError メソッドを呼び出してから終了してください。</remarks>
        public virtual int ValidateText(string _source)
        {
            if (_source is not null && !Focused && TextEditFormat is not null)
            {
                // text edit formating.
                Text = TextEditFormat.Invoke(this, _source);
            }

            SetLastError(ErrorNumbers.OK);
            return (int)m_error_number;
        }

       
        #endregion
    }
}