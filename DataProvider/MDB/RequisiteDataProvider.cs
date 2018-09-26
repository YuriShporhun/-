using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace AccountingForAgriculturalTax
{
    public class RequisiteDataProvider
    {
        string dataBasePath;
        string connectionString;

        public RequisiteDataProvider()
        {
            this.dataBasePath = Constants.dataBaseFullPath;
            connectionString = "provider=Microsoft.Jet.OLEDB.4.0; data source=" + dataBasePath;
        }

        public void SetINN(string INN)
        {
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            StringBuilder commandText = new StringBuilder();
            commandText.Append("UPDATE реквизиты SET ");

            DataProvider.AddCommandTextUpdate(commandText, "ИНН", INN, last: true);

            commandText.Append(" WHERE Счетчик = 2;");
            myOleDbCommand.CommandText = commandText.ToString();
            myOleDbConnection.Open();
            myOleDbCommand.ExecuteScalar();
            myOleDbConnection.Close();
        }

        public Requisite LoadRequsite()
        {
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            myOleDbCommand.CommandText = "SELECT * FROM реквизиты WHERE Счетчик=2";

            myOleDbConnection.Open();
            OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader();
            myOleDbDataReader.Read();

            Requisite requisite = new Requisite();

            Налогоплательщик налогоплательщик = new Налогоплательщик();

            налогоплательщик.ДатаРождения = myOleDbDataReader["Дата"].ToString();
            налогоплательщик.ИНН = myOleDbDataReader["ИНН"].ToString();
            налогоплательщик.МестоЖительства = myOleDbDataReader["Место жительства"].ToString();
            налогоплательщик.Телефон = myOleDbDataReader["Тел"].ToString();
            налогоплательщик.Фамилия = myOleDbDataReader["ФИО"].ToString();
            налогоплательщик.ФормаПоОКУД = myOleDbDataReader["форма по ОКУД"].ToString();

            УполномоченныйПредставитель уполномоченныйПредставитель = new УполномоченныйПредставитель();

            уполномоченныйПредставитель.Дов = myOleDbDataReader["Дов"].ToString();
            уполномоченныйПредставитель.Имя = myOleDbDataReader["Имя"].ToString();
            уполномоченныйПредставитель.ИНН = myOleDbDataReader["ИНН2"].ToString();
            уполномоченныйПредставитель.Отчество = myOleDbDataReader["Отчество"].ToString();
            уполномоченныйПредставитель.Телефон = myOleDbDataReader["Телефон"].ToString();
            уполномоченныйПредставитель.Фамилия = myOleDbDataReader["Фамилия"].ToString();

            СвидетельствоОВнесении свидетельствоОВнесении = new СвидетельствоОВнесении();

            свидетельствоОВнесении.Дата = myOleDbDataReader["дата2"].ToString();
            свидетельствоОВнесении.ДатаИсключенияИзРеестра = myOleDbDataReader["дата исключения из реестра"].ToString();
            свидетельствоОВнесении.Номер = myOleDbDataReader["№"].ToString();
            свидетельствоОВнесении.ОГРН = myOleDbDataReader["ОГРН"].ToString();
            свидетельствоОВнесении.РегОрган = myOleDbDataReader["регорган"].ToString();

            СвидетельствоОПостановке свидетельствоОПостановке = new СвидетельствоОПостановке();

            свидетельствоОПостановке.Дата = myOleDbDataReader["Дата3"].ToString();
            свидетельствоОПостановке.ИНН = myOleDbDataReader["ИНН6"].ToString();
            свидетельствоОПостановке.НалОрган= myOleDbDataReader["налорган"].ToString();
            свидетельствоОПостановке.Номер = myOleDbDataReader["№2"].ToString();

            РегистрацияВФондах регистрацияВФондах = new РегистрацияВФондах();

            регистрацияВФондах.СНИЛС = myOleDbDataReader["СНИЛС"].ToString();
            регистрацияВФондах.РегОМС = myOleDbDataReader["РегНомОМС"].ToString();
            регистрацияВФондах.РегПФР = myOleDbDataReader["РегНомПРФ"].ToString();

            Коды коды = new Коды();

            коды.ОКАТО = myOleDbDataReader["ОКАТО"].ToString();
            коды.ОКВЭД = myOleDbDataReader["ОКВЭД"].ToString();
            коды.ОКОГУ = myOleDbDataReader["ОКОГУ"].ToString();
            коды.ОКОПФ = myOleDbDataReader["ОКОПФ"].ToString();
            коды.ОКПО = myOleDbDataReader["ОКПО"].ToString();
            коды.ОКФС = myOleDbDataReader["ОКФС"].ToString();

            АдминистраторНалоговыхПлатежей администраторНалоговыхПлатежей = new АдминистраторНалоговыхПлатежей();

            администраторНалоговыхПлатежей.ИНН = myOleDbDataReader["ИНН4"].ToString();
            администраторНалоговыхПлатежей.Адрес = myOleDbDataReader["адрес"].ToString();
            администраторНалоговыхПлатежей.ИнспекцияФНС = myOleDbDataReader["инспекция ФНС"].ToString();
            администраторНалоговыхПлатежей.КПП = myOleDbDataReader["КПП"].ToString();

            АдминистраторСтраховыхВзносов администраторСтраховыхВзносов = new АдминистраторСтраховыхВзносов();

            администраторСтраховыхВзносов.Адрес = myOleDbDataReader["адрес2"].ToString();
            администраторСтраховыхВзносов.ИНН = myOleDbDataReader["ИНН5"].ToString();
            администраторСтраховыхВзносов.КПП = myOleDbDataReader["КПП2"].ToString();
            администраторСтраховыхВзносов.ОПРФ = myOleDbDataReader["ОПФР"].ToString();
            администраторСтраховыхВзносов.УПРФ = myOleDbDataReader["УПФР"].ToString();

            ЕКС екс = new ЕКС();

            екс.Банк = myOleDbDataReader["Банк"].ToString();
            екс.БИК = myOleDbDataReader["БИК"].ToString();
            екс.Получатель = myOleDbDataReader["получатель"].ToString();
            екс.Расчетныйсчет = myOleDbDataReader["РСЧ"].ToString();

            УведомлениеОВозможностиПрименения уведомлениеОВозможностиПрименения = new УведомлениеОВозможностиПрименения();

            уведомлениеОВозможностиПрименения.Выдано = myOleDbDataReader["выдано"].ToString();
            уведомлениеОВозможностиПрименения.Дата = myOleDbDataReader["дата4"].ToString();
            уведомлениеОВозможностиПрименения.Номер = myOleDbDataReader["Номер"].ToString();
            уведомлениеОВозможностиПрименения.ПримС = myOleDbDataReader["примс"].ToString();

            requisite.налогоплательщик = налогоплательщик;
            requisite.уполномоченныйПредставитель = уполномоченныйПредставитель;
            requisite.свидетельствоОВнесении = свидетельствоОВнесении;
            requisite.свидетельствоОПостановке = свидетельствоОПостановке;
            requisite.регистрацияВФондах = регистрацияВФондах;
            requisite.коды = коды;
            requisite.администраторНалоговыхПлатежей = администраторНалоговыхПлатежей;
            requisite.администраторСтраховыхВзносов = администраторСтраховыхВзносов;
            requisite.екс = екс;
            requisite.уведомлениеОВозможностиПрименения = уведомлениеОВозможностиПрименения;
            
            myOleDbDataReader.Close();
            myOleDbConnection.Close();
            return requisite;
        }

        public void SaveRequisite(Requisite requisite)
        {
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();

            StringBuilder commandText = new StringBuilder();
            commandText.Append("UPDATE реквизиты SET ");

            Налогоплательщик налогоплательщик = requisite.налогоплательщик;

            DataProvider.AddCommandTextUpdate(commandText, "Дата", налогоплательщик.ДатаРождения);
            DataProvider.AddCommandTextUpdate(commandText, "ИНН", налогоплательщик.ИНН);
            DataProvider.AddCommandTextUpdate(commandText, "Место жительства", налогоплательщик.МестоЖительства);
            DataProvider.AddCommandTextUpdate(commandText, "Тел", налогоплательщик.Телефон);
            DataProvider.AddCommandTextUpdate(commandText, "ФИО", налогоплательщик.Фамилия);
            DataProvider.AddCommandTextUpdate(commandText, "форма по ОКУД", налогоплательщик.ФормаПоОКУД);

            УполномоченныйПредставитель уполномоченныйПредставитель = requisite.уполномоченныйПредставитель;

            DataProvider.AddCommandTextUpdate(commandText, "Дов", уполномоченныйПредставитель.Дов);
            DataProvider.AddCommandTextUpdate(commandText, "Имя", уполномоченныйПредставитель.Имя);
            DataProvider.AddCommandTextUpdate(commandText, "ИНН2", уполномоченныйПредставитель.ИНН);
            DataProvider.AddCommandTextUpdate(commandText, "Отчество", уполномоченныйПредставитель.Отчество);
            DataProvider.AddCommandTextUpdate(commandText, "Телефон", уполномоченныйПредставитель.Телефон);
            DataProvider.AddCommandTextUpdate(commandText, "Фамилия", уполномоченныйПредставитель.Фамилия);

            СвидетельствоОВнесении свидетельствоОВнесении = requisite.свидетельствоОВнесении;

            DataProvider.AddCommandTextUpdate(commandText, "дата2", свидетельствоОВнесении.Дата);
            DataProvider.AddCommandTextUpdate(commandText, "дата исключения из реестра", свидетельствоОВнесении.ДатаИсключенияИзРеестра);
            DataProvider.AddCommandTextUpdate(commandText, "№", свидетельствоОВнесении.Номер);
            DataProvider.AddCommandTextUpdate(commandText, "ОГРН", свидетельствоОВнесении.ОГРН);
            DataProvider.AddCommandTextUpdate(commandText, "регорган", свидетельствоОВнесении.РегОрган);

            СвидетельствоОПостановке свидетельствоОПостановке = requisite.свидетельствоОПостановке;

            DataProvider.AddCommandTextUpdate(commandText, "Дата3", свидетельствоОПостановке.Дата);
            DataProvider.AddCommandTextUpdate(commandText, "ИНН6", свидетельствоОПостановке.ИНН);
            DataProvider.AddCommandTextUpdate(commandText, "налорган", свидетельствоОПостановке.НалОрган);
            DataProvider.AddCommandTextUpdate(commandText, "№2", свидетельствоОПостановке.Номер);

            РегистрацияВФондах регистрацияВФондах = requisite.регистрацияВФондах;

            DataProvider.AddCommandTextUpdate(commandText, "СНИЛС", регистрацияВФондах.СНИЛС);
            DataProvider.AddCommandTextUpdate(commandText, "РегНомОМС", регистрацияВФондах.РегОМС);
            DataProvider.AddCommandTextUpdate(commandText, "РегНомПРФ", регистрацияВФондах.РегПФР);

            Коды коды = requisite.коды;

            DataProvider.AddCommandTextUpdate(commandText, "ОКАТО", коды.ОКАТО);
            DataProvider.AddCommandTextUpdate(commandText, "ОКВЭД", коды.ОКВЭД);
            DataProvider.AddCommandTextUpdate(commandText, "ОКОГУ", коды.ОКОГУ);
            DataProvider.AddCommandTextUpdate(commandText, "ОКОПФ", коды.ОКОПФ);
            DataProvider.AddCommandTextUpdate(commandText, "ОКПО", коды.ОКПО);
            DataProvider.AddCommandTextUpdate(commandText, "ОКФС", коды.ОКФС);

            АдминистраторНалоговыхПлатежей администраторНалоговыхПлатежей = requisite.администраторНалоговыхПлатежей;

            DataProvider.AddCommandTextUpdate(commandText, "ИНН4", администраторНалоговыхПлатежей.ИНН);
            DataProvider.AddCommandTextUpdate(commandText, "адрес", администраторНалоговыхПлатежей.Адрес);
            DataProvider.AddCommandTextUpdate(commandText, "инспекция ФНС", администраторНалоговыхПлатежей.ИнспекцияФНС);
            DataProvider.AddCommandTextUpdate(commandText, "КПП", администраторНалоговыхПлатежей.КПП);

            АдминистраторСтраховыхВзносов администраторСтраховыхВзносов = requisite.администраторСтраховыхВзносов;

            DataProvider.AddCommandTextUpdate(commandText, "адрес2", администраторСтраховыхВзносов.Адрес);
            DataProvider.AddCommandTextUpdate(commandText, "ИНН5", администраторСтраховыхВзносов.ИНН);
            DataProvider.AddCommandTextUpdate(commandText, "КПП2", администраторСтраховыхВзносов.КПП);
            DataProvider.AddCommandTextUpdate(commandText, "ОПФР", администраторСтраховыхВзносов.ОПРФ);
            DataProvider.AddCommandTextUpdate(commandText, "УПФР", администраторСтраховыхВзносов.УПРФ);

            ЕКС екс = requisite.екс;

            DataProvider.AddCommandTextUpdate(commandText, "Банк", екс.Банк);
            DataProvider.AddCommandTextUpdate(commandText, "БИК", екс.БИК);
            DataProvider.AddCommandTextUpdate(commandText, "получатель", екс.Получатель);
            DataProvider.AddCommandTextUpdate(commandText, "РСЧ", екс.Расчетныйсчет);

            УведомлениеОВозможностиПрименения уведомлениеОВозможностиПрименения = requisite.уведомлениеОВозможностиПрименения;

            DataProvider.AddCommandTextUpdate(commandText, "выдано", уведомлениеОВозможностиПрименения.Выдано);
            DataProvider.AddCommandTextUpdate(commandText, "дата4", уведомлениеОВозможностиПрименения.Дата);
            DataProvider.AddCommandTextUpdate(commandText, "Номер", уведомлениеОВозможностиПрименения.Номер);
            DataProvider.AddCommandTextUpdate(commandText, "примс", уведомлениеОВозможностиПрименения.ПримС, last: true);

            commandText.Append(" WHERE Счетчик = 2;");

            myOleDbCommand.CommandText = commandText.ToString();
            myOleDbConnection.Open();
            myOleDbCommand.ExecuteScalar();
            myOleDbConnection.Close();
        }
    }
}
