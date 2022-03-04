using System;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class _2606_virus
    {
        static void Problem_2606()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int nNodeCnt = int.Parse(sr.ReadLine());
            int nEdgeCnt = int.Parse(sr.ReadLine());
            bool[,] bGraph = new bool[nNodeCnt + 1, nNodeCnt + 1];

            // input
            for (int i = 0; i < nEdgeCnt; ++i)
            {
                string[] strInput = sr.ReadLine().Split(' ');
                int nFrom = int.Parse(strInput[0]);
                int nTo = int.Parse(strInput[1]);

                bGraph[nFrom, nTo] = true;
                bGraph[nTo, nFrom] = true;
            }

            // infected computer counter
            int nCount = getInfectedComputers(bGraph, nNodeCnt);

            // output
            sw.WriteLine(nCount);

            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }

        static int getInfectedComputers(bool[,] bGraph, int nNodeCnt)
        {
            Queue<int> queue = new Queue<int>();
            bool[] bNode = new bool[nNodeCnt + 1];
            int nCnt = 0;
            int nStart = 1;

            queue.Enqueue(nStart);
            bNode[nStart] = true;
            while(queue.Count > 0)
            {
                int nNode = queue.Dequeue();
                for(int i = 1; i <= nNodeCnt; ++i)
                {
                    if (bNode[i] == false && bGraph[nNode, i] == true)
                    {
                        queue.Enqueue(i);
                        bNode[i] = true;
                        ++nCnt;
                    }
                }
            }

            return nCnt;
        }
    }

}
