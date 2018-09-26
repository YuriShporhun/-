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
    public partial class TaxPeriodReferenceForm : Form
    {
        public string SelectedTaxPeriodCode { get; private set; }

        TaxPeriodCodeReferenceLogic taxPeriodReferenceLogic = new TaxPeriodCodeReferenceLogic();

        public TaxPeriodReferenceForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetTaxPeriodCodeButton_Click(object sender, EventArgs e)
        {
            SelectedTaxPeriodCode = taxPeriodReferenceLogic[TaxPeriodReferenceDataGridView.CurrentCell.RowIndex];
            Close();
        }

        private void TaxPeriodReferenceForm_Load(object sender, EventArgs e)
        {
            taxPeriodReferenceLogic.Bind(TaxPeriodReferenceDataGridView);
            TaxPeriodReferenceDataGridView.Columns[0].Width = 40;
        }
    }
}
