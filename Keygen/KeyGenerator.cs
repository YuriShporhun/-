using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    class KeyGenerator
    {
        public string Year { get; private set; }
        public string INN { get; private set; }

        private const int salt = 1539673518;

        public KeyGenerator(string Year, string INN)
        {
            this.INN = INN;
            this.Year = Year;
        }

        public string GetKey()
        {
            byte[] plainData = Encoding.ASCII.GetBytes(Year + INN + salt.ToString());

            StringBuilder sb = new StringBuilder();

            using (MD5 md5 = MD5.Create())
            {
                byte[] plainKey = md5.ComputeHash(plainData);

                for (int i = 0; i < plainKey.Length; i++)
                {
                    sb.Append(plainKey[i].ToString("X2"));
                }
            }
            return sb.ToString();
        }
    }
}
