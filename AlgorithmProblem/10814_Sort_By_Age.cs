using System;
using System.IO;
using System.Collections.Generic;

namespace AlgorithmProblem
{
    struct Member
    {
        public Member(int age, string name)
        {
            this.age = age;
            this.name = name;
        }
        int age;
        public int Age
        {
            get { return age; }
        }
        string name;
        public string Name
        {
            get { return name; }
        }
    }

    class _10814_Sort_By_Age
    {
        static void Problem_10814()
        {
            StreamReader sr = new StreamReader(Console.OpenStandardInput());
            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());

            int nInputMembers = int.Parse(sr.ReadLine());

            // 0 제외
            List<Member>[] memberList = new List<Member>[201];

            // Input
            for (int i = 0; i < memberList.Length; ++i)
            {
                memberList[i] = new List<Member>();
            }

            string[] strInputArr;
            for (int i = 0; i < nInputMembers; ++i)
            {
                strInputArr = sr.ReadLine().Split(' ');
                int nAge = int.Parse(strInputArr[0]);
                string strName = strInputArr[1];
                memberList[nAge].Add(new Member(nAge, strName));
            }

            // output
            for(int i = 1; i < 201; ++i)
            {
                for(int j = 0; j < memberList[i].Count; ++j)
                {
                    sw.WriteLine(memberList[i][j].Age + " " + memberList[i][j].Name);
                }
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }
    }
}
