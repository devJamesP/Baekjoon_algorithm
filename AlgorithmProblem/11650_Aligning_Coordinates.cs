using System;
using System.IO;

namespace AlgorithmProblem
{
    class _11650_Aligning_Coordinates
    {
        struct SCoord
        {
            int x;
            int y;
            public int X { 
                get { return x; } 
                set { x = value; }
            }
            public int Y {
                get { return y; } 
                set { y = value; }
            }
        }

        static void Problem_11650()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int nTestCase = int.Parse(sr.ReadLine());
            SCoord[] coords = new SCoord[nTestCase];
            
            // input
            for(int i = 0; i < nTestCase; ++i)
            {
                string[] strInputArr = sr.ReadLine().Split(' ');
                coords[i].X = int.Parse(strInputArr[0]);
                coords[i].Y = int.Parse(strInputArr[1]);
            }

            // sort
            sortOfCoords(coords);

            // output
            for(int i = 0; i < nTestCase; ++i)
            {
                sw.WriteLine(coords[i].X + " " + coords[i].Y);
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static void sortOfCoords(SCoord[] coords)
        {
            // x값 정렬(퀵 정렬)
            quickSort(coords, 0, coords.Length-1, false);

            // x가 같을 때 y값 정렬
            int nEnd = 1;
            int nSameCount = 0;
            while (nEnd < coords.Length)
            {
                if (coords[nEnd-1].X == coords[nEnd].X)
                {
                    ++nSameCount;
                    if (nEnd == coords.Length - 1)
                    {
                        int left = nEnd - nSameCount;
                        int right = nEnd;
                        quickSort(coords, left, right, true);
                    }
                }
                else
                {
                    if (nSameCount > 0)
                    {
                        int left = nEnd - 1 - nSameCount;
                        int right = nEnd - 1;
                        quickSort(coords, left, right, true);
                        nSameCount = 0;
                    }
                }
                ++nEnd;
            }
        }

        static void quickSort(SCoord[] coords, int left, int right, bool bSameFlag)
        {
            if (bSameFlag == false)
            {
                if (left <= right)
                {
                    int pivot = partitionOfX(coords, left, right); // 둘로 나눔
                    quickSort(coords, left, pivot - 1, false); //왼쪽 영역 정렬
                    quickSort(coords, pivot + 1, right, false);
                }
            }
            else
            {
                if (left <= right)
                {
                    int pivot = partitionOfY(coords, left, right); // 둘로 나눔
                    quickSort(coords, left, pivot - 1, true); //왼쪽 영역 정렬
                    quickSort(coords, pivot + 1, right, true);
                }
            }
        }

        static int partitionOfX(SCoord[] coords, int left, int right)
        {
            int pivot = coords[left].X;
            int low = left + 1;
            int high = right;

            while(low <= high)
            {
                while(low <= right && pivot >= coords[low].X) { ++low; }
                while(high >= left + 1 && pivot <= coords[high].X) { --high; }

                if (low <= high)
                {
                    swap(coords, low, high);
                }
            }

            swap(coords, left, high); // pivot position change
            return high;
        }

        static int partitionOfY(SCoord[] coords, int left, int right)
        {
            int pivot = coords[left].Y;
            int low = left + 1;
            int high = right;

            while (low <= high)
            {
                while (low <= right && pivot >= coords[low].Y) { ++low; }
                while (high >= left + 1 && pivot <= coords[high].Y) { --high; }

                if (low <= high)
                {
                    swap(coords, low, high);
                }
            }

            swap(coords, left, high); // pivot position change
            return high;
        }

        static void swap(SCoord[] coords, int i, int j)
        {
            SCoord temp = coords[i];
            coords[i] = coords[j];
            coords[j] = temp;
        }
    }
}
