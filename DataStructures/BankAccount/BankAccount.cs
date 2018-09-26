using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class BankAccount
    {
        string internalIndex;

        public string GetInternalIndex()
        {
            return this.internalIndex;
        }

        public void SetInternalIndex(string internalIndex)
        {
            this.internalIndex = internalIndex;
        }

        [Browsable(false)]
        [DisplayName("ФИО")]
        public string FIO { get; set; }

        [DisplayName("Название банка")]
        public string BankName { get; set; }

        [DisplayName("Номер счета")]
        public string AccountNumber { get; set; }
    }
}
