using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MineCrypto;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoPrivacy
{
    public partial class HashingOptionsForm : Form
    {
        public HashingOptionsForm()
        {
            InitializeComponent();
        }

        private void HashingOptionsForm_Load(object sender, EventArgs e)
        {
            Main GetIcon = new Main();
            this.Icon = GetIcon.Icon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new HashingForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new HMACHashingForm().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FileHashingForm().ShowDialog();
        }
    }
}
