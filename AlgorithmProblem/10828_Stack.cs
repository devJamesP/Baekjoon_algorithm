using System;
using System.IO;

namespace AlgorithmProblem
{


    class MyStack
    {
        int[] arr;
        int capacity;
        int curPos;

        int length;

        public MyStack()
        {
            capacity = 1;
            length = 0;
            curPos = -1;
            arr = new int[capacity];
        }

        public void Push(int data)
        {
            if (length == capacity)
            {
                int[] temp = arr;
                arr = new int[capacity * 2];
                for (int i = 0; i < length; ++i)
                {
                    arr[i] = temp[i];
                }
                capacity *= 2;
            }
            ++curPos;
            arr[curPos] = data;

            ++length;
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
            int popData = arr[curPos];
            --curPos;
            --length;
            return popData;
        }

        public int Size()
        {
            return length;
        }

        public int Top()
        {
            return IsEmpty() == 1 ? -1 : arr[curPos];
        }
    }

    class _10828_Stack
    {
        static void Problem_10828()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            MyStack stack = new MyStack();

            int nInstructCase = int.Parse(sr.ReadLine());
            string[] strInput;

            string strInstruct;
            int data;

            for (int i = 0; i < nInstructCase; ++i)
            {
                strInput = sr.ReadLine().Split(' ');
                strInstruct = strInput[0];

                switch (strInstruct)
                {
                    case "push":
                        data = int.Parse(strInput[1]);
                        stack.Push(data);
                        break;
                    case "pop":
                        int popData = stack.Pop();
                        sw.WriteLine(popData);
                        break;
                    case "top":
                        int topData = stack.Top();
                        sw.WriteLine(topData);
                        break;
                    case "empty":
                        int isEmpty = stack.IsEmpty();
                        sw.WriteLine(isEmpty);
                        break;
                    case "size":
                        int nSize = stack.Size();
                        sw.WriteLine(nSize);
                        break;
                    default:
                        /* Nothing */
                        break;
                }
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
