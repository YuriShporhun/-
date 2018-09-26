using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    /// <summary>
    /// Данный класс отвечает за представление кода налогового периода
    /// Подробнее о коде налогового периода можно прочитать в приложении 1 порядка заполнения декларации
    /// </summary>
    public class TaxPeriodCode
    {
        [DisplayName("Код")]
        public string Code { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }
    }
}
