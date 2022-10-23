using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    internal class Stack
    {
        internal static void Start()
        {
            //ArrayImplementationOfStack();
            //CheckForBalancedParenthesis("{{}}}}}[][][[[][[][");
            //StockSpanProblem(new int[] { 13, 15, 12, 14, 16, 8, 6, 4, 10, 30});
            //LargestAreaInHistogram(new int[] { 6, 2, 5, 4, 1, 5, 6});
        }

        private static void ArrayImplementationOfStack()
        {
            
        }

        private static bool CheckForBalancedParenthesis(string input)
        {
            var stack = new Stack<string>();
            for (int i = 0; i < input.Length; i++)
            {
                var s = input[i].ToString();
                var t = string.Empty;
                if (s == "{" || s == "[" || s == "(") stack.Push(s);

                else if (s == "}")
                {
                    if (stack.TryPeek(out t))
                    {
                        if (t == "{")
                        {
                            stack.Pop();
                            continue;
                        }
                        else return false;
                    }
                    else return false;
                }
                else if (s == "]")
                {
                    if (stack.TryPeek(out t))
                    {
                        if (t == "[")
                        {
                            stack.Pop();
                            continue;
                        }
                        else return false;
                    }
                    else return false;
                }
                else if (s == ")")
                {
                    if (stack.TryPeek(out t))
                    {
                        if (t == "(")
                        {
                            stack.Pop();
                            continue;
                        }
                        else return false;
                    }
                    else return false;
                }
            }
            return true;
        }

        private static void StockSpanProblem(int[] input)
        {
            var stack = new Stack<int>();
            var span = new Stack<int>();
            stack.Push(input[0]);
            span.Push(1);
            int k = -1;
            int count = 0;
            var spanArray = new int[input.Length];
            spanArray[0] = 1;   
            for (int i = 1; i < input.Length; i++)
            {
                count = 0;
                while (stack.TryPeek(out k) && k <= input[i])
                {
                    stack.Pop();
                    count += span.Pop();
                }
                stack.Push(input[i]);
                span.Push(count + 1);
                spanArray[i] = count + 1;
            }
            foreach (var item in input)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
            foreach (var item in spanArray)
            {
                Console.Write(item + "  ");
            }
        }

        private static int LargestAreaInHistogram(int[] input)
        {
            int largest = 0, currentArea = 0, count = 1;

            for (int i = 0; i < input.Length; i++)
            {
                currentArea = 0;
                count = 1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (input[j] >= input[i]) count++;
                    else break;
                }
                currentArea = input[i] * count;
                count = 1;
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[j] >= input[i]) count++;
                    else break;
                }
                currentArea += input[i] * (count - 1);

                if (currentArea > largest) largest = currentArea;
            }

            return largest;
        }
    }
    internal class ArrayImplementedStack
    {
        private int[] _elements;
        private int _count;

        public ArrayImplementedStack(int capacity)
        {
            _elements = new int[capacity];
            _count = 0;
        }
        public int Count 
        { 
            get 
            { 
                return _count; 
            } 
            set 
            {
                _count = value;
            } 
        }
        internal void Add(int number)
        {
            if (_count == _elements.Length)
            {
                var temp = new int[2 * _elements.Length];
                for (int i = 0; i < _elements.Length; i++)
                {
                    temp[i] = _elements[i];
                }
               _elements = temp;
            }
            _elements[_count] = number;
            _count++;
        }
        internal void Remove(int number)
        {
            _count--;
        }
        internal int Peek(int number)
        {
            if (_count <= 0) return -1;

            return _elements[_count - 1];
        }
        internal int Find(int number)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_elements[i] == number) return i;
            }
            return -1;
        }
    }
}
