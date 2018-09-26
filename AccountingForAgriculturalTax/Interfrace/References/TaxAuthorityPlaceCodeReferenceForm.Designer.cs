namespace AccountingForAgriculturalTax
{
    partial class TaxAuthorityPlaceCodeReferenceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxAuthorityPlaceCodeReferenceForm));
            this.TaxAuthorityPlaceCodeDataGridView = new System.Windows.Forms.DataGridView();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TaxAuthorityPlaceCodeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TaxAuthorityPlaceCodeDataGridView
            // 
            this.TaxAuthorityPlaceCodeDataGridView.AllowUserToAddRows = false;
            this.TaxAuthorityPlaceCodeDataGridView.AllowUserToDeleteRows = false;
            this.TaxAuthorityPlaceCodeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TaxAuthorityPlaceCodeDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.TaxAuthorityPlaceCodeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaxAuthorityPlaceCodeDataGridView.Location = new System.Drawing.Point(12, 12);
            this.TaxAuthorityPlaceCodeDataGridView.Name = "TaxAuthorityPlaceCodeDataGridView";
            this.TaxAuthorityPlaceCodeDataGridView.ReadOnly = true;
            this.TaxAuthorityPlaceCodeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TaxAuthorityPlaceCodeDataGridView.Size = new System.Drawing.Size(551, 296);
            this.TaxAuthorityPlaceCodeDataGridView.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(488, 314);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(12, 314);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(75, 23);
            this.SelectButton.TabIndex = 2;
            this.SelectButton.Text = "Выбрать";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // TaxAuthorityPlaceCodeReferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 349);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.TaxAuthorityPlaceCodeDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TaxAuthorityPlaceCodeReferenceForm";
            this.Text = "Справочник кодов места представления декларации";
            this.Load += new System.EventHandler(this.TaxAuthorityPlaceCodeReferenceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TaxAuthorityPlaceCodeDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TaxAuthorityPlaceCodeDataGridView;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button SelectButton;
    }
}