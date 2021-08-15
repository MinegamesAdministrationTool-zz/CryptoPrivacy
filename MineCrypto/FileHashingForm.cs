using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MineCrypto;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoPrivacy
{
    public partial class FileHashingForm : Form
    {
        int HashType;
        public FileHashingForm()
        {
            InitializeComponent();
        }

        private void FileHashingForm_Load(object sender, EventArgs e)
        {
            Main GetIcon = new Main();
            this.Icon = GetIcon.Icon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDialogToHash = new OpenFileDialog();
            OpenDialogToHash.Title = "Select a File To Hash";
            if(OpenDialogToHash.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = OpenDialogToHash.FileName;
            }
        }

        private void HashingThreadForBigFiles()
        {
            try
            {
                FileStream GetFileToHash = new FileStream(textBox1.Text, FileMode.Open);
                switch (HashType)
                {
                    case 1:
                        SHA512CryptoServiceProvider SHA512 = new SHA512CryptoServiceProvider();
                        label3.Text = "Hashing....";
                        byte[] FileHashSHA512 = SHA512.ComputeHash(GetFileToHash);
                        string TheFinalHashSHA512 = BitConverter.ToString(FileHashSHA512).Replace("-", string.Empty).ToLower();
                        textBox2.Text = TheFinalHashSHA512;
                        GetFileToHash.Close();
                        label3.Text = "Done.";
                        break;
                    case 2:
                        SHA384CryptoServiceProvider SHA384 = new SHA384CryptoServiceProvider();
                        label3.Text = "Hashing....";
                        byte[] FileHashSHA384 = SHA384.ComputeHash(GetFileToHash);
                        string TheFinalHashSHA384 = BitConverter.ToString(FileHashSHA384).Replace("-", string.Empty).ToLower();
                        textBox2.Text = TheFinalHashSHA384;
                        GetFileToHash.Close();
                        label3.Text = "Done.";
                        break;
                    case 3:
                        SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider();
                        label3.Text = "Hashing....";
                        byte[] FileHashSHA256 = SHA256.ComputeHash(GetFileToHash);
                        string TheFinalHashSHA256 = BitConverter.ToString(FileHashSHA256).Replace("-", string.Empty).ToLower();
                        textBox2.Text = TheFinalHashSHA256;
                        GetFileToHash.Close();
                        label3.Text = "Done.";
                        break;
                    case 4:
                        SHA1CryptoServiceProvider SHA1 = new SHA1CryptoServiceProvider();
                        label3.Text = "Hashing....";
                        byte[] FileHashSHA1 = SHA1.ComputeHash(GetFileToHash);
                        string TheFinalHashSHA1 = BitConverter.ToString(FileHashSHA1).Replace("-", string.Empty).ToLower();
                        textBox2.Text = TheFinalHashSHA1;
                        GetFileToHash.Close();
                        label3.Text = "Done.";
                        break;
                    case 5:
                        MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                        label3.Text = "Hashing....";
                        byte[] FileHashMD5 = MD5.ComputeHash(GetFileToHash);
                        string TheFinalHashMD5 = BitConverter.ToString(FileHashMD5).Replace("-", string.Empty).ToLower();
                        textBox2.Text = TheFinalHashMD5;
                        GetFileToHash.Close();
                        label3.Text = "Done.";
                        break;
                    default:
                        MessageBox.Show("Please Select a hash mode to hash the File.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        break;
                }
                GetFileToHash.Close();
            }
            catch (Exception ex)
            {
                label3.Text = "Error";
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please Choose a File To Hash you Can't leave the textbox empty.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                Thread HashingThread = new Thread(new ThreadStart(HashingThreadForBigFiles));
                HashingThread.Priority = ThreadPriority.Highest;
                HashingThread.Start();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                HashType = 1;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
            }
            else
            {
                HashType = 0;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                HashType = 2;
                checkBox1.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
            }
            else
            {
                HashType = 0;
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                HashType = 3;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
            }
            else
            {
                HashType = 0;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                HashType = 4;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox5.Enabled = false;
            }
            else
            {
                HashType = 0;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox5.Enabled = true;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                HashType = 5;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
            else
            {
                HashType = 0;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
            }
        }
    }
}
