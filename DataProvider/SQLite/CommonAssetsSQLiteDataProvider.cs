using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class CommonAssetsSQLiteDataProvider
    {
        public void ImportCommonAssets(List<CommonAssets> commonAssets, string INN)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();
            foreach (var item in commonAssets)
            {
                StringBuilder commandText = new StringBuilder();
                commandText.Append("INSERT INTO [ОсновныеСредства] (ИНН, Наименование, ДатаОплаты, ПервоначальнаяСтоимостьОбъекта, СрокПолезногоИспользованияОбъекта,");
                commandText.Append("ОстаточнаяСтоимостьОбъекта, КоличествоПолугодийЭксплуатацииОбъекта, ДоляСтоимостиОбъектаЗаНалоговыйПериод,");
                commandText.Append("ВключеноВРасходы, ДатаВыбытия, ДатаПодачиДокументов, ДатаВводаВЭксплуатацию)");
                commandText.Append("VALUES(");

                DataProvider.AddCommandTextInsert(commandText, INN);
                DataProvider.AddCommandTextInsert(commandText, item.Name);
                DataProvider.AddCommandTextInsert(commandText, DataProvider.ConvertDateToSQLiteFormat(item.BillingDate));
                DataProvider.AddCommandTextInsert(commandText, item.InitialCost);
                DataProvider.AddCommandTextInsert(commandText, item.ObjectsUsefulLife);
                DataProvider.AddCommandTextInsert(commandText, item.ObjectsResidualValue);
                DataProvider.AddCommandTextInsert(commandText, item.NumberOfSemesters);
                DataProvider.AddCommandTextInsert(commandText, item.ObjectsProportionOfValue);
                DataProvider.AddCommandTextInsert(commandText, item.IncludedInCosts);
                DataProvider.AddCommandTextInsert(commandText, DataProvider.ConvertDateToSQLiteFormat(item.DisposalDate));
                DataProvider.AddCommandTextInsert(commandText, DataProvider.ConvertDateToSQLiteFormat(item.DocumentsDate));
                DataProvider.AddCommandTextInsert(commandText, DataProvider.ConvertDateToSQLiteFormat(item.ExpluatationDate), last: true);
                commandText.Append(");");

                sqlite_cmd.CommandText = commandText.ToString();
                sqlite_cmd.ExecuteNonQuery();
            }
            sqlite_conn.Close();
        }

        public List<CommonAssets> Load(string INN)
        {
            List<CommonAssets> commonAssets = new List<CommonAssets>();

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("SELECT Индекс, Наименование, ДатаОплаты, ПервоначальнаяСтоимостьОбъекта, СрокПолезногоИспользованияОбъекта, ");
            commandText.Append("ОстаточнаяСтоимостьОбъекта, КоличествоПолугодийЭксплуатацииОбъекта, КоличествоПолугодийЭксплуатацииОбъекта, ДатаВводаВЭксплуатацию,");
            commandText.Append("ДоляСтоимостиОбъектаЗаНалоговыйПериод, ВключеноВРасходы, ДатаВыбытия, ДатаПодачиДокументов FROM [ОсновныеСредства] ");
            commandText.Append("WHERE ИНН=" + INN);

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                CommonAssets temporaryCommonAssets = new CommonAssets();
                string internalIndex = sqlite_datareader["Индекс"].ToString();
                temporaryCommonAssets.SetInternalIndex(internalIndex);

                string billingDate = sqlite_datareader["ДатаОплаты"].ToString();
                string disposalDate = sqlite_datareader["ДатаВыбытия"].ToString();
                string documentsDate = sqlite_datareader["ДатаПодачиДокументов"].ToString();
                string expluatationDate = sqlite_datareader["ДатаВводаВЭксплуатацию"].ToString();

                temporaryCommonAssets.BillingDate = DataProvider.ConvertDateThatCantBeEmpty(billingDate);
                temporaryCommonAssets.DisposalDate = DataProvider.ConvertDateThatCantBeEmpty(disposalDate);
                temporaryCommonAssets.DocumentsDate = DataProvider.ConvertDateThatCantBeEmpty(documentsDate);
                temporaryCommonAssets.ExpluatationDate = DataProvider.ConvertDateThatCantBeEmpty(expluatationDate);

                temporaryCommonAssets.IncludedInCosts = sqlite_datareader["ВключеноВРасходы"].ToString();
                temporaryCommonAssets.InitialCost = sqlite_datareader["ПервоначальнаяСтоимостьОбъекта"].ToString();
                temporaryCommonAssets.Name = sqlite_datareader["Наименование"].ToString();
                temporaryCommonAssets.NumberOfSemesters = sqlite_datareader["КоличествоПолугодийЭксплуатацииОбъекта"].ToString();
                temporaryCommonAssets.ObjectsProportionOfValue = sqlite_datareader["ДоляСтоимостиОбъектаЗаНалоговыйПериод"].ToString();
                temporaryCommonAssets.ObjectsResidualValue = sqlite_datareader["ОстаточнаяСтоимостьОбъекта"].ToString();
                temporaryCommonAssets.ObjectsUsefulLife = sqlite_datareader["СрокПолезногоИспользованияОбъекта"].ToString();

                commonAssets.Add(temporaryCommonAssets);
            }

            sqlite_conn.Close();
            return commonAssets;
        }

        public void Delete(string internalIndex)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();
            commandText.Append("DELETE FROM ОсновныеСредства WHERE [Индекс]=");
            DataProvider.AddCommandTextDelete(commandText, internalIndex);

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteScalar();
            sqlite_conn.Close();
        }

        public void Insert(CommonAssets commonAssets, string INN)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();
            commandText.Append("INSERT INTO [ОсновныеСредства] (ИНН, Наименование, ДатаОплаты, ПервоначальнаяСтоимостьОбъекта, СрокПолезногоИспользованияОбъекта,");
            commandText.Append("ОстаточнаяСтоимостьОбъекта, КоличествоПолугодийЭксплуатацииОбъекта, ДоляСтоимостиОбъектаЗаНалоговыйПериод,");
            commandText.Append("ВключеноВРасходы, ДатаВыбытия, ДатаПодачиДокументов, ДатаВводаВЭксплуатацию)");
            commandText.Append("VALUES(");

            DataProvider.AddCommandTextInsert(commandText, INN);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.Name);
            DataProvider.AddCommandTextInsert(commandText, DataProvider.ConvertDateToSQLiteFormat(commonAssets.BillingDate));
            DataProvider.AddCommandTextInsert(commandText, commonAssets.InitialCost);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.ObjectsUsefulLife);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.ObjectsResidualValue);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.NumberOfSemesters);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.ObjectsProportionOfValue);
            DataProvider.AddCommandTextInsert(commandText, commonAssets.IncludedInCosts);
            DataProvider.AddCommandTextInsert(commandText, DataProvider.ConvertDateToSQLiteFormat(commonAssets.DisposalDate));
            DataProvider.AddCommandTextInsert(commandText, DataProvider.ConvertDateToSQLiteFormat(commonAssets.DocumentsDate));
            DataProvider.AddCommandTextInsert(commandText, DataProvider.ConvertDateToSQLiteFormat(commonAssets.ExpluatationDate), last: true);
            commandText.Append(");");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

        public void Update(CommonAssets commonAssets)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("UPDATE ОсновныеСредства SET ");

            DataProvider.AddCommandTextUpdate(commandText, "Наименование", commonAssets.Name);
            DataProvider.AddCommandTextUpdate(commandText, "ДатаОплаты", DataProvider.ConvertDateToSQLiteFormat(commonAssets.BillingDate));
            DataProvider.AddCommandTextUpdate(commandText, "ПервоначальнаяСтоимостьОбъекта", commonAssets.InitialCost);
            DataProvider.AddCommandTextUpdate(commandText, "СрокПолезногоИспользованияОбъекта", commonAssets.ObjectsUsefulLife);
            DataProvider.AddCommandTextUpdate(commandText, "ОстаточнаяСтоимостьОбъекта", commonAssets.ObjectsResidualValue);
            DataProvider.AddCommandTextUpdate(commandText, "КоличествоПолугодийЭксплуатацииОбъекта", commonAssets.NumberOfSemesters);
            DataProvider.AddCommandTextUpdate(commandText, "ДоляСтоимостиОбъектаЗаНалоговыйПериод", commonAssets.ObjectsProportionOfValue);
            DataProvider.AddCommandTextUpdate(commandText, "ВключеноВРасходы", commonAssets.IncludedInCosts);
            DataProvider.AddCommandTextUpdate(commandText, "ДатаВыбытия", DataProvider.ConvertDateToSQLiteFormat(commonAssets.DisposalDate));
            DataProvider.AddCommandTextUpdate(commandText, "ДатаПодачиДокументов", DataProvider.ConvertDateToSQLiteFormat(commonAssets.DocumentsDate));
            DataProvider.AddCommandTextUpdate(commandText, "ДатаВводаВЭксплуатацию", DataProvider.ConvertDateToSQLiteFormat(commonAssets.ExpluatationDate), last: true);

            commandText.Append(" WHERE Индекс = " + commonAssets.GetInternalIndex() + ";");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }
    }
}