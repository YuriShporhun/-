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
    public partial class AddGuideToOperationForm : Form
    {
        public DialogResult FormResult { get; set; }
        public String GuideToOperationText { get; set; }
        public AddGuideToOperationForm()
        {
            InitializeComponent();
            this.Text = "Добавление справки по операции";
            this.addGuideToOperationButton.Text = "Добавить";
        }

        public AddGuideToOperationForm(string initialText)
        {
            InitializeComponent();
            guideToOperationsTextBox.Text = initialText;
            this.Text = "Редактирование справки по операции";
            this.addGuideToOperationButton.Text = "Редактировать";
        }

        private void AddGuideToOperationForm_Load(object sender, EventArgs e)
        {
            closeButton.Click += (s, o) =>
            {
                Close();
            };

            addGuideToOperationButton.Click += (s, o) =>
            {
                if (guideToOperationsTextBox.Text == "")
                {
                    MessageBox.Show("Введите текст справки по операции.", "Предупреждение");
                    return;
                }
                FormResult = System.Windows.Forms.DialogResult.Yes;
                GuideToOperationText = guideToOperationsTextBox.Text;
                Close();
            };
        }
    }
}
