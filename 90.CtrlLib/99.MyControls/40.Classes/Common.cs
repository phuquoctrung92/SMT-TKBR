using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using SmtLib;

namespace CtrlLib.MyControls
{
    /// <summary>
    /// コントロールの共通機能
    /// </summary>
    public class Common
    {
        #region Structure

        #endregion
        /// <summary>
        /// ベースフォームの左下にテキストを表示
        /// </summary>
        /// <param name="_control">コントロール</param>
        /// <param name="_txt">表示テキスト</param>
        public static void SetToolStripStatusLabel(Control _control, string _txt = "")
        {
            MyForms.BaseForm frm = null;
            int i = 0;
            do
            {
                if (_control is not null && _control.Parent is not null)
                {
                    frm = _control.Parent as MyForms.BaseForm;
                    if (frm != null)
                    {
                        break;
                    }
                    _control = _control.Parent;
                }
                i += 1;
                if (i > 10)
                {
                    return;
                }
            }
            while (true);

            frm.ToolStripStatusLabel1.Text = _txt;

        }

        /// <summary>
        /// コントロールから現在のベースフォームを取得
        /// </summary>
        /// <param name="_control">コントロール</param>
        /// <returns></returns>
        public static MyForms.BaseForm GetOwnerForm(Control _control)
        {
            do
            {
                if (_control.Parent is MyForms.BaseForm)
                {
                    return (MyForms.BaseForm)_control.Parent;
                }
                _control = _control.Parent;
            }
            while (true);

        }
        /// <summary>チェックボックス</summary>
        public struct StcCheckBoxList
        {
            /// <summary>チェックボックスコントロール</summary>
            public CheckBox control { get; set; }
            /// <summary>値</summary>
            public string Value { get; set; }
        }

        /// <summary> TabIndex の比較 </summary>
        /// <param name="x"> ControlX </param>
        /// <param name="y"> ControlY </param>
        private static int CompareTabIndex(Control x, Control y)
        {
            return x.TabIndex - y.TabIndex;
        }

        // Private Shared Function mCreateClsMsg(ByVal message As String, ByVal pTyp As SmtLib.clsMsg.MessagType, ByVal ParamArray _replace_value() As String) As clsMsg
        // Dim ret As clsMsg = Nothing
        // Dim intMsgNo As Integer = message.Length - 1
        // Dim strMsg As String = XmlMessageLib.GetMessage(message.Substring(0, 1), ClsConvert.ToInteger(message.Substring(1, intMsgNo)))
        // If Not _replace_value Is Nothing Then
        // strMsg = String.Format(strMsg, _replace_value)
        // End If
        // ret = New clsMsg(strMsg, pTyp)
        // Return ret
        // End Function

        /// <summary> コントロールに格納されているすべてのコントロール コレクションを TabIndex 順にソートされた配列として取得します。 </summary>
        /// <param name="_control"> 検索する親コンテナを指定してください。(フォーム、ダイアログ など) </param>
        public static Control[] SortedControls(Control _control)
        {
            List<Control> list;
            int index;

            if (_control is null || _control.Controls.Count == 0)
                return new Control[] { };

            list = new List<Control>();

            var loopTo = _control.Controls.Count - 1;
            for (index = 0; index <= loopTo; index++)
                list.Add(_control.Controls[index]);
            list.Sort(CompareTabIndex);

            index = list.Count;
            while (index != 0)
            {
                list.InsertRange(index, SortedControls(list[index - 1]));
                index -= 1;
            }

            return list.ToArray();
        }

