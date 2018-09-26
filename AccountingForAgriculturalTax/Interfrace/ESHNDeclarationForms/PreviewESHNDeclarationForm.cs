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
    public partial class PreviewESHNDeclarationForm : Form
    {
        string declarationPath;
        public PreviewESHNDeclarationForm(string declarationPath)
        {
            InitializeComponent();
            this.declarationPath = declarationPath;
        }

        private void PreviewESHNDeclarationForm_Load(object sender, EventArgs e)
        {
            if(!axAcroPDF1.LoadFile(declarationPath))
            {
                MessageBox.Show("Файл декларации уж открыт в другом приложении.");
            }
        }
    }
}
