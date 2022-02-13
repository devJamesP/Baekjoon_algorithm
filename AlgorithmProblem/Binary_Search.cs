using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProblem
{
    class Binary_Search
    {
        static void binary_Search()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int[] nArr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] nSameArr = { 0, 1, 2, 3, 4, 4, 4, 5, 5, 6, 7 };

            sw.WriteLine(binarySearch(nArr, -5));
            sw.WriteLine(binarySearch(nArr, 2));
            sw.WriteLine(binarySearch(nArr, 8));
            sw.WriteLine(binarySearch(nArr, 11));
            sw.WriteLine();

            // upper bound 특성 상 찾고자 하는 값이 없고 큰 값일 경우 마지막 인덱스를 찾는 경우와 동일한 결과가 나옴.
            sw.WriteLine(upperBound(nArr, -5));
            sw.WriteLine(upperBound(nArr, 2));
            sw.WriteLine(upperBound(nArr, 9));
            sw.WriteLine(upperBound(nArr, 11));
            sw.WriteLine();
            // lower bound는 찾고자 하는 값이 없고 작은 값일 경우 첫번째 인덱스를 찾는 경우와 동일한 결과가 나옴.
            sw.WriteLine(lowerBound(nArr, -5));
            sw.WriteLine(lowerBound(nArr, 2));
            sw.WriteLine(lowerBound(nArr, 9));
            sw.WriteLine(lowerBound(nArr, 11));
            sw.WriteLine();

            sw.WriteLine(lowerBound(nSameArr, 4));
            sw.WriteLine(upperBound(nSameArr, 4));
            sw.WriteLine();

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static int binarySearch(int[] arr, int target)
        {
            int low = 0;
            int high = arr.Length;
            int mid;

            while (low < high)
            {
                mid = low + (high - low) / 2;
                if (arr[mid] > target)
                {
                    high = mid - 1;
                }
                else if (arr[mid] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        // 상한값 찾기(바로 위 초과)
        static int upperBound(int[] arr, int target)
        {
            int low = 0;
            int high = arr.Length;
            int mid;

            while (low < high)
            {
                mid = low + (high - low) / 2;
                if (target < arr[mid])
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return low;
        }

        // 하한값 찾기(해당 값을 포함하는 이상 값)
        static int lowerBound(int[] arr, int target)
        {
            int low = 0;
            int high = arr.Length;
            int mid;

            while(low < high)
            {
                mid = low + (high - low) / 2;
                if (target <= arr[mid])
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return low;
        }
    }
}