        /// <summary> カスタムコントロールの入力チェック </summary>
        /// <remarks> ここを修正時コントロールのOnKeyDowmを確認してください。 </remarks>
        /// <param name="_form">ベースフォーム</param>
        /// <param name="_control">入力確認を行うコントロールを別途指定する時は _control パラメーターに親となるコントロールを指定します。</param>
        /// <param name="_baseEnableFlg">有効化フラグ</param>
        public static bool InputAllItemCheck(MyForms.BaseForm _form, Control _control = null, bool _baseEnableFlg = false)
        {
            bool flg = _form.Enabled;
            if (_baseEnableFlg)
            {
                // チェック時だけ一時解除する。
                _form.Enabled = true;
            }

            Control[] ctls = _control is null ? SortedControls(_form) : SortedControls(_control);
            StringBox ctlText;
            DateBox ctlDate;
            TimeBox ctlTime;
            ucComboBox ctlDBCmb;
            NumberBox ctlNumber;
            CheckBox ctlCheck;
            RadioButton ctlRadio;
            // Dim ctlSpd As SpreadControl

            for (int i = 0, loopTo = ctls.Length - 1; i <= loopTo; i++)
            {
                if (ctls[i] is TabPage && ctls[i].Parent is TabControl)
                {
                    ((TabControl)ctls[i].Parent).SelectedTab = (TabPage)ctls[i];
                }

                if (ctls[i].Visible && ctls[i].Enabled)
                {

                    if (ctls[i] is StringBox)
                    {
                        // テキスト入力コントロール
                        ctlText = (StringBox)ctls[i];
                        if (ctlText.ReadOnly)
                        {
                            continue;
                        }
                        ctlText.ValidateText(ctlText.Text);
                        if (ctlText.LastErrorNumber != ErrorNumbers.OK)
                        {
                            if(ctlText.LastErrorNumber == ErrorNumbers.IsLength)
                            {
                                ClsMsgBox.ShowMessage(_form.Text, "E" + ((int)ctlText.LastErrorNumber).ToString().PadLeft(3, '0'), ctlText.Caption, ctlText.MaxLength.ToString() + "桁 以内");
                            }
                            else
                            {
                                ClsMsgBox.ShowMessage(_form.Text, "E" + ((int)ctlText.LastErrorNumber).ToString().PadLeft(3, '0'), ctlText.Caption);
                            }
                            ctlText.SelectAll();
                            ctlText.Focus();
                            return false;
                        }
                    }

                    else if (ctls[i] is DateBox)
                    {
                        // 日付入力コントロール
                        ctlDate = (DateBox)ctls[i];
                        if (ctlDate.ReadOnly)
                        {
                            continue;
                        }
                        ctlDate.ValidateText(ctlDate.Text);
                        if (ctlDate.LastErrorNumber != ErrorNumbers.OK)
                        {
                            ClsMsgBox.ShowMessage(_form.Text, "E" + ((int)ctlDate.LastErrorNumber).ToString().PadLeft(3, '0'), ctlDate.Caption);
                            ctlDate.SelectAll();
                            ctlDate.Focus();
                            return false;
                        }
                    }

                    else if (ctls[i] is TimeBox)
                    {
                        // 日付入力コントロール
                        ctlTime = (TimeBox)ctls[i];
                        if (ctlTime.ReadOnly)
                        {
                            continue;
                        }

                        ctlTime.ValidateText(ctlTime.Text);
                        if (ctlTime.LastErrorNumber != ErrorNumbers.OK)
                        {
                            ClsMsgBox.ShowMessage(_form.Text, "E" + ((int)ctlTime.LastErrorNumber).ToString().PadLeft(3, '0'), ctlTime.Caption);
                            ctlTime.SelectAll();
                            ctlTime.Focus();
                            return false;
                        }
                    }

                    else if (ctls[i] is ucComboBox)
                    {
                        // コンボ選択コントロール
                        ctlDBCmb = (ucComboBox)ctls[i];
                        int ErrNum = (int)ctlDBCmb.ValidateText(ctlDBCmb.SelectedValue);

                        if (ErrNum != (int)ErrorNumbers.OK)
                        {
                            ClsMsgBox.ShowMessage(_form.Text, "E" + ErrNum.ToString().PadLeft(3, '0'), ctlDBCmb.Caption);
                            ctlDBCmb.Focus();
                            return false;
                        }
                    }

                    else if (ctls[i] is NumberBox)
                    {
                        // 数値コントロール
                        ctlNumber = (NumberBox)ctls[i];
                        if (ctlNumber.ReadOnly)
                        {
                            continue;
                        }
                        string strRep;
                        int ErrNum = ctlNumber.ValidateText(ctlNumber.Text);
                        if (ErrNum != (int)ErrorNumbers.OK)
                        {
                            switch (ErrNum)
                            {
                                case (int)ErrorNumbers.IsLength:
                                    {
                                        if (ctlNumber.DecimalLength == 0)
                                        {
                                            strRep = ctlNumber.IntegerLength + "桁 以内";
                                        }
                                        else
                                        {
                                            strRep = " 整数 " + ctlNumber.IntegerLength + "桁," + " 小数 " + ctlNumber.DecimalLength + "桁" + " 以内";
                                        }
                                        ClsMsgBox.ShowMessage(_form.Text, "E" + ErrNum.ToString().PadLeft(3, '0'), ctlNumber.Caption, strRep);
                                        break;
                                    }

                                case (int)ErrorNumbers.DecimalError:
                                    {
                                        // E009: {0}ため、{1}できません。 当てはめるパラメーターが不明です..
                                        string arg0 = string.Format("{0} の入力値誤りの", ctlNumber.Caption);
                                        string arg1 = "{1}";  // 
                                        ClsMsgBox.ShowMessage(_form.Text, string.Format("E{0:d3}", ErrNum), arg0, arg1);
                                        break;
                                    }

                                default:
                                    {
                                        ClsMsgBox.ShowMessage(_form.Text, "E" + ErrNum.ToString().PadLeft(3, '0'), ctlNumber.Caption);
                                        break;
                                    }
                            }

                            ctlNumber.SelectAll();
                            ctlNumber.Focus();
                            return false;
                        }
                    }

                    else if (ctls[i] is CheckBox)
                    {
                        // チェックボックスコントロール
                        ctlCheck = (CheckBox)ctls[i];
                        int ErrNum = ctlCheck.ValidateCheck();
                        if (ErrNum != (int)ErrorNumbers.OK)
                        {
                            ClsMsgBox.ShowMessage(_form.Text, "E" + ErrNum.ToString().PadLeft(3, '0'), ctlCheck.AlertCaption);
                            ctlCheck.Focus();
                            return false;
                        }
                    }

                    else if (ctls[i] is RadioButton)
                    {
                        // ラジオボタンコントロール
                        ctlRadio = (RadioButton)ctls[i];
                        int ErrNum = ctlRadio.ValidateCheck();
                        if (ErrNum != (int)ErrorNumbers.OK)
                        {
                            ClsMsgBox.ShowMessage(_form.Text, "E" + ErrNum.ToString().PadLeft(3, '0'), ctlRadio.AlertCaption);
                            ctlRadio.Focus();
                            ctlRadio.Checked = false;
                            return false;
                        }
                    }

                }

            }
            if (_baseEnableFlg)
            {
                // 状態を戻す。
                _form.Enabled = flg;
            }
            return true;

        }

