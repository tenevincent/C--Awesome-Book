using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter01.Concurrency
{
    public class ConcurrencyLib
    {
     public   async Task<int> DoSomethingAsync()
        {
            int value = 8;

            await Task.Delay(TimeSpan.FromSeconds(4));

            value *= 2;

            await Task.Delay(TimeSpan.FromSeconds(4));

            return value;
        }


    }
}
