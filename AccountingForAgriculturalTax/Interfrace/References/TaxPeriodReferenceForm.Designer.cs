namespace AccountingForAgriculturalTax
{
    partial class TaxPeriodReferenceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxPeriodReferenceForm));
            this.TaxPeriodReferenceDataGridView = new System.Windows.Forms.DataGridView();
            this.GetTaxPeriodCodeButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TaxPeriodReferenceDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TaxPeriodReferenceDataGridView
            // 
            this.TaxPeriodReferenceDataGridView.AllowUserToAddRows = false;
            this.TaxPeriodReferenceDataGridView.AllowUserToDeleteRows = false;
            this.TaxPeriodReferenceDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TaxPeriodReferenceDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.TaxPeriodReferenceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaxPeriodReferenceDataGridView.Location = new System.Drawing.Point(12, 12);
            this.TaxPeriodReferenceDataGridView.Name = "TaxPeriodReferenceDataGridView";
            this.TaxPeriodReferenceDataGridView.ReadOnly = true;
            this.TaxPeriodReferenceDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TaxPeriodReferenceDataGridView.Size = new System.Drawing.Size(578, 217);
            this.TaxPeriodReferenceDataGridView.TabIndex = 0;
            // 
            // GetTaxPeriodCodeButton
            // 
            this.GetTaxPeriodCodeButton.Location = new System.Drawing.Point(12, 347);
            this.GetTaxPeriodCodeButton.Name = "GetTaxPeriodCodeButton";
            this.GetTaxPeriodCodeButton.Size = new System.Drawing.Size(75, 23);
            this.GetTaxPeriodCodeButton.TabIndex = 1;
            this.GetTaxPeriodCodeButton.Text = "Выбрать";
            this.GetTaxPeriodCodeButton.UseVisualStyleBackColor = true;
            this.GetTaxPeriodCodeButton.Click += new System.EventHandler(this.GetTaxPeriodCodeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(515, 347);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 248);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(578, 93);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Заметка:";
            // 
            // TaxPeriodReferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 377);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.GetTaxPeriodCodeButton);
            this.Controls.Add(this.TaxPeriodReferenceDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TaxPeriodReferenceForm";
            this.Text = "Коды налоговых периодов";
            this.Load += new System.EventHandler(this.TaxPeriodReferenceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TaxPeriodReferenceDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TaxPeriodReferenceDataGridView;
        private System.Windows.Forms.Button GetTaxPeriodCodeButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}