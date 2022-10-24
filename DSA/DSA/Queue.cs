using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    internal class Queue
    {
        internal static void Start()
        {
            //QueueBasics();
            //ImplementStackUsingQueue();
            //GenerateNumbersUptoNFromAWithDigitsGivenSet(new HashSet<int>() { 5, 6 }, 10);
        }

        private static void QueueBasics()
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            while (queue.Count() > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
        private static void ImplementStackUsingQueue()
        {
            MyStackUsingQueue myStack = new MyStackUsingQueue();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);

            while (myStack.GetSize() > 0)
            {
                Console.WriteLine($"Popped item: {myStack.Pop()}, Size: {myStack.GetSize()}");
            }
        }
        internal static void GenerateNumbersUptoNFromAWithDigitsGivenSet(HashSet<int> input, int n)
        {
            var queue = new Queue<int>();
            var auxQueue = new Queue<int>();
            var count = 0;
            var dequedItem = 0;
            var flag = true;

            while (count < n)
            {
                if (!auxQueue.TryDequeue(out dequedItem))
                {
                    foreach (var item in input)
                    {
                        queue.Enqueue(item);
                        auxQueue.Enqueue(item);
                        count++;

                        if (count == n)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var item in input)
                    {
                        queue.Enqueue(dequedItem * 10 + item);
                        auxQueue.Enqueue(dequedItem * 10 + item);
                        count++;

                        if (count == n)
                        {
                            flag = false;
                            break;
                        }
                    }
                }
                if (!flag) break;
            }
            while (queue.Count() > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }

    internal class MyStackUsingQueue
    {
        private int _size;
        Queue<int> _queue, auxQueue;
        public MyStackUsingQueue()
        {
            _queue = new Queue<int>();
            auxQueue = new Queue<int>();
        }
        internal void Push(int number)
        {
            var count = 0;
            while (count < _size)
            {
                auxQueue.Enqueue(_queue.Dequeue());
                count++;
            }
            _queue.Enqueue(number);
            count = 0;
            while (count < _size)
            {
                _queue.Enqueue(auxQueue.Dequeue());
                count++;
            }
            _size++;
        }
        internal int Pop()
        {
            if (_size > 0)
            {
                _size--;
                return _queue.Dequeue();
            }
            throw new Exception("Empty Stack");
        }
        internal int GetSize()
        {
            return _size;
        }
    }
}
