using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms.Code.Module_2
{
    public class TaskAndTaskReturnDemo
    {
        private readonly string apiURL;
        private readonly HttpClient httpClient;

        public TaskAndTaskReturnDemo(string apiURL)
        {
            this.apiURL = apiURL;
            httpClient = new HttpClient();
        }

        public async Task btnStart_Click(TextBox txtInput)
        {
            await Wait();
            var name = txtInput.Text;
            var greeting = await GetGreeting(name);
            MessageBox.Show(greeting);
        }

        private async Task Wait()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        private Task CreateTaskWithException()
        {
            return Task.FromResult(new TaskCanceledException());
        }

        private Task CreateTaskCancelled()
        {
            return Task.FromCanceled(new CancellationToken());
        }



        Task<List<string>> GetCardsMock(int amountOfCards)
        {
            var result = new List<string>();
            result.Add("001");
            result.Add("002");
            return Task.FromResult(result);
        }

        private Task ProcessMockCarcd(List<string> cards, IProgress<int> progress = default, CancellationToken token = default)
        {
            //...

            return Task.CompletedTask;

        }


        public async Task ProcessCars(List<string> cards, IProgress<int> progress = default, CancellationToken token = default)
        {
            using var semaphore = new SemaphoreSlim(1000);

            var taskResolved = 0;

            var tasks = new List<Task<HttpResponseMessage>>();
            tasks = cards.Select(

                async card =>
                {

                    var json = JsonConvert.SerializeObject(card);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    await semaphore.WaitAsync();
                    try
                    {
                        var takIntern = await httpClient.PostAsync($"{apiURL}/api/cards", content, token);
                        //if (progress != null)
                        //{
                        //    taskResolved++;
                        //    var percentage = (double)taskResolved / cards.Count;
                        //    percentage = percentage * 100;

                        //    var percentageInt = (int)Math.Round(percentage, 0);
                        //    progress?.Report(percentageInt);
                        //}

                        return takIntern;

                    }
                    finally
                    {
                        semaphore.Release();
                    }

                }).ToList();

            // var tasks = await Task.Run( () => ConstructTasks(cards));

            var responsesTasks =   Task.WhenAll(tasks);

            if(progress != null)
            {

                while (await Task.WhenAny(responsesTasks, Task.Delay(TimeSpan.FromMilliseconds(100))) != responsesTasks)
                {
                    var completedTask = tasks.Where(x=> x.IsCompleted).Count();
                    var percentage = (double)completedTask / cards.Count;
                    percentage = percentage * 100;
                    var percentageInt = (int)Math.Round(percentage, 0);
                    progress?.Report(percentageInt);
                }
            }

            // aa
            var responses = await responsesTasks;

            var rejectedCards = new List<string>();

            foreach (var item in  responses)
            {
                var content = await item.Content.ReadAsStringAsync();
                var responseCard = JsonConvert.DeserializeObject<CardResponse>(content);
                if (!responseCard.Approved)
                {
                    rejectedCards.Add(responseCard.Card);
                }
            }


            foreach (var card in rejectedCards)
            {
                Console.WriteLine($"Card {card} was rejected!");
            }



            Task<List<Task<HttpResponseMessage>>> ConstructTasks(List<string> cards)
            {
                var tasks = new List<Task<HttpResponseMessage>>();

                foreach (var card in cards)
                {
                    var json = JsonConvert.SerializeObject(card);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var responseTask = httpClient.PostAsync($"{apiURL}/api/cards", content);
                    tasks.Add(responseTask);
                }
                return Task.FromResult(tasks);
            }
        }



        private async Task<List<string>> GetCards(int amountOfCards)
        {
            return await Task.Run(() =>
            {
                var cards = new List<string>();

                for (int i = 0; i < amountOfCards; i++)
                {
                    cards.Add(i.ToString().PadLeft(16, '0'));
                }

                return cards;
            });

        }


        private async Task<string> GetGreeting(string nombre)
        {
            using (var response = await httpClient.GetAsync($"{apiURL}/api/greetings/{nombre}"))
            {
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
