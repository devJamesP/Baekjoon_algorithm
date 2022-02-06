using System;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class _10989_SortOfNumber
    {
        static void Problem_10989()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int n = int.Parse(sr.ReadLine());
            int[] nArr = new int[10001];

            for (int i = 0; i < n; ++i)
            {
                ++nArr[int.Parse(sr.ReadLine())];
            }

            for(int i = 1; i < 10001; ++i)
            {
                for(int j = 0; j < nArr[i]; ++j)
                {
                    sw.WriteLine(i);
                }
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
