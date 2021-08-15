using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography;
using System.Drawing;
using System.Linq;
using System.Text;
using MineCrypto;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoPrivacy
{
    public partial class HMACHashingForm : Form
    {
        int HashType;
        public HMACHashingForm()
        {
            InitializeComponent();
        }

        private void HMACHashingForm_Load(object sender, EventArgs e)
        {
            Main GetIcon = new Main();
            this.Icon = GetIcon.Icon;
        }

        private void HashingHMACMD5(string Hash)
        {
            string Key = textBox2.Text;
            byte[] KeyToHash = Encoding.ASCII.GetBytes(Key);
            HMACMD5 MD5Hashing = new HMACMD5();
            MD5Hashing.Key = KeyToHash;
            var TheHash = MD5Hashing.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < TheHash.Length; i++)
            {
                builder.Append(TheHash[i].ToString("x2"));
            }
            textBox3.Text = builder.ToString();
        }

        private void HashingHMACSHA1(string Hash)
        {
            string Key = textBox2.Text;
            byte[] KeyToHash = Encoding.ASCII.GetBytes(Key);
            HMACSHA1 SHA1Hashing = new HMACSHA1();
            SHA1Hashing.Key = KeyToHash;
            var TheHash = SHA1Hashing.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < TheHash.Length; i++)
            {
                builder.Append(TheHash[i].ToString("x2"));
            }
            textBox3.Text = builder.ToString();
        }

        private void HashingHMACSHA256(string Hash)
        {
            string Key = textBox2.Text;
            byte[] KeyToHash = Encoding.ASCII.GetBytes(Key);
            HMACSHA256 SHA256Hashing = new HMACSHA256();
            SHA256Hashing.Key = KeyToHash;
            var TheHash = SHA256Hashing.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < TheHash.Length; i++)
            {
                builder.Append(TheHash[i].ToString("x2"));
            }
            textBox3.Text = builder.ToString();
        }

        private void HashingHMACSHA384(string Hash)
        {
            string Key = textBox2.Text;
            byte[] KeyToHash = Encoding.ASCII.GetBytes(Key);
            HMACSHA384 SHA384Hashing = new HMACSHA384();
            SHA384Hashing.Key = KeyToHash;
            var TheHash = SHA384Hashing.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < TheHash.Length; i++)
            {
                builder.Append(TheHash[i].ToString("x2"));
            }
            textBox3.Text = builder.ToString();
        }

        private void HashingHMACSHA512(string Hash)
        {
            string Key = textBox2.Text;
            byte[] KeyToHash = Encoding.ASCII.GetBytes(Key);
            HMACSHA512 SHA512Hashing = new HMACSHA512();
            SHA512Hashing.Key = KeyToHash;
            var TheHash = SHA512Hashing.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < TheHash.Length; i++)
            {
                builder.Append(TheHash[i].ToString("x2"));
            }
            textBox3.Text = builder.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("you have to put a password to hash with HMAC if you don't want to hash with password use the normal hashing form.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Please Enter a password or a text to hash with.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else
                {
                    if (HashType == 0)
                    {
                        MessageBox.Show("please use a hash to hash with.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                    else
                    {
                        switch (HashType)
                        {
                            case 1:
                                HashingHMACSHA512(textBox1.Text);
                                break;
                            case 2:
                                HashingHMACSHA384(textBox1.Text);
                                break;
                            case 3:
                                HashingHMACSHA256(textBox1.Text);
                                break;
                            case 4:
                                HashingHMACSHA1(textBox1.Text);
                                break;
                            case 5:
                                HashingHMACMD5(textBox1.Text);
                                break;
                        }
                    }
                }
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
