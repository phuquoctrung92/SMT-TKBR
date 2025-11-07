namespace CtrlLib.MyControls
{
    #region 入力チェックのエラー番号(ErrorNumbers)

    /// <summary>
    /// 入力チェックのエラー番号
    /// </summary>
    /// <remarks></remarks>
    public enum ErrorNumbers
    {
        /// <summary> エラーなし </summary>
        OK = 0,
        /// <summary> 必須テキスト空白 </summary>
        IsTextEmpty = 1,
        /// <summary> 必須項目未選択 </summary>
        IsSelectEmpty = 2,
        /// <summary> 日付などのフォーマットエラー </summary>
        IsInputErr = 3,
        /// <summary> 文字の長さエラー </summary>
        IsLength = 4,
        /// <summary> 禁則文字エラー </summary>
        InvalidCharError = 5,
        /// <summary> 入力値無効エラー </summary>
        InvalidCastError = 6,
        /// <summary> マイナス入力エラー </summary>
        MinusError = 7,
        /// <summary> ゼロ入力エラー </summary>
        ZeroError = 8,
        /// <summary> 小数入力不可エラー </summary>
        DecimalError = 9,
        /// <summary> 1900以前を制限 </summary>
        DateError1900 = 26
    }

    #endregion

    #region テキストボックスの入力パターン(InputPatterns)

    /// <summary>
    /// テキストボックスの入力パターン
    /// </summary>
    /// <remarks></remarks>
    /// <memo>追加時は複数個所修正が必要となります。</memo>
    public enum InputPatterns
    {
        /// <summary>すべて</summary>
        All = 0,
        /// <summary>アルファベット＋数字</summary>
        Alphabet,
        /// <summary>アルファベットのみ</summary>
        AlphabetOnly,
        /// <summary> Code(アルファベット＋数字) </summary>
        Code,
        /// <summary> CodeSp(アルファベット＋数字＋記号) </summary>
        CodeSp,
        /// <summary> Number（数字オンリー） </summary>
        Number,
        /// <summary> KanaHalf(半角「カタカナ＋数字＋スペース」) </summary>
        KatakanaHalf,
        /// <summary>メール/summary>
        Mail,
        /// <summary>ファイル</summary>
        File,
        /// <summary>電話番号</summary>
        Tel,
        /// <summary>急便番号</summary>
        Zip,
        /// <summary>バーコード</summary>
        Barcode
    }

    #endregion

    #region 日付の入力パターン(DateFormats)

    /// <summary>
    /// 日付の入力パターン
    /// </summary>
    /// <remarks></remarks>
    /// <memo>追加時はCommonのSetDatePropertyにも追加お願いします。</memo>
    public enum DateFormats
    {
        /// <summary>年月日</summary>
        yyyyMMdd,
        /// <summary>年月</summary>
        yyyyMM,
        /// <summary>月日</summary>
        MMdd,
        /// <summary>年</summary>
        yyyy,
        /// <summary>月</summary>
        MM,
        /// <summary>日</summary>
        dd
    }

    #endregion

    #region 時間の入力パターン(TimeFormats)

    /// <summary>
    /// 時間の入力パターン
    /// </summary>
    /// <remarks></remarks>
    /// <memo>追加時はCommonのSetTimePropertyにも追加お願いします。</memo>
    public enum TimeFormats
    {
        /// <summary>時分</summary>
        HHmm,
        /// <summary>時</summary>
        HH,
        /// <summary>分</summary>
        mm
    }

    #endregion

    #region SpreadのCell設定(CellTypes)

    /// <summary>
    /// SpreadのCell設定
    /// </summary>
    /// <remarks></remarks>
    public enum CellTypes
    {
        /// <summary> 非表示 </summary>
        Hidden = Cell.Hidden,

        /// <summary> 読取テキスト </summary>
        ReadText = ReadOrWrite.Read + Cell.Text,

        /// <summary> 読取数字 </summary>
        ReadNumber = ReadOrWrite.Read + Cell.Number,
        /// <summary> 読取日付 </summary>
        ReadDate = ReadOrWrite.Read + Cell.Date,

        /// <summary> チェックボックス </summary>
        ReadCheckBox = ReadOrWrite.Read + Cell.CheckBox,

        /// <summary> 書込テキスト </summary>
        WriteText = ReadOrWrite.Write + Cell.Text,

        /// <summary> 書込数字 </summary>
        WriteNumber = ReadOrWrite.Write + Cell.Number,

        /// <summary> 書込日付 </summary>
        WriteDate = ReadOrWrite.Write + Cell.Date,

        /// <summary> チェックボックス </summary>
        WriteCheckBox = ReadOrWrite.Write + Cell.CheckBox,

        /// <summary> コンボボックス </summary>
        ComboBox = ReadOrWrite.Write + Cell.ComboBox,

        /// <summary> ボタン </summary>
        Button = ReadOrWrite.Write + Cell.Button,

        /// <summary> マルチオプション </summary>
        Option = ReadOrWrite.Write + Cell.Option
    }

    /// <summary>
    /// SpreadのCell設定
    /// </summary>
    /// <remarks></remarks>
    public enum Cell
    {
        /// <summary> 非表示 </summary>
        Hidden = -1,
        /// <summary> テキスト </summary>
        Text,

        /// <summary> 数字 </summary>
        Number,
        /// <summary> 日付 </summary>
        Date,

        /// <summary> チェックボックス </summary>
        CheckBox,
        /// <summary> コンボボックス </summary>
        ComboBox,
        /// <summary> ボタン </summary>
        Button,
        /// <summary> マルチオプション </summary>
        Option

    }

    /// <summary>
    /// 読み取り書き取り
    /// </summary>
    /// <remarks></remarks>
    public enum ReadOrWrite
    {
        /// <summary> 読み取り </summary>
        Read = 0,
        /// <summary> 書き取り </summary>
        Write = 100
    }

    #endregion

    #region 貼り付けタイプ(PasteTypes)

    /// <summary>
    /// 貼り付けタイプ
    /// </summary>
    /// <remarks></remarks>
    public enum PasteTypes
    {
        /// <summary>'貼り付け' の既定の処理を呼び出します。</summary>
        Default = 0,
        /// <summary>'貼り付け' を一切禁止します。</summary>
        Disabled,
        /// <summary>MaxLength 以上の桁数になる場合は切り捨てます。</summary>
        Range,
        /// <summary>コントロールに設定されている有効文字のみ貼り付けます。</summary>
        RangeAndRemove,
        /// <summary>コントロールに側の処理に依存します。</summary>
        Control
    }

    #endregion
    /// <summary>スプレッドモード</summary>
    public enum SpreadModes
    {
        /// <summary>表示</summary>
        Disp,
        /// <summary>入力</summary>
        Input
    }
    /// <summary>行を移動のモード</summary>
    public enum RowMoveModes
    {
        /// <summary>上</summary>
        Up = -1,
        /// <summary>下</summary>
        Down = +1
    }
    /// <summary>スプレッドパータン</summary>
    public enum SpreadPatterns
    {
        /// <summary>単一</summary>
        Single,
        /// <summary>複数</summary>
        Multi
    }

    /// <summary>スプレッド結果</summary>
    public enum SpreadResults
    {
        /// <summary>成功</summary>
        OK = 0,
        /// <summary>失敗</summary>
        Error = int.MinValue + 0x20040000,
        /// <summary>引数NULLのエラー</summary>
        ErrorArgumentNull,
        /// <summary>存在していないアクティブシートのエラー</summary>
        ErrorActiveSheetNotFound,
        /// <summary>存在していない行のエラー</summary>
        ErrorRowNotFound,
        /// <summary>インデックスが範囲外ですのエラー</summary>
        ErrorIndexOutOfRange
    }

}