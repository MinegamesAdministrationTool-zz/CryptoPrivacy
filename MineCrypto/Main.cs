using CryptoPrivacy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MineCrypto;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineCrypto
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Program are a text encryptor and contains a file encryptor.", "About", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new AES().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new TripleDES().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AESFileEncryptForm().Show();
        }
    }
}
 