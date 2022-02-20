using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class _1541_lost_bracket
    {
        static void Problem_1541()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
            StringBuilder sb = new StringBuilder();
            string strInput = sr.ReadLine();
            int[] nArr = Array.ConvertAll(strInput.Split('-', '+'), int.Parse);
            int sum = nArr[0];

            Queue<char> queue = new Queue<char>();

            for(int i = 0; i < strInput.Length; ++i)
            {
                if (char.IsDigit(strInput[i]) == false)
                {
                    queue.Enqueue(strInput[i]);
                }
            }

            int j = 1;
            while(queue.Count > 0)
            {
                char op = queue.Dequeue();
                if (op == '-')
                {
                    for(;j < nArr.Length; ++j)
                    {
                        sum -= nArr[j];
                    }
                    queue.Clear();
                }
                else
                {
                    sum += nArr[j];
                }
                ++j;
            }

            sw.WriteLine(sum);
            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }
    }
}
