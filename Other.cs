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
    public partial class Other : Form
    {
        public Other()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("regedit.exe");
            }
            catch (Exception ex)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("taskmgr.exe");
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("mmc.exe", "gpedit.msc");
            }
            catch (Exception ex)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("mmc.exe", "eventvwr.msc");
            }
            catch (Exception ex)
            {

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start("C:\\WINDOWS\\system32\\msconfig.exe");
            }
            catch (Exception ex)
            {
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("mmc.exe", "compmgmt.msc");
            }
            catch (Exception ex)
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("mmc.exe", "taskschd.msc");
            }
            catch (Exception ex)
            {

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("C:\\WINDOWS\\system32\\resmon.exe");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
