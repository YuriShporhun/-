using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class ClientInfo
    {
        [DisplayName("ИНН")]
        public string INN { get; set; }

        [DisplayName("ФИО")]
        public string FIO { get; set; }

        [DisplayName("Дата регистрации")]
        public string RegistrationDate { get; set; }

        [DisplayName("Год")]
        public string Year { get; set; }

        [DisplayName("Ключ")]
        public string Key { get; private set; }

        [DisplayName("Адрес")]
        public string Adress { get; set; }

        [DisplayName("Соль")]
        public string Salt { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        public void SetKey(string Key)
        {
            this.Key = Key;
        }
    }
}
