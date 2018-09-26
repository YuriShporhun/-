namespace AccountingForAgriculturalTax
{
    partial class AddGuideToOperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGuideToOperationForm));
            this.guideToOperationsTextBox = new System.Windows.Forms.TextBox();
            this.addGuideToOperationButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // guideToOperationsTextBox
            // 
            this.guideToOperationsTextBox.Location = new System.Drawing.Point(12, 12);
            this.guideToOperationsTextBox.Multiline = true;
            this.guideToOperationsTextBox.Name = "guideToOperationsTextBox";
            this.guideToOperationsTextBox.Size = new System.Drawing.Size(427, 191);
            this.guideToOperationsTextBox.TabIndex = 0;
            // 
            // addGuideToOperationButton
            // 
            this.addGuideToOperationButton.Location = new System.Drawing.Point(12, 209);
            this.addGuideToOperationButton.Name = "addGuideToOperationButton";
            this.addGuideToOperationButton.Size = new System.Drawing.Size(75, 23);
            this.addGuideToOperationButton.TabIndex = 1;
            this.addGuideToOperationButton.Text = "Добавить";
            this.addGuideToOperationButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(364, 209);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Отмена";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // AddGuideToOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 244);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.addGuideToOperationButton);
            this.Controls.Add(this.guideToOperationsTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddGuideToOperationForm";
            this.Text = "Добавление записи в справочник операций";
            this.Load += new System.EventHandler(this.AddGuideToOperationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox guideToOperationsTextBox;
        private System.Windows.Forms.Button addGuideToOperationButton;
        private System.Windows.Forms.Button closeButton;
    }
}