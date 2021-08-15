using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MineCrypto;
using System.IO;
using System.Security.Cryptography;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoPrivacy
{
    public partial class RSAFileEncryptionForm : Form
    {
        bool IsAntiClosingActive;
        public RSAFileEncryptionForm()
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

        private void RSAFileEncryptionForm_Load(object sender, EventArgs e)
        {
            Main GetIcon = new Main();
            this.Icon = GetIcon.Icon;
        }

        public void EncryptFile(string FileToEncrypt, string publickey)
        {
            string FileToEncryptWithRSA = File.ReadAllText(FileToEncrypt);

            publickey = File.ReadAllText(publickey);

            FileToEncryptWithRSA = Encrypt(FileToEncryptWithRSA, publickey, 4096);

            string fileEncrypted = FileToEncrypt;

            File.WriteAllText(fileEncrypted, FileToEncryptWithRSA);
        }

        public void DecryptFile(string FileToDecrypt, string privatekey)
        {
            string FileToDecryptWithRSA = File.ReadAllText(FileToDecrypt);

            privatekey = File.ReadAllText(privatekey);

            FileToDecryptWithRSA = Decrypt(FileToDecryptWithRSA, privatekey, 4096);

            string fileEncrypted = FileToDecrypt;

            File.WriteAllText(fileEncrypted, FileToDecryptWithRSA);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog GetKeyFile = new OpenFileDialog();
            if(GetKeyFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = GetKeyFile.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                if(string.IsNullOrEmpty(textBox1.Text) == true)
                {
                    MessageBox.Show("Please Select the rsa key file to encrypt with.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        EncryptFile(textBox2.Text, textBox1.Text);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
            else if(radioButton2.Checked == true)
            {
                if (string.IsNullOrEmpty(textBox1.Text) == true)
                {
                    MessageBox.Show("Please Select the rsa key file to encrypt with.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        DecryptFile(textBox2.Text, textBox1.Text);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog GetKeyFile = new OpenFileDialog();
            if (GetKeyFile.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = GetKeyFile.FileName;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Private Key File:";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Public Key File:";
        }

        public void CreateKeysThread()
        {
            try
            {
                IsAntiClosingActive = true;
                var RSAEncryption = new RSACryptoServiceProvider(4096);
                var privateKey = RSAEncryption.ExportParameters(true);
                var publicKey = RSAEncryption.ExportParameters(false);
                string publicKeyString = GetKeyToString(publicKey);
                string privateKeyString = GetKeyToString(privateKey);
                File.WriteAllText(Environment.CurrentDirectory + @"\publickeyfileEncryption.txt", publicKeyString);
                File.WriteAllText(Environment.CurrentDirectory + @"\privatekeyfileDecryption.txt", privateKeyString);
                IsAntiClosingActive = false;
                MessageBox.Show("Keys have been generated!", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread GenerateKeys = new Thread(new ThreadStart(CreateKeysThread));
            GenerateKeys.Priority = ThreadPriority.Highest;
            GenerateKeys.Start();
        }

        private void RSAFileEncryptionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(IsAntiClosingActive == true)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
