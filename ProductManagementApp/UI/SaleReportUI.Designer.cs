namespace ProductManagementApp.UI
{
    partial class SaleReportUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.saleReportListView = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sales Product Report";
            // 
            // saleReportListView
            // 
            this.saleReportListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.saleReportListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.saleReportListView.FullRowSelect = true;
            this.saleReportListView.GridLines = true;
            this.saleReportListView.HoverSelection = true;
            this.saleReportListView.Location = new System.Drawing.Point(34, 48);
            this.saleReportListView.Name = "saleReportListView";
            this.saleReportListView.Size = new System.Drawing.Size(338, 216);
            this.saleReportListView.TabIndex = 3;
            this.saleReportListView.UseCompatibleStateImageBehavior = false;
            this.saleReportListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Serial No";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Product Code";
            this.columnHeader7.Width = 94;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Product Name";
            this.columnHeader8.Width = 109;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Quantity";
            this.columnHeader9.Width = 71;
            // 
            // SaleReportUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 292);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saleReportListView);
            this.Name = "SaleReportUI";
            this.Text = "Sale Report";
            this.Load += new System.EventHandler(this.SaleReportUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView saleReportListView;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}