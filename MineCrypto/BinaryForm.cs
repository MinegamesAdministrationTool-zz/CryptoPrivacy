using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MineCrypto;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoPrivacy
{
    public partial class BinaryForm : Form
    {
        public BinaryForm()
        {
            InitializeComponent();
        }

        public static string StringToBinary(string data) { StringBuilder sb = new StringBuilder(); foreach (char c in data.ToCharArray()) { sb.Append(Convert.ToString(c, 2).PadLeft(8, '0')); } return sb.ToString(); }
        public static string BinaryToString(string data) { List<Byte> byteList = new List<Byte>(); for (int i = 0; i < data.Length; i += 8) { byteList.Add(Convert.ToByte(data.Substring(i, 8), 2)); } return Encoding.ASCII.GetString(byteList.ToArray()); }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ConvertedText = StringToBinary(textBox1.Text);
                textBox1.Clear();
                textBox3.Text = ConvertedText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string UnConvertedText = BinaryToString(textBox2.Text);
                textBox2.Clear();
                textBox4.Text = UnConvertedText;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void BinaryForm_Load(object sender, EventArgs e)
        {
            Main GetIcon = new Main();
            this.Icon = GetIcon.Icon;
        }
    }
}
