using System;
using System.IO;
using System.Collections.Generic;


namespace AlgorithmProblem
{
    class _1012_organic_cabbage
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            Stack<int> stack = new Stack<int>();
            int nTestCase = int.Parse(sr.ReadLine());
            string[] strInputArr = sr.ReadLine().Split(' ');
            int M = int.Parse(strInputArr[0]);
            int N = int.Parse(strInputArr[1]);
            int K = int.Parse(strInputArr[2]);
            int[,] nCabbageArr = new int[M, N];

            // input
            int[] nPoint;
            for (int i = 0; i < nTestCase; ++i)
            {
                for (int j = 0; j < K; ++j)
                {
                    nPoint = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
                    nCabbageArr[nPoint[0], nPoint[1]] = 1;
                }


            }
            



            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
