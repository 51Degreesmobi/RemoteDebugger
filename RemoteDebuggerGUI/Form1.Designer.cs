namespace RemoteDebuggerGUI
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
            this.urlsTextBox = new System.Windows.Forms.TextBox();
            this.processBut = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.WebSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Requests = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PageWeightCompressed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // urlsTextBox
            // 
            this.urlsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.urlsTextBox.Location = new System.Drawing.Point(23, 14);
            this.urlsTextBox.Multiline = true;
            this.urlsTextBox.Name = "urlsTextBox";
            this.urlsTextBox.Size = new System.Drawing.Size(519, 121);
            this.urlsTextBox.TabIndex = 0;
            // 
            // processBut
            // 
            this.processBut.Location = new System.Drawing.Point(23, 141);
            this.processBut.Name = "processBut";
            this.processBut.Size = new System.Drawing.Size(75, 23);
            this.processBut.TabIndex = 1;
            this.processBut.Text = "Test";
            this.processBut.UseVisualStyleBackColor = true;
            this.processBut.Click += new System.EventHandler(this.processBut_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WebSite,
            this.Requests,
            this.PageWeight,
            this.PageWeightCompressed});
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(23, 176);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(519, 121);
            this.dgvResults.TabIndex = 2;
            // 
            // WebSite
            // 
            this.WebSite.HeaderText = "WebSite";
            this.WebSite.Name = "WebSite";
            this.WebSite.ReadOnly = true;
            // 
            // Requests
            // 
            this.Requests.HeaderText = "Requests";
            this.Requests.Name = "Requests";
            this.Requests.ReadOnly = true;
            // 
            // PageWeight
            // 
            this.PageWeight.HeaderText = "Page Weight (bytes)";
            this.PageWeight.Name = "PageWeight";
            this.PageWeight.ReadOnly = true;
            // 
            // PageWeightCompressed
            // 
            this.PageWeightCompressed.HeaderText = "Compressed Page Weight (bytes)";
            this.PageWeightCompressed.Name = "PageWeightCompressed";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.processBut, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.urlsTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvResults, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(565, 320);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 320);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Remote Tester";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox urlsTextBox;
        private System.Windows.Forms.Button processBut;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn WebSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Requests;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageWeightCompressed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

