using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class BlankIdentifierNumberException: Exception 
    {
        public const string MessageString = "Список ИНН пуст. Добавьте нового пользователя в разделе Справочники->Реквизиты.";
        public BlankIdentifierNumberException()
            : base(MessageString)
            { }
    }
}
