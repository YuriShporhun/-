using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public partial class ImportForm : Form
    {
        public bool isImportCorrect = false;

        bool importStarted = false;

        public ImportForm()
        {
            InitializeComponent();

            FirstINNTextBox.MaxLength = Constants.requiredINNLength;
            SecondINNTextBox.MaxLength = Constants.requiredINNLength;

            FirstINNTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;
            SecondINNTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if(FirstINNTextBox.Text != SecondINNTextBox.Text)
            {
                MessageBox.Show("Введенные вами ИНН не совпадают");
                return;
            }

            var dialogResult = MessageBox.Show("Вы уверены, что хотете сделать импорт данных для ИНН " + FirstINNTextBox.Text, "Предупреждение", MessageBoxButtons.YesNo);
            
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                if (!File.Exists(Constants.SQLiteDataBaseFullPath))
                {
                    File.Copy(Constants.pureSQLitePath, Constants.SQLiteDataBaseFullPath);
                }

                importStarted = true;

                try
                {
                    RequisiteDataProvider requisiteDataProvider = new RequisiteDataProvider();
                    string INN = FirstINNTextBox.Text;
                    requisiteDataProvider.SetINN(INN);
                    ImportProgressBar.Increment(1);
                    DataImporter.ImportIncomeAndExpense(INN);
                    ImportProgressBar.Increment(1);
                    DataImporter.ImportCommonAssets(INN);
                    ImportProgressBar.Increment(1);
                    DataImporter.ImportGuideToOperations();
                    ImportProgressBar.Increment(1);
                    DataImporter.ImportBankAccounts(INN);
                    ImportProgressBar.Increment(1);
                    DataImporter.ImportReqisite();
                }
                catch
                {
                    MessageBox.Show("Во время импорта произошла ошибка и он будет отменен, обратитесь к поставщику программы");
                    Environment.Exit(1);
                }

                isImportCorrect = true;
                importStarted = false;

                Close();
            }
        }

        private void ImportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(importStarted)
            {
                var dialogResult = MessageBox.Show("Импорт данных прерывать нельзя.");
                return;
            }
        }
    }
}
