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
    public partial class AddUseOfPropertyForm : Form
    {
        public UseOfProperty useOfProperty { get; private set; }

        public DialogResult formResult = DialogResult.No;

        public AddUseOfPropertyForm()
        {
            InitializeComponent();

            ДатаПоступленияDateTimePicker.Format = DateTimePickerFormat.Custom;
            ДатаПоступленияDateTimePicker.CustomFormat = Constants.SQLiteDateFormat;

            СрокИспользованияDateTimePicker.Format = DateTimePickerFormat.Custom;
            СрокИспользованияDateTimePicker.CustomFormat = Constants.SQLiteDateFormat;
        }

        private void GetCodeFromReferenceButton_Click(object sender, EventArgs e)
        {
            IncomeTypeCodeReferenceForm incomeTypeCodeReferenceForm = new IncomeTypeCodeReferenceForm();
            incomeTypeCodeReferenceForm.ShowDialog();
            КодВидаПоступленийTextBox.Text = incomeTypeCodeReferenceForm.SelectedIncomeTypeCode;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if(!CheckFormCorrectness())
            {
                return;
            }

            useOfProperty = new UseOfProperty();
            useOfProperty.IncomeTypeCode = КодВидаПоступленийTextBox.Text;
            useOfProperty.GoodsReceiptDate = ДатаПоступленияDateTimePicker.Text;
            useOfProperty.PeriodOfUse = СрокИспользованияDateTimePicker.Text;
            useOfProperty.ValueOfProperty = СтоимостьИмуществаTextBox.Text;
            useOfProperty.AmountOfFundsWherePeriodHasNotExpired = СуммаСредствСрокИспользованияКоторыхНеИстекTextBox.Text;
            useOfProperty.AmountOfUsedFunds = СуммаСредствИспользованныхПоНазначениюTextBox.Text;
            useOfProperty.AmountOfBadUsedOrNotUsedFunds = СуммаСредствИспользованныхНеПоназначениюTextBox.Text;
            formResult = DialogResult.Yes;
            Close();
        }

        private bool CheckFormCorrectness()
        {
            bool areAllFieldsCorrect = true;
            List<string> warningMessages = new List<string>();

            if (КодВидаПоступленийTextBox.Text.Length != Constants.requiredIncomeTypeCodeLength)
            {
                warningMessages.Add("Поле кода вида поступлений должно содержать " + Constants.requiredIncomeTypeCodeLength + " знака");
                КодВидаПоступленийTextBox.BackColor = Constants.badFieldColor;
                areAllFieldsCorrect = false;
            }
            else
            {
                КодВидаПоступленийTextBox.BackColor = Constants.commonFieldColor;
            }

            if (areAllFieldsCorrect)
            {
                return true;
            }
            else
            {
                WarningForm warningForm = new WarningForm(warningMessages);
                warningForm.ShowDialog();
                return false;
            }
        }

        private void AddUseOfPropertyForm_Load(object sender, EventArgs e)
        {
            КодВидаПоступленийTextBox.MaxLength = Constants.requiredIncomeTypeCodeLength;
            СтоимостьИмуществаTextBox.MaxLength = Constants.maximumESHNPartFourIncomeFieldLength;
            СуммаСредствИспользованныхПоНазначениюTextBox.MaxLength = Constants.maximumESHNPartFourIncomeFieldLength;
            СуммаСредствИспользованныхНеПоназначениюTextBox.MaxLength = Constants.maximumESHNPartFourIncomeFieldLength;
            СуммаСредствСрокИспользованияКоторыхНеИстекTextBox.MaxLength = Constants.maximumESHNPartFourIncomeFieldLength;

            КодВидаПоступленийTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;
            СтоимостьИмуществаTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;
            СуммаСредствИспользованныхПоНазначениюTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;
            СуммаСредствИспользованныхНеПоназначениюTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;
            СуммаСредствСрокИспользованияКоторыхНеИстекTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;
        }
    }
}
