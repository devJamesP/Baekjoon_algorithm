using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class _1260_DFS_BFS
    {
        static int nVertex;
        static int nEdge;
        static int nStart;

        static bool[] visited = new bool[1001];
        static int[,] graph = new int[1001, 1001];
        static StringBuilder sb = new StringBuilder();

        static void Problem_1260()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
            int[] nInputArr = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

            nVertex = nInputArr[0];
            nEdge = nInputArr[1];
            nStart = nInputArr[2];

            string[] v1v2;
            int v1;
            int v2;

            // input (non direction graph)
            for (int i = 0; i < nEdge; ++i)
            {
                v1v2 = sr.ReadLine().Split(' ');
                v1 = int.Parse(v1v2[0]);
                v2 = int.Parse(v1v2[1]);
                graph[v1, v2] = 1;
                graph[v2, v1] = 1;
            }

            // solution(dfs)
            dfsWithStack(nStart);

            // reset
            for (int i = 1; i < nVertex + 1; ++i)
            {
                visited[i] = false;
            }
            sb.Append('\n');

            // solution(bfs)
            bfsWithQueue(nStart);

            // output
            sw.WriteLine(sb.ToString());
            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }

        // DFS : 깊이 우선 탐색(재귀)
        static void dfsWithRecursion(int start)
        {
            visited[start] = true;
            sb.Append(start.ToString());
            sb.Append(' ');

            for (int i = 1; i < nVertex+1; ++i)
            {
                if (visited[i] == false && graph[start, i] == 1)
                {
                    dfsWithRecursion(i);
                }
            }

            return;
        }

        // DFS : 깊이 우선 탐색(stack)
        static void dfsWithStack(int start)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(start);
            visited[start] = true;

            sb.Append(start.ToString());
            sb.Append(' ');

            int v;
            while(stack.Count > 0)
            {
                v = stack.Pop();
                for (int i = 1; i < nVertex+1; ++i)
                {
                    if (visited[i] == false && graph[v, i] == 1)
                    {
                        visited[i] = true;
                        stack.Push(v);
                        stack.Push(i);

                        sb.Append(i.ToString());
                        sb.Append(' ');
                        break;
                    }
                }
            }

            return;
        }

        // BFS : 너비 우선 탐색(queue)
        static void bfsWithQueue(int start)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;

            sb.Append(start.ToString());
            sb.Append(' ');

            int v;
            while(queue.Count > 0)
            {
                v = queue.Dequeue();
                for(int i = 1; i < nVertex + 1; ++i)
                {
                    if (visited[i] == false && graph[v, i] == 1)
                    {
                        visited[i] = true;
                        queue.Enqueue(v);
                        queue.Enqueue(i);

                        sb.Append(i.ToString());
                        sb.Append(' ');
                    }
                }
            }

            return;
        }
    }
}
