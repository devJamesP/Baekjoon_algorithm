using System;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    struct SPoint
    {
        int x;
        public int X { get { return x; } }
        
        int y;
        public int Y { get { return y; } }

        public SPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class _2667_numbering
    {
        static void Problem_2667()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            bool[,] visited = new bool[25, 25];
            int N = int.Parse(sr.ReadLine());
            int[,] aMap = new int[N,N];
            List<int> nReslutList = new List<int>();

            // input
            for(int i = 0; i < N; ++i)
            {
                string strShape = sr.ReadLine();
                for(int j = 0; j < strShape.Length; ++j)
                {
                    aMap[i, j] = strShape[j] - '0';
                }
            }

            // calc
            numberingApartment(visited, aMap, nReslutList);
            nReslutList.Sort();

            // output
            sw.WriteLine(nReslutList.Count);
            for (int i = 0; i < nReslutList.Count; ++i)
            {
                sw.WriteLine(nReslutList[i]);
            }

            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }

        static void numberingApartment(bool[,] visited, int[,] aMap, List<int> nReslutList)
        {
            for(int i = 0; i < aMap.GetLength(0); ++i)
            {
                for(int j = 0; j < aMap.GetLength(1); ++j)
                {
                    if (visited[i,j] == true || aMap[i,j] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        // 카운팅
                        int nCount = countOfConnetedHouse(j, i, visited, aMap);
                        nReslutList.Add(nCount);
                    }
                }
            }

            return;
        }

        // 집이 있는 곳을 DFS를 이용하여 갯수를 센다.
        static int countOfConnetedHouse(int x, int y, bool[,] visited, int[,] aMap)
        {
            Stack<SPoint> stack = new Stack<SPoint>();
            int[] aX = { 0, 0, -1, 1 };
            int[] aY = { -1, 1, 0, 0 };
            int nCount = 0;
            int len = aMap.GetLength(0);

            stack.Push(new SPoint(x, y));
            visited[y, x] = true;
            ++nCount;

            while(stack.Count > 0)
            {
                SPoint v = stack.Pop();
                for(int i = 0; i < 4; ++i)
                {
                    int nextX = v.X + aX[i];
                    int nextY = v.Y + aY[i];
                    if (isMove(nextX, nextY, len) == true)
                    {
                        if (visited[nextY, nextX] == false && aMap[nextY, nextX] == 1)
                        {
                            stack.Push(v);
                            stack.Push(new SPoint(nextX, nextY));
                            visited[nextY, nextX] = true;
                            ++nCount;
                        }
                    }
                }
            }

            return nCount;
        }

        // 유효한 범위의 인덱스인지 체크
        static bool isMove(int x, int y, int len)
        {
            return (x >= 0 && y >= 0 && x < len && y < len);
        }
    }
}
