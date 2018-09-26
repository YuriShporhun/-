namespace AccountingForAgriculturalTax
{
    partial class EditCommonAssetsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCommonAssetsForm));
            this.closeButton = new System.Windows.Forms.Button();
            this.editCommonAssetsButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.disposalDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.expluatationDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.documentsDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.billingDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.initialCostTextBox = new System.Windows.Forms.TextBox();
            this.objectsUsefulLifeTextBox = new System.Windows.Forms.TextBox();
            this.includedInCostsTextBox = new System.Windows.Forms.TextBox();
            this.objectsProportionOfValueTextBox = new System.Windows.Forms.TextBox();
            this.numberOfSemestersTextBox = new System.Windows.Forms.TextBox();
            this.objectsResidualValueTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.disposalTimeTextBox = new System.Windows.Forms.TextBox();
            this.deleteDisposalDateButton = new System.Windows.Forms.Button();
            this.INNInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(336, 361);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(94, 23);
            this.closeButton.TabIndex = 47;
            this.closeButton.Text = "Отмена";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // editCommonAssetsButton
            // 
            this.editCommonAssetsButton.Location = new System.Drawing.Point(15, 361);
            this.editCommonAssetsButton.Name = "editCommonAssetsButton";
            this.editCommonAssetsButton.Size = new System.Drawing.Size(93, 23);
            this.editCommonAssetsButton.TabIndex = 46;
            this.editCommonAssetsButton.Text = "Редактировать";
            this.editCommonAssetsButton.UseVisualStyleBackColor = true;
            this.editCommonAssetsButton.Click += new System.EventHandler(this.editCommonAssetsButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 312);
            this.label11.MaximumSize = new System.Drawing.Size(200, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(197, 26);
            this.label11.TabIndex = 45;
            this.label11.Text = "Включено в расходы за предыдущие налоговые периоды:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Дата выбытия объекта:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Доля стоимости объекта:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Количество полугодий эксплуатации:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Остаточная стоимость объекта:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Срок полезного использование объекта:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Первоначальная стоимость объекта:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Дата ввода в эксплуатацию объекта:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Дата подачи документов:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Дата оплаты объекта:";
            // 
            // disposalDateDateTimePicker
            // 
            this.disposalDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.disposalDateDateTimePicker.Location = new System.Drawing.Point(416, 283);
            this.disposalDateDateTimePicker.Name = "disposalDateDateTimePicker";
            this.disposalDateDateTimePicker.Size = new System.Drawing.Size(18, 20);
            this.disposalDateDateTimePicker.TabIndex = 34;
            this.disposalDateDateTimePicker.ValueChanged += new System.EventHandler(this.disposalDateDateTimePicker_ValueChanged);
            // 
            // expluatationDateDateTimePicker
            // 
            this.expluatationDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.expluatationDateDateTimePicker.Location = new System.Drawing.Point(234, 127);
            this.expluatationDateDateTimePicker.Name = "expluatationDateDateTimePicker";
            this.expluatationDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.expluatationDateDateTimePicker.TabIndex = 28;
            // 
            // documentsDateDateTimePicker
            // 
            this.documentsDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.documentsDateDateTimePicker.Location = new System.Drawing.Point(234, 101);
            this.documentsDateDateTimePicker.Name = "documentsDateDateTimePicker";
            this.documentsDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.documentsDateDateTimePicker.TabIndex = 27;
            // 
            // billingDateDateTimePicker
            // 
            this.billingDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.billingDateDateTimePicker.Location = new System.Drawing.Point(234, 75);
            this.billingDateDateTimePicker.Name = "billingDateDateTimePicker";
            this.billingDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.billingDateDateTimePicker.TabIndex = 26;
            // 
            // initialCostTextBox
            // 
            this.initialCostTextBox.Location = new System.Drawing.Point(234, 153);
            this.initialCostTextBox.Name = "initialCostTextBox";
            this.initialCostTextBox.Size = new System.Drawing.Size(200, 20);
            this.initialCostTextBox.TabIndex = 29;
            // 
            // objectsUsefulLifeTextBox
            // 
            this.objectsUsefulLifeTextBox.Location = new System.Drawing.Point(234, 179);
            this.objectsUsefulLifeTextBox.Name = "objectsUsefulLifeTextBox";
            this.objectsUsefulLifeTextBox.Size = new System.Drawing.Size(200, 20);
            this.objectsUsefulLifeTextBox.TabIndex = 30;
            // 
            // includedInCostsTextBox
            // 
            this.includedInCostsTextBox.Location = new System.Drawing.Point(234, 309);
            this.includedInCostsTextBox.Name = "includedInCostsTextBox";
            this.includedInCostsTextBox.Size = new System.Drawing.Size(200, 20);
            this.includedInCostsTextBox.TabIndex = 35;
            // 
            // objectsProportionOfValueTextBox
            // 
            this.objectsProportionOfValueTextBox.Location = new System.Drawing.Point(234, 257);
            this.objectsProportionOfValueTextBox.Name = "objectsProportionOfValueTextBox";
            this.objectsProportionOfValueTextBox.Size = new System.Drawing.Size(200, 20);
            this.objectsProportionOfValueTextBox.TabIndex = 33;
            // 
            // numberOfSemestersTextBox
            // 
            this.numberOfSemestersTextBox.Location = new System.Drawing.Point(234, 231);
            this.numberOfSemestersTextBox.Name = "numberOfSemestersTextBox";
            this.numberOfSemestersTextBox.Size = new System.Drawing.Size(200, 20);
            this.numberOfSemestersTextBox.TabIndex = 32;
            // 
            // objectsResidualValueTextBox
            // 
            this.objectsResidualValueTextBox.Location = new System.Drawing.Point(234, 205);
            this.objectsResidualValueTextBox.Name = "objectsResidualValueTextBox";
            this.objectsResidualValueTextBox.Size = new System.Drawing.Size(200, 20);
            this.objectsResidualValueTextBox.TabIndex = 31;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(234, 49);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 20);
            this.nameTextBox.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Наименование объекта:";
            // 
            // disposalTimeTextBox
            // 
            this.disposalTimeTextBox.Location = new System.Drawing.Point(263, 283);
            this.disposalTimeTextBox.Name = "disposalTimeTextBox";
            this.disposalTimeTextBox.ReadOnly = true;
            this.disposalTimeTextBox.Size = new System.Drawing.Size(147, 20);
            this.disposalTimeTextBox.TabIndex = 48;
            // 
            // deleteDisposalDateButton
            // 
            this.deleteDisposalDateButton.Location = new System.Drawing.Point(233, 282);
            this.deleteDisposalDateButton.Name = "deleteDisposalDateButton";
            this.deleteDisposalDateButton.Size = new System.Drawing.Size(24, 20);
            this.deleteDisposalDateButton.TabIndex = 49;
            this.deleteDisposalDateButton.Text = "X";
            this.deleteDisposalDateButton.UseVisualStyleBackColor = true;
            this.deleteDisposalDateButton.Click += new System.EventHandler(this.deleteDisposalDateButton_Click);
            // 
            // INNInfoLabel
            // 
            this.INNInfoLabel.AutoSize = true;
            this.INNInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.INNInfoLabel.Location = new System.Drawing.Point(12, 18);
            this.INNInfoLabel.Name = "INNInfoLabel";
            this.INNInfoLabel.Size = new System.Drawing.Size(250, 18);
            this.INNInfoLabel.TabIndex = 54;
            this.INNInfoLabel.Text = "Редактирование записи для ИНН: ";
            // 
            // EditCommonAssetsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 393);
            this.Controls.Add(this.INNInfoLabel);
            this.Controls.Add(this.deleteDisposalDateButton);
            this.Controls.Add(this.disposalTimeTextBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.editCommonAssetsButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.disposalDateDateTimePicker);
            this.Controls.Add(this.expluatationDateDateTimePicker);
            this.Controls.Add(this.documentsDateDateTimePicker);
            this.Controls.Add(this.billingDateDateTimePicker);
            this.Controls.Add(this.initialCostTextBox);
            this.Controls.Add(this.objectsUsefulLifeTextBox);
            this.Controls.Add(this.includedInCostsTextBox);
            this.Controls.Add(this.objectsProportionOfValueTextBox);
            this.Controls.Add(this.numberOfSemestersTextBox);
            this.Controls.Add(this.objectsResidualValueTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditCommonAssetsForm";
            this.Text = "Редактировать основные средства";
            this.Load += new System.EventHandler(this.EditCommonAssetsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button editCommonAssetsButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker disposalDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker expluatationDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker documentsDateDateTimePicker;
        private System.Windows.Forms.DateTimePicker billingDateDateTimePicker;
        private System.Windows.Forms.TextBox initialCostTextBox;
        private System.Windows.Forms.TextBox objectsUsefulLifeTextBox;
        private System.Windows.Forms.TextBox includedInCostsTextBox;
        private System.Windows.Forms.TextBox objectsProportionOfValueTextBox;
        private System.Windows.Forms.TextBox numberOfSemestersTextBox;
        private System.Windows.Forms.TextBox objectsResidualValueTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox disposalTimeTextBox;
        private System.Windows.Forms.Button deleteDisposalDateButton;
        private System.Windows.Forms.Label INNInfoLabel;
    }
}