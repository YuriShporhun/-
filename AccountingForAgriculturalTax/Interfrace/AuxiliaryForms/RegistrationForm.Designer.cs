namespace AccountingForAgriculturalTax
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.registeringButton = new System.Windows.Forms.Button();
            this.requisiteButton = new System.Windows.Forms.Button();
            this.listOfKeysListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.INNTextBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите год:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Введите ваш ИНН:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ключ:";
            // 
            // yearTextBox
            // 
            this.yearTextBox.Location = new System.Drawing.Point(120, 6);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.Size = new System.Drawing.Size(194, 20);
            this.yearTextBox.TabIndex = 3;
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(119, 59);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(194, 20);
            this.keyTextBox.TabIndex = 5;
            // 
            // registeringButton
            // 
            this.registeringButton.Location = new System.Drawing.Point(15, 182);
            this.registeringButton.Name = "registeringButton";
            this.registeringButton.Size = new System.Drawing.Size(99, 23);
            this.registeringButton.TabIndex = 6;
            this.registeringButton.Text = "Регистрация";
            this.registeringButton.UseVisualStyleBackColor = true;
            this.registeringButton.Click += new System.EventHandler(this.registeringButton_Click);
            // 
            // requisiteButton
            // 
            this.requisiteButton.Location = new System.Drawing.Point(203, 182);
            this.requisiteButton.Name = "requisiteButton";
            this.requisiteButton.Size = new System.Drawing.Size(111, 23);
            this.requisiteButton.TabIndex = 7;
            this.requisiteButton.Text = "Реквизиты";
            this.requisiteButton.UseVisualStyleBackColor = true;
            this.requisiteButton.Click += new System.EventHandler(this.requisiteButton_Click);
            // 
            // listOfKeysListBox
            // 
            this.listOfKeysListBox.FormattingEnabled = true;
            this.listOfKeysListBox.Location = new System.Drawing.Point(15, 101);
            this.listOfKeysListBox.Name = "listOfKeysListBox";
            this.listOfKeysListBox.Size = new System.Drawing.Size(299, 69);
            this.listOfKeysListBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Доступные ключи для данного пользователя:";
            // 
            // INNTextBox
            // 
            this.INNTextBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.INNTextBox.FormattingEnabled = true;
            this.INNTextBox.Location = new System.Drawing.Point(120, 32);
            this.INNTextBox.Name = "INNTextBox";
            this.INNTextBox.Size = new System.Drawing.Size(194, 21);
            this.INNTextBox.TabIndex = 10;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 214);
            this.Controls.Add(this.INNTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listOfKeysListBox);
            this.Controls.Add(this.requisiteButton);
            this.Controls.Add(this.registeringButton);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegistrationForm";
            this.Text = "Регистрация программы";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Button registeringButton;
        private System.Windows.Forms.Button requisiteButton;
        private System.Windows.Forms.ListBox listOfKeysListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox INNTextBox;
    }
}