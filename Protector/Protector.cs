using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public class Protector
    {
        /// <summary>
        /// Данные, добавляемые к информации для шифрования до начала шифрования, чтобы недопустить взлома программы
        /// </summary>
        private const int salt = 1539673518;

        /// <summary>
        /// Путь к файлу, хранящему информацию о лицензионных ключах
        /// </summary>
        private string licensePath;

        public Protector(string licensePath)
        {
            this.licensePath = licensePath;
        }

        public List<KeyData> LoadKeyData()
        {
            List<KeyData> keyData = new List<KeyData>();

            if (!File.Exists(licensePath))
            {
                File.Create(licensePath).Close();
                return keyData;
            }

            using(StreamReader sr = new StreamReader(licensePath))
            {
                string line;
                while((line = sr.ReadLine()) != null)
                {
                    string [] keys = line.Split(' ');
                    KeyData key = new KeyData(keys[0], keys[2], keys[1]);
                    if(CheckKey(key.Key, new UserData(key.INN, key.Year)))
                    {
                        keyData.Add(key);
                    }
                }
            }

            return keyData;
        }

        public void SaveKey(KeyData key)
        {
            using(StreamWriter sw = new StreamWriter(licensePath, true))
            {
                sw.WriteLine(key.INN + " " + key.Key + " " + key.Year);
            }
        }

        public List<UserData> GetUsers()
        {
            List<UserData> userData = new List<UserData>();

            if (!File.Exists(licensePath))
            {
                return userData;
            }

            using (StreamReader sr = new StreamReader(licensePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] keys = line.Split(' ');
                    UserData tuserData = new UserData(keys[0], keys[2]);
                    userData.Add(tuserData);
                }
            }

            return userData;
        }

        public bool CheckKey(string Key, UserData userData)
        {
            return Decryptor.CheckKey(Key, userData);
        }
    }
}
