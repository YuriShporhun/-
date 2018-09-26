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
    public partial class GuideToOperationsForm : Form
    {
        public GuideToOperationsForm()
        {
            InitializeComponent();
            closeButton.Click += (s, e) => Close();
        }

        private void GuideToOperationsForm_Load(object sender, EventArgs e)
        {
            MainForm.programLogic.guideToOperationsLogic.Load();
            UpdateList();
        }

        private void UpdateList()
        {
            guideToOperationsListBox.Items.Clear();
            for (int i = 0; i < MainForm.programLogic.guideToOperationsLogic.GetOperationsCount(); ++i)
            {
                guideToOperationsListBox.Items.Add(MainForm.programLogic.guideToOperationsLogic[i].Name);
            }
        }

        private void addGuideToOperationButton_Click(object sender, EventArgs e)
        {
            var addGuideToOperationForm = new AddGuideToOperationForm();
            addGuideToOperationForm.ShowDialog();
            if (addGuideToOperationForm.FormResult == System.Windows.Forms.DialogResult.Yes)
            {
                MainForm.programLogic.guideToOperationsLogic.Insert(new GuideToOperation(addGuideToOperationForm.GuideToOperationText));
                UpdateList();
            }
        }

        private void editGuideToOperationButton_Click(object sender, EventArgs e)
        {
            if (guideToOperationsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите справку по операции из списка.", "Предупреждение");
                return;
            }

            var addGuideToOperationForm = new AddGuideToOperationForm(MainForm.programLogic.guideToOperationsLogic[guideToOperationsListBox.SelectedIndex].Name);

            addGuideToOperationForm.ShowDialog();

            if (addGuideToOperationForm.FormResult == System.Windows.Forms.DialogResult.Yes)
            {
                MainForm.programLogic.guideToOperationsLogic.Update(
                    MainForm.programLogic.guideToOperationsLogic[guideToOperationsListBox.SelectedIndex], addGuideToOperationForm.GuideToOperationText);
                UpdateList();
            }
        }

        private void deleteGuideToOperationButton_Click(object sender, EventArgs e)
        {
            if (guideToOperationsListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите справку по операции из списка.", "Предупреждение");
                return;
            }
            var dialogResult = MessageBox.Show("Вы уверены, что хотите удалить запись ?", "Предупреждение", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                MainForm.programLogic.guideToOperationsLogic.Delete(guideToOperationsListBox.SelectedIndex);
                UpdateList();
            }
        }
    }
}
