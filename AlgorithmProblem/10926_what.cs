using System;
using System.IO;

namespace AlgorithmProblem
{
    class _10926_what
    {
        static void Problem_10926()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            sw.WriteLine(sr.ReadLine() + "??!");

            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }
    }
}
