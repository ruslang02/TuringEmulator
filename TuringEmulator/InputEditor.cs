using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace TuringEmulator
{
    public partial class InputEditorForm : Form
    {
        public string ReturnInput { get; set; }
        public InputEditorForm() => InitializeComponent();
        private void CancelButton_Click(object sender, EventArgs e) => Close();
        private void OKButton_Click(object sender, EventArgs e)
        {
            ReturnInput = InputField.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void FileLoadButton_Click(object sender, EventArgs e) => LoadDialog.ShowDialog();
        private void LoadDialog_Select(object sender, CancelEventArgs e)
        {
            try
            {
                InputField.Text = File.ReadAllText(LoadDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
