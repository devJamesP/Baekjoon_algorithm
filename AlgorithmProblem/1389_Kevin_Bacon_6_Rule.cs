using System;
using System.IO;
using System.Collections.Generic;
namespace AlgorithmProblem
{
    /*
     * bMeet : 케빈 베이컨 게임을 했을 때 만나는 사람 체크 (중복 되면 안되니깐~)
     * relations : 인맥 연결도 (내 삼촌의 동생의 큰아버지의 아버지가 대통령이면 케빈베이커 게임에 따라 대통령은 내 친구다)
     * N : 유저의 수
     * M : 친구 관계의 수
     * 
     * [풀이]
     * BFS 문제이다.
     * BFS의 깊이를 구하면 풀리는 문제이다~
     * BFS의 특징은 찾고자 하는 노드의 최단경로를 구할 수 있다.
     * 찾고자 하는 노드가 얕을 수록 빠르게 찾을 수 있지만 만약 노드가 없다면 시간이 오래 걸린다.
     */
    class _1389_Kevin_Bacon_6_Rule
    {
        static bool[] bMeet = new bool[101];
        static int[,] relations = new int[101, 101];
        static int N;
        static int M;
        static void Problem_1389()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int[] NM = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            N = NM[0] + 1;
            M = NM[1] + 1;
            int min = int.MaxValue;
            int nResult = 1;

            // input
            string[] strInputRelations;
            int p;
            int q;
            for (int i = 1; i < M; ++i)
            {
                strInputRelations = sr.ReadLine().Split(' ');
                p = int.Parse(strInputRelations[0]);
                q = int.Parse(strInputRelations[1]);
                relations[p, q] = 1;
                relations[q, p] = 1;
            }

            // calc
            int minKBNum;
            for (int i = 1; i < N; ++i)
            {
                minKBNum = getKevinBaconNum(i);
                if (min > minKBNum)
                {
                    min = minKBNum;
                    nResult = i;
                }
            }

            // output
            sw.WriteLine(nResult);
            sw.Flush();
            sr.Close();
            sw.Close();
        }
        static int getKevinBaconNum(int start)
        {
            int sum = 0;
            for (int i = 1; i < N; ++i)
            {
                if (i == start)
                {
                    continue;
                }
                sum += nMinRelations(start, i);
                for(int j = 1; j < N; ++j)
                {
                    bMeet[j] = false;
                }
            }
            return sum;
        }
        static int nMinRelations(int start, int target)
        {
            Queue<int> queue = new Queue<int>();
            int nLevel = 0;

            queue.Enqueue(start);
            bMeet[start] = true;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 1; i <= size; ++i)
                {
                    int v = queue.Dequeue();
                    if (v == target)
                    {
                        return nLevel;
                    }
                    for (int j = 1; j < N; ++j)
                    {
                        if (bMeet[j] == false && relations[v, j] == 1)
                        {
                            bMeet[j] = true;
                            queue.Enqueue(j);
                        }
                    }
                }
                ++nLevel;
            }
            return -1;
        }
    }
}
