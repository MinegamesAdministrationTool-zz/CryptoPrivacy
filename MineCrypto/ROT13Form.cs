using MineCrypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoPrivacy
{
    public partial class ROT13Form : Form
    {
        public ROT13Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please Enter a Text To Encode.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                StringBuilder BuildText = new StringBuilder();
                Regex regex = new Regex("[A-Za-z]");
                foreach (char KSXZ in textBox1.Text)
                {
                    if (regex.IsMatch(KSXZ.ToString()))
                    {
                        int C = ((KSXZ & 223) - 52) % 26 + (KSXZ & 32) + 65;
                        BuildText.Append((char)C);
                    }
                }
                textBox1.Clear();
                textBox3.Text = BuildText.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please Enter a Text To Decode.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                StringBuilder BuildText = new StringBuilder();
                Regex regex = new Regex("[A-Za-z]");
                foreach (char KSXZ in textBox2.Text)
                {
                    int C = ((KSXZ & 223) - 52) % 26 + (KSXZ & 32) + 65;
                    BuildText.Append((char)C);
                }
                textBox2.Clear();
                textBox4.Text = BuildText.ToString();
            }
        }

        private void ROT13Form_Load(object sender, EventArgs e)
        {
            Main GetIcon = new Main();
            this.Icon = GetIcon.Icon;
        }
    }
}
