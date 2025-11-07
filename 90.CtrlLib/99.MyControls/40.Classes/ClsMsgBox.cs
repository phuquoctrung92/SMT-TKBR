using System;
using System.Diagnostics;
using System.Windows.Forms;
using CtrlLib.Message;
using SmtLib;

namespace CtrlLib
{


    /// <summary>
    /// メッセージクラス
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create  1.00
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class ClsMsgBox
    {

        #region Constant Value

        /// <summary> メッセージ取得失敗時のメッセージ内容 </summary>
        private const string NOT_EXIST_MESSAGE = "メッセージが存在しませんでした。";
        /// <summary> データベースエラー時のメッセージ内容 </summary>
        private const string DB_ERROR_MESSAGE = "データベースエラーが発生しました。システム管理者に連絡して下さい。";
        /// <summary> システムエラー時のメッセージ内容 </summary>
        private const string SYSTEM_ERROR_MESSAGE = "システムエラーが発生しました。システム管理者に連絡して下さい。";

        #endregion
        /// <summary> テキストボックス入力値 </summary>
        private static string txtBoxValue;


        #region Enumerated type
        /// <summary>デフォルトボタン</summary>
        public enum DefaultButtons
        {
            /// <summary>ボタン１</summary>
            Button1,
            /// <summary>ボタン２</summary>
            Button2,
            /// <summary>ボタン３</summary>
            Button3
        }

        /// <summary> メッセージボックスの種類 </summary>
        public enum MessageTypes
        {
            /// <summary> Windows のメッセージボックス </summary>
            Normal,
            /// <summary> カスタムタイプ のメッセージボックス(Form) </summary>
            Custom,
            /// <summary> テキストボックス付きカスタムタイプ のメッセージボックス(Form) </summary>
            TextCustom
        }

        #endregion

        #region Method

        /// <summary> メッセージ表示(置き換えなし) </summary>
        /// <param name="title"> メッセージボックスのタイトル </param>
        /// <param name="message_cd"> メッセージコード </param>
        /// <param name="default_button"> 確認メッセージのみキャンセルボタンへ変更できる </param>
        /// <returns> MsgBoxResult </returns>
        [DebuggerStepThrough()]
        public static DialogResult ShowMessage(string title, string message_cd, MessageBoxButtons default_button = MessageBoxButtons.OK)
        {

            return Init(MessageTypes.Custom, message_cd, null, title, default_button);

        }

        /// <summary> メッセージ表示(置き換え１つ) </summary>
        /// <param name="title"> メッセージボックスのタイトル </param>
        /// <param name="message_code"> メッセージコード </param>
        /// <param name="replace_value"> 置き換え文字列 </param>
        /// <param name="default_button"> 確認メッセージのみキャンセルボタンへ変更できる </param>
        /// <returns> MsgBoxResult </returns>
        [DebuggerStepThrough()]
        public static DialogResult ShowMessage(string title, string message_code, string replace_value, MessageBoxButtons default_button = MessageBoxButtons.OK)
        {

            return Init(MessageTypes.Custom, message_code, new string[] { replace_value }, title, default_button);

        }

        /// <summary> テキストボックスつきメッセージ表示(置き換え１つ) </summary>
        /// <param name="title"> メッセージボックスのタイトル </param>
        /// <param name="message_code"> メッセージコード </param>
        /// <param name="replace_value"> 置き換え文字列 </param>
        /// <param name="_txtBoxValue"> 確認メッセージのみキャンセルボタンへ変更できる </param>
        /// <param name="default_button"> 確認メッセージのみキャンセルボタンへ変更できる </param>
        /// <returns> MsgBoxResult </returns>
        [DebuggerStepThrough()]
        public static DialogResult ShowMessageTextBox(string title, string message_code, string replace_value, ref string _txtBoxValue, MessageBoxButtons default_button = MessageBoxButtons.OK)
        {
            txtBoxValue = _txtBoxValue;

            var ret = Init(MessageTypes.TextCustom, message_code, new string[] { replace_value }, title, default_button);

            _txtBoxValue = txtBoxValue;
            return ret;

        }


        /// <summary> メッセージ表示(置き換え１つ) </summary>
        /// <param name="title"> メッセージボックスのタイトル </param>
        /// <param name="message_code"> メッセージコード </param>
        /// <param name="ex"> 置き換え文字列 </param>
        /// <param name="default_button"> 確認メッセージのみキャンセルボタンへ変更できる </param>
        /// <returns> MsgBoxResult </returns>
        [DebuggerStepThrough()]
        public static DialogResult ShowMessage(string title, string message_code, Exception ex, MessageBoxButtons default_button = MessageBoxButtons.OK)
        {
            clsLogger.Error(ex);
#if DEBUG
            return Init(MessageTypes.Custom, message_code, new string[] { ex.ToString()}, title, default_button);
#else
            return Init(MessageTypes.Custom, message_code, new string[] { ex.Message }, title, default_button);
#endif
        }

        /// <summary> メッセージ表示(置き換え２つ) </summary>
        /// <param name="title"> メッセージボックスのタイトル </param>
        /// <param name="message_cd"> メッセージコード </param>
        /// <param name="replace_value1"> 置き換え文字列１ </param>
        /// <param name="replace_value2"> 置き換え文字列２ </param>
        /// <param name="default_button"> 確認メッセージのみキャンセルボタンへ変更できる </param>
        /// <returns>MsgBoxResult</returns>
        [DebuggerStepThrough()]
        public static DialogResult ShowMessage(string title, string message_cd, string replace_value1, string replace_value2, MessageBoxButtons default_button = MessageBoxButtons.OK)
        {

            return Init(MessageTypes.Custom, message_cd, new string[] { replace_value1, replace_value2 }, title, default_button);

        }

        /// <summary> メッセージ表示 </summary>
        /// <param name="message_code"> メッセージコード </param>
        /// <param name="replace_value"> 置き換え文字列 </param>
        /// <param name="title"> メッセージボックスのタイトル </param>
        /// <param name="default_button"> 確認メッセージのみキャンセルボタンへ変更できる </param>
        /// <returns> MsgBoxResult </returns>
        [DebuggerStepThrough()]
        public static DialogResult ShowMessage(string title, string message_code, string[] replace_value, MessageBoxButtons default_button = MessageBoxButtons.OK)
        {

            return Init(MessageTypes.Custom, message_code, replace_value, title, default_button);

        }

        #endregion

        #region メッセージ作成・表示(ローカル)

        /// <summary> メッセージ作成・表示(共通) </summary>
        /// <param name="message_type"> メッセージボックスの種類 </param>
        /// <param name="message_code"> メッセージコード </param>
        /// <param name="replace_value"> 置き換え文字列 </param>
        /// <param name="title"> メッセージボックスのタイトル </param>
        /// <param name="default_button"> 確認メッセージのみキャンセルボタンへ変更できる </param>
        /// <returns> MsgBoxResult </returns>
        [DebuggerStepThrough()]
        internal static DialogResult Init(MessageTypes message_type, string message_code, string[] replace_value, string title, MessageBoxButtons default_button)
        {
            string strMsg = "";
            var msgBoxStyle = default(MessageBoxIcon);
            try
            {
                // アイコン・ボタンの設定
                switch (message_code.Substring(0, 1) ?? "")
                {
                    case ConstLib.MESSAGE_CATEGORY_INFORMATION:   // 情報
                        {
                            msgBoxStyle = MessageBoxIcon.Information;
                            default_button = MessageBoxButtons.OK;
                            break;
                        }
                    case ConstLib.MESSAGE_CATEGORY_EXCLAMATION:  // 注意
                        {
                            msgBoxStyle = MessageBoxIcon.Exclamation;
                            default_button = MessageBoxButtons.OK;
                            break;
                        }
                    case ConstLib.MESSAGE_CATEGORY_QUESTION:   // 問い合わせ
                        {
                            msgBoxStyle = MessageBoxIcon.Question;
                            default_button = MessageBoxButtons.YesNo;
                            break;
                        }
                    case ConstLib.MESSAGE_CATEGORY_CRITICAL:  // 警告
                        {
                            msgBoxStyle = MessageBoxIcon.Error;
                            default_button = MessageBoxButtons.OK;
                            break;
                        }
                }

                int intMsgNo = message_code.Length - 1;

                // メッセージの取得
                strMsg = XmlMessageLib.GetMessage(message_code.Substring(0, 1), ClsConvert.ToInteger(message_code.Substring(1, intMsgNo)));

                // メッセージ取得できなかった場合
                if (ClsCheck.IsNull(strMsg))
                    return MessageBox.Show(NOT_EXIST_MESSAGE, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

                // 文字列の置き換え
                if (replace_value is not null)
                {
                    strMsg = string.Format(strMsg, replace_value);
                }

                switch (msgBoxStyle)
                {
                    case MessageBoxIcon.Exclamation:
                        {
                            clsLogger.Error(strMsg);
                            break;
                        }
                    default:
                        {
                            clsLogger.Info(strMsg);
                            break;
                        }
                }

                // メッセージ表示
                if (message_type == MessageTypes.Custom)
                {
                    return ShowCustomMessageBox(message_code, strMsg, title, default_button);
                }
                else if (message_type == MessageTypes.TextCustom)
                {
                    return ShowCustomMessageBoxTextBox(message_code, strMsg, title, default_button);
                }

                return MessageBox.Show(strMsg, title, default_button, msgBoxStyle);
            }

            catch (Exception ex)
            {
                clsLogger.Error(ex);
                // エラーメッセージ
                ShowSystemErrorMessage(ex, title);
                return DialogResult.Cancel;
            }

        }

        /// <summary> メッセージボックスカスタム </summary>
        /// <param name="_message_cd"></param>
        /// <param name="Msg"></param>
        /// <param name="_title"></param>
        /// <param name="_default_button"></param>
        /// <returns> MsgBoxResult </returns>
        private static DialogResult ShowCustomMessageBox(string _message_cd, string Msg, string _title, MessageBoxButtons _default_button)
        {
            frmMessage frm = new frmMessage();
            frm.MessageCD = _message_cd;
            frm.Message = Msg;
            frm.DefaultButton = _default_button;
            frm.Text = _title;
            frm.MessageCategory = _message_cd.Substring(0, 1);
            frm.ShowDialog();
            if(frm.MessageCategory == ConstLib.MESSAGE_CATEGORY_QUESTION)
            {
                clsLogger.Info(frm.DialogResult.ToString());
            }
            
            return frm.DialogResult;
        }
        /// <summary> テキストボックス付きメッセージボックス </summary>
        /// <param name="_message_cd"></param>
        /// <param name="Msg"></param>
        /// <param name="_title"></param>
        /// <param name="_default_button"></param>
        /// <returns> MsgBoxResult </returns>
        private static DialogResult ShowCustomMessageBoxTextBox(string _message_cd, string Msg, string _title, MessageBoxButtons _default_button)
        {
            frmMessageTextBox frm = new frmMessageTextBox(txtBoxValue);
            frm.MessageCD = _message_cd;
            frm.Message = Msg;
            frm.DefaultButton = _default_button;
            frm.Text = _title;
            frm.MessageCategory = _message_cd.Substring(0, 1);
            frm.ShowDialog();
            if (frm.MessageCategory == ConstLib.MESSAGE_CATEGORY_QUESTION)
            {
                clsLogger.Info(frm.DialogResult.ToString());
            }

            txtBoxValue = frm.InputText;

            return frm.DialogResult;
        }

        /// <summary> ビジネスロジックにてException発生時呼び出されるメソッド </summary>
        /// <param name="ex"> Exception </param>
        /// <param name="title"> タイトル </param>
        [DebuggerStepThrough()]
        public static void SystemErrorMessage(Exception ex, string title = "")
        {
            try
            {
                ShowSystemErrorMessage(ex, title);
                clsLogger.Error(ex);
            }
            catch
            {
                //Skip this exception
            }
        }

        /// <summary> データベースエラーメッセージ表示 </summary>
        /// <param name="_ex"> Exception </param>
        /// <param name="_title"> メッセージタイトル </param>
        public static void ShowDataBaseErrorMessage(Exception _ex, string _title = "")
        {
            string title;

            // メッセージボックスタイトル設定
            if (ClsCheck.IsNull(_title))
            {
                title = _ex.TargetSite.DeclaringType.Name;
            }
            else
            {
                title = _title;
            }

            // DBエラーメッセージの表示
            MessageBox.Show(DB_ERROR_MESSAGE, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary> システムエラーメッセージ表示 </summary>
        /// <param name="ex"> Exception </param>
        /// <param name="title"> メッセージタイトル </param>
        [DebuggerStepThrough()]
        private static void ShowSystemErrorMessage(Exception ex, string title = "")
        {
            var message = new System.Text.StringBuilder();
            // Dim title As String

            // メッセージボックスタイトル設定
            if (ClsCheck.IsNull(title))
            {
                title = ex.TargetSite.DeclaringType.Name;
            }

            message.Append(SYSTEM_ERROR_MESSAGE + "\n");
            message.Append(" Source : " + ex.Source + "\n");
            message.Append(" Method : " + ex.TargetSite.DeclaringType.Name + "." + ex.TargetSite.Name + "\n");
            message.Append(" Message: " + ex.Message + "\n");
            message.Append(" StackTrace: " + ex.StackTrace + "\n");

            // システムエラーメッセージの表示
            MessageBox.Show(message.ToString(), title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        #endregion

    }
}