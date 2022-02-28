using System;
using System.IO;
using System.Text;
namespace AlgorithmProblem
{
    class _1992_quad_tree
    {
        static void Problem_1992()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int N = int.Parse(sr.ReadLine());
            int[,] aMatrix = new int[N, N];
            StringBuilder sb = new StringBuilder();

            // input
            for(int i = 0; i < N; ++i)
            {
                string strInput = sr.ReadLine();
                for(int j = 0; j< strInput.Length; ++j)
                {
                    aMatrix[i, j] = strInput[j] - '0';
                }
            }

            // quadTree
            Zip(0, 0, aMatrix, N, ref sb);

            // output
            sw.WriteLine(sb.ToString());
            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }

        static void Zip(int x, int y, int[,] aMatrix, int length, ref StringBuilder sb)
        {
            if (length == 1 || isCompression(x, y, aMatrix, length) == true)
            {
                sb.Append(aMatrix[y, x].ToString());
            }
            else
            {
                int halfLength = length >> 1;

                sb.Append('(');
                Zip(x, y, aMatrix, halfLength, ref sb);
                Zip(x + halfLength, y, aMatrix, halfLength, ref sb);
                Zip(x, y + halfLength, aMatrix, halfLength, ref sb);
                Zip(x + halfLength, y + halfLength, aMatrix, halfLength, ref sb);
                sb.Append(')');
            }

            return;
        }

        static bool isCompression(int x, int y, int[,] aMatrix, int length)
        {
            int nCheck = aMatrix[y, x];
            for(int i = y; i < y + length; ++i)
            {
                for(int j = x; j < x + length; ++j)
                {
                    if (aMatrix[i,j] != nCheck)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
