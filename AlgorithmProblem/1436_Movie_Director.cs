using System;
using System.IO;
using System.Text;
namespace AlgorithmProblem
{
    class _1436_Movie_Director
    {
        static void Problem_1436_2()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int n = int.Parse(sr.ReadLine());
            int i = 666;
            int nCount = 1;
            string strEndOfNum = "666";
            while (nCount <= n)
            {
                if (i.ToString().Contains(strEndOfNum) == true)
                {
                    ++nCount;
                }
                ++i;
            }
            sw.WriteLine((i-1).ToString());
            sw.Flush();
            sw.Close();
            sr.Close();
        }
        static void Problem_1436()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
            StringBuilder sb = new StringBuilder();
            int nCount = 0;
            int n = int.Parse(sr.ReadLine());
            int nEndOfNum = -334; // 종말의 숫자

            int frontNum = 0;
            int nSixCount = 0;
            bool checkSixCount = false;
            int nSixPanjung = 0;
            string strSix;

            while (nCount < n)
            {
                if (frontNum % 10 != 6)
                {
                    ++frontNum;
                    nEndOfNum += 1000;
                }
                else
                {
                    if (checkSixCount == false)
                    {
                        nEndOfNum += 1000;
                        strSix = frontNum.ToString();
                        sb.Clear();
                        sb.Append("6");
                        for(int i = 0; i < strSix.Length; ++i)
                        {
                            if (strSix.Contains(sb.ToString()) == true)
                            {
                                ++nSixCount;
                                sb.Append("6");
                            }
                            else
                            {
                                break;
                            }
                        }
                        nSixPanjung = (int)Math.Pow(10, nSixCount);
                        nEndOfNum -= nEndOfNum % nSixPanjung;
                        checkSixCount = true;
                    }
                    else
                    {
                        if (nSixPanjung == nEndOfNum % nSixPanjung + 1)
                        {
                            nEndOfNum -= nEndOfNum % nSixPanjung;
                            int nResetSix = 0;
                            for(int i = 0; i < nSixCount; ++i)
                            {
                                nResetSix += 6 * (int)Math.Pow(10, i);
                            }
                            nEndOfNum += nResetSix;
                            frontNum += 2;
                            nEndOfNum += 1000;
                            checkSixCount = false;

                            nSixCount = 0;
                        }
                        else
                        {
                            ++nEndOfNum;
                        }
                    }
                }
                ++nCount;
            }

            sw.WriteLine(nEndOfNum);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
