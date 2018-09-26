using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    /// <summary>
    /// Данный класс отвечает за представление кода места представления декларации в налоговый орган
    /// Подробнее о кодах места представления декларации можно прочитать в приложении 3 порядка заполнения декларации
    /// </summary>
    public class TaxAuthorityPlaceCode
    {
        [DisplayName("Код")]
        public string Code { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }
    }
}
