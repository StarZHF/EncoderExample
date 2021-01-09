using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace EncoderExample
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            MaximumSize = Size;
            MinimumSize = Size;
        }

        private void tbPath_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog o = new OpenFileDialog())
            {
                if(o.ShowDialog() == DialogResult.OK)
                {
                    tbPath.Text = o.FileName;
                }
            }
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            byte[] split = Encoding.Default.GetBytes("#defaultSplit#"); // our Default split.
            byte[] Encoded = Encoding.Default.GetBytes(Convert.ToBase64String(File.ReadAllBytes(tbPath.Text))); // our Base64 encoded payload.
            byte[] stub = File.ReadAllBytes(Environment.CurrentDirectory + @"\stub.exe"); // the stub

            IEnumerable<byte> output = stub.Concat(split).Concat(Encoded); // concatenating bytes through LINQ.

            File.WriteAllBytes(Environment.CurrentDirectory + @"\encoded.exe", output.ToArray()); // outputting the finished payload.
            MessageBox.Show("Done!");
        }
    }
}
