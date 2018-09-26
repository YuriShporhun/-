using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class CommonAssetsDataProvider
    {
        string dataBaseFullPath;
        string connectionString;

        public CommonAssetsDataProvider()
        {
            this.dataBaseFullPath = Constants.dataBaseFullPath;
            connectionString = "provider=Microsoft.Jet.OLEDB.4.0; data source=" + dataBaseFullPath;
        }

        public List<CommonAssets> Load()
        {
            List<CommonAssets> commonAssets = new List<CommonAssets>();

            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            myOleDbCommand.CommandText = "SELECT * FROM [Основные средства]";

            myOleDbConnection.Open();

            OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader();

            while (myOleDbDataReader.Read())
            {
                CommonAssets temporaryCommonAssets = new CommonAssets();
                string timeFormat = "dd.MM.yyyy h:mm:ss";
                CultureInfo provider = CultureInfo.InvariantCulture;
                string internalIndex = myOleDbDataReader["№ п/п"].ToString();
                temporaryCommonAssets.SetInternalIndex(internalIndex);
                string billingDate = myOleDbDataReader["Дата оплаты объекта"].ToString();

                if (billingDate != "")
                {
                    temporaryCommonAssets.BillingDate = DateTime.ParseExact(billingDate, timeFormat, provider).ToShortDateString();
                }
                else
                {
                    temporaryCommonAssets.BillingDate = "Не задано";
                }

                string disposalDate = myOleDbDataReader["Дата выбытия"].ToString();

                if (disposalDate != "")
                {
                    temporaryCommonAssets.DisposalDate = DateTime.ParseExact(disposalDate, timeFormat, provider).ToShortDateString();
                }
                else
                {
                    temporaryCommonAssets.DisposalDate = "Не задано";
                }

                string documentsDate = myOleDbDataReader["Дата подачи документов"].ToString();

                if (documentsDate != "")
                {
                    temporaryCommonAssets.DocumentsDate = DateTime.ParseExact(documentsDate, timeFormat, provider).ToShortDateString();
                }
                else
                {
                    temporaryCommonAssets.DocumentsDate = "Не задано";
                }

                string expluatationDate = myOleDbDataReader["Дата ввода в эксплуатацию"].ToString();

                if (expluatationDate != "")
                {
                    temporaryCommonAssets.ExpluatationDate = DateTime.ParseExact(expluatationDate, timeFormat, provider).ToShortDateString();
                }
                else
                {
                    temporaryCommonAssets.ExpluatationDate = "Не задано";
                }

                temporaryCommonAssets.IncludedInCosts = myOleDbDataReader["Включено в расходы"].ToString();
                temporaryCommonAssets.InitialCost = myOleDbDataReader["Первоначальная стоимость объекта"].ToString();
                temporaryCommonAssets.Name = myOleDbDataReader["Наименование объекта"].ToString();
                temporaryCommonAssets.NumberOfSemesters = myOleDbDataReader["Количества полугодий эксплуатации объекта"].ToString();
                temporaryCommonAssets.ObjectsProportionOfValue = myOleDbDataReader["Доля стоимости объекта  за налоговый объект"].ToString();
                temporaryCommonAssets.ObjectsResidualValue = myOleDbDataReader["Остаточная стоимость объекта"].ToString();
                temporaryCommonAssets.ObjectsUsefulLife = myOleDbDataReader["Срок полезного использования объекта"].ToString();

                commonAssets.Add(temporaryCommonAssets);
            }

            myOleDbDataReader.Close();
            myOleDbConnection.Close();
            return commonAssets;
        }

        public void Insert(CommonAssets commonAssets)
        {

            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("INSERT INTO [Основные средства] ([Наименование объекта],");
            commandText.Append("[Дата оплаты объекта], [Дата подачи документов], [Дата ввода в эксплуатацию],");
            commandText.Append("[Первоначальная стоимость объекта], [Срок полезного использования объекта],");
            commandText.Append("[Остаточная стоимость объекта], [Количества полугодий эксплуатации объекта],");
            commandText.Append("[Доля стоимости объекта  за налоговый объект], [Включено в расходы],");
            commandText.Append("[Дата выбытия]");
            commandText.Append(") VALUES(");


            DataProvider.AddCommandTextInsert(commandText, commonAssets.Name);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.BillingDate);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.DocumentsDate);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.ExpluatationDate);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.InitialCost);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.ObjectsUsefulLife);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.ObjectsResidualValue);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.NumberOfSemesters);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.ObjectsProportionOfValue);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.IncludedInCosts);


            if (commonAssets.DisposalDate != "")
            {
                DataProvider.AddCommandTextInsert(commandText, commonAssets.DisposalDate, last: true);
            }
            else
            {
                DataProvider.AddCommandTextInsert(commandText, "NULL", last: true);
            }

            commandText.Append(");");

            myOleDbCommand.CommandText = commandText.ToString();
            myOleDbConnection.Open();
            myOleDbCommand.ExecuteScalar();
            myOleDbConnection.Close();
        }

        public void Delete(string internalIndex)
        {
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            string commandText = "DELETE FROM [Основные средства] WHERE [№ п/п]=";
            commandText += internalIndex;
            commandText += ";";

            myOleDbCommand.CommandText = commandText;
            myOleDbConnection.Open();
            myOleDbCommand.ExecuteScalar();
            myOleDbConnection.Close();
        }

        public void Update(CommonAssets commonAssets)
        {
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            string commandText = "UPDATE [Основные средства] SET ";

            commandText += "[Наименование объекта] = '";
            commandText += commonAssets.Name;
            commandText += "',";

            commandText += "[Дата оплаты объекта] = '";
            commandText += commonAssets.BillingDate;
            commandText += "',";

            commandText += "[Дата подачи документов] = '";
            commandText += commonAssets.DocumentsDate;
            commandText += "',";

            commandText += "[Дата ввода в эксплуатацию] = '";
            commandText += commonAssets.ExpluatationDate;
            commandText += "',";

            commandText += "[Первоначальная стоимость объекта] = '";
            commandText += commonAssets.InitialCost;
            commandText += "',";

            commandText += "[Срок полезного использования объекта] = '";
            commandText += commonAssets.ObjectsUsefulLife;
            commandText += "',";

            commandText += "[Остаточная стоимость объекта] = '";
            commandText += commonAssets.ObjectsResidualValue;
            commandText += "',";

            commandText += "[Количества полугодий эксплуатации объекта] = '";
            commandText += commonAssets.NumberOfSemesters;
            commandText += "',";

            commandText += "[Доля стоимости объекта  за налоговый объект] = '";
            commandText += commonAssets.ObjectsProportionOfValue;
            commandText += "',";

            commandText += "[Включено в расходы] = '";
            commandText += commonAssets.IncludedInCosts;
            commandText += "',";

            if (commonAssets.DisposalDate != "")
            {
                commandText += "[Дата выбытия] = '";
                commandText += commonAssets.DisposalDate;
                commandText += "'";
            }
            else
            {
                commandText += "[Дата выбытия] = ";
                commandText += "NULL";
                commandText += "";
            }

            commandText += " WHERE [№ п/п] = ";

            commandText += commonAssets.GetInternalIndex();

            commandText += ";";

            myOleDbCommand.CommandText = commandText;

            myOleDbConnection.Open();

            myOleDbCommand.ExecuteScalar();

            myOleDbConnection.Close();
        }
    }
}