namespace WindowsFormsApp1
{
    partial class FormLabelPreview
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
            this.pictureBoxLabel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLabel
            // 
            this.pictureBoxLabel.Location = new System.Drawing.Point(87, 49);
            this.pictureBoxLabel.Name = "pictureBoxLabel";
            this.pictureBoxLabel.Size = new System.Drawing.Size(453, 351);
            this.pictureBoxLabel.TabIndex = 0;
            this.pictureBoxLabel.TabStop = false;
            // 
            // FormLabelPreview
            // 
            this.ClientSize = new System.Drawing.Size(628, 451);
            this.Controls.Add(this.pictureBoxLabel);
            this.Name = "FormLabelPreview";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLabel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxLabel;
    }
}