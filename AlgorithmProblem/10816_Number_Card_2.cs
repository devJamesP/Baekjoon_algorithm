using System;
using System.IO;
using System.Text;
namespace AlgorithmProblem
{
    class _10816_Number_Card_2
    {
        static void Problem_10816()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            // input
            int[] nCardsCountArr = new int[20000001];
            
            int n = int.Parse(sr.ReadLine());
            string[] strHasCardArr = sr.ReadLine().Split(' ');

            int m = int.Parse(sr.ReadLine());
            string[] strCardListArr = sr.ReadLine().Split(' ');

            // count cardList
            int ndx;
            for (int i = 0; i < strHasCardArr.Length; ++i)
            {
                ndx = int.Parse(strHasCardArr[i]);
                if (ndx < 0)
                {
                    ++nCardsCountArr[10000000 + (ndx * -1)];
                }
                else
                {
                    ++nCardsCountArr[ndx];
                }
            }

            // output cardList
            for (int i = 0; i < m; ++i)
            {
                ndx = int.Parse(strCardListArr[i]);
                if (ndx < 0)
                {
                    sb.Append(nCardsCountArr[10000000 + (ndx * -1)]);
                }
                else
                {
                    sb.Append(nCardsCountArr[ndx]);
                }
                sb.Append(" ");
            }

            sw.WriteLine(sb.ToString().Trim());
            sw.Flush();
            sr.Close();
            sw.Close();
        }

    }
}
