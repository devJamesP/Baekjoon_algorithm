using System;
using System.IO;
using System.Text;
namespace AlgorithmProblem
{
    class _5430_AC
    {
        static void Problem_5430()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
            StringBuilder sb = new StringBuilder();

            // input
            int T = int.Parse(sr.ReadLine());

            for (int i = 0; i < T; ++i)
            {
                bool bRev = false; 

                string strExp = sr.ReadLine(); 
                
                int nLen = int.Parse(sr.ReadLine()); 
                string[] arr = new string[nLen];

                string strNums = sr.ReadLine().Trim('[', ']');
                int ndx = 0;
                if (strNums.Length > 0)
                {
                    for (int j = 0; j < strNums.Length; ++j)
                    {
                        if (strNums[j] == ',')
                        {
                            arr[ndx] = sb.ToString();
                            sb.Clear();
                            ++ndx;
                            continue;
                        }
                        sb.Append(strNums[j]);
                    }
                    arr[ndx] = sb.ToString();
                    sb.Clear();
                }

                // function
                int nLeft = 0;
                int nRight = nLen;
                for (int j = 0; j < strExp.Length; ++j)
                {
                    if (strExp[j] == 'R')
                    {
                        bRev = !bRev;
                    }
                    else if (strExp[j] == 'D')
                    {
                        if (nRight < nLeft)
                        {
                            break;
                        }
                        else
                        {
                            if (bRev == true)
                            {
                                --nRight;
                            }
                            else
                            {
                                ++nLeft;
                            }
                        }
                    }
                    else
                    {
                        /* Nothing */
                    }
                }

                // output
                if (nRight < nLeft)
                {
                    sw.WriteLine("error");
                }
                else
                {
                    sb.Append('[');
                    for(int j = nLeft; j < nRight; ++j)
                    {
                        if (bRev == true)
                        {
                            int offset = nRight - j;
                            sb.Append(arr[nLeft + offset - 1]);
                        }
                        else
                        {
                            sb.Append(arr[j]);
                        }

                        if (j != nRight-1)
                        {
                            sb.Append(',');
                        }
                    }
                    sb.Append(']');
                    sw.WriteLine(sb.ToString());
                    sb.Clear();
                }
            }

            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }
    }
}
