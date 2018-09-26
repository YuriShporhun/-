using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class KeyData
    {
        public string INN { get; set; }
        public string Year { get; set; }
        public string Key { get; set; }

        public KeyData(string INN, string Year, string Key)
        {
            this.INN = INN;
            this.Key = Key;
            this.Year = Year;
        }
    }
}
