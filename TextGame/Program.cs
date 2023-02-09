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
        public int Randomer(int min, int max)
        {
            Random rd = new Random();
            return rd.Next(min, max);
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
                    else if (playGround[i, j] == "3")
                    {
                        playGround[i, j] = "♨";
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
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
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

        public int[] previusArr = new int[3];
        public static void SetRandom()
        {
            RandomPlace rp = new RandomPlace();
            int arr = rp.Randomer(1, playGround.GetLength(1) - 1);
            
            playGround[1, arr] = arrText[arr];
        }

        public static int fps = 0;
        public static int currentLine;
        public static void OnTimedEvent()
        {
            while (true) {
                
                //플레이 그라운드 초기화 클래스.
                Initialize init = new Initialize();
                init.InitializePlayGround(playGround);

                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = false;
            }
        }

        
        //텍스트들을 아래로 움직인다
        public static void MoveDown()
        {
            while(true)
            {
                for(int i = playGround.GetLength(0) - 3; i >= 1; i--)
                {
                    for (int j = 1; j < playGround.GetLength(1) - 2; j++)
                    {
                        if (playGround[i, j] != "□" && playGround[i, j] != "  ")
                        {
                            //이전 텍스트들을 없앰
                            string temp = playGround[i, j];
                            playGround[i, j] = "  ";
                            //이전텍스들의 y를 하나 올림
                            playGround[i + 1, j] = temp;
                            Thread.Sleep(100);
                        }
                    }
                }
                SetRandom();
            }
            //위에서부터 아래가 아닌 아래에서부터 위로 올라가는 방식으로.,
        }
        //온천 아이콘을 오른쪽으로 움직인다
        public static void MoveRight()
        {
            //객체지향적으로 코드 바꾸기-------------------------------------------------------------------
            for (int i = 1; i < playGround.GetLength(1) - 2; i++)
            {
                if (playGround[playGround.GetLength(0) - 2, i] == "♨")
                {
                    string temp = playGround[playGround.GetLength(0) - 2, i];
                    playGround[playGround.GetLength(0) - 2, i] = "  ";
                    playGround[playGround.GetLength(0) - 2, i + 1] = temp;
                    break;
                }
            }
        }
        //온천 아이콘을 왼쪽으로 움직인다
        public static void MoveLeft()
        {
            //객체지향적으로 코드 바꾸기-------------------------------------------------------------------
            for (int i = 1; i < playGround.GetLength(1) - 2; i++)
            {
                if (playGround[playGround.GetLength(0) - 2, i] == "♨")
                {
                    string temp = playGround[playGround.GetLength(0) - 2, i];
                    playGround[playGround.GetLength(0) - 2, i] = "  ";
                    playGround[playGround.GetLength(0) - 2, i - 1] = temp;
                    break;
                }
            }
        }

        public static ConsoleKeyInfo c;
        public static void Input()
        {
            while (true)
            {
                c = Console.ReadKey(true);
                if(c.Key == ConsoleKey.RightArrow)
                {
                    MoveRight();
                }
                else if(c.Key == ConsoleKey.LeftArrow)
                {
                    MoveLeft();
                }
            }
        }

        //텍스트들이 마지막 라인인지 확인하는 메서드
        public static bool IsEndLine()
        {
            if (currentLine == 10)
            {
                Environment.Exit(0);
            }
            return false;
        }

        static void Main(string[] args)
        {
            IntToString();
            SetRandom();


            //플레이 그라운드에서의 텍스트 랜덤 위치를 뽑아내는 클래스.
            Task workPlayGround = new Task(new Action(OnTimedEvent));
            Task workInput = new Task(new Action(Input));
            Task workMoveDown = new Task(new Action(MoveDown));

            workPlayGround.Start();
            workMoveDown.Start();

            workInput.Start();
            workInput.Wait();

            workMoveDown.Wait();
            workPlayGround.Wait();
        }
    }
}

