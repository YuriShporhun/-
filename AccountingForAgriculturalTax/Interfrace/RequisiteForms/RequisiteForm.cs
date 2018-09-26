using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public partial class RequisiteForm : Form
    {
        bool isINNPlaced = false;

        public RequisiteForm()
        {
            InitializeComponent();

            CloseButton.Click += (s, o) => Close();
            OrganizationTypeComboBox.SelectedIndex = 0;

            НалогоплательщикКППTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;
            НалогоплательщикТелефонTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;
            НалогоплательщикФамилияTextBox.KeyPress += TextBoxProcessor.ProcessOnlyLetters;
            НалогоплательщикИМЯTextBox.KeyPress += TextBoxProcessor.ProcessOnlyLetters;
            НалогоплательщикОтчествоTextBox.KeyPress += TextBoxProcessor.ProcessOnlyLetters;

            НалогоплательщикТелефонTextBox.MaxLength = Constants.maximumPhoneLength;
            НалогоплательщикФамилияTextBox.MaxLength = Constants.maximumNameLength;
            НалогоплательщикИМЯTextBox.MaxLength = Constants.maximumNameLength;
            НалогоплательщикОтчествоTextBox.MaxLength = Constants.maximumNameLength;
            НалогоплательщикКППTextBox.MaxLength = Constants.requiredKPPLength;

            УполномоченныйПредставительФамилияTextBox.MaxLength = Constants.maximumNameLength;
            УполномоченныйПредставительИмяTextBox.MaxLength = Constants.maximumNameLength;
            УполномоченныйПредставительОтчествоTextBox.MaxLength = Constants.maximumNameLength;
            УполномоченныйПредставительИННTextBox.MaxLength = Constants.requiredINNLength;
            УполномоченныйПредставительТелефонTextBox.MaxLength = Constants.maximumPhoneLength;

            УполномоченныйПредставительФамилияTextBox.KeyPress += TextBoxProcessor.ProcessOnlyLetters;
            УполномоченныйПредставительИмяTextBox.KeyPress += TextBoxProcessor.ProcessOnlyLetters;
            УполномоченныйПредставительОтчествоTextBox.KeyPress += TextBoxProcessor.ProcessOnlyLetters;
            УполномоченныйПредставительИННTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;
            УполномоченныйПредставительТелефонTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;

        }

        private void RequisiteForm_Load(object sender, EventArgs e)
        {
            PlaceAvailableINNIntoComboBox();
            if (НалогоплательщикИННComboBox.Items.Count > 0)
            {
                LoadRequisite(НалогоплательщикИННComboBox.Text);
            }
        }

        private void PlaceAvailableINNIntoComboBox()
        {
            RequisiteSQLiteDataProvider requisiteDataProvider = new RequisiteSQLiteDataProvider();

            List<string> innList = requisiteDataProvider.GetAllINN();

            if (!innList.Any())
            {
                AddRequisiteForm addRequisiteForm = new AddRequisiteForm();
                addRequisiteForm.ShowDialog();

                if (addRequisiteForm.wasNewUserAdded)
                {
                    innList = requisiteDataProvider.GetAllINN();
                }
                else
                {
                    Close();
                }
            }

            НалогоплательщикИННComboBox.Items.Clear();

            foreach (var i in innList)
            {
                НалогоплательщикИННComboBox.Items.Add(i);
            }

            if (НалогоплательщикИННComboBox.Items.Count > 0)
            {
                НалогоплательщикИННComboBox.SelectedIndex = 0;
            }

            isINNPlaced = true;
        }

        void LoadRequisite(string INN)
        {
            RequisiteSQLiteDataProvider requisiteDataProvider = new RequisiteSQLiteDataProvider();

            Requisite requisite = requisiteDataProvider.Load(INN);

            if (requisite == null)
            {
                MessageBox.Show("Не удалось загрузить реквизиты. Обратитесь к поставщику программы.");
                return;
            }


            НалогоплательщикМестоЖительстваTextBox.Text = requisite.налогоплательщик.МестоЖительства;
            НалогоплательщикДатаРожденияTextBox.Text = requisite.налогоплательщик.ДатаРождения;
            НалогоплательщикТелефонTextBox.Text = requisite.налогоплательщик.Телефон;
            НалогоплательщикФамилияTextBox.Text = requisite.налогоплательщик.Фамилия;
            НалогоплательщикИмяОрганизацииTextBox.Text = requisite.налогоплательщик.ИмяОрганизации;
            НалогоплательщикИМЯTextBox.Text = requisite.налогоплательщик.Имя;
            НалогоплательщикОтчествоTextBox.Text = requisite.налогоплательщик.Отчество;
            НалогоплательщикФормаПоОКУДTextBox.Text = requisite.налогоплательщик.ФормаПоОКУД;
            НалогоплательщикКППTextBox.Text = requisite.налогоплательщик.КПП;
       
            if(requisite.налогоплательщик.ФормаСобственности == "ИП")
            {
                OrganizationTypeComboBox.SelectedIndex = 0;
            }

            if(requisite.налогоплательщик.ФормаСобственности == "ООО")
            {
                OrganizationTypeComboBox.SelectedIndex = 1;
            }

            УполномоченныйПредставительФамилияTextBox.Text = requisite.уполномоченныйПредставитель.Фамилия;
            УполномоченныйПредставительИмяTextBox.Text = requisite.уполномоченныйПредставитель.Имя;
            УполномоченныйПредставительОтчествоTextBox.Text = requisite.уполномоченныйПредставитель.Отчество;
            УполномоченныйПредставительИННTextBox.Text = requisite.уполномоченныйПредставитель.ИНН;
            УполномоченныйПредставительТелефонTextBox.Text = requisite.уполномоченныйПредставитель.Телефон;
            УполномоченныйПредставительДовTextBox.Text = requisite.уполномоченныйПредставитель.Дов;
            УполномоченныйПредставительИмяОрганизацииTextBox.Text = requisite.уполномоченныйПредставитель.ИмяОрганизации;

            СвидетельствоОВнесенииОГРНTextBox.Text = requisite.свидетельствоОВнесении.ОГРН;
            СвидетельствоОВнесенииНомерTextBox.Text = requisite.свидетельствоОВнесении.Номер;
            СвидетельствоОВнесенииДатаTextBox.Text = requisite.свидетельствоОВнесении.Дата;
            СвидетельствоОВнесенииРегОрганTextBox.Text = requisite.свидетельствоОВнесении.РегОрган;
            СвидетельствоОВнесенииДатаИсключенияTextBox.Text = requisite.свидетельствоОВнесении.ДатаИсключенияИзРеестра;

            СвидетельствоОПостановкеНалОрганTextBox.Text = requisite.свидетельствоОПостановке.НалОрган;
            СвидетельствоОПостановкеДатаDateTimePicker.Text = requisite.свидетельствоОПостановке.Дата;
            СвидетельствоОПостановкеИННTextBox.Text = requisite.свидетельствоОПостановке.ИНН;
            СвидетельствоОПостановкеНомерTextBox.Text = requisite.свидетельствоОПостановке.Номер;

            РегистрацияВФондахОМСTextBox.Text = requisite.регистрацияВФондах.РегОМС;
            РегистрацияВФондахПФРTextBox.Text = requisite.регистрацияВФондах.РегПФР;
            РегистрацияВФондахСНИЛСTextBox.Text = requisite.регистрацияВФондах.СНИЛС;

            КодыОКАТОTextBox.Text = requisite.коды.ОКАТО;
            КодыОКОГУTextBox.Text = requisite.коды.ОКОГУ;
            КодыОКПОTextBox.Text = requisite.коды.ОКПО;
            КодыОКФСTextBox.Text = requisite.коды.ОКФС;
            КодыОКОПФTextBox.Text = requisite.коды.ОКОПФ;
            КодОКВЭДTextBox.Text = requisite.коды.ОКВЭД;

            АдминистраторНалоговыхПлатежейАдресTextBox.Text = requisite.администраторНалоговыхПлатежей.Адрес;
            АдминистраторНалоговыхПлатежейИННTextBox.Text = requisite.администраторНалоговыхПлатежей.ИНН;
            АдминистраторНалоговыхПлатежейИнспекцияФНСTextBox.Text = requisite.администраторНалоговыхПлатежей.ИнспекцияФНС;
            АдминистраторНалоговыхПлатежейКППTextBox.Text = requisite.администраторНалоговыхПлатежей.КПП;

            АдминистраторСтраховыхВзносовАдресTextBox.Text = requisite.администраторСтраховыхВзносов.Адрес;
            АдминистраторСтраховыхВзносовИННTextBox.Text = requisite.администраторСтраховыхВзносов.ИНН;
            АдминистраторСтраховыхВзносовКППTextBox.Text = requisite.администраторСтраховыхВзносов.КПП;
            АдминистраторСтраховыхВзносовОПРФTextBox.Text = requisite.администраторСтраховыхВзносов.ОПРФ;
            АдминистраторСтраховыхВзносовУПРФTextBox.Text = requisite.администраторСтраховыхВзносов.УПРФ;

            ЕКСБанкTextBox.Text = requisite.екс.Банк;
            ЕКСБИКTextBox.Text = requisite.екс.БИК;
            ЕКСПолучательTextBox.Text = requisite.екс.Получатель;
            ЕКСРасчетныйСчетTextBox.Text = requisite.екс.Расчетныйсчет;

            УведомлениеОВозможностиПримененияЕСХНДатаDateTimePicker.Text = requisite.уведомлениеОВозможностиПрименения.Дата;
            УведомлениеОВозможностиПримененияЕСХНВыданоTextBox.Text = requisite.уведомлениеОВозможностиПрименения.Выдано;
            УведомлениеОВозможностиПримененияЕСХННомерTextBox.Text = requisite.уведомлениеОВозможностиПрименения.Номер;
            УведомлениеОВозможностиПримененияЕСХНПримСDateTimePicker.Text = requisite.уведомлениеОВозможностиПрименения.ПримС;
        }

        void SaveRequisiteButton_Click(object sender, EventArgs e)
        {
            if (!IsRequisiteFormCorrect())
            {
                return;
            }

            RequisiteSQLiteDataProvider requisiteDataProvider = new RequisiteSQLiteDataProvider();
            var requisite = new Requisite();

            АдминистраторНалоговыхПлатежей администраторНалоговыхПлатежей = new АдминистраторНалоговыхПлатежей();

            администраторНалоговыхПлатежей.Адрес = АдминистраторНалоговыхПлатежейАдресTextBox.Text;
            администраторНалоговыхПлатежей.ИНН = АдминистраторНалоговыхПлатежейИННTextBox.Text;
            администраторНалоговыхПлатежей.ИнспекцияФНС = АдминистраторНалоговыхПлатежейИнспекцияФНСTextBox.Text;
            администраторНалоговыхПлатежей.КПП = АдминистраторНалоговыхПлатежейКППTextBox.Text;

            АдминистраторСтраховыхВзносов администраторСтраховыхВзносов = new АдминистраторСтраховыхВзносов();

            администраторСтраховыхВзносов.Адрес = АдминистраторСтраховыхВзносовАдресTextBox.Text;
            администраторСтраховыхВзносов.ИНН = АдминистраторСтраховыхВзносовИННTextBox.Text;
            администраторСтраховыхВзносов.КПП = АдминистраторСтраховыхВзносовКППTextBox.Text;
            администраторСтраховыхВзносов.ОПРФ = АдминистраторСтраховыхВзносовОПРФTextBox.Text;
            администраторСтраховыхВзносов.УПРФ = АдминистраторСтраховыхВзносовУПРФTextBox.Text;

            УполномоченныйПредставитель уполномоченныйПредставитель = new УполномоченныйПредставитель();

            уполномоченныйПредставитель.Дов = УполномоченныйПредставительДовTextBox.Text;
            уполномоченныйПредставитель.Имя = УполномоченныйПредставительИмяTextBox.Text;
            уполномоченныйПредставитель.ИНН = УполномоченныйПредставительИННTextBox.Text;
            уполномоченныйПредставитель.Отчество = УполномоченныйПредставительОтчествоTextBox.Text;
            уполномоченныйПредставитель.Телефон = УполномоченныйПредставительТелефонTextBox.Text;
            уполномоченныйПредставитель.Фамилия = УполномоченныйПредставительФамилияTextBox.Text;
            уполномоченныйПредставитель.ИмяОрганизации = УполномоченныйПредставительИмяОрганизацииTextBox.Text;

            ЕКС екс = new ЕКС();

            екс.Банк = ЕКСБанкTextBox.Text;
            екс.БИК = ЕКСБИКTextBox.Text;
            екс.Получатель = ЕКСПолучательTextBox.Text;
            екс.Расчетныйсчет = ЕКСРасчетныйСчетTextBox.Text;

            Коды коды = new Коды();

            коды.ОКАТО = КодыОКАТОTextBox.Text;
            коды.ОКВЭД = КодОКВЭДTextBox.Text;
            коды.ОКОГУ = КодыОКОГУTextBox.Text;
            коды.ОКОПФ = КодыОКОПФTextBox.Text;
            коды.ОКПО = КодыОКПОTextBox.Text;
            коды.ОКФС = КодыОКФСTextBox.Text;

            Налогоплательщик налогоплательщик = new Налогоплательщик();

            налогоплательщик.ДатаРождения = НалогоплательщикДатаРожденияTextBox.Text;
            налогоплательщик.ИНН = НалогоплательщикИННComboBox.Text;
            налогоплательщик.КПП = НалогоплательщикКППTextBox.Text;
            налогоплательщик.ФормаСобственности = OrganizationTypeComboBox.Text;
            налогоплательщик.МестоЖительства = НалогоплательщикМестоЖительстваTextBox.Text;
            налогоплательщик.Телефон = НалогоплательщикТелефонTextBox.Text;
            налогоплательщик.Фамилия = НалогоплательщикФамилияTextBox.Text;
            налогоплательщик.Имя = НалогоплательщикИМЯTextBox.Text;
            налогоплательщик.Отчество = НалогоплательщикОтчествоTextBox.Text;
            налогоплательщик.ФормаПоОКУД = НалогоплательщикФормаПоОКУДTextBox.Text;
            налогоплательщик.ИмяОрганизации = НалогоплательщикИмяОрганизацииTextBox.Text;

            РегистрацияВФондах регистрацияВФондах = new РегистрацияВФондах();

            регистрацияВФондах.РегОМС = РегистрацияВФондахОМСTextBox.Text;
            регистрацияВФондах.РегПФР = РегистрацияВФондахПФРTextBox.Text;
            регистрацияВФондах.СНИЛС = РегистрацияВФондахСНИЛСTextBox.Text;

            СвидетельствоОВнесении свидетельствоОВнесении = new СвидетельствоОВнесении();

            свидетельствоОВнесении.Дата = СвидетельствоОВнесенииДатаTextBox.Text;
            свидетельствоОВнесении.ДатаИсключенияИзРеестра = СвидетельствоОВнесенииДатаИсключенияTextBox.Text;
            свидетельствоОВнесении.Номер = СвидетельствоОВнесенииНомерTextBox.Text;
            свидетельствоОВнесении.ОГРН = СвидетельствоОВнесенииОГРНTextBox.Text;
            свидетельствоОВнесении.РегОрган = СвидетельствоОВнесенииРегОрганTextBox.Text;

            СвидетельствоОПостановке свидетельствоОПостановке = new СвидетельствоОПостановке();

            свидетельствоОПостановке.Дата = СвидетельствоОПостановкеДатаDateTimePicker.Text;
            свидетельствоОПостановке.ИНН = СвидетельствоОПостановкеИННTextBox.Text;
            свидетельствоОПостановке.НалОрган = СвидетельствоОПостановкеНалОрганTextBox.Text;
            свидетельствоОПостановке.Номер = СвидетельствоОПостановкеНомерTextBox.Text;

            УведомлениеОВозможностиПрименения уведомлениеОВозможностиПрименения = new УведомлениеОВозможностиПрименения();

            уведомлениеОВозможностиПрименения.Выдано = УведомлениеОВозможностиПримененияЕСХНВыданоTextBox.Text;
            уведомлениеОВозможностиПрименения.Дата = УведомлениеОВозможностиПримененияЕСХНДатаDateTimePicker.Text;
            уведомлениеОВозможностиПрименения.Номер = УведомлениеОВозможностиПримененияЕСХННомерTextBox.Text;
            уведомлениеОВозможностиПрименения.ПримС = УведомлениеОВозможностиПримененияЕСХНПримСDateTimePicker.Text;

            requisite.администраторНалоговыхПлатежей = администраторНалоговыхПлатежей;
            requisite.администраторСтраховыхВзносов = администраторСтраховыхВзносов;
            requisite.екс = екс;
            requisite.коды = коды;
            requisite.налогоплательщик = налогоплательщик;
            requisite.регистрацияВФондах = регистрацияВФондах;
            requisite.свидетельствоОВнесении = свидетельствоОВнесении;
            requisite.свидетельствоОПостановке = свидетельствоОПостановке;
            requisite.уведомлениеОВозможностиПрименения = уведомлениеОВозможностиПрименения;
            requisite.уполномоченныйПредставитель = уполномоченныйПредставитель;

            requisiteDataProvider.SaveRequisite(requisite);

            ChangesWasSavedForm changesWasSavedForm = new ChangesWasSavedForm();
            changesWasSavedForm.ShowDialog();
        }

        private bool IsRequisiteFormCorrect()
        {
            Color badFieldColor = Color.FromArgb(247, 195, 195);
            bool isAllFieldsCorrect = true;
            List<string> warningMessages = new List<string>();

            if (isAllFieldsCorrect)
            {
                return true;
            }
            else
            {
                WarningForm warningForm = new WarningForm(warningMessages);
                warningForm.ShowDialog();
                return false;
            }
        }

        private void bankAccountsButton_Click(object sender, EventArgs e)
        {
            BankAccountsForm bankAccountForm = new BankAccountsForm(НалогоплательщикФамилияTextBox.Text, НалогоплательщикИННComboBox.Text);
            bankAccountForm.ShowDialog();
        }

        private void OrganozationTypeComboBox_TextChanged(object sender, EventArgs e)
        {
            if(OrganizationTypeComboBox.SelectedIndex == 0)
            {
                НалогоплательщикИмяОрганизацииTextBox.ReadOnly = true;
                НалогоплательщикКППTextBox.ReadOnly = true;
            }
            else if (OrganizationTypeComboBox.SelectedIndex == 1)
            {
                НалогоплательщикИмяОрганизацииTextBox.ReadOnly = false;
                НалогоплательщикКППTextBox.ReadOnly = false;
            }
        }

        private void GetОКВЭДCodeFromReferenceButton_Click(object sender, EventArgs e)
        {
            ОКВЭДReferenceForm okved = new ОКВЭДReferenceForm();
            okved.ShowDialog();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AddRequisiteForm addRequisiteForm = new AddRequisiteForm();
            addRequisiteForm.ShowDialog();
            PlaceAvailableINNIntoComboBox();
        }

        private void НалогоплательщикИННComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (НалогоплательщикИННComboBox.Items.Count > 0 && isINNPlaced)
            {
                LoadRequisite(НалогоплательщикИННComboBox.Text);
            }
        }
    }
}