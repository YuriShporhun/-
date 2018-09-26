using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    /// <summary>
    /// Данный класс отвечает за представление кода формы реорганизации компании
    /// Подробнее о кодах формы реорганизации компании можно прочитать в приложении 2 порядка заполнения декларации
    /// </summary>
    public class FormOfReorganizationCode
    {
        [DisplayName("Код")]
        public string Code { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }
    }
}
