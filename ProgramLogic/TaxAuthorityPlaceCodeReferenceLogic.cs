using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    /// <summary>
    /// Данный класс отвечает за справку по кодам места представления декларации
    /// Подробнее о кодах места представления декларации можно прочитать в приложении 3 порядка заполнения декларации
    /// </summary>
    public class TaxAuthorityPlaceCodeReferenceLogic
    {
        /// <summary>
        /// Список кодов места представления декларации
        /// </summary>
        List<TaxAuthorityPlaceCode> TaxAuthorityPlaceCodes = new List<TaxAuthorityPlaceCode>();

        public string this[int index]
        {
            get
            {
                return TaxAuthorityPlaceCodes[index].Code;
            }
        }

        /// <summary>
        /// Конструктор по умолчанию заполняет список кодов места представления декларации
        /// </summary>
        public TaxAuthorityPlaceCodeReferenceLogic()
        {
            TaxAuthorityPlaceCodes.AddRange(new TaxAuthorityPlaceCode[] {
                new TaxAuthorityPlaceCode() { Code = "120", Name = "По месту жительства индивидуального предпринимателя"},
                new TaxAuthorityPlaceCode() { Code = "213", Name = "По месту учета в качестве крупнейшего налогоплательщика"},
                new TaxAuthorityPlaceCode() { Code = "214", Name = "По месту нахождения российской организации, не являющейся крупнейшим налогоплательщиком"},
                new TaxAuthorityPlaceCode() { Code = "215", Name = "По месту нахождения правоприемника, не являющегося крупнейшим налогоплательщиком"},
                new TaxAuthorityPlaceCode() { Code = "216", Name = "По месту нахождения правопреемника, являющегося крупнейшим налогоплательщиком"},
                new TaxAuthorityPlaceCode() { Code = "331", Name = "По месту осуществления деятельности иностранной организации через отделение иностранной организации"}
            });
        }

        /// <summary>
        /// Привязывает список кодов места представления декларации к таблице DataDridView
        /// </summary>
        /// <param name="TaxAuthorityPlaceReferenceDataGridView">Таблица в которую будет выводится список кодов представления декларации</param>
        public void Bind(DataGridView TaxAuthorityPlaceReferenceDataGridView)
        {
            BindingSource taxAuthorityPlaceReferenceBindingSource = new BindingSource();
            taxAuthorityPlaceReferenceBindingSource.DataSource = TaxAuthorityPlaceCodes;
            TaxAuthorityPlaceReferenceDataGridView.DataSource = taxAuthorityPlaceReferenceBindingSource;
        }
    }
}
