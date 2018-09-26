using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    /// <summary>
    /// Данный класс отвечает за инкапсуляцию данных о доходах и расходах
    /// </summary>
    public class IncomeAndExpense
    {
        private string internalIndex;

        public void SetInternalIndex(string internalIndex)
        {
            this.internalIndex = internalIndex;
        }

        public string GetInternalIndex()
        {
            return internalIndex;
        }

        [DisplayName("Номер документа")]
        public string DocumentsNumber { get; set; }

        [DisplayName("Дата")]
        public string Date { get; set; }

        [DisplayName("Содержание операции")]
        public string SubstanceOfTransaction { get; set; }

        [DisplayName("Доход")]
        public string Income { get; set; }

        [DisplayName("Расход")]
        public string Expense { get; set; }
    }
}
