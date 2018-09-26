namespace AccountingForAgriculturalTax
{
    partial class FormOfReorganizationsReferenceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOfReorganizationsReferenceForm));
            this.FormOfReorganizationReferenceDataGridView = new System.Windows.Forms.DataGridView();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FormOfReorganizationReferenceDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FormOfReorganizationReferenceDataGridView
            // 
            this.FormOfReorganizationReferenceDataGridView.AllowUserToAddRows = false;
            this.FormOfReorganizationReferenceDataGridView.AllowUserToDeleteRows = false;
            this.FormOfReorganizationReferenceDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FormOfReorganizationReferenceDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.FormOfReorganizationReferenceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FormOfReorganizationReferenceDataGridView.Location = new System.Drawing.Point(12, 12);
            this.FormOfReorganizationReferenceDataGridView.Name = "FormOfReorganizationReferenceDataGridView";
            this.FormOfReorganizationReferenceDataGridView.ReadOnly = true;
            this.FormOfReorganizationReferenceDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FormOfReorganizationReferenceDataGridView.Size = new System.Drawing.Size(557, 313);
            this.FormOfReorganizationReferenceDataGridView.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(494, 331);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(12, 331);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(75, 23);
            this.SelectButton.TabIndex = 2;
            this.SelectButton.Text = "Выбрать";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // FormOfReorganizationsReferenceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 366);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.FormOfReorganizationReferenceDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormOfReorganizationsReferenceForm";
            this.Text = "Справочник кодов форм реорганизации компании";
            this.Load += new System.EventHandler(this.FormOfReorganizationsReferenceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormOfReorganizationReferenceDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView FormOfReorganizationReferenceDataGridView;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button SelectButton;
    }
}