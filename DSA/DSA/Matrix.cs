using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    internal class Matrix
    {
        internal static void Start()
        {
            var input = new int[,] 
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };
            //TraverseMatrixZigZag(input);
            //MatrixBoundaryTraversal(input);
            //TransposeOfMatrix(input);
            //RotateMatrixBy90(input);
            //SpiralTraversalmatrix(input);
            SearchInRowWiseColumnWiseSortedMatrix(input, 1);
        }

        private static void TraverseMatrixZigZag(int[,] input)
        {
            int rows = input.GetUpperBound(0) + 1;
            int columns = input.GetUpperBound(1) + 1;
            var left = true;
            for (int i = 0; i < input.Length; i++)
            {
                if (left)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write(input[i, j] + " ");
                    }
                }
                else
                {
                    for (int j = columns - 1; j >= 0; j--)
                    {
                        Console.Write(input[i, j] + " ");
                    }
                }
                Console.WriteLine("");
                left = !left;
            }
        }
        
        private static void MatrixBoundaryTraversal(int[,] input)
        {
            int rows = input.GetUpperBound(0) + 1;
            int columns = input.GetUpperBound(1) + 1;

            for (int i = 0; i < columns; i++)
            {
                Console.Write(input[0, i] + " ");
            }
            Console.WriteLine("");
            for (int i = 1; i < rows; i++)
            {
                Console.Write(input[i, columns - 1] + " ");
            }
            Console.WriteLine("");
            for (int i = columns - 2; i >= 0; i--)
            {
                Console.Write(input[rows - 1,i] + " ");
            }
            Console.WriteLine("");
            for (int i = rows - 2; i >= 1; i--)
            {
                Console.Write(input[i,0] + " ");
            }
            Console.WriteLine("");

        }

        private static void TransposeOfMatrix(int[,] input)
        {
            int rows = input.GetUpperBound(0) + 1;
            int columns = input.GetUpperBound(1) + 1;

            int temp;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (row < column)
                    {
                        temp = input[row, column];
                        input[row, column] = input[column, row];
                        input[column, row] = temp;
                    }
                }
            }
            Program.PrintMatrix(input);
        }

        private static void RotateMatrixBy90(int[,] input)
        {
            int rows = input.GetUpperBound(0) + 1;
            int columns = input.GetUpperBound(1) + 1;

            int[,] arr = new int[rows, columns];
            int i = 0, j = 0;
            for (int column = columns - 1; column >= 0; column--)
            {
                for (int row = 0; row < rows; row++)
                {
                    arr[i, j] = input[row, column];
                    j++;
                }
                i++;
                j = 0;
            }
           
            Program.PrintMatrix(arr);
        }

        private static void SpiralTraversalmatrix(int[,] input)
        {
            int rows = input.GetUpperBound(0) + 1;
            int columns = input.GetUpperBound(1) + 1;
            int size = input.Length;
            int n = 0, 
                left = 0, 
                right = columns - 1, 
                up = 0, 
                down = rows - 1;

            while (n < size)
            {
                for (int column = left; column <= right; column++)
                {
                    Console.Write(input[up, column] + " ");
                    n++;
                }
                up++;
                for (int row = up; row <= down; row++)
                {
                    Console.Write(input[row, right] + " ");
                    n++;
                }
                right--;
                for (int column = right; column >= left; column--)
                {
                    Console.Write(input[down, column] + " ");
                    n++;
                }
                down--;
                for (int row = down; row >= up; row--)
                {
                    Console.Write(input[row, left] + " ");
                    n++;
                }
                left++;
            }
        }

        private static void SearchInRowWiseColumnWiseSortedMatrix(int[,] input, int number)
        {
            int row = 0, column = input.GetUpperBound(1);
            while (row >= 0 && row <= input.GetUpperBound(0) && column >= 0 && column <= input.GetUpperBound(1))
            {
                int n = input[row, column];
                if (n == number)
                {
                    Console.WriteLine($"Element found at {row}, {column}");
                    return;
                }
                else if (n < number) row++;
                else column--;
            }

            Console.WriteLine($"Element not present in the given matrix");
        }
    }
}
