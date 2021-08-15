using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MineCrypto;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoPrivacy
{
    public partial class Base64EncodeForm : Form
    {
        public Base64EncodeForm()
        {
            InitializeComponent();
        }

        private void Base64EncodeForm_Load(object sender, EventArgs e)
        {
            Main GetIcon = new Main();
            this.Icon = GetIcon.Icon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Do You want me to encode the air?", "Base64", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                var UTF8Enc = UTF8Encoding.UTF8.GetBytes(textBox1.Text);
                string Base64TextEncoded = Convert.ToBase64String(UTF8Enc);
                textBox1.Clear();
                textBox3.Text = Base64TextEncoded;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Do You want me to decode the air?", "Base64", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                var Base64EncodedText = Convert.FromBase64String(textBox2.Text);
                var UTF8Enc = UTF8Encoding.UTF8.GetString(Base64EncodedText);
                textBox2.Clear();
                textBox4.Text = UTF8Enc;
            }
        }
    }
}
