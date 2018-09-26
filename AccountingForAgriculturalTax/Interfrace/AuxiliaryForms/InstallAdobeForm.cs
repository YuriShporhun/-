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
    public partial class InstallAdobeForm : Form
    {
        public InstallAdobeForm()
        {
            InitializeComponent();
        }

        private void InstallAdobeForm_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://get.adobe.com/ru/reader/");
        }
    }
}
