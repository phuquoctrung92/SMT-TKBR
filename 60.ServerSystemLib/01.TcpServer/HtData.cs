using SmtLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerSystemLib
{
    /// <summary>
    /// 表示区分
    /// </summary>
    public enum DisplayKB
    {
        /// <summary> アップデート　</summary>
        HT000,
        /// <summary> 印字検品 </summary>
        HT100,
        /// <summary> 封入検品 </summary>
        HT200,
        /// <summary> オンデマンド窓検品 </summary>
        HT300,
        /// <summary> ダミー消込 </summary>
        HT400,
        /// <summary> ｱﾄﾞﾐ封入検品 </summary>
        HT500,
        /// <summary> ｱﾄﾞﾐ同封検品 </summary>
        HT600,
    }

    /// <summary>
    /// 操作区分
    /// </summary>
    public enum ActionKB
    {
        /// <summary> チェック </summary>
        C,
        /// <summary> ロード </summary>
        L,
        /// <summary> 取得 </summary>
        G,
        /// <summary> 登録 </summary>
        E,
        /// <summary> 削除 </summary>
        D,
        /// <summary> 削除チェック </summary>
        DC,
        /// <summary> 登録チェック </summary>
        EC,
        /// <summary> 一括取得 </summary>
        B,
        /// <summary> 追加 </summary>
        EG
    }

    /// <summary>
    /// 操作区分内容
    /// </summary>
    public enum ActionSub
    {
        /// <summary> アップデート </summary>
        Update,
        /// <summary> 管理番号を読取処理 </summary>
        ReadKanriNo,
        /// <summary> バーコードを読取処理 </summary>
        ReadBarcode,
        /// <summary> 検品処理 </summary>
        Kenpin,
        /// <summary> 件数取得 </summary>
        GetKensu
    }

    /// <summary>
    /// 送信データ区分
    /// </summary>
    public enum SendDataKbn
    {
        /// <summary> 正常 </summary>
        Normal = 0,
        /// <summary> エラー </summary>
        Error = 1
    }

    /// <summary>
    /// ハンディターミナル受信データ
    /// </summary>
    public class HtReceiveData
    {

        /// <summary>
        /// 表示区分
        /// </summary>
        public DisplayKB kbn { get; protected set; }

        /// <summary>
        /// 区分一覧
        /// </summary>
        public string kbnS { get { return kbn.ToString(); } }

        /// <summary>
        /// BHTシリアル番号
        /// </summary>
        public string BHTSNo { get; protected set; }

        /// <summary>
        /// ユーザー
        /// </summary>
        //public string User { get; protected set; }

        /// <summary>
        /// 操作区分
        /// </summary>
        public ActionKB Action { get; protected set; }

        /// <summary>
        /// 操作区分内容
        /// </summary>
        public ActionSub ActionSub { get; protected set; }

        /// <summary>
        /// 取得データ
        /// </summary>
        public List<string> Value { get; protected set; }

        public byte[] File { get; set; }

        public HtSendData SetData(byte[] myData, ref string resMsg)
        {
            HtSendData result = new HtSendData();
            try
            {
                resMsg = Const_Encoding.UTF8.GetString(myData, 0, myData.TakeWhile(x=>x != Const_Encoding.UTF8.GetBytes(ConstKrsv.SEPARATOR_File)[0]).Count());
                
                result = SetData(resMsg);
                File = myData.SkipWhile(x => x != Const_Encoding.UTF8.GetBytes(ConstKrsv.SEPARATOR_File)[0]).Skip(1).ToArray();
            }
            catch
            {
                string erMsg = "引数の定義が違います";
                clsLogger.Error(string.Format("{0}:{1}", erMsg, myData));
                result.CreateError(erMsg);
            }
            return result;
        }

        public HtSendData SetData(string myData)
        {
            HtSendData result = new HtSendData();
            if (string.IsNullOrWhiteSpace(myData))
            {
                result.CreateError("引数がありません");
                return result;
            }

            Value = new List<string>();

            try
            {

                string[] s = myData.Split(ConstKrsv.SEPARATOR_Data[0]);
                int i = 0;
                kbn = (DisplayKB)Enum.Parse(typeof(DisplayKB), s[i++], true);
                BHTSNo = s[i++];

                Action = (ActionKB)Enum.Parse(typeof(ActionKB), s[i++], true);
                ActionSub = (ActionSub)Enum.Parse(typeof(ActionSub), s[i++], true);

                if (s.Length < i) { return result; }

                for (int a = i; a < s.Length; a++)
                {
                    Value.Add(s[a]);
                }
            }
            catch
            {
                string erMsg = "引数の定義が違います";
                clsLogger.Error(string.Format("{0}:{1}", erMsg, myData));
                result.CreateError(erMsg);
            }
            return result;
        }

    }

    /// <summary>
    /// ハンディターミナル送信データ
    /// </summary>
    public class HtSendData
    {
        public const string DATA_KBN_NORMAL = "0";
        public const string DATA_KBN_ERROR = "1";

        public HtSendData()
        {
            _data = new List<string>();
            DataKbn = DATA_KBN_NORMAL;
        }

        string _dataKbn;
        /// <summary>
        /// 送信データ区分
        /// </summary>
        public string DataKbn
        {
            get
            {
                return _dataKbn;
            }
            set
            {
                _dataKbn = value;
                // _data.Add(_dataKbn);
            }
        }

        List<string> _data;
        byte[] _file;
        /// <summary>
        /// 送信データ
        /// </summary>
        public List<string> Data { get { return _data; } }
        public byte[] File { get { return _file; } set { _file = value; } }
        public void Clear()
        {
            Data.Clear();
            _file = null;
        }


        /// <summary>
        /// 操作ログ操作内容
        /// </summary>
        public string LogAction { get; set; } = "";
        /// <summary>
        /// 操作ログ結果
        /// </summary>
        public string LogResult { get; set; } = "";


        /// <summary>
        /// データ追加
        /// </summary>
        /// <param name="value"></param>
        public void Add(string value)
        {
            // 最初に送信データ区分を設定
            if (_data == null)
            {
                _data = new List<string>();
            }

            // データに追加
            _data.Add(value);
        }
        public void Add(object value)
        {
            // データに追加
            Add(value.ToString());
        }

        public void CreateError(string message, string logAction = null)
        {
            Clear();
            Add(message);
            DataKbn = HtSendData.DATA_KBN_ERROR;
            LogResult = message;
            if (!clsUtil.IsNull(logAction)) LogAction = logAction;
        }

        public void CreateSuccess(string message, string logAction = null, params string[] Data)
        {
            Clear();
            Add(message);
            foreach (string d in Data)
            {
                Add(d);
            }
            DataKbn = HtSendData.DATA_KBN_NORMAL;
            LogResult = message;
            if (!clsUtil.IsNull(logAction)) LogAction = logAction;
        }
    }
}
