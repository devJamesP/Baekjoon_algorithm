using System;
using System.IO;
using System.Text;

namespace AlgorithmProblem
{
    class _1003_Fibonacci
    {
        static void Problem_1003()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
            StringBuilder sb = new StringBuilder();

            int[] fiboArr = new int[42];

            int n = int.Parse(sr.ReadLine());
            int num;

            // Case 1
            //int zeroCounter = 0;
            //int oneCounter = 0;
            //for (int i = 0; i < n; ++i)
            //{
            //    num = int.Parse(sr.ReadLine());
            //    fibonacciZeroAndOneCounter(num, ref zeroCounter, ref oneCounter);
            //    sb.Append(zeroCounter + " " + oneCounter + "\n");
            //}


            // Case 2
            CalcFiboZeroCounter(fiboArr);
            for(int i = 0; i < n; ++i)
            {
                num = int.Parse(sr.ReadLine());
                sb.AppendLine(fiboArr[num] + " " + fiboArr[num + 1]);
            }

            sw.WriteLine(sb.ToString());
            sw.Flush();
            sr.Close();
            sw.Close();
        }

        // Case 1
        static void fibonacciZeroAndOneCounter(int n, ref int zeroCounter, ref int oneCounter)
        {
            zeroCounter = 1;
            oneCounter = 0;

            int prevZeroCount;
            for(int i = 1; i <= n; ++i)
            {
                prevZeroCount = zeroCounter;
                zeroCounter = oneCounter;
                oneCounter = prevZeroCount  + oneCounter;
            }
            return;
        }

        // Case 2
        static void CalcFiboZeroCounter(int[] fiboZeroCounterArr)
        {
            fiboZeroCounterArr[0] = 1;
            int oneCounter = 0;

            int prevZeroCounter;
            for (int i = 1; i < fiboZeroCounterArr.Length; ++i)
            {
                prevZeroCounter = fiboZeroCounterArr[i - 1];
                fiboZeroCounterArr[i] = oneCounter;
                oneCounter = prevZeroCounter + oneCounter;
            }
            return;
        }

    }
}
