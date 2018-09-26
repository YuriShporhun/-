using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class ESHNDeclarationPartOne
    {
        public string ОтчетныйГод { get; set; }
        public string НалоговыйПериод { get; set; }
        public string ПоМестуУчета { get; set; }
        public string ФормаРеорганизации { get; set; }
        public string ИННРеорганизованнойОрганизации { get; set; }
        public string КППРеорганизованнойОрганизации { get; set; }
        public string НомерКорректировки { get; set; }
        public string НаименованиеДокументаПодтверждающегоПолномочия { get; set; }
        public string ДостоверностьИПолнотуПодтверждает { get; set; }
        public string ПредставляетсяВНалоговыйОрган { get; set; }
        public Requisite Requisites { get; set; }
    }
}
