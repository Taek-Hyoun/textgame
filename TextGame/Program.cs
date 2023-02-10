using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

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
                    Console.Write(playGround[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
    class Character
    {
        Program pg = new Program();
        public int x = 14;
        public int y = 20;

        public void MoveRight(string[,] playGround)
        {
            string temp = playGround[y, x];
            playGround[y, x] = "  ";
            playGround[y, x + 1] = temp;
            x++;
        }
        public void MoveLeft(string[,] playGround)
        {
            if (x >= 1)
            {
                string temp = playGround[y, x];
                playGround[y, x] = "  ";
                playGround[y, x - 1] = temp;
                x--;
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
            {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
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
        
        public static void SetCharacter()
        {
            Character cht = new Character();
            playGround[cht.y, cht.x] = "♨";
        }


        public static int fps = 0;
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
                    if(i + 1 == playGround.GetLength(0) - 2)
                    {
                        for (int j = 1; j < playGround.GetLength(1) - 2; j++)
                        {
                            //regex
                            Match m = Regex.Match(playGround[playGround.GetLength(0) - 2, j], "[a-z]");
                            if (m.Success)
                            {
                                Debug.WriteLine(m.Success);
                                playGround[playGround.GetLength(0) - 2, j] = "  ";
                            }
                        }
                    }


                    for (int j = 1; j < playGround.GetLength(1) - 2; j++)
                    {
                        if (playGround[i, j] != "□" && playGround[i, j] != "  ")
                        {
                            //이전 텍스트들을 없앰
                            string temp = playGround[i, j];
                            playGround[i, j] = "  ";
                            //이전텍스들의 y를 하나 올림
                            playGround[i + 1, j] = temp;
                            Thread.Sleep(1);
                        }
                    }
                }
                SetRandom();
            }
            //위에서부터 아래가 아닌 아래에서부터 위로 올라가는 방식으로.,
        }

        public static Character cht = new Character();

        public static ConsoleKeyInfo c;
        public static void Input()
        {
            while (true)
            {
                c = Console.ReadKey(true);
                if(c.Key == ConsoleKey.RightArrow)
                {
                    cht.MoveRight(playGround);
                }
                else if(c.Key == ConsoleKey.LeftArrow)
                {
                    cht.MoveLeft(playGround);
                }
            }
        }

        static void Main(string[] args)
        {
            IntToString();
            SetRandom();
            SetCharacter();

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

