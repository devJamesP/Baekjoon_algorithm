using System;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class Heap_Implemente
    {
        static void Main2(string[] args)
        {
            int[,] wires = new int[3, 2] { { 1, 2 }, { 2, 3 }, { 3, 4 } };
            int n = 4;
            solution(n, wires);
        }

        static public int solution(int n, int[,] wires)
        {
            bool[] visited = new bool[n + 1];
            bool[,] graph = new bool[n + 1, n + 1];
            int[] posArr = new int[2];
            int answer = -1;
            int min = n;

            // setup
            setupGraph(graph, wires);

            // min count
            for (int i = 0; i < wires.GetLength(0); ++i)
            {
                posArr[0] = wires[i, 0];
                posArr[1] = wires[i, 1];
                int cnt = count(n, posArr, visited, graph);
                min = min < cnt ? min : cnt;
            }

            // answer
            answer = min;
            return answer;
        }

        static void setupGraph(bool[,] graph, int[,] wires)
        {
            for (int i = 0; i < wires.GetLength(0); ++i)
            {
                int fromPos = wires[i, 0];
                int toPos = wires[i, 1];
                graph[fromPos, toPos] = true;
                graph[toPos, fromPos] = true;
            }

            return;
        }

        static int count(int n, int[] posArr, bool[] visited, bool[,] graph)
        {
            Stack<int> stack = new Stack<int>();
            int[] cntArr = new int[2];
            int v;

            for (int i = 0; i < cntArr.Length; ++i)
            {
                visited[posArr[i]] = true;
                stack.Push(posArr[i]);
                ++cntArr[i];

                while (stack.Count > 0)
                {
                    v = stack.Pop();
                    for (int j = 1; j < visited.Length; ++j)
                    {
                        if (visited[j] == false && graph[v, j] == true)
                        {
                            stack.Push(v);
                            stack.Push(j);
                            ++cntArr[i];
                            break;
                        }
                    }
                }
                clear(visited);
            }
            return cntArr[0] < cntArr[1] ? cntArr[0] : cntArr[1];
        }

        static void clear(bool[] visited)
        {
            for (int i = 1; i < visited.Length; ++i)
            {
                visited[i] = false;
            }
            return;
        }
    }
    
}
