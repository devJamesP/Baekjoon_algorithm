using System;
using System.IO;

namespace AlgorithmProblem
{
    /*
     * 분할정복 문제임
     */
    class _1708_paper_count
    {
        static int[,] nPaper;
        static int[] nArrCount = new int[3]; // 0, 1, -1
        static void Problem_1708()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int N = int.Parse(sr.ReadLine());
            nPaper = new int[N, N];
            // input
            for (int i = 0; i < N; ++i)
            {
                string[] strInputArr = sr.ReadLine().Split(' ');
                for (int j = 0; j < N; ++j)
                {
                    nPaper[i, j] = int.Parse(strInputArr[j]);
                }
            }

            // count
            countOfPaper(0, 0, N);

            // output
            sw.WriteLine(nArrCount[2]);
            sw.WriteLine(nArrCount[0]);
            sw.WriteLine(nArrCount[1]);

            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }

        static void countOfPaper(int x, int y, int length)
        {
            if (length == 1)
            {
                int ndx = nPaper[y, x] < 0 ? 2 : nPaper[y, x];
                ++nArrCount[ndx];
            }
            else
            {
                if (isSameNumber(x, y, length) == false)
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        for (int j = 0; j < 3; ++j)
                        {
                            int rlength = length / 3;
                            int ry = y + rlength * i;
                            int rx = x + rlength * j;
                            countOfPaper(rx, ry, rlength);
                        }
                    }
                }
                else
                {
                    int ndx = nPaper[y, x] < 0 ? 2 : nPaper[y, x];
                    ++nArrCount[ndx];
                }
            }
            return;
        }

        static bool isSameNumber(int x, int y, int length)
        {
            int n = nPaper[y, x];
            for (int i = y; i < y + length; ++i)
            {
                for (int j = x; j < x + length; ++j)
                {
                    if (nPaper[i, j] != n)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
