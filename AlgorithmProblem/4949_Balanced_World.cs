using System;
using System.IO;
using System.Collections.Generic;
namespace AlgorithmProblem
{
    class _4949_Balanced_World
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            Stack<char> stack = new Stack<char>();
            string strLine;
            string strYes = "yes";
            string strNo = "no";

            while (true)
            {
                strLine = sr.ReadLine();
                if (strLine[0] == '.')
                {
                    break;
                }

                for (int i = 0; i < strLine.Length; ++i)
                {
                    if (strLine[i] == '(' || strLine[i] == '[')
                    {
                        stack.Push(strLine[i]);
                    }
                    else if (strLine[i] == ')' || strLine[i] == ']')
                    {
                        if (stack.Count != 0 && strLine[i] == ')' && stack.Peek() == '(' ||
                            stack.Count != 0 && strLine[i] == ']' && stack.Peek() == '[')
                        {
                            stack.Pop();
                        }
                        else
                        {
                            sw.WriteLine(strNo);
                            break;
                        }
                    }
                    else if (strLine[i] == '.')
                    {
                        if (stack.Count == 0)
                        {
                            sw.WriteLine(strYes);
                        }
                        else
                        {
                            sw.WriteLine(strNo);
                        }
                        break;
                    }
                }

                stack.Clear();
            }
            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}