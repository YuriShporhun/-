using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class IncomeAndExpenseDataProvider
    {
        string dataBaseFullPath;
        string connectionString;

        public IncomeAndExpenseDataProvider()
        {
            this.dataBaseFullPath = Constants.dataBaseFullPath;
            connectionString = "provider=Microsoft.Jet.OLEDB.4.0; data source=" + dataBaseFullPath;
        }

        public List<IncomeAndExpense> LoadIncomeAndExpense(IncomeAndExpenseTimePeriod timePeriod)
        {
            List<IncomeAndExpense> incomeAndExpense = new List<IncomeAndExpense>();

            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            string commandText = "";

            commandText += "SELECT * FROM [Доходы и расходы " + timePeriod.Year + "] WHERE [Дата] >= DateSerial(" + timePeriod.StartDate.Year + "," + timePeriod.StartDate.Month + "," + timePeriod.StartDate.Day + ")";
            commandText += "AND [Дата] <= DateSerial(" + timePeriod.EndDate.Year + "," + timePeriod.EndDate.Month + "," + timePeriod.EndDate.Day + ")";


            myOleDbCommand.CommandText = commandText;

            myOleDbConnection.Open();

            OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader();

            while (myOleDbDataReader.Read())
            {
                IncomeAndExpense temporaryIncomeAndExpense = new IncomeAndExpense();

                string timeFormat = "dd.MM.yyyy h:mm:ss";
                CultureInfo provider = CultureInfo.InvariantCulture;

                string internalIndex = myOleDbDataReader["№ п/п"].ToString();

                temporaryIncomeAndExpense.SetInternalIndex(internalIndex);

                string billingDate = myOleDbDataReader["Дата"].ToString();

                if (billingDate != "")
                {
                    temporaryIncomeAndExpense.Date = DateTime.ParseExact(billingDate, timeFormat, provider).ToShortDateString();
                }
                else
                {
                    temporaryIncomeAndExpense.Date = "Не задано";
                }

                temporaryIncomeAndExpense.DocumentsNumber = myOleDbDataReader["№ документа"].ToString();
                temporaryIncomeAndExpense.Expense = myOleDbDataReader["Расход"].ToString();
                temporaryIncomeAndExpense.Income = myOleDbDataReader["Доход"].ToString();
                temporaryIncomeAndExpense.SubstanceOfTransaction = myOleDbDataReader["Содержание операции"].ToString();

                incomeAndExpense.Add(temporaryIncomeAndExpense);
            }

            myOleDbConnection.Close();

            return incomeAndExpense;
        }

        public void InsertIncomeAndExpense(IncomeAndExpense incomeAndExpense, IncomeAndExpenseTimePeriod timePeriod)
        {
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            StringBuilder commandText = new StringBuilder();

            commandText.Append("INSERT INTO [Доходы и расходы " + timePeriod.Year + "]"); 
            commandText.Append("([Дата], [№ документа], [Содержание операции],");
            commandText.Append("[Доход], [Расход]");
            commandText.Append(") VALUES(");

            DataProvider.AddCommandTextInsert(commandText, incomeAndExpense.Date);
            DataProvider.AddCommandTextInsert(commandText, incomeAndExpense.DocumentsNumber);
            DataProvider.AddCommandTextInsert(commandText, incomeAndExpense.SubstanceOfTransaction);
            DataProvider.AddCommandTextInsert(commandText, incomeAndExpense.Income);
            DataProvider.AddCommandTextInsert(commandText, incomeAndExpense.Expense, last:true);

            commandText.Append(");");

            myOleDbCommand.CommandText = commandText.ToString();

            myOleDbConnection.Open();
            myOleDbCommand.ExecuteScalar();
            myOleDbConnection.Close();
        }

        public void DeleteIncomeAndExpense(string internalIndex, IncomeAndExpenseTimePeriod timePeriod)
        {
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            StringBuilder commandText = new StringBuilder();

            commandText.Append("DELETE FROM [Доходы и расходы " + timePeriod.Year + "] WHERE [№ п/п]=");

            DataProvider.AddCommandTextDelete(commandText, internalIndex);

            myOleDbCommand.CommandText = commandText.ToString();
            myOleDbConnection.Open();
            myOleDbCommand.ExecuteScalar();
            myOleDbConnection.Close();
        }

        public void UpdateIncomeAndExpense(IncomeAndExpense incomeAndExpense, IncomeAndExpenseTimePeriod timePeriod)
        {
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            StringBuilder commandText = new StringBuilder();
                
            commandText.Append("UPDATE [Доходы и расходы " + timePeriod.Year +"] SET ");

            DataProvider.AddCommandTextUpdate(commandText, "Дата", incomeAndExpense.Date);
            DataProvider.AddCommandTextUpdate(commandText, "№ документа", incomeAndExpense.DocumentsNumber);
            DataProvider.AddCommandTextUpdate(commandText, "Содержание операции", incomeAndExpense.SubstanceOfTransaction);
            DataProvider.AddCommandTextUpdate(commandText, "Доход", incomeAndExpense.Income);
            DataProvider.AddCommandTextUpdate(commandText, "Расход", incomeAndExpense.Expense, last: true);
     
            commandText.Append(" WHERE [№ п/п] = ");
            commandText.Append(incomeAndExpense.GetInternalIndex());
            commandText.Append(";");

            myOleDbCommand.CommandText = commandText.ToString();
            myOleDbConnection.Open();
            myOleDbCommand.ExecuteScalar();
            myOleDbConnection.Close();
        }
    }
}
