namespace DSA
{
    internal class Recursion
    {
        internal static void Start()
        {
            // Print1ToN(10);
            // PrintNTo1(10);
            // Console.WriteLine($"{SumOfFirstNNaturalNumbers(10)}"); 
            // Console.WriteLine($"{IsPallindrome("abba")}"); 
            // Console.WriteLine($"{SumOfDigits(253)}"); 
            // Console.WriteLine($"{RopeCuttingProblem(23, 12, 11, 1)}");
            // Program.PrintArray(GenerateSubSequencesSet("ABCD"));
            // Console.WriteLine(TowerOfHanoi(4)); 
            // Console.WriteLine(CountOfSubsetsWithGivenSum(new int[] {1, 2, 3, 4, 1, -1}, 10)); 
            // Program.PrintArray(GenerateAllPermutationsOfString("ABCDE")); 
            // Console.WriteLine(JosephusProblem(100, 3)); 
        }

        internal static void Print1ToN(int number)
        {
            if (number == 0) return;

            Print1ToN(number - 1);
            Console.WriteLine(number);
        }
        
        internal static void PrintNTo1(int number)
        {
            if (number == 0) return;

            Console.WriteLine(number);
            PrintNTo1(number - 1);
        }
        
        internal static int SumOfFirstNNaturalNumbers(int number)
        {
            if (number == 1) return 1;

            return number + SumOfFirstNNaturalNumbers(number - 1);
        }

        internal static bool IsPallindrome(string input)
        {
            var reverse = ReverseStringWithRecursion(input);

            return reverse == input;
        }

        internal static string ReverseStringWithRecursion(string input)
        {
            if (input.Length == 1) return input;

            return ReverseStringWithRecursion(input.Substring(1)) + input[0];
        }

        internal static int SumOfDigits(int input)
        {
            if (input == 0) return 0;

            return (input % 10) + SumOfDigits(input / 10);
        }

        internal static int RopeCuttingProblem(int ropeLength, int a, int b, int c)
        {
            if (ropeLength < a && ropeLength < b && ropeLength < c) return 0;
            
            var pieces1 = ropeLength >= a ? 1 + RopeCuttingProblem(ropeLength - a, a, b, c) : 0;
            var pieces2 = ropeLength >= b ? 1 + RopeCuttingProblem(ropeLength - b, a, b, c) : 0;
            var pieces3 = ropeLength >= c ? 1 + RopeCuttingProblem(ropeLength - c, a, b, c) : 0;

            return ((pieces1 >= pieces2 && pieces1 >= pieces3) ? pieces1 : ((pieces2 >= pieces1 && pieces2 >= pieces3) ? pieces2 : pieces3));
        }

        internal static string[] GenerateSubSequencesSet(string input, int position = 0)
        {
            //Idea: For every character in the string, we have 2 options:
            //Either to add the character to the combination or not add.
            if (position == input.Length - 1) return new string[] { string.Empty, input[position].ToString() };

            var prevLevelSubSequenceSet = GenerateSubSequencesSet(input, position + 1);
            var subSequenceSet = new string[2 * prevLevelSubSequenceSet.Length];
            var index = 0;
            foreach (var item in prevLevelSubSequenceSet)
            {
                subSequenceSet[index] = item;
                index++;
                subSequenceSet[index] = input[position].ToString() + item;
                index++;
            }
            return subSequenceSet;
        }

        internal static int TowerOfHanoi(int discs)
        {
            if (discs == 1) return 1;

            return 2 * TowerOfHanoi(discs - 1) + 1;
        }

        internal static int CountOfSubsetsWithGivenSum(int[] input, int sum, int position = 0, List<int[]> prevSubSets = null)
        {
            if (position == input.Length) return 0;
            
            List<int[]> presentSubSets = new List<int[]>();
            int count = 0;
            if (prevSubSets == null)
            {
                presentSubSets.Add(Array.Empty<int>());
                presentSubSets.Add(new int[] { input[position] });
                if (input[position] == sum) count = 1;
            }
            else 
            {
                for (int i = 0; i < prevSubSets.Count; i++)
                {
                    var arr = prevSubSets[i];
                    if (arr == Array.Empty<int>())
                    {
                        presentSubSets.Add(Array.Empty<int>());
                        presentSubSets.Add(new int[] { input[position] });
                        if (input[position] == sum) count++;
                    }
                    else
                    {
                        presentSubSets.Add(arr);
                        var arr2 = new int[arr.Length + 1];
                        arr2[0] = input[position];
                        int localSum = arr2[0];
                        for (int j = 1; j < arr2.Length; j++)
                        {
                            arr2[j] = arr[j - 1];
                            localSum += arr2[j];
                        }
                        presentSubSets.Add(arr2);

                        if (localSum == sum) count++;
                    }
                }
            }
            if (position == 0 && sum == 0) count++; 
            return count + CountOfSubsetsWithGivenSum(input, sum, position + 1, presentSubSets);
        }

        internal static string[] GenerateAllPermutationsOfString(string input)
        {
            //Idea: Remove the first character and find the permutations of the remaining string of "n-1" length
            //and add the first character to each permuted string at different indices

            if (input.Length == 1)  return new string[] { input[0].ToString() };
            
            var responseSet = new string[General_Math.Factorial(input.Length)];
            int index = 0;
            var firstChar = input[0].ToString();
            var remainingString = input.Substring(1);
            var prevLevelPermutationCollections = GenerateAllPermutationsOfString(remainingString);
            foreach (var item in prevLevelPermutationCollections)
            {
                for (int j = 0; j <= item.Length; j++)
                {
                    responseSet[index] = item.Substring(0, j) + firstChar + item.Substring(j);
                    index++;
                }
            }
            return responseSet;
        }

        internal static int JosephusProblem(int number, int k)
        {
            var people = new int[100];
            for (int i = 0; i < number; i++)
            {
                people[i] = i;
            }
            int killedPersons = 0;
            int start = 0;
            int survivor = -1;
            while (killedPersons < number - 1)
            {
                int count = 1; var flag = true;
                while (count < k)
                {
                    flag = true;
                    start++;
                    if (start == number)
                    {
                        for (int l = 0; l < number; l++)
                        {
                            if (people[l] != -1)
                            {
                                count++;
                                start = l;
                                flag = false;
                                break;
                            }
                        }
                    }
                    else if (people[start] != -1 && flag) count++;
                }
                people[start] = -1;
                killedPersons++;
            }
            for (int i = 0; i < number; i++)
            {
                if (people[i] != -1) {
                    survivor = i;
                    break;
                }
            }
            return survivor;
        }

        
    }
}