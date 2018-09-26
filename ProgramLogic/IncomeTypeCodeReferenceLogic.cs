using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    /// <summary>
    /// Данный класс отвечает за справку по кодам вида поступлений
    /// Подробнее о кодах вида поступлений можно прочитать в приложении 5 порядка заполнения декларации
    /// </summary>
    public class IncomeTypeCodeReferenceLogic
    {
        /// <summary>
        /// Список кодов вида поступлений
        /// </summary>
        List<IncomeTypeCode> incomeTypeCodes = new List<IncomeTypeCode>();

        public string this[int index]
        {
            get
            {
                return incomeTypeCodes[index].Code;
            }
        }

        /// <summary>
        /// Конструктор по умолчанию заполняет список кодов вида поступлений
        /// </summary>
        public IncomeTypeCodeReferenceLogic()
        {
            incomeTypeCodes.AddRange(new IncomeTypeCode[] {
                new IncomeTypeCode() { Code = "010", Name = IncomeTypeCodeData.КодПоступлений_010},
                new IncomeTypeCode() { Code = "020", Name = IncomeTypeCodeData.КодПоступлений_020},
                new IncomeTypeCode() { Code = "030", Name = IncomeTypeCodeData.КодПоступлений_030},
                new IncomeTypeCode() { Code = "120", Name = IncomeTypeCodeData.КодПоступлений_120},
                new IncomeTypeCode() { Code = "130", Name = IncomeTypeCodeData.КодПоступлений_130},
                new IncomeTypeCode() { Code = "140", Name = IncomeTypeCodeData.КодПоступлений_140},
                new IncomeTypeCode() { Code = "141", Name = IncomeTypeCodeData.КодПоступлений_141},
                new IncomeTypeCode() { Code = "160", Name = IncomeTypeCodeData.КодПоступлений_160},
                new IncomeTypeCode() { Code = "170", Name = IncomeTypeCodeData.КодПоступлений_170},
                new IncomeTypeCode() { Code = "171", Name = IncomeTypeCodeData.КодПоступлений_171},
                new IncomeTypeCode() { Code = "172", Name = IncomeTypeCodeData.КодПоступлений_172},
                new IncomeTypeCode() { Code = "173", Name = IncomeTypeCodeData.КодПоступлений_173},
                new IncomeTypeCode() { Code = "180", Name = IncomeTypeCodeData.КодПоступлений_180},
                new IncomeTypeCode() { Code = "220", Name = IncomeTypeCodeData.КодПоступлений_220},
                new IncomeTypeCode() { Code = "281", Name = IncomeTypeCodeData.КодПоступлений_281},
                new IncomeTypeCode() { Code = "281", Name = IncomeTypeCodeData.КодПоступлений_282},
                new IncomeTypeCode() { Code = "321", Name = IncomeTypeCodeData.КодПоступлений_321},
                new IncomeTypeCode() { Code = "322", Name = IncomeTypeCodeData.КодПоступлений_322},
                new IncomeTypeCode() { Code = "323", Name = IncomeTypeCodeData.КодПоступлений_323},
                new IncomeTypeCode() { Code = "324", Name = IncomeTypeCodeData.КодПоступлений_324},
                new IncomeTypeCode() { Code = "340", Name = IncomeTypeCodeData.КодПоступлений_340},
                new IncomeTypeCode() { Code = "360", Name = IncomeTypeCodeData.КодПоступлений_360},
                new IncomeTypeCode() { Code = "400", Name = IncomeTypeCodeData.КодПоступлений_400},
                new IncomeTypeCode() { Code = "500", Name = IncomeTypeCodeData.КодПуступлений_500}
            });
        }

        /// <summary>
        /// Привязывает список кодов поступлений к таблице DataDridView
        /// </summary>
        /// <param name="IncomeTypeCodesDataGridView">Таблица в которую будет выводится список кодов поступлений</param>
        public void Bind(DataGridView IncomeTypeCodesDataGridView)
        {
            BindingSource incomeTypeCodesBindingSource = new BindingSource();
            incomeTypeCodesBindingSource.DataSource = incomeTypeCodes;
            IncomeTypeCodesDataGridView.DataSource = incomeTypeCodesBindingSource;
        }
    }
}
