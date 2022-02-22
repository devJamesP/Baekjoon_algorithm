using System;
using System.IO;

namespace AlgorithmProblem
{
    /*
     *수빈이는 동생과 숨바꼭질을 하고 있다. 수빈이는 현재 점 N(0 ≤ N ≤ 100,000)에 있고, 동생은 점 K(0 ≤ K ≤ 100,000)에 있다. 수빈이는 걷거나 순간이동을 할 수 있다. 만약, 수빈이의 위치가 X일 때 걷는다면 1초 후에 X-1 또는 X+1로 이동하게 된다. 순간이동을 하는 경우에는 1초 후에 2*X의 위치로 이동하게 된다.

수빈이와 동생의 위치가 주어졌을 때, 수빈이가 동생을 찾을 수 있는 가장 빠른 시간이 몇 초 후인지 구하는 프로그램을 작성하시오.
     *
     */
    class _1697_hide_and_seek
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            string[] NK = sr.ReadLine().Split(' ');
            int N = int.Parse(NK[0]);
            int K = int.Parse(NK[1]);

            int nWalk = K - N;
            int nCount = int.MaxValue;

            while(true)
            {


                // 텔레포트 하고 난 후 걸어서 계산
                // min값에 저장
                // 이를 반복해서 텔레포트 한 후 이전값보다 더 큰값이 나올때까지 반복
            }



            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }

        static int Abs(int n)
        {
            return n < 0 ? (~n + 1) : n;
        }

        static int Pow(int n, int m)
        {
            return n << m;
        }
    }
}
