using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace AlgorithmProblem
{
    class _1874_Stack_Sequence
    {
        static void Problem_1874()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
            StringBuilder sb = new StringBuilder();

            Stack<int> stack = new Stack<int>();
            int n = int.Parse(sr.ReadLine());

            int num = 1;
            int input;

            for(int i = 0; i < n; ++i)
            {
                input = int.Parse(sr.ReadLine());
                while (num <= input)
                {
                    stack.Push(num);
                    sb.Append("+\n");
                    ++num;
                }

                if (stack.Count > 0 && stack.Peek() == input)
                {
                    stack.Pop();
                    sb.Append("-\n");
                }
                else
                {
                    sb.Clear();
                    sb.Append("NO");
                    break;
                }
            }

            sw.WriteLine(sb.ToString());
            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
