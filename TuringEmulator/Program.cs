using System;
using System.IO;
using System.Windows.Forms;

namespace TuringEmulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm form = new MainForm();
            if (args.Length != 0)
                form.LoadAppFile(args[0]);
            else
            {
                bool empty = true;
                if (File.Exists("saved.emt"))
                    if (MessageBox.Show("Загрузить сохраненное состояние?", "Найдено сохраненное состояние", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        form.LoadAppFile("saved.emt");
                        empty = false;
                    }
                if(empty) form.EmptyLaunch();
            }
            Application.Run(form);
        }
    }
}
