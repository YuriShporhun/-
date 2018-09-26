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
    public partial class WarningForm : Form
    {
        List<string> messages;

        public WarningForm(List<string> messages)
        {
            InitializeComponent();
            this.messages = messages;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WarningForm_Load(object sender, EventArgs e)
        {
            int index = 1;
            StringBuilder sb = new StringBuilder();
            foreach (var message in messages)
            {
                sb.Append(index + ".");
                sb.Append(message);
                sb.Append("\r\n");
                index++;
            }
            WarningTextBox.Text = sb.ToString();
        }

        private void WarningTextBox_ReadOnlyChanged(object sender, EventArgs e)
        {
            WarningTextBox.BackColor = Color.White;
        }
    }
}
