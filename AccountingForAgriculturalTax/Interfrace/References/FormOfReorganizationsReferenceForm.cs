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
    public partial class FormOfReorganizationsReferenceForm : Form
    {
        public string SelectedFormOfReorganizationCode { get; private set; }

        FormOfReorganizationReferenceLogic formOfReorganizationReferenceLogic = new FormOfReorganizationReferenceLogic();

        public FormOfReorganizationsReferenceForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            SelectedFormOfReorganizationCode = formOfReorganizationReferenceLogic[FormOfReorganizationReferenceDataGridView.CurrentCell.RowIndex];
            Close();
        }

        private void FormOfReorganizationsReferenceForm_Load(object sender, EventArgs e)
        {
            formOfReorganizationReferenceLogic.Bind(FormOfReorganizationReferenceDataGridView);
            FormOfReorganizationReferenceDataGridView.Columns[0].Width = 40;
        }
    }
}
