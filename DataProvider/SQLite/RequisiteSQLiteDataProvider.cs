using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class RequisiteSQLiteDataProvider
    {
        public void ImportRequisite(Requisite requisite)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("INSERT INTO [Реквизиты] (");
            commandText.Append("НалогоплательщикДатаРождения, НалогоплательщикИНН, НалогоплательщикМестоЖительства, НалогоплательщикТелефон, НалогоплательщикФамилия, НалогоплательщикФормаПоОКУД,");
            commandText.Append("ПредставительДоверенность, ПредставительИмя, ПредставительИНН, ПредставительОтчество, ПредставительТелефон, ПредставительФамилия,");
            commandText.Append("СвидетельствоОВнесенииДата, СвидетельствоОВнесенииДатаИсключения, СвидетельствоОВнесенииНомер, СвидетельствоОВнесенииОГРН, СвидетельствоОВнесенииРегОрган,");
            commandText.Append("СвидетельствоОПостановкеДата, СвидетельствоОПостановкеИНН, СвидетельствоОПостановкеНалОрган, СвидетельствоОПостановкеНомер,");
            commandText.Append("РегистрацияВФондахСНИЛС, РегистрацияВФондахОМС, РегистрацияВФондахПФР,"); 
            commandText.Append("КодыОКАТО, КодыОКВЭД, КодыОКОГУ, КодыОКОПФ, КодыОКПО, КодыОКФС,");
            commandText.Append("АдминистраторНалоговыхПлатежейИНН, АдминистраторНалоговыхПлатежейАдрес, АдминистраторНалоговыхПлатежейИнспекцияФНС, АдминистраторНалоговыхПлатежейКПП,");
            commandText.Append("АдминистраторСтраховыхВзносовАдрес, АдминистраторСтраховыхВзносовИНН, АдминистраторСтраховыхВзносовКПП, АдминистраторСтраховыхВзносовОПФР, АдминистраторСтраховыхВзносовУПФР,");
            commandText.Append("ЕКСБанк, ЕКСБИК, ЕКСПолучатель, ЕКСРасчетныйСчет,");
            commandText.Append("УведомлениеВыдано, УведомлениеДата, УведомлениеНомер, УведомлениеДатаПримС");
            commandText.Append(")VALUES(");

            Налогоплательщик налогоплательщик = requisite.налогоплательщик;

            DataProvider.AddCommandTextInsert(commandText, налогоплательщик.ДатаРождения);
            DataProvider.AddCommandTextInsert(commandText, налогоплательщик.ИНН);
            DataProvider.AddCommandTextInsert(commandText, налогоплательщик.МестоЖительства);
            DataProvider.AddCommandTextInsert(commandText, налогоплательщик.Телефон);
            DataProvider.AddCommandTextInsert(commandText, налогоплательщик.Фамилия);
            DataProvider.AddCommandTextInsert(commandText, налогоплательщик.ФормаПоОКУД);

            УполномоченныйПредставитель уполномоченныйПредставитель = requisite.уполномоченныйПредставитель;

            DataProvider.AddCommandTextInsert(commandText, уполномоченныйПредставитель.Дов);
            DataProvider.AddCommandTextInsert(commandText, уполномоченныйПредставитель.Имя);
            DataProvider.AddCommandTextInsert(commandText, уполномоченныйПредставитель.ИНН);
            DataProvider.AddCommandTextInsert(commandText, уполномоченныйПредставитель.Отчество);
            DataProvider.AddCommandTextInsert(commandText, уполномоченныйПредставитель.Телефон);
            DataProvider.AddCommandTextInsert(commandText, уполномоченныйПредставитель.Фамилия);

            СвидетельствоОВнесении свидетельствоОВнесении = requisite.свидетельствоОВнесении;

            DataProvider.AddCommandTextInsert(commandText, свидетельствоОВнесении.Дата);
            DataProvider.AddCommandTextInsert(commandText, свидетельствоОВнесении.ДатаИсключенияИзРеестра);
            DataProvider.AddCommandTextInsert(commandText, свидетельствоОВнесении.Номер);
            DataProvider.AddCommandTextInsert(commandText, свидетельствоОВнесении.ОГРН);
            DataProvider.AddCommandTextInsert(commandText, свидетельствоОВнесении.РегОрган);

            СвидетельствоОПостановке свидетельствоОПостановке = requisite.свидетельствоОПостановке;

            DataProvider.AddCommandTextInsert(commandText, свидетельствоОПостановке.Дата);
            DataProvider.AddCommandTextInsert(commandText, свидетельствоОПостановке.ИНН);
            DataProvider.AddCommandTextInsert(commandText, свидетельствоОПостановке.НалОрган);
            DataProvider.AddCommandTextInsert(commandText, свидетельствоОПостановке.Номер);

            РегистрацияВФондах регистрацияВФондах = requisite.регистрацияВФондах;

            DataProvider.AddCommandTextInsert(commandText, регистрацияВФондах.СНИЛС);
            DataProvider.AddCommandTextInsert(commandText, регистрацияВФондах.РегОМС);
            DataProvider.AddCommandTextInsert(commandText, регистрацияВФондах.РегПФР);

            Коды коды = requisite.коды;

            DataProvider.AddCommandTextInsert(commandText, коды.ОКАТО);
            DataProvider.AddCommandTextInsert(commandText, коды.ОКВЭД);
            DataProvider.AddCommandTextInsert(commandText, коды.ОКОГУ);
            DataProvider.AddCommandTextInsert(commandText, коды.ОКОПФ);
            DataProvider.AddCommandTextInsert(commandText, коды.ОКПО);
            DataProvider.AddCommandTextInsert(commandText, коды.ОКФС);

            АдминистраторНалоговыхПлатежей администраторНалоговыхПлатежей = requisite.администраторНалоговыхПлатежей;

            DataProvider.AddCommandTextInsert(commandText, администраторНалоговыхПлатежей.ИНН);
            DataProvider.AddCommandTextInsert(commandText, администраторНалоговыхПлатежей.Адрес);
            DataProvider.AddCommandTextInsert(commandText, администраторНалоговыхПлатежей.ИнспекцияФНС);
            DataProvider.AddCommandTextInsert(commandText, администраторНалоговыхПлатежей.КПП);

            АдминистраторСтраховыхВзносов администраторСтраховыхВзносов = requisite.администраторСтраховыхВзносов;

            DataProvider.AddCommandTextInsert(commandText, администраторСтраховыхВзносов.Адрес);
            DataProvider.AddCommandTextInsert(commandText, администраторСтраховыхВзносов.ИНН);
            DataProvider.AddCommandTextInsert(commandText, администраторСтраховыхВзносов.КПП);
            DataProvider.AddCommandTextInsert(commandText, администраторСтраховыхВзносов.ОПРФ);
            DataProvider.AddCommandTextInsert(commandText, администраторСтраховыхВзносов.УПРФ);

            ЕКС екс = requisite.екс;

            DataProvider.AddCommandTextInsert(commandText, екс.Банк);
            DataProvider.AddCommandTextInsert(commandText, екс.БИК);
            DataProvider.AddCommandTextInsert(commandText, екс.Получатель);
            DataProvider.AddCommandTextInsert(commandText, екс.Расчетныйсчет);

            УведомлениеОВозможностиПрименения уведомлениеОВозможностиПрименения = requisite.уведомлениеОВозможностиПрименения;

            DataProvider.AddCommandTextInsert(commandText, уведомлениеОВозможностиПрименения.Выдано);
            DataProvider.AddCommandTextInsert(commandText, уведомлениеОВозможностиПрименения.Дата);
            DataProvider.AddCommandTextInsert(commandText, уведомлениеОВозможностиПрименения.Номер);
            DataProvider.AddCommandTextInsert(commandText, уведомлениеОВозможностиПрименения.ПримС, last: true);

            commandText.Append(");");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

        public Requisite Load(string INN)
        {
            Requisite requisite = new Requisite();

            if (INN == String.Empty)
            {
                throw new BlankIdentifierNumberException();
            }

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("SELECT * FROM Реквизиты WHERE НалогоплательщикИНН = '" + INN + "'");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                Налогоплательщик налогоплательщик = new Налогоплательщик();
                налогоплательщик.ДатаРождения = sqlite_datareader["НалогоплательщикДатаРождения"].ToString();
                налогоплательщик.ФормаСобственности = sqlite_datareader["НалогоплательщикФормаСобственности"].ToString();
                налогоплательщик.ИНН = sqlite_datareader["НалогоплательщикИНН"].ToString();
                налогоплательщик.КПП = sqlite_datareader["НалогоплательщикКПП"].ToString();
                налогоплательщик.МестоЖительства = sqlite_datareader["НалогоплательщикМестоЖительства"].ToString();
                налогоплательщик.Телефон = sqlite_datareader["НалогоплательщикТелефон"].ToString();
                налогоплательщик.Фамилия = sqlite_datareader["НалогоплательщикФамилия"].ToString();
                налогоплательщик.Имя = sqlite_datareader["НалогоплательщикИмя"].ToString();
                налогоплательщик.Отчество = sqlite_datareader["НалогоплательщикОтчество"].ToString();
                налогоплательщик.ФормаПоОКУД = sqlite_datareader["НалогоплательщикФормаПоОКУД"].ToString();
                налогоплательщик.ИмяОрганизации = sqlite_datareader["НалогоплательщикИмяОрганизации"].ToString();
                requisite.налогоплательщик = налогоплательщик;

                УполномоченныйПредставитель уполномоченныйПредставитель = new УполномоченныйПредставитель();
                уполномоченныйПредставитель.Дов = sqlite_datareader["ПредставительДоверенность"].ToString();
                уполномоченныйПредставитель.Имя = sqlite_datareader["ПредставительИмя"].ToString();
                уполномоченныйПредставитель.ИНН = sqlite_datareader["ПредставительИНН"].ToString();
                уполномоченныйПредставитель.Отчество = sqlite_datareader["ПредставительОтчество"].ToString();
                уполномоченныйПредставитель.Телефон = sqlite_datareader["ПредставительТелефон"].ToString();
                уполномоченныйПредставитель.Фамилия = sqlite_datareader["ПредставительФамилия"].ToString();
                уполномоченныйПредставитель.ИмяОрганизации = sqlite_datareader["ПредставительИмяОрганизации"].ToString();
                requisite.уполномоченныйПредставитель = уполномоченныйПредставитель;

                СвидетельствоОВнесении свидетельствоОВнесении = new СвидетельствоОВнесении();
                свидетельствоОВнесении.Дата = sqlite_datareader["СвидетельствоОВнесенииДата"].ToString();
                свидетельствоОВнесении.ДатаИсключенияИзРеестра = sqlite_datareader["СвидетельствоОВнесенииДатаИсключения"].ToString();
                свидетельствоОВнесении.Номер = sqlite_datareader["СвидетельствоОВнесенииНомер"].ToString();
                свидетельствоОВнесении.ОГРН = sqlite_datareader["СвидетельствоОВнесенииОГРН"].ToString();
                свидетельствоОВнесении.РегОрган = sqlite_datareader["СвидетельствоОВнесенииРегОрган"].ToString();
                requisite.свидетельствоОВнесении = свидетельствоОВнесении;

                СвидетельствоОПостановке свидетельствоОПостановке = new СвидетельствоОПостановке();
                свидетельствоОПостановке.Дата = sqlite_datareader["СвидетельствоОПостановкеДата"].ToString();
                свидетельствоОПостановке.ИНН = sqlite_datareader["СвидетельствоОПостановкеИНН"].ToString();
                свидетельствоОПостановке.НалОрган = sqlite_datareader["СвидетельствоОПостановкеНалОрган"].ToString();
                свидетельствоОПостановке.Номер = sqlite_datareader["СвидетельствоОПостановкеНомер"].ToString();
                requisite.свидетельствоОПостановке = свидетельствоОПостановке;

                РегистрацияВФондах регистрацияВФондах = new РегистрацияВФондах();
                регистрацияВФондах.СНИЛС = sqlite_datareader["РегистрацияВФондахСНИЛС"].ToString();
                регистрацияВФондах.РегОМС = sqlite_datareader["РегистрацияВФондахОМС"].ToString();
                регистрацияВФондах.РегПФР = sqlite_datareader["РегистрацияВФондахПФР"].ToString();
                requisite.регистрацияВФондах = регистрацияВФондах;

                Коды коды = new Коды();
                коды.ОКАТО = sqlite_datareader["КодыОКАТО"].ToString();
                коды.ОКВЭД = sqlite_datareader["КодыОКВЭД"].ToString();
                коды.ОКОГУ = sqlite_datareader["КодыОКОГУ"].ToString();
                коды.ОКОПФ = sqlite_datareader["КодыОКОПФ"].ToString();
                коды.ОКПО = sqlite_datareader["КодыОКПО"].ToString();
                коды.ОКФС = sqlite_datareader["КодыОКФС"].ToString();
                requisite.коды = коды;

                АдминистраторНалоговыхПлатежей администраторНалоговыхПлатежей = new АдминистраторНалоговыхПлатежей();
                администраторНалоговыхПлатежей.ИНН = sqlite_datareader["АдминистраторНалоговыхПлатежейИНН"].ToString();
                администраторНалоговыхПлатежей.Адрес = sqlite_datareader["АдминистраторНалоговыхПлатежейАдрес"].ToString();
                администраторНалоговыхПлатежей.ИнспекцияФНС = sqlite_datareader["АдминистраторНалоговыхПлатежейИнспекцияФНС"].ToString();
                администраторНалоговыхПлатежей.КПП = sqlite_datareader["АдминистраторНалоговыхПлатежейКПП"].ToString();
                requisite.администраторНалоговыхПлатежей = администраторНалоговыхПлатежей;

                АдминистраторСтраховыхВзносов администраторСтраховыхВзносов = new АдминистраторСтраховыхВзносов();
                администраторСтраховыхВзносов.Адрес = sqlite_datareader["АдминистраторСтраховыхВзносовАдрес"].ToString();
                администраторСтраховыхВзносов.ИНН = sqlite_datareader["АдминистраторСтраховыхВзносовИНН"].ToString();
                администраторСтраховыхВзносов.КПП = sqlite_datareader["АдминистраторСтраховыхВзносовКПП"].ToString();
                администраторСтраховыхВзносов.ОПРФ = sqlite_datareader["АдминистраторСтраховыхВзносовОПФР"].ToString();
                администраторСтраховыхВзносов.УПРФ = sqlite_datareader["АдминистраторСтраховыхВзносовУПФР"].ToString();
                requisite.администраторСтраховыхВзносов = администраторСтраховыхВзносов;

                ЕКС екс = new ЕКС();
                екс.Банк = sqlite_datareader["ЕКСБанк"].ToString();
                екс.БИК = sqlite_datareader["ЕКСБИК"].ToString();
                екс.Получатель = sqlite_datareader["ЕКСПолучатель"].ToString();
                екс.Расчетныйсчет = sqlite_datareader["ЕКСРасчетныйСчет"].ToString();
                requisite.екс = екс;

                УведомлениеОВозможностиПрименения уведомлениеОВозможностиПрименения = new УведомлениеОВозможностиПрименения();
                уведомлениеОВозможностиПрименения.Выдано = sqlite_datareader["УведомлениеВыдано"].ToString();
                уведомлениеОВозможностиПрименения.Дата = sqlite_datareader["УведомлениеДата"].ToString();
                уведомлениеОВозможностиПрименения.Номер = sqlite_datareader["УведомлениеНомер"].ToString();
                уведомлениеОВозможностиПрименения.ПримС = sqlite_datareader["УведомлениеДатаПримС"].ToString();
                requisite.уведомлениеОВозможностиПрименения = уведомлениеОВозможностиПрименения;
            }

            sqlite_datareader.Close();
            sqlite_conn.Close();

            return requisite;
        }

        public List<Requisite> Load()
        {
            List<Requisite> requisites = new List<Requisite>();

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("SELECT * FROM Реквизиты");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                Requisite requisite = new Requisite();

                Налогоплательщик налогоплательщик = new Налогоплательщик();
                налогоплательщик.ДатаРождения = sqlite_datareader["НалогоплательщикДатаРождения"].ToString();
                налогоплательщик.ФормаСобственности = sqlite_datareader["НалогоплательщикФормаСобственности"].ToString();
                налогоплательщик.ИНН = sqlite_datareader["НалогоплательщикИНН"].ToString();
                налогоплательщик.КПП = sqlite_datareader["НалогоплательщикКПП"].ToString();
                налогоплательщик.МестоЖительства = sqlite_datareader["НалогоплательщикМестоЖительства"].ToString();
                налогоплательщик.Телефон = sqlite_datareader["НалогоплательщикТелефон"].ToString();
                налогоплательщик.Фамилия = sqlite_datareader["НалогоплательщикФамилия"].ToString();
                налогоплательщик.Имя = sqlite_datareader["НалогоплательщикИмя"].ToString();
                налогоплательщик.Отчество = sqlite_datareader["НалогоплательщикОтчество"].ToString();
                налогоплательщик.ФормаПоОКУД = sqlite_datareader["НалогоплательщикФормаПоОКУД"].ToString();
                налогоплательщик.ИмяОрганизации = sqlite_datareader["НалогоплательщикИмяОрганизации"].ToString();
                requisite.налогоплательщик = налогоплательщик;

                УполномоченныйПредставитель уполномоченныйПредставитель = new УполномоченныйПредставитель();
                уполномоченныйПредставитель.Дов = sqlite_datareader["ПредставительДоверенность"].ToString();
                уполномоченныйПредставитель.Имя = sqlite_datareader["ПредставительИмя"].ToString();
                уполномоченныйПредставитель.ИНН = sqlite_datareader["ПредставительИНН"].ToString();
                уполномоченныйПредставитель.Отчество = sqlite_datareader["ПредставительОтчество"].ToString();
                уполномоченныйПредставитель.Телефон = sqlite_datareader["ПредставительТелефон"].ToString();
                уполномоченныйПредставитель.Фамилия = sqlite_datareader["ПредставительФамилия"].ToString();
                уполномоченныйПредставитель.ИмяОрганизации = sqlite_datareader["ПредставительИмяОрганизации"].ToString();
                requisite.уполномоченныйПредставитель = уполномоченныйПредставитель;

                СвидетельствоОВнесении свидетельствоОВнесении = new СвидетельствоОВнесении();
                свидетельствоОВнесении.Дата = sqlite_datareader["СвидетельствоОВнесенииДата"].ToString();
                свидетельствоОВнесении.ДатаИсключенияИзРеестра = sqlite_datareader["СвидетельствоОВнесенииДатаИсключения"].ToString();
                свидетельствоОВнесении.Номер = sqlite_datareader["СвидетельствоОВнесенииНомер"].ToString();
                свидетельствоОВнесении.ОГРН = sqlite_datareader["СвидетельствоОВнесенииОГРН"].ToString();
                свидетельствоОВнесении.РегОрган = sqlite_datareader["СвидетельствоОВнесенииРегОрган"].ToString();
                requisite.свидетельствоОВнесении = свидетельствоОВнесении;

                СвидетельствоОПостановке свидетельствоОПостановке = new СвидетельствоОПостановке();
                свидетельствоОПостановке.Дата = sqlite_datareader["СвидетельствоОПостановкеДата"].ToString();
                свидетельствоОПостановке.ИНН = sqlite_datareader["СвидетельствоОПостановкеИНН"].ToString();
                свидетельствоОПостановке.НалОрган = sqlite_datareader["СвидетельствоОПостановкеНалОрган"].ToString();
                свидетельствоОПостановке.Номер = sqlite_datareader["СвидетельствоОПостановкеНомер"].ToString();
                requisite.свидетельствоОПостановке = свидетельствоОПостановке;

                РегистрацияВФондах регистрацияВФондах = new РегистрацияВФондах();
                регистрацияВФондах.СНИЛС = sqlite_datareader["РегистрацияВФондахСНИЛС"].ToString();
                регистрацияВФондах.РегОМС = sqlite_datareader["РегистрацияВФондахОМС"].ToString();
                регистрацияВФондах.РегПФР = sqlite_datareader["РегистрацияВФондахПФР"].ToString();
                requisite.регистрацияВФондах = регистрацияВФондах;

                Коды коды = new Коды();
                коды.ОКАТО = sqlite_datareader["КодыОКАТО"].ToString();
                коды.ОКВЭД = sqlite_datareader["КодыОКВЭД"].ToString();
                коды.ОКОГУ = sqlite_datareader["КодыОКОГУ"].ToString();
                коды.ОКОПФ = sqlite_datareader["КодыОКОПФ"].ToString();
                коды.ОКПО = sqlite_datareader["КодыОКПО"].ToString();
                коды.ОКФС = sqlite_datareader["КодыОКФС"].ToString();
                requisite.коды = коды;

                АдминистраторНалоговыхПлатежей администраторНалоговыхПлатежей = new АдминистраторНалоговыхПлатежей();
                администраторНалоговыхПлатежей.ИНН = sqlite_datareader["АдминистраторНалоговыхПлатежейИНН"].ToString();
                администраторНалоговыхПлатежей.Адрес = sqlite_datareader["АдминистраторНалоговыхПлатежейАдрес"].ToString();
                администраторНалоговыхПлатежей.ИнспекцияФНС = sqlite_datareader["АдминистраторНалоговыхПлатежейИнспекцияФНС"].ToString();
                администраторНалоговыхПлатежей.КПП = sqlite_datareader["АдминистраторНалоговыхПлатежейКПП"].ToString();
                requisite.администраторНалоговыхПлатежей = администраторНалоговыхПлатежей;

                АдминистраторСтраховыхВзносов администраторСтраховыхВзносов = new АдминистраторСтраховыхВзносов();
                администраторСтраховыхВзносов.Адрес = sqlite_datareader["АдминистраторСтраховыхВзносовАдрес"].ToString();
                администраторСтраховыхВзносов.ИНН = sqlite_datareader["АдминистраторСтраховыхВзносовИНН"].ToString();
                администраторСтраховыхВзносов.КПП = sqlite_datareader["АдминистраторСтраховыхВзносовКПП"].ToString();
                администраторСтраховыхВзносов.ОПРФ = sqlite_datareader["АдминистраторСтраховыхВзносовОПФР"].ToString();
                администраторСтраховыхВзносов.УПРФ = sqlite_datareader["АдминистраторСтраховыхВзносовУПФР"].ToString();
                requisite.администраторСтраховыхВзносов = администраторСтраховыхВзносов;

                ЕКС екс = new ЕКС();
                екс.Банк = sqlite_datareader["ЕКСБанк"].ToString();
                екс.БИК = sqlite_datareader["ЕКСБИК"].ToString();
                екс.Получатель = sqlite_datareader["ЕКСПолучатель"].ToString();
                екс.Расчетныйсчет = sqlite_datareader["ЕКСРасчетныйСчет"].ToString();
                requisite.екс = екс;

                УведомлениеОВозможностиПрименения уведомлениеОВозможностиПрименения = new УведомлениеОВозможностиПрименения();
                уведомлениеОВозможностиПрименения.Выдано = sqlite_datareader["УведомлениеВыдано"].ToString();
                уведомлениеОВозможностиПрименения.Дата = sqlite_datareader["УведомлениеДата"].ToString();
                уведомлениеОВозможностиПрименения.Номер = sqlite_datareader["УведомлениеНомер"].ToString();
                уведомлениеОВозможностиПрименения.ПримС = sqlite_datareader["УведомлениеДатаПримС"].ToString();
                requisite.уведомлениеОВозможностиПрименения = уведомлениеОВозможностиПрименения;

                requisites.Add(requisite);
            }

            sqlite_datareader.Close();
            sqlite_conn.Close();

            return requisites;
        }

        public void InsertNewINN(string INN)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("INSERT INTO Реквизиты (");
            commandText.Append("НалогоплательщикИНН");
            commandText.Append(")VALUES(");

            DataProvider.AddCommandTextInsert(commandText, INN, last: true);

            commandText.Append(");");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }

        public List<string> GetAllINN()
        {
            List<string> innList = new List<string>();

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();
            commandText.Append("SELECT НалогоплательщикИНН FROM Реквизиты");
            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                innList.Add(sqlite_datareader["НалогоплательщикИНН"].ToString());
            }

            sqlite_datareader.Close();
            sqlite_conn.Close();

            return innList;
        }

        public void SaveRequisite(Requisite requisite)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection(DataProvider.SQLiteConnectionString);
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            StringBuilder commandText = new StringBuilder();

            commandText.Append("UPDATE Реквизиты SET ");

            Налогоплательщик налогоплательщик = requisite.налогоплательщик;

            DataProvider.AddCommandTextUpdate(commandText, "НалогоплательщикДатаРождения", налогоплательщик.ДатаРождения);
            DataProvider.AddCommandTextUpdate(commandText, "НалогоплательщикИНН", налогоплательщик.ИНН);
            DataProvider.AddCommandTextUpdate(commandText, "НалогоплательщикМестоЖительства", налогоплательщик.МестоЖительства);
            DataProvider.AddCommandTextUpdate(commandText, "НалогоплательщикТелефон", налогоплательщик.Телефон);
            DataProvider.AddCommandTextUpdate(commandText, "НалогоплательщикФамилия", налогоплательщик.Фамилия);
            DataProvider.AddCommandTextUpdate(commandText, "НалогоплательщикИмя", налогоплательщик.Имя);
            DataProvider.AddCommandTextUpdate(commandText, "НалогоплательщикОтчество", налогоплательщик.Отчество);
            DataProvider.AddCommandTextUpdate(commandText, "НалогоплательщикФормаПоОКУД", налогоплательщик.ФормаПоОКУД);
            DataProvider.AddCommandTextUpdate(commandText, "НалогоплательщикКПП", налогоплательщик.КПП);
            DataProvider.AddCommandTextUpdate(commandText, "НалогоплательщикФормаСобственности", налогоплательщик.ФормаСобственности);
            DataProvider.AddCommandTextUpdate(commandText, "НалогоплательщикИмяОрганизации", налогоплательщик.ИмяОрганизации);

            УполномоченныйПредставитель уполномоченныйПредставитель = requisite.уполномоченныйПредставитель;

            DataProvider.AddCommandTextUpdate(commandText, "ПредставительДоверенность", уполномоченныйПредставитель.Дов);
            DataProvider.AddCommandTextUpdate(commandText, "ПредставительИмя", уполномоченныйПредставитель.Имя);
            DataProvider.AddCommandTextUpdate(commandText, "ПредставительИНН", уполномоченныйПредставитель.ИНН);
            DataProvider.AddCommandTextUpdate(commandText, "ПредставительОтчество", уполномоченныйПредставитель.Отчество);
            DataProvider.AddCommandTextUpdate(commandText, "ПредставительТелефон", уполномоченныйПредставитель.Телефон);
            DataProvider.AddCommandTextUpdate(commandText, "ПредставительФамилия", уполномоченныйПредставитель.Фамилия);
            DataProvider.AddCommandTextUpdate(commandText, "ПредставительИмяОрганизации", уполномоченныйПредставитель.ИмяОрганизации);

            СвидетельствоОВнесении свидетельствоОВнесении = requisite.свидетельствоОВнесении;

            DataProvider.AddCommandTextUpdate(commandText, "СвидетельствоОВнесенииДата", свидетельствоОВнесении.Дата);
            DataProvider.AddCommandTextUpdate(commandText, "СвидетельствоОВнесенииДатаИсключения", свидетельствоОВнесении.ДатаИсключенияИзРеестра);
            DataProvider.AddCommandTextUpdate(commandText, "СвидетельствоОВнесенииНомер", свидетельствоОВнесении.Номер);
            DataProvider.AddCommandTextUpdate(commandText, "СвидетельствоОВнесенииОГРН", свидетельствоОВнесении.ОГРН);
            DataProvider.AddCommandTextUpdate(commandText, "СвидетельствоОВнесенииРегОрган", свидетельствоОВнесении.РегОрган);

            СвидетельствоОПостановке свидетельствоОПостановке = requisite.свидетельствоОПостановке;

            DataProvider.AddCommandTextUpdate(commandText, "СвидетельствоОПостановкеДата", свидетельствоОПостановке.Дата);
            DataProvider.AddCommandTextUpdate(commandText, "СвидетельствоОПостановкеИНН", свидетельствоОПостановке.ИНН);
            DataProvider.AddCommandTextUpdate(commandText, "СвидетельствоОПостановкеНалОрган", свидетельствоОПостановке.НалОрган);
            DataProvider.AddCommandTextUpdate(commandText, "СвидетельствоОПостановкеНомер", свидетельствоОПостановке.Номер);

            РегистрацияВФондах регистрацияВФондах = requisite.регистрацияВФондах;

            DataProvider.AddCommandTextUpdate(commandText, "РегистрацияВФондахСНИЛС", регистрацияВФондах.СНИЛС);
            DataProvider.AddCommandTextUpdate(commandText, "РегистрацияВФондахОМС", регистрацияВФондах.РегОМС);
            DataProvider.AddCommandTextUpdate(commandText, "РегистрацияВФондахПФР", регистрацияВФондах.РегПФР);

            Коды коды = requisite.коды;

            DataProvider.AddCommandTextUpdate(commandText, "КодыОКАТО", коды.ОКАТО);
            DataProvider.AddCommandTextUpdate(commandText, "КодыОКВЭД", коды.ОКВЭД);
            DataProvider.AddCommandTextUpdate(commandText, "КодыОКОГУ", коды.ОКОГУ);
            DataProvider.AddCommandTextUpdate(commandText, "КодыОКОПФ", коды.ОКОПФ);
            DataProvider.AddCommandTextUpdate(commandText, "КодыОКПО", коды.ОКПО);
            DataProvider.AddCommandTextUpdate(commandText, "КодыОКФС", коды.ОКФС);

            АдминистраторНалоговыхПлатежей администраторНалоговыхПлатежей = requisite.администраторНалоговыхПлатежей;

            DataProvider.AddCommandTextUpdate(commandText, "АдминистраторНалоговыхПлатежейИНН", администраторНалоговыхПлатежей.ИНН);
            DataProvider.AddCommandTextUpdate(commandText, "АдминистраторНалоговыхПлатежейАдрес", администраторНалоговыхПлатежей.Адрес);
            DataProvider.AddCommandTextUpdate(commandText, "АдминистраторНалоговыхПлатежейИнспекцияФНС", администраторНалоговыхПлатежей.ИнспекцияФНС);
            DataProvider.AddCommandTextUpdate(commandText, "АдминистраторНалоговыхПлатежейКПП", администраторНалоговыхПлатежей.КПП);

            АдминистраторСтраховыхВзносов администраторСтраховыхВзносов = requisite.администраторСтраховыхВзносов;

            DataProvider.AddCommandTextUpdate(commandText, "АдминистраторСтраховыхВзносовАдрес", администраторСтраховыхВзносов.Адрес);
            DataProvider.AddCommandTextUpdate(commandText, "АдминистраторСтраховыхВзносовИНН", администраторСтраховыхВзносов.ИНН);
            DataProvider.AddCommandTextUpdate(commandText, "АдминистраторСтраховыхВзносовКПП", администраторСтраховыхВзносов.КПП);
            DataProvider.AddCommandTextUpdate(commandText, "АдминистраторСтраховыхВзносовОПФР", администраторСтраховыхВзносов.ОПРФ);
            DataProvider.AddCommandTextUpdate(commandText, "АдминистраторСтраховыхВзносовУПФР", администраторСтраховыхВзносов.УПРФ);

            ЕКС екс = requisite.екс;

            DataProvider.AddCommandTextUpdate(commandText, "ЕКСБанк", екс.Банк);
            DataProvider.AddCommandTextUpdate(commandText, "ЕКСБИК", екс.БИК);
            DataProvider.AddCommandTextUpdate(commandText, "ЕКСПолучатель", екс.Получатель);
            DataProvider.AddCommandTextUpdate(commandText, "ЕКСРасчетныйСчет", екс.Расчетныйсчет);

            УведомлениеОВозможностиПрименения уведомлениеОВозможностиПрименения = requisite.уведомлениеОВозможностиПрименения;

            DataProvider.AddCommandTextUpdate(commandText, "УведомлениеВыдано", уведомлениеОВозможностиПрименения.Выдано);
            DataProvider.AddCommandTextUpdate(commandText, "УведомлениеДата", уведомлениеОВозможностиПрименения.Дата);
            DataProvider.AddCommandTextUpdate(commandText, "УведомлениеНомер", уведомлениеОВозможностиПрименения.Номер);
            DataProvider.AddCommandTextUpdate(commandText, "УведомлениеДатаПримС", уведомлениеОВозможностиПрименения.ПримС, last: true);

            commandText.Append(" WHERE НалогоплательщикИНН = '" + налогоплательщик.ИНН + "';");

            sqlite_cmd.CommandText = commandText.ToString();
            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }
    }
}
