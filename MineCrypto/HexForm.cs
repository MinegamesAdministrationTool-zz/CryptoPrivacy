using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MineCrypto;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoPrivacy
{
    public partial class HexForm : Form
    {
        public HexForm()
        {
            InitializeComponent();
        }

        private void HexForm_Load(object sender, EventArgs e)
        {
            Main GetIcon = new Main();
            this.Icon = GetIcon.Icon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please Enter a text to hex", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                var GetTextToHEX = Encoding.Unicode.GetBytes(textBox1.Text);
                var BuildHEX = new StringBuilder();
                foreach (var FinalHEX in GetTextToHEX)
                {
                    BuildHEX.Append(FinalHEX.ToString("X2"));
                }
                textBox1.Clear();
                textBox3.Text = BuildHEX.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please Enter a text to unhex", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                var Hex = new byte[textBox2.Text.Length / 2];
                for (var i = 0; i < Hex.Length; i++)
                {
                    Hex[i] = Convert.ToByte(textBox2.Text.Substring(i * 2, 2), 16);
                }
                textBox2.Clear();
                textBox4.Text = Encoding.Unicode.GetString(Hex);
            }
        }
    }
}
