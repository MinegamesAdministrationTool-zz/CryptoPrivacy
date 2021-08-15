using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MineCrypto;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoPrivacy
{
    public partial class RSAEncryptionForm : Form
    {
        bool CheckForTheConfirmation;
        string privateKeyString;
        public RSAEncryptionForm()
        {
            InitializeComponent();
        }

        public static string GetKeyToString(RSAParameters publicKey)
        {
            var stringWriter = new StringWriter();
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(stringWriter, publicKey);
            return stringWriter.ToString();
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

        private void RSAEncryptionForm_Load(object sender, EventArgs e)
        {
            Main GetIcon = new Main();
            this.Icon = GetIcon.Icon;
        }

        private void GetIfAccepted()
        {
            RegistryKey ConfirmationKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE", true);
            if (ConfirmationKey.GetSubKeyNames().Contains("CryptoPrivacy"))
            {
                RegistryKey ConfirmationCheck = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\CryptoPrivacy", true);
                if (ConfirmationCheck.GetValueNames().Contains("AlwaysUseSamePubAndPrivKey"))
                {
                    CheckForTheConfirmation = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("the To Encrypt Textbox cannot be leaved empty.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    GetIfAccepted();
                    if (CheckForTheConfirmation == true)
                    {
                        string GetPublicKeyFromSameDirectory = File.ReadAllText(Environment.CurrentDirectory + @"\publickey.txt");
                        string EncryptedText = Encrypt(textBox1.Text, GetPublicKeyFromSameDirectory, 4096);
                        textBox1.Clear();
                        textBox3.Text = EncryptedText;
                    }
                    else
                    {
                        var RSAEncryption = new RSACryptoServiceProvider(4096);
                        var privateKey = RSAEncryption.ExportParameters(true);
                        var publicKey = RSAEncryption.ExportParameters(false);
                        string publicKeyString = GetKeyToString(publicKey);
                        privateKeyString = GetKeyToString(privateKey);
                        string EncryptedText = Encrypt(textBox1.Text, publicKeyString, 4096);
                        textBox1.Clear();
                        textBox3.Text = EncryptedText;
                        File.WriteAllText(Environment.CurrentDirectory + @"\publickey.txt", publicKeyString);
                        File.WriteAllText(Environment.CurrentDirectory + @"\privatekey.txt", privateKeyString);
                        MessageBox.Show("private and public key that generated and used for encryption saved on the current executable directory.", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        var Confirmation = MessageBox.Show("are you wanna always use the specified private and public keys for encryption and decryption?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (Confirmation == DialogResult.Yes)
                        {
                            RegistryKey Confirmed = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\CryptoPrivacy");
                            Confirmed.SetValue("AlwaysUseSamePubAndPrivKey", "a", RegistryValueKind.String);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("the To Decrypt Textbox cannot be leaved empty.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    GetIfAccepted();
                    if (CheckForTheConfirmation == true)
                    {
                        string GetPrivateKeyFromSameDirectory = File.ReadAllText(Environment.CurrentDirectory + @"\privatekey.txt");
                        string DecryptedText = Decrypt(textBox2.Text, GetPrivateKeyFromSameDirectory, 4096);
                        textBox2.Clear();
                        textBox4.Text = DecryptedText;
                    }
                    else
                    {
                        string DecryptedText = Decrypt(textBox2.Text, privateKeyString, 4096);
                        textBox4.Text = DecryptedText;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Form uses RSA with a key size of 4096 with OAEP padding and uses public key for encryption and private key for decryption.", "Algoritohm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}