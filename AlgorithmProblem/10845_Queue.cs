using System;
using System.IO;

namespace AlgorithmProblem
{
    class MyQueue
    {
        int[] arr;
        int backPos;

        int length;
        int capacity;

        public MyQueue()
        {
            backPos = -1;

            length = 0;

            capacity = 1;

            arr = new int[1];
        }

        public void Push(int data)
        {
            if (length == capacity)
            {
                int[] temp = arr;
                arr = new int[capacity * 2];
                for (int i = 0; i < temp.Length; ++i)
                {
                    arr[i] = temp[i];
                }
                capacity *= 2;
            }
            ++backPos;
            ++length;
            arr[backPos] = data;
        }

        public int IsEmpty()
        {
            return length == 0 ? 1 : 0;
        }

        public int Pop()
        {
            if (IsEmpty() == 1)
            {
                return -1;
            }

            int popData = Front();
            --backPos;
            --length;

            for (int i = 0; i < length; ++i)
            {
                arr[i] = arr[i + 1];
            }
            return popData;
        }

        public int Size()
        {
            return length;
        }

        public int Front()
        {
            return IsEmpty() == 1 ? -1 : arr[0];
        }

        public int Back()
        {
            return IsEmpty() == 1 ? -1 : arr[backPos];
        }
    }

    class _10845_Queue
    {
        static void Problem_10845(string[] args)
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            MyQueue queue = new MyQueue();

            int nInstructCase = int.Parse(sr.ReadLine());
            string[] strInput;

            for (int i = 0; i < nInstructCase; ++i)
            {
                strInput = sr.ReadLine().Split(' ');
                switch (strInput[0])
                {
                    case "push":
                        queue.Push(int.Parse(strInput[1]));
                        break;
                    case "pop":
                        sw.WriteLine(queue.Pop());
                        break;
                    case "size":
                        sw.WriteLine(queue.Size());
                        break;
                    case "empty":
                        sw.WriteLine(queue.IsEmpty());
                        break;
                    case "front":
                        sw.WriteLine(queue.Front());
                        break;
                    case "back":
                        sw.WriteLine(queue.Back());
                        break;
                    default:
                        /* Wrong Instruct */
                        break;
                }
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
