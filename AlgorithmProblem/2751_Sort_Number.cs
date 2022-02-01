using System;
using System.IO;

namespace AlgorithmProblem
{
    class _2751_Sort_Number
    {
        struct SNumber
        {
            bool bMinus;
            public bool BMinus
            {
                get { return bMinus; }
                set { bMinus = value; }
            }
            bool bPlus;
            public bool BPlus
            {
                get { return bPlus; }
                set { bPlus = value; }
            }
        }
        static void Problem_2751()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int nTestCase = int.Parse(sr.ReadLine());

            SNumber[] sNumbers = new SNumber[1000001];

            // input
            for (int i = 0; i < nTestCase; ++i)
            {
                int ndx = int.Parse(sr.ReadLine());
                if (ndx < 0)
                {
                    sNumbers[ndx * -1].BMinus = true;
                }
                else
                {
                    sNumbers[ndx].BPlus = true;
                }
            }

            // output
            for(int i = 0; i < sNumbers.Length; ++i)
            {
                int ndx = sNumbers.Length - i - 1;
                if (sNumbers[ndx].BMinus == true)
                {
                    sw.WriteLine(ndx * -1);
                }
            }
            for (int i = 0; i < sNumbers.Length; ++i)
            {
                if (sNumbers[i].BPlus == true)
                {
                    sw.WriteLine(i);
                }
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
