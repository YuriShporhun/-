using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class ESHNDeclarationPartTwo
    {
        public string ПервыйКодПоОКТМО { get; set; }
        public string ВторойКодПоОКТМО { get; set; }
        public string СуммаАвансовогоПлатежа { get; set; }
        public string СуммаДоходовЗаНалоговыйПериод { get; set; }
        public string СуммаРасходовЗаНалоговыйПериод { get; set; }
        public string НалоговаяБазаПоНалогу { get; set; }
        public string СуммаУбытка { get; set; }
        public string СуммаНалогаИсчисленногоЗаНалоговыйПериод { get; set; }
        public string СуммаНалогаПодлежащаяДоплате { get; set; }
        public string СуммаНалогаКУменьшению { get; set; }
        public Requisite Requisites { get; set; }
    }
}
