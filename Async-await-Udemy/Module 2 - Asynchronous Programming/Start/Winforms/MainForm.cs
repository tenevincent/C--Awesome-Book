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
        private TaskAndTaskReturnDemo taskDemo;
        private CancellationTokenSource tokenSource;

        public MainForm()
        {
            InitializeComponent();

            apiURL = "https://localhost:44313";
            taskDemo = new TaskAndTaskReturnDemo(apiURL);
            

        }




        private async void btnStart_Click(object sender, EventArgs e)
        {
            tokenSource = new CancellationTokenSource();
           
            //tokenSource.CancelAfter(TimeSpan.FromSeconds(5));


            try
            {
                await OnStartTask();
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show("The operation was cancelled!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tokenSource.Dispose();
            }

            loadingGIF.Visible = false;
            progressBar.Value = 0;
        }

        private async Task OnStartTask()
        {
            var progressReport = new Progress<int>(OnProgress);
            progressBar.Visible = true;
            progressBar.Value = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            loadingGIF.Visible = true;

            // Video: Task and Task That Returns a Value
            // await new Task_And_TaskOfT(apiURL).btnStart_Click(txtInput);

            var cards = await GetCardsAsync(5000,tokenSource.Token);
            await taskDemo.ProcessCars(cards, progressReport, tokenSource.Token);

            // await WaitAsync();
            // Thread.Sleep(TimeSpan.FromSeconds(8));

            stopwatch.Stop();

            MessageBox.Show(this, $"Task terminated. The duration was \"{((float)stopwatch.ElapsedMilliseconds / 1000).ToString()} seconds\"", "Finished");

        }

        private void OnProgress(int progressValue)
        {
            this.progressBar.Value = progressValue;
        }

        private static  Task WaitAsync()
        {
            return Task.Delay(TimeSpan.FromSeconds(2));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tokenSource?.Cancel();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private static async Task<List<string>> GetCardsAsync(int amountOfCards, CancellationToken token = default)
        {
            return await Task.Run(async () =>
            {
                var cards = new List<string>();

                for (int i = 0; i < amountOfCards; i++)
                {
                    await Task.Delay(millisecondsDelay: 1000);
                    cards.Add(i.ToString().PadLeft(16, '0'));
                    Console.WriteLine($"Card number {i} has been created!");
                    if (token.IsCancellationRequested)
                    {
                        throw new TaskCanceledException("The task was cancelled inside the method GetCardsAsync");
                    }
                }

                return cards;
            });

        }


    }
}
