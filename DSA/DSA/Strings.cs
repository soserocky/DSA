using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA
{
    internal class Strings
    {
        internal static void Start()
        {
            //CheckIfSubsequence("ABCD", "DA", true);
            //Console.WriteLine( CheckForAnagram("AZaz", "ZuAa"));
            //Console.WriteLine(FindLexiographicalRankOfAString("ABDC"));
            Console.WriteLine(FindLongestSubstringWithDistinctCharacters("ABAACDBAB"));
        }

        private static List<string> CheckIfSubsequence(string s1, string s2, bool flag)
        {
            if (s1.Length == 1) return new List<string>() { s1, string.Empty };

            var firstChar = s1[0].ToString();
            var remainingString = s1.Substring(1);
            var list = CheckIfSubsequence(remainingString, s2, false);
            var set = new List<string>();
            foreach (var item in list)
            {
                set.Add(item);
                set.Add(firstChar + item);
            }
            if (flag)
            {
                var isPresent = false;
                foreach (var item in set)
                {
                    if (item == s2)
                    {
                        Console.WriteLine("Anagram is present");
                        isPresent = true;
                        break;
                    }
                }
                if (!isPresent)
                {
                    Console.WriteLine("Anagram is not present");
                }
            }
            return set;
        }

        private static bool CheckForAnagram(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;

            int[] arr = new int[256];

            for (int i = 0; i < s1.Length; i++)
            {
                arr[s1[i]]++;
                arr[s2[i]]--;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0) return false;
            }

            return true;
        }


        private static void NaivePatternMatching(string s1, string s2)
        {
            int i = 0, j = 0, index = 0;
            while (i < s1.Length)
            {
                if (s1[i].ToString() == s2[0].ToString())
                {
                    index = i;
                    j = 0;
                    while (j < s2.Length && i < s1.Length)
                    {
                        if (s1[i].ToString() != s2[j].ToString()) break;
                        
                        i++;
                        j++;
                    }
                    if (j == s2.Length) Console.WriteLine($"{i}");
                    else i = index;
                }
                i++;
            }
        }

        private static int FindLexiographicalRankOfAString(string input)
        {
            var permutations = FindAllPermutationsOfString(input).ToArray();
            Array.Sort(permutations);

            for (int i = 0; i < permutations.Length; i++)
            {
                if (permutations[i] == input) return i;
            }

            return -1;
        }

        private static HashSet<string> FindAllPermutationsOfString(string sortedInput)
        {
            if (sortedInput.Length == 2)
            {
                return new HashSet<string>()
                {
                    sortedInput[0].ToString() + sortedInput[1].ToString(),
                    sortedInput[1].ToString() + sortedInput[0].ToString()
                };
            }
            var result = new HashSet<string>();
            for (int i = 0; i < sortedInput.Length; i++)
            {
                var firstChar = sortedInput[i].ToString();
                var remainingString = i < sortedInput.Length - 1 ? sortedInput.Substring(0, i) + sortedInput.Substring(i + 1)
                                          : sortedInput.Substring(0, i);
                var permutations = FindAllPermutationsOfString(remainingString);

                foreach (var str in permutations)
                {
                    for (int k = 0; k < str.Length; k++)
                    {
                        result.Add(str.Insert(k, firstChar));
                    }
                }
            }
            return result;
        }

        private static string FindLongestSubstringWithDistinctCharacters(string input)
        {
            var hs = new HashSet<int>();
            hs.Add(input[0]);
            int maxCount = 1, count = 1, start = 0, s = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (hs.Add(input[i])) count++;
                else
                {
                    if (count > maxCount)
                    {
                        start = s;
                        maxCount = count;
                    }
                    s = i;
                    count = 1;
                    hs.Clear();
                    hs.Add(input[i]);
                }
            }
            return input.Substring(start, maxCount);
        }
        private int CompareStrings(string s1, string s2)
        {
            int length = s1.Length > s2.Length ? s2.Length : s1.Length;
            for (int i = 0; i < length; i++)
            {
                if (s1[i] < s2[i]) return -1;
                else if (s2[i] < s1[i]) return 1;
            }
            return 0;
        }
    }
}
