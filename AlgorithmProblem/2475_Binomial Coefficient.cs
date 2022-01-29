using System;
using System.IO;
namespace AlgorithmProblem
{
    class _2475_Binomial_Coefficient
    {
        static void Problem_2475()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string[] strInputArr = sr.ReadLine().Split(' ');

            int n = int.Parse(strInputArr[0]);
            int k = int.Parse(strInputArr[1]);

            int nResult = factorial(n, 1) / (factorial(k, 1) * factorial(n - k, 1));
            sw.WriteLine(nResult);

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static int factorial(int n, int sum)
        {
            if (n <= 1)
            {
                return sum;
            }
            return factorial(n-1, sum * n); 
        }
    }
}
