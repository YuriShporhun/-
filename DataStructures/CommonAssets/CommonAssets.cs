using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    /// <summary>
    /// Данный класс отвечает за  инкапсуляцию данных о основных средствах
    /// </summary>
    public class CommonAssets
    {
        private string internalIndex;

        public void SetInternalIndex(string DBIndex)
        {
            internalIndex = DBIndex;
        }

        public string GetInternalIndex()
        {
            return this.internalIndex;
        }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Дата оплаты")]
        public string BillingDate { get; set; }

        [DisplayName("Дата подачи документов")]
        public string DocumentsDate { get; set; }

        [DisplayName("Дата ввода в эксплуатацию")]
        public string ExpluatationDate { get; set; }

        [DisplayName("Первоначальная стоимость объекта")]
        public string InitialCost { get; set; }

        [DisplayName("Срок полезного использования объекта")]
        public string ObjectsUsefulLife { get; set; }

        [DisplayName("Остаточная стоимость объекта")]
        public string ObjectsResidualValue { get; set; }

        [DisplayName("Количество полугодий эксплуатации объекта")]
        public string NumberOfSemesters { get; set; }

        [DisplayName("Доля стоимости объекта за налоговый период")]
        public string ObjectsProportionOfValue { get; set; }

        [DisplayName("Включено в расходы")]
        public string IncludedInCosts { get; set; }

        [DisplayName("Дата выбытия")]
        public string DisposalDate { get; set; }
    }
}
