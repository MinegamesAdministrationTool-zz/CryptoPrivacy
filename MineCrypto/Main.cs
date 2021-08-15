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
using System.Diagnostics;

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
            var PrioritySet = Process.GetCurrentProcess();
            PrioritySet.PriorityClass = ProcessPriorityClass.RealTime;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Program are a text encryptor and contains a file encryptor.", "About", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            new AES().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new TripleDES().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AESFileEncryptForm().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new HashingOptionsForm().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new UltimateEncryptionForm().ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new RSAEncryptionForm().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new AntiRansomwareForm().ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new RSAFileEncryptionForm().ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new MoreToolsForm().ShowDialog();
        }
    }
}
 