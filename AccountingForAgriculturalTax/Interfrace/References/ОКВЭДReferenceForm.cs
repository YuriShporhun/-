using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public partial class ОКВЭДReferenceForm : Form
    {
        public ОКВЭДReferenceForm()
        {
            InitializeComponent();
        }

        private void ОКВЭДReferenceForm_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("оквэд.рф"); 
        }
    }
}
