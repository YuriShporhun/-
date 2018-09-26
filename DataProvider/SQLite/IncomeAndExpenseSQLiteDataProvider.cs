using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public class IncomeAndExpenseSQLiteDataProvider
    {
        public static void Import(List<IncomeAndExpense> incomeAndExpense, int year, string INN)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();
            foreach (var item in incomeAndExpense)
            {
                StringBuilder commandText = new StringBuilder();
                commandText.Append("INSERT INTO [ДоходыИРасходы] (ИНН, НомерДокумента, Дата, СодержаниеОперации, Доход, Расход)");
                commandText.Append("VALUES(");

                DataProvider.AddCommandTextInsert(commandText, INN);
                DataProvider.AddCommandTextInsert(commandText, item.DocumentsNumber);
                DataProvider.AddCommandTextInsert(commandText, DataProvider.ConvertDateToSQLiteFormat(item.Date));
                DataProvider.AddCommandTextInsert(commandText, item.SubstanceOfTransaction);
                DataProvider.AddCommandTextInsert(commandText, item.Income);
                DataProvider.AddCommandTextInsert(commandText, item.Expense, last: true);
                commandText.Append(");");

                sqlite_cmd.CommandText = commandText.ToString();
                sqlite_cmd.ExecuteNonQuery();
            }
            sqlite_conn.Close();
        }

        public List<IncomeAndExpense> Load(IncomeAndExpenseTimePeriod timePeriod, string INN)
        {
            List<IncomeAndExpense> incomeAndExpense = new List<IncomeAndExpense>();

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("SELECT Индекс, НомерДокумента, Дата, СодержаниеОперации, Доход, Расход FROM ДоходыИРасходы WHERE date([Дата]) >= date(\"" + timePeriod.StartDate.Year + "-" + timePeriod.StartDate.Month.ToString("00") + "-" + timePeriod.StartDate.Day.ToString("00") + "\")");
            commandText.Append("AND date([Дата]) <= date(\"" + timePeriod.EndDate.Year + "-" + timePeriod.EndDate.Month.ToString("00") + "-" + timePeriod.EndDate.Day.ToString("00") + "\") ");
            commandText.Append("AND ИНН=" + INN + " ");
            commandText.Append("ORDER BY Дата");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                IncomeAndExpense temporaryIncomeAndExpense = new IncomeAndExpense();

                string internalIndex = sqlite_datareader["Индекс"].ToString();

                temporaryIncomeAndExpense.SetInternalIndex(internalIndex);

                string billingDate = sqlite_datareader["Дата"].ToString();

                temporaryIncomeAndExpense.Date = DataProvider.ConvertDateThatCantBeEmpty(billingDate);

                temporaryIncomeAndExpense.DocumentsNumber = sqlite_datareader["НомерДокумента"].ToString();
                temporaryIncomeAndExpense.Expense = sqlite_datareader["Расход"].ToString();
                temporaryIncomeAndExpense.Income = sqlite_datareader["Доход"].ToString();
                temporaryIncomeAndExpense.SubstanceOfTransaction = sqlite_datareader["СодержаниеОперации"].ToString();

                incomeAndExpense.Add(temporaryIncomeAndExpense);
            }

            sqlite_datareader.Close();
            sqlite_conn.Close();

            return incomeAndExpense;
        }

        public void Delete(string internalIndex, IncomeAndExpenseTimePeriod timePeriod)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();
            commandText.Append("DELETE FROM ДоходыИРасходы WHERE [Индекс]=");
            DataProvider.AddCommandTextDelete(commandText, internalIndex);

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteScalar();
            sqlite_conn.Close();
        }

        public void Update(IncomeAndExpense incomeAndExpense)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("UPDATE ДоходыИРасходы SET ");

            DataProvider.AddCommandTextUpdate(commandText, "Дата", DataProvider.ConvertDateToSQLiteFormat(incomeAndExpense.Date));
            DataProvider.AddCommandTextUpdate(commandText, "НомерДокумента", incomeAndExpense.DocumentsNumber);
            DataProvider.AddCommandTextUpdate(commandText, "СодержаниеОперации", incomeAndExpense.SubstanceOfTransaction);
            DataProvider.AddCommandTextUpdate(commandText, "Доход", incomeAndExpense.Income);
            DataProvider.AddCommandTextUpdate(commandText, "Расход", incomeAndExpense.Expense, last: true);

            commandText.Append(" WHERE Индекс = " + incomeAndExpense.GetInternalIndex() + ";");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

        public void Insert(IncomeAndExpense incomeAndExpense, string INN)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("INSERT INTO ДоходыИРасходы");
            commandText.Append("(ИНН, Дата, НомерДокумента, СодержаниеОперации, Доход, Расход");
            commandText.Append(") VALUES(");

            DataProvider.AddCommandTextInsert(commandText, INN);
            DataProvider.AddCommandTextInsert(commandText, DataProvider.ConvertDateToSQLiteFormat(incomeAndExpense.Date));
            DataProvider.AddCommandTextInsert(commandText, incomeAndExpense.DocumentsNumber);
            DataProvider.AddCommandTextInsert(commandText, incomeAndExpense.SubstanceOfTransaction);
            DataProvider.AddCommandTextInsert(commandText, incomeAndExpense.Income);
            DataProvider.AddCommandTextInsert(commandText, incomeAndExpense.Expense, last: true);

            commandText.Append(");");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }
    }
}
