using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CtrlLib.MyControls
{
    /// <summary>
    /// コンボボックス共通機能
    /// </summary>
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ucComboBox : UserControl
    {
        /// <summary>
        /// UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。
        /// </summary>
        /// <param name="disposing"></param>
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
        // Windows フォーム デザイナーを使用して変更できます。  
        // コード エディターを使って変更しないでください。
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.Label = new System.Windows.Forms.Label();
            this.ComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Label
            // 
            this.Label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label.Location = new System.Drawing.Point(50, 0);
            this.Label.MinimumSize = new System.Drawing.Size(20, 2);
            this.Label.Name = "Label";
            this.Label.Size = new System.Drawing.Size(25, 22);
            this.Label.TabIndex = 1;
            this.Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComboBox
            // 
            this.ComboBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ComboBox.Location = new System.Drawing.Point(0, 0);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(50, 20);
            this.ComboBox.TabIndex = 0;
            this.ComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBox_DrawItem);
            this.ComboBox.DropDown += new System.EventHandler(this.ComboBox_DropDown);
            this.ComboBox.DropDownClosed += new System.EventHandler(this.ComboBox_DropDownClosed);
            this.ComboBox.SelectedValueChanged += new System.EventHandler(this.ComboBox1_SelectedValueChanged);
            this.ComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBox_KeyDown);
            this.ComboBox.Leave += new System.EventHandler(this.ComboBox_Leave);
            this.ComboBox.Resize += new System.EventHandler(this.ComboBox_Resize);
            // 
            // ucComboBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.Label);
            this.Controls.Add(this.ComboBox);
            this.Name = "ucComboBox";
            this.Size = new System.Drawing.Size(75, 22);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Label Label;
        private ComboBox ComboBox;

    }
}