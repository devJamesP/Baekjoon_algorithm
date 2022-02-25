using System;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    class Heap
    {
        protected int[] nArr; // 배열
        private int capacity; // 배열 크기
        public int Capacity { get { return capacity; } }
        protected int length; // 값이 들어있는 배열 크기

        public Heap(int capacity)
        {
            nArr = new int[capacity];
            this.capacity = capacity;
            this.length = 0;
        }
        // empty 체크
        public bool IsEmpty()
        {
            return length == 0;
        }

        // 최소값
        public int Peek()
        {
            if (IsEmpty() == true)
            {
                return -1;
            }
            return nArr[0];
        }

        // 교체
        protected void swap(int ndx1, int ndx2)
        {
            int temp = nArr[ndx1];
            nArr[ndx1] = nArr[ndx2];
            nArr[ndx2] = temp;
        }

        // 배열의 크기 유효성 체크
        protected bool isInvalidate(int ndx)
        {
            return ndx >= capacity;
        }

        // 부모 인덱스
        protected int getParentIndex(int ndx)
        {
            return (ndx - 1) / 2;
        }

        // 왼쪽 자식 인덱스
        protected int getLeftChildIndex(int ndx)
        {
            int cdx = (ndx * 2) + 1;
            return cdx;
        }

        // 오른쪽 자식 인덱스
        protected int getRightChildIndex(int ndx)
        {
            int cdx = (ndx * 2) + 2;
            return cdx;
        }

        // 리사이징
        protected void ReSize()
        {
            int[] tempArr = nArr;
            nArr = new int[capacity * 2];
            for (int i = 0; i < tempArr.Length; ++i)
            {
                nArr[i] = tempArr[i];
            }

            capacity *= 2;

            return;
        }
    }

    class MinHeap : Heap
    {
        public MinHeap(int capacity) : base(capacity) { }

        // 데이터 추가
        public void Add(int data)
        {
            if (length == Capacity)
            {
                ReSize();
            }

            nArr[length] = data;
            sortUp(length);
            ++length;
            return;
        }

        // 데이터 삭제
        public int Delete()
        {
            if (IsEmpty() == true)
            {
                return 0;
            }

            int temp = nArr[0];
            int ndx = sortDown();
            nArr[length-1] = 0;

            sortUp(ndx);

            --length;
            return temp;
        }

        // 추가 후 정렬
        private void sortUp(int ndx)
        {
            if (nArr[ndx] == 0)
            {
                return;
            }
            int pdx = getParentIndex(ndx);
            while (nArr[pdx] > nArr[ndx])
            {
                swap(pdx, ndx);
                ndx = pdx;
                pdx = getParentIndex(ndx);
            }

            return;
        }

        // 삭제 전 정렬
        private int sortDown()
        {
            int ndx = 0;

            int cdx1;
            int cdx2;

            int mdx;
            while (true)
            {
                cdx1 = getLeftChildIndex(ndx);
                cdx2 = getRightChildIndex(ndx);
                if (isInvalidate(cdx1) == true || isInvalidate(cdx2) == true)
                {
                    break;
                }
                mdx = Min(cdx1, cdx2);
                if (nArr[mdx] == 0)
                {
                    break;
                }
                swap(ndx, mdx);
                ndx = mdx;
            }

            swap(ndx, length - 1);

            return ndx;
        }

        private int Min(int ndx1, int ndx2)
        {
            if (nArr[ndx1] == 0)
            {
                return ndx2;
            }
            else if (nArr[ndx2] == 0)
            {
                return ndx1;
            }
            else
            {
                return nArr[ndx1] < nArr[ndx2] ? ndx1 : ndx2;
            }
        }
    }

    class _1927_minimun_heap
    {
        static void Problem_1927()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int N = int.Parse(sr.ReadLine());
            MinHeap heap = new MinHeap(N);
            for (int i = 0; i < N; ++i)
            {
                int n = int.Parse(sr.ReadLine());
                if (n == 0)
                {
                    sw.WriteLine(heap.Delete());
                }
                else
                {
                    heap.Add(n);
                }
            }

            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }
    }
}
