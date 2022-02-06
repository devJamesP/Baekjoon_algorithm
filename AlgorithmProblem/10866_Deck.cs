using System;
using System.IO;

namespace AlgorithmProblem
{
    class MyDeque
    {
        Node FrontRoot;
        Node BackRoot;

        bool bEmpty;
        int size;

        public MyDeque()
        {
            FrontRoot = new Node(0);
            BackRoot = new Node(0);
            bEmpty = true;
            size = 0;

            FrontRoot.NextNode = BackRoot;
            BackRoot.PreNode = FrontRoot;
        }

        public void PushFront(int data)
        {
            if (bEmpty == true)
            {
                bEmpty = false;
            }

            Node tempNode = FrontRoot.NextNode;

            Node pushNode = new Node(data);
            FrontRoot.NextNode = pushNode;
            pushNode.PreNode = FrontRoot;

            pushNode.NextNode = tempNode;
            tempNode.PreNode = pushNode;
            ++size;
        }

        public void PushBack(int data)
        {
            if (bEmpty == true)
            {
                bEmpty = false;
            }

            Node tempNode = BackRoot.PreNode;

            Node pushNode = new Node(data);
            BackRoot.PreNode = pushNode;
            pushNode.NextNode = BackRoot;

            pushNode.PreNode = tempNode;
            tempNode.NextNode = pushNode;
            ++size;
        }

        public int PopFront()
        {
            if (IsEmpty() == 1)
            {
                return -1;
            }

            Node popNode = FrontRoot.NextNode;
            Node nextNode = popNode.NextNode;

            FrontRoot.NextNode = nextNode;
            nextNode.PreNode = FrontRoot;

            --size;
            if (Size() == 0)
            {
                bEmpty = true;
            }
            return popNode.Data;
        }

        public int PopBack()
        {
            if (IsEmpty() == 1)
            {
                return -1;
            }

            Node popNode = BackRoot.PreNode;
            Node preNode = popNode.PreNode;

            BackRoot.PreNode = preNode;
            preNode.NextNode = BackRoot;

            --size;
            if (Size() == 0)
            {
                bEmpty = true;
            }
            return popNode.Data;
        }

        public int Size()
        {
            return size;
        }

        public int IsEmpty()
        {
            return bEmpty == true ? 1 : 0;
        }

        public int Front()
        {
            return IsEmpty() == 1 ? -1 : FrontRoot.NextNode.Data;
        }

        public int Back()
        {
            return IsEmpty() == 1 ? -1 : BackRoot.PreNode.Data;
        }
    }

    public class Node
    {
        public int Data;
        public Node NextNode;
        public Node PreNode;

        public Node(int data)
        {
            this.Data = data;
            this.NextNode = null;
            this.PreNode = null;
        }
    }


    class _10866_Deque
    {
        static void Problem_10866()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            MyDeque deque = new MyDeque();

            int nInstructCase = int.Parse(sr.ReadLine());
            for (int i = 0; i < nInstructCase; ++i)
            {
                string[] strInputArr = sr.ReadLine().Split(' ');
                switch (strInputArr[0])
                {
                    case "push_front":
                        deque.PushFront(int.Parse(strInputArr[1]));
                        break;
                    case "push_back":
                        deque.PushBack(int.Parse(strInputArr[1]));
                        break;
                    case "pop_front":
                        sw.WriteLine(deque.PopFront());
                        break;
                    case "pop_back":
                        sw.WriteLine(deque.PopBack());
                        break;
                    case "empty":
                        sw.WriteLine(deque.IsEmpty());
                        break;
                    case "size":
                        sw.WriteLine(deque.Size());
                        break;
                    case "front":
                        sw.WriteLine(deque.Front());
                        break;
                    case "back":
                        sw.WriteLine(deque.Back());
                        break;
                    default:
                        /* Wrong Instruct type */
                        break;
                }
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
