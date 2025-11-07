
namespace SmtLib.DataBaseObjects
{

    /// <summary>
    /// SqlExecuteStructureのexecuteCRUDに指定する値
    /// </summary>
    /// <remarks></remarks>
    public enum SqlExecuteCRUD
    {
        /// <summary> Create(Insert)文 </summary>
        Create = 0,
        /// <summary> Update文 </summary>
        /// <remarks></remarks>
        Update = 1,
        /// <summary> Delete文 </summary>
        /// <remarks></remarks>
        Delete = 2,
        /// <summary> InsSelect Or UpdSelect文 </summary>
        /// <remarks></remarks>
        InsUpdSelect = 3,
        /// <summary>
        /// 一覧に最初のアイテムを取得
        /// </summary>
        SelectOne = 4
    }

    /// <summary>
    /// データベースの構造
    /// </summary>
    public class Structure
    {
        /// <summary>
        /// 実行SQL
        /// </summary>
        private string executeSql;
        /// <summary>
        /// executeSqlのパラメータ
        /// </summary>
        private SqlParameter[] executeParam;
        /// <summary>
        /// executeSqlのCRUD
        /// </summary>
        /// <remarks>
        /// "C"or"U"or"D"
        /// </remarks>
        private SqlExecuteCRUD executeCRUD;

        /// <summary>
        /// クエリ文
        /// </summary>
        public string SQL
        {
            get
            {
                return executeSql;
            }
        }

        /// <summary>
        /// パラメータ
        /// </summary>
        public SqlParameter[] Parameter
        {
            get
            {
                return executeParam;
            }
        }

        /// <summary>
        /// 実行区分
        /// C: Create(INSERT - 作成)
        /// R: Read (SELECT - 取得)
        /// U: Update (UPDATE - 更新)
        /// D: Delete (DELETE - 削除)
        /// </summary>
        public SqlExecuteCRUD CRUD
        {
            get
            {
                return executeCRUD;
            }
        }

        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="_executeSql">SQL文</param>
        /// <param name="_executeParam">パラメータ</param>
        /// <param name="_executeCRUD">実行区分</param>
        /// <remarks></remarks>
        public Structure(string _executeSql, SqlParameter[] _executeParam, SqlExecuteCRUD _executeCRUD = SqlExecuteCRUD.Create)
        {
            executeSql = _executeSql;
            executeParam = _executeParam;
            executeCRUD = _executeCRUD;
        }
    }
}