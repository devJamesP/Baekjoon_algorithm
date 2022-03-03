using System;
using System.IO;

namespace AlgorithmProblem
{
    /*
     * 점화식(동적 프로그래밍)
     * nSum[n] = nSum[n] + nSum[n-3] + nArr[n-1];
     * nSum[n] = nSum[n] + nSum[n-2]
     * 마지막 계단을 밟을 조건이 다음과 같다.
     * 즉, 두개의 케이스를 비교해서 더 큰쪽으로 움직이면 된다.
     * 매번 n-1, n-3요소의 합과 n-2를 비교해서 더 큰쪽으로 이동하면 끝~
     * 
     * 단, n-1은 요소로 더해줘야 한다.
     * 이유는 n-1번째 까지의 메모리제이션의 값(nSum[n-1])이 
     * n-2에서 온건지, n-3에서 올라온건지 알수가 없음.
     * 따라서 바로 직전 계단의 점수는 더해주고, n-3번째 메모리제이션의 값을 더해주어야 함.
     */
    class _2579_go_up_the_stairs
    {
        static int[] aDP = new int[301];
        static int[] aStairs = new int[301];
        static void Problem_2579()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int N = int.Parse(sr.ReadLine());

            for (int i = 1; i <= N; ++i)
            {
                aStairs[i] = int.Parse(sr.ReadLine());
            }

            aDP[1] = aStairs[1];
            aDP[2] = aStairs[1] + aStairs[2];
            aDP[3] = Max(aStairs[1], aStairs[2]) + aStairs[3];

            //int nMaxScore = goDownStair(N);
            int nMaxScore = goUpStair(N);

            sw.WriteLine(nMaxScore);
            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }

        // 재귀호출 방식 (Top-Down)
        static int goDownStair(int N)
        {
            if (N > 3)
            {
                aDP[N] = Max(aStairs[N - 1] + goDownStair(N - 3), goDownStair(N - 2)) + aStairs[N];
            }

            return aDP[N];
        }

        // 반복문 (Bottom-Up)
        static int goUpStair(int N)
        {
            for(int i = 4; i <= N; ++i)
            {
                aDP[i] = Max(aStairs[i - 1] + aDP[i - 3], aDP[i - 2]) + aStairs[i];
            }

            return aDP[N];
        }

        static int Max(int n, int m)
        {
            return n > m ? n : m;
        }
    }
}
