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

    internal class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
        }
    }
}
