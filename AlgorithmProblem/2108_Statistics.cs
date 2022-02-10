using System;
using System.IO;
using System.Collections.Generic;
namespace AlgorithmProblem
{
    class _2108_Statistics
    {
        static void Problem_2108()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int nNumCase = int.Parse(sr.ReadLine());
            int[] nArr = new int[nNumCase];
            for(int i = 0; i < nNumCase; ++i)
            {
                nArr[i] = int.Parse(sr.ReadLine());
            }

            int n1;
            int n2;
            int n3;
            int n4;

            calcArithmeticMeanNum(nArr, out n1);
            calcMedianNum(nArr, out n2);
            calcModeNum(nArr, out n3);
            calcRangeNum(nArr, out n4);

            // 산술평균
            sw.WriteLine(n1);
            sw.WriteLine(n2);
            sw.WriteLine(n3);
            sw.WriteLine(n4);

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        // 산술평균 계산
        static void calcArithmeticMeanNum(int[] nArr, out int n)
        {
            double dSum = 0;
            for(int i = 0; i < nArr.Length; ++i)
            {
                dSum += nArr[i];
            }
            n = (int)Math.Round(dSum / nArr.Length);
        }

        // 중앙값 계산
        static void calcMedianNum(int[] nArr, out int n)
        {
            Array.Sort(nArr);
            n = nArr[nArr.Length / 2];
        }

        // 최빈값 계산
        static void calcModeNum(int[] nArr, out int n)
        {
            Array.Sort(nArr);
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nArr.Length; ++i)
            {
                if (dict.ContainsKey(nArr[i]) == false)
                {
                    dict.Add(nArr[i], 0);
                }
                ++dict[nArr[i]];
            }

            n = nArr[0];
            bool bSecondMax = false;
            for(int i = 1; i < nArr.Length; ++i)
            {
                if (dict[n] == dict[nArr[i]])
                {
                    if (n < nArr[i] && bSecondMax == false)
                    {
                        n = nArr[i];
                        bSecondMax = true;
                    }
                }
                else if (dict[n] < dict[nArr[i]])
                {
                    n = nArr[i];
                    bSecondMax = false;
                }
            }
        }

        // 범위 계산
        static void calcRangeNum(int[] nArr, out int n)
        {
            Array.Sort(nArr);
            n = nArr[nArr.Length - 1] - nArr[0];
        }
    }
}