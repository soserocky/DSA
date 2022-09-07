namespace DSA
{
    internal class BitMagic
    {
        internal static void Start()
        {
           //Console.WriteLine(Negate(-5));
           //Console.WriteLine(LeftShift(-5, 1));
           //Console.WriteLine(RightShift(-5, 5));
           //Console.WriteLine(IsKthBitSetOrNot(5, 5));
           //Console.WriteLine(CountSetBits_Efficient(31));
           //Console.WriteLine(IsPowerOf2_Efficient(32));
           //Console.WriteLine(OneOddOccuringNumberInArray_Efficient(new int[] { 2, 2, 10, 7, 7 }));
           //Console.WriteLine(FindMissingNumberInSequence(new int[] { 1, 2, 5, 6, 3 }));
           //TwoOddOccuringNumberInArray_Efficient(new int[] { 1, 2, 1, 2, 3, 5 });
           //PowerSetGeneration_Efficient("abc");
        }

        internal static int Negate(int number)
        {
            return ~number;
        }

        internal static int LeftShift(int number, int positions)
        {
            return (number << positions);
        }

        internal static int RightShift(int number, int positions)
        {
            return (number >> positions);
        }

        internal static bool IsKthBitSetOrNot(int number, int k)
        {
            return (((1 << (k - 1)) & number) > 0);
        }
        
        internal static int CountSetBits_Naive(int number)
        {
            var setBits = 0;
            for (int i = 1; i <= 32; i++)
            {
                if (((1 << (i - 1)) & number) > 0)
                    setBits++;
            }
            return setBits;
        }
        
        internal static int CountSetBits_Efficient(int number)
        {
            //Brian Kerningam's Algorithm
            var setBits = 0;
            while (number > 0)
            {
                number = (number & (number - 1));
                setBits++;
            }
            return setBits;
        }
        
        internal static bool IsPowerOf2_Efficient(int number)
        {
            if (number == 0 || number == 1) return false;

            return ((number & (number - 1)) == 0);
        }

        internal static int OneOddOccuringNumberInArray_Naive(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] == array[i])
                        count++;

                    if (count == 2) break;
                }
                if (count == 1) return array[i];
            }
            return 0;
        }
        
        internal static int OneOddOccuringNumberInArray_Efficient(int[] array)
        {
            int xor = 0;
            for (int i = 0; i < array.Length; i++)
            {
                xor = xor ^ array[i];
            }
            return xor;
        }
        
        internal static int FindMissingNumberInSequence(int[] array)
        {
            int xor = 0;
            for (int i = 1; i <= array.Length; i++)
            {
                xor = xor ^ i ^ array[i - 1];
            }
            return (xor ^ (array.Length + 1));
        }
        
        internal static void TwoOddOccuringNumberInArray_Efficient(int[] array)
        {
            int xor = 0, grp1 = 0, grp2 = 0;
            for (int i = 0; i < array.Length; i++)
            {
                xor = xor ^ array[i];
            }

            int specialNumber = (xor ^ (~(xor - 1)));
            for (int i = 0; i < array.Length; i++)
            {
                if ((specialNumber & (array[i])) == 0)
                    grp1 = grp1 ^ array[i];
                else
                    grp2 = grp2 ^ array[i];
            }
            Console.WriteLine($"The two odd occuring numbers are: {grp1}, {grp2}");
        }

        internal static void PowerSetGeneration_Naive(string input)
        {
            var maxSize = General_Math.ComputingPower(2, input.Length);
            for (int i = 0; i < maxSize; i++)
            {
                var binaryRepresentation = General_Math.DecimalToBinary(i);
                var gap = input.Length - binaryRepresentation.Length;
                string prefixZeroes = string.Empty;
                for (int j = 0; j < gap; j++)
                {
                    prefixZeroes += "0";
                }
                var normalizedBinary = prefixZeroes + binaryRepresentation;
                string str = string.Empty;
                for (int j = 0; j < normalizedBinary.Length; j++)
                {
                    if (normalizedBinary[j].ToString() == "1")
                        str += input[j].ToString();
                    
                }
                Console.WriteLine(str);
            }
        }
        
        internal static void PowerSetGeneration_Efficient(string input)
        {
            var maxSize = General_Math.ComputingPower(2, input.Length);
            for (int i = 0; i < maxSize; i++)
            {
                string str = string.Empty;
                for (int j = input.Length; j >= 1; j--)
                {
                    if (IsKthBitSetOrNot(i, j))
                        str = input[j-1].ToString() + str;
                }
                Console.WriteLine(str);
            }
        }

    }
}