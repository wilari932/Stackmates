using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace StackMates
    {
        class Enkryption
        {


        public Enkryption()
        {

        }

            public string Encrypt( string plainText)
            {

                try
                {

                string pH = null;
                string sK = null;
                string vK = null;


                string path = @"Resources\Conf.txt";

                List<string> ReadLines = File.ReadAllLines(path).ToList();
                foreach (string lines in ReadLines)
                {
                 string[] entries = lines.Split(',');
                  pH = entries[1];
                  sK = entries[2];
                  vK = entries[2];
                }
               
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                byte[] keyBytes = new Rfc2898DeriveBytes(pH, Encoding.ASCII.GetBytes(sK)).GetBytes(256 / 8);
                var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
                var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(vK));

                byte[] cipherTextBytes;

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        cipherTextBytes = memoryStream.ToArray();
                        cryptoStream.Close();
                    }
                    memoryStream.Close();
                }

                return Convert.ToBase64String(cipherTextBytes);

               


             





            }
                catch (Exception e)
                {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return null;
               
                }
            }

        public string DecryptFromFile(string path)
        {
        
            string ReadLines = File.ReadAllText(path);
            Decrypt(ReadLines);
            return Decrypt(ReadLines);



        }











        public string Decrypt(string encryptedText)
        {
            try
            {
              

                string pH = null;
                string sK = null;
                string vK = null;
                string path = @"Resources\Conf.txt";

                List<string> ReadLines = File.ReadAllLines(path).ToList();
                foreach (string lines in ReadLines)
                {
                    string[] entries = lines.Split(',');
                    pH = entries[1];
                    sK = entries[2];
                    vK = entries[2];
                }
                byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
                byte[] keyBytes = new Rfc2898DeriveBytes(pH, Encoding.ASCII.GetBytes(sK)).GetBytes(256 / 8);
                var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

                var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(vK));
                var memoryStream = new MemoryStream(cipherTextBytes);
                var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();


            
                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());

            }
            catch
            {
                return null;
                
            }



        }


      











    }
}




