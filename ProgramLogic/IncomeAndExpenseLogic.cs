using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public class IncomeAndExpenseLogic
    {
        List<IncomeAndExpense> incomeAndExpense = new List<IncomeAndExpense>();

        DataGridView incomeAndExpenseGridView;
        IncomeAndExpenseSQLiteDataProvider incomeAndExpenseDataProvider = null;
        BindingSource incomeAndExpenseBindingSource = new BindingSource();

        public IncomeAndExpense this[int index]
        {
            get
            {
                return incomeAndExpense[index];
            }
        }

        public int GetIncomeAndExpenseCount()
        {
            return incomeAndExpense.Count;
        }
        
        public IncomeAndExpenseLogic(DataGridView incomeAndExpenseGridView)
        {
            incomeAndExpenseDataProvider = new IncomeAndExpenseSQLiteDataProvider();
            this.incomeAndExpenseGridView = incomeAndExpenseGridView;
        }

        /// <summary>
        /// Данный метод привязывает данные о расходах и доходах к таблице отображения данных.
        /// </summary>
        private void Bind()
        {
            var incomeAndExpenseBindingSource = new BindingSource();
            incomeAndExpenseBindingSource.DataSource = this.incomeAndExpense;
            incomeAndExpenseGridView.DataSource = incomeAndExpenseBindingSource;
        }

        public void Load(IncomeAndExpenseTimePeriod timePeriod, string INN)
        {
            if(INN == string.Empty)
            {
                return;
            }
            incomeAndExpense = incomeAndExpenseDataProvider.Load(timePeriod, INN);
            Bind();
        }

        public void Insert(IncomeAndExpense incomeAndExpense, IncomeAndExpenseTimePeriod timePeriod, string INN)
        {
            incomeAndExpenseDataProvider.Insert(incomeAndExpense, INN);
            Load(timePeriod, INN);
        }

        public void Delete(int indexInProgramsList, IncomeAndExpenseTimePeriod timePeriod, string INN)
        {
            incomeAndExpenseDataProvider.Delete(incomeAndExpense[indexInProgramsList].GetInternalIndex(), timePeriod);
            Load(timePeriod, INN);
        }

        public void Update(IncomeAndExpense incomeAndExpense, IncomeAndExpenseTimePeriod timePeriod, string INN)
        {
            incomeAndExpenseDataProvider.Update(incomeAndExpense);
            Load(timePeriod, INN);
        }
    }
}
