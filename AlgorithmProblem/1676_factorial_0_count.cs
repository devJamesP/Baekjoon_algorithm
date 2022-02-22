using System;
using System.IO;

namespace AlgorithmProblem
{
    class _1676_factorial_0_count
    {
        static void Problem_1676()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int n = int.Parse(sr.ReadLine());
            int nCount = 0;
            for(int i = 5; i <= n; i*=5)
            {
                nCount += n / i;
            }
            sw.WriteLine(nCount);
            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }
    }
}
