using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    internal class Searching
    {
        internal static void Start()
        {
            //Console.WriteLine(BinarySearch_Iterative(new int[7] { 1, 2, 3, 4, 5, 6, 7 }, 6));
            //Console.WriteLine(BinarySearch_Recursive(new int[7] { 1, 2, 3, 4, 5, 6, 7 }, 6, 0, 6));
            //Console.WriteLine(IndexOfFirstOccurenceOfElementInSortedArray(new int[8] { 1, 2, 3, 4, 5, 5, 6, 7 }, 5));
            //Console.WriteLine(IndexOfLastOccurenceOfElementInSortedArray(new int[8] { 1, 2, 3, 4, 5, 5, 6, 7 }, 5));
            Console.WriteLine(CountOccurenceOfNumberInSortedArray(new int[8] { 1, 2, 3, 4, 5, 5, 6, 7 }, 5));
            //Console.WriteLine(SquareRoot(1000));
        }

        internal static int BinarySearch_Iterative(int[] input, int number)
        {
            int start = 0, end = input.Length - 1;
            while (start <= end)
            {
                if (end - start == 1)
                {
                    if (input[start] == number) return start;
                    if (input[end] == number) return end;
                }
                //The above "start" amd "end" checks are necessary, because,
                //if end - start = 1, means only 2 elements in the search range and "mid"
                //always comes out to be "start" and the code ends up in an infinite "while loop"

                var mid = (start + end) / 2;
                
                if (input[mid] == number) return mid;

                if (number > input[mid]) start = mid;
                else end = mid;

            }
            return -1;
        }

        internal static int BinarySearch_Recursive(int[] input, int number, int start, int end)
        {
            if (end - start == 1)
            {
                if (input[start] == number) return start;

                if (input[end] == number) return end;
            }
            var mid = (start + end) / 2;

            if (input[mid] == number) return mid;

            if (number > input[mid]) return BinarySearch_Recursive(input, number, mid, end);
            else return BinarySearch_Recursive(input, number, start, mid);
        }

        internal static int IndexOfFirstOccurenceOfElementInSortedArray(int[] input, int number)
        {
            int start = 0, end = input.Length - 1;
            int index = -1;
            while (start <= end)
            {
                if (end - start == 1)
                {
                    if (input[start] == number)
                    {
                        index = start;
                        break;
                    }
                    if (input[end] == number)
                    {
                        index = end;
                        break;
                    } 
                }
                var mid = (start + end) / 2;

                if (input[mid] == number)
                {
                    index = mid;
                    break;
                }

                if (number > input[mid]) start = mid;
                else end = mid;
            }
            
            while (index > 0)
            {
                if (input[index - 1] == number) index--;
                else break;
            }
            return index;
        }
        internal static int IndexOfLastOccurenceOfElementInSortedArray(int[] input, int number)
        {
            int start = 0, end = input.Length - 1;
            int index = -1;
            while (start <= end)
            {
                if (end - start == 1)
                {
                    if (input[start] == number)
                    {
                        index = start;
                        break;
                    }
                    if (input[end] == number)
                    {
                        index = end;
                        break;
                    }
                }
                var mid = (start + end) / 2;

                if (input[mid] == number)
                {
                    index = mid;
                    break;
                }

                if (number > input[mid]) start = mid;
                else end = mid;
            }

            while (index < input.Length - 1)
            {
                if (input[index + 1] == number) index++;
                else break;
            }
            return index;
        }

        internal static int CountOccurenceOfNumberInSortedArray(int[] input, int number)
        {
            int start = 0, end = input.Length - 1;
            int index = -1;
            while (start <= end)
            {
                if (end - start == 1)
                {
                    if (input[start] == number)
                    {
                        index = start;
                        break;
                    }
                    if (input[end] == number)
                    {
                        index = end;
                        break;
                    }
                }
                var mid = (start + end) / 2;

                if (input[mid] == number)
                {
                    index = mid;
                    break;
                }

                if (number > input[mid]) start = mid;
                else end = mid;
            }
            int count = index == -1 ? 0 : 1;
            int i = index;
            while (i > 0)
            {
                if (input[i - 1] == number)
                {
                    count++;
                    i--;
                }
                else break;
            }
            i = index;
            while (i < input.Length - 1)
            {
                if (input[i + 1] == number)
                {
                    count++;
                    i++;
                }
                else break;
            }
            return count;
        }
        internal static int SquareRoot(int number)
        {
            var i = 0;
            while (i * i <= number)
            {
                i++;
            }
            return i;
        }
    }
}
