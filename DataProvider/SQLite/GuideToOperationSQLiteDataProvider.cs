using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class GuideToOperationSQLiteDataProvider
    {
        string dataBaseFullPath;

        public GuideToOperationSQLiteDataProvider()
        {
            this.dataBaseFullPath = Constants.SQLiteDataBaseFullPath;
        }

        public void ImportGuideToOperations(List<GuideToOperation> guideToOperations)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();
            foreach (var item in guideToOperations)
            {
                StringBuilder commandText = new StringBuilder();
                commandText.Append("INSERT INTO СправочникОпераций (Содержание) VALUES(");
                DataProvider.AddCommandTextInsert(commandText, item.Name, last: true);
                commandText.Append(");");
                sqlite_cmd.CommandText = commandText.ToString();
                sqlite_cmd.ExecuteNonQuery();
            }
            sqlite_conn.Close();
        }

        public List<GuideToOperation> Load()
        {
            List<GuideToOperation> guideToOperations = new List<GuideToOperation>();

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT Индекс, Содержание FROM СправочникОпераций");
            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                GuideToOperation guideToOperation = new GuideToOperation(sqlite_datareader["Содержание"].ToString());
                guideToOperation.SetInternalIndex(Convert.ToInt32(sqlite_datareader["Индекс"]));
                guideToOperations.Add(guideToOperation);
            }

            sqlite_datareader.Close();
            sqlite_conn.Close();
            return guideToOperations;
        }

        public void Insert(GuideToOperation guideToOperation)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("INSERT INTO СправочникОпераций (Содержание) VALUES(");

            DataProvider.AddCommandTextInsert(commandText, guideToOperation.Name, last: true);

            commandText.Append(");");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

        public void Update(GuideToOperation guideToOperation, string textToUpdate)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("UPDATE СправочникОпераций SET ");

            DataProvider.AddCommandTextUpdate(commandText, "Содержание", textToUpdate, last: true);

            commandText.Append(" WHERE Индекс = ");
            commandText.Append(guideToOperation.GetInternalIndex());
            commandText.Append(";");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

        public void Delete(string indexToDelete)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("DELETE FROM СправочникОпераций WHERE Индекс=");
            commandText.Append(indexToDelete);
            commandText.Append(";");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }
    }
}
