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
    public partial class ScanResultsForm : Form
    {
        public ScanResultsForm()
        {
            InitializeComponent();
        }

        public void ChangeLabelFromAnotherForm(string ThreadName, string EncryptionUsed, string CodedOn, string EncryptionPowerRating)
        {
            label2.Text = ThreadName;
            label4.Text = EncryptionUsed;
            label8.Text = CodedOn;
            label6.Text = EncryptionPowerRating;
        }

        private void ScanResultsForm_Load(object sender, EventArgs e)
        {
            Main GetIcon = new Main();
            this.Icon = GetIcon.Icon;
        }
    }
}