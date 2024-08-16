using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PigUnlocker
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Открываем браузер с указанным URL
            Process.Start(new ProcessStartInfo("http://harampig.github.io/pig") { UseShellExecute = true });
        }
    }
}
