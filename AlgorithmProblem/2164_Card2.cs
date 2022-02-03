using System;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class _2164_Card2
    {
        static void Problem_2164()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int nTestCase = int.Parse(sr.ReadLine());
            bool[] cardArr = new bool[nTestCase];

            int nAllDiscardCount = 0;
            int index = 0;
            while (nAllDiscardCount < nTestCase - 1)
            {
                index = disCardNHide(cardArr, index);
                ++nAllDiscardCount;
            }
            sw.WriteLine(index + 1);
            sw.Flush();
            sr.Close();
            sw.Close();
        }


        static int disCardNHide(bool[] cardArr, int index)
        {
            int ndx = index;
            int nCount = 0;

            while(nCount <= 2)
            {
                if (ndx >= cardArr.Length)
                {
                    ndx = 0;
                }
                
                if (cardArr[ndx] == false)
                {
                    // 1. 카드를 한장 버린다.
                    if (nCount == 0)
                    {
                        cardArr[ndx] = true;
                        ++nCount;
                    }
                    // 2. 카드를 덱의 제일 아래에 위치에 놓는다.
                    else if (nCount == 1)
                    {
                        ++nCount;
                    }
                    else if (nCount == 2)
                    {
                        return ndx;
                    }
                }
                ++ndx;
            }
            return ndx;
        }

    }
}
