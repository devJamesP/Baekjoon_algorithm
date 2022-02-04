using System;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class _9012_Parenthesis_String
    {
        static Stack<char> sk = new Stack<char>();
        static void Problem_9012()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            
            string strValid = "";
            bool bJudgeVPS = false;

            int nTestCase = int.Parse(sr.ReadLine());
            for(int i = 0; i < nTestCase; ++i)
            {
                bJudgeVPS = judgeVPS(sr.ReadLine());
                if (bJudgeVPS == true)
                {
                    strValid = "YES";
                }
                else
                {
                    strValid = "NO";
                }
                sw.WriteLine(strValid);
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static bool judgeVPS(string strInput)
        {
            sk.Clear();

            for (int i = 0; i < strInput.Length; ++i)
            {
                if (strInput[i] == ')')
                {
                    if (sk.Count == 0)
                    {
                        return false;
                    }
                    sk.Pop();
                } 
                else if (strInput[i] == '(')
                {
                    sk.Push(strInput[i]);
                }
            }
            return sk.Count == 0;
            
        }
    }
}
