using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class BankAccountDataProvider
    {
        string dataBaseFullPath;
        string connectionString;

        public BankAccountDataProvider()
        {
            this.dataBaseFullPath = Constants.dataBaseFullPath;
            connectionString = "provider=Microsoft.Jet.OLEDB.4.0; data source=" + dataBaseFullPath;
        }

        public List<BankAccount> Load()
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();

            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            myOleDbCommand.CommandText = "SELECT * FROM [Номера счетов]";

            myOleDbConnection.Open();

            OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader();

            while (myOleDbDataReader.Read())
            {
                BankAccount temporaryBankAccount = new BankAccount();

                string internalIndex = myOleDbDataReader["счетчик"].ToString();

                temporaryBankAccount.SetInternalIndex(internalIndex);

                temporaryBankAccount.BankName = myOleDbDataReader["Название банка"].ToString();

                temporaryBankAccount.FIO = myOleDbDataReader["ФИО"].ToString();

                temporaryBankAccount.AccountNumber = myOleDbDataReader["Номер счета"].ToString();

                bankAccounts.Add(temporaryBankAccount);
            }

            myOleDbDataReader.Close();

            myOleDbConnection.Close();

            return bankAccounts;
        }

        public void Insert(BankAccount bankAccount)
        {

            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            string commandText = "INSERT INTO [Номера счетов] (";
            commandText += "[Название банка], [ФИО], [Номер счета]) VALUES(";

            commandText += "'";
            commandText += bankAccount.BankName;
            commandText += "',";

            commandText += "'";
            commandText += bankAccount.FIO;
            commandText += "',";

            commandText += "'";
            commandText += bankAccount.AccountNumber;
            commandText += "'";

            commandText += ");";

            myOleDbCommand.CommandText = commandText;

            myOleDbConnection.Open();

            myOleDbCommand.ExecuteScalar();

            myOleDbConnection.Close();
        }

        public void Delete(string internalIndex)
        {
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            string commandText = "DELETE FROM [Номера счетов] WHERE [счетчик]=";

            commandText += "";

            commandText += internalIndex;

            commandText += ";";

            myOleDbCommand.CommandText = commandText;

            myOleDbConnection.Open();

            myOleDbCommand.ExecuteScalar();

            myOleDbConnection.Close();
        }

        public void Update(BankAccount bankAccount)
        {
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            string commandText = "UPDATE [Номера счетов] SET ";

            commandText += "[Название банка] = '";
            commandText += bankAccount.BankName;
            commandText += "',";

            commandText += "[ФИО] = '";
            commandText += bankAccount.FIO;
            commandText += "',";

            commandText += "[Номер счета] = '";
            commandText += bankAccount.AccountNumber;
            commandText += "'";

            commandText += " WHERE [счетчик] = ";

            commandText += bankAccount.GetInternalIndex();

            commandText += ";";

            myOleDbCommand.CommandText = commandText;

            myOleDbConnection.Open();

            myOleDbCommand.ExecuteScalar();

            myOleDbConnection.Close();
        }
    }
}
