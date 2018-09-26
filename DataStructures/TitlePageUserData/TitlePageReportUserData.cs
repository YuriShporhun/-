using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class TitlePageReportUserData
    {
        public string Year { get; set; }
        public string INN { get; set; }
        public string FIO { get; set; }

        public TitlePageReportUserData(string Year, string INN, string FIO)
        {
            this.Year = Year;
            this.INN = INN;
            this.FIO = FIO;
        }
    }
}
