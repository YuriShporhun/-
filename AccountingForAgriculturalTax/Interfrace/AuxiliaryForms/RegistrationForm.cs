using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingForAgriculturalTax
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        public DialogResult formResult = DialogResult.No;

        private void registeringButton_Click(object sender, EventArgs e)
        {
            string Key = keyTextBox.Text;
            Protector protector = new Protector(Constants.licenseFullPath);
            UserData userData = new UserData(INNTextBox.Text, yearTextBox.Text);
            if(protector.CheckKey(Key, userData))
            {
                protector.SaveKey(new KeyData(INNTextBox.Text, yearTextBox.Text, Key));
                MessageBox.Show("Программа теперь зарегистрирована на " + yearTextBox.Text + " год");
                formResult = System.Windows.Forms.DialogResult.Yes;
                Close();
            }
            else
            {
                MessageBox.Show("Введенная вами информация не верна.");
            }
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            CheckINN();
            CheckKeys();
        }

        private void CheckKeys()
        {
            listOfKeysListBox.Items.Clear();
            Protector protector = new Protector(Constants.licenseFullPath);
            List<UserData> users = protector.GetUsers();
            foreach (var user in users)
            {
                listOfKeysListBox.Items.Add("Для ИНН: " + user.INN + " на " + user.Year + " год");
            }
        }

        private void CheckINN()
        {
            RequisiteSQLiteDataProvider dataProvider = new RequisiteSQLiteDataProvider();
            List<string> INNs = dataProvider.GetAllINN();
            INNTextBox.Items.Clear();
            foreach(var i in INNs)
            {
                INNTextBox.Items.Add(i);
            }
            if(INNTextBox.Items.Count > 0)
            {
                INNTextBox.SelectedIndex = 0;
            }
        }

        private void requisiteButton_Click(object sender, EventArgs e)
        {
            (new RequisiteForm()).ShowDialog();
            CheckINN();
            CheckKeys();
        }
    }
}