        /// <summary> 値のチェックを行う </summary>
        /// <param name="strValue"> チェックする値 </param>
        /// <param name="intInputPtn"> EnumInpTxtChar </param>
        /// <param name="intMaxLength"> 桁数 </param>
        /// <param name="AllowInputQuotation"> クオーテーションを許可 </param>
        /// <param name="AllowInputVerticalBar"> バーチカルバーを許可 </param>
        /// <returns> EnumErrNumber </returns>
        public static ErrorNumbers IsInPutTxtChar(string strValue, InputPatterns intInputPtn, int intMaxLength, bool AllowInputQuotation = true, bool AllowInputVerticalBar = true)
        {
            char c;

            // 禁則文字チェック導入
            if (ClsCheck.IsProhibitionCharacter(strValue, _allow_quotation: AllowInputQuotation, _allow_VerticalBar: AllowInputVerticalBar))
            {
                return ErrorNumbers.IsInputErr;
            }

            for (int iLp = 1, loopTo = strValue.Length; iLp <= loopTo; iLp++)
            {
                c = Conversions.ToChar(Strings.Mid(strValue, iLp, 1));
                if (intInputPtn == InputPatterns.All || intInputPtn == InputPatterns.Alphabet)
                {
                }
                // All.英字は全てOK
                else if (Strings.AscW(c) == Strings.AscW(" ") && (intInputPtn == InputPatterns.CodeSp || intInputPtn == InputPatterns.KatakanaHalf))
                {
                }
                // スペースはSpついてるものとKana
                else if (ClsCheck.IsNarrowAlpha(c) && (intInputPtn == InputPatterns.KatakanaHalf || intInputPtn == InputPatterns.Code || intInputPtn == InputPatterns.CodeSp || intInputPtn == InputPatterns.AlphabetOnly))
                {
                }
                // アルファベットはカタカナとCode
                else if (ClsCheck.IsNumberKey(c) && (intInputPtn == InputPatterns.Code || intInputPtn == InputPatterns.CodeSp || intInputPtn == InputPatterns.Number))
                {
                }
                // 数値は数値とCode
                else if (intInputPtn == InputPatterns.KatakanaHalf && (ClsCheck.IsKanaKey(c) || ClsCheck.IsNumberKey(c) || ClsCheck.IsSignKey(c)))
                {
                }
                // カタカナは数字と記号いけるように。
                else if (intInputPtn == InputPatterns.CodeSp && (ClsCheck.IsNumericKey(c) || ClsCheck.IsSignKey(c)))
                {
                }
                // 'コードSPに記号許可
                else if (intInputPtn == InputPatterns.File && ClsCheck.IsFileKey(c))
                {
                }
                else if (intInputPtn == InputPatterns.Mail && ClsCheck.IsEmailKey(c))
                {
                }
                else if (intInputPtn == InputPatterns.Tel && ClsCheck.IsTellKey(c))
                {
                }
                else if (intInputPtn == InputPatterns.Zip && ClsCheck.IsZipKey(c))
                {
                }
                else if (intInputPtn == InputPatterns.Barcode && ClsCheck.IsNarrow(Conversions.ToString(c)))
                {
                }
                else
                {
                    return ErrorNumbers.IsInputErr;
                }

            }

            return ErrorNumbers.OK;

        }

