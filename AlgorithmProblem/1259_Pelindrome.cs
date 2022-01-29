using System;
using System.IO;

namespace AlgorithmProblem
{
    class _1259_Pelindrome
    {
        static void Problem_1259() 
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string strPelindrome = "";

            while (true)
            {
                strPelindrome = sr.ReadLine();
                if (strPelindrome == "0")
                {
                    break;
                }

                int nMedianLength = (int)Math.Round((double)strPelindrome.Length / 2, 1);
                int i = 0;
                for(i = 0; i < nMedianLength; ++i)
                {
                    if (strPelindrome[i] != strPelindrome[strPelindrome.Length-1-i])
                    {
                        sw.WriteLine("no");
                        break;
                    }
                }
                if (i == nMedianLength)
                {
                    sw.WriteLine("yes");
                }
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
