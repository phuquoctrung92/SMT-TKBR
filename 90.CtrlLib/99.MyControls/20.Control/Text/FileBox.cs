using System;
using model = System.ComponentModel;
using System.Windows.Forms;

namespace CtrlLib.MyControls
{

    /// <summary>
    /// ファイル用テキストボックス
    /// </summary>
    /// <remarks></remarks>
    /// <history>
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// Create
    /// Action  Ver-  Date------  Name------  Comment-------------------------------------------
    /// </history>
    public class FileBox : StringBox
    {

        #region Extend Property

        /// <summary> コントロールで値固定のため非表示 </summary>
        [model.Browsable(false)]
        public override InputPatterns InputPattern
        {
            get
            {
                return base.InputPattern;
            }
            set
            {
                base.InputPattern = value;
            }
        }

        /// <summary> コントロールで値固定のため非表示 </summary>
        [model.Browsable(false)]
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }
            set
            {
                base.AllowDrop = value;
            }
        }

        #endregion

        #region Constructor
        /// <summary>初期設定</summary>
        public FileBox() : base()
        {
            DragDrop += FileBox_DragDrop;
            DragEnter += FileBox_DragEnter;
            base.InputPattern = InputPatterns.File;
            base.MaxLength = 200;
            base.AllowDrop = true;
        }

        #endregion

        #region Control Events

        /// <summary>
        /// ドラッグドロップ処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void FileBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] FilePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            ((StringBox)sender).Text = FilePath[0];
        }

        /// <summary>
        /// ドラッグ可能にする
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void FileBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        #endregion

    }

}