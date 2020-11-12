using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime? effectiveDate = null;

            Nullable<DateTime> datetime = null;

            Console.WriteLine(datetime.HasValue);


            ValidateEffectiveDate(effectiveDate);



        }


        public static bool ValidateEffectiveDate(DateTime? effectiveDate)
        {
            if (!effectiveDate.HasValue) return false;

            if (effectiveDate.Value < DateTime.Now.AddDays(7)) return false;

            return true;
        }


    }
}
