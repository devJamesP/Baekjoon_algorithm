using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmProblem
{
    /*
     * N : 나무의 수 (1 <= N <= 1_000_000)
     * M : 상근이 놈이 집에 몰래 가져가려는 나무의 길이 (1 <= M <= 2_000_000_000)
     * nTreeHeightArr : 나무 높이 배열
     * nMaxCutHeight : 톱으로 자를 최대 길이(나무 낭비하면 안된다는데... 자르면 죽는거 아닌가)
     * 
     * 나무 높이를 설정하여 나무를 잘랐을 때 최소한 낭비 없이 자를 수 있는 최대 높이 구하기
     */
    class _2805_cutting_tree
    {

        static void Test(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            string[] strInput = sr.ReadLine().Split(' '); ;
            int N = int.Parse(strInput[0]);
            int M = int.Parse(strInput[1]);
            int[] nTreeHeightArr = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            int nMaxCutHeight;

            Array.Sort(nTreeHeightArr);
            cuttingMaxTreeHeight(nTreeHeightArr, M, out nMaxCutHeight);

            sw.WriteLine(nMaxCutHeight);
            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static void cuttingMaxTreeHeight(int[] nTreeHeightArr, int M, out int nMaxCutHeight)
        {
            int high = nTreeHeightArr[nTreeHeightArr.Length - 1];
            int low = nTreeHeightArr[0];
            int mid = 0;

            int sumWoodHeight = 0;
            while(low <= high)
            {
                mid = low + (high - low) / 2;
                sumWoodHeight = cutTreeHeight(nTreeHeightArr, mid);
                if (sumWoodHeight >= M)
                {
                    low = mid + 1;
                }
                else if (sumWoodHeight < M)
                {
                    high = mid - 1;
                }
            }
            nMaxCutHeight = mid;
        }

        static int cutTreeHeight(int[] nTreeHeightArr, int cut)
        {
            int sum = 0;
            for (int i = 0; i < nTreeHeightArr.Length; ++i)
            {
                if (nTreeHeightArr[i] > cut)
                {
                    sum += (nTreeHeightArr[i] - cut);
                }
            }
            return sum;
        }
    }
}
