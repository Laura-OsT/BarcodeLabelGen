namespace WindowsFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.inputBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.ListBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.cSF_ProdDataSet = new WindowsFormsApp1.CSF_ProdDataSet();
            this.iTM1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iTM1TableAdapter = new WindowsFormsApp1.CSF_ProdDataSetTableAdapters.ITM1TableAdapter();
            this.tableAdapterManager = new WindowsFormsApp1.CSF_ProdDataSetTableAdapters.TableAdapterManager();
            this.statusLabel = new System.Windows.Forms.Label();
            this.clearBtn = new System.Windows.Forms.Button();
            this.importBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cSF_ProdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTM1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputBox.Location = new System.Drawing.Point(278, 101);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(479, 31);
            this.inputBox.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(63, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "Enter SKU or Model:";
            // 
            // output
            // 
            this.output.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.FormattingEnabled = true;
            this.output.HorizontalScrollbar = true;
            this.output.ItemHeight = 29;
            this.output.Location = new System.Drawing.Point(52, 143);
            this.output.Margin = new System.Windows.Forms.Padding(5);
            this.output.Name = "output";
            this.output.ScrollAlwaysVisible = true;
            this.output.Size = new System.Drawing.Size(816, 323);
            this.output.TabIndex = 7;
            this.output.SelectedIndexChanged += new System.EventHandler(this.output_SelectedIndexChanged);
            // 
            // closeBtn
            // 
            this.closeBtn.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(793, 476);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 38);
            this.closeBtn.TabIndex = 11;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // cSF_ProdDataSet
            // 
            this.cSF_ProdDataSet.DataSetName = "CSF_ProdDataSet";
            this.cSF_ProdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // iTM1BindingSource
            // 
            this.iTM1BindingSource.DataMember = "ITM1";
            this.iTM1BindingSource.DataSource = this.cSF_ProdDataSet;
            // 
            // iTM1TableAdapter
            // 
            this.iTM1TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ITM1TableAdapter = this.iTM1TableAdapter;
            this.tableAdapterManager.OITMTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApp1.CSF_ProdDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(9, 498);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(44, 16);
            this.statusLabel.TabIndex = 12;
            this.statusLabel.Text = "label1";
            // 
            // clearBtn
            // 
            this.clearBtn.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.Location = new System.Drawing.Point(694, 476);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 38);
            this.clearBtn.TabIndex = 13;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // importBtn
            // 
            this.importBtn.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBtn.Location = new System.Drawing.Point(577, 476);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(86, 38);
            this.importBtn.TabIndex = 14;
            this.importBtn.Text = "Import";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtn.Location = new System.Drawing.Point(469, 476);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 38);
            this.printBtn.TabIndex = 15;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.Location = new System.Drawing.Point(781, 98);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(87, 38);
            this.searchBtn.TabIndex = 16;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(292, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 38);
            this.label1.TabIndex = 17;
            this.label1.Text = "LABEL GENERATOR";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.The_Chef_Supply_logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 572);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.importBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.inputBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "TCS Label Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cSF_ProdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTM1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox output;
        private System.Windows.Forms.Button closeBtn;
        private CSF_ProdDataSet cSF_ProdDataSet;
        private System.Windows.Forms.BindingSource iTM1BindingSource;
        private CSF_ProdDataSetTableAdapters.ITM1TableAdapter iTM1TableAdapter;
        private CSF_ProdDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