        /// <summary> KeyDown時のエラーメッセージ </summary>
        /// <param name="_error_number"></param>
        /// <returns></returns>
        public static bool ControlKeyDownErr(ErrorNumbers _error_number)

        {

            // ControlKeyDownErr(_error_number, Nothing)
            return ControlKeyDownErr(_error_number, null, null);

        }

        // ''' <summary> KeyDown時のエラーメッセージ </summary>
        // ''' <param name="_error_number"></param>
        // ''' <param name="_replace_value"></param>
        // ''' <returns></returns>
        // Public Shared Function ControlKeyDownErr( _
        // ByVal _error_number As ErrorNumbers, 
        // ByVal ParamArray _replace_value() As String _
        // ) As Boolean

        /// <summary> KeyDown時のエラーメッセージ </summary>
        [DebuggerStepThrough()]
        public static bool ControlKeyDownErr(ErrorNumbers _error_number, Control _control, params string[] _replace_value)
        {

            string message = string.Empty;

            switch (_error_number)
            {
                case ErrorNumbers.OK:
                    {
                        // Dim msg As New clsMsg("", SmtLib.clsMsg.MessagType.INFORMATION)
                        // SetMsgLabel(_control, msg)
                        return true;
                    }
                case ErrorNumbers.IsTextEmpty:
                    {
                        message = "E001"; // VALIDATION_ERROR_EMPTY
                        break;
                    }
                case ErrorNumbers.IsSelectEmpty:
                    {
                        message = "E002"; // VALIDATION_ERROR_NO_SELECTED
                        break;
                    }
                case ErrorNumbers.IsInputErr:
                    {
                        message = "E003"; // VALIDATION_ERROR_UNJUST_VALUE
                        break;
                    }
                case ErrorNumbers.IsLength:
                    {
                        message = "E012"; // VALIDATION_ERROR_OVERFLOW
                        break;
                    }
                case ErrorNumbers.InvalidCharError:
                    {
                        message = "E015"; // VALIDATION_ERROR_INVALID_CHARACTER
                        break;
                    }
                case ErrorNumbers.InvalidCastError:
                    {
                        message = "E016"; // VALIDATION_ERROR_INVALID_CAST
                        break;
                    }
                case ErrorNumbers.MinusError:
                    {
                        message = "E017"; // VALIDATION_ERROR_INPUT_NEGATIVEVALUE
                        break;
                    }
                case ErrorNumbers.ZeroError:
                    {
                        message = "E018"; // VALIDATION_ERROR_INPUT_ZERO_VALUE
                        break;
                    }
                case ErrorNumbers.DecimalError:
                    {
                        message = "E019"; // VALIDATION_ERROR_INPUT_DECIMAL_VALUE
                        break;
                    }
                case ErrorNumbers.DateError1900:
                    {
                        message = "E026";
                        break;
                    }

            }

            if (!ClsCheck.IsNull(message))
            {

                ClsMsgBox.ShowMessage(ConstLib.VALIDATION_ERROR_TITLE, message, _replace_value);
                // If _control IsNot Nothing Then

                // Dim clsMsg As clsMsg = mCreateClsMsg(message, SmtLib.clsMsg.MessagType.EXCLAMATION, _replace_value)
                // SetMsgLabel(_control, clsMsg)
                // Else
                // ClsMsgBox.ShowMessage(ClsMsgBox.MessageTypes.Normal, message, _replace_value, VALIDATION_ERROR_TITLE)
                // End If


                return false;

            }

            return true;

        }

