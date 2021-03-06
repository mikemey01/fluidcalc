﻿using System;
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

            int r_value = 4000;

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

            // get the r value
            Console.WriteLine("Enter the r value: ");
            r_value = Convert.ToInt32(Console.ReadLine());

            // left and right values
            // instantiate outside of loop
            // so we can use them outside of the loop
            decimal bisectLhs = 0m;
            decimal bisectRhs = 0m;
            
            // main loop
            while (start_iterations < NUM_ITERATIONS)
            {
                // get the lhs, rhs, bisect, and delta
                var highLhs = CalculateLhs(high_value);
                var highRhs = CalculateRhs(high_value, r_value);
                var highDelta = CalculateDelta(highLhs, highRhs);

                var lowLhs = CalculateLhs(low_value);
                var lowRhs = CalculateRhs(low_value, r_value);
                var lowDelta = CalculateDelta(highRhs, lowRhs);

                var bisect = GetBisect(high_value, low_value);
                bisectLhs = CalculateLhs(bisect);
                bisectRhs = CalculateRhs(bisect, r_value);
                var bisectDelta = CalculateDelta(bisectLhs, bisectRhs);


                // I might have this backwards, but for the next iteration
                // it sets either the high or low value to the bisect.
                if(bisectDelta < 0)
                {
                    high_value = bisect;
                }
                else
                {
                    low_value = bisect;
                }

                // write them out to the console window
                Console.WriteLine(" ");
                Console.WriteLine("HIGH: LHS: " + highLhs+", RHS: " + highRhs + ", Delta: " + highDelta);
                Console.WriteLine($"HIGH: LHS: {highLhs}, RHS: {highRhs}, Delta: {highDelta}");
                Console.WriteLine($"LOW: LHS: {lowLhs}, RHS: {lowRhs}, Delta: {lowDelta}");
                Console.WriteLine($"BISECT: LHS: {bisectLhs}, RHS: {bisectRhs}, Delta: {bisectDelta}");
                Console.WriteLine("-----------------------------");

                // don't forget to increment, otherwise you'll get infinite loop
                start_iterations++;
            }

            CalculateRelativeRoughness(bisectLhs, bisectRhs);

            Console.Read();
        }

        /************************
         * Helper functions below
         * 
         * */

        // the LHS calc
        static decimal CalculateLhs(decimal value)
        {
            var dValue = Convert.ToDouble(value);
            var answer = 1 / Math.Sqrt(dValue);

            return Convert.ToDecimal(answer);
        }

        // the RHS calc
        static decimal CalculateRhs(decimal value, int rValue)
        {
            var dValue = Convert.ToDouble(value);

            var answer = 2 * Math.Log10(((rValue * Math.Sqrt(dValue)) / 2.51));

            return Convert.ToDecimal(answer);
        }

        static decimal CalculateDelta(decimal left, decimal right)
        {
            return left - right;
        }

        // returns the bisect value
        static decimal GetBisect(decimal high, decimal low)
        {
            var total = high + low;
            var answer = total / 2;

            return answer;
        }

        static void CalculateRelativeRoughness(decimal lhs, decimal rhs)
        {

            var returnValue = (1 / lhs) * (1 / lhs);

            Console.WriteLine("The f value is: " + returnValue);
        }
    }
}
