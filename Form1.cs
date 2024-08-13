namespace PigUnlocker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            restrictions restrictions = new restrictions();
            restrictions.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            autorun autorun = new autorun();
            autorun.Show();
        }
    }
}
