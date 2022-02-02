using System;
using System.IO;

namespace AlgorithmProblem
{
    class _1920_Find_number
    {
        static void Problem_1920()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int N = int.Parse(sr.ReadLine());
            string[] strArr1 = sr.ReadLine().Split(' ');
            int M = int.Parse(sr.ReadLine());
            string[] strArr2 = sr.ReadLine().Split(' ');

            int[] nArr = new int[N];
            int[] mArr = new int[M];

            for(int i =0; i < N; ++i)
            {
                nArr[i] = int.Parse(strArr1[i]);
            }

            for(int i = 0; i < M; ++i)
            {
                mArr[i] = int.Parse(strArr2[i]);
            }

            // 먼저 정렬
            Array.Sort(nArr);

            string strContain = "1";
            string strNotContain = "0";
            for(int i = 0; i < M; ++i)
            {
                if (hasContainOfNumber(nArr, mArr[i]) == true)
                {
                    sw.WriteLine(strContain);
                }
                else
                {
                    sw.WriteLine(strNotContain);
                }
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static bool hasContainOfNumber(int[] nArr, int n)
        {
            // 이분 탐색
            int leftIndex = 0;
            int rightIndex = nArr.Length - 1;

            while(leftIndex <= rightIndex) {
                int midIndex = (leftIndex + rightIndex) / 2;
                if (nArr[midIndex] < n)
                {
                    leftIndex = midIndex + 1;
                }
                else if (nArr[midIndex] > n)
                {
                    rightIndex = midIndex - 1;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
