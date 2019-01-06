using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluidCalc
{
    class Program
    {
        // this is just the number of times you want to iterate over the calculation
        const int NUM_ITERATIONS  = 50;

        // entry point into the app
        static void Main(string[] args)
        {
            // start the iterations at 0
            var start_iterations = 0;

            // initial high value
            decimal high_value = 0M;
            Console.WriteLine("Initial high value: ");
            try
            {
                high_value = Convert.ToDecimal(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            // initial low value
            Console.WriteLine("Initial low value: ");
            decimal low_value = 0M;
            try
            {
                low_value = Convert.ToDecimal(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            // main loop
            while (start_iterations < NUM_ITERATIONS)
            {
                Console.WriteLine(high_value);
                Console.WriteLine(low_value);

                // don't forget to increment, otherwise you'll get infinite loop
                start_iterations++;
            }

            Console.Read();

            
        }

        /************************
         * Helper functions below
         * 
         * */

        // the main calculation
        decimal CalculateFluid(decimal high, decimal low)
        {
            // I don't remember what the calculation was, need to put it here.
            // temp calc for now
            return high - low;
        }

        // returns the bisect value
        decimal GetBisect(decimal high, decimal low)
        {
            var total = high + low;
            var answer = total / 2;

            return answer;
        }
    }
}
