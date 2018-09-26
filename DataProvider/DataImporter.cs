using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public static class DataImporter
    {
        public static void ImportReqisite()
        {
            RequisiteSQLiteDataProvider requisiteSQLiteDataProvider = new RequisiteSQLiteDataProvider();
            RequisiteDataProvider requisiteDataProvider = new RequisiteDataProvider();
            requisiteSQLiteDataProvider.ImportRequisite(requisiteDataProvider.LoadRequsite());
        }

        public static void ImportBankAccounts(string INN)
        {
            BankAccountSQLiteDataProvider bankAccountSQLiteDataProvider = new BankAccountSQLiteDataProvider();
            BankAccountDataProvider bankAccountDataProvider = new BankAccountDataProvider();
            List<BankAccount> listToImport = bankAccountDataProvider.Load();
            if (listToImport.Count != 0)
            {
                bankAccountSQLiteDataProvider.ImportBankAccounts(listToImport, INN);
            }

        }

        public static void ImportGuideToOperations()
        {
            GuideToOperationSQLiteDataProvider guideToOperationSQLiteDataProvider = new GuideToOperationSQLiteDataProvider();
            GuideToOperationsDataProvider guideToOperationsDataProvider = new GuideToOperationsDataProvider();
            List<GuideToOperation> listToImport = guideToOperationsDataProvider.LoadGuideToOperations();
            if (listToImport.Count != 0)
            {
                guideToOperationSQLiteDataProvider.ImportGuideToOperations(listToImport);
            }
        }

        public static void ImportCommonAssets(string INN)
        {
            CommonAssetsSQLiteDataProvider commonAssetsSQLiteDataProvider = new CommonAssetsSQLiteDataProvider();
            CommonAssetsDataProvider commonAssetsDataProvider = new CommonAssetsDataProvider();
            List<CommonAssets> listToImport = commonAssetsDataProvider.Load();
            if (listToImport.Count != 0)
            {
                commonAssetsSQLiteDataProvider.ImportCommonAssets(listToImport, INN);
            }
        }

        public static void ImportIncomeAndExpense(string INN)
        {
            for (int year = 2008; year <= 2020; year++)
            {
                IncomeAndExpenseDataProvider incomeAndExpenseDataProvider = new IncomeAndExpenseDataProvider();
                List<IncomeAndExpense> listToImport = incomeAndExpenseDataProvider.LoadIncomeAndExpense(new IncomeAndExpenseTimePeriod(year));
                if (listToImport.Count != 0)
                {
                    IncomeAndExpenseSQLiteDataProvider.Import(listToImport, year, INN);
                }
            }
        }
    }
}
