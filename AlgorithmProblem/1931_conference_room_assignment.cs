using System;
using System.IO;

namespace AlgorithmProblem
{
    class CTime : IComparable<CTime>
    {
        int nIn;
        public int InTime { get { return nIn; } }

        int nExit;
        public int ExitTime { get { return nExit; } }
        public CTime(int nIn, int nExit)
        {
            this.nIn = nIn;
            this.nExit = nExit;
        }

        public int CompareTo(CTime other)
        {
            if (ExitTime < other.ExitTime)
            {
                return -1;
            }
            else if (ExitTime == other.ExitTime)
            {
                if (InTime < other.InTime)
                {
                    return -1;
                }
                else if (InTime > other.InTime)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 1;
            }
        }
    }

    class _1931_conference_room_assignment
    {
        static void Problem_1931()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int N = int.Parse(sr.ReadLine());
            CTime[] aTime = new CTime[N];
            int nCnt = 1;

            // input
            for (int i = 0; i < N; ++i)
            {
                string[] aInput = sr.ReadLine().Split();
                int nIn = int.Parse(aInput[0]);
                int nExit = int.Parse(aInput[1]);
                aTime[i] = new CTime(nIn, nExit);
            }

            // sort
            Array.Sort(aTime);

            // calc
            int nTime = aTime[0].ExitTime;
            for (int i = 1; i < N; ++i)
            {
                if (nTime <= aTime[i].InTime)
                {
                    nTime = aTime[i].ExitTime;
                    ++nCnt;
                }
            }

            // output
            sw.WriteLine(nCnt);

            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }
    }
}
