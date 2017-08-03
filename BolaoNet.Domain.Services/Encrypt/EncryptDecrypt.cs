using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Encrypt
{
    public class EncryptDecrypt
    {
        #region Methods

        //public string Decrypt(string cipherString, bool useHashing)
        //{
        //    byte[] keyArray;
        //    //get the byte code of the string

        //    byte[] toEncryptArray = Convert.FromBase64String(cipherString);

        //    System.Configuration.AppSettingsReader settingsReader =
        //                                        new AppSettingsReader();
        //    //Get your key from config file to open the lock!
        //    string key = (string)settingsReader.GetValue("SecurityKey",
        //                                                 typeof(String));

        //    if (useHashing)
        //    {
        //        //if hashing was used get the hash code with regards to your key
        //        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        //        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        //        //release any resource held by the MD5CryptoServiceProvider

        //        hashmd5.Clear();
        //    }
        //    else
        //    {
        //        //if hashing was not implemented get the byte code of the key
        //        keyArray = UTF8Encoding.UTF8.GetBytes(key);
        //    }

        //    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        //    //set the secret key for the tripleDES algorithm
        //    tdes.Key = keyArray;
        //    //mode of operation. there are other 4 modes. 
        //    //We choose ECB(Electronic code Book)

        //    tdes.Mode = CipherMode.ECB;
        //    //padding mode(if any extra byte added)
        //    tdes.Padding = PaddingMode.PKCS7;

        //    ICryptoTransform cTransform = tdes.CreateDecryptor();
        //    byte[] resultArray = cTransform.TransformFinalBlock(
        //                         toEncryptArray, 0, toEncryptArray.Length);
        //    //Release resources held by TripleDes Encryptor                
        //    tdes.Clear();
        //    //return the Clear decrypted TEXT
        //    return UTF8Encoding.UTF8.GetString(resultArray);
        //}
        //public string Encrypt(string toEncrypt, bool useHashing)
        //{
        //    byte[] keyArray;
        //    byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        //    System.Configuration.AppSettingsReader settingsReader =
        //                                        new AppSettingsReader();
        //    // Get the key from config file

        //    string key = (string)settingsReader.GetValue("SecurityKey",
        //                                                     typeof(String));
        //    //System.Windows.Forms.MessageBox.Show(key);
        //    //If hashing use get hashcode regards to your key
        //    if (useHashing)
        //    {
        //        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        //        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        //        //Always release the resources and flush data
        //        // of the Cryptographic service provide. Best Practice

        //        hashmd5.Clear();
        //    }
        //    else
        //        keyArray = UTF8Encoding.UTF8.GetBytes(key);

        //    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        //    //set the secret key for the tripleDES algorithm
        //    tdes.Key = keyArray;
        //    //mode of operation. there are other 4 modes.
        //    //We choose ECB(Electronic code Book)
        //    tdes.Mode = CipherMode.ECB;
        //    //padding mode(if any extra byte added)

        //    tdes.Padding = PaddingMode.PKCS7;

        //    ICryptoTransform cTransform = tdes.CreateEncryptor();
        //    //transform the specified region of bytes array to resultArray
        //    byte[] resultArray =
        //      cTransform.TransformFinalBlock(toEncryptArray, 0,
        //      toEncryptArray.Length);
        //    //Release resources held by TripleDes Encryptor
        //    tdes.Clear();
        //    //Return the encrypted data into unreadable string format
        //    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        //}
        public string EncryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string result = Convert.ToBase64String(bytesEncrypted);

            return result;
        }
        public string DecryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }
        public byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }
        public byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }
        #endregion
    }
}
