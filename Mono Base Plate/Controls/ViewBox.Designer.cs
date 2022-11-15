namespace Mono_Base_Plate.Controls
{
    partial class ViewBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // ViewBox
            // 
            this.SizeChanged += new System.EventHandler(this.ViewBox_SizeChanged);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ViewBox_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ViewBox_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewBox_MouseDown);
            this.MouseEnter += new System.EventHandler(this.ViewBox_MouseEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewBox_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewBox_MouseUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ViewBox_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
