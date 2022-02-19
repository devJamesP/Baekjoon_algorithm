using System;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class _1463_make_1
    {
        static void Problem_1463()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int X = int.Parse(sr.ReadLine());

            int nResult = recursiveMakeNumber1(X);

            sw.WriteLine(nResult);
            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }

        static int bfsMakeNumber1(int X)
        {
            Queue<int> queue = new Queue<int>();
            int m;
            int cnt = 0;
            queue.Enqueue(X);

            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 1; i <= size; ++i)
                {
                    m = queue.Dequeue();
                    if (m == 1)
                    {
                        return cnt;
                    }
                    else
                    {
                        if (m % 3 == 0)
                        {
                            queue.Enqueue(m / 3);
                        }
                        if (m % 2 == 0)
                        {
                            queue.Enqueue(m / 2);
                        }
                        if (m != 1)
                        {
                            queue.Enqueue(m - 1);
                        }
                    }
                }
                ++cnt;
            }
            return -1;
        }

        static int recursiveMakeNumber1(int X)
        {
            if (X < 2)
            {
                return 0;
            }

            int v1 = recursiveMakeNumber1(X / 3) + X % 3 + 1;
            int v2 = recursiveMakeNumber1(X / 2) + X % 2 + 1;

            return v1 < v2 ? v1 : v2;
        }
    }
}
