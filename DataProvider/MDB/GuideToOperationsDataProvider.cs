using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace AccountingForAgriculturalTax
{
    public class GuideToOperationsDataProvider
    {
        string dataBaseFullPath;
        string connectionString;
        public GuideToOperationsDataProvider()
        {
            this.dataBaseFullPath = Constants.dataBaseFullPath;
            connectionString = "provider=Microsoft.Jet.OLEDB.4.0; data source=" + dataBaseFullPath;
        }

        public List<GuideToOperation> LoadGuideToOperations()
        {
            List<GuideToOperation> guideToOperations = new List<GuideToOperation>();
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            myOleDbCommand.CommandText = "SELECT * FROM Справочник";

            myOleDbConnection.Open();

            OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader();

            while (myOleDbDataReader.Read())
            {
                GuideToOperation guideToOperation = new GuideToOperation(myOleDbDataReader["Название"].ToString());
                guideToOperation.SetInternalIndex(Convert.ToInt32(myOleDbDataReader["Номер"]));
                guideToOperations.Add(guideToOperation);
            }

            myOleDbDataReader.Close();
            myOleDbConnection.Close();
            return guideToOperations;
        }

        public void InsertGuideToOperation(string guideToOperationText)
        {
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            StringBuilder commandText = new StringBuilder();

            commandText.Append("INSERT INTO Справочник (Название) VALUES(");

            DataProvider.AddCommandTextInsert(commandText, guideToOperationText, last: true);

            commandText.Append(");");

            myOleDbCommand.CommandText = commandText.ToString();

            myOleDbConnection.Open();
            myOleDbCommand.ExecuteScalar();
            myOleDbConnection.Close();
        }

        public void DeleteGuideToOperation(string indexToDelete)
        {
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            StringBuilder commandText = new StringBuilder();

            commandText.Append("DELETE FROM Справочник WHERE Номер=");
            commandText.Append(indexToDelete);
            commandText.Append(";");

            myOleDbCommand.CommandText = commandText.ToString();
            myOleDbConnection.Open();
            myOleDbCommand.ExecuteScalar();
            myOleDbConnection.Close();
        }

        public void UpdateGuideToOperation(string internalIndex, string textToupdate)
        {
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
            StringBuilder commandText = new StringBuilder();

            commandText.Append("UPDATE Справочник SET ");

            DataProvider.AddCommandTextUpdate(commandText, "Название", textToupdate, last: true);

            commandText.Append(" WHERE Номер = ");
            commandText.Append(internalIndex);
            commandText.Append(";");

            myOleDbCommand.CommandText = commandText.ToString();
            myOleDbConnection.Open();
            myOleDbCommand.ExecuteScalar();
            myOleDbConnection.Close();
        }
    }
}
