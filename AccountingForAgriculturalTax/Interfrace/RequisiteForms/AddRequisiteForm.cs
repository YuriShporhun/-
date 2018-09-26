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
    public partial class AddRequisiteForm : Form
    {
        public bool wasNewUserAdded = false;

        public AddRequisiteForm()
        {
            InitializeComponent();
            INNTextBox.KeyPress += TextBoxProcessor.ProcessOnlyDigits;
            INNTextBox.MaxLength = Constants.requiredINNLength;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if (INNTextBox.Text.Length != Constants.requiredINNLength)
            {
                MessageBox.Show("Некорректная длина ИНН налогоплательщика. Если у Вас ООО и в ИНН 10 символов, то первыми укажите два нуля и далее Ваш ИНН.", "Предупреждение");
                INNTextBox.BackColor = Constants.badFieldColor;
                return;
            }
            else
            {
                INNTextBox.BackColor = SystemColors.Window;
            }

            var dialogResult = MessageBox.Show("Вы уверены, что хотите добавить пользователя с ИНН " + INNTextBox.Text + " ?", "Уведомление", MessageBoxButtons.YesNo);
            
            if(dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                RequisiteSQLiteDataProvider requisiteDataProvider = new RequisiteSQLiteDataProvider();
                List<string> innList = requisiteDataProvider.GetAllINN();
                string newInn = INNTextBox.Text;

                if(innList.Contains(newInn))
                {
                    MessageBox.Show("Пользователь с данным ИНН уже есть");
                    return;
                }

                requisiteDataProvider.InsertNewINN(newInn);
                wasNewUserAdded = true;
            }
            Close();
        }
    }
}
