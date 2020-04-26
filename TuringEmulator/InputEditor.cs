using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringEmulator
{
    public partial class InputEditor : Form
    {
        public string ReturnInput { get; set; }
        public InputEditor()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ReturnInput = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog ofd = (OpenFileDialog)sender;
            try
            {
                textBox1.Text = File.ReadAllText(ofd.FileName);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
