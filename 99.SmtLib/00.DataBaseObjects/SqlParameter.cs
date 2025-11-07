using System;
using System.Data;
using Microsoft.VisualBasic.CompilerServices;



namespace SmtLib.DataBaseObjects
{

    /// <summary> パラメータクエリのためのパラメータを定義します。 </summary>
    public class SqlParameter
    {

        #region Property

        /// <summary> System.Data.Common.DbParameter の名前を取得または設定します。 </summary>
        /// <returns> System.Data.Common.DbParameter の名前。既定値は空の文字列 ("") です。 </returns>
        public string ParameterName { get; set; }

        /// <summary> パラメータの値を取得または設定します。 </summary>
        /// <returns> パラメータの値を示す System.Object。既定値は null です。 </returns>
        public object Value { get; set; }

        /// <summary>  </summary>
        /// <returns>  </returns>
        public SqlDbType Type { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// 初期設定
        /// </summary>
        public SqlParameter()
        {

            ParameterName = null;
            Value = null;

        }
        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pValue"></param>
        /// <param name="pType"></param>
        public SqlParameter(string pName, object pValue, SqlDbType pType)
        {

            ParameterName = pName;
            Value = pValue;
            Type = pType;

        }

        /// <summary>
        /// 初期設定
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pValue"></param>
        public SqlParameter(string pName, object pValue) : this(pName, pValue, SqlDbType.NVarChar)
        {

            if (ClsCheck.IsNull(pValue))
            {
                Value = DBNull.Value;
            }

        }

        // Public Sub New(pName As String, pValue As Object, pTo_null As Boolean)

        // Me.ParameterName = pName
        // If Value Is Nothing OrElse String.IsNullOrEmpty(pValue.ToString()) AndAlso pTo_null Then
        // Me.Value = System.DBNull.Value
        // Else
        // Me.Value = pValue
        // End If

        // End Sub

        #endregion
        /// <summary>
        /// テキストに変換
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            string nameString;
            string valueString;

            if (ParameterName is null)
            {
                nameString = "{Null}";
            }
            else
            {
                nameString = ParameterName;
            }

            if (Value is null)
            {
                valueString = "{Null}";
            }
            else if (ReferenceEquals(Value, DBNull.Value))
            {
                valueString = "NULL";
            }
            else if (Value is string)
            {
                valueString = '\'' + ((string)Value).Replace(Conversions.ToString('\''), "''") + '\'';
            }
            else if (Value is DateTime)
            {
                valueString = string.Format("'{0}'", Value);
            }
            else if (Value.GetType().IsValueType)
            {
                valueString = Value.ToString();
            }
            else
            {
                valueString = '{' + Value.GetType().ToString() + '}';
            }

            return string.Format("{0} = {1}", nameString, valueString);

        }

    }

}