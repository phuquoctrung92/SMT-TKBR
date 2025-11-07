
namespace SmtLib
{
    /// <summary>列挙共通</summary>
    public static class Enums
    {

        /// <summary>
        /// フォームの動作モードを定義します。
        /// </summary>
        public enum OperatingModes : int
        {
            /// <summary> デフォルトモード </summary>
            NonSelected = 0,
            /// <summary> 検索モード </summary>
            Searching,
            /// <summary> 新規登録モード </summary>
            Adding,
            /// <summary> 修正モード </summary>
            Editing,
            /// <summary> 削除モード </summary>
            Deleteing,
            /// <summary> 複写追加モード </summary>
            CopyAdding,
            /// <summary> 表示モード </summary>
            Showing,
            /// <summary> エラー </summary>
            Error = -999
        }

        /// <summary>
        /// フォームの戻り値を定義します。
        /// </summary>
        public enum FormResults : int
        {
            /// <summary> キャンセル・閉じる </summary>
            Canceled = 0,
            /// <summary> 選択(検索モード時) </summary>
            Selected,
            /// <summary> 新規登録 </summary>
            Inserted,
            /// <summary> 修正 </summary>
            Updated,
            /// <summary> 削除 </summary>
            Deleted,
            /// <summary> 確定 </summary>
            Decide
        }

    }
}