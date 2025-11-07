using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CtrlLib
{
    /// <summary>手入力できるデートピッカー</summary>
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class ucDateTimePicker : UserControl
    {
        /// <summary>UserControl はコンポーネント一覧をクリーンアップするために dispose をオーバーライドします。</summary>
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
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.dtb = new CtrlLib.MyControls.DateBox();
            this.SuspendLayout();
            // 
            // dtp
            // 
            this.dtp.CalendarFont = new System.Drawing.Font("MS Gothic", 20F);
            this.dtp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtp.Font = new System.Drawing.Font("Meiryo", 15.75F);
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp.Location = new System.Drawing.Point(0, 0);
            this.dtp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(300, 55);
            this.dtp.TabIndex = 0;
            this.dtp.TabStop = false;
            this.dtp.Value = new System.DateTime(2018, 9, 14, 0, 0, 0, 0);
            this.dtp.Enter += new System.EventHandler(this.dtp_Enter);
            // 
            // dtb
            // 
            this.dtb.Caption = "";
            this.dtb.DateFormat = CtrlLib.MyControls.DateFormats.yyyyMMdd;
            this.dtb.Font = new System.Drawing.Font("Meiryo", 15.75F);
            this.dtb.HasWeekdayLabel = false;
            this.dtb.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dtb.Location = new System.Drawing.Point(0, 0);
            this.dtb.Margin = new System.Windows.Forms.Padding(4);
            this.dtb.Name = "dtb";
            this.dtb.PasteType = CtrlLib.MyControls.PasteTypes.RangeAndRemove;
            this.dtb.Size = new System.Drawing.Size(247, 54);
            this.dtb.TabIndex = 1;
            this.dtb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtb.Value = "";
            this.dtb.EnterKeyDown += new CtrlLib.MyControls.BaseTextBox.EnterKeyDownEventHandler(this.OnEnterDown);
            // 
            // ucDateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.dtb);
            this.Controls.Add(this.dtp);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucDateTimePicker";
            this.Size = new System.Drawing.Size(300, 57);
            this.Load += new System.EventHandler(this.ucDtp_Load);
            this.FontChanged += new System.EventHandler(this.ucDateTimePicker_FontChanged);
            this.SizeChanged += new System.EventHandler(this.ucDateTimePicker_SizeChanged);
            this.ResumeLayout(false);

        }
        internal DateTimePicker dtp;
        internal MyControls.DateBox dtb;

    }
}