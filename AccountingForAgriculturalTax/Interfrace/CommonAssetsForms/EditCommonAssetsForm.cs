using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public partial class EditCommonAssetsForm : Form
    {
        CommonAssets commonAssets;
        string INN;

        public EditCommonAssetsForm(CommonAssets commonAssets, string INN)
        {
            InitializeComponent();
            this.commonAssets = commonAssets;

            this.INN = INN;

            closeButton.Click += (s, e) => Close();

            nameTextBox.GotFocus += TextBoxProcessor.GotFocusSelectAll;
            initialCostTextBox.GotFocus += TextBoxProcessor.GotFocusSelectAll;
            objectsUsefulLifeTextBox.GotFocus += TextBoxProcessor.GotFocusSelectAll;
            objectsResidualValueTextBox.GotFocus += TextBoxProcessor.GotFocusSelectAll;
            numberOfSemestersTextBox.GotFocus += TextBoxProcessor.GotFocusSelectAll;
            objectsProportionOfValueTextBox.GotFocus += TextBoxProcessor.GotFocusSelectAll;
            includedInCostsTextBox.GotFocus += TextBoxProcessor.GotFocusSelectAll;

            billingDateDateTimePicker.Format = DateTimePickerFormat.Custom;
            billingDateDateTimePicker.CustomFormat = Constants.SQLiteDateFormat;

            documentsDateDateTimePicker.Format = DateTimePickerFormat.Custom;
            documentsDateDateTimePicker.CustomFormat = Constants.SQLiteDateFormat;

            expluatationDateDateTimePicker.Format = DateTimePickerFormat.Custom;
            expluatationDateDateTimePicker.CustomFormat = Constants.SQLiteDateFormat;

            disposalDateDateTimePicker.Format = DateTimePickerFormat.Custom;
            disposalDateDateTimePicker.CustomFormat = Constants.SQLiteDateFormat;
        }

        private void editCommonAssetsButton_Click(object sender, EventArgs e)
        {
            string internalIndex = commonAssets.GetInternalIndex();
            commonAssets = new CommonAssets();
            commonAssets.SetInternalIndex(internalIndex);

            if (includedInCostsTextBox.Text == String.Empty)
            {
                includedInCostsTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                includedInCostsTextBox.BackColor = SystemColors.Window;
            }

            if (initialCostTextBox.Text == "")
            {
                initialCostTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                initialCostTextBox.BackColor = SystemColors.Window;
            }

            if (nameTextBox.Text == "")
            {
                nameTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                nameTextBox.BackColor = SystemColors.Window;
            }

            if (numberOfSemestersTextBox.Text == "")
            {
                numberOfSemestersTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                numberOfSemestersTextBox.BackColor = SystemColors.Window; ;
            }

            if (objectsProportionOfValueTextBox.Text == "")
            {
                objectsProportionOfValueTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                objectsProportionOfValueTextBox.BackColor = SystemColors.Window;
            }

            if (objectsResidualValueTextBox.Text == "")
            {
                objectsResidualValueTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                objectsResidualValueTextBox.BackColor = SystemColors.Window;
            }

            if (objectsUsefulLifeTextBox.Text == "")
            {
                objectsUsefulLifeTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                objectsUsefulLifeTextBox.BackColor = SystemColors.Window;
            }

            if (includedInCostsTextBox.Text == "" ||
               initialCostTextBox.Text == "" ||
               nameTextBox.Text == "" ||
               numberOfSemestersTextBox.Text == "" ||
               objectsProportionOfValueTextBox.Text == "" ||
               objectsResidualValueTextBox.Text == "" ||
               objectsUsefulLifeTextBox.Text == "")
            {
                MessageBox.Show("Заполните все обязательные поля перед добавлением основных средств.");
                return;
            }

            commonAssets.BillingDate = billingDateDateTimePicker.Text;
            commonAssets.DisposalDate = disposalTimeTextBox.Text;
            commonAssets.DocumentsDate = documentsDateDateTimePicker.Text;
            commonAssets.ExpluatationDate = expluatationDateDateTimePicker.Text;
            commonAssets.IncludedInCosts = includedInCostsTextBox.Text;
            commonAssets.InitialCost = initialCostTextBox.Text;
            commonAssets.Name = nameTextBox.Text;
            commonAssets.NumberOfSemesters = numberOfSemestersTextBox.Text;
            commonAssets.ObjectsProportionOfValue = objectsProportionOfValueTextBox.Text;
            commonAssets.ObjectsResidualValue = objectsResidualValueTextBox.Text;
            commonAssets.ObjectsUsefulLife = objectsUsefulLifeTextBox.Text;

            MainForm.programLogic.commonAssetsLogic.Update(commonAssets, INN);

            Close();
        }

        private void EditCommonAssetsForm_Load(object sender, EventArgs e)
        {
            nameTextBox.Text = commonAssets.Name;
            billingDateDateTimePicker.Text = commonAssets.BillingDate;
            documentsDateDateTimePicker.Text = commonAssets.DocumentsDate;
            expluatationDateDateTimePicker.Text = commonAssets.ExpluatationDate;
            initialCostTextBox.Text = commonAssets.InitialCost;
            objectsUsefulLifeTextBox.Text = commonAssets.ObjectsUsefulLife;
            objectsResidualValueTextBox.Text = commonAssets.ObjectsResidualValue;
            numberOfSemestersTextBox.Text = commonAssets.NumberOfSemesters;
            objectsProportionOfValueTextBox.Text = commonAssets.ObjectsProportionOfValue;

            if (commonAssets.DisposalDate != "Не задано")
            {
                disposalDateDateTimePicker.Text = commonAssets.DisposalDate;
            }
            else
            {
                disposalDateDateTimePicker.Text = DateTime.Now.ToShortDateString();
            }

            includedInCostsTextBox.Text = commonAssets.IncludedInCosts;

            INNInfoLabel.Text += INN;
        }

        private void disposalDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            disposalTimeTextBox.Text = disposalDateDateTimePicker.Text;
        }

        private void deleteDisposalDateButton_Click(object sender, EventArgs e)
        {
            disposalTimeTextBox.Text = "";
        }
    }
}
