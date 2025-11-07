using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CtrlLib
{
    // EventArgs拡張

    #region EventArgsHandled：Handled追加したEventArgs
    /// <summary>イベントのハンドル</summary>
    public class EventArgsHandled : EventArgs
    {
        /// <summary>イベントが処理されたかどうかを示す値を取得または設定します。</summary>
        /// <returns>コントロールの既定の処理を省略する場合は true。コントロールの既定の処理と共にイベントも渡す場合は false。</returns>
        public bool Handled { get; set; }
        /// <summary>初期設定</summary>
        protected internal EventArgsHandled()
        {
            Handled = false;
        }
    }
    #endregion

    #region EventArgsFunctionButtonClick
    /// <summary></summary>
    public class EventArgsFunctionButtonClick : EventArgsHandled
    {

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        private Keys _KeyData;

        public Keys KeyData
        {
            [DebuggerStepThrough()]
            get
            {
                return _KeyData;
            }
        }

        public Keys KeyCode
        {
            [DebuggerStepThrough()]
            get
            {
                return _KeyData & Keys.KeyCode;
            }
        }

        [DebuggerStepThrough()]
        protected internal EventArgsFunctionButtonClick(Keys keyData)
        {
            Handled = false;
            _KeyData = keyData;
        }

    }
}

#endregion

#region EventArgsRowAndColumn

// Public Class EventArgsRowAndColumn
// Inherits EventArgsHandled

// Public Property Column() As Integer

// Public Property Row() As Integer

// Public Sub New(ByVal _row As Integer, ByVal _column As Integer)
// Me.Handled = False
// Me.Column = _column
// Me.Row = _row
// End Sub

// Public Sub New(ByVal e As Spread.CellClickEventArgs)

// Me.Handled = False
// If e.ColumnHeader Then
// Me.Column = 0
// Else
// Me.Column = e.Column
// End If
// If e.RowHeader Then
// Me.Row = 0
// Else
// Me.Row = e.Row
// End If
// End Sub

// Public Sub New(ByVal _spread As Spread.FpSpread)
// Me.Handled = False
// If _spread Is Nothing _
// OrElse _spread.ActiveSheet Is Nothing _
// OrElse _spread.ActiveSheet.ActiveCell Is Nothing Then
// Me.Column = 0
// Me.Row = 0
// Else
// Me.Column = _spread.ActiveSheet.ActiveCell.Column.Index
// Me.Row = _spread.ActiveSheet.ActiveCell.Row.Index
// End If
// End Sub

// End Class

#endregion

