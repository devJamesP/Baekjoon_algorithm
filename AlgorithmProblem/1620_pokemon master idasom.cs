using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class _1620_pokemon_master_idasom
    {
        static void Problem_1620()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            string[] NM = sr.ReadLine().Split(' ');
            int N = int.Parse(NM[0]);
            int M = int.Parse(NM[1]);

            Dictionary<string, int> poketmonDict = new Dictionary<string, int>();
            string[] poketmonArr = new string[N + 1];

            for (int i = 1; i <= N; ++i)
            {
                string strInput = sr.ReadLine();
                poketmonArr[i] = strInput;
                poketmonDict.Add(strInput, i);
            }

            for(int i = 0; i < M; ++i)
            {
                string strInput = sr.ReadLine();
                int ndx;
                if (int.TryParse(strInput, out ndx) == true)
                {
                    sw.WriteLine(poketmonArr[ndx]);
                }
                else
                {
                    sw.WriteLine(poketmonDict[strInput]);
                }
            }

            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }
    }
}
