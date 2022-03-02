using System;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmProblem
{

    class _2178_maze_exploration
    {
        struct SPoint
        {
            int nX;
            public int NX { get { return nX; } }
            int nY;
            public int NY { get { return nY; } }
            bool bMove;
            public bool BMove { get { return bMove; } }
            public SPoint(int nX, int nY, bool bMove)
            {
                this.nX = nX;
                this.nY = nY;
                this.bMove = bMove;
            }
        }

        static void Problem_2178()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            string[] NM = sr.ReadLine().Split(' ');
            int N = int.Parse(NM[0]);
            int M = int.Parse(NM[1]);

            SPoint[,] aMap = new SPoint[N, M];
            for (int i = 0; i < N; ++i)
            {
                string strLine = sr.ReadLine();
                for (int j = 0; j < strLine.Length; ++j)
                {
                    aMap[i, j] = new SPoint(j, i, strLine[j] - '0' == 1);
                }
            }

            int nCount = getMinCountOfPass(aMap, N, M);

            sw.WriteLine(nCount);
            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }

        static int getMinCountOfPass(SPoint[,] aMap, int N, int M)
        {
            // 방문 체크, 카운터
            Queue<SPoint> queue = new Queue<SPoint>();
            bool[,] visited = new bool[N, M];
            int nCount = 0;

            // 이동축
            int nMoveLength = 4;
            int[] aXAxis = new int[4] { -1, 1, 0, 0 };
            int[] aYAxis = new int[4] { 0, 0, -1, 1 };

            queue.Enqueue(aMap[0, 0]);
            ++nCount;
            while (queue.Count > 0)
            {
                if (visited[N - 1, M - 1] == true)
                {
                    break;
                }

                int size = queue.Count;
                for (int i = 0; i < size; ++i)
                {
                    SPoint v = queue.Dequeue();
                    for(int k = 0; k < nMoveLength; ++k)
                    {
                        int x = v.NX + aXAxis[k];
                        int y = v.NY + aYAxis[k];

                        if (isPassingMaze(aMap, x, y, visited) == true)
                        {
                            visited[y, x] = true;
                            queue.Enqueue(new SPoint(x, y, true));
                        }
                    }
                }
                ++nCount;
            }

            return nCount;
        }

        static bool isPassingMaze(SPoint[,] aMap, int x, int y, bool[,] visited)
        {
            // 이동 유효 범위 체크
            if (y < 0 || x < 0 || y >= aMap.GetLength(0) || x >= aMap.GetLength(1))
            {
                return false;
            }
            // 방문 가능 체크
            if (aMap[y, x].BMove == false || visited[y, x] == true)
            {
                return false;
            }

            return true;
        }
    }
}
