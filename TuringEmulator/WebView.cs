using System.Windows.Forms;

namespace TuringEmulator
{
    public partial class WebView : Form
    {
        public WebView() => InitializeComponent();
        public void LoadPage() => browser.DocumentText = Properties.Resources.HowTo_html;
        public void LoadTheory() => browser.DocumentText = Properties.Resources.theory;
    }
}
