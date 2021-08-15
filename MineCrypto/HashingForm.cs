using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoPrivacy
{
    public partial class HashingForm : Form
    {
        int HashType;
        public HashingForm()
        {
            InitializeComponent();
        }

        private void HashingMD5(string Hash)
        {
            using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = MD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < keys.Length; i++)
                {
                    builder.Append(keys[i].ToString("x2"));
                }
                textBox3.Text = builder.ToString();
            }
        }

        private void HashingSHA1(string Hash)
        {
            using (SHA1CryptoServiceProvider SHA1 = new SHA1CryptoServiceProvider())
            {
                byte[] keys = SHA1.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < keys.Length; i++)
                {
                    builder.Append(keys[i].ToString("x2"));
                }
                textBox3.Text = builder.ToString();
            }
        }

        private void HashingSHA256(string Hash)
        {
            using (SHA256CryptoServiceProvider SHA256 = new SHA256CryptoServiceProvider())
            {
                byte[] keys = SHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < keys.Length; i++)
                {
                    builder.Append(keys[i].ToString("x2"));
                }
                textBox3.Text = builder.ToString();
            }
        }

        private void HashingSHA384(string Hash)
        {
            using (SHA384CryptoServiceProvider SHA384 = new SHA384CryptoServiceProvider())
            {
                byte[] keys = SHA384.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < keys.Length; i++)
                {
                    builder.Append(keys[i].ToString("x2"));
                }
                textBox3.Text = builder.ToString();
            }
        }

        private void HashingSHA512(string Hash)
        {
            using (SHA512CryptoServiceProvider SHA512 = new SHA512CryptoServiceProvider())
            {
                byte[] keys = SHA512.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < keys.Length; i++)
                {
                    builder.Append(keys[i].ToString("x2"));
                }
                textBox3.Text = builder.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            switch(HashType)
            {
                case 1:
                    HashingSHA512(textBox2.Text);
                    break;
                case 2:
                    HashingSHA384(textBox2.Text);
                    break;
                case 3:
                    HashingSHA256(textBox2.Text);
                    break;
                case 4:
                    HashingSHA1(textBox2.Text);
                    break;
                case 5:
                    HashingMD5(textBox2.Text);
                    break;
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

        private void HashingForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new HMACHashingForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FileHashingForm().Show();
        }
    }
}