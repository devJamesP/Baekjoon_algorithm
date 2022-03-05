using System;
using System.IO;

namespace AlgorithmProblem
{
    class _2630_make_paper
    {
        static void Problem_2630()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int[] aPapenCnt = new int[2]; // 0 : White, 1 : Blue

            // input
            int nPaperLen = int.Parse(sr.ReadLine());
            int[,] aPaper = new int[nPaperLen, nPaperLen];

            for (int i = 0; i < nPaperLen; ++i)
            {
                string[] strInput = sr.ReadLine().Split(' ');
                for (int j = 0; j < nPaperLen; ++j)
                {
                    aPaper[i, j] = int.Parse(strInput[j]);
                }
            }

            // count
            countOfPaper(aPaper, 0, 0, nPaperLen, aPapenCnt);

            // output
            sw.WriteLine(aPapenCnt[0]);
            sw.WriteLine(aPapenCnt[1]);

            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }

        static void countOfPaper(int[,] aPaper, int x, int y, int nPaperLen, int[] aPaperCnt)
        {
            if (nPaperLen == 1 || isSameColor(aPaper, x, y, nPaperLen) == true)
            {
                int ndx = aPaper[y, x];
                ++aPaperCnt[ndx];
                return;
            }
            else
            {
                int halfLen = nPaperLen / 2;

                countOfPaper(aPaper, x, y, halfLen, aPaperCnt);
                countOfPaper(aPaper, x+halfLen, y, halfLen, aPaperCnt);
                countOfPaper(aPaper, x, y+halfLen, halfLen, aPaperCnt);
                countOfPaper(aPaper, x+halfLen, y+halfLen, halfLen, aPaperCnt);
            }
            return;
        }

        static bool isSameColor(int[,] aPaper, int x, int y, int aPaperLen)
        {
            int nColor = aPaper[y, x];
            for (int i = y; i < y + aPaperLen; ++i)
            {
                for (int j = x; j < x + aPaperLen; ++j)
                {
                    if (aPaper[i, j] != nColor)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
