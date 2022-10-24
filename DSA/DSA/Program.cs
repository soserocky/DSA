namespace DSA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //General_Math.Start();
            //BitMagic.Start();
            //Recursion.Start();
            //Arrays.Start();
            //Searching.Start();
            //Revision.Start();
            //Sorting.Start();
            //Matrix.Start();
            //Hashing.Start();
            //Strings.Start();
            //LinkedList.Start();
            //Stack.Start();
            Queue.Start();
            Console.Read();
        }

        internal static void PrintArray<T>(T[] input)
        {
            if (input== null)
            {
                Console.WriteLine("Null Array");
                return;
            }
            if (input.Length == 0)
            {
                Console.WriteLine("Empty Array");
                return;
            }
            foreach (var item in input)
            {
                if (item.GetType().Name.ToLower() == "string" && (item == null || item.ToString() == string.Empty))
                    Console.Write("Empty ");
                else
                    Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        internal static void PrintDictionary(Dictionary<int, int> input)
        {
            foreach (var item in input)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
        }

        internal static void PrintMatrix(int[,] input)
        {
            int rows = input.GetUpperBound(0) + 1;
            int columns = input.GetUpperBound(1) + 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(input[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
