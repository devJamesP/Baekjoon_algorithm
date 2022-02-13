using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmProblem
{
    /*
     * N : 나무의 수 (1 <= N <= 1_000_000)
     * M : 상근이 놈이 집에 몰래 가져가려는 나무의 길이 (1 <= M <= 2_000_000_000)
     * nTreeHeightArr : 나무 높이 배열
     * nResult: 톱으로 자를 최대 길이(나무 낭비하면 안된다는데... 자르면 죽는거 아닌가)
     * curMaxHeight : 나무들 중에 가장 길이가 긴 나무
     * 나무 높이를 설정하여 나무를 잘랐을 때 최소한 낭비 없이 자를 수 있는 최대 높이 구하기
     */
    class _2805_cutting_tree
    {

        static void Problem_2805()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            string[] strInput = sr.ReadLine().Split(' '); ;
            int N = int.Parse(strInput[0]);
            int M = int.Parse(strInput[1]);
            int[] nTreeHeightArr = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            int nResult;
            int curMaxHeight = getMaxLengthTree(nTreeHeightArr);

            cuttingMaxTreeHeight(nTreeHeightArr, M, curMaxHeight,  out nResult);

            sw.WriteLine(nResult);
            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static int getMaxLengthTree(int[] nTreeHeightArr)
        {
            int max = nTreeHeightArr[0];
            for(int i = 1; i < nTreeHeightArr.Length; ++i)
            {
                max = max < nTreeHeightArr[i] ? nTreeHeightArr[i] : max;
            }
            return max;
        }

        static void cuttingMaxTreeHeight(int[] nTreeHeightArr, int M, int curMaxHeight, out int nMaxCutHeight)
        {
            int high = curMaxHeight;
            int low = 0;
            int mid;

            long sumWoodHeight = 0;
            while (low < high)
            {
                mid = low + (high - low) / 2;
                sumWoodHeight = cutTreeHeight(nTreeHeightArr, mid);
                if (sumWoodHeight < M)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            nMaxCutHeight = low - 1;
        }

        static long cutTreeHeight(int[] nTreeHeightArr, int cut)
        {
            long sum = 0;
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
