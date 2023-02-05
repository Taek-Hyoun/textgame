using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace TextGame
{
    class RandomPlace
    {
        public int[] numOfRand = new int[3];
        public int[] Randomer(int min, int max)
        {
            Random rd = new Random();
            for (int i = 0; i < 3; i++)
            {
                this.numOfRand[i] = rd.Next(min, max);
            }
            return this.numOfRand;
        }
    }

    class Initialize
    {
        public void InitializePlayGround(string[,] playGround)
        {
            for (int i = 0; i < playGround.GetLength(0); i++)
            {
                for (int j = 0; j < playGround.GetLength(1); j++)
                {
                    if (playGround[i, j] == "0")
                    {
                        playGround[i, j] = "  ";
                    }
                    else if (playGround[i, j] == "1" || playGround[i, j] == "2")
                    {
                        playGround[i, j] = "□";
                    }
                    Console.Write(playGround[i, j]);
                }
                Console.Write("\n");
            }
        }
    }

    class Program
    {
        public static int[,] intArr = new int[,]
            {
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2},
                //{2,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            };

        public static int row = 22;
        public static int column = 28;
        public static string[,] playGround = new string[row, column];
        public static void IntToString()
        {

            //배열 안의 값이 정수니까 문자열로 바꿔주는 반복문.
            for (int i = 0; i < intArr.GetLength(0); i++)
            {
                for (int j = 0; j < intArr.GetLength(1); j++)
                {
                    playGround[i, j] = intArr[i, j].ToString();
                }
            }
        }

        public static string[] arrText = new string[] {"", "a ", "b ", "c ", "d ", "e ", "f ", "g ", "h ", "i ", "j ", "k ", "l ", "m ", "n ", "o ", "p ",
                                             "q ", "r ", "s ", "t ", "u ", "v ", "w ", "x ", "y ", "z "};

        static void Main(string[] args)
        {
            IntToString();

            SetRandom();
            //플레이 그라운드에서의 텍스트 랜덤 위치를 뽑아내는 클래스.
            System.Timers.Timer aTimer = new System.Timers.Timer();

            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 1000;
            aTimer.Start();
            Console.ReadLine();
        }
        public int[] previusArr = new int[3];
        public static void SetRandom()
        {
            RandomPlace rp = new RandomPlace();
            int[] arr = rp.Randomer(1, playGround.GetLength(1)-1);

            for (int i = 1; i <= 1; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    playGround[i, arr[j]] = arrText[arr[j]];
                }
            }
        }
        public static int fps = 0;
        public static int currentLine;
        public static ConsoleKey c;

        public static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            //플레이 그라운드 초기화 클래스.
            Initialize init = new Initialize();
            init.InitializePlayGround(playGround);
            //텍스트들이 마지막 라인에 도달했을 때 랜덤메서드 실행
            if (IsEndLine()) {
                SetRandom();
            }
            MoveDown(fps++);

            c = Console.ReadKey();   // 입력한 키를 받음
            switch (c.Key)
            {
                case ConsoleKey.RightArrow:
                    //오른쪽 움직임 메서드
                    break;
                case ConsoleKey.LeftArrow:
                    //왼쪽 움직임 메서드
                    break;
            }

            Console.SetCursorPosition(0, 0);
        }
        //텍스트들을 아래로 움직인다
        public static void MoveDown(int HowLong)
        {
            for(int i = 1; i <= HowLong; i++)
            {
                for (int j = 1; j < 28; j++)
                {
                    if (playGround[i, j] != "□" && playGround[i, j] != "  ")
                    {
                        //이전 텍스트들을 없앰
                        string temp = playGround[i, j];
                        playGround[i, j] = "  ";
                        //이전텍스들의 y를 하나 올림
                        playGround[i + 1, j] = temp;
                        currentLine = i + 1;
                    }
                }
            }
        }
        //텍스트들이 마지막 라인인지 확인하는 메서드
        public static bool IsEndLine()
        {
            if(currentLine == 10)
            {
                Environment.Exit(0);
            }
            return false;
        }
    }
}

