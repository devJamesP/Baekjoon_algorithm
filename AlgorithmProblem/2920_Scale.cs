using System;
using System.IO;

namespace AlgorithmProblem
{
    class _2920_Scale
    {
        static void Problem_2920()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            string strOutput = "mixed";
            string[] strInputScaleArr = sr.ReadLine().Split(' ');

            if (strInputScaleArr[0] == "1")
            {
                strOutput = "ascending";
                for (int i = 1; i < strInputScaleArr.Length - 1; ++i)
                {
                    // Ascending Check
                    if (strInputScaleArr[i] != (i + 1).ToString())
                    {
                        // mixed 
                        strOutput = "mixed";
                        break;
                    }
                }
            } else if (strInputScaleArr[0] == "8")
            {
                strOutput = "descending";
                for (int i = 1; i < strInputScaleArr.Length - 1; ++i)
                {
                    // Descending Check
                    if (strInputScaleArr[i] != (strInputScaleArr.Length-i).ToString())
                    {
                        // mixed 
                        strOutput = "mixed";
                        break;
                    }
                }
            }

            sw.WriteLine(strOutput);

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
