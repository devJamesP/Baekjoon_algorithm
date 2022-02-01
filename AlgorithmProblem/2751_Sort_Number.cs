using System;
using System.IO;

namespace AlgorithmProblem
{
    class _2751_Sort_Number
    {
        static void Problem_2751()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int nTestCase = int.Parse(sr.ReadLine());

            int[] nNumbers = new int[nTestCase];

            // input
            for (int i = 0; i < nTestCase; ++i)
            {
                nNumbers[i] = int.Parse(sr.ReadLine());
            }

            // sort
            SortOfNumber(nNumbers, 0, nTestCase - 1);

            // output
            for (int i = 0; i < nTestCase; ++i)
            {
                sw.WriteLine(nNumbers[i]);
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        // 퀵 정렬
        static void SortOfNumber(int[] nNumbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = partition(nNumbers, start, end);

            SortOfNumber(nNumbers, start, pivot - 1);
            SortOfNumber(nNumbers, pivot + 1, end);
        }

        static int partition(int[] nNumbers, int start, int end)
        {
            int pivot = nNumbers[end];

            int i = start - 1;

            for(int j = start; j < end; ++j)
            {
                if (nNumbers[j] < pivot)
                {
                    ++i;
                    swap(nNumbers, i, j);
                }
            }

            int pivotPosition = i + 1;
            swap(nNumbers, pivotPosition, end);

            return pivotPosition;
        }

        static void swap(int[] nNumbers, int a, int b)
        {
            int temp = nNumbers[a];
            nNumbers[a] = nNumbers[b];
            nNumbers[b] = temp;
        }
    }
}
