using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    /// <summary>
    /// Данный класс отвечает за справку по текущим налоговым периодам
    /// Подробнее о коде налогового периода можно прочитать в приложении 1 порядка заполнения декларации
    /// </summary>
    public class TaxPeriodCodeReferenceLogic
    {
        /// <summary>
        /// Список налоговых периодов
        /// </summary>
        List<TaxPeriodCode> TaxPeriodCodes = new List<TaxPeriodCode>();

        public string this[int index]
        {
            get
            {
                return TaxPeriodCodes[index].Code;
            }
        }

        /// <summary>
        /// Конструктор по умолчанию заполняет список налоговых периодов
        /// </summary>
        public TaxPeriodCodeReferenceLogic()
        {
            TaxPeriodCodes.AddRange(new TaxPeriodCode[] {
                new TaxPeriodCode() { Code = "34", Name = "Календарный год"},
                new TaxPeriodCode() { Code = "50", Name = "Последний налоговый период при реорганизации (ликвидации) организации"},
                new TaxPeriodCode() { Code = "95", Name = "Последний налоговый период при переходе на иной режим налогообложения"},
                new TaxPeriodCode() { Code = "96", Name = "Последний налоговый период при прекращении предпринимательской деятельности"}
            });
        }

        /// <summary>
        /// Привязывает список налоговых периодов к таблице DataDridView
        /// </summary>
        /// <param name="TaxPeriodReferenceDataGridView">Таблица в которую будет выводится список налоговых периодов</param>
        public void Bind(DataGridView TaxPeriodReferenceDataGridView)
        {
            BindingSource taxPeriodReferenceBindingSource = new BindingSource();
            taxPeriodReferenceBindingSource.DataSource = TaxPeriodCodes;
            TaxPeriodReferenceDataGridView.DataSource = taxPeriodReferenceBindingSource;
        }
    }
}
