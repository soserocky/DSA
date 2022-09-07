namespace DSA
{
    internal class Arrays
    {
        internal static void Start()
        {
            //Console.WriteLine(IndexOfMaximumElementInArray(new int[] { 1, 2, 3, -1, 5, 10 }));
            //Console.WriteLine(IndexOfSecondMaximumElementInArray(new int[] { 10, 10, 10 }));
            //Console.WriteLine(IfArraySortedOrNot(new int[] { 10, 10, 10 }));
            //Program.PrintArray(ReverseArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
            //Program.PrintArray(RemoveDuplicatesFromSortedArray(new int[] { 1, 1, 2, 3, 4, 4, 4, 5, 6, 6 }));
            //Program.PrintArray(MoveZeroesToTheEnd(new int[] { 1, 1, 2, 3, 4, 4, 4, 5, 6, 6 }));
            //Program.PrintArray(RotateArrayByOne(new int[] { 1, 1, 2, 3, 4, 4, 4, 5, 6, 6 }));
            //Program.PrintArray(RotateArrayByD(new int[] { 1, 1, 2, 3, 4, 4, 4, 5, 6, 6 }, 4));
            //Program.PrintArray(LeadersInArrayProblem(new int[] { 1, 1, 2, 3, 4, 4, 4, 5, 6, 6 }));
            //Console.WriteLine(MaxDifferenceInArrayProblem(new int[] { 2, 3, 10, 6, 4, 8, 1 }));
            //Program.PrintDictionary(FrequenciesOfElementsInSortedArray(new int[] { 2, 3, 10, 11, 15, 18, 19 }));
            //Console.WriteLine(MaximizeProfitStocksTrade(new int[] { 3, 2, 4, 5, 0, 8, 71 }));
            //Console.WriteLine(TrappingRainWater_Efficient(new int[] { 2,0,3,0,2,0,4,0,2,0,2,0,5 }));
            //Console.WriteLine(MaxConsecutive1sInArray(new int[] { 1, 0, 1, 1, 0, 0, 1 }));
            //Console.WriteLine(MaxLinearSubArraySum(new int[] { -6, -1, 8 }));
            //Console.WriteLine(MaxAlternatingSubArray(new int[] { 6, 1, 8 }));
            //Console.WriteLine(MaxCircularSubArraySum(new int[] { 10, 5, -5 }));
            //Console.WriteLine(FindMajorityElement(new int[] { 10, 3, 3, 3, 10, 0, 10, 10 }));
            //MinimumGroupFlipsToMakeSame(new int[] { 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1 });
            //Console.WriteLine(FindMaxSumOfKConsecutiveElements(new int[] { 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 1 }, 5));
            //Console.WriteLine(FindSubArrayWithGivenSumInNonNegativeArray(new int[] { 3,2,4,5,0,8,71 }, 2));
            //Console.WriteLine(FindSumOfArrayBetweenGivenIndicesByPreprocessing(new int[] { 3,2,4,5,0,8,71 }, 2, 5));
        }
        internal static int IndexOfMaximumElementInArray(int[] input)
        {
            int max = input[0];
            int index = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > max)
                    index = i;
            }
            return index;
        }
        internal static int IndexOfSecondMaximumElementInArray(int[] input)
        {
            int max = input[0];
            int secondMax = max;
            int maxIndex = 0, secondMaxIndex = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > max)
                {
                    secondMax = max;
                    secondMaxIndex = maxIndex;
                    max = input[i];
                    maxIndex = i;
                }
                else if (max == secondMax && input[i] < secondMax)
                {
                    secondMax = input[i];
                    secondMaxIndex = i;
                }
                else if (input[i] < max && input[i] > secondMax)
                {
                    secondMax = input[i];
                    secondMaxIndex = i;
                }
            }
            return secondMaxIndex == maxIndex ? -1 : secondMaxIndex;
        }
        internal static bool IfArraySortedOrNot(int[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] < input[i - 1]) return false;
            }
            return true;
        }
        internal static int[] RemoveDuplicatesFromSortedArray(int[] input)
        {
            var response = new List<int>();
            response.Add(input[0]);
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1]) continue;

                response.Add(input[i]);
            }
            return response.ToArray();
        }
        internal static int[] MoveZeroesToTheEnd(int[] input)
        {
            var response = new int[input.Length];
            int index = 0, numberOfZeroes = 0;
            for (index = 0; index < input.Length; index++)
            {
                if (input[index] != 0) response[index] = input[index];
                else numberOfZeroes++;
            }
            for (int j = 0; j < numberOfZeroes; j++)
            {
                input[index++] = 0;
            }
            return response;
        }
        internal static int[] RotateArrayByOne(int[] input)
        {
            int first = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                input[i - 1] = input[i];
            }
            input[input.Length - 1] = first;
            return input;
        }
        internal static int[] RotateArrayByD(int[] input, int d)
        {
            d = d % input.Length;
            var temp = new int[d];
            for (int i = 0; i < input.Length; i++)
            {
                if (i < d) temp[i] = input[i];
                else input[i - d] = input[i];
            }
            for (int i = d; i < input.Length; i++)
            {
                input[i] = temp[i - d];
            }
            return input;
        }
        internal static int[] LeadersInArrayProblem(int[] input)
        {
            int max = input.Length - 1;
            var leaders = new List<int>();
            leaders.Add(max);
            for (int i = input.Length - 2; i > 0; i--)
            {
                if (input[i] > max)
                {
                    leaders.Add(i);
                    max = input[i];
                }
            }
            return leaders.ToArray();
        }
        internal static int MaxDifferenceInArrayProblem(int[] input)
        {
            int difference = input[1] - input[0];
            int min = input[0];
            for (int j = 1; j < input.Length; j++)
            {
                difference = Math.Max(difference, input[j] - min);
                min = Math.Min(min, input[j]);
            }
            return difference;
        }
        internal static Dictionary<int, int> FrequenciesOfElementsInSortedArray(int[] input)
        {
            var frequencies = new Dictionary<int, int>();
            var count = 1;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1]) count++;
                else
                {
                    frequencies.Add(input[i-1], count);
                    count = 1;
                }
            }
            if (input[input.Length - 1] != input[input.Length - 2])
                frequencies.Add(input[input.Length - 1], 1);
            else
                frequencies.Add(input[input.Length - 1], count);

            return frequencies;
        }
        internal static int MaximizeProfitStocksTrade(int[] input)
        {
            int profit = 0;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] - input[i - 1] > 0) profit += input[i] - input[i - 1];
            }
            return profit;
        }
        internal static int TrappingRainWater_Naive(int[] input)
        {
            int waterStored = 0;
            for (int i = 1; i < input.Length - 1; i++)
            {
                int lMax = input[i];
                for (int j = 0; j < i; j++)
                {
                    lMax = Math.Max(lMax, input[j]);
                }
                int rMax = input[i];
                for (int j = i + 1; j < input.Length; j++)
                {
                    rMax = Math.Max(rMax, input[j]);
                }
                waterStored += Math.Min(lMax, rMax) - input[i];
            }
            return waterStored;

            

        }
        internal static int TrappingRainWater_Efficient(int[] input)
        {
            int waterStored = 0;
            int n = input.Length;
            int[] lMax = new int[n];
            int[] rMax = new int[n];

            lMax[0] = input[0];
            for (int i = 1; i < n; i++)
                lMax[i] = Math.Max(input[i], lMax[i - 1]);

            rMax[n - 1] = input[n - 1];
            for (int i = n - 2; i >= 0; i--)
                rMax[i] = Math.Max(input[i], rMax[i + 1]);

            for (int i = 1; i < n - 1; i++)
                waterStored = waterStored + (Math.Min(lMax[i], rMax[i]) - input[i]);

            return waterStored;
        }
        internal static int MaxConsecutive1sInArray(int[] input)
        {
            var count = input[0] == 1 ? 1 : 0;
            int max = count;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == 1) count++;
                else
                {
                   if (count > max) max = count;
                   count = 0;
                }
            }
            return max;
        }
        internal static int MaxLinearSubArraySum(int[] input)
        {
            var sum = input[0];
            var max = sum;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] + sum < 0) sum = input[i];
                else sum += input[i];

                if (sum > max) max = sum;
            }
            if (input[input.Length - 1] > max) max = input[input.Length - 1];

            return max;
        }
        internal static int MaxAlternatingSubArray(int[] input)
        {
            var flag = input[0] % 2 == 0 ? 0 : 1;
            int count = 1, max = 1;
            for (int i = 1; i < input.Length; i++)
            {
                if (flag == 0 && input[i] % 2 > 0)
                {
                    flag = 1;
                    count++;
                }
                else if (flag == 1 && input[i] % 2 == 0)
                {
                    flag = 0;
                    count++;
                }
                else 
                {
                    if (count > max) max = count;
                    count = 1;
                    flag = input[i] % 2 == 0 ? 0 : 1;
                }
            }
            if (count > max) max = count;

            return max;
        }
        internal static int MaxCircularSubArraySum(int[] input)
        {
            //Sum of Circular Sub Array + Sum of Remaining Linear Sub Array = Sum of Total Array
            //Find Minimum Linear Sub Array Sum and subtract from the Total Array Sum

            var sum = input[0];
            var minLinearSum = sum;

            for (int i = 1; i < input.Length; i++)
            {
                if (sum + input[i] > sum) sum = input[i];
                else sum += input[i];

                if (sum < minLinearSum) minLinearSum = sum;
            }

            if (input[input.Length - 1] < minLinearSum) minLinearSum = input[input.Length - 1];

            return input.Sum() - minLinearSum;
        }
        internal static int FindMajorityElement(int[] input)
        {
            int index = 0, count = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[index] == input[i]) count++;
                else count--;

                if (count == 0)
                {
                    count = 1;
                    index = i;
                }
            }
            count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == input[index]) count++;
            }

            if (count > input.Length / 2) return index;

            return -1;
        }
        internal static void MinimumGroupFlipsToMakeSame(int[] input)
        {
            int flips0 = 0, flips1 = 0;
            var flag0 = input[0] == 0 ? true : false;
            var flag1 = !flag0; bool hasOne = false, hasZero = false;
            var zeroIndices = flag0 ? "0" : string.Empty;
            var oneIndices = flag1 ? "1" : string.Empty;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == 1 && flag0)
                {
                    flag0 = false;
                    flips0++;
                    zeroIndices += $" to {i - 1}";
                    oneIndices += hasOne ? $", {i}" : $"{i}";
                    hasOne = true;
                }
                else if (input[i] == 0) flag0 = true;
                
                if (input[i] == 0 && flag1)
                {
                    flag1 = false;
                    flips1++;
                    zeroIndices += hasZero ? $", {i}" : $"{i}";
                    oneIndices += $" to {i - 1}";
                    hasZero = true;
                }
                else if (input[i] == 1) flag1 = true;
            }
            if (input[input.Length - 1] == 0 && hasOne)
            {
                flips0++;
                zeroIndices += $" to {input.Length - 1}";
            }
            if (input[input.Length - 1] == 1 && hasZero)
            {
                flips1++;
                oneIndices += $" to {input.Length - 1}";
            }

            if (flips0 < flips1)
            {
                Console.WriteLine("Flip 0's from: ");
                Console.WriteLine(zeroIndices);
            }
            else if (flips1 < flips0)
            {
                Console.WriteLine("Flip 1's from: ");
                Console.WriteLine(oneIndices);
            }
            else
            {
                Console.WriteLine("Flip 0's from: ");
                Console.WriteLine(zeroIndices);
                Console.WriteLine("Flip 1's from: ");
                Console.WriteLine(oneIndices);
            }
        }
        internal static int FindMaxSumOfKConsecutiveElements(int[] input, int k)
        {
            int sum = 0, max = 0;
            for (int i = 0; i < k; i++)
            {
                sum += input[i];
            }
            max = sum;
            for (int i = k; i < input.Length; i++)
            {
                sum += input[i] - input[i - k];

                if (sum > max) max = sum;
            }

            return max;
        }
        internal static bool FindSubArrayWithGivenSumInNonNegativeArray(int[] input, int sum)
        {
            var localSum = input[0];

            if (localSum == sum) return true;
            int start = 0;
            for (int i = 1; i < input.Length; i++)
            {
                var newSum = localSum + input[i];

                if (newSum == sum) return true;
                else if (newSum < sum) localSum += input[i];
                else
                {
                    while (start < i && newSum > sum)
                    {
                        newSum -= input[start];
                        start++;
                    }
                    if (newSum == sum) return true;
                    localSum = newSum;
                }
            }

            return false;
        }
        internal static int FindSumOfArrayBetweenGivenIndicesByPreprocessing(int[] input, int left, int right)
        {
            #region Pre-Processing
            int sum = input[0];
            var leftSum = new int[input.Length];
            var rightSum = new int[input.Length];
            for (int i = 1; i < input.Length; i++)
            {
                leftSum[i] = sum;
                sum += input[i];
            }
            for (int i = 0; i < input.Length; i++)
            {
                rightSum[i] = sum - leftSum[i] - input[i];
            }
            #endregion

            return sum - leftSum[left] - rightSum[right];

        }
        internal static int[] ReverseArray(int[] input)
        {
            int start = 0, end = input.Length - 1, temp;
            while (start < end)
            {
                temp = input[start];
                input[start] = input[end];
                input[end] = temp;
                start++;
                end--;
            }
            return input;
        }

    }
}