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
    public partial class AddCommonAssetsForm : Form
    {
        string INN;

        public AddCommonAssetsForm(string INN)
        {
            InitializeComponent();
            closeButton.Click += (s, o) => Close();

            this.INN = INN;

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

        private void addCommonAssetsButton_Click(object sender, EventArgs e)
        {
            CommonAssets commonAssets = new CommonAssets();

            if (includedInCostsTextBox.Text == String.Empty)
            {
                includedInCostsTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                includedInCostsTextBox.BackColor = SystemColors.Window;
            }

            if(initialCostTextBox.Text  == String.Empty)
            {
                initialCostTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                initialCostTextBox.BackColor = SystemColors.Window;
            }

            if(nameTextBox.Text == String.Empty)
            {
                nameTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                nameTextBox.BackColor = SystemColors.Window;
            }

            if(numberOfSemestersTextBox.Text == String.Empty)
            {
                numberOfSemestersTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                numberOfSemestersTextBox.BackColor = SystemColors.Window; ;
            }

            if (objectsProportionOfValueTextBox.Text == String.Empty)
            {
                objectsProportionOfValueTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                objectsProportionOfValueTextBox.BackColor = SystemColors.Window;
            }

            if (objectsResidualValueTextBox.Text == String.Empty)
            {
                objectsResidualValueTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                objectsResidualValueTextBox.BackColor = SystemColors.Window;
            }

            if (objectsUsefulLifeTextBox.Text == String.Empty)
            {
                objectsUsefulLifeTextBox.BackColor = Constants.badFieldColor;
            }
            else
            {
                objectsUsefulLifeTextBox.BackColor = SystemColors.Window; ;
            }

            if (includedInCostsTextBox.Text == String.Empty ||
               initialCostTextBox.Text == String.Empty ||
               nameTextBox.Text == String.Empty ||
               numberOfSemestersTextBox.Text == String.Empty ||
               objectsProportionOfValueTextBox.Text == String.Empty ||
               objectsResidualValueTextBox.Text == String.Empty ||
               objectsUsefulLifeTextBox.Text == String.Empty)
            {
                MessageBox.Show("Заполните все обязательные поля перед добавлением основных средств. (Выделены красным)");
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

            MainForm.programLogic.commonAssetsLogic.Insert(commonAssets, INN);
            
            Close();
        }

        private void disposalDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            disposalTimeTextBox.Text = disposalDateDateTimePicker.Text;
        }

        private void deleteDisposalDateButton_Click(object sender, EventArgs e)
        {
            disposalTimeTextBox.Text = "";
        }

        private void initialCostTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void objectsUsefulLifeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void objectsResidualValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void numberOfSemestersTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void objectsProportionOfValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void includedInCostsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AddCommonAssetsForm_Load(object sender, EventArgs e)
        {
            INNInfoLabel.Text += INN;
        }
    }
}
