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
            CheckIfSubsequence("ABCD", "DA", true);
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
    }
}
