using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public class BankAccountLogic
    {
        DataGridView bankAccountsGridView;
        BankAccountSQLiteDataProvider bankAccountDataProvider;

        List<BankAccount> bankAccounts = new List<BankAccount>();

        public BankAccount this[int index]
        {
            get
            {
                return bankAccounts[index];
            }
        }

        public BankAccountLogic(DataGridView bankAccountsGridView)
        {
            bankAccountDataProvider = new BankAccountSQLiteDataProvider();
            this.bankAccountsGridView = bankAccountsGridView;
        }

        private void Bind()
        {
            var bankAccountsBindingSource = new BindingSource();
            bankAccountsBindingSource.DataSource = bankAccounts;
            bankAccountsGridView.DataSource = bankAccountsBindingSource;
        }

        public void Load(string INN)
        {
            bankAccounts = bankAccountDataProvider.Load(INN);
            Bind();
        }

        public void Insert(BankAccount bankAccount, string INN)
        {
            bankAccountDataProvider.Insert(bankAccount, INN);
            Load(INN);
        }

        public void Delete(int indexInProgramsList, string INN)
        {
            bankAccountDataProvider.Delete(bankAccounts[indexInProgramsList].GetInternalIndex());
            Load(INN);
        }

        public void Update(BankAccount bankAccount, string INN)
        {
            bankAccountDataProvider.Update(bankAccount);
            Load(INN);
        }
    }
}
