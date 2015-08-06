namespace ProductManagementApp.UI
{
    partial class ProductSaleUI
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saleButton = new System.Windows.Forms.Button();
            this.saleQuantityTextBox = new System.Windows.Forms.TextBox();
            this.saleProductComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saleReportButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saleButton);
            this.groupBox1.Controls.Add(this.saleQuantityTextBox);
            this.groupBox1.Controls.Add(this.saleProductComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(31, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Sale";
            // 
            // saleButton
            // 
            this.saleButton.Location = new System.Drawing.Point(210, 95);
            this.saleButton.Name = "saleButton";
            this.saleButton.Size = new System.Drawing.Size(75, 23);
            this.saleButton.TabIndex = 3;
            this.saleButton.Text = "Sale";
            this.saleButton.UseVisualStyleBackColor = true;
            this.saleButton.Click += new System.EventHandler(this.saleButton_Click);
            // 
            // saleQuantityTextBox
            // 
            this.saleQuantityTextBox.Location = new System.Drawing.Point(79, 60);
            this.saleQuantityTextBox.Name = "saleQuantityTextBox";
            this.saleQuantityTextBox.Size = new System.Drawing.Size(206, 20);
            this.saleQuantityTextBox.TabIndex = 2;
            // 
            // saleProductComboBox
            // 
            this.saleProductComboBox.FormattingEnabled = true;
            this.saleProductComboBox.Location = new System.Drawing.Point(79, 28);
            this.saleProductComboBox.Name = "saleProductComboBox";
            this.saleProductComboBox.Size = new System.Drawing.Size(206, 21);
            this.saleProductComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product";
            // 
            // saleReportButton
            // 
            this.saleReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saleReportButton.Location = new System.Drawing.Point(133, 177);
            this.saleReportButton.Name = "saleReportButton";
            this.saleReportButton.Size = new System.Drawing.Size(109, 41);
            this.saleReportButton.TabIndex = 1;
            this.saleReportButton.Text = "Sale Report";
            this.saleReportButton.UseVisualStyleBackColor = true;
            this.saleReportButton.Click += new System.EventHandler(this.saleReportButton_Click);
            // 
            // ProductSaleUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 243);
            this.Controls.Add(this.saleReportButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProductSaleUI";
            this.Text = "Product Sale";
            this.Load += new System.EventHandler(this.ProductSaleUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox saleQuantityTextBox;
        private System.Windows.Forms.ComboBox saleProductComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saleButton;
        private System.Windows.Forms.Button saleReportButton;
    }
}