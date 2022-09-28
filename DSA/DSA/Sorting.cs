namespace DSA
{
    internal class Sorting
    {
        internal static void Start()
        {
            //Program.PrintArray(BubbleSort(new int[] {10,2,3,4,1,8,-9}));
            //Program.PrintArray(SelectionSort(new int[] {10,2,3,4,1,8,2,-9}));
            //Program.PrintArray(InsertionSort(new int[] {10,2,3,4,1,8,2,-9}));
            //Program.PrintArray(MergeTwoSortedArrays(new int[] {0, 2, 4, 6, 8, 10}, new int[] { 1, 3, 5, 7, 9 }));
            //Program.PrintArray(MergeFunctionOfMergedSort(new int[] {0, 2, 4, 6, 8, 10, 1, 3, 5, 7, 9 }, 0, 5, 10));
            //Program.PrintArray(MergeSort(new int[] {0, 2, 4, 6, 8, 10, 1, 3, 5, 7, 9 }, 0, 10));
            //IntersectionOf2SortedArrays(new int[] { 3, 5, 10, 10, 10, 15, 15, 20 }, new int[] { 5, 10, 10, 15, 30 });
            //UnionOf2SortedArrays(new int[] { 2, 3, 3, 4, 4 }, new int[] { 4, 4 });
            //NaivePartition(new int[] { 2, 30, 7, 20, 10 }, 4);
            //Console.WriteLine(LomutoPartition(new int[] { 0, 2, 4, 6, 8, 10, 1, 9, 3, 5, 7 }, 0, 10));
            //Console.WriteLine(HoarePartition(new int[] { 5, 3, 0, 7, 9, 2, 4, 6, 8, 10, 1 }, 0, 10));
            //Program.PrintArray(QuickSortUsingLomutoPartition(new int[] { 0, 2, 4, 6, 8, 10, 1, 9, 3, 5, 7 }, 0, 10));
            //Program.PrintArray(QuickSortUsingLomutoPartition(new int[] { 0, 2, 4, 6, 8, 10, 1, 9, 3, 5, 7 }, 0, 10));
            //Program.PrintArray(QuickSortUsingHoarePartition(new int[] { 0, 2, 4, 6, 8, 10, 1, 9, 3, 5, 7 }, 0, 10));
            Console.WriteLine(KthSmallestElementInDistinctArray(new int[] { 5, 3, 0, 7, 9, 2, 4, 6, 8, 10, 1 }, 0, 10, 6));
        }

        private static int[] BubbleSort(int[] input)
        {
            int temp; bool swapped;
            for (int i = 0; i < input.Length; i++)
            {
                swapped = false;
                for (int j = 1; j < input.Length; j++)
                {
                    if (input[j] < input[j - 1])
                    {
                        temp = input[j];
                        input[j] = input[j - 1];
                        input[j - 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped) return input;
            }
            return input;
        }

        private static int[] SelectionSort(int[] input)
        {
            int minIndex, temp;
            for (int i = 0; i < input.Length; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[j] < input[minIndex]) minIndex = j; 
                }
                temp = input[i];
                input[i] = input[minIndex];
                input[minIndex] = temp;
            }
            return input;
        }

        private static int[] InsertionSort(int[] input)
        {
            int temp, j;
            for (int i = 0; i < input.Length - 1; i++)
            {
                j = i + 1;
                while (j > 0)
                {
                    if (input[j] < input[j - 1])
                    {
                        temp = input[j - 1];
                        input[j - 1] = input[j];
                        input[j] = temp;
                        j--;
                    }
                    else break;
                }
            }

            return input;
        }

        private static int[] MergeTwoSortedArrays(int[] input1, int[] input2)
        {
            int pointer1 = 0, pointer2 = 0, pointer = 0;
            var mergedOutput = new int[input1.Length + input2.Length];
            while (pointer < mergedOutput.Length)
            {
                if (input1[pointer1] < input2[pointer2])
                {
                    mergedOutput[pointer] = input1[pointer1];
                    if (pointer1 < input1.Length - 1) pointer1++;
                    else
                    {
                        pointer++;
                        for (int i = pointer2; i < input2.Length; i++)
                        {
                            mergedOutput[pointer] = input2[i];
                            pointer++;
                        }
                        break;
                    }
                }
                else
                {
                    mergedOutput[pointer] = input2[pointer2];
                    if (pointer2 < input2.Length - 1) pointer2++;
                    else
                    {
                        pointer++;
                        for (int i = pointer1; i < input1.Length; i++)
                        {
                            mergedOutput[pointer] = input1[i];
                            pointer++;
                        }
                        break;
                    }
                }
                pointer++;
            }
            return mergedOutput;
        }

        private static int[] MergeFunctionOfMergedSort(int[] input, int low, int mid, int high)
        {
            int[] left = new int[mid - low + 1];
            int[] right = new int[high - mid];
            int pointer1 = 0, pointer2 = 0, pointer = low;
            for (int i = low; i <= high; i++)
            {
                if (i <= mid)
                    left[i - low] = input[i];
                else
                    right[i - mid - 1] = input[i];
            }

            while (pointer1 < left.Length && pointer2 < right.Length)
            {
                if (left[pointer1] < right[pointer2])
                {
                    input[pointer] = left[pointer1];
                    pointer1++;
                }
                else
                {
                    input[pointer] = right[pointer2];
                    pointer2++;
                }
                pointer++;
            }
            if (pointer1 == left.Length)
            {
                for (int i = pointer2; i < right.Length; i++)
                {
                    input[pointer] = right[i];
                    pointer++;
                }
            }
            if (pointer2 == right.Length)
            {
                for (int i = pointer1; i < left.Length; i++)
                {
                    input[pointer] = left[i];
                    pointer++;
                }
            }

            return input;
        }

        private static int[] MergeSort(int[] input, int low, int high)
        {
            if (high > low)
            {
                int mid = low + (high - low) / 2; //To avoid overflow of Index
                MergeSort(input, low, mid);
                MergeSort(input, mid + 1, high);
                MergeFunctionOfMergedSort(input, low, mid, high);
            }
            return input;
        }
        
        private static void IntersectionOf2SortedArrays(int[] input1, int[] input2)
        {
            int pointer1 = 0, pointer2 = 0;
            while (pointer1 < input1.Length && pointer2 < input2.Length)
            {
                if (pointer1 > 0 && input1[pointer1] == input1[pointer1 - 1])
                {
                    pointer1++;
                    continue;
                }
                if (pointer2 > 0 && input2[pointer2] == input2[pointer2 - 1])
                {
                    pointer2++;
                    continue;
                }
                if (input1[pointer1] == input2[pointer2])
                {
                    Console.Write(input1[pointer1] + " ");
                    pointer1++;
                    pointer2++;
                }
                else if (input1[pointer1] < input2[pointer2]) pointer1++;
                else pointer2++;
            }

        }
        private static void UnionOf2SortedArrays(int[] input1, int[] input2)
        {
            int pointer1 = 0, pointer2 = 0;
            while (pointer1 < input1.Length && pointer2 < input2.Length)
            {
                if (pointer1 > 0 && input1[pointer1] == input1[pointer1 - 1])
                {
                    pointer1++;
                    continue;
                }
                if (pointer2 > 0 && input2[pointer2] == input2[pointer2 - 1])
                {
                    pointer2++;
                    continue;
                }
                if (input1[pointer1] == input2[pointer2])
                {
                    Console.Write(input1[pointer1] + " ");
                    pointer1++;
                    pointer2++;
                }
                else if (input1[pointer1] < input2[pointer2])
                {
                    Console.Write(input1[pointer1] + " ");
                    pointer1++;
                }
                else
                {
                    Console.Write(input2[pointer2] + " ");
                    pointer2++;
                }
            }
            if (pointer1 == input1.Length)
            {
                while (pointer2 < input2.Length)
                {
                    if (input2[pointer2] > input2[pointer2 - 1]) Console.Write(input2[pointer2] + " ");
                    pointer2++;
                }
            }
            if (pointer2 == input2.Length)
            {
                while (pointer1 < input1.Length)
                {
                    if (input1[pointer1] > input1[pointer1 - 1]) Console.Write(input1[pointer1] + " ");
                    pointer1++;
                }
            }
        }

        private static void NaivePartition(int[] input, int p)
        {
            var arr = new int[input.Length];
            var pointer = -1; 
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] <= input[p])
                {
                    pointer++;
                    arr[pointer] = input[i];
                }
            }
            pointer++;
            arr[pointer] = input[p];
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > input[p])
                {
                    pointer++;
                    arr[pointer] = input[i];
                }
            }
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = arr[i];
            }
        }

        //Lomuto partition ensures that:
        //1. Pivot is at its correct index
        //2. All numbers to the left of the returned value are smaller than pivot
        //3. All numbers to the right of the returned value are greater than pivot
        private static int LomutoPartition(int[] input, int low, int high)
        {
            var pivot = input[high];
            int smallerNumbersWindow = low - 1, temp;
            for (int i = low; i <= high - 1; i++)
            {
                if (input[i] < pivot)
                {
                    smallerNumbersWindow++;
                    temp = input[smallerNumbersWindow];
                    input[smallerNumbersWindow] = input[i];
                    input[i] = temp;
                }
            }
            temp = input[smallerNumbersWindow + 1];
            input[smallerNumbersWindow + 1] = input[high];
            input[high] = temp;
            return smallerNumbersWindow + 1;
        }


        //Hoare partition ensures that:
        //1. Pivot may or may not be at its correct index (unlike, Lomuto partition)
        //2. All numbers to the left of returned value are smaller than or equal to pivot
        //3. All numbers to the right of returned value are greater than or equal to pivot
        private static int HoarePartition(int[] input, int low, int high)
        {
            var pivot = input[low];
            int smallerNumbersWindow = low - 1;
            int greaterNumbersWindow = high + 1;
            int temp;
            while (true)
            {
                smallerNumbersWindow++;
                while (input[smallerNumbersWindow] < pivot)
                {
                    smallerNumbersWindow++;
                }
                greaterNumbersWindow--;
                while (input[greaterNumbersWindow] > pivot)
                {
                    greaterNumbersWindow--;
                }
                if (smallerNumbersWindow >= greaterNumbersWindow) return greaterNumbersWindow;

                temp = input[smallerNumbersWindow];
                input[smallerNumbersWindow] = input[greaterNumbersWindow];
                input[greaterNumbersWindow] = temp;
            }
            return -1;
        }

        private static int[] QuickSortUsingLomutoPartition(int[] input, int low, int high)
        {
            if (low < high)
            {
                int partition = LomutoPartition(input, low, high);
                QuickSortUsingLomutoPartition(input, low, partition - 1);
                QuickSortUsingLomutoPartition(input, partition + 1, high);
            }
            return input;
        }

        private static int[] QuickSortUsingHoarePartition(int[] input, int low, int high)
        {
            if (low < high)
            {
                int partition = HoarePartition(input, low, high);
                QuickSortUsingHoarePartition(input, low, partition);
                QuickSortUsingHoarePartition(input, partition + 1, high);
            }
            return input;
        }

        private static int KthSmallestElementInDistinctArray(int[] input, int low, int high, int k)
        {
            if (low == high) return input[low];
            if (low < high)
            {
                int partition = LomutoPartition(input, low, high);

                if (partition == k - 1) return input[partition];
                else if (partition > k - 1) return KthSmallestElementInDistinctArray(input, low, partition - 1, k);
                return KthSmallestElementInDistinctArray(input, partition + 1, high, k);
            }
            return -1;
        }
    }
}