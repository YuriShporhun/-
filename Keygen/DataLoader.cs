using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AccountingForAgriculturalTax
{
    class DataLoader
    {
        public void SaveData(string fileName, List<ClientInfo> clients)
        {
            var xEle = new XElement("KeyData",
                new XElement("Clients",
                    from client in clients
                    select new XElement("Client",
                        new XElement("Adress", client.Adress),
                        new XElement("Email", client.Email),
                        new XElement("FIO", client.FIO),
                        new XElement("INN", client.INN),
                        new XElement("Key", client.Key),
                        new XElement("RegistrationDate", client.RegistrationDate),
                        new XElement("Salt", client.Salt),
                        new XElement("Year", client.Year)))
                );

            using(StreamWriter sw = new StreamWriter(fileName))
            {
                xEle.Save(sw);
            }
        }

        public void LoadData(string fileName, List<ClientInfo> clients)
        {

            XDocument xdoc = XDocument.Load(fileName);

            var series = from srs in xdoc.Descendants("Client")
                         select new 
                         {
                             Adress = srs.Descendants("Adress").First(),
                             Email = srs.Descendants("Email").First(),
                             FIO = srs.Descendants("FIO").First(),
                             INN = srs.Descendants("INN").First(),
                             Key = srs.Descendants("Key").First(),
                             RegistrationDate = srs.Descendants("RegistrationDate").First(),
                             Salt = srs.Descendants("Salt").First(),
                             Year = srs.Descendants("Year").First()
                         };

            foreach(var srs in series)
            {
                ClientInfo client = new ClientInfo();

                client.Adress = srs.Adress.Value;
                client.Email = srs.Email.Value;
                client.FIO = srs.FIO.Value;
                client.INN = srs.INN.Value;
                client.SetKey(srs.Key.Value);
                client.RegistrationDate = srs.RegistrationDate.Value;
                client.Salt = srs.Salt.Value;
                client.Year = srs.Year.Value;

                clients.Add(client);
            }
        }
    }
}
