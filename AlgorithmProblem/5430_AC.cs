using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
namespace AlgorithmProblem
{
    class _5430_AC
    {
        static void test()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
            List<int> list = new List<int>(); // 리스트

            // input
            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; ++i)
            {
                bool bRev = false; // 리버스 체크

                string strExp = sr.ReadLine(); // 함수식

                int nLen = int.Parse(sr.ReadLine()); // 배열 길이

                string strNums = sr.ReadLine().Trim('[', ']'); 
                translate(list, strNums); // 리스트 셋업

                if (isProcess(list, strExp, ref nLen, ref bRev) == false)
                {
                    sw.WriteLine("error");
                }
                else
                {
                    sw.WriteLine(output(list, bRev));
                }
                list.Clear();
            }

            sw.Flush();
            sr.Close();
            sw.Close();
            return;
        }

        static void translate(List<int> list, string strNums)
        {
            StringBuilder sb = new StringBuilder();
            if (strNums.Length > 0)
            {
                for (int j = 0; j < strNums.Length; ++j)
                {
                    if (strNums[j] == ',')
                    {
                        list.Add(int.Parse(sb.ToString()));
                        sb.Clear();
                        continue;
                    }
                    sb.Append(strNums[j]);
                }
                list.Add(int.Parse(sb.ToString()));
            }
        }

        static bool isProcess(List<int> list, string strExp, ref int nLen, ref bool bRev)
        {
            if (nLen == 0)
            {
                return true;
            }
            int nDel = 0;
            for (int i = 0; i < strExp.Length; ++i)
            {
                if (strExp[i] == 'R')
                {
                    bRev = !bRev;
                }
                else if (strExp[i] == 'D')
                {
                    if (nLen == 0)
                    {
                        return false;
                    }
                    else
                    {
                        list.RemoveAt(nDel);
                        --nLen;
                    }
                }
                else
                {
                    /* Nothing */
                }
                nDel = bRev == true ? nLen - 1 : 0;
            }
            return true;
        }

        static string output(List<int> list, bool bRev)
        {
            StringBuilder sb = new StringBuilder();
            int nCount = 0;
            sb.Append('[');
            if (bRev == false)
            {
                for(int i = 0; i < list.Count; ++i)
                {
                    sb.Append(list[i]);
                    if (nCount != list.Count-1)
                    {
                        sb.Append(',');
                        ++nCount;
                    }
                }
            }
            else
            {
                for(int i = list.Count-1; i >= 0; --i)
                {
                    sb.Append(list[i]);
                    if (nCount != list.Count - 1)
                    {
                        sb.Append(',');
                        ++nCount;
                    }
                }
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
