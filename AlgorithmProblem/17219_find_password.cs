using System;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class _17219_find_password
    {
        static void Problem_17219()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            Dictionary<string, string> notepad = new Dictionary<string, string>();
            string[] NM = sr.ReadLine().Split(' ');
            int N = int.Parse(NM[0]);
            int M = int.Parse(NM[1]);

            // input
            for(int i = 0; i < N; ++i)
            {
                string[] SP = sr.ReadLine().Split(' ');
                notepad.Add(SP[0], SP[1]);
            }

            // output
            for(int j = 0; j < M; ++j)
            {
                sw.WriteLine(notepad[sr.ReadLine()]);
            }

            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }
    }
}
