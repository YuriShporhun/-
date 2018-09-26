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
    public partial class SelectGuideToOperationForm : Form
    {
        public string SelectedGuideToOperationText;
        public DialogResult formResult;

        public SelectGuideToOperationForm()
        {
            InitializeComponent();
        }

        private void SelectGuideToOperation_Load(object sender, EventArgs e)
        {
            MainForm.programLogic.guideToOperationsLogic.Load();
            UpdateList();
        }

        private void UpdateList()
        {
            for (int i = 0; i < MainForm.programLogic.guideToOperationsLogic.GetOperationsCount(); ++i)
            {
                guideToOperationsListBox.Items.Add(MainForm.programLogic.guideToOperationsLogic[i].Name);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            formResult = System.Windows.Forms.DialogResult.No;
            Close();
        }

        private void SelectGuideButton_Click(object sender, EventArgs e)
        {
            if(guideToOperationsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите операцию из справочника", "Предупреждение");
                return;
            }
            formResult = System.Windows.Forms.DialogResult.Yes;
            SelectedGuideToOperationText = guideToOperationsListBox.Items[guideToOperationsListBox.SelectedIndex].ToString();
            Close();
        }
    }
}
