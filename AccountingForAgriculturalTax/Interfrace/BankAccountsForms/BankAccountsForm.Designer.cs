namespace AccountingForAgriculturalTax
{
    partial class BankAccountsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankAccountsForm));
            this.bankAccountsGridView = new System.Windows.Forms.DataGridView();
            this.addBankAccountButton = new System.Windows.Forms.Button();
            this.editBankAccountButton = new System.Windows.Forms.Button();
            this.deleteBankAccountButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // bankAccountsGridView
            // 
            this.bankAccountsGridView.AllowUserToAddRows = false;
            this.bankAccountsGridView.AllowUserToDeleteRows = false;
            this.bankAccountsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bankAccountsGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.bankAccountsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bankAccountsGridView.Location = new System.Drawing.Point(12, 12);
            this.bankAccountsGridView.Name = "bankAccountsGridView";
            this.bankAccountsGridView.ReadOnly = true;
            this.bankAccountsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bankAccountsGridView.Size = new System.Drawing.Size(468, 343);
            this.bankAccountsGridView.TabIndex = 0;
            // 
            // addBankAccountButton
            // 
            this.addBankAccountButton.Location = new System.Drawing.Point(12, 361);
            this.addBankAccountButton.Name = "addBankAccountButton";
            this.addBankAccountButton.Size = new System.Drawing.Size(96, 23);
            this.addBankAccountButton.TabIndex = 1;
            this.addBankAccountButton.Text = "Добавить";
            this.addBankAccountButton.UseVisualStyleBackColor = true;
            this.addBankAccountButton.Click += new System.EventHandler(this.addBankAccountButton_Click);
            // 
            // editBankAccountButton
            // 
            this.editBankAccountButton.Location = new System.Drawing.Point(114, 361);
            this.editBankAccountButton.Name = "editBankAccountButton";
            this.editBankAccountButton.Size = new System.Drawing.Size(96, 23);
            this.editBankAccountButton.TabIndex = 2;
            this.editBankAccountButton.Text = "Редактировать";
            this.editBankAccountButton.UseVisualStyleBackColor = true;
            this.editBankAccountButton.Click += new System.EventHandler(this.editBankAccountButton_Click);
            // 
            // deleteBankAccountButton
            // 
            this.deleteBankAccountButton.Location = new System.Drawing.Point(216, 361);
            this.deleteBankAccountButton.Name = "deleteBankAccountButton";
            this.deleteBankAccountButton.Size = new System.Drawing.Size(96, 23);
            this.deleteBankAccountButton.TabIndex = 3;
            this.deleteBankAccountButton.Text = "Удалить";
            this.deleteBankAccountButton.UseVisualStyleBackColor = true;
            this.deleteBankAccountButton.Click += new System.EventHandler(this.deleteBankAccountButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(384, 361);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(96, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // BankAccountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 393);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.deleteBankAccountButton);
            this.Controls.Add(this.editBankAccountButton);
            this.Controls.Add(this.addBankAccountButton);
            this.Controls.Add(this.bankAccountsGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BankAccountsForm";
            this.Text = "Счета в банках";
            this.Load += new System.EventHandler(this.BankAccountsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView bankAccountsGridView;
        private System.Windows.Forms.Button addBankAccountButton;
        private System.Windows.Forms.Button editBankAccountButton;
        private System.Windows.Forms.Button deleteBankAccountButton;
        private System.Windows.Forms.Button CloseButton;
    }
}