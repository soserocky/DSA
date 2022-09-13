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
            //Console.WriteLine(CountOccurenceOfNumberInSortedArray(new int[8] { 1, 2, 3, 4, 5, 5, 6, 7 }, 5));
            //Console.WriteLine(SearchElementInInfinitelySortedArray(new int[8] { 1, 2, 3, 4, 5, 5, 6, 7 }, 5));
            //Console.WriteLine(FindPeakElementInNonSortedArray(new int[8] { 1, 2, 3, 4, 5, 5, 6, 7 }));
            //FindPairOfElementsWithAGivenSumInASortedArray(new int[8] { 1, 2, 3, 4, 5, 5, 6, 7 }, 10);
            FindTripletsOfElementsWithAGivenSumInASortedArray(new int[8] { 1, 2, 3, 4, 5, 5, 6, 7 }, 10);
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

        internal static int SearchElementInInfinitelySortedArray(int[] input, int number)
        {
            //In an infinite array, you can not do mid = (low + high) / 2
            //as high = input.length - 1, a very high number.

            if (input[0] == number) return 0;

            int index = 1;
            while (input[index] < number)
                index *= 2;
            
            if (input[index] == number) return index;

            var destinationArray = new int[index /2 + 1];
            Array.Copy(input, index / 2, destinationArray, 0, index / 2 + 1);

            return BinarySearch_Iterative(destinationArray, number);
        }

        internal static int FindPeakElementInNonSortedArray(int[] input)
        {
            int low = 0, high = input.Length - 1;
            while (low <= high)
            {
                if (high - low == 1) 
                {
                    if (input[low] >= input[high]) return input[low];
                    else return input[high];
                }
                var mid = (low + high) / 2;
                if (input[mid] >= input[mid - 1] && input[mid] >= input[mid + 1]) return input[mid];
                else if (input[mid - 1] >= input[mid]) high = mid - 1;
                else low = mid + 1;
            }
            return -1;
        }

        internal static void FindPairOfElementsWithAGivenSumInASortedArray(int[] input, int number)
        {
            int low = 0, high = input.Length - 1;
            while (low < high)
            {
                var sum = input[low] + input[high];
                if (sum == number)
                {
                    Console.WriteLine($"Pair is: ${input[low]}, {input[high]}");
                    return;
                }
                else if (sum < number) high--;
                else low++;
            }
        }

        internal static void FindTripletsOfElementsWithAGivenSumInASortedArray(int[] input, int number)
        {
            int low = 0, high = input.Length - 1;
            while (low < high)
            {
                var sum = input[low] + input[high];
                if (sum == number)
                {
                    Console.WriteLine($"Pair is: ${input[low]}, {input[high]}");
                    return;
                }
                else if (sum < number) high--;
                else low++;
            }
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
