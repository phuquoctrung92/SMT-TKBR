using System;
using System.Collections.Generic;
using System.Data;

namespace SmtLib
{

    public class ClsXml
    {
        #region XML定義定数

        /// <summary> PATH.XML PATH用ノード名 </summary>
        public const string XML_PATH_NODE_NAME = "PATH";
        /// <summary> PATH.XML LOG用メンバー名(ID) </summary>
        public const string XML_PATH_MEMBER_ID = "ID";
        /// <summary> PATH.XML LOG用メンバー名(DIR) </summary>
        public const string XML_PATH_MEMBER_DIR = "DIR";

        /// <summary> ImgSettings.XML TEMP用ノード名 </summary>
        public const string XML_IMG_SETTINGS_NODE_NAME = "TEMP";
        /// <summary> PATH.XML LOG用メンバー名(ID) </summary>
        public const string XML_IMG_SETTINGS_MEMBER_ID = "ID";
        /// <summary> PATH.XML LOG用メンバー名(DIR) </summary>
        public const string XML_IMG_SETTINGS_MEMBER_FILENM = "FILENM";

        /// <summary> PRINTER.XML PRINTER用ノード名 </summary>
        public const string XML_PRINTER_NODE_NAME = "PRINTER";
        /// <summary> PRINTER.XML PRINTER用メンバー名(VALUE) </summary>
        public const string XML_PRINTER_MEMBER_VALUE = "VALUE";

        #endregion

        #region Variable Value

        private DataSet m_dataset;
        private string m_xml_file;

        #endregion

        #region Constructor

        /// <summary> コンストラクタ </summary>
        /// <param name="_target_filename"> XMLファイル名 </param>
        public ClsXml(string _target_filename)
        {
            m_dataset = new DataSet();

            _target_filename = ClsPath.CombinePath(AppDomain.CurrentDomain.BaseDirectory, _target_filename);

            if ((ClsFile.GetFileName(_target_filename) ?? "") == Const_XML.FILE_Path && !ClsFile.IsExist(_target_filename))
            {

                //ClsFile.Create(Const_XML.FILE_Path, false);

                // テーブル作成
                var fileStr = new string[3];
                fileStr[0] = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
                fileStr[1] = "<" + XML_PATH_NODE_NAME + ">";
                fileStr[2] = "</" + XML_PATH_NODE_NAME + ">";
                ClsFile.Write(_target_filename, fileStr);
            }

            if ((ClsFile.GetFileName(_target_filename) ?? "") == Const_XML.FILE_PRINTER && !ClsFile.IsExist(_target_filename))
            {

                //ClsFile.Create(Const_XML.FILE_PRINTER, false);

                // テーブル作成
                var fileStr = new string[3];
                fileStr[0] = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
                fileStr[1] = "<" + XML_PRINTER_NODE_NAME + ">";
                fileStr[2] = "</" + XML_PRINTER_NODE_NAME + ">";
                ClsFile.Write(_target_filename, fileStr);

            }

            m_dataset.ReadXml(_target_filename, XmlReadMode.Auto);
            m_xml_file = _target_filename;
        }

        #endregion

        #region Method

        /// <summary> 新規データの追加 </summary>
        /// <param name="_node_name"> ノード名 </param>
        /// <param name="_member_name"> キーメンバ名 </param>
        /// <param name="_member_code"> キーメンバコード </param>
        /// <param name="_pass_member_name"> パスメンバ名 </param>
        /// <param name="_default_pass"> デフォルトパス </param>
        /// <returns> True:成功 False:失敗 </returns>
        private bool AddRow(string _node_name, string _member_name, string _member_code, string[] _pass_member_name, string[] _default_pass)
        {
            int length = Math.Min(_pass_member_name.Length, _default_pass.Length);

            // テーブル存在チェック
            if (m_dataset.Tables.IndexOf(_node_name) < 0)
            {
                // テーブルが無ければ追加する
                AddTable(_node_name, _member_name, _pass_member_name);
            }
            // 取得したデータセットより新行作成
            DataRow new_row = m_dataset.Tables[_node_name].NewRow();
            // データをセット
            new_row[_member_name] = _member_code;
            for (int i = 0, loopTo = length - 1; i <= loopTo; i++)
                new_row[_pass_member_name[i]] = _default_pass[i];
            // データセットに新行追加
            m_dataset.Tables[_node_name].Rows.Add(new_row);

            return true;
        }

