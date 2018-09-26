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
    public partial class MainForm : Form
    {
        List<ClientInfo> clients = new List<ClientInfo>();

        string currentDirectory = Environment.CurrentDirectory;
        string clientDataPath = "\\ClientData.xml";
        string backupPath = "\\backups\\";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DataLoader dataLoader = new DataLoader();
            dataLoader.LoadData(currentDirectory + clientDataPath, clients);
            UpdateClientsGridView();
        }

        private void AddNewKeyButton_Click(object sender, EventArgs e)
        {
            AddNewKeyForm addNewKeyForm = new AddNewKeyForm(clients);
            addNewKeyForm.ShowDialog();
            UpdateClientsGridView();
        }

        private void UpdateClientsGridView()
        {
            BindingSource clientsBindingSource = new BindingSource();
            clientsBindingSource.DataSource = clients;
            clientsDataGridView.DataSource = clientsBindingSource;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataLoader loader = new DataLoader();
            loader.SaveData(currentDirectory + clientDataPath, clients);

            string correctDate =  DateTime.Now.ToString().Replace(':', '_');

            if(!Directory.Exists(currentDirectory + backupPath))
            {
                Directory.CreateDirectory(currentDirectory + backupPath);
            }

            if (!File.Exists(currentDirectory + backupPath + "ClientData" + correctDate + ".xml"))
            {
                File.Create(currentDirectory + backupPath + "ClientData" + correctDate + ".xml").Close();
            }
            loader.SaveData(currentDirectory + backupPath + "ClientData" + correctDate + ".xml", clients);
          
        }

        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Вы уверены, что хотите удалить данную запись ?", "Предупреждение", MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                clients.RemoveAt(clientsDataGridView.CurrentCell.RowIndex);
            }
            UpdateClientsGridView();
        }

        private void copyKeyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(clients[clientsDataGridView.CurrentCell.RowIndex].Key);
        }
    }
}
