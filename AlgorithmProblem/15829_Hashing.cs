using System;
using System.IO;

namespace AlgorithmProblem
{
    class _15829_Hashing
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int nLength = int.Parse(sr.ReadLine());
            string strInput = sr.ReadLine();
            ulong M = 1234567891;

            ulong nResult = outputHashOfAlphabet(nLength, strInput) % M;
            sw.WriteLine(nResult);

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static ulong outputHashOfAlphabet(int nLength, string strInput)
        {
            ulong sum = 0;
            int r = 31;

            for (int i = 0; i < nLength; ++i)
            {
                sum += (ulong)(strInput[i] - 'a' + 1) * (ulong)Math.Pow(r, i);
            }
            return sum;
        }
    }
}
