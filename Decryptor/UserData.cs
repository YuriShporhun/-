using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class UserData
    {
        public string INN { get; set; }
        public string Year { get; set; }

        public UserData(string INN, string Year)
        {
            this.INN = INN;

            this.Year = Year;
        }
    }
}
