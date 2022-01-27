using System;
using System.IO;

namespace AlgorithmProblem
{
    class _2475_NumberOfVerifications
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string[] strInputArr = sr.ReadLine().Split(' ');
            int[] nUniqueNumArr = new int[5];
            int nSum = 0;
            for (int i = 0; i < 5; ++i)
            {
                nUniqueNumArr[i] = int.Parse(strInputArr[i]);
                nSum += nUniqueNumArr[i] * nUniqueNumArr[i];
            }

            sw.WriteLine(nSum % 10);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
