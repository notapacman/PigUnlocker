namespace PigUnlocker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            FileManager manager = new FileManager();
            manager.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
    }
}
