using System;
using System.IO;

namespace AlgorithmProblem
{
    /*
     * 문제 : Z 무빙으로 탐색했을 때 r행 c열을 몇번째로 방문하는지 구하기
     * N : 2^(N-1)의 지수값 (행렬의 크기)
     * r : 행
     * c : 열
     * 
     * 풀이 : 
     * 분할해서 정복하면 문제가 풀린다.
     * 처음에 갈피를 잡기 어려운데 구글링을 통해 알아보자!
     */


    class _1074_Z
    {
        static int N;
        static int r;
        static int c;
        static int nCount = 0;
        static int nResult;
        static void Problem_1074()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int[] nInputArr = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            N = nInputArr[0];
            r = nInputArr[1];
            c = nInputArr[2];

            divideZ(0, 0, Pow(2, N));

            sw.WriteLine(nResult);
            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static int Pow(int num, int square)
        {
            int res = 1;
            for (int i = 0; i < square; ++i)
            {
                res *= num;
            }
            return res;
        }

        static void divideZ(int x, int y, int len)
        {
            if (r == y && c == x)
            {
                nResult = nCount;
                return;
            }

            if (len == 1)
            {
                ++nCount;
                return;
            }

            if (r >= y && r < y + len && c >= x && x < x + len)
            {
                divideZ(x, y, len / 2);
                divideZ(x + len / 2, y, len / 2);
                divideZ(x, y + len / 2, len / 2);
                divideZ(x + len / 2, y + len / 2, len / 2);
            }
            else
            {
                nCount += len * len;
            }

            return;
        }
    }
}
