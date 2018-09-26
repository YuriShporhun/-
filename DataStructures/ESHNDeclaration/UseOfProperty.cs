using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class UseOfProperty
    {
        [DisplayName("Код вида поступления")]
        public string IncomeTypeCode { get; set; }

        [DisplayName("Дата поступления")]
        public string GoodsReceiptDate { get; set; }

        [DisplayName("Срок использования (до какой даты)")]
        public string PeriodOfUse { get; set; }

        [DisplayName("Стоимость имущества, работ, услуг или сумма денежных средств")]
        public string ValueOfProperty { get; set; }

        [DisplayName("Сумма средств, срок использования которых не истек")]
        public string AmountOfFundsWherePeriodHasNotExpired { get; set; }

        [DisplayName("Сумма средств, использованных по назначению в течении установленного срока")]
        public string AmountOfUsedFunds { get; set; }

        [DisplayName("Сумма средств, использованных не по назначению или не использованных в установленный срок")]
        public string AmountOfBadUsedOrNotUsedFunds { get; set; }

    }
}
