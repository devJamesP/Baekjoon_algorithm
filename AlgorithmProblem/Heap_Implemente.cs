using System;

namespace AlgorithmProblem
{
    class Heap
    {
        protected int[] arr;
        protected int capacity;
        protected int length;

        public int Length { get { return length; } }
        public int Capacity { get { return capacity; } }
        public int Peek { get { return arr[0]; } }
        protected Heap(int capacity)
        {
            arr = new int[capacity];
            this.capacity = capacity;
            this.length = 0;
        }

        protected void Swap(int ndx1, int ndx2)
        {
            int temp = arr[ndx1];
            arr[ndx1] = arr[ndx2];
            arr[ndx2] = temp;
        }

        // 부모 인덱스
        protected int GetParentIndex(int cur)
        {
            return (cur - 1) / 2;
        }

        // 왼쪽 자식 인덱스
        protected int GetLeftChildIndex(int cur)
        {
            int ndx = cur * 2 + 1;
            return ndx;
        }

        // 오른쪽 자식 인덱스
        public int GetRightChildIndex(int cur)
        {
            int ndx = cur * 2 + 2;
            return ndx;
        }

        // 부모 반환 메소드
        protected int GetParent(int cur)
        {
            int ndx = GetParentIndex(cur);
            return arr[ndx];
        }

        // 왼쪽 자식 메소드
        protected int GetLeftChild(int cur)
        {
            int ndx = GetLeftChildIndex(cur);
            if (IsInvalidate(ndx) == true)
            {
                return -1;
            }
            return arr[ndx];
        }

        // 오른쪽 자식 메소드
        protected int GetRightChild(int cur)
        {
            int ndx = GetRightChildIndex(cur);
            if (IsInvalidate(ndx) == true)
            {
                return -1;
            }
            return arr[ndx];
        }

        // 유효성 체크
        protected bool IsInvalidate(int cur)
        {
            return cur >= capacity;
        }

        // 리사이징
        protected void ReSize()
        {
            int[] tempArr = arr;
            arr = new int[capacity * 2];

            for(int i = 0; i < capacity; ++i)
            {
                arr[i] = tempArr[i];
            }
            capacity <<= 1;
        }

        protected int Min(int n1, int n2) 
        {
            int min = 0;
            if (arr[n1] == 0)
            {
                min = n2;
            }
            else if (arr[n2] == 0)
            {
                min = n1;
            }
            else
            {
                min = arr[n1] < arr[n2] ? n1 : n2;
            }
            return min;
        }
    }

    class MinHeap : Heap
    {
        // 최소힙에 데이터 추가
        public void Add(int data)
        {
            if (length == capacity)
            {
                ReSize();
            }
            int ndx = length;
            for(int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] == 0)
                {
                    arr[i] = data;
                    ndx = i;
                    break;
                }
            }
            bubbleUp(ndx);
            ++length;
        }
        void bubbleUp(int ndx)
        {
            int child = ndx;
            int parent = GetParentIndex(child);
            while (arr[parent] > arr[child])
            {
                Swap(parent, child);
                parent = GetParentIndex(parent);
            }

            return;
        }

        // 최소힙의 최소값 제거
        public int Delete()
        {
            int delValue = arr[0];
            bubbleDown();
            --length;
            return delValue;
        }

        void bubbleDown()
        {
            int ndx = 0;
            int child1;
            int child2;
            while(true)
            {
                child1 = GetLeftChildIndex(ndx);
                child2 = GetRightChildIndex(ndx);
                if (IsInvalidate(child1) == true || IsInvalidate(child2) == true)
                {
                    break;
                }
                int min = Min(child1, child2);
                Swap(ndx, min);
                ndx = min;
            }
            arr[ndx] = 0;
            return;
        }

        public MinHeap(int length) : base(length) { }
    }


    class Heap_Implemente
    {
        static void Main(string[] args)
        {
            MinHeap minHeap = new MinHeap(7);
            for(int i = 0; i < minHeap.Capacity; ++i)
            {
                minHeap.Add(i + 1);
            }

            Console.WriteLine(minHeap.Peek);
            minHeap.Delete();
            Console.WriteLine(minHeap.Peek);
            minHeap.Delete();
            Console.WriteLine(minHeap.Peek);
            minHeap.Delete();
            Console.WriteLine(minHeap.Peek);
            minHeap.Delete();

            Console.WriteLine(minHeap.Peek);
            minHeap.Add(4);
            Console.WriteLine(minHeap.Peek);
            minHeap.Add(6);
            Console.WriteLine(minHeap.Peek);
            minHeap.Add(9);
            Console.WriteLine(minHeap.Peek);
            minHeap.Add(2);

        }
    }
}
