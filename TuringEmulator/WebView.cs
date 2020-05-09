using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringEmulator
{
    public partial class WebView : Form
    {
        public WebView()
        {
            InitializeComponent();
            LoadPage();
        }

        public void LoadPage()
        {
            browser.DocumentText = Properties.Resources.HowTo_html;
        }

        public void LoadTheory()
        {
            browser.Navigate("https://ru.m.wikipedia.org/wiki/%D0%9C%D0%B0%D1%88%D0%B8%D0%BD%D0%B0_%D0%A2%D1%8C%D1%8E%D1%80%D0%B8%D0%BD%D0%B3%D0%B0");
        }
    }
}
