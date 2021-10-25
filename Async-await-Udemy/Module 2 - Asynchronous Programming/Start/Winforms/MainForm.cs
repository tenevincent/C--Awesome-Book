using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winforms.Code.Module_2;

namespace Winforms
{
    public partial class MainForm : Form
    {
        private string apiURL;

        public MainForm()
        {
            InitializeComponent();

            apiURL = "https://localhost:44313";
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            loadingGIF.Visible = true;

            // Video: Task and Task That Returns a Value
            await new Task_And_TaskOfT(apiURL).btnStart_Click(txtInput);

            await WaitAsync();
            // Thread.Sleep(TimeSpan.FromSeconds(8));
            loadingGIF.Visible = false;

            //MessageBox.Show(this,"Task terminated!","Finished");
        }

        private static  Task WaitAsync()
        {
            return Task.Delay(TimeSpan.FromSeconds(2));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
