using System;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class DFS_Algorithm
    {

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            bool[] visited = new bool[8];

            List<int>[] graph = new List<int>[8];
            for (int i = 0; i < graph.Length; ++i)
            {
                graph[i] = new List<int>();
            }
            graph[1].Add(2);
            graph[1].Add(3);
            graph[2].Add(4);
            graph[2].Add(5);
            graph[3].Add(6);
            graph[3].Add(7);
            int target = 4;
            int count = 0;
            bool isSearch = false;

            dfs(visited, graph, 1, target, ref count, ref isSearch);

            //count = 0;
            //dfsStack(visited, graph, 1, target, ref count);

            sw.WriteLine(count);
            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static void dfs(bool[] visited, List<int>[] graph, int x, int target, ref int count, ref bool isSearch)
        {
            visited[x] = true;
            ++count;

            if (x == target)
            {
                isSearch = true;
                return;
            }

            int y;
            for (int i = 0; i < graph[x].Count; ++i)
            {
                y = graph[x][i];
                if (visited[y] == false)
                {
                    dfs(visited, graph, y, target, ref count, ref isSearch);
                    {
                        break;
                    }
                }
            }
        }

        static void dfsStack(bool[] visited, List<int>[] graph, int x, int target, ref int count)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(x);
            ++count;

            int node;
            int nextNode;
            while (stack.Count != 0)
            {
                node = stack.Pop();
                if (node == target)
                {
                    break;
                }
                for (int i = 0; i < graph[node].Count; ++i)
                {
                    nextNode = graph[node][i];

                    if (visited[nextNode] == false)
                    {
                        visited[nextNode] = true;
                        ++count;
                        stack.Push(node);
                        stack.Push(nextNode);
                        break;
                    }
                }
            }
        }
    }
}
