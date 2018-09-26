namespace AccountingForAgriculturalTax
{
    partial class SelectGuideToOperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectGuideToOperationForm));
            this.guideToOperationsListBox = new System.Windows.Forms.ListBox();
            this.SelectGuideButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // guideToOperationsListBox
            // 
            this.guideToOperationsListBox.FormattingEnabled = true;
            this.guideToOperationsListBox.Location = new System.Drawing.Point(12, 12);
            this.guideToOperationsListBox.Name = "guideToOperationsListBox";
            this.guideToOperationsListBox.Size = new System.Drawing.Size(406, 264);
            this.guideToOperationsListBox.TabIndex = 0;
            // 
            // SelectGuideButton
            // 
            this.SelectGuideButton.Location = new System.Drawing.Point(12, 283);
            this.SelectGuideButton.Name = "SelectGuideButton";
            this.SelectGuideButton.Size = new System.Drawing.Size(75, 23);
            this.SelectGuideButton.TabIndex = 1;
            this.SelectGuideButton.Text = "Выбрать";
            this.SelectGuideButton.UseVisualStyleBackColor = true;
            this.SelectGuideButton.Click += new System.EventHandler(this.SelectGuideButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(343, 283);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Отмена";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SelectGuideToOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 318);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SelectGuideButton);
            this.Controls.Add(this.guideToOperationsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SelectGuideToOperationForm";
            this.ShowInTaskbar = false;
            this.Text = "Выбор из справочника";
            this.Load += new System.EventHandler(this.SelectGuideToOperation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox guideToOperationsListBox;
        private System.Windows.Forms.Button SelectGuideButton;
        private System.Windows.Forms.Button CloseButton;
    }
}