using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    /// <summary>
    /// Данный класс отвечает за представление кода вида поступлений
    /// Подробнее о кодах вида поступлений можно прочитать в приложении 5 порядка заполнения декларации
    /// </summary>
    public class IncomeTypeCode
    {
        [DisplayName("Код вида поступлений")]
        public string Code { get; set; }

        [DisplayName("Наименование полученных целевых средств")]
        public string Name { get; set; }

    }
}