        /// <summary> 日付入力パターンでPropertyを変更 </summary>
        /// <param name="_customFormat">DateFormats</param>
        /// <param name="_MaxLength">返す桁数</param>
        /// <param name="_formatString">返すDateFormats</param>
        public static void SetDateProperty(DateFormats _customFormat, ref int _MaxLength, ref string _formatString)
        {

            switch (_customFormat)
            {
                case DateFormats.yyyyMM:
                    {
                        _MaxLength = 7;
                        _formatString = "yyyy/MM";
                        break;
                    }
                case DateFormats.MMdd:
                    {
                        _MaxLength = 5;
                        _formatString = "MM/dd";
                        break;
                    }
                case DateFormats.yyyy:
                    {
                        _MaxLength = 4;
                        _formatString = "yyyy";
                        break;
                    }
                case DateFormats.MM:
                    {
                        _MaxLength = 2;
                        _formatString = "MM";
                        break;
                    }
                case DateFormats.dd:
                    {
                        _MaxLength = 2;
                        _formatString = "dd";
                        break;
                    }

                default:
                    {
                        _MaxLength = 10;
                        _formatString = "yyyy/MM/dd";
                        break;
                    }
            }
        }

        /// <summary> 時間入力パターンでPropertyを変更 </summary>
        /// <param name="_customFormat">DateFormats</param>
        /// <param name="_MaxLength">返す桁数</param>
        /// <param name="_formatString">返すDateFormats</param>
        public static void SetTimeProperty(TimeFormats _customFormat, ref int _MaxLength, ref string _formatString)
        {
            switch (_customFormat)
            {
                case TimeFormats.HH:
                    {
                        _MaxLength = 2;
                        _formatString = "HH";
                        break;
                    }
                case TimeFormats.mm:
                    {
                        _MaxLength = 2;
                        _formatString = "mm";
                        break;
                    }
                default:
                    {
                        _MaxLength = 5;
                        _formatString = "HH:mm";
                        break;
                    }
            }
        }

