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
    public partial class BankAccountsForm : Form
    {
        BankAccountLogic bankAccountLogic;

        string FIO;
        string INN;

        public BankAccountsForm(string FIO, string INN)
        {
            InitializeComponent();
            this.FIO = FIO;
            this.INN = INN;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BankAccountsForm_Load(object sender, EventArgs e)
        {
            bankAccountLogic = new BankAccountLogic(bankAccountsGridView);
            bankAccountLogic.Load(INN);
        }

        private void addBankAccountButton_Click(object sender, EventArgs e)
        {
            AddBankAccountForm addBankAccountForm = new AddBankAccountForm(FIO);
            addBankAccountForm.ShowDialog();
            if(addBankAccountForm.formResult == System.Windows.Forms.DialogResult.Yes)
            {
                bankAccountLogic.Insert(addBankAccountForm.bankAccount, INN);
            }
        }

        private void editBankAccountButton_Click(object sender, EventArgs e)
        {
            if (bankAccountsGridView.RowCount == 0)
            {
                MessageBox.Show("В таблице счетов нет данных для редактирования");
                return;
            }

            AddBankAccountForm addBankAccountForm = new AddBankAccountForm(FIO, bankAccountLogic[bankAccountsGridView.CurrentCell.RowIndex]);
            addBankAccountForm.ShowDialog();

            if (addBankAccountForm.formResult == System.Windows.Forms.DialogResult.Yes)
            {
                bankAccountLogic.Update(addBankAccountForm.bankAccount, INN);
            }
        }

        private void deleteBankAccountButton_Click(object sender, EventArgs e)
        {
            if(bankAccountsGridView.RowCount == 0)
            {
                MessageBox.Show("В таблице счетов нет данных для удаления");
                return;
            }

            var dialogResult = MessageBox.Show("Уверены, что хотите удалить запись", "Предупреждение", MessageBoxButtons.YesNo);

            if(dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                bankAccountLogic.Delete(bankAccountsGridView.CurrentCell.RowIndex, INN);
            }
        }
    }
}
