using System;
using System.IO;
using System.Collections.Generic;


namespace AlgorithmProblem
{
    /*
     * 문제 : 지렁이를 몇 마리 희생해야 내 배추밭을 전부 갉아먹는지 계산하는 프로그램
     * 
     * SCabbagePoint : 배추 위치 구조체 (y : 행, x : 열)
     * M : 배추밭 가로길이
     * N : 배추밭 세로길이
     * K : 배추심은 개수
     * nCabbageArr : 배추밭 배열
     * countCabbageWhiteEarthworm() : 배추흰지렁이 최소 필요 개수 구하는 함수
     * earthWormMoveStack : 지렁이 이동 스택
     * 
     * 원리 : Stack을 이용한 DFS
     * 
     * 1. 배추밭을 1칸씩 이동하다가(반복)
     * 배추(1)를 만나면 그 위치에 지렁이를 놓는다(지렁이 이동 스택에 현재 위치를 저장)
     * 
     * 2. 상, 하, 좌, 우를 체크해보고 배추가 있으면 해당 위치로 지렁이를 1칸 이동시킨다.(지렁이 이동 스택에 위치를 저장)
     * 
     * 3. 이미 이동했기 때문에 배추밭의 배추(1)를 지렁이한테 갉아먹으라고 한다. (0으로 바꿔줌)
     * 
     * 4. 이를 반복하다가 상, 하, 좌, 우를 체크하고 더 이상 이동할 곳이 없으면 (스택을 차례대로 1칸씩 ) 스택을 비워준다.
     * 
     * 5. 전부 비워지면 자동으로 지렁이가 사망한다.
     * 
     * 6. 이를 반복하면 지렁이가 몇마리 희생해야 하는지 갯수가 나온다.
     * 
     * 7. 끝!!!!!!!!
     */
    class _1012_organic_cabbage
    {
        struct SCabbagePoint
        {
            public int X;
            public int Y;
            public SCabbagePoint(int y, int x)
            {
                this.Y = y;
                this.X = x;
            }
        }

        static void Problem_1012()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int nTestCase = int.Parse(sr.ReadLine());
            int[] nInputArr;
            int M;
            int N;
            int K;
            int[,] nCabbageArr;

            // input
            int[] nPoint;
            int nEarchwormCounter;
            for (int i = 0; i < nTestCase; ++i)
            {
                nEarchwormCounter = 0;
                nInputArr = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
                M = nInputArr[0];
                N = nInputArr[1];
                K = nInputArr[2];
                nCabbageArr = new int[M, N];

                for (int j = 0; j < K; ++j)
                {
                    nPoint = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
                    nCabbageArr[nPoint[0], nPoint[1]] = 1;
                }

                nEarchwormCounter = countCabbageWhiteEarthworm(nCabbageArr);
                sw.WriteLine(nEarchwormCounter);
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static int countCabbageWhiteEarthworm(int[,] nCabbageArr)
        {
            Stack<SCabbagePoint> earthWormMoveStack = new Stack<SCabbagePoint>();
            int count = 0;

            for (int i = 0; i < nCabbageArr.GetLength(0); ++i)
            {
                for (int j = 0; j < nCabbageArr.GetLength(1); ++j)
                {
                    if (nCabbageArr[i, j] == 0)
                    {
                        continue;
                    }
                    earthWormMoveStack.Push(new SCabbagePoint(i, j));
                    ++count;

                    while (earthWormMoveStack.Count != 0)
                    {
                        SCabbagePoint wormPoint = earthWormMoveStack.Peek();

                        SCabbagePoint nextTopPoint = new SCabbagePoint(wormPoint.Y - 1, wormPoint.X);
                        SCabbagePoint nextBottomPoint = new SCabbagePoint(wormPoint.Y + 1, wormPoint.X);
                        SCabbagePoint nextLeftPoint = new SCabbagePoint(wormPoint.Y, wormPoint.X - 1);
                        SCabbagePoint nextRightPoint = new SCabbagePoint(wormPoint.Y, wormPoint.X + 1);

                        if (wormPoint.Y != 0 && nCabbageArr[nextTopPoint.Y, nextTopPoint.X] == 1)
                        {
                            earthWormMoveStack.Push(nextTopPoint);
                        }
                        else if (wormPoint.Y != nCabbageArr.GetLength(0) - 1 && nCabbageArr[nextBottomPoint.Y, nextBottomPoint.X] == 1)
                        {
                            earthWormMoveStack.Push(nextBottomPoint);
                        }
                        else if (wormPoint.X != 0 && nCabbageArr[nextLeftPoint.Y, nextLeftPoint.X] == 1)
                        {
                            earthWormMoveStack.Push(nextLeftPoint);
                        }
                        else if (wormPoint.X != nCabbageArr.GetLength(1) - 1 && nCabbageArr[nextRightPoint.Y, nextRightPoint.X] == 1)
                        {
                            earthWormMoveStack.Push(nextRightPoint);
                        }
                        else
                        {
                            earthWormMoveStack.Pop();
                        }
                        nCabbageArr[wormPoint.Y, wormPoint.X] = 0;
                    }
                }
            }

            return count;
        }

    }
}
