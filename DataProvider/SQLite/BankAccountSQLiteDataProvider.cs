using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class BankAccountSQLiteDataProvider
    {
        public void ImportBankAccounts(List<BankAccount> bankAccounts, string INN)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            foreach (var item in bankAccounts)
            {
                StringBuilder commandText = new StringBuilder();
                commandText.Append("INSERT INTO НомераСчетов (ИНН, НазваниеБанка, НомерСчета) VALUES(");

                DataProvider.AddCommandTextInsert(commandText, INN);
                DataProvider.AddCommandTextInsert(commandText, item.BankName);
                DataProvider.AddCommandTextInsert(commandText, item.AccountNumber, last: true);

                commandText.Append(");");
                sqlite_cmd.CommandText = commandText.ToString();
                sqlite_cmd.ExecuteNonQuery();
            }

            sqlite_conn.Close();
        }

        public List<BankAccount> Load(string INN)
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("SELECT Индекс, НазваниеБанка, НомерСчета FROM НомераСчетов WHERE ИНН=" + INN);

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                BankAccount temporaryBankAccount = new BankAccount();
                string internalIndex = sqlite_datareader["Индекс"].ToString();
                temporaryBankAccount.SetInternalIndex(internalIndex);
                temporaryBankAccount.BankName = sqlite_datareader["НазваниеБанка"].ToString();
                temporaryBankAccount.AccountNumber = sqlite_datareader["НомерСчета"].ToString();
                bankAccounts.Add(temporaryBankAccount);
            }

            sqlite_datareader.Close();
            sqlite_conn.Close();

            return bankAccounts;
        }

        public void Insert(BankAccount bankAccount, string INN)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("INSERT INTO НомераСчетов (ИНН, НазваниеБанка, НомерСчета) VALUES(");

            DataProvider.AddCommandTextInsert(commandText, INN);
            DataProvider.AddCommandTextInsert(commandText, bankAccount.BankName);
            DataProvider.AddCommandTextInsert(commandText, bankAccount.AccountNumber, last: true);

            commandText.Append(");");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

        public void Delete(string internalIndex)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("DELETE FROM НомераСчетов WHERE [Индекс]=");
            DataProvider.AddCommandTextDelete(commandText, internalIndex);

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteScalar();
            sqlite_conn.Close();
        }

        public void Update(BankAccount bankAccount)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("UPDATE НомераСчетов SET ");

            DataProvider.AddCommandTextUpdate(commandText, "НазваниеБанка", bankAccount.BankName);
            DataProvider.AddCommandTextUpdate(commandText, "НомерСчета", bankAccount.AccountNumber, last:true);

            commandText.Append(" WHERE Индекс = ");
            commandText.Append(bankAccount.GetInternalIndex());
            commandText.Append(";");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteScalar();
            sqlite_conn.Close();
        }
    }
}
