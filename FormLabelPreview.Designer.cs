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
            this.label5 = new System.Windows.Forms.Label();
            this.zebraPrintButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownCopies = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLabel
            // 
            this.pictureBoxLabel.Location = new System.Drawing.Point(65, 79);
            this.pictureBoxLabel.Name = "pictureBoxLabel";
            this.pictureBoxLabel.Size = new System.Drawing.Size(355, 178);
            this.pictureBoxLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLabel.TabIndex = 0;
            this.pictureBoxLabel.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(137, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 38);
            this.label5.TabIndex = 18;
            this.label5.Text = "Label Preview";
            // 
            // zebraPrintButton
            // 
            this.zebraPrintButton.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zebraPrintButton.Location = new System.Drawing.Point(323, 288);
            this.zebraPrintButton.Name = "zebraPrintButton";
            this.zebraPrintButton.Size = new System.Drawing.Size(97, 46);
            this.zebraPrintButton.TabIndex = 19;
            this.zebraPrintButton.Text = "Print";
            this.zebraPrintButton.UseVisualStyleBackColor = true;
            this.zebraPrintButton.Click += new System.EventHandler(this.zebraPrintButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Copies:";
            // 
            // numericUpDownCopies
            // 
            this.numericUpDownCopies.BackColor = System.Drawing.SystemColors.ControlLight;
            this.numericUpDownCopies.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownCopies.Location = new System.Drawing.Point(134, 296);
            this.numericUpDownCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCopies.Name = "numericUpDownCopies";
            this.numericUpDownCopies.Size = new System.Drawing.Size(74, 30);
            this.numericUpDownCopies.TabIndex = 20;
            this.numericUpDownCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormLabelPreview
            // 
            this.ClientSize = new System.Drawing.Size(522, 358);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownCopies);
            this.Controls.Add(this.zebraPrintButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBoxLabel);
            this.Name = "FormLabelPreview";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button zebraPrintButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownCopies;
    }
}