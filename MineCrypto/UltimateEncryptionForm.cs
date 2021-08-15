using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.AccessControl;
using System.Security.Authentication;
using System.Security.Permissions;
using CryptoPrivacy.Properties;
using CryptoPrivacy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MineCrypto;
using Microsoft.Win32;

namespace CryptoPrivacy
{
    public partial class UltimateEncryptionForm : Form
    {
        bool CheckForConfirmation;
        string OneTimePass = "P4TPi4unizhd*4hp^fC$SnCZQ230haI1!60m*eZi2&0kQrcIYF";
        string SecondTimePass = "wr&A@2FBrGxB82oW4ZJkY3*v9x81MdETe59LHFi1sVlKqm1j38";
        string ThirdTimePass = "ttf%vxHS%fv!s!%0lMvacHdn2WEW$7h1UPu4FcsZX5YuFjFbj&";
        string FourthTimePass = "a&VXAiO%$K1wEdOo$chH9mN$5m!scCNzyK5bjFlTU*uQiXb!K0";
        string FifthTimePass = "XwXrcl0o$M@qQeNu4VR0Pk#^$KNL5D8hqEwwa7$WnXtB3xlzJH";
        string DataFromLatestEncryptedText;

        public UltimateEncryptionForm()
        {
            InitializeComponent();
        }

        private void GetIfAccepted()
        {
            RegistryKey ConfirmationKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE", true);
            if (ConfirmationKey.GetSubKeyNames().Contains("CryptoPrivacy"))
            {
                RegistryKey ConfirmationCheck = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\CryptoPrivacy", true);
                if (ConfirmationCheck.GetValueNames().Contains("AlwaysUseSamePubAndPrivKey"))
                {
                    CheckForConfirmation = true;
                }
            }
        }

        private void UltimateEncryptionForm_Load(object sender, EventArgs e)
        {
            Main GetIcon = new Main();
            this.Icon = GetIcon.Icon;
        }

