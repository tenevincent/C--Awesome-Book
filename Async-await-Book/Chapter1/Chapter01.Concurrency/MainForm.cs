namespace Chapter01.Concurrency
{
    public partial class MainForm : Form
    {
        private ConcurrencyLib concurrencyLib = new ConcurrencyLib();
        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnRunAsync_Click(object sender, EventArgs e)
        {
            this.statusbarLabel.Text = "This task is running. Please wait...";

            Thread.Sleep(8000);

            await concurrencyLib.DoSomethingAsync();

            this.statusbarLabel.Text = "This task is finished...";
            
        }
    }
}