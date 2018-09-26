using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class Requisite
    {
        public Налогоплательщик налогоплательщик { get; set; }
        public УполномоченныйПредставитель уполномоченныйПредставитель { get; set; }
        public СвидетельствоОВнесении свидетельствоОВнесении { get; set; }
        public СвидетельствоОПостановке свидетельствоОПостановке { get; set; }
        public УведомлениеОВозможностиПрименения уведомлениеОВозможностиПрименения { get; set; }
        public РегистрацияВФондах регистрацияВФондах { get; set; }
        public Коды коды { get; set; }
        public АдминистраторНалоговыхПлатежей администраторНалоговыхПлатежей { get; set; }
        public АдминистраторСтраховыхВзносов администраторСтраховыхВзносов { get; set; }
        public ЕКС екс { get; set; }
    }
}
