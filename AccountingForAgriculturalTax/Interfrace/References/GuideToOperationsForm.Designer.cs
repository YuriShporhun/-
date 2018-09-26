namespace AccountingForAgriculturalTax
{
    partial class GuideToOperationsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuideToOperationsForm));
            this.guideToOperationsListBox = new System.Windows.Forms.ListBox();
            this.addGuideToOperationButton = new System.Windows.Forms.Button();
            this.deleteGuideToOperationButton = new System.Windows.Forms.Button();
            this.editGuideToOperationButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // guideToOperationsListBox
            // 
            this.guideToOperationsListBox.FormattingEnabled = true;
            this.guideToOperationsListBox.Location = new System.Drawing.Point(12, 12);
            this.guideToOperationsListBox.Name = "guideToOperationsListBox";
            this.guideToOperationsListBox.Size = new System.Drawing.Size(563, 290);
            this.guideToOperationsListBox.TabIndex = 0;
            // 
            // addGuideToOperationButton
            // 
            this.addGuideToOperationButton.Location = new System.Drawing.Point(12, 308);
            this.addGuideToOperationButton.Name = "addGuideToOperationButton";
            this.addGuideToOperationButton.Size = new System.Drawing.Size(119, 23);
            this.addGuideToOperationButton.TabIndex = 1;
            this.addGuideToOperationButton.Text = "Добавить";
            this.addGuideToOperationButton.UseVisualStyleBackColor = true;
            this.addGuideToOperationButton.Click += new System.EventHandler(this.addGuideToOperationButton_Click);
            // 
            // deleteGuideToOperationButton
            // 
            this.deleteGuideToOperationButton.Location = new System.Drawing.Point(262, 308);
            this.deleteGuideToOperationButton.Name = "deleteGuideToOperationButton";
            this.deleteGuideToOperationButton.Size = new System.Drawing.Size(119, 23);
            this.deleteGuideToOperationButton.TabIndex = 2;
            this.deleteGuideToOperationButton.Text = "Удалить";
            this.deleteGuideToOperationButton.UseVisualStyleBackColor = true;
            this.deleteGuideToOperationButton.Click += new System.EventHandler(this.deleteGuideToOperationButton_Click);
            // 
            // editGuideToOperationButton
            // 
            this.editGuideToOperationButton.Location = new System.Drawing.Point(137, 308);
            this.editGuideToOperationButton.Name = "editGuideToOperationButton";
            this.editGuideToOperationButton.Size = new System.Drawing.Size(119, 23);
            this.editGuideToOperationButton.TabIndex = 3;
            this.editGuideToOperationButton.Text = "Редактировать";
            this.editGuideToOperationButton.UseVisualStyleBackColor = true;
            this.editGuideToOperationButton.Click += new System.EventHandler(this.editGuideToOperationButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(456, 308);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(119, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // GuideToOperationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 340);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.editGuideToOperationButton);
            this.Controls.Add(this.deleteGuideToOperationButton);
            this.Controls.Add(this.addGuideToOperationButton);
            this.Controls.Add(this.guideToOperationsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GuideToOperationsForm";
            this.Text = "Справочник по операциям";
            this.Load += new System.EventHandler(this.GuideToOperationsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox guideToOperationsListBox;
        private System.Windows.Forms.Button addGuideToOperationButton;
        private System.Windows.Forms.Button deleteGuideToOperationButton;
        private System.Windows.Forms.Button editGuideToOperationButton;
        private System.Windows.Forms.Button closeButton;
    }
}