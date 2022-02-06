using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmProblem
{
    class _11866_Josephus_Permutation
    {
        static void Problem_11866()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            StringBuilder sb = new StringBuilder();

            Queue<int> queue = new Queue<int>();

            string[] strInputArr = sr.ReadLine().Split(' ');
            int n = int.Parse(strInputArr[0]);
            int k = int.Parse(strInputArr[1]);

            // input
            int i;
            for (i = 0; i < n; ++i)
            {
                queue.Enqueue(i + 1);
            }

            sb.Append("<");
            i = k;
            while(queue.Count != 0)
            {
                --i;
                if (i == 0)
                {
                    sb.Append(queue.Dequeue().ToString());
                    if (queue.Count != 0)
                    {
                        sb.Append(", ");
                    }
                    i = k;
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                }
            }
            sb.Append(">");

            sw.WriteLine(sb.ToString());
            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
