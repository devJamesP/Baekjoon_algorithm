using System;
using System.IO;

namespace AlgorithmProblem
{
    class _15829_Hashing
    {
        static void Problem_15829()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int nLength = int.Parse(sr.ReadLine());
            string strInput = sr.ReadLine();

            int nResult = outputHashOfAlphabet(nLength, strInput);
            sw.WriteLine(nResult );

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static int outputHashOfAlphabet(int nLength, string strInput)
        {
            int sum = 0;
            int r = 31;
            int M = 1234567891;

            for (int i = 0; i < nLength; ++i)
            {
                sum += (int)(strInput[i] - 'a' + 1) * (int)Math.Pow(r, i) % M;
            }
            return sum;
        }
    }
}
