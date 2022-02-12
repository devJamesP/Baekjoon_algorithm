using System;
using System.Collections.Generic;
using System.IO;

namespace AlgorithmProblem
{
    struct SDocument
    {
        public int Num;
        public int Importance;
        public SDocument(int num, int importance)
        {
            this.Num = num;
            this.Importance = importance;
        }
    }

    class _1966_Printer_Queue
    {
        /*
         * NM : 문서의 개수, 현재 궁금한 문서가 Queue에 몇 번째에 놓여 있는지
         * nDocNums : 문서 중요도 배열
         * curiousDocument : 궁금한 문서
         * nCount : 궁금한 문서가 인쇄되는 순서
         * maxImportanceDocument : 현재 Queue에서 가장 중요도가 높은 문서
         */

        static void Problem_1966()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int nTestCase = int.Parse(sr.ReadLine());
            int[] NM;
            int[] nDocNums;

            SDocument curiousDocument;
            SDocument maxImportanceDocument;
            int nCount;

            Queue<SDocument> queue = new Queue<SDocument>();

            for(int i = 0; i < nTestCase; ++i)
            {
                // input
                NM = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
                nDocNums = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

                for(int j = 0; j < NM[0]; ++j)
                {
                    queue.Enqueue(new SDocument(j, nDocNums[j]));
                }

                curiousDocument = new SDocument(NM[1], nDocNums[NM[1]]);
                maxImportanceDocument = GetBigOfNums(queue.ToArray());
                nCount = 0;

                // compare and dequeue
                while (NM[0] > 0)
                {
                    SDocument doc = queue.Dequeue();
                    if (doc.Importance < maxImportanceDocument.Importance)
                    {
                        queue.Enqueue(doc);
                    }
                    else
                    {
                        ++nCount;
                        --NM[0];
                        if (curiousDocument.Importance == doc.Importance && curiousDocument.Num == doc.Num)
                        {
                            break;
                        }
                        maxImportanceDocument = GetBigOfNums(queue.ToArray());
                    }
                }
                sw.WriteLine(nCount);
                queue.Clear();
            }

            sw.Flush();
            sr.Close();
            sw.Close();
        }

        static SDocument GetBigOfNums(SDocument[] docArr)
        {
            SDocument maxDoc = docArr[0];
            for(int i = 0; i < docArr.Length; ++i)
            {
                maxDoc = maxDoc.Importance < docArr[i].Importance ? docArr[i] : maxDoc;
            }
            return maxDoc;
        }

    }
}
