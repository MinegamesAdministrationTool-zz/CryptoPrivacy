using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MineCrypto;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoPrivacy
{
    public partial class MoreToolsForm : Form
    {
        public MoreToolsForm()
        {
            InitializeComponent();
        }

        private void MoreToolsForm_Load(object sender, EventArgs e)
        {
            Main GetIcon = new Main();
            this.Icon = GetIcon.Icon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new BinaryForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Base64EncodeForm().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MinegamesAdministrationTool/CryptoPrivacy/issues/new");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new HexForm().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new ROT13Form().ShowDialog();
        }
    }
}
