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
    public partial class TaxAuthorityPlaceCodeReferenceForm : Form
    {
        public string SelectedTaxAuthorityPlaceCode { get; private set; }

        TaxAuthorityPlaceCodeReferenceLogic taxAuthorityPlaceCodeReferenceLogic = new TaxAuthorityPlaceCodeReferenceLogic();
        public TaxAuthorityPlaceCodeReferenceForm()
        {
            InitializeComponent();
        }

        private void TaxAuthorityPlaceCodeReferenceForm_Load(object sender, EventArgs e)
        {
            taxAuthorityPlaceCodeReferenceLogic.Bind(TaxAuthorityPlaceCodeDataGridView);
            TaxAuthorityPlaceCodeDataGridView.Columns[0].Width = 40;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            SelectedTaxAuthorityPlaceCode = taxAuthorityPlaceCodeReferenceLogic[TaxAuthorityPlaceCodeDataGridView.CurrentCell.RowIndex];
            Close();
        }
    }
}
