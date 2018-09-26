using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AccountingForAgriculturalTax
{
    public static class Decryptor
    {

        const int salt = 1539673518;
        public static bool CheckKey(string Key, UserData userData)
        {
            byte[] plainData = Encoding.ASCII.GetBytes(userData.Year + userData.INN + salt.ToString());

            StringBuilder sb = new StringBuilder();

            using (MD5 md5 = MD5.Create())
            {
                byte[] plainKey = md5.ComputeHash(plainData);

                for (int i = 0; i < plainKey.Length; i++)
                {
                    sb.Append(plainKey[i].ToString("X2"));
                }
            }

            if(Key  == sb.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
