using System;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class _1697_hide_and_seek
    {
        static void Problem_1697()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            string[] NK = sr.ReadLine().Split(' ');
            int N = int.Parse(NK[0]); // 수빈이sk 위치
            int K = int.Parse(NK[1]); // 동생sk   위치

            int nCount = count(N, K);
            sw.WriteLine(nCount);
            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }

        static int count(int N, int K)
        {
            if (N >= K)
            {
                return N - K;
            }
            else if (K == 1)
            {
                return 1;
            }
            else if ((K & 1) == 1)
            {
                return 1+Min(count(N, K - 1), count(N, K + 1));
            }
            else
                return Min(K - N, 1+count(N, K >> 1));
        }


        static int count2(int N, int K)
        {
            bool[] visited = new bool[100001];
            int nCount = 0;
            Queue<int> queue = new Queue<int>();
            int nWalk = Abs(N - K);
            visited[N] = true;
            queue.Enqueue(N);
            while(queue.Count > 0)
            {
                int nSize = queue.Count;
                for(int i = 0; i < nSize; ++i)
                {
                    int nCur = queue.Dequeue();
                    if (nCur == K)
                    {
                        return Min(nWalk, nCount);
                    }
                    if (nCur - 1 >= 0 && visited[nCur - 1] == false)
                    {
                        visited[nCur - 1] = true;
                        queue.Enqueue(nCur - 1);
                    }
                    if (nCur + 1 <= 100000 && visited[nCur + 1] == false)
                    {
                        visited[nCur + 1] = true;
                        queue.Enqueue(nCur + 1);
                    }
                    if (nCur * 2 <= 100000 && visited[nCur * 2] == false)
                    {
                        visited[nCur * 2] = true;
                        queue.Enqueue(nCur * 2);
                    }
                }
                ++nCount;
            }
            return nCount;
        }
        static int Abs(int n)
        {
            return n < 0 ? (~n + 1) : n;
        }

        static int Min(int n, int m)
        {
            return n < m ? n : m;
        }
    }
}
