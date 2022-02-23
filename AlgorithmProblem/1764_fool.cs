using System;
using System.IO;
using System.Collections.Generic;
namespace AlgorithmProblem
{
    class _1764_fool
    {
        static void Problem_1764()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
            string[] NM = sr.ReadLine().Split(' ');
            int N = int.Parse(NM[0]);
            int M = int.Parse(NM[1]);

            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<string> strList = new List<string>();

            // 입력
            for (int i = 0; i < N; ++i)
            {
                string str = sr.ReadLine();
                dict.Add(str, str);
            }

            // 해당 키가 있는지 체크
            for (int i = 0; i < M; ++i)
            {
                string key = sr.ReadLine();
                if (dict.ContainsKey(key) == true)
                {
                    strList.Add(dict[key]);
                    dict.Remove(key);
                }
            }

            // 사전 순 정렬
            strList.Sort();

            // 출력
            sw.WriteLine(strList.Count);
            foreach(string strDup in strList)
            {
                sw.WriteLine(strDup);
            }
            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }
    }
}
