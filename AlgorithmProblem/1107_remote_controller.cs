using System;
using System.IO;

namespace AlgorithmProblem
{
    /*
     * N : 이동하고 싶은 채널
     * M : 고장난 버튼 갯수(고장났으면 새로 좀 사라 수빈아)
     * iChannelCounter : 100을 기준으로 각 채널별로 이동할때의 카운트 저장 배열
     * iOver : 최대 이동 횟수 (499900임 500000으로 이동하는데 버튼 다고장나면 +로만 이동해야함 ㅋㅋ)
     * 
     * exceptBrokenNumber() : 부서진 버튼 제외 메서드
     * pushBtnNumberCount() : 번호로 이동 할 때의 누른 횟수 세는 메서드
     * calculateMinCount()  : 최솟값 구하기
     * 
     * 
     * [풀이]
     * 결국 브루트 포스 알고리즘 이기 때문에 완전 탐색이 가능하다.
     * 여기서 놓치면 안되는 부분이 만약 500000으로 이동해야하는데 9가 고장났다면
     * 500001에서 이동하는게 가장 빠르다. 즉, 배열의 크기를 500000 + 499900개 해야한다는 점. 계산의 편리를 위해 100만1개 생성했다.
     * 
     * 각 배열의 요소에는 다음을 저장한다.
     * 1. 고장난 버튼의 숫자를 포함한 채널의 경우 
     * 최댓값을 넣어버린다.
     * 
     * 2. 최댓값을 저장한 요소를 제외하고 
     * 버튼을 눌렀을 때 가장 빠르므로 
     * 0~1000001까지 버튼으로 이동한다고 했을 때
     * 누른 버튼의 갯수를 저장한다.
     * (단, 99~102는 버튼을 누르는 것보다 +/-를 누르는 것이 
     * 훨씬 빠르므로 따로 넣어준다. 100은 0)
     * 
     * 3. 이제 +/-로만 움직이면 되므로
     * 고장난 버튼의 숫자를 포함한 채널에서는 
     * Abs(100 -해당 숫자) + Abs(N - 해당 숫자)로 계산하고
     * 그 외에는 Abs(N - 해당숫자) 로 계산한다.
     * 끝!
     * 
     * ex)
     * 
     * 110으로 이동해야 한다고 해보자
     * 부서진 버튼은 없다고 가정하면
     * 
     * 1. 각 채널별로 100에서 해당 채널로 번호를 누른 횟수 계산
     * 0   = 1
     * ...
     * 96  = 2
     * 97  = 2
     * 98  = 2
     * 99  = 1(+/-누르는게 더 빠름)
     * 100 = 0(번호 누를 필요 없음)
     * 101 = 1(+/-누르는게 더빠르므로)
     * 102 = 2(+/-누르는게 더빠름)
     * 103 = 3
     * 104 = 3
     * ...
     * 1000000 = 7
     * 
     * 2. 이렇게 저장하고 난뒤
     * 해당 숫자에서 110으로 +/-로만 움직이게 했을 때
     * 누른 횟수를 구하고 가장 적은 수를 누르값을 구하면 된다.
     * 
     *          +/-버튼 누른 횟수
     *           ↓ 
     * 0 = 100 + 110
     * 1 = 99 + 109
     * 2 = 98 + 108
     * ...
     * 100 = 0 + 10
     * 101 = 1 + 9
     * 102 = 2 + 8
     * ...
     * 109 = 3 + 1
     * 110 = 3 + 0
     * 111 = 3 + 1
     * 112 = 3 + 2
     * ...
     * 500000 = 499900 + 499890
     * ...
     * 
     * 즉, 여기서는 110을 직접 누르는게 가장 빠르다~
     */

    class _1107_remote_controller
    {
        static int[] iChannelCounter = new int[1000001];
        static int iOver = abs(iChannelCounter.Length/2 - 100);
        static void Problem_1107()
        {
            StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int N = int.Parse(sr.ReadLine());
            int M = int.Parse(sr.ReadLine());
            int[] iBrokenNum;
            if (M > 0)
            {
                iBrokenNum = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
                exceptBrokenNumber(iChannelCounter, iBrokenNum);
            }

            pushBtnNumberCount(iChannelCounter);

            // calculate (+)
            int iMin = calculateMinCount(iChannelCounter, N);

            sw.WriteLine(iMin);
            sw.Flush();
            sr.Close();
            sw.Close();

            return;
        }
        static void pushBtnNumberCount(int[] iChannelCounter)
        {
            for (int i = 0; i < iChannelCounter.Length; ++i)
            {
                if (iChannelCounter[i] == iOver)
                {
                    continue;
                }

                if (i > 99999)
                {
                    iChannelCounter[i] = 6;
                }
                else if (i > 9999)
                {
                    iChannelCounter[i] = 5;
                }
                else if (i > 999)
                {
                    iChannelCounter[i] = 4;
                }
                else if (i > 102)
                {
                    iChannelCounter[i] = 3;
                }
                else if (i > 9 && i < 99 || i == 102)
                {
                    iChannelCounter[i] = 2;
                }
                else if (i < 10 || i == 101 || i == 99)
                {
                    iChannelCounter[i] = 1;
                }
                else
                {
                    iChannelCounter[i] = 0;
                }
            }
        }
        static void exceptBrokenNumber(int[] iChannelCounter, int[] iBrokenNum)
        {
            for (int i = 0; i < iChannelCounter.Length; ++i)
            {
                if (isContainBrokenNum(i, iBrokenNum) == true)
                {
                    iChannelCounter[i] = iOver;
                }
            }
        }
        static bool isContainBrokenNum(int n, int[] iBrokenNum)
        {
            if (n == 0)
            {
                for (int i = 0; i < iBrokenNum.Length; ++i)
                {
                    if (n == iBrokenNum[i])
                    {
                        return true;
                    }
                }
            }
            else
            {
                while (n != 0)
                {
                    for (int i = 0; i < iBrokenNum.Length; ++i)
                    {
                        if (n % 10 == iBrokenNum[i])
                        {
                            return true;
                        }
                    }
                    n /= 10;
                }
            }

            return false;
        }
        static int calculateMinCount(int[] iChannelCounter, int N)
        {
            int iMin = iOver;
            for (int i = 0; i < iChannelCounter.Length; ++i)
            {
                if (iChannelCounter[i] != iOver)
                {
                    iChannelCounter[i] += abs(N - i);
                }
                else
                {
                    iChannelCounter[i] = abs(i - 100) + abs(N - i);
                }
                iMin = iMin > iChannelCounter[i] ? iChannelCounter[i] : iMin;
            }
            return iMin;
        }
        static int abs(int n)
        {
            return n < 0 ? (~n + 1) : n;
        }
    }
}
