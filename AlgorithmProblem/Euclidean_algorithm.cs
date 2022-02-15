using System;
using System.IO;
namespace AlgorithmProblem
{
    class Euclidean_algorithm
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        /*
         * 두 자연수 또는 정식의 최대공약수를 구하는 알고리즘
         * 
         * 두 자연수 a, b (a > b)
         * GCD = 최대공약수
         * LCM = 최소공배수
         * a x b 는 GCD x LCM 이다.
         * 
         * 
         * a mod b == 0 (b 가 gcd)
         * a mod b != 0이면 (a % b == c라고 했을 때)
         * b mod c == 0인지 체크하면 위의 과정을 반복한다.
         * 이 때 mod값이 0이되는 나누는 수가 바로 gcd이다.
         */

        static int LCM(int a, int b)
        {
            return a * b / GCD(a, b);
        }

        static int GCD(int a, int b)
        {
            int temp = 0;
            while(b != 0)
            {
                temp = a;
                a = b;
                b = a % b;
            }
            return a;
        }
    }


}
