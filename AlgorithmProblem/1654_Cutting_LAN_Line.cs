using System;
using System.IO;
namespace AlgorithmProblem
{
    class _1654_Cutting_LAN_Line
    {
        /*
         * strInput : k, n 문자열 형태로 입력
         * k : "갓영식"이 가지고 있는 랜선의 갯수
         * n : 박성원이 만들어야 하는 랜선의 갯수
         * LANs : 각 랜선의 길이를 가진 배열
         * 
         * left : 만들 수 있는 랜선의 최소 길이
         * right : 만들 수 있는 랜선의 최대 길이
         * nCount : line마다 랜선의 갯수
         * nLineCount : 구하고자 하는 랜선의 최대 길이 
         * 
         * getMaxLine(int[] LANs) : 랜선의 길이 배열 중 가장 큰 길이의 랜선을 반환
         * devideLANOfLineCount(int[] LANs, int line) : 랜선의 길이 배열을 line의 크기만큼 잘라서 카운트 -> 반환
         */

        static void Problem_1654()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            string[] strInput = sr.ReadLine().Split(' ');
            int k = int.Parse(strInput[0]);
            int n = int.Parse(strInput[1]);
            int[] LANs = new int[k];

            // input
            for (int i = 0; i < k; ++i)
            {
                LANs[i] = int.Parse(sr.ReadLine());
            }

            long low = 1;
            long high = getMaxLine(LANs);
            long mid = 0;
            long nLine = 0;
            long nLineCount;
            if (n == 1)
            {
                nLine = LANs[0] / n;
            }
            else
            {
                while (low <= high)
                {
                    mid = low + (high - low) / 2;
                    nLineCount = devideLANOfLineCount(LANs, mid);
                    if (nLineCount < n)
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                        nLine = nLine < mid ? mid : nLine;
                    }
                }
            }
            
            sw.WriteLine(nLine);

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static int getMaxLine(int[] LANs)
        {
            int max = LANs[0];
            for (int i = 1; i < LANs.Length; ++i)
            {
                max = LANs[i] > max ? LANs[i] : max;
            }
            return max;
        }

        static long devideLANOfLineCount(int[] LANs, long line)
        {
            long nLineCount = 0;
            for (int i = 0; i < LANs.Length; ++i)
            {
                nLineCount += LANs[i] / line;
            }
            return nLineCount;
        }

    }
}
