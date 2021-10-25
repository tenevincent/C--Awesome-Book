using System.Reactive.Linq;
using System.Threading.Tasks.Dataflow;

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
 

            await concurrencyLib.DoSomethingAsync();

            this.statusbarLabel.Text = "This task is finished...";
            
        }

        private   async void btnParallel_Click(object sender, EventArgs e)
        {

          await  Task.Run(() =>
            {
                var values = Enumerable.Range(1, 100);
                Parallel.ForEach(values, (x) =>
                {
                    var message = $"Parallel.ForEach {x}";
                    Console.WriteLine(message);
                    //if (this.InvokeRequired)
                    //    this.statusbarLabel.Text = message;
                    Thread.Sleep(1000);
                });


            });

            //await Task.CompletedTask;
        }

        private  void btnParallelInvoke_Click(object sender, EventArgs e)
        {
            var values = Enumerable.Range(1, 10).ToArray();
            Parallel.Invoke(
                () => Process(values, 0, values.Count() / 2),
                () => Process(values, values.Count() / 2, values.Count())
            );

            void Process<T>(T[] arr, int begin, int end)
            { 
                Console.WriteLine($"Parallel.Invoke {begin}:{end}");
                Thread.Sleep(5000);
            }
        }

        private void btnReactivePrograming_Click(object sender, EventArgs e)
        {
            IObservable<DateTimeOffset> values = Observable.Interval(TimeSpan.FromSeconds(1))
        .Timestamp()
        .Where(x => x.Value % 2 == 0)
        .Select(x => x.Timestamp);

            values.Subscribe(x => {
                string message = $"Observable.Interval {x}";
                Console.WriteLine(message);
                if(btnReactivePrograming.InvokeRequired)
                    statusbarLabel.Text = message;
            });
        }

        private void btnDataFlow_Click(object sender, EventArgs e)
        {
            var block1 = new TransformBlock<int, int>(
               x => (x == 1) ? throw new InvalidOperationException("Meh") : x * 2);
            var block2 = new TransformBlock<int, int>(x => x - 2);

            block1.LinkTo(block2, new DataflowLinkOptions { PropagateCompletion = true });

            block1.Post(1);
        }
    }
}