using System;
using System.Collections.Generic;
using model = System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SmtLib;
using System.Data;

namespace CtrlLib.MyControls
{
    public partial class ucComboBox
    {
        #region Variable Value

        private List<ComboData> mDataList;

        #endregion

        #region Property
        /// <summary>
        /// コントロールのフォント
        /// </summary>
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                ComboBox.Font = base.Font;
                Label.Font = base.Font;
            }
        }

        /// <summary>
        /// コンボボックスの幅を調整
        /// </summary>
        [model.Category("拡張")]
        [model.Description("コンボボックスの幅を調整する場合に入力して下さい。")]
        public int ComboWidth
        {
            get
            {
                return ComboBox.Width;
            }
            set
            {
                ComboBox.Width = value;
            }
        }

        /// <summary>
        /// コンボボックスの選択肢幅を調整
        /// </summary>
        [model.Category("拡張")]
        [model.Description("コンボボックスの選択肢幅を調整する場合に入力して下さい。")]
        public int DropDownWidth
        {
            get
            {
                return ComboBox.DropDownWidth;
            }
            set
            {
                ComboBox.DropDownWidth = value;
            }
        }

        /// <summary>
        /// コンボボックスの選択肢横を調整
        /// </summary>
        public int DropDownHeight
        {
            get
            {
                return ComboBox.DropDownHeight;
            }
            set
            {
                ComboBox.DropDownHeight = value;
            }
        }

        /// <summary>
        /// ラベルが必要なコンボボックスかどうか
        /// </summary>
        [model.Category("拡張")]
        [model.Description("ラベルが必要なコンボボックスかどうか")]
        public bool LabelVisible
        {
            get
            {
                return Label.Visible;
            }
            set
            {
                Label.Visible = value;
                if (value)
                {
                    ComboBox.Dock = DockStyle.Left;
                    Label.Dock = DockStyle.Fill;
                    ComboBox.DropDownStyle = ComboBoxStyle.DropDown;
                }
                else
                {
                    ComboBox.Dock = DockStyle.Fill;
                    Label.Dock = DockStyle.None;
                    ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
        }

        /// <summary>
        /// コードの取得・セット 
        /// 　ラベル表示時はコンボボックス部分
        /// 　ラベルを非表示にしているときは表示されない値
        /// </summary>
        [model.Browsable(false)]
        public string SelectedValue
        {
            get
            {
                if (ComboBox.SelectedIndex < 0)
                {
                    return string.Empty;
                }
                return Conversions.ToString(mDataList[ComboBox.SelectedIndex].Value);
            }
            set
            {

                MoveFlg = false;


                for (int i = 0, loopTo = mDataList.Count - 1; i <= loopTo; i++)
                {

                    var cd = mDataList[i];
                    if ((Strings.StrConv(Conversions.ToString(cd.Value), VbStrConv.Uppercase) ?? "") == (Strings.StrConv(value, VbStrConv.Uppercase) ?? ""))
                    {
                        ComboBox.SelectedIndex = i;
                        return;
                    }
                }

                Text = string.Empty;
                if (AllowEmpty && mDataList.Count > 0)
                {
                    ComboBox.SelectedIndex = 0;
                }
                else
                {
                    ComboBox.SelectedIndex = -1;
                    Label.Text = string.Empty;
                }

                // アンマッチイベントをライズする
                // RaiseEvent OnUnmatching()

            }
        }

        /// <summary>
        /// 選択しているテキスト（表示部）
        /// 　ラベル表示時はラベル部分
        /// 　ラベルを非表示にしているときはコンボボックスに表示される値
        /// </summary>
        [model.Browsable(false)]
        public string SelectedText
        {
            get
            {
                if (ComboBox.SelectedIndex < 0)
                {
                    return string.Empty;
                }
                return mDataList[ComboBox.SelectedIndex].Text;
            }
        }

        /// <summary>
        /// 選択しているアイテムの位置
        /// </summary>
        [model.Browsable(false)]
        public int SelectedIndex
        {
            get
            {
                return ComboBox.SelectedIndex;
            }
            set
            {
                ComboBox.SelectedIndex = value;
            }
        }

        /// <summary> コントロールの遷移を制御します。 </summary>
        [model.Browsable(false)]
        public bool MoveFlg { get; set; }

        /// <summary> 現在のインデックスを取得または設定します。 </summary>
        /// <remarks></remarks>
        [model.Browsable(false)]
        public int CurrentIndex { get; set; }

        /// <summary> 空の文字列を許可するかどうかを示す値を取得または設定します。 </summary>
        [model.Category("拡張")]
        [model.DefaultValue(true)]
        [model.Description("空の文字列を許可するかどうかを示します。")]
        public bool AllowEmpty { get; set; }

        /// <summary> コントロールに関連付けられた '表示名' を取得または設定します。 </summary>
        [model.Category("拡張")]
        [model.Description("オブジェクトに関連付けられた、ユーザー定義の '表示名' です。")]
        public string Caption { get; set; }

        /// <summary>
        /// アイテムのカウント
        /// </summary>
        public int Count
        {
            get
            {
                return ComboBox.Items.Count;
            }
        }

        #endregion
        /// <summary>
        /// 他のアイテムを選択のイベント
        /// </summary>
        public event SelectedValueChangedEventHandler SelectedValueChanged;

        /// <summary>
        /// 他のアイテムを選択のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void SelectedValueChangedEventHandler(object sender, EventArgs e);

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }

            e.DrawBackground();
            e.DrawFocusRectangle();

            // 通常のリスト描画
            Rectangle rect;
            StringFormat sf;

            rect = new Rectangle(e.Bounds.Left, e.Bounds.Top, Width + 1000, e.Bounds.Height);

            sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;

            string txt = mDataList[e.Index].Text;
            string val = Conversions.ToString(mDataList[e.Index].Value);

            if (ClsCheck.GetLengthAsByte(val) < ComboBox.MaxLength)
            {
                val = val.PadRight(ComboBox.MaxLength, ' ');
            }

            if (!Label.Visible)
            {
                e.Graphics.DrawString(txt, e.Font, new SolidBrush(e.ForeColor), rect, sf);
            }
            else if (string.IsNullOrEmpty(val + txt))
            {
                e.Graphics.DrawString(val, e.Font, new SolidBrush(e.ForeColor), rect, sf);
            }
            else
            {
                e.Graphics.DrawString(val + ":" + txt, e.Font, new SolidBrush(e.ForeColor), rect, sf);
            }

            // フォーカスを示す四角形を描画
            e.DrawFocusRectangle();
            // Me.ComboBox.BackColor = XmlColorLib.GetColor(Colors.GotFocusColor)
        }

        private void ComboBox_DropDown(object sender, EventArgs e)
        {
            SetLostFocusColor();
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox.BackColor = XmlColorLib.GetColor(XmlColorLib.Colors.GotFocusColor);

            if (ComboBox.SelectedIndex == CurrentIndex)
            {
                return;
            }

            if (ClsCheck.IsNull(SelectedValue))
            {
                return;
            }

            MoveFlg = true;
        }

        private void ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        if (e.Handled)
                            return;

                        MoveFlg = true;

                        if (ComboBox.SelectedIndex != -1)
                        {
                            SelectedValue = Conversions.ToString(mDataList[ComboBox.SelectedIndex].Value);
                        }

                        string val = SelectedValue;
                        int ind = SelectedIndex;

                        int ErrNum = (int)ValidateText(SelectedValue);

                        if (!Common.ControlKeyDownErr((ErrorNumbers)ErrNum, this, Caption))
                        {
                            ComboBox.SelectAll();
                            e.Handled = true;
                            return;
                        }

                        // RaiseEvent EnterKeyDown(Me, e)
                        if (e.Handled)
                        {
                            ComboBox.SelectAll();
                            return;
                        }

                        ComboBox_Leave(null, null);

                        Control arg_current_control = this;
                        Common.SelectNextControl(ref arg_current_control, this, !e.Shift);

                        if(ind == SelectedIndex)
                        {
                            SelectedValue = val;
                        }
                        e.Handled = true;
                        MoveFlg = false;
                        return;
                    }

                case Keys.Up:
                case Keys.Down:
                    {
                        MoveFlg = false;
                        break;
                    }

                case Keys.Right:
                    {
                        if (ComboBox.DropDownStyle == ComboBoxStyle.DropDownList)
                        {
                            MoveFlg = false;
                            Control arg_current_control1 = this;
                            Common.SelectNextControl(ref arg_current_control1, this, true);
                            e.Handled = true;
                        }

                        break;
                    }

                case Keys.Left:
                    {
                        if (ComboBox.DropDownStyle == ComboBoxStyle.DropDownList)
                        {
                            MoveFlg = false;
                            Control arg_current_control2 = this;
                            Common.SelectNextControl(ref arg_current_control2, this, false);
                            e.Handled = true;
                        }

                        break;
                    }
                case { } k when (k >= Keys.D0 && k <= Keys.D9):
                    //数字キー入力時に番号に対応した位置に変更（ラベル非表示時のみ）
                    if (!LabelVisible)
                    {
                        int ind = e.KeyCode - Keys.D0;
                        if(ind > 0 && mDataList.Count > 0 && !ClsCheck.IsNull(mDataList[0].Value) && mDataList[0].Value.ToString().Trim() != "")
                        {
                            // コンボボックスの先頭が空文字でなかった場合は数字の1を先頭とする
                            ind = e.KeyCode - Keys.D1;
                        }

                        if (ind < mDataList.Count) SelectedIndex = ind;
                    }
                    break;
                case { } k when (k >= Keys.NumPad0 && k <= Keys.NumPad9):
                    //テンキー入力時に番号に対応した位置に変更（ラベル非表示時のみ）
                    if (!LabelVisible)
                    {
                        int ind = e.KeyCode - Keys.NumPad0;
                        if (ind > 0 && mDataList.Count > 0 && !ClsCheck.IsNull(mDataList[0].Value) && mDataList[0].Value.ToString().Trim() != "")
                        {
                            // コンボボックスの先頭が空文字でなかった場合は数字の1を先頭とする
                            ind = e.KeyCode - Keys.NumPad1;
                        }

                        if (ind < mDataList.Count) SelectedIndex = ind;
                    }
                    break;
            }
        }

        /// <summary>
        /// キーが押されたのイベント
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // 左キーが押されているか調べる
            if ((keyData & Keys.KeyCode) == Keys.Tab)
            {
                MoveFlg = true;

                string val = SelectedValue;

                int ErrNum = (int)ValidateText(SelectedValue);

                if (!Common.ControlKeyDownErr((ErrorNumbers)ErrNum, this, Caption))
                {
                    ComboBox.SelectAll();
                    return true;
                }

                // RaiseEvent EnterKeyDown(Me, e)
                ComboBox_Leave(null, null);

                if ((int)keyData == (int)Keys.Tab + (int)Keys.Shift)
                {
                    Control arg_current_control = this;
                    Common.SelectNextControl(ref arg_current_control, this, false);
                }
                else
                {
                    Control arg_current_control1 = this;
                    Common.SelectNextControl(ref arg_current_control1, this, true);
                }

                SelectedValue = val;

                MoveFlg = false;
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// コントロールのフォーカスが切れるのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Leave(object sender, EventArgs e)
        {
            Common.SetToolStripStatusLabel(this);

            //
            if(SelectedText != ComboBox.Text)
            {
                for(int i = 0; i < mDataList.Count; i++)
                {
                    if (mDataList[i].Value.ToString() == ComboBox.Text)
                    {
                        ComboBox.SelectedIndex = i;
                        break;
                    }
                }

            }



            SetLostFocusColor();

            Parent.Refresh();
        }

        /// <summary>
        /// コントロールのサイズを変更のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_Resize(object sender, EventArgs e)
        {
            Height = ComboBox.Height;
        }

        /// <summary>
        /// 他のアイテムを選択のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

            if (Label.Visible)
            {
                Label.Text = SelectedText;
            }

            if (ComboBox.SelectedIndex == CurrentIndex)
            {
                return;
            }

            CurrentIndex = ComboBox.SelectedIndex;

            SelectedValueChanged?.Invoke(sender, e);

            if (MoveFlg)
            {
                Control arg_current_control = this;
                Common.SelectNextControl(ref arg_current_control, this, true);
            }
            MoveFlg = false;

        }

        /// <summary>
        /// 初期設定
        /// </summary>
        public ucComboBox()
        {

            // この呼び出しはデザイナーで必要です。
            InitializeComponent();

            // InitializeComponent() 呼び出しの後で初期化を追加します。

            AllowEmpty = true;
            MoveFlg = true;
            ComboBox.ImeMode = ImeMode.Disable;

            // MSC 標準のフォント サイズを初期値としています。
            ComboBox.Font = new Font("ＭＳ ゴシック", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 128);
            Label.Font = new Font("ＭＳ ゴシック", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 128);
            Label.BackColor = XmlColorLib.GetColor(XmlColorLib.Colors.LabelColor);
            LabelVisible = false;
            mDataList = new List<ComboData>();

        }

        /// <summary>
        /// フォーカスイベント
        /// </summary>
        public new void Focus()
        {
            ComboBox.SelectAll();
            base.Focus();
        }

        /// <summary>
        /// フォーカス中のイベント
        /// </summary>
        /// <param name="e"></param>
        [DebuggerStepThrough()]
        protected override void OnEnter(EventArgs e)
        {
            Common.SetToolStripStatusLabel(this, string.Format("{0}を選択して下さい。", Caption));
            ComboBox.SelectAll();
            ComboBox.BackColor = XmlColorLib.GetColor(XmlColorLib.Colors.GotFocusColor);
            CurrentIndex = ComboBox.SelectedIndex;
        }

        /// <summary>
        /// 作成イベント
        /// </summary>

        protected override void OnCreateControl()
        {

            base.OnCreateControl();
            if (AllowEmpty)
            {
                ComboBox.BackColor = XmlColorLib.GetColor(XmlColorLib.Colors.LostFocusColor);
            }
            else
            {
                ComboBox.BackColor = XmlColorLib.GetColor(XmlColorLib.Colors.HissuColor);
            }
            // Me.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            ComboBox.DropDownWidth = Width;

        }

        /// <summary>
        /// フォーカス
        /// </summary>
        private void SetLostFocusColor()
        {
            SetLostFocusColor(ComboBox.Enabled);
        }
        private void SetLostFocusColor(bool enabled)
        {
            // 'FormがEnabled=falseの場合MyBase.Enable=Trueに変更してもFormがEnabled=Trueになるまで有効にならない問題の対策
            // If MyBase.Enabled Then
            if (enabled)
            {
                if (AllowEmpty)
                {

                    ComboBox.BackColor = XmlColorLib.GetColor(XmlColorLib.Colors.LostFocusColor);
                }
                else
                {
                    ComboBox.BackColor = XmlColorLib.GetColor(XmlColorLib.Colors.HissuColor);
                }
            }

            else
            {
                ComboBox.BackColor = Color.WhiteSmoke;
            }


        }

        /// <summary> 
        /// 値の追加 
        /// 
        /// _text  : ラベル表示時はラベル部分
        ///          ラベルを非表示にしているときはコンボボックスに表示される値
        ///         
        /// _value : ラベル表示時はコンボボックス部分
        ///          ラベルを非表示にしているときは表示されない値
        /// </summary>
        public void AddItem(string _text, string _value)
        {

            mDataList.Add(new ComboData(_text, _value));

            if (Label.Visible)
            {
                ComboBox.Items.Add(_value);
            }
            else
            {
                ComboBox.Items.Add(_text);
            }

        }

        /// <summary>
        /// DataTableでComboBoxに追加
        /// 一列目を text、二列目を value として追加
        /// </summary>
        public void AddItem(DataTable _item)
        {
            try
            {
                foreach (DataRow dr in _item.Rows)
                {
                    this.AddItem(dr[0].ToString(), dr[1].ToString());
                }
            }
            catch { }
        }

        /// <summary>
        /// すべてのアイテムをクリア
        /// </summary>
        public void Clear()
        {

            mDataList.Clear();
            ComboBox.Items.Clear();
            CurrentIndex = -1;

            Label.Text = string.Empty;

        }

        /// <summary>
        /// アイテムを削除
        /// </summary>
        /// <param name="_value">アイテム</param>
        public void RemoveItem(string _value)
        {

            int tg = -1;
            for (int i = 0, loopTo = mDataList.Count - 1; i <= loopTo; i++)
            {
                var cbd = mDataList[i];
                if (cbd is not null && cbd.Value.Equals(_value))
                {
                    tg = i;
                    break;
                }
            }

            if (tg > -1)
            {
                ComboBox.Items.RemoveAt(tg);
                mDataList.RemoveAt(tg);
            }

        }

        #region Validation Control
        /// <summary>
        /// 無効なテキストかをチェック
        /// </summary>
        /// <param name="_source"></param>
        /// <returns>ErrorNumbers</returns>
        public ErrorNumbers ValidateText(string _source)
        {

            // is empty.
            if (string.IsNullOrEmpty(_source))
            {
                if (AllowEmpty)
                {
                    return ErrorNumbers.OK;
                }
                else
                {
                    return ErrorNumbers.IsSelectEmpty;
                }

            }
            // OK.
            return ErrorNumbers.OK;

        }

        #endregion

    }

}