using System;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class _10773_Zero
    {
        static void Problem_10773()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            Stack<int> accountBookStack = new Stack<int>();

            int n = int.Parse(sr.ReadLine());
            accountBookStack.Push(int.Parse(sr.ReadLine()));
            int nInput;
            for(int i = 1; i < n; ++i)
            {
                nInput = int.Parse(sr.ReadLine());
                if (nInput == 0)
                {
                    accountBookStack.Pop();
                }
                else
                {
                    accountBookStack.Push(nInput);
                }
            }

            int sum = 0;
            while(accountBookStack.Count != 0)
            {
                sum += accountBookStack.Pop();
            }

            sw.WriteLine(sum);
            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
