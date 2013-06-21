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
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // urlsTextBox
            // 
            this.urlsTextBox.Location = new System.Drawing.Point(12, 12);
            this.urlsTextBox.Multiline = true;
            this.urlsTextBox.Name = "urlsTextBox";
            this.urlsTextBox.Size = new System.Drawing.Size(541, 96);
            this.urlsTextBox.TabIndex = 0;
            // 
            // processBut
            // 
            this.processBut.Location = new System.Drawing.Point(13, 115);
            this.processBut.Name = "processBut";
            this.processBut.Size = new System.Drawing.Size(75, 23);
            this.processBut.TabIndex = 1;
            this.processBut.Text = "Text";
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
            this.PageWeight});
            this.dgvResults.Location = new System.Drawing.Point(13, 145);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(540, 150);
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
            this.PageWeight.HeaderText = "PageWeight";
            this.PageWeight.Name = "PageWeight";
            this.PageWeight.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 320);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.processBut);
            this.Controls.Add(this.urlsTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlsTextBox;
        private System.Windows.Forms.Button processBut;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn WebSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Requests;
        private System.Windows.Forms.DataGridViewTextBoxColumn PageWeight;
    }
}

