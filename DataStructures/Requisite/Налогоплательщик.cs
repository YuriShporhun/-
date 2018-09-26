using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class Налогоплательщик
    {
        public string ФормаСобственности { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string ДатаРождения { get; set; }
        public string ИНН { get; set; }
        public string КПП { get; set; }
        public string ФормаПоОКУД { get; set; }
        public string МестоЖительства { get; set; }
        public string Телефон { get; set; }
        public string ИмяОрганизации { get; set; }
    }
}