        /// <summary> 入力値の範囲チェック </summary>
        /// <param name="_strFrom"> 前 </param>
        /// <param name="_strTo"> 後 </param>
        /// <param name="_bolDate"> 省略可：省略時は日付じゃない </param>
        /// <returns> 範囲OKまたは空白：True NG：False </returns>
        public static bool InputHaniCheck(string _strFrom, string _strTo, bool _bolDate = false)
        {

            string strFrom = _strFrom;
            string strTo = _strTo;

            if (ClsCheck.IsNull(strFrom) || ClsCheck.IsNull(strTo))
            {
                return true;
            }

            if (_bolDate)
            {
                if (Information.IsDate(strFrom))
                    strFrom = Conversions.ToDate(strFrom).ToString("yyyyMMdd");
                if (Information.IsDate(strTo))
                    strTo = Conversions.ToDate(strTo).ToString("yyyyMMdd");
            }

            if (Operators.CompareString(strFrom, strTo, false) > 0)
            {
                return false;
            }

            return true;

        }
        /// <summary>チェックボックス一覧のセット</summary>
        /// <param name="_ctl">コントロール</param>
        /// <param name="_dt">DataTable</param>
        /// <param name="_MaxCnt">カウント</param>
        /// <param name="_CtlNM">コントロール名</param>
        /// <param name="_FieldCD">列コード</param>
        /// <param name="_FieldNM">列名</param>
        /// <param name="_CheckMode">チェック状況</param>
        /// <param name="_FieldCheck">チェック列名</param>
        /// <returns></returns>
        public static StcCheckBoxList[] SetCheckBoxList(Control _ctl, DataTable _dt, int _MaxCnt, string _CtlNM, string _FieldCD = "MEICD", string _FieldNM = "MEINM", bool _CheckMode = false, string _FieldCheck = "CHECKED")
        {
            StcCheckBoxList[] stc = null;
            int Cnt = 0;

            for (int i = 1, loopTo = _MaxCnt; i <= loopTo; i++)
            {
                var chk = _ctl.Controls[_CtlNM + i] as CheckBox;
                if (chk != null)
                {
                    if (_dt is not null && _dt.Rows.Count > Cnt)
                    {
                        if (Cnt == 0)
                        {
                            stc = new StcCheckBoxList[Cnt + 1];
                        }
                        else
                        {
                            Array.Resize(ref stc, Cnt + 1);
                        }

                        stc[Cnt].control = chk;

                        stc[Cnt].control.Text = _dt.Rows[Cnt][_FieldNM].ToString();
                        stc[Cnt].Value = _dt.Rows[Cnt][_FieldCD].ToString();
                        stc[Cnt].control.Visible = true;

                        if (_CheckMode && (_dt.Rows[Cnt][_FieldCheck].ToString() ?? "") == ConstLib.CST_CHECKED)
                        {
                            stc[Cnt].control.Checked = true;
                        }
                        else
                        {
                            stc[Cnt].control.Checked = false;
                        }

                        Cnt += 1;
                    }
                    else
                    {
                        chk.Checked = false;
                        chk.Visible = false;
                    }
                }
            }

            return stc;
        }

        /// <summary> 次のコントロールへフォーカスを移動する </summary>
        /// <param name="_current_control"> 現在のコントロール </param>
        /// <param name="_parent_control"> 移動先選択用(Panelとかあるため) </param>
        /// <param name="_forward"> オーダー内を前方に移動する場合は true。後方に移動する場合は false。 </param>
        public static void SelectNextControl(ref Control _current_control, Control _parent_control, bool _forward)
        {
            if(_parent_control.Parent is Panel || _parent_control.Parent is GroupBox || _parent_control.Parent is TabControl)
            {
                SelectNextControl(ref _current_control, _parent_control.Parent, _forward);
            }
            else
            {
                _parent_control.Parent.SelectNextControl(_current_control, _forward, true, true, true);
            }
        }
    }

}