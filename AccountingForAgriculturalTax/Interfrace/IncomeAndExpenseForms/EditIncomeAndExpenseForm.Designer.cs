namespace AccountingForAgriculturalTax
{
    partial class EditIncomeAndExpenseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditIncomeAndExpenseForm));
            this.CloseButton = new System.Windows.Forms.Button();
            this.editIncomeAndExpenseButton = new System.Windows.Forms.Button();
            this.expenseTextBox = new System.Windows.Forms.TextBox();
            this.incomeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GetFromGuideButton = new System.Windows.Forms.Button();
            this.substanceOfTransactionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.documentsNumberTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.INNInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(327, 293);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(74, 23);
            this.CloseButton.TabIndex = 25;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // editIncomeAndExpenseButton
            // 
            this.editIncomeAndExpenseButton.Location = new System.Drawing.Point(7, 293);
            this.editIncomeAndExpenseButton.Name = "editIncomeAndExpenseButton";
            this.editIncomeAndExpenseButton.Size = new System.Drawing.Size(98, 23);
            this.editIncomeAndExpenseButton.TabIndex = 24;
            this.editIncomeAndExpenseButton.Text = "Редактировать";
            this.editIncomeAndExpenseButton.UseVisualStyleBackColor = true;
            this.editIncomeAndExpenseButton.Click += new System.EventHandler(this.editIncomeAndExpenseButton_Click);
            // 
            // expenseTextBox
            // 
            this.expenseTextBox.Location = new System.Drawing.Point(53, 267);
            this.expenseTextBox.Name = "expenseTextBox";
            this.expenseTextBox.Size = new System.Drawing.Size(348, 20);
            this.expenseTextBox.TabIndex = 36;
            this.expenseTextBox.Text = "0";
            // 
            // incomeTextBox
            // 
            this.incomeTextBox.Location = new System.Drawing.Point(53, 239);
            this.incomeTextBox.Name = "incomeTextBox";
            this.incomeTextBox.Size = new System.Drawing.Size(348, 20);
            this.incomeTextBox.TabIndex = 35;
            this.incomeTextBox.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 270);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Расход";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Доход";
            // 
            // GetFromGuideButton
            // 
            this.GetFromGuideButton.Location = new System.Drawing.Point(201, 202);
            this.GetFromGuideButton.Name = "GetFromGuideButton";
            this.GetFromGuideButton.Size = new System.Drawing.Size(200, 23);
            this.GetFromGuideButton.TabIndex = 32;
            this.GetFromGuideButton.Text = "Взять из справочника";
            this.GetFromGuideButton.UseVisualStyleBackColor = true;
            this.GetFromGuideButton.Click += new System.EventHandler(this.GetFromGuideButton_Click);
            // 
            // substanceOfTransactionTextBox
            // 
            this.substanceOfTransactionTextBox.Location = new System.Drawing.Point(12, 116);
            this.substanceOfTransactionTextBox.Multiline = true;
            this.substanceOfTransactionTextBox.Name = "substanceOfTransactionTextBox";
            this.substanceOfTransactionTextBox.Size = new System.Drawing.Size(389, 80);
            this.substanceOfTransactionTextBox.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Содержание операции";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Номер документа";
            // 
            // documentsNumberTextBox
            // 
            this.documentsNumberTextBox.Location = new System.Drawing.Point(201, 70);
            this.documentsNumberTextBox.Name = "documentsNumberTextBox";
            this.documentsNumberTextBox.Size = new System.Drawing.Size(200, 20);
            this.documentsNumberTextBox.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Дата";
            // 
            // dateDateTimePicker
            // 
            this.dateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDateTimePicker.Location = new System.Drawing.Point(201, 44);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateDateTimePicker.TabIndex = 26;
            // 
            // INNInfoLabel
            // 
            this.INNInfoLabel.AutoSize = true;
            this.INNInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.INNInfoLabel.Location = new System.Drawing.Point(12, 15);
            this.INNInfoLabel.Name = "INNInfoLabel";
            this.INNInfoLabel.Size = new System.Drawing.Size(250, 18);
            this.INNInfoLabel.TabIndex = 37;
            this.INNInfoLabel.Text = "Редактирование записи для ИНН: ";
            // 
            // EditIncomeAndExpenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 325);
            this.Controls.Add(this.INNInfoLabel);
            this.Controls.Add(this.expenseTextBox);
            this.Controls.Add(this.incomeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.GetFromGuideButton);
            this.Controls.Add(this.substanceOfTransactionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.documentsNumberTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateDateTimePicker);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.editIncomeAndExpenseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditIncomeAndExpenseForm";
            this.Text = "Редактировать доход или расход";
            this.Load += new System.EventHandler(this.EditIncomeAndExpenseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button editIncomeAndExpenseButton;
        private System.Windows.Forms.TextBox expenseTextBox;
        private System.Windows.Forms.TextBox incomeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button GetFromGuideButton;
        private System.Windows.Forms.TextBox substanceOfTransactionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox documentsNumberTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateDateTimePicker;
        private System.Windows.Forms.Label INNInfoLabel;
    }
}