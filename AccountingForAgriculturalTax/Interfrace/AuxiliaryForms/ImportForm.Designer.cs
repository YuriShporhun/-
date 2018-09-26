namespace AccountingForAgriculturalTax
{
    partial class ImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FirstINNTextBox = new System.Windows.Forms.TextBox();
            this.SecondINNTextBox = new System.Windows.Forms.TextBox();
            this.ImportButton = new System.Windows.Forms.Button();
            this.ImportProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите ИНН:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Повторно введите ИНН:";
            // 
            // FirstINNTextBox
            // 
            this.FirstINNTextBox.Location = new System.Drawing.Point(166, 20);
            this.FirstINNTextBox.Name = "FirstINNTextBox";
            this.FirstINNTextBox.Size = new System.Drawing.Size(143, 20);
            this.FirstINNTextBox.TabIndex = 2;
            // 
            // SecondINNTextBox
            // 
            this.SecondINNTextBox.Location = new System.Drawing.Point(166, 47);
            this.SecondINNTextBox.Name = "SecondINNTextBox";
            this.SecondINNTextBox.Size = new System.Drawing.Size(143, 20);
            this.SecondINNTextBox.TabIndex = 3;
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(12, 85);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(143, 23);
            this.ImportButton.TabIndex = 4;
            this.ImportButton.Text = "Импортировать";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // ImportProgressBar
            // 
            this.ImportProgressBar.Location = new System.Drawing.Point(12, 120);
            this.ImportProgressBar.Maximum = 10;
            this.ImportProgressBar.Minimum = 1;
            this.ImportProgressBar.Name = "ImportProgressBar";
            this.ImportProgressBar.Size = new System.Drawing.Size(297, 23);
            this.ImportProgressBar.Step = 1;
            this.ImportProgressBar.TabIndex = 5;
            this.ImportProgressBar.Value = 1;
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 155);
            this.Controls.Add(this.ImportProgressBar);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.SecondINNTextBox);
            this.Controls.Add(this.FirstINNTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportForm";
            this.Text = "Импорт данных";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FirstINNTextBox;
        private System.Windows.Forms.TextBox SecondINNTextBox;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.ProgressBar ImportProgressBar;
    }
}