namespace AccountingForAgriculturalTax
{
    partial class WarningForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarningForm));
            this.WarningTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WarningTextBox
            // 
            this.WarningTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.WarningTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.WarningTextBox.Location = new System.Drawing.Point(12, 25);
            this.WarningTextBox.Multiline = true;
            this.WarningTextBox.Name = "WarningTextBox";
            this.WarningTextBox.ReadOnly = true;
            this.WarningTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WarningTextBox.Size = new System.Drawing.Size(450, 359);
            this.WarningTextBox.TabIndex = 0;
            this.WarningTextBox.TabStop = false;
            this.WarningTextBox.ReadOnlyChanged += new System.EventHandler(this.WarningTextBox_ReadOnlyChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Обнаружены следующие недочеты:";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(387, 390);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // WarningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 420);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WarningTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WarningForm";
            this.Text = "Предупреждение";
            this.Load += new System.EventHandler(this.WarningForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WarningTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CloseButton;
    }
}