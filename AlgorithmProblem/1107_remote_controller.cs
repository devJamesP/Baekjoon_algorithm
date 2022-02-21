using System;
using System.IO;

namespace AlgorithmProblem
{
    class _1107_remote_controller
    {
        static bool[] remote = new bool[10];
        static void Problem_1107()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int N = int.Parse(sr.ReadLine());
            int M = int.Parse(sr.ReadLine());
            int[] brokenNum;
            if (M > 0)
            {
                brokenNum = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
                for (int i = 0; i < M; ++i)
                {
                    // 부서진 버튼 true
                    remote[brokenNum[i]] = true;
                }
            }

            int iPMMove = abs(100 - N); // +/-로만 이동
            int iCount = 0; // 
            while(true)
            {
                if (iCount >= iPMMove)
                {
                    break;
                } 
                // N을 기준으로 +/-1씩 점진적으로 부서진 버튼의 숫자를 포함하고 있는지 체크
                // 포함하고 있지 않다면 움직인 거리 + 해당 숫자의 길이
                if (isContainBrokenNumber(N - iCount) == true)
                {
                    iCount += GetNumberLength(N - iCount);
                    break;
                }
                else if (isContainBrokenNumber(N + iCount) == true)
                {
                    iCount += GetNumberLength(N + iCount);
                    break;
                }
                ++iCount;
            }

            sw.WriteLine(minCount(iCount, iPMMove));
            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }
        static bool isContainBrokenNumber(int n)
        {
            if (n < 0)
            {
                return false;
            }

            while(true)
            {
                if (remote[n % 10] == true)
                {
                    return false;
                }
                n /= 10;
                if (n == 0)
                {
                    break;
                }
            }

            return true;
        }

        static int GetNumberLength(int n)
        {
            int length = 0;
            while(true)
            {
                ++length;
                n /= 10;
                if (n == 0)
                {
                    break;
                }
            }
            return length;
        }

        static int minCount(int n, int m)
        {
            return n < m ? n : m;
        }

        static int abs(int n)
        {
            return n < 0 ? (~n + 1) : n;
        }
    }
}
