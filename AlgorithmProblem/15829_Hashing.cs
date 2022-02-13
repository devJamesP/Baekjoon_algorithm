using System;
using System.IO;

namespace AlgorithmProblem
{
    class _15829_Hashing
    {
        static void Problem_15829()
        {
            const int multi = 31;
            const int mod = 1234567891;

            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int nLength = int.Parse(sr.ReadLine());
            string strInput = sr.ReadLine();

            long sum = 0;
            long r = 1;

            for (int i = 0; i < nLength; ++i)
            {
                sum = (sum + (strInput[i] - 'a' + 1) * r) % mod;
                r = (r * multi) % mod;
            }
            sw.WriteLine(sum % mod);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
