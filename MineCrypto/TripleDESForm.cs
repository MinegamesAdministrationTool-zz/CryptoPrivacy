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

namespace MineCrypto
{
    public partial class TripleDES : Form
    {
        public TripleDES()
        {
            InitializeComponent();
        }

        string Hash = "Un77bo3aJi3K2eWGPeDgY3YaMOdXJP2yYjqLOz3EdnhgBUOpLp";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(textBox1.Text);
                using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = MD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateEncryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        textBox3.Text = Convert.ToBase64String(results, 0, results.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ", Please report that error to my github page to get help (im really happy to provide help)", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data = Convert.FromBase64String(textBox2.Text);
                using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = MD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Hash));
                    using (TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = DES.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        textBox4.Text = UTF8Encoding.UTF8.GetString(results);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + ", Please report that error to my github page to get help (im really happy to provide help)", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
    }
}
