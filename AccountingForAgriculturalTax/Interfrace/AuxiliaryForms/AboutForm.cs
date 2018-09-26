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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AdvPictureBox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://eshn-nalog.ru/");
        }

        private void ProgramChangesRichTextBox_ReadOnlyChanged(object sender, EventArgs e)
        {
            ProgramChangesRichTextBox.BackColor = Color.White;
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            this.Text = "Учет ЕСХН " + Constants.currentProgramVersion;
            ProgramChangesRichTextBox.Text = VersionChanges.Changes;
        }
    }
}
