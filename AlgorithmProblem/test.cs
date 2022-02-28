using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProblem
{
    public class Solution
    {
        static void Main(string[] args)
        {
            string[,] places = { { "POOOP", "OXXOX", "OPXPX", "OOXOX", "POXXP" } };
            int[] nArr = solution(places);
            for(int i = 0; i < nArr.Length; ++i)
            {
                Console.WriteLine(nArr[i]);
            }
        }

        static public int[] solution(string[,] places)
        {
            int[] answer = new int[places.GetLength(0)];

            for (int i = 0; i < places.GetLength(0); ++i)
            {
                string[] strARoom = new string[places.GetLength(0)];
                for (int j = 0; j < strARoom.Length; ++j)
                {
                    strARoom[j] = places[i, j];
                }
                if (isKeepDistance(strARoom) == true)
                {
                    ++answer[i];
                }
            }

            return answer;
        }

        static bool isKeepDistance(string[] strARoom)
        {
            int length = strARoom.Length;
            int[,] nARoom = new int[length, length];
            for (int i = 0; i < length; ++i)
            {
                for (int j = 0; j < length; ++j)
                {
                    switch (strARoom[i][j])
                    {
                        case 'O':
                            nARoom[i, j] = 0;
                            break;
                        case 'P':
                            nARoom[i, j] = 1;
                            break;
                        case 'X':
                            nARoom[i, j] = 8;
                            break;
                        default:
                            /* Nothing */
                            break;
                    }
                }
            }
            for (int i = 0; i < length; ++i)
            {
                for (int j = 0; j < length; ++j)
                {
                    if (isInvalidate(j, i, nARoom) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // 거리두기를 지키지 않고 있다면 true
        static bool isInvalidate(int x, int y, int[,] nARoom)
        {
            int length = nARoom.GetLength(0);

            // 맨해튼 x축 체크
            for (int i = 1; i < 3; ++i)
            {
                if (x + i < length && nARoom[y, x + i] == 1)
                {
                    if (i == 1 || nARoom[y, x + 1] != 8)
                    {
                        return true;
                    }
                }

                if (x - i >= 0 && nARoom[y, x - i] == 1)
                {
                    if (i == 1 || nARoom[y, x - 1] != 8)
                    {
                        return true;
                    }
                }
            }
            // 맨해튼 y축 체크
            for (int i = 1; i < 3; ++i)
            {
                if (y + i < length && nARoom[y + i, x] == 1)
                {
                    if (i == 1 || nARoom[y + i, x] != 8)
                    {
                        return true;
                    }
                }

                if (y - i >= 0 && nARoom[y - i, x] == 1)
                {
                    if (i == 1 || nARoom[y - i, x] != 8)
                    {
                        return true;
                    }
                }
            }

            // 맨해튼 대각선 체크
            if (x + 1 < length && y + 1 < length && nARoom[y + 1, x + 1] == 1)
            {
                if (nARoom[y, x + 1] != 8 || nARoom[y + 1, x] != 8)
                {
                    return false;
                }
            }

            if (x - 1 >= 0 && y + 1 < length && nARoom[y + 1, x - 1] == 1)
            {
                if (nARoom[y + 1, x] != 8 || nARoom[y, x - 1] != 8)
                {
                    return false;
                }
            }

            if (x - 1 >= 0 && y - 1 >= 0 && nARoom[y - 1, x - 1] == 1)
            {
                if (nARoom[y - 1, x] != 8 || nARoom[y, x - 1] != 8)
                {
                    return false;
                }
            }

            if (x + 1 < length && y - 1 >= 0 && nARoom[y - 1, x + 1] == 1)
            {
                if (nARoom[y - 1, x] != 8 || nARoom[y, x + 1] != 8)
                {
                    return false;
                }
            }

            return false;
        }


        static int Abs(int n)
        {
            return n < 0 ? (~n + 1) : n;
        }

    }
}
