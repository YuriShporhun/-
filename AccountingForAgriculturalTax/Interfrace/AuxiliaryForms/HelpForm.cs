using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public partial class HelpForm : Form
    {
        string helpString;

        public HelpForm(string helpString)
        {
            InitializeComponent();
            this.helpString = helpString;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            HelpTextBox.Text = helpString;
        }
    }
}
