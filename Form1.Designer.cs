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
            this.input = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.ListBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.cSF_ProdDataSet = new WindowsFormsApp1.CSF_ProdDataSet();
            this.iTM1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iTM1TableAdapter = new WindowsFormsApp1.CSF_ProdDataSetTableAdapters.ITM1TableAdapter();
            this.tableAdapterManager = new WindowsFormsApp1.CSF_ProdDataSetTableAdapters.TableAdapterManager();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cSF_ProdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTM1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(203, 25);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(369, 22);
            this.input.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Search by SKU or Model.";
            // 
            // output
            // 
            this.output.FormattingEnabled = true;
            this.output.ItemHeight = 16;
            this.output.Location = new System.Drawing.Point(34, 67);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(629, 84);
            this.output.TabIndex = 7;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(588, 24);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 8;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(278, 170);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 9;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(151, 170);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 10;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(426, 169);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 11;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = true;
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
            this.statusLabel.Location = new System.Drawing.Point(36, 402);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(44, 16);
            this.statusLabel.TabIndex = 12;
            this.statusLabel.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cSF_ProdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTM1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox output;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button closeBtn;
        private CSF_ProdDataSet cSF_ProdDataSet;
        private System.Windows.Forms.BindingSource iTM1BindingSource;
        private CSF_ProdDataSetTableAdapters.ITM1TableAdapter iTM1TableAdapter;
        private CSF_ProdDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label statusLabel;
    }
}

