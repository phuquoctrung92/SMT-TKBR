using SmtLib.DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DBLib.MSSQL
{
    public class dbBase
    {
        List<string> _PrimaryKeys;
        string _Identity;
        public List<string> PrimaryKeys { get { return _PrimaryKeys ?? new List<string>(); } }
        public string Identity { get { return _Identity ?? ""; } }

        public string prog_id { get; set; }
        public DateTime sysDate { get; set; }

        public SqlExecuteCRUD executeCRUD { get; set; }

        protected void setKeys(string primaryKey, string identity = "")
        {
            _PrimaryKeys = string.IsNullOrEmpty(primaryKey.Trim()) ? new List<string>() : new List<string>() { primaryKey };
            _Identity = identity;
        }

        protected void setKeys(List<string> primaryKeys = null, string identity = "")
        {
            _PrimaryKeys = primaryKeys ?? new List<string>();
            _Identity = identity;
        }

        protected void setFields(DataRow row)
        {
            if (row != null)
            {
                foreach (var field in GetType().GetFields())
                {
                    if (row.Table.Columns.Contains(field.Name))
                    {
                        field.SetValue(this, row[field.Name] == DBNull.Value ? null : row[field.Name]);
                    }
                }
            }
        }

        public virtual int INSERT()
        {
            StringBuilder query = new StringBuilder();
            List<SqlParameter> prm = new List<SqlParameter>();
            Type type = GetType();
            var lstField = type.GetFields();
            query.AppendLine($" INSERT INTO {type.Name} ");
            query.Append(" ( ");
            foreach (var field in lstField)
            {
                if (!string.IsNullOrWhiteSpace(Identity) && Identity == field.Name)
                {
                    continue;
                }
                query.Append(field.Name);
                if (!field.Equals(lstField.Last()))
                {
                    query.Append(", ");
                }
            }

            query.Append(" , insert_dt, insert_pg ");
            query.Append(" , update_dt, update_pg ");

            query.AppendLine(" ) ");
            query.AppendLine(" VALUES ");

            query.Append(" ( ");
            foreach (var field in lstField)
            {
                if (!string.IsNullOrWhiteSpace(Identity) && Identity == field.Name)
                {
                    continue;
                }
                query.Append("@" + field.Name);
                if (!field.Equals(lstField.Last()))
                {
                    query.Append(", ");
                }

                var value = type.GetField(field.Name).GetValue(this);
                //var tp= SqlDbType.VarChar;
                //if(value is string){ 
                //    tp=SqlDbType.NVarChar;
                //}
                //prm.Add(new SqlParameter($"@{field.Name}", value ?? DBNull.Value,tp));
                prm.Add(new SqlParameter($"@{field.Name}", value ?? DBNull.Value));
            }
            query.Append(" , @insert_dt, @insert_pg ");
            query.Append(" , @update_dt, @update_pg ");

            prm.Add(new SqlParameter("@insert_dt", sysDate ));
            prm.Add(new SqlParameter("@insert_pg", prog_id));
            prm.Add(new SqlParameter("@update_dt", sysDate));
            prm.Add(new SqlParameter("@update_pg", prog_id));

            query.AppendLine(" ) ");

            return SQLServer.Instance.ExecuteNonQuery(query.ToString(), prm.ToArray());
        }

        public virtual int UPDATE()
        {
            StringBuilder query = new StringBuilder();
            List<SqlParameter> prm = new List<SqlParameter>();
            Type type = GetType();
            var lstField = type.GetFields();

            query.AppendLine($" UPDATE {type.Name} ");
            query.AppendLine(" SET ");

            foreach (var field in lstField)
            {
                if (PrimaryKeys.Contains(field.Name))
                    continue;

                query.Append($"      {field.Name} = @{field.Name}");
                if (!field.Equals(lstField.Last()))
                {
                    query.AppendLine(", ");
                }
                var value = type.GetField(field.Name).GetValue(this);
                prm.Add(new SqlParameter($"@{field.Name}", value ?? DBNull.Value));
            }
            query.Append(" , update_dt = @update_dt ,update_pg = @update_pg ");
            prm.Add(new SqlParameter("@update_dt", sysDate));
            prm.Add(new SqlParameter("@update_pg", prog_id));

            query.AppendLine("");
            query.AppendLine(" WHERE ");
            query.AppendLine("  1 = 1 ");

            foreach (string key in PrimaryKeys)
            {
                query.AppendLine($"  AND {key} = @{key} ");
                prm.Add(new SqlParameter($"@{key}", type.GetField(key).GetValue(this)));
            }

            return SQLServer.Instance.ExecuteNonQuery(query, prm);
        }

        /// <summary>
        /// 値セットした項目だけ更新するUPDATE
        /// </summary>
        /// <returns></returns>
        public virtual int UPDATE_ValueNotNullOnly()
        {
            StringBuilder query = new StringBuilder();
            List<SqlParameter> prm = new List<SqlParameter>();
            Type type = GetType();
            var lstField = type.GetFields();

            query.AppendLine($" UPDATE {type.Name} ");
            query.AppendLine(" SET ");
            bool bol = false;
            foreach (var field in lstField)
            {
                if (PrimaryKeys.Contains(field.Name))
                    continue;

                var value = type.GetField(field.Name).GetValue(this);
                if (value != null && value.ToString() != "") {
                    if (bol)  {  query.AppendLine(", "); }
                    query.Append($"      {field.Name} = @{field.Name}");
                   
                    bol= true;
                    prm.Add(new SqlParameter($"@{field.Name}", value ?? DBNull.Value));
                }

            }
            query.Append(" , update_dt = @update_dt ,update_pg = @update_pg ");
            prm.Add(new SqlParameter("@update_dt", sysDate));
            prm.Add(new SqlParameter("@update_pg", prog_id));

            query.AppendLine("");
            query.AppendLine(" WHERE ");
            query.AppendLine("  1 = 1 ");

            foreach (string key in PrimaryKeys)
            {
                query.AppendLine($"  AND {key} = @{key} ");
                prm.Add(new SqlParameter($"@{key}", type.GetField(key).GetValue(this)));
            }

            return SQLServer.Instance.ExecuteNonQuery(query, prm);
        }

        public virtual int DELETE()
        {
            StringBuilder query = new StringBuilder();
            List<SqlParameter> prm = new List<SqlParameter>();
            Type type = GetType();
            query.AppendLine($" DELETE {type.Name} ");
            query.AppendLine(" WHERE ");
            query.AppendLine("  1 = 1 ");

            foreach (string key in PrimaryKeys)
            {
                query.AppendLine($"  AND {key} = @{key} ");
                prm.Add(new SqlParameter($"@{key}", type.GetField(key).GetValue(this)));
            }

            return SQLServer.Instance.ExecuteNonQuery(query, prm);
        }

        public virtual int DELETEALL()
        {
            Type type = GetType();

            return SQLServer.Instance.ExecuteNonQuery($" DELETE {type.Name} ");
        }

        /// <summary>
        /// IDENTITY値初期化
        /// </summary>
        /// <returns></returns>
        public virtual int IDENTITYRESET()
        {
            Type type = GetType();
            var currentIdentityID = SQLServer.Instance.ExecuteScalar($" SELECT COUNT(*) FROM {type.Name} ");

            return SQLServer.Instance.ExecuteNonQuery($" DBCC CHECKIDENT({type.Name}, reseed, {currentIdentityID}) ");
        }
    }
}
