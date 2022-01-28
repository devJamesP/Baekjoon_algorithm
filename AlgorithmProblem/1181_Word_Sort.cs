using System;
using System.IO;
using System.Collections;

namespace AlgorithmProblem
{
    class _1181_Word_Sort
    {
        static void Problem_1181() { 
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int nWordCount = int.Parse(sr.ReadLine());
            string[] strWordArr = new string[nWordCount];

            // input
            for (int i = 0; i < nWordCount; ++i)
            {
                strWordArr[i] = sr.ReadLine();
            }

            Array.Sort(strWordArr, new SortWord());
            sw.WriteLine(strWordArr[0]);
            for(int i = 1; i < strWordArr.Length; ++i)
            {
                if (strWordArr[i-1] != strWordArr[i])
                {
                    sw.WriteLine(strWordArr[i]);
                }
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }

    class SortWord : IComparer
    {
        public int Compare(object x, object y)
        {
            string word1 = (string)x;
            string word2 = (string)y;

            if (word1.Length == word2.Length)
            {
                // 사전 비교
                return word1.CompareTo(word2);
            }
            else
            {
                // 길이 비교
                if (word1.Length > word2.Length)
                {
                    return 1;
                }
                else if (word1.Length <= word2.Length)
                {
                    return -1;
                }
            }
            return -1;
        }
    }
}