        /// <summary> テーブルの追加 </summary>
        /// <param name="_node_name"> ノード名 </param>
        /// <param name="_member_name"> キーメンバ名 </param>
        /// <param name="_pass_member_name"> パスメンバ名 </param>
        private void AddTable(string _node_name, string _member_name, string[] _pass_member_name)
        {
            // 新規データテーブルの作成
            var table = new DataTable(_node_name);
            table.Columns.Add(_member_name);
            for (int i = 0, loopTo = _pass_member_name.Length - 1; i <= loopTo; i++)
                table.Columns.Add(_pass_member_name[i]);
            // データセットにテーブルの追加
            m_dataset.Tables.Add(table);
        }

        /// <summary> xmlファイルの保存 </summary>
        /// <param name="_node_name"> ノード名 </param>
        /// <param name="_member_name"> キーメンバ名 </param>
        /// <param name="_member_code"> キーメンバコード </param>
        /// <param name="_pass_member_name"> パスメンバ名 </param>
        /// <param name="_default_pass"> デフォルトパス </param>
        /// <returns> True:保存成功 False:保存失敗 </returns>
        public bool CanSavePathXml(string _node_name, string _member_name, string _member_code, string _pass_member_name, string _default_pass)
        {
            var MemberName = new string[1];
            MemberName[0] = _pass_member_name;
            var pass = new string[1];
            pass[0] = _default_pass;

            return CanSavePathXml(_node_name, _member_name, _member_code, MemberName, pass);
        }

        /// <summary> xmlファイルの保存 </summary>
        /// <param name="_node_name"> ノード名 </param>
        /// <param name="_member_name"> キーメンバ名 </param>
        /// <param name="_member_code"> キーメンバコード </param>
        /// <param name="_pass_member_name"> パスメンバ名 </param>
        /// <param name="_default_pass"> デフォルトパス </param>
        /// <param name="single"> ノードが一つしかない場合（キーメンバ、キーコードを無視） </param>
        /// <returns> True:保存成功 False:保存失敗 </returns>
        public bool CanSavePathXml(string _node_name, string _member_name, string _member_code, string[] _pass_member_name, string[] _default_pass, bool single = false)
        {
            // xmlファイル再読込み
            Refresh();
            if (NodeGetCount(_node_name, _member_name + " = '" + _member_code + "'") == 1)
            {
                // データ存在時は更新
                if (!ChangeRow(_node_name, _member_name, _member_code, _pass_member_name, _default_pass, single))
                {
                    return false;
                }
            }
            // データ未存在時は追加
            else if (!AddRow(_node_name, _member_name, _member_code, _pass_member_name, _default_pass))
            {
                return false;
            }

            // Xmlファイルの保存
            SaveXml();

            return true;
        }

