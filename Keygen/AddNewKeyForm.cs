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
    public partial class AddNewKeyForm : Form
    {
        public DialogResult formResult { get; set; }

        public List<ClientInfo> clients = new List<ClientInfo>();

        const int StandartINNLength = 12;
        const int StandartYearLength = 4;

        public AddNewKeyForm(List<ClientInfo> clients)
        {
            InitializeComponent();

            closeButton.Click += (s, e) => Close();

            this.clients = clients;
        }

        private void INNTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SaltTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void YearTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void addKeyButton_Click(object sender, EventArgs e)
        {
            if (INNTextBox.Text.Length == 0)
            {
                MessageBox.Show("Заполните ИНН");
                return;
            }

            if(YearTextBox.Text.Length == 0)
            {
                MessageBox.Show("Заполните год");
                return;
            }

            if (INNTextBox.Text.Length != StandartINNLength)
            {
                MessageBox.Show("ИНН состоит из 12 цифр, а введено только " + INNTextBox.Text.Length);
                return;
            }

            if(YearTextBox.Text.Length != StandartYearLength)
            {
                MessageBox.Show("Год состоит из 4 цифр, а введено только " + YearTextBox.Text.Length);
                return;
            }

            ClientInfo client = new ClientInfo();

            client.INN = INNTextBox.Text;
            client.FIO = FIOTextBox.Text;
            client.Year = YearTextBox.Text;
            client.Salt = SaltTextBox.Text;
            client.Adress = AdressTextBox.Text;
            client.Email = EmailTextBox.Text;
            client.RegistrationDate = DateTime.Now.ToShortDateString();
            client.SetKey((new KeyGenerator(client.Year, client.INN)).GetKey());

            clients.Add(client);

            Close();
        }
    }
}
