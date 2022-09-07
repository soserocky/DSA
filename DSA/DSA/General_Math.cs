using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    internal class General_Math
    {
        internal static void Start() 
        {
            //Console.WriteLine(CountDigits(1980));
            //Console.WriteLine(IsPallindrome(1980));
            //Console.WriteLine(Factorial(5));
            //Console.WriteLine(TrailingZeroesInFactorial(5));
            //Console.WriteLine(GCD(5, 15));
            //Console.WriteLine(LCM(5, 15));
            //Console.WriteLine(IsPrime(5));
            //Console.WriteLine(IsPrime(5));
            //PrimeFactors(210);
            //AllDivisorsOfNumber(210);
            //SieveOfEratosthenes(210);
            //ComputingPower(5,4);
            //DecimalToBinary(12);
            CalculateProductOfAllOtherElementsInArray(new int[] { 1, 2, 3, 4, 0, 0});
        }

        

        internal static int CountDigits(int number)
        {
            int digits = 0;
            while (number > 0)
            {
                digits++;
                number /= 10;
            }    
            return digits;
        }

        internal static bool IsPallindrome(int number)
        {
            int reverse = 0;
            while (number > 0)
            {
                reverse = reverse * 10 + (number % 10);
                number /= 10;
            }

            return reverse == number;
        }

        internal static long Factorial(int number)
        {
            if (number == 1) return 1;

            return number * Factorial(number - 1);
        }

        internal static int TrailingZeroesInFactorial(int number)
        {
            int divisor = 5;
            int trailingZeroes = 0;

            while (divisor <= number)
            {
                trailingZeroes += number / divisor;
                divisor *= 5;
            }
            return trailingZeroes;
        }
        
        internal static int GCD(int a, int b)
        {
            if (a == b) return a;

            int gcd = 1;

            int smaller = a < b ? a : b;
            int greater = a > b ? a : b;

            int divisor = 2;
            while (divisor <= smaller)
            {
                if ((smaller % divisor == 0) && (greater % divisor == 0))
                    gcd = divisor;
                
                divisor++;
            }

            return gcd;
        }

        internal static int LCM(int a, int b)
        {
            if (a == b) return a;

            int smaller = a < b ? a : b;
            int greater = a > b ? a : b;

            int lcm = smaller * greater;

            int multiple = greater;
            while (multiple <= smaller * greater)
            {
                if ((multiple % smaller == 0) && (multiple % greater == 0))
                    return multiple;

                multiple++;
            }

            return lcm;
        }

        internal static bool IsPrime(int number)
        {
            if (number == 1) return false;

            if (number < 4) return true;

            for (int i = 2; i*i <= number; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        internal static void PrimeFactors(int number)
        {
            for (int i = 2; i <= number; i++)
            {
                if ((number % i == 0) && IsPrime(i))
                    Console.WriteLine(i);
            }
        }
        
        internal static void AllDivisorsOfNumber(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                    Console.WriteLine(i);
            }
        }
        
        internal static void SieveOfEratosthenes(int number)
        {
            for (int i = 2; i <= number; i++)
            {
                if (IsPrime(i))
                    Console.WriteLine(i);
            }
        }
        
        internal static long ComputingPower(int number, int power)
        {
            if (power == 1) return number;

            return number * ComputingPower(number, power - 1);
        }

        internal static string DecimalToBinary(int number)
        {
            var binaryRep = string.Empty;
            while (number > 0)
            {
                binaryRep = (number % 2).ToString() + binaryRep;
                number /= 2;
            }
            return string.IsNullOrEmpty(binaryRep) ? "0" : binaryRep;
        }

        internal static int[] CalculateProductOfAllOtherElementsInArray(int[] array)
        {
            int product = 1, numberOfZeroes = 0;
            var response = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0)
                    product *= array[i];
                else
                    numberOfZeroes++;

                if (numberOfZeroes > 1) break;
            }

            if (numberOfZeroes == 0)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    response[i] = product / array[i];
                }
            }
            else if (numberOfZeroes == 1)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 0)
                        response[i] = product;
                    else
                        response[i] = 0;
                }
            }
            
            return response;
        }
    }
}
