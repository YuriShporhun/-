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
    public partial class AddBankAccountForm : Form
    {
        public DialogResult formResult = DialogResult.No;
        public BankAccount bankAccount = new BankAccount();
        string FIO;
        public AddBankAccountForm(string FIO)
        {
            InitializeComponent();
            this.FIO = FIO;
            addBackAccountButton.Text = "Добавить";
        }

        public AddBankAccountForm(string FIO, BankAccount bankAccount)
        {
            InitializeComponent();
            this.FIO = FIO;
            this.bankNameTextBox.Text = bankAccount.BankName;
            this.accountNumberTextBox.Text = bankAccount.AccountNumber;
            addBackAccountButton.Text = "Редактировать";
            this.bankAccount.SetInternalIndex(bankAccount.GetInternalIndex());
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addBackAccountButton_Click(object sender, EventArgs e)
        {
            if(accountNumberTextBox.Text == "" ||
               bankNameTextBox.Text == "")
            {
                MessageBox.Show("Заполните номер счета и название банка", "Предупреждение");
                return;
            }
            formResult = System.Windows.Forms.DialogResult.Yes;
            bankAccount.AccountNumber = accountNumberTextBox.Text;
            bankAccount.BankName = bankNameTextBox.Text;
            bankAccount.FIO = FIO;
            Close();
        }
    }
}