        private void EncryptOneTime()
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(textBox1.Text);
            using (SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider())
            {
                byte[] keys = SHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(OneTimePass));
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider() { Key = keys, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
                {
                    string initVector = "#xlZ*SDrxl8iDy%z";
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    AES.IV = initVectorBytes;
                    ICryptoTransform transform = AES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox1.Text = Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        private void EncryptTwoTime()
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(textBox1.Text);
            using (SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider())
            {
                byte[] keys = SHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecondTimePass));
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider() { Key = keys, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
                {
                    string initVector = "XePIi@wUsS8GUwPN";
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    AES.IV = initVectorBytes;
                    ICryptoTransform transform = AES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox1.Text = Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        private void EncryptThreeTimes()
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(textBox1.Text);
            using (SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider())
            {
                byte[] keys = SHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(ThirdTimePass));
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider() { Key = keys, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
                {
                    string initVector = "6Sg#@cLOUf@Mhufv";
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    AES.IV = initVectorBytes;
                    ICryptoTransform transform = AES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox1.Text = Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        private void EncryptFourTimes()
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(textBox1.Text);
            using (SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider())
            {
                byte[] keys = SHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(FourthTimePass));
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider() { Key = keys, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
                {
                    string initVector = "W&ZMhBhkOTCX@F@G";
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    AES.IV = initVectorBytes;
                    ICryptoTransform transform = AES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox1.Text = Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        private void EncryptFiveTimes()
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(textBox1.Text);
            using (SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider())
            {
                byte[] keys = SHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(FifthTimePass));
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider() { Key = keys, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
                {
                    string initVector = "uQC%biqjziiI*ftJ";
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    AES.IV = initVectorBytes;
                    ICryptoTransform transform = AES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox1.Clear();
                    if (CheckForConfirmation)
                    {
                        DataFromLatestEncryptedText = Convert.ToBase64String(results, 0, results.Length);
                    }
                    else
                    {
                        textBox3.Text = Convert.ToBase64String(results, 0, results.Length);
                    }
                }
            }
        }

        private static string Encrypt(string textToEncrypt, string publicKeyString, int keysize)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(textToEncrypt);

            using (var RSAEncryption = new RSACryptoServiceProvider(keysize))
            {
                try
                {
                    RSAEncryption.FromXmlString(publicKeyString.ToString());
                    var encryptedData = RSAEncryption.Encrypt(bytesToEncrypt, true);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    return base64Encrypted;
                }
                finally
                {
                    RSAEncryption.PersistKeyInCsp = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetIfAccepted();
            //4Io5l1RRboS2jqGE2VJyZfZq4XF8Xvov9iH27wtSRFY0jRahw2tXgdLCkd1kJfGTGRod3uk4LmSQMEvqCnoGEdn8rmwERjK4EDGWJuxyVZErlmygibRz+7KvbrRtFhoo5t5dCzxB+k21NEkBs1Gp3w==
            EncryptOneTime();
            EncryptTwoTime();
            EncryptThreeTimes();
            EncryptFourTimes();
            EncryptFiveTimes();
            if (CheckForConfirmation == true)
            {
                string GetPublicKeyFromSameDirectory = File.ReadAllText(Environment.CurrentDirectory + @"\publickey.txt");
                string EncryptedText = Encrypt(DataFromLatestEncryptedText, GetPublicKeyFromSameDirectory, 1024);
                textBox3.Text = EncryptedText;
            }
        }

        private static string Decrypt(string textToDecrypt, string privateKey, int keysize)
        {
            using (var RSADecrypt = new RSACryptoServiceProvider(keysize))
            {
                try
                {
                    RSADecrypt.FromXmlString(privateKey);

                    var resultBytes = Convert.FromBase64String(textToDecrypt);
                    var decryptedBytes = RSADecrypt.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    RSADecrypt.PersistKeyInCsp = false;
                }
            }
        }

        private void DecryptOneTimes()
        {
            byte[] data = Convert.FromBase64String(textBox2.Text);
            using (SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider())
            {
                byte[] keys = SHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(FifthTimePass));
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider() { Key = keys, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
                {
                    string initVector = "uQC%biqjziiI*ftJ";
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    AES.IV = initVectorBytes;
                    ICryptoTransform transform = AES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox2.Text = UTF8Encoding.UTF8.GetString(results);
                }
            }
        }

        private void DecryptTwoTimes()
        {
            byte[] data = Convert.FromBase64String(textBox2.Text);
            using (SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider())
            {
                byte[] keys = SHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(FourthTimePass));
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider() { Key = keys, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
                {
                    string initVector = "W&ZMhBhkOTCX@F@G";
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    AES.IV = initVectorBytes;
                    ICryptoTransform transform = AES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox2.Text = UTF8Encoding.UTF8.GetString(results);
                }
            }
        }

        private void DecryptThreeTimes()
        {
            byte[] data = Convert.FromBase64String(textBox2.Text);
            using (SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider())
            {
                byte[] keys = SHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(ThirdTimePass));
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider() { Key = keys, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
                {
                    string initVector = "6Sg#@cLOUf@Mhufv";
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    AES.IV = initVectorBytes;
                    ICryptoTransform transform = AES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox2.Text = UTF8Encoding.UTF8.GetString(results);
                }
            }
        }

        private void DecryptFourTimes()
        {
            byte[] data = Convert.FromBase64String(textBox2.Text);
            using (SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider())
            {
                byte[] keys = SHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecondTimePass));
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider() { Key = keys, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
                {
                    string initVector = "XePIi@wUsS8GUwPN";
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    AES.IV = initVectorBytes;
                    ICryptoTransform transform = AES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox2.Text = UTF8Encoding.UTF8.GetString(results);
                }
            }
        }

        private void DecryptFiveTimes()
        {
            byte[] data = Convert.FromBase64String(textBox2.Text);
            using (SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider())
            {
                byte[] keys = SHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(OneTimePass));
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider() { Key = keys, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 })
                {
                    string initVector = "#xlZ*SDrxl8iDy%z";
                    byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                    AES.IV = initVectorBytes;
                    ICryptoTransform transform = AES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    textBox2.Clear();
                    textBox4.Text = UTF8Encoding.UTF8.GetString(results);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetIfAccepted();
            if (CheckForConfirmation == true)
            {
                string GetPrivateKeyFromSameDirectory = File.ReadAllText(Environment.CurrentDirectory + @"\privatekey.txt");
                string DecryptedText = Decrypt(textBox2.Text, GetPrivateKeyFromSameDirectory, 1024);
                textBox2.Text = DecryptedText;
            }
            DecryptOneTimes();
            DecryptTwoTimes();
            DecryptThreeTimes();
            DecryptFourTimes();
            DecryptFiveTimes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetIfAccepted();
            if (CheckForConfirmation == true)
            {
                MessageBox.Show("this will encrypt the text five times with AES-256 CBC (Different IV's and passwords) after that it will be encrypted again with RSA with a keysize of 1024 (encrypting with public key and decrypting with private key)", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("this will encrypt the text five times with AES-256 CBC (Different IV's and passwords)", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
        }
    }
}
