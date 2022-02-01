using System;
using System.IO;
namespace AlgorithmProblem
{
    class _2609_Common_Factor_And_Multiple
    {
        static void Problem_2609()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            // input
            string[] strInputArr = sr.ReadLine().Split(' ');

            int n1 = int.Parse(strInputArr[0]);
            int n2 = int.Parse(strInputArr[1]);

            // 최소공배수, 최대공약수
            int min = n1 >= n2 ? n2 : n1;
            int greatestFactor = 1;
            int leastMultiple = 1;
            int i = 2;
            while (i <= n1 && i <= n2)
            {
                if (n1 % i == 0 && n2 % i == 0)
                {
                    greatestFactor *= i;
                    leastMultiple *= i;
                    n1 /= i;
                    n2 /= i;

                    i = 2;
                    continue;
                }
                ++i;
            }

            leastMultiple *= n1 * n2;

            sw.WriteLine(greatestFactor);
            sw.WriteLine(leastMultiple);

            sw.Flush();
            sr.Close();
            sw.Close();
        }

    }
}
