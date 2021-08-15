using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CryptoPrivacy
{
    public partial class AESFileEncryptForm : Form
    {
        public AESFileEncryptForm()
        {
            InitializeComponent();
        }

        private void EncryptionAndDecryption()
        {
            if (radioButton1.Checked == true)
            {
                try
                {
                    if (File.Exists(textBox2.Text))
                    {
                        EncryptFile(textBox2.Text, textBox1.Text);
                    }
                    else if (Directory.Exists(textBox2.Text))
                    {
                        var DirectoryAccept = MessageBox.Show("thats's a folder are you want to encrypt all it's content?", "folder", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (DirectoryAccept == DialogResult.Yes)
                        {
                            string path = textBox2.Text;
                            string[] files = Directory.GetFiles(path + @"\", "*", SearchOption.AllDirectories);
                            for (int i = 0; i < files.Length; i++)
                            {
                                label3.Text = "Encrypting.....";
                                EncryptFile(files[i], textBox2.Text);
                                label3.Text = "Done.";
                            }
                        }
                        else if (DirectoryAccept == DialogResult.No)
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("File or Directory does not exist.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to Encrypt Cause the Error: " + ex.Message + ", Please report that to my github page so i can provide you help.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else if (radioButton2.Checked == true)
            {
                try
                {
                    if (File.Exists(textBox2.Text))
                    {
                        DecryptFile(textBox2.Text, textBox1.Text);
                    }
                    else if (Directory.Exists(textBox2.Text))
                    {
                        var DirectoryAccept = MessageBox.Show("thats's a folder are you want to decrypt all it's content?", "folder", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (DirectoryAccept == DialogResult.Yes)
                        {
                            string path = textBox2.Text;
                            string[] files = Directory.GetFiles(path + @"\", "*", SearchOption.AllDirectories);
                            for (int i = 0; i < files.Length; i++)
                            {
                                label3.Text = "Decrypting....";
                                DecryptFile(files[i], textBox2.Text);
                                label3.Text = "Done.";
                            }
                        }
                        else if (DirectoryAccept == DialogResult.No)
                        {

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to Decrypt Cause the Error: " + ex.Message + ", Please Check your Password or Check that this file is AES Encrypted.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("you have to put a key to encrypt/decrypt that file. NOTE:you have to use a strong key for a harder decryption.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                Thread EncryptionAndDecryptionThread = new Thread(new ThreadStart(EncryptionAndDecryption));
                EncryptionAndDecryptionThread.Priority = ThreadPriority.Highest;
                var PrioritySet = Process.GetCurrentProcess();
                PrioritySet.PriorityClass = ProcessPriorityClass.RealTime;
                EncryptionAndDecryptionThread.Start();
            }
        }

        private static byte[] TheAESEncryptionBaby(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encrypted = null;

            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider())
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
                    encrypted = ms.ToArray();
                }
            }

            return encrypted;
        }

        public void EncryptFile(string file, string password)
        {

            byte[] bytesToBeEncrypted = File.ReadAllBytes(file);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = TheAESEncryptionBaby(bytesToBeEncrypted, passwordBytes);

            string fileEncrypted = file;

            File.WriteAllBytes(fileEncrypted, bytesEncrypted);
        }

        public void DecryptFile(string theEncryptedFile, string passwordfromtextbox)
        {

            byte[] bytesToBeDecrypted = File.ReadAllBytes(theEncryptedFile);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(passwordfromtextbox);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AESDecryption(bytesToBeDecrypted, passwordBytes);

            string file = theEncryptedFile;
            File.WriteAllBytes(file, bytesDecrypted);
        }

        public static byte[] AESDecryption(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (AesCryptoServiceProvider AES = new AesCryptoServiceProvider())
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

        private void AESFileEncryptForm_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        public string RandomPassword(int PasswordLength)
        {
            StringBuilder MakePassword = new StringBuilder();
            Random MakeRandom = new Random();
            while (0 < PasswordLength--)
            {
                string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ*!@=&?&/abcdefghijklmnopqrstuvwxyz1234567890";
                MakePassword.Append(characters[MakeRandom.Next(characters.Length)]);
            }
            return MakePassword.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = RandomPassword(24);
        }
    }
}
