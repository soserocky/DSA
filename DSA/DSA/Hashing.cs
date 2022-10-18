using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    internal class Hashing
    {
        internal static void Start()
        {
            //ImplementMyHashing();
            //Console.WriteLine(CountNumberOfDistinctElementsInArray(new int[] { 1,1,1,2,3,5,6,88,7,7}));
            CountFrequenciesOfElementsInArray(new int[] { 1,1,1,2,3,5,6,88,7,7});
            LongestSubArrayWithGivenSumInArray(new int[] { 5, 8, -4, -4, 9, -2, 2 }, 0);
        }

        private static void ImplementMyHashing()
        {
            MyHashDataStructure set1 = new MyHashDataStructure(7);
            Console.WriteLine(set1.Count);
            set1.Insert(15);
            Console.WriteLine(set1.Count);
            set1.Insert(17);
            set1.Delete(15);
            Console.WriteLine(set1.Count);
        }
        private static int CountNumberOfDistinctElementsInArray(int[] input)
        {
            var set = new HashSet<int>();

            foreach (var item in input)
            {
                set.Add(item);
            }

            return set.Count;
        }
        private static void CountFrequenciesOfElementsInArray(int[] input)
        {
            var dictionary = new Dictionary<int, int>();
            foreach (var item in input)
            {
                if (dictionary.TryGetValue(item, out int value))
                    dictionary[item] = dictionary[item] + 1;
                else
                    dictionary.Add(item, 1);
            }
            Console.WriteLine("Frequencies:");
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }

        private static int CountOfOverlappingElementsIn2Arrays(int[] input1, int[] input2)
        {
            var set1 = new HashSet<int>();
            var count = 0;
            foreach (var item in input1)
            {
                set1.Add(item);
            }
            var set2 = new HashSet<int>();
            foreach (var item in input2)
            {
                set2.Add(item);
            }

            foreach (var item in set2)
            {
                if (set1.Add(item)) continue;
                else count++;
            }

            return count;
        }

        private static int CountOfUnionOfElementsIn2Arrays(int[] input1, int[] input2)
        {
            var set = new HashSet<int>();
            foreach (var item in input1)
            {
                set.Add(item);
            }
            foreach (var item in input2)
            {
                set.Add(item);
            }

            return set.Count;
        }

        private static bool PairWithAGivenSumInArray(int[] input, int sum)
        {
            var set = new HashSet<int>();
            foreach (var item in input)
            {
                if (set.Contains(sum - item)) return true;
                else set.Add(item);
            }
            return false;
        }

        private static bool SubArrayWith0SumInArray(int[] input)
        {
            if (input[0] == 0) return true;
            if (input[input.Length - 1] == 0) return true;
            var leftSum = new HashSet<int>();
            var sum = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                if (leftSum.Add(sum)) sum += input[i];
                else return true;
            }
            if (sum == 0) return true;
            return false;
        }

        private static bool SubArrayWithGivenSumInArray(int[] input, int sum)
        {
            if (input[0] == sum) return true;
            if (input[input.Length - 1] == sum) return true;
            var leftSum = new HashSet<int>();
            var lsum = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                if (leftSum.Contains(lsum - sum)) return true;

                leftSum.Add(lsum);
                lsum += input[i];
            }
            if (lsum == sum) return true;
            return false;
        }

        private static int LongestSubArrayWithGivenSumInArray(int[] input, int sum)
        {
            int start = -1, end = -1;
            if (input[0] == sum)
            {
                start = 0; 
                end = 0;
            };
            var leftSum = new Dictionary<int, int>();
            var lsum = input[0]; 
            for (int i = 1; i < input.Length; i++)
            {
                if (leftSum.TryGetValue(lsum - sum, out int index))
                {
                    if (i - 1 - index > end - start)
                    {
                        start = index;
                        end = i - 1;
                    }
                }
                else leftSum.Add(lsum, i);
                
                lsum += input[i];
            }
            if (lsum == sum)
            {
                start = 0;
                end = input.Length - 1;
            }
            if (start > -1 && end > -1)
            {
                Console.WriteLine($"The longest sub-array with the given sum {sum} is {start} to {end}");
            }
            else 
            {
                Console.WriteLine($"There is no sub-array with the given sum = {sum}");
            }

            return end - start + 1;
        }

        private static int LongestSubArrayWithEqual1And0(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 0) input[i] = -1;
            }

            return LongestSubArrayWithGivenSumInArray(input, 0);
        }

    }


    internal class MyHashDataStructure
    {
        private readonly int BucketSize;
        private int _count;
        internal int Count 
        { 
            private set
            { 
                _count = value;
            } 
            get 
            { 
                return _count;
            } 
        }

        public Node[] Bucket;
        public MyHashDataStructure(int bucketSize)
        {
            BucketSize = bucketSize;
            Bucket = new Node[BucketSize];
            _count = 0;
        }

        internal bool Search(int number)
        {
            int slot = FindSlot(number);
            var head = Bucket[slot];
            while (head != null)
            {
                if (head.Value == number) return true;
                head = head.Next;
            }
            return false;
        }
        
        internal void Insert(int number)
        {
            int slot = FindSlot(number);
            var head = Bucket[slot];
            while (head != null)
            {
                if (head.Value == number) return;
                if (head.Next == null)
                {
                    head.Next = new Node(number);
                    _count++;
                    return;
                }
                head = head.Next;
            }
            Bucket[slot] = new Node(number);
            _count++;
        }
        
        internal void Delete(int number)
        {
            int slot = FindSlot(number);
            var head = Bucket[slot];
            if (head != null && head.Value == number)
            {
                Bucket[slot] = null;
                _count--;
                return;
            }
            while (head != null)
            {
               if (head.Next == null) return;

               if (head.Next.Value == number)
               {
                   head.Next = head.Next.Next;
                    _count--;
                   return;
               }
               head = head.Next;
            }
        }

        private int FindSlot(int number)
        {
            return number % BucketSize;
        }
    }

    
}
