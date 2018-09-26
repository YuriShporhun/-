using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public partial class IncomeTypeCodeReferenceForm : Form
    {
        IncomeTypeCodeReferenceLogic incomeTypeCodeReferenceLogic = new IncomeTypeCodeReferenceLogic();

        public string SelectedIncomeTypeCode { get; private set; }

        public IncomeTypeCodeReferenceForm()
        {
            InitializeComponent();
        }

        private void IncomeTypeCodeReferenceForm_Load(object sender, EventArgs e)
        {
            incomeTypeCodeReferenceLogic.Bind(IncomeTypeCodeDataGridView);
            IncomeTypeCodeDataGridView.Columns[0].Width = 40;
            IncomeTypeCodeDataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True; 
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            SelectedIncomeTypeCode = incomeTypeCodeReferenceLogic[IncomeTypeCodeDataGridView.CurrentCell.RowIndex];
            Close();
        }
    }
}
