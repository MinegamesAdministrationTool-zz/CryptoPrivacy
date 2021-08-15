using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MineCrypto;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Threading;

namespace CryptoPrivacy
{
    public partial class AntiRansomwareForm : Form
    {
        public AntiRansomwareForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog GetFileToScan = new OpenFileDialog();
            GetFileToScan.Title = "Choose File To Scan";
            if(GetFileToScan.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = GetFileToScan.FileName;
            }
        }

        private void AntiRansomwareForm_Load(object sender, EventArgs e)
        {
            Main GetIcon = new Main();
            this.Icon = GetIcon.Icon;
        }

        private void ScanningThread()
        {
            try
            {
                ScanResultsForm Customize = new ScanResultsForm();
                FileStream GetFileToHash = new FileStream(textBox1.Text, FileMode.Open);
                MD5CryptoServiceProvider GetHashFromFile = new MD5CryptoServiceProvider();
                byte[] GetTheHash = GetHashFromFile.ComputeHash(GetFileToHash);
                string Hash = BitConverter.ToString(GetTheHash).Replace("-", string.Empty).ToLower();
                textBox2.Text = Hash;
                switch (Hash)
                {
                    case "cf66108354123c80adb2cd14837e7961":
                        Customize.ChangeLabelFromAnotherForm("Mionoho 2.0 Ransomware (made by me for fun)", ".NET", "AES-256 CBC", "8/10");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("Mionoho 2.0 Ransomware (made by me for fun)", ".NET", "AES-256 CBC", "8/10");
                        break;
                    case "9f8bc96c96d43ecb69f883388d228754":
                        Customize.ChangeLabelFromAnotherForm("7ev3n Ransomware", "Not Sure", "Generic", "N/A");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("7ev3n Ransomware", "Not Sure", "Generic", "N/A");
                        break;
                    case "41789c704a0eecfdd0048b4b4193e752":
                        Customize.ChangeLabelFromAnotherForm("Birele Ransomware", "Unknown", "PE32 Executable (UPX)", "N/A");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("Birele Ransomware", "Unknown", "PE32 Executable (UPX)", "N/A");
                        break;
                    case "fe1bc60a95b2c2d77cd5d232296a7fa4":
                        Customize.ChangeLabelFromAnotherForm("Cerber", "RSA and RC4", "Microsoft Visual C++", "10/10");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("Cerber", "RSA and RC4", "Microsoft Visual C++", "10/10");
                        break;
                    case "b805db8f6a84475ef76b795b0d1ed6ae":
                        Customize.ChangeLabelFromAnotherForm("InfinityCrypt", "Rijandel / AES-128", ".NET", "6/10");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("InfinityCrypt", "Rijandel / AES-128", ".NET", "6/10");
                        break;
                    case "87ccd6f4ec0e6b706d65550f90b0e3c7":
                        Customize.ChangeLabelFromAnotherForm("Krotten Ransomware", "Delete's Files", "Microsoft Visual C++", "N/A");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("Krotten Ransomware", "Delete's Files", "Microsoft Visual C++", "N/A");
                        break;
                    case "63210f8f1dde6c40a7f3643ccf0ff313":
                        Customize.ChangeLabelFromAnotherForm("NoMoreRansom Ransomware", "Fake (Encrypted) Copy's of Files", "Microsoft Visual C++", "N/A");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("NoMoreRansom Ransomware", "Fake (Encrypted) Copy's of Files", "Microsoft Visual C++", "N/A");
                        break;
                    case "af2379cc4d607a45ac44d62135fb7015":
                        Customize.ChangeLabelFromAnotherForm("Petya Ransomware", "MBR Screen Locker", "Generic", "N/A");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("Petya Ransomware", "MBR Screen Locker", "Generic", "N/A");
                        break;
                    case "3ed3fb296a477156bc51aba43d825fc0":
                        Customize.ChangeLabelFromAnotherForm("Poly Ransomware", "Screen Locker (easy to bypass)", "Generic", "N/A");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("Poly Ransomware", "Screen Locker (easy to bypass)", "Generic", "N/A");
                        break;
                    case "70108103a53123201ceb2e921fcfe83c":
                        Customize.ChangeLabelFromAnotherForm("PowerPoint Ransomware", "MBR Screen Locker", "Win32 Executable", "N/A");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("PowerPoint Ransomware", "MBR Screen Locker", "Win32 Executable", "N/A");
                        break;
                    case "8803d517ac24b157431d8a462302b400":
                        Customize.ChangeLabelFromAnotherForm("ViraLock Ransomware (Similar to PolyRansomware)", "Screen Locker", "Generic", "N/A");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("ViraLock Ransomware (Similar to PolyRansomware)", "Screen Locker", "Generic", "N/A");
                        break;
                    case "84c82835a5d21bbcf75a61706d8ab549":
                        Customize.ChangeLabelFromAnotherForm("WannaCryptor", "RSA and AES Algorithms", "Microsoft Visual C++", "10/10");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("WannaCryptor", "RSA and AES Algorithms", "Microsoft Visual C++", "10/10");
                        break;
                    case "dbfbf254cfb84d991ac3860105d66fc6":
                        Customize.ChangeLabelFromAnotherForm("WinLockerVB6 Ransomware", "Screen Locker", "Generic", "N/A");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("WinLockerVB6 Ransomware", "Screen Locker", "Generic", "N/A");
                        break;
                    case "9d15a3b314600b4c08682b0202700ee7":
                        Customize.ChangeLabelFromAnotherForm("Xyeta Ransomware", "Screen Locker", "Generic", "N/A");
                        Customize.Show();
                        Customize.ChangeLabelFromAnotherForm("Xyeta Ransomware", "Screen Locker", "Generic", "N/A");
                        break;
                    case "0ed2ca539a01cdb86c88a9a1604b2005":
                        Customize.ChangeLabelFromAnotherForm("WastedLocker (Dangerous)", "RSA-4096 and AES-256", "Unknown", "10/10");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("WastedLocker (Dangerous)", "RSA-4096 and AES-256", "Unknown", "10/10");
                        break;
                    case "fbbdc39af1139aebba4da004475e8839":
                        Customize.ChangeLabelFromAnotherForm("BadRabbit", "MBR Screen Locker", "Microsoft Visual C++", "N/A");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("BadRabbit", "MBR Screen Locker", "Microsoft Visual C++", "N/A");
                        break;
                    case "0a7b70efba0aa93d4bc0857b87ac2fcb":
                        Customize.ChangeLabelFromAnotherForm("DeriaLocker", "AES-256 / Screen Locker", ".NET", "9/10");
                        Customize.Show();
                        Customize.ChangeLabelFromAnotherForm("DeriaLocker", "AES-256 / Screen Locker", ".NET", "9/10");
                        break;
                    case "7d80230df68ccba871815d68f016c282":
                        Customize.ChangeLabelFromAnotherForm("Fantom (Dangerous)", "RSA-4096 and AES-256", "Microsoft Visual C++", "10/10");
                        Customize.ShowDialog();
                        Customize.ChangeLabelFromAnotherForm("Fantom (Dangerous)", "RSA-4096 and AES-256", "Microsoft Visual C++", "10/10");
                        break;
                    default:
                        Customize.ShowDialog();
                        break;
                }
                GetFileToHash.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please Browse a File to Scan.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                Thread ScanningThreadForRansom = new Thread(new ThreadStart(ScanningThread));
                ScanningThreadForRansom.Priority = ThreadPriority.AboveNormal;
                ScanningThreadForRansom.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this are not an actuall ransomware detector it's only based on hashes of famous ransomware's of endermanch ransomware database on github and it's made only for fun.", "Note", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
