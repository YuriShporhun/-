using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    /// <summary>
    /// Данный класс отвечает за справку по кодам формы реорганизации компании
    /// Подробнее о кодах формы реорганизации компании можно прочитать в приложении 3 порядка заполнения декларации
    /// </summary>
    public class FormOfReorganizationReferenceLogic
    {
        /// <summary>
        /// Список кодов формы реорганизации компании
        /// </summary>
        List<FormOfReorganizationCode> formOfReorganizationCodes = new List<FormOfReorganizationCode>();

        public string this[int index]
        {
            get
            {
                return formOfReorganizationCodes[index].Code;
            }
        }

        /// <summary>
        /// Конструктор по умолчанию заполняет список кодов формы реорганизации компании
        /// </summary>
        public FormOfReorganizationReferenceLogic()
        {
            formOfReorganizationCodes.AddRange(new FormOfReorganizationCode[] {
                new FormOfReorganizationCode() { Code = "1", Name = "Преобразование"},
                new FormOfReorganizationCode() { Code = "2", Name = "Слияние" },
                new FormOfReorganizationCode() { Code = "3", Name = "Разделение"},
                new FormOfReorganizationCode() { Code = "5", Name = "Присоединение"},
                new FormOfReorganizationCode() { Code = "6", Name = "Разделение с одновременным присоединением"},
                new FormOfReorganizationCode() { Code = "0", Name = "Ликвидация"}
            });
        }

        /// <summary>
        /// Привязывает список кодов формы реорганизации компании к таблице DataDridView
        /// </summary>
        /// <param name="FormOfReorganizationCodeReferenceDataGridView">Таблица в которую будет выводится список кодов формы реорганизации компании</param>
        public void Bind(DataGridView FormOfReorganizationCodeReferenceDataGridView)
        {
            BindingSource formOfReorganizationCodeReferenceBindingSource = new BindingSource();
            formOfReorganizationCodeReferenceBindingSource.DataSource = formOfReorganizationCodes;
            FormOfReorganizationCodeReferenceDataGridView.DataSource = formOfReorganizationCodeReferenceBindingSource;
        }
    }
}
