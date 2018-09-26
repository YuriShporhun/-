using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public partial class MainForm : Form
    {
        SemesterToLoad semesterToLoad;
        IncomeAndExpenseTimePeriod incomeAndExpenseTimePeriod;
        DateTimePicker incomeAndExpenseEndDateTimePicker = new DateTimePicker();
        DateTimePicker incomeAndExpenseStartDateTimePicker = new DateTimePicker();

        List<KeyData> keyData = new List<KeyData>();
        BindingList<UseOfProperty> useOfProperty = new BindingList<UseOfProperty>();
        List<String> availableINN = new List<string>();

        public static ProgramLogic programLogic = null;

        public MainForm()
        {
            InitializeComponent();

            programLogic = ProgramLogic.GetInstance(new ProgramLogicView() {
                IncomeAndExpenseDataGridView = IncomeAndExpenseGridView,
                CommonAssetsGridView = CommonAssetsGridView
            });

            справочникОперацийToolStripMenuItem.Click += (s, e) => (new GuideToOperationsForm()).ShowDialog();
            наклейкаToolStripMenuItem.Click += (s, e) => (new StickerReportPreviewForm()).ShowDialog();
            оПрограммеToolStripMenuItem.Click += (s, e) => (new AboutForm()).ShowDialog();

            Label incomeAndExpenseEndDateLabel = new Label();
            Label incomeAndExpenseStartDateLabel = new Label();
            incomeAndExpenseStartDateTimePicker.Format = DateTimePickerFormat.Short;
            incomeAndExpenseStartDateTimePicker.Width = 80;
            incomeAndExpenseEndDateTimePicker.Format = DateTimePickerFormat.Short;
            incomeAndExpenseEndDateTimePicker.Width = 80;
            incomeAndExpenseEndDateLabel.Text = "по";
            incomeAndExpenseStartDateLabel.Text = "с";

            incomeAndExpensetoolStrip.Items.Add(new ToolStripControlHost(incomeAndExpenseStartDateLabel));
            incomeAndExpensetoolStrip.Items.Add(new ToolStripControlHost(incomeAndExpenseStartDateTimePicker));
            incomeAndExpensetoolStrip.Items.Add(new ToolStripControlHost(incomeAndExpenseEndDateLabel));
            incomeAndExpensetoolStrip.Items.Add(new ToolStripControlHost(incomeAndExpenseEndDateTimePicker));
        }

        public int GetSelectedYear()
        {
            return Convert.ToInt32(yearsComboBox.Text);
        }

        public string GetSelectedINN()
        {
            return INNComboBox.Text;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                CheckDataBase();
            }
            catch(Exception)
            {
                Environment.Exit(1);
            }

            keyData = CheckLicense();

            AddAvailableINN();

            SetESHNDeclarationPartOneLimits();
            SetESHNDeclarationPartTwoLimits();

            semesterToLoad = SemesterToLoad.BothSemesters;
            incomeAndExpenseTimePeriod = new IncomeAndExpenseTimePeriod(GetSelectedYear());

            UpdateIncomeAndExpenseDateIntervals();

            programLogic.incomeAndExpenseLogic.Load(incomeAndExpenseTimePeriod, GetSelectedINN());
            programLogic.commonAssetsLogic.Load(GetSelectedINN());

            //IncomeAndExpenseGridView.Columns[0].Width = 60;
            //IncomeAndExpenseGridView.Columns[1].Width = 80;
            //IncomeAndExpenseGridView.Columns[3].Width = 80;
            //IncomeAndExpenseGridView.Columns[4].Width = 80;

            saveBackupDialog.FileName = DateTime.Now.ToShortDateString();

            CheckSemesterButtonsState();
            UseOfPropertyDataGridView.DataSource = useOfProperty;
            RequiredSoftwareChecker.CheckApplicationShortcut();
        }

        private void AddAvailableINN()
        {
            RequisiteSQLiteDataProvider requisiteDataProvider = new RequisiteSQLiteDataProvider();
            var innList = requisiteDataProvider.GetAllINN();

            INNComboBox.Items.Clear();
            foreach (var item in innList)
            {
                INNComboBox.Items.Add(item);
            }

            if (INNComboBox.Items.Count > 0)
            {
                INNComboBox.SelectedIndex = 0;
            }
        }

        private void CheckSemesterButtonsState()
        {
            switch (semesterToLoad)
            {
                case SemesterToLoad.BothSemesters:
                    bothSemestersButton.Checked = true;
                    firstSemesterButton.Checked = false;
                    secondSemesterButton.Checked = false;
                    periodButton.Checked = false;
                    break;
                case SemesterToLoad.FirstSemester:
                    bothSemestersButton.Checked = false;
                    firstSemesterButton.Checked = true;
                    secondSemesterButton.Checked = false;
                    periodButton.Checked = false;
                    break;
                case SemesterToLoad.SecondSemester:
                    bothSemestersButton.Checked = false;
                    firstSemesterButton.Checked = false;
                    secondSemesterButton.Checked = true;
                    periodButton.Checked = false;
                    break;
                case SemesterToLoad.Period:
                    bothSemestersButton.Checked = false;
                    firstSemesterButton.Checked = false;
                    secondSemesterButton.Checked = false;
                    periodButton.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void CheckDataBase()
        {
            if (!Directory.Exists(Constants.dataBaseDirectoryPath))
            {
                Directory.CreateDirectory(Constants.dataBaseDirectoryPath);
            }

            if(!File.Exists(Constants.importFullPath) && 
               !File.Exists(Constants.SQLiteDataBaseFullPath) && 
                File.Exists(Constants.dataBaseFullPath))
            {
                ImportForm importForm = new ImportForm();
                importForm.ShowDialog();

                if (!importForm.isImportCorrect)
                {
                    MessageBox.Show("Во время импорта произошла ошибка. Аварийное завершение.");
                    Environment.Exit(1);
                }
                else
                {
                    File.Move(Constants.dataBaseFullPath, Constants.oldDataBaseFullPath);
                    File.Create(Constants.importFullPath).Close();
                }
            }
            else
            {
                if (!File.Exists(Constants.SQLiteDataBaseFullPath))
                {
                    File.Copy(Constants.pureSQLitePath, Constants.SQLiteDataBaseFullPath);
                    File.Create(Constants.importFullPath).Close();
                }
            }

            if (!File.Exists(Constants.licenseFullPath))
            {
                File.Copy(Constants.pureLicensePath, Constants.licenseFullPath);
            }
        }

        private List<KeyData> CheckLicense()
        {
            Protector protector = new Protector(Constants.licenseFullPath);

            List<KeyData> keyData = protector.LoadKeyData();

            if(keyData.Count == 0)
            {
                MessageBox.Show("Программа не зарегистрирована ни на один год. Пройдите процедуру регистрации.");
                Constants.isDemoVersion = true;
                this.Text = "Учет ЕСХН " + Constants.currentProgramVersion + " ДЕМО";
                AddDemoVersionYears();
            }
            else
            {
                Constants.isDemoVersion = false;
                this.Text = "Учет ЕСХН " + Constants.currentProgramVersion;
                AddFullVersionYears(keyData);
            }

            return keyData;
        }

        private void AddFullVersionYears(List<KeyData> keyData)
        {
            yearsComboBox.Items.Clear();
            foreach(var item in keyData)
            {
                yearsComboBox.Items.Add(item.Year);
            }
            yearsComboBox.SelectedIndex = 0;
        }

        private void AddDemoVersionYears()
        {
            yearsComboBox.Items.Clear();
            for(int i = 2008; i <= 2020; ++i)
            {
                yearsComboBox.Items.Add(i);
            }
            yearsComboBox.SelectedIndex = 0;
        }

        private void сохранитьБазуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveBackupDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.Copy(Constants.SQLiteDataBaseFullPath, saveBackupDialog.FileName);
            }
        }

        private void восстановитьБазуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Constants.backUpDirectory))
            {
                loadBackupDialog.InitialDirectory = Constants.backUpDirectory;
            }

            if(loadBackupDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var dialogResult = MessageBox.Show("Вы уверены, что хотите восстановить эту базу", "Предупреждение", MessageBoxButtons.YesNo);
                if(dialogResult == System.Windows.Forms.DialogResult.Yes)
                {
                    if(File.Exists(Constants.SQLiteDataBaseFullPath))
                    {
                        File.Move(Constants.SQLiteDataBaseFullPath, Constants.SQLiteDataBaseFullPath + DateTime.Now.ToShortDateString());
                    }
                    File.Copy(loadBackupDialog.FileName, Constants.SQLiteDataBaseFullPath);

                    programLogic.incomeAndExpenseLogic.Load(incomeAndExpenseTimePeriod, GetSelectedINN());
                    programLogic.commonAssetsLogic.Load(GetSelectedINN());
                }
            }
        }

        private void регистрацияПрограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
            if(registrationForm.formResult == System.Windows.Forms.DialogResult.Yes)
            {
                keyData = CheckLicense();
            }
        }

        private void DeleteCommonAssetsButton_Click(object sender, EventArgs e)
        {
            if (CommonAssetsGridView.RowCount == 0)
            {
                MessageBox.Show("В таблице основных средств нет данных");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить эту запись ?", "Предупреждение", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                programLogic.commonAssetsLogic.Delete(CommonAssetsGridView.CurrentCell.RowIndex, GetSelectedINN());
            }
        }

        private void yearsComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (incomeAndExpenseTimePeriod != null)
            {
                programLogic.incomeAndExpenseLogic.Load(incomeAndExpenseTimePeriod, GetSelectedINN());
                UpdateIncomeAndExpenseDateIntervals();
            }
        }

        private void UpdateIncomeAndExpenseDateIntervals()
        {
            incomeAndExpenseEndDateTimePicker.MinDate = new DateTime(1900, 1, 1);
            incomeAndExpenseStartDateTimePicker.MinDate = new DateTime(1900, 1, 1);
            incomeAndExpenseEndDateTimePicker.MaxDate = new DateTime(2100, 1, 1);
            incomeAndExpenseStartDateTimePicker.MaxDate = new DateTime(2100, 1, 1);

            incomeAndExpenseEndDateTimePicker.MinDate = new DateTime(GetSelectedYear(), 1, 1);
            incomeAndExpenseEndDateTimePicker.MaxDate = new DateTime(GetSelectedYear(), 12, 31);

            incomeAndExpenseStartDateTimePicker.MinDate = new DateTime(GetSelectedYear(), 1, 1);
            incomeAndExpenseStartDateTimePicker.MaxDate = new DateTime(GetSelectedYear(), 12, 31);
        }

        private void firstSemesterButton_Click(object sender, EventArgs e)
        {
            semesterToLoad = SemesterToLoad.FirstSemester;
            incomeAndExpenseTimePeriod.SetFirstSemesterPeriod();
            programLogic.incomeAndExpenseLogic.Load(incomeAndExpenseTimePeriod, GetSelectedINN());
            CheckSemesterButtonsState();
        }

        private void secondSemesterButton_Click(object sender, EventArgs e)
        {
            semesterToLoad = SemesterToLoad.SecondSemester;
            incomeAndExpenseTimePeriod.SetSecondSemesterPeriod();
            programLogic.incomeAndExpenseLogic.Load(incomeAndExpenseTimePeriod, GetSelectedINN());
            CheckSemesterButtonsState();
        }

        private void bothSemestersButton_Click(object sender, EventArgs e)
        {
            semesterToLoad = SemesterToLoad.BothSemesters;
            incomeAndExpenseTimePeriod.SetBothSemesterPeriod();
            programLogic.incomeAndExpenseLogic.Load(incomeAndExpenseTimePeriod, GetSelectedINN());
            CheckSemesterButtonsState();
        }

        bool CanUserPrintReports()
        {
            Protector protector = new Protector(Constants.licenseFullPath);
            List<KeyData> keyData = protector.LoadKeyData();

            foreach(var key in keyData)
            {
                if(key.INN == GetSelectedINN())
                {
                    return true;
                }
            }

            return false;
        }

        private void раздел1ДоходыИРасходыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                printIncomeAndExpenseReport();
            }
            catch(BlankIdentifierNumberException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printIncomeAndExpenseButton_Click(object sender, EventArgs e)
        {
            try
            {
                printIncomeAndExpenseReport();
            }
            catch (BlankIdentifierNumberException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printIncomeAndExpenseReport()
        {
            if (!CanUserPrintReports() && !Constants.isDemoVersion)
            {
                MessageBox.Show("У вас нет лицензии на печать по ИНН, введенному в реквизитах");
            }
            else
            {
                if (GetSelectedINN() == String.Empty)
                {
                    throw new BlankIdentifierNumberException();
                }
                (new IncomeAndExpenseReportPreviewForm(incomeAndExpenseTimePeriod, semesterToLoad, GetSelectedINN())).ShowDialog();
            }
        }

        private void раздел2ОсновныеСредстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                printCommonAssetsReport();
            }
            catch(BlankIdentifierNumberException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printCommonAssetsButton_Click(object sender, EventArgs e)
        {
            try
            {
                printCommonAssetsReport();
            }
            catch (BlankIdentifierNumberException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printCommonAssetsReport()
        {
            if (!CanUserPrintReports() && !Constants.isDemoVersion)
            {
                MessageBox.Show("У вас нет лицензии на печать по ИНН, введенному в реквизитах");
            }
            else
            {
                if(GetSelectedINN() == String.Empty)
                {
                    throw new BlankIdentifierNumberException();
                }
                CommonAssetsReportPreviewForm commonAssetsReportPreviewForm = new CommonAssetsReportPreviewForm(programLogic.commonAssetsLogic.GetCommonAssets(GetSelectedINN()));
                commonAssetsReportPreviewForm.ShowDialog();
            }
        }

        private void титульныйЛистToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RequisiteSQLiteDataProvider requisiteSQLiteDataProvider = new RequisiteSQLiteDataProvider();
            Requisite requisite = null;

            try
            {
                requisite = requisiteSQLiteDataProvider.Load(GetSelectedINN());
            }
            catch (BlankIdentifierNumberException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if(requisite.налогоплательщик.ИНН == String.Empty ||
               requisite.налогоплательщик.Имя == String.Empty ||
               requisite.налогоплательщик.Фамилия == String.Empty ||
               requisite.налогоплательщик.Отчество == String.Empty)
            {
                MessageBox.Show("Для печати титульного листа необходимо заполнить реквизиты, а именно ФИО и ИНН.", "Предупреждение");
                return;
            }

            string FIO = requisite.налогоплательщик.Фамилия + " " + requisite.налогоплательщик.Имя + " " + requisite.налогоплательщик.Отчество; 
            TitlePageReportUserData titlePageUserData = new TitlePageReportUserData(GetSelectedYear().ToString(), requisite.налогоплательщик.ИНН, FIO);

            TitlePageReportPreviewForm titlePageReportPreviewForm = new TitlePageReportPreviewForm(titlePageUserData);
            titlePageReportPreviewForm.ShowDialog();
        }

        private void AddIncomeAndExpenseButton_Click(object sender, EventArgs e)
        {
            if (GetSelectedINN() == String.Empty)
            {
                MessageBox.Show(BlankIdentifierNumberException.MessageString);
                return;
            }
            AddIncomeAndExpenseForm addIncomeAndExpenseForm = new AddIncomeAndExpenseForm(incomeAndExpenseTimePeriod, GetSelectedINN());
            addIncomeAndExpenseForm.ShowDialog();
        }

        private void DeleteIncomeAndExpenseButton_Click(object sender, EventArgs e)
        {
            if(IncomeAndExpenseGridView.RowCount == 0)
            {
                MessageBox.Show("В таблице доходов и расходов за " + GetSelectedYear() + " нет данных");
                return;
            }

            var dialogResult = MessageBox.Show("Вы уверены, что хотите удалить эту запись ?", "Предупреждение", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                programLogic.incomeAndExpenseLogic.Delete(IncomeAndExpenseGridView.CurrentCell.RowIndex, incomeAndExpenseTimePeriod, GetSelectedINN());
            }
        }

        private void EditIncomeAndExpenseButton_Click(object sender, EventArgs e)
        {
            if (IncomeAndExpenseGridView.RowCount == 0)
            {
                MessageBox.Show("В таблице доходов и расходов за " + GetSelectedYear() + " нет данных");
                return;
            }

            EditIncomeAndExpenseForm editIncomeAndExpenseForm = new EditIncomeAndExpenseForm(
                programLogic.incomeAndExpenseLogic[IncomeAndExpenseGridView.CurrentCell.RowIndex], 
                incomeAndExpenseTimePeriod,
                GetSelectedINN());

            editIncomeAndExpenseForm.ShowDialog();
        }

        private void EditCommonAssetsButton_Click(object sender, EventArgs e)
        {
            if (CommonAssetsGridView.RowCount == 0)
            {
                MessageBox.Show("В таблице основных средств нет данных");
                return;
            }
            EditCommonAssetsForm editCommonAssetsForm = new EditCommonAssetsForm(programLogic.commonAssetsLogic[CommonAssetsGridView.CurrentCell.RowIndex], GetSelectedINN());
            editCommonAssetsForm.ShowDialog();  
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoBackup()
        {
            string correctDate =  DateTime.Now.ToString().Replace(':', '_');

            if(!Directory.Exists(Constants.backUpDirectory))
            {
                Directory.CreateDirectory(Constants.backUpDirectory);
            }

            File.Copy(Constants.dataBaseFullPath, Constants.backUpDirectory + "base_" + correctDate + ".bdb");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DoBackup();
        }

        private void periodButton_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = incomeAndExpenseStartDateTimePicker.Value;
            DateTime endDateTime = incomeAndExpenseEndDateTimePicker.Value;
            int compareResult = DateTime.Compare(startDateTime, endDateTime);
            if (compareResult > 0)
            {
                MessageBox.Show("Неправильно задан период выборки данных", "Предупреждение");
                return;
            }
            semesterToLoad = SemesterToLoad.Period;
            incomeAndExpenseTimePeriod.SetPeriod(incomeAndExpenseStartDateTimePicker.Value, incomeAndExpenseEndDateTimePicker.Value);
            programLogic.incomeAndExpenseLogic.Load(incomeAndExpenseTimePeriod, GetSelectedINN());
            CheckSemesterButtonsState();
        }

        private void GetTaxPeriodFromReferenceButton_Click(object sender, EventArgs e)
        {
            TaxPeriodReferenceForm taxPeriodReferenceCodeForm = new TaxPeriodReferenceForm();
            taxPeriodReferenceCodeForm.ShowDialog();
            НалоговыйПериодTextBox.Text = taxPeriodReferenceCodeForm.SelectedTaxPeriodCode;
        }

        private void SetESHNDeclarationPartOneLimits()
        {
            НалоговыйПериодTextBox.MaxLength = Constants.maximumTaxPeriodLength;
            НалоговыйПериодTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;

            ПоМестуУчетаTextBox.MaxLength = Constants.maximumПоМестуУчетаLength;
            ПоМестуУчетаTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;

            ФормаРеорганизацииTextBox.MaxLength = Constants.maximumFormOfReorganisationLength;
            ФормаРеорганизацииTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;

            ИННРеорганизованнойОрганизацииTextBox.MaxLength = Constants.requiredReorganisedINNLength;
            ИННРеорганизованнойОрганизацииTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;

            КППРеорганизованнойОрганизацииTextBox.MaxLength = Constants.requiredKPPLength;
            КППРеорганизованнойОрганизацииTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;

            НомерКорректировкиTextBox.MaxLength = Constants.maximumCorrectNumberLength;
            НомерКорректировкиTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;

            НаименованиеПодтверждающегоДокументаTextBox.MaxLength = Constants.maximumНаименованиеПодтверждающегоLength;

            ПредставляетсяВНалоговыйОрганTextBox.MaxLength = Constants.maximumПредставляетсяВНалоговыйОрганLength;
            ПредставляетсяВНалоговыйОрганTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;
        }

        private void SetESHNDeclarationPartTwoLimits()
        {
            ПервыйКодПоОКТМОTextBox.MaxLength = Constants.maximumOKTMOLength;
            ПервыйКодПоОКТМОTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;

            ВторойКодПоОКТМОTextBox.MaxLength = Constants.maximumOKTMOLength;
            ВторойКодПоОКТМОTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;

            СуммаАвансовогоПлатежаTextBox.MaxLength = Constants.mamimumESHNPartTwoLongestFieldLength;
            СуммаАвансовогоПлатежаTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;

            СуммаДоходовTextBox.MaxLength = Constants.mamimumESHNPartTwoLongestFieldLength;
            СуммаДоходовTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;

            СуммаРасходовTextBox.MaxLength = Constants.mamimumESHNPartTwoLongestFieldLength;
            СуммаРасходовTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;
        }

        private bool CheckESHNPartOneCorrectness()
        {
            bool areAllFieldsCorrect = true;
            List<string> warningMessages = new List<string>();

            if(НалоговыйПериодTextBox.Text == String.Empty)
            {
                warningMessages.Add("Код налогового периода не может быть пустым");
                НалоговыйПериодTextBox.BackColor = Constants.badFieldColor;
                areAllFieldsCorrect = false;
            }
            else
            {
                НалоговыйПериодTextBox.BackColor = Constants.commonFieldColor;
            }

            if(ПоМестуУчетаTextBox.Text == String.Empty)
            {
                warningMessages.Add("Поле \"Представляется в налоговый орган\" не может быть пустым");
                ПоМестуУчетаTextBox.BackColor = Constants.badFieldColor;
                areAllFieldsCorrect = false;
            }
            else
            {
                ПоМестуУчетаTextBox.BackColor = Constants.commonFieldColor;
            }

            if(ИННРеорганизованнойОрганизацииTextBox.Text != String.Empty &&
               ИННРеорганизованнойОрганизацииTextBox.Text.Length != Constants.requiredReorganisedINNLength)
            {
                warningMessages.Add("ИНН реорганизованной организации может быть либо пустым, либо содержащим 10 символов.");
                ИННРеорганизованнойОрганизацииTextBox.BackColor = Constants.badFieldColor;
                areAllFieldsCorrect = false;
            }
            else
            {
                ИННРеорганизованнойОрганизацииTextBox.BackColor = Constants.commonFieldColor;
            }

            if(КППРеорганизованнойОрганизацииTextBox.Text != String.Empty &&
               КППРеорганизованнойОрганизацииTextBox.Text.Length != Constants.requiredKPPLength)
            {
                warningMessages.Add("КПП реорганизационной организации может быть либо пустым, либо содержащим 9 символов");
                КППРеорганизованнойОрганизацииTextBox.BackColor = Constants.badFieldColor;
                areAllFieldsCorrect = false;
            }
            else
            {
                КППРеорганизованнойОрганизацииTextBox.BackColor = Constants.commonFieldColor;
            }

            if(НомерКорректировкиTextBox.Text == String.Empty)
            {
                warningMessages.Add("Номер корректировки не может быть пустым");
                НомерКорректировкиTextBox.BackColor = Constants.badFieldColor;
                areAllFieldsCorrect = false;
            }
            else
            {
                НомерКорректировкиTextBox.BackColor = Constants.commonFieldColor;
            }

            if(!TaxpayerRadioButton.Checked && !RepresentativeRadioButton.Checked)
            {
                warningMessages.Add("Выберите ответственного за достоверность декларации");
                ConfirmsTheAccuracyOfTheDeclarationGroupBox.BackColor = Constants.badFieldColor;
                areAllFieldsCorrect = false;
            }
            else
            {
                ConfirmsTheAccuracyOfTheDeclarationGroupBox.BackColor = Constants.commonFieldColor;
            }

            if (areAllFieldsCorrect)
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

        private void GetTaxAuthorityPlaceCodeButton_Click(object sender, EventArgs e)
        {
            TaxAuthorityPlaceCodeReferenceForm taxAuthorityPlaceCodeReferenceForm = new TaxAuthorityPlaceCodeReferenceForm();
            taxAuthorityPlaceCodeReferenceForm.ShowDialog();
            ПоМестуУчетаTextBox.Text = taxAuthorityPlaceCodeReferenceForm.SelectedTaxAuthorityPlaceCode;
        }

        private void FirstOKTMOHelpButton_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm(HelpInfo.ЕСХН_Ч2_ПервыйКодПоОКТМО);
            helpForm.ShowDialog();
        }

        private void FormOfReorganizationReferenceButton_Click(object sender, EventArgs e)
        {
            FormOfReorganizationsReferenceForm formOfReorganizationsReferenceForm = new FormOfReorganizationsReferenceForm();
            formOfReorganizationsReferenceForm.ShowDialog();
            ФормаРеорганизацииTextBox.Text = formOfReorganizationsReferenceForm.SelectedFormOfReorganizationCode;
        }

        private void SecondOKTMOHelpButton_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm(HelpInfo.ЕСХН_Ч2_ВторойКодПоОКТМО);
            helpForm.ShowDialog();
        }

        private bool CheckESHNPartTwoCorrectness()
        {
            bool areAllFieldsCorrect = true;
            List<string> warningMessages = new List<string>();

            if(ПервыйКодПоОКТМОTextBox.Text == String.Empty)
            {
                warningMessages.Add("Поле первого кода по ОКТМО не может быть пустым");
                ПервыйКодПоОКТМОTextBox.BackColor = Constants.badFieldColor;
                areAllFieldsCorrect = false;
            }
            else
            {
                ПервыйКодПоОКТМОTextBox.BackColor = Constants.commonFieldColor;
            }

            if(СуммаАвансовогоПлатежаTextBox.Text == String.Empty)
            {
                warningMessages.Add("Поле суммы авансового платежа к уплате по сроку не позднее двадцать пятого июля отчетного года не может быть пустым");
                СуммаАвансовогоПлатежаTextBox.BackColor = Constants.badFieldColor;
                areAllFieldsCorrect = false;
            }
            else
            {
                СуммаАвансовогоПлатежаTextBox.BackColor = Constants.commonFieldColor;
            }

            if(СуммаДоходовTextBox.Text == String.Empty)
            {
                warningMessages.Add("Поле суммы доходов за налоговый период, учитываемых при определении налоговой базы по налогу не может быть пустым");
                СуммаДоходовTextBox.BackColor = Constants.badFieldColor;
                areAllFieldsCorrect = false;
            }
            else
            {
                СуммаДоходовTextBox.BackColor = Constants.commonFieldColor;
            }

            if(СуммаРасходовTextBox.Text == String.Empty)
            {
                warningMessages.Add("Поле суммы расходов за налоговый период, учитываемых при определении налоговой базы по налогу не может быть пустым");
                СуммаРасходовTextBox.BackColor = Constants.badFieldColor;
                areAllFieldsCorrect = false;
            }
            else
            {
                СуммаРасходовTextBox.BackColor = Constants.commonFieldColor;
            }

            if(СуммаУбыткаTextBox.Text == String.Empty)
            {
                warningMessages.Add("Поле суммы убытка, полученного в предыдущем налоговом периоде не может быть пустым");
                СуммаУбыткаTextBox.BackColor = Constants.badFieldColor;
                areAllFieldsCorrect = false;
            }
            else
            {
                СуммаУбыткаTextBox.BackColor = Constants.commonFieldColor;
            }

            if (areAllFieldsCorrect)
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

        private void ESHNPartOne_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;
            if (current == ESHNDeclarationPartFourTabPage)
            {
                AddUseOfPropertyToolStripButton.Visible = true;
                EditUseOfPropertyToolStripButton.Visible = true;
                DeleteUseOfPropertyToolStripButton.Visible = true;
            }
            else
            {
                AddUseOfPropertyToolStripButton.Visible = false;
                EditUseOfPropertyToolStripButton.Visible = false;
                DeleteUseOfPropertyToolStripButton.Visible = false;
            }
        }

        private void AddUseOfPropertyToolStripButton_Click(object sender, EventArgs e)
        {
            AddUseOfPropertyForm addUseOfPropertyForm = new AddUseOfPropertyForm();
            addUseOfPropertyForm.ShowDialog();
            if (addUseOfPropertyForm.formResult == System.Windows.Forms.DialogResult.Yes)
            {
                useOfProperty.Add(addUseOfPropertyForm.useOfProperty);
            }
        }

        private void PrintCurrentDeclarationPartButton_Click(object sender, EventArgs e)
        {
            if (!CanUserPrintReports() && !Constants.isDemoVersion)
            {
                MessageBox.Show("У вас нет лицензии на печать по ИНН, введенному в реквизитах");
                return;
            }

            if(ESHNDeclarationTabControl.SelectedTab == ESHNDeclarationPartOneTabPage)
            {
                if (CheckESHNPartOneCorrectness())
                {
                    RequisiteSQLiteDataProvider requisiteSQLiteDataProvider = new RequisiteSQLiteDataProvider();
                    Requisite requisite = null;

                    try
                    {
                        requisite = requisiteSQLiteDataProvider.Load(GetSelectedINN());
                    }
                    catch(BlankIdentifierNumberException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                    string ДостоверностьИПолнотуСведенийПодтверждает = String.Empty;

                    if(TaxpayerRadioButton.Checked)
                    {
                        ДостоверностьИПолнотуСведенийПодтверждает = "1";
                    }
                    else if(RepresentativeRadioButton.Checked)
                    {
                        ДостоверностьИПолнотуСведенийПодтверждает = "2";
                    }

                    ESHNDeclarationPartOne partOneData = new ESHNDeclarationPartOne
                    {
                        ПредставляетсяВНалоговыйОрган = ПредставляетсяВНалоговыйОрганTextBox.Text,
                        ОтчетныйГод = GetSelectedYear().ToString(),
                        ДостоверностьИПолнотуПодтверждает = ДостоверностьИПолнотуСведенийПодтверждает,
                        ИННРеорганизованнойОрганизации = ИННРеорганизованнойОрганизацииTextBox.Text,
                        КППРеорганизованнойОрганизации = КППРеорганизованнойОрганизацииTextBox.Text,
                        НаименованиеДокументаПодтверждающегоПолномочия = НаименованиеПодтверждающегоДокументаTextBox.Text,
                        НалоговыйПериод = НалоговыйПериодTextBox.Text,
                        НомерКорректировки = НомерКорректировкиTextBox.Text,
                        ПоМестуУчета = ПоМестуУчетаTextBox.Text,
                        ФормаРеорганизации = ФормаРеорганизацииTextBox.Text,
                        Requisites = requisite
                    };

                    PrintESHNDeclarationPartOne(partOneData);
                }        
            }
            else if(ESHNDeclarationTabControl.SelectedTab == ESHNDeclarationPartTwoTabPage)
            {
                if (CheckESHNPartTwoCorrectness())
                {
                    RequisiteSQLiteDataProvider requisiteSQLiteDataProvider = new RequisiteSQLiteDataProvider();
                    Requisite requisite = null;

                    try
                    {
                        requisite = requisiteSQLiteDataProvider.Load(GetSelectedINN());
                    }
                    catch (BlankIdentifierNumberException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                    int incomeSum = Convert.ToInt32(СуммаДоходовTextBox.Text);
                    int expenseSum = Convert.ToInt32(СуммаРасходовTextBox.Text);
                    int taxBase = 0;
                    int taxSum = 0;
                    int СуммаНалогаПодлежащаяДоплате = 0;
                    int СуммаНалогаКУменьшению = 0;

                    if(incomeSum > expenseSum)
                    {
                        taxBase = incomeSum - expenseSum;
                    }
                    taxSum = Convert.ToInt32(Math.Ceiling((taxBase - Convert.ToInt32(СуммаУбыткаTextBox.Text)) * 6.0 / 100.0));
                    if(taxSum > Convert.ToInt32(СуммаАвансовогоПлатежаTextBox.Text))
                    {
                        СуммаНалогаПодлежащаяДоплате = taxSum - Convert.ToInt32(СуммаАвансовогоПлатежаTextBox.Text);
                    }
                    if(taxSum < Convert.ToInt32(СуммаАвансовогоПлатежаTextBox.Text))
                    {
                        СуммаНалогаКУменьшению = Convert.ToInt32(СуммаАвансовогоПлатежаTextBox.Text) - taxSum;
                    }

                    ESHNDeclarationPartTwo partTwoData = new ESHNDeclarationPartTwo()
                        {
                            Requisites = requisite,
                            ВторойКодПоОКТМО = ВторойКодПоОКТМОTextBox.Text,
                            ПервыйКодПоОКТМО = ПервыйКодПоОКТМОTextBox.Text,
                            СуммаАвансовогоПлатежа = СуммаАвансовогоПлатежаTextBox.Text,
                            СуммаДоходовЗаНалоговыйПериод = СуммаДоходовTextBox.Text,
                            СуммаРасходовЗаНалоговыйПериод = СуммаРасходовTextBox.Text,
                            НалоговаяБазаПоНалогу = taxBase.ToString(),
                            СуммаУбытка = СуммаУбыткаTextBox.Text,
                            СуммаНалогаИсчисленногоЗаНалоговыйПериод = taxSum.ToString(),
                            СуммаНалогаПодлежащаяДоплате = СуммаНалогаПодлежащаяДоплате.ToString(),
                            СуммаНалогаКУменьшению = СуммаНалогаКУменьшению.ToString()
                        };

                    PrintESHNDeclarationPartTwo(partTwoData);
                }
            }
            else if(ESHNDeclarationTabControl.SelectedTab == ESHNDeclarationPartFourTabPage)
            {
                RequisiteSQLiteDataProvider requisiteSQLiteDataProvider = new RequisiteSQLiteDataProvider();
                Requisite requisite = null;

                try
                {
                    requisite = requisiteSQLiteDataProvider.Load(GetSelectedINN());
                }
                catch (BlankIdentifierNumberException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                ESHNDeclarationPartFour partFourData = new ESHNDeclarationPartFour();
                partFourData.useOfProperty = useOfProperty.ToList();
                partFourData.Requisites = requisite;
                PrintESHNDeclarationPartFour(partFourData);
            }
        }

        private void PrintESHNDeclarationPartOne(ESHNDeclarationPartOne partOneData)
        {
            ESHNDeclarationPartOnePrinter declaration = new ESHNDeclarationPartOnePrinter(partOneData);
            declaration.PrintIntoPdf();

            if (RequiredSoftwareChecker.IsAdobeReaderInstalled())
            {
                PreviewESHNDeclarationForm ESHNDeclarationForm = new PreviewESHNDeclarationForm(Constants.CompletedESHNDeclarationPartOneFullPath);
                ESHNDeclarationForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("У вас не установлено программное обеспечение Adobe PDF Reader. Сейчас вы перейдете на страницу установки. Удостоверьтесь, что у вас есть подключение к интернету.", "Предупреждение");
                InstallAdobeForm installAdobeForm = new InstallAdobeForm();
                installAdobeForm.ShowDialog();
            }
        }

        private void PrintESHNDeclarationPartTwo(ESHNDeclarationPartTwo partTwoData)
        {
            ESHNDeclarationPartTwoPrinter declaration = new ESHNDeclarationPartTwoPrinter(partTwoData);
            declaration.PrintIntoPdf();

            if (RequiredSoftwareChecker.IsAdobeReaderInstalled())
            {
                PreviewESHNDeclarationForm ESHNDeclarationForm = new PreviewESHNDeclarationForm(Constants.CompletedESHNDeclarationPartTwoFullPath);
                ESHNDeclarationForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("У вас не установлено программное обеспечение Adobe PDF Reader. Сейчас вы перейдете на страницу установки. Удостоверьтесь, что у вас есть подключение к интернету.", "Предупреждение");
                InstallAdobeForm installAdobeForm = new InstallAdobeForm();
                installAdobeForm.ShowDialog();
            }
        }

        private void PrintESHNDeclarationPartFour(ESHNDeclarationPartFour partFourData)
        {
            ESHNDeclarationPartFourPrinter declaration = new ESHNDeclarationPartFourPrinter(partFourData);
            declaration.PrintIntoPdf();

            if (RequiredSoftwareChecker.IsAdobeReaderInstalled())
            {
                PreviewESHNDeclarationForm ESHNDeclarationForm = new PreviewESHNDeclarationForm(Constants.CompletedESHNDeclarationPartFourFullPath);
                ESHNDeclarationForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("У вас не установлено программное обеспечение Adobe PDF Reader. Сейчас вы перейдете на страницу установки. Удостоверьтесь, что у вас есть подключение к интернету.", "Предупреждение");
                InstallAdobeForm installAdobeForm = new InstallAdobeForm();
                installAdobeForm.ShowDialog();
            }
        }

        private void DeleteUseOfPropertyToolStripButton_Click(object sender, EventArgs e)
        {
            if (UseOfPropertyDataGridView.CurrentCell.RowIndex != -1)
            {
                useOfProperty.RemoveAt(UseOfPropertyDataGridView.CurrentCell.RowIndex);
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления");
            }
        }

        private void НомерКорректировкиHelpButton_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm(HelpInfo.ЕСХН_ТИТУЛ_НомерКорректировки);
            helpForm.ShowDialog();
        }

        private void ReorganizedINNHelpButton_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm(HelpInfo.ЕСХН_ТИТУЛ_РеорганизованныйИНН);
            helpForm.ShowDialog();
        }

        private void ReorganizedKPPHelpButton_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm(HelpInfo.ЕСХН_ТИТУЛ_РеорганизованныйКПП);
            helpForm.ShowDialog();
        }

        private void FormOfReorganizationHelpButton_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm(HelpInfo.ЕСХН_ТИТУЛ_ФормаРеорганизации);
            helpForm.ShowDialog();
        }

        private void ПредставляетсяВНалоговыйОрганHelpButton_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm(HelpInfo.ЕСХН_ТИТУЛ_ПредставляетсяВНалоговыйОрган);
            helpForm.ShowDialog();
        }

        private void реквизитыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RequisiteForm requisiteForm = new RequisiteForm();
            requisiteForm.ShowDialog();
            AddAvailableINN();
        }

        private void INNComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (incomeAndExpenseTimePeriod != null)
            {
                programLogic.incomeAndExpenseLogic.Load(incomeAndExpenseTimePeriod, GetSelectedINN());
                programLogic.commonAssetsLogic.Load(GetSelectedINN());
            }
        }

        private void addCommonAssetsButton_Click(object sender, EventArgs e)
        {
            if (GetSelectedINN() == String.Empty)
            {
                MessageBox.Show(BlankIdentifierNumberException.MessageString);
                return;
            }
            AddCommonAssetsForm addCommonAssetsForm = new AddCommonAssetsForm(GetSelectedINN());
            addCommonAssetsForm.ShowDialog();
        }
    }
}