        /// <summary> 既存データの変更 </summary>
        /// <param name="_node_name"> ノード名 </param>
        /// <param name="_member_name"> キーメンバ名 </param>
        /// <param name="_member_code"> キーメンバコード </param>
        /// <param name="_pass_member_name"> パスメンバ名 </param>
        /// <param name="_default_pass"> デフォルトパス </param>
        /// <param name="single"> ノードが一つしかない場合（キーメンバ、キーコードを無視） </param>
        /// <returns> True:成功 False:失敗 </returns>
        private bool ChangeRow(string _node_name, string _member_name, string _member_code, string[] _pass_member_name, string[] _default_pass, bool single)
        {
            for (int i = 0; i < _pass_member_name.Length; i++)
            {
                if (!m_dataset.Tables[_node_name].Columns.Contains(_pass_member_name[i]))
                {
                    // 存在しない項目があった場合は追加
                    m_dataset.Tables[_node_name].Columns.Add(_pass_member_name[i]);
                }
            }

            int length = Math.Min(_pass_member_name.Length, _default_pass.Length);

            if (!single)
            {
                for (int i = 0, loopTo = m_dataset.Tables[_node_name].Rows.Count - 1; i <= loopTo; i++)
                {
                    if ((m_dataset.Tables[_node_name].Rows[i][_member_name].ToString() ?? "") == (_member_code ?? ""))
                    {
                        // 指定したメンバコードのパスを書き換える。
                        for (int j = 0, loopTo1 = length - 1; j <= loopTo1; j++)
                            m_dataset.Tables[_node_name].Rows[i][_pass_member_name[j]] = _default_pass[j];
                        return true;

                    }
                }
            }
            else
            {
                // 指定したメンバコードのパスを書き換える。
                for (int j = 0, loopTo1 = length - 1; j <= loopTo1; j++)
                    m_dataset.Tables[_node_name].Rows[0][_pass_member_name[j]] = _default_pass[j];
            }

            return false;
        }

        /// <summary> データの取得 </summary>
        /// <param name="_node_name"> ノード名 </param>
        /// <param name="_member_name"> 取得するメンバ名 </param>
        /// <param name="_conditions"> 複数ある場合の条件 </param>
        public string GetValue(string _node_name, string _member_name, string _conditions = "")
        {
            DataTable table;

            try
            {

                if (m_dataset is null)
                {
                    Refresh();
                }

                table = m_dataset.Tables[_node_name];
                if (table is null)
                {
                    return null;
                }

                if (table.Rows.Count == 0)
                {
                    return null;
                }

                DataRow[] dRow = table.Select(_conditions);
                return dRow[0][_member_name].ToString();
            }

            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 指定したデータの更新(ノードが一つしかないことが前提) 
        /// </summary>
        /// <param name="_node_name"> ノード名 </param>
        /// <param name="_keyValue"> メンバ名 / 設定値 </param>
        public bool SetValueSingle(string _node_name, Dictionary<string,string> _keyValue )
        {
            // xmlファイル再読込み
            Refresh();

            foreach (KeyValuePair<string, string> setValue in _keyValue)
            {
                m_dataset.Tables[_node_name].Rows[0][setValue.Key] = setValue.Value;
            }
            // Xmlファイルの保存
            SaveXml();

            return true;
        }


        /// <summary> データの取得 </summary>
        /// <param name="_node_name"> ノード名 </param>
        public DataTable GetValues(string _node_name)
        {
            try
            {
                if (m_dataset is null)
                {
                    Refresh();
                }

                return m_dataset.Tables[_node_name];
            }
            catch
            {
                return null;
            }
        }

        /// <summary> 件数取得 </summary>
        /// <param name="_node_name"></param>
        /// <param name="_conditions"></param>
        private int NodeGetCount(string _node_name, string _conditions = "")
        {
            try
            {
                return m_dataset?.Tables[_node_name]?.Select(_conditions)?.Length ?? 0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary> Xmlファイルを再読込みしDataSetにセット </summary>
        private void Refresh()
        {
            m_dataset = new DataSet();
            m_dataset.ReadXml(m_xml_file, XmlReadMode.Auto);
        }

        /// <summary> Xmlファイルの保存 </summary>
        private void SaveXml()
        {
            m_dataset.WriteXml(m_xml_file);
        }

        /// <summary>
        /// 現在のDataSetを取得
        /// </summary>
        /// <returns></returns>
        public DataSet GetCurrentDataSet()
        {
            return m_dataset;
        }
        #endregion

    }
}