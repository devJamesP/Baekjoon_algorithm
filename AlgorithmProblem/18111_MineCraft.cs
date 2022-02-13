using System;
using System.IO;
using System.Collections;
namespace AlgorithmProblem
{
    class _18111_MineCraft
    {
        static void Problem_18111()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            string[] strInput = sr.ReadLine().Split(' ');
            int[,] blocks = new int[500, 500];
            int leastTime = 0x7a12000;
            int mostHeight = 0;

            int N = int.Parse(strInput[0]);
            int M = int.Parse(strInput[1]);
            int B = int.Parse(strInput[2]);

            int[] nTempBlocks;
            for (int i = 0; i < N; ++i)
            {
                nTempBlocks = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
                for (int j = 0; j < M; ++j)
                {
                    blocks[i, j] = nTempBlocks[j];
                }
            }

            int buildCount = 0;
            int removeCount = 0;
            int time = 0;
            for (int height = 0; height <= 256; ++height)
            {
                buildCount = 0;
                removeCount = 0;
                for (int i = 0; i < N; ++i)
                {
                    for (int j = 0; j < M; ++j)
                    {
                        if (blocks[i, j] > height)
                        {
                            removeCount += blocks[i, j] - height;
                        }
                        else if (blocks[i, j] <= height)
                        {
                            buildCount += height - blocks[i, j];
                        }
                    }
                }
                if (removeCount + B - buildCount >= 0)
                {
                    time = removeCount * 2 + buildCount;
                    if (leastTime >= time)
                    {
                        leastTime = time;
                        mostHeight = height;
                    }
                }
            }

            sw.WriteLine(leastTime + " " + mostHeight);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
