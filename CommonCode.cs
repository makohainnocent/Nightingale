using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nightingale.Common
{
    public static class Functions
    {
        public static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the input string to bytes and compute the hash
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Convert the hash bytes to a hexadecimal string
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("X2"));
                }

                return stringBuilder.ToString();
            }
        }

        public static void closeApplication()
        {
            Application.Exit();
        }

    }
}
