using System;
using System.IO;
namespace AlgorithmProblem
{
    class _11651_Aligning_Coordinates
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int n = int.Parse(sr.ReadLine());
            MyPoint[] myPoint = new MyPoint[n];

            string[] strInputArr;
            int x;
            int y;
            for (int i = 0; i < n; ++i)
            {
                strInputArr = sr.ReadLine().Split(' ');
                x = Convert.ToInt32(strInputArr[0]);
                y = Convert.ToInt32(strInputArr[1]);
                myPoint[i] = new MyPoint(x, y);
            }

            Array.Sort(myPoint);
            for (int i = 0; i < n; ++i)
            {
                sw.WriteLine(myPoint[i].X + " " + myPoint[i].Y);
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }

    class MyPoint : IComparable<MyPoint>
    {
        int x;
        public int X { get { return x; } }
        int y;
        public int Y { get { return y; } }

        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int CompareTo(MyPoint other)
        {
            if (this.y == other.y)
            {
                if (this.x < other.x)
                {
                    return -1;
                }
                else if (this.x > other.x)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else if (this.y < other.y)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}