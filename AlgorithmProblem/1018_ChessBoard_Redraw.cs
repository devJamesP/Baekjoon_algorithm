using System;
using System.IO;

namespace baekjoon
{
    class _1018_ChessBoard_Redraw
    {
        static void Problem_1018() 
        { 
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string[] strInput = sr.ReadLine().Split(' ');
            int n = int.Parse(strInput[0]);
            int m = int.Parse(strInput[1]);

            string[] strChessBoard = new string[n];
            int nMinReDrawCount = 2500; // 최솟값

            // input
            for (int i = 0; i < n; ++i)
            {
                strChessBoard[i] = sr.ReadLine();
            }

            // calc redraw count
            for (int i = 0; i < n - 7; ++i)
            {
                for (int j = 0; j < m - 7; ++j)
                {
                    int nReDrawCount = GetReDrawCount(i, j, strChessBoard);
                    if (nMinReDrawCount > nReDrawCount)
                    {
                        nMinReDrawCount = nReDrawCount;
                    }
                }
            }

            // calc min redraw count
            sw.WriteLine(nMinReDrawCount);

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        // B W 판정 후, count증가
        private static int GetReDrawCount(
            int nRowOffset,
            int nColumnOffset,
            in string[] strChessBoard
            )
        {
            int nRedrawCountA = 0;
            int nRedrawCountB = 0;
            for (int i = 0; i < 8; ++i)
            {
                for (int j = 0; j < 8; ++j)
                {
                    // 행과 열의 합으로 먼저 필터링
                    // (행과 열이 서로 짝수 홀수(홀수 짝수)인 경우 합: 홀수)
                    if ((i + j) % 2 == 1)
                    {
                        if (strChessBoard[i + nRowOffset][j + nColumnOffset] == 'B')
                        {
                            ++nRedrawCountA;
                        }
                    }
                    // 행과 열의 합이 (행과 열이 짝수 짝수(홀수 홀수)인 경우 합: 짝수)
                    else
                    {
                        if (strChessBoard[i + nRowOffset][j + nColumnOffset] == 'B')
                        {
                            ++nRedrawCountB;
                        }
                    }
                }
            }
            nRedrawCountA = 32 - Math.Abs(nRedrawCountA - nRedrawCountB);
            return nRedrawCountA;
        }

    }
}