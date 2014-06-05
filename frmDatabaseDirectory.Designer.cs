namespace ERPMercuryDatabaseDirectory
{
    partial class frmDatabaseDirectory
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmDatabaseDirectory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 391);
            this.Name = "frmDatabaseDirectory";
            this.Text = "Справочник";
            this.Load += new System.EventHandler(this.frmDatabaseDirectory_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDirect_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
    }
}