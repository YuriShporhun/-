using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public partial class AddIncomeAndExpenseForm : Form
    {
        IncomeAndExpenseTimePeriod timePeriod;
        string INN;

        public AddIncomeAndExpenseForm(IncomeAndExpenseTimePeriod timePeriod, string INN)
        {
            InitializeComponent();

            this.timePeriod = timePeriod;
            this.INN = INN;

            incomeTextBox.KeyPress += TextBoxProcessor.ProcessOnlyFloats;
            expenseTextBox.KeyPress += TextBoxProcessor.ProcessOnlyFloats;

            dateDateTimePicker.Format = DateTimePickerFormat.Custom;
            dateDateTimePicker.CustomFormat = Constants.SQLiteDateFormat;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddIncomeAndExpenseButton_Click(object sender, EventArgs e)
        {
            if((incomeTextBox.Text == "0" && expenseTextBox.Text == "0") ||
               (incomeTextBox.Text != "0" && expenseTextBox.Text != "0"))
            {
                MessageBox.Show("Заполните расход либо доход.");
                return;
            }

            IncomeAndExpense incomeAndExpense = new IncomeAndExpense();

            incomeAndExpense.Date = dateDateTimePicker.Text;
            incomeAndExpense.DocumentsNumber = documentsNumberTextBox.Text; 
            incomeAndExpense.SubstanceOfTransaction = substanceOfTransactionTextBox.Text;
            incomeAndExpense.Income = incomeTextBox.Text;
            incomeAndExpense.Expense = expenseTextBox.Text;

            try
            {
                Convert.ToDouble(incomeAndExpense.Income);
            }
            catch(FormatException)
            {
                MessageBox.Show("Поле дохода указано неверно.");
                return;
            }

            try
            {
                Convert.ToDouble(incomeAndExpense.Expense);
            }
            catch(FormatException)
            {
                MessageBox.Show("Поле расхода указано не верно");
                return;
            }

            MainForm.programLogic.incomeAndExpenseLogic.Insert(incomeAndExpense, timePeriod, INN);

            Close();
        }

        private void GetFromGuideButton_Click(object sender, EventArgs e)
        {
            var selectGuideToOperationForm = new SelectGuideToOperationForm();
            selectGuideToOperationForm.ShowDialog();
            substanceOfTransactionTextBox.Text = selectGuideToOperationForm.SelectedGuideToOperationText;
        }

        private void AddIncomeAndExpenseForm_Load(object sender, EventArgs e)
        {
            dateDateTimePicker.MaxDate = new DateTime(timePeriod.Year, 12, 31);
            dateDateTimePicker.MinDate = new DateTime(timePeriod.Year, 1, 1);

            incomeTextBox.MouseDown += TextBoxProcessor.GotFocusSelectAll;
            expenseTextBox.MouseDown += TextBoxProcessor.GotFocusSelectAll;

            INNInfoLabel.Text += INN;
        }
    }
}
