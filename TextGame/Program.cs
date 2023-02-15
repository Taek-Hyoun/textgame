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
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http.Headers;
using System.Xml.Linq;

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
        private int x = 4;
        private int y = 20;
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public void MoveRight(string[,] playGround)
        {
            string temp = playGround[this.y, this.x];
            playGround[this.y, this.x] = "  ";
            playGround[this.y, this.x + 1] = temp;
        }
        public void MoveLeft(string[,] playGround)
        {
            string temp = playGround[this.y, this.x];
            playGround[this.y, this.x] = "  ";
            playGround[this.y, this.x - 1] = temp;
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
        public static void IntToString(int[,] arr)
        {
            //배열 안의 값이 정수니까 문자열로 바꿔주는 반복문.
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    playGround[i, j] = arr[i, j].ToString();
                }
            }
        }
        public static string[,] IntToString(int[,] arr, string[,] strArr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    strArr[i, j] = arr[i, j].ToString();
                }
            }
            return strArr;
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

        public static Character cht = new Character();
        public static void SetCharacter()
        {
            playGround[cht.Y, cht.X] = "♨";
        }


        public static int fps = 0;
        public static async Task OnTimedEvent()
        {
            await Task.Run(() =>
            {
                while (true && !cancellationTokenSource.IsCancellationRequested)
                {
                    //플레이 그라운드 초기화 클래스.
                    Initialize init = new Initialize();
                    init.InitializePlayGround(playGround);

                    Console.SetCursorPosition(0, 0);
                    Console.CursorVisible = false;
                }
            });
        }
        public static void EndGame()
        {
            string[,] endGround = (string[,])playGround.Clone();
            int[,] sample = (int[,])intArr.Clone();
            IntToString(sample, endGround);

            string texts = "Game Over";
            for (int j = 0; j < texts.Length; j++)
            {
                endGround[4, j + 4] = texts[j].ToString() + " ";
            }
            Initialize init = new Initialize();
            init.InitializePlayGround(endGround);
        }
        //텍스트들을 아래로 움직인다
        public static async Task MoveDown()
        {
            await Task.Run(() =>
            {
                int lastLine = playGround.GetLength(0) - 2;
                while (true && !cancellationTokenSource.IsCancellationRequested)
                {
                    for (int i = playGround.GetLength(0) - 3; i >= 1; i--)
                    {
                        if (i + 1 == lastLine)
                        {
                            for (int j = 1; j < playGround.GetLength(1) - 2; j++)
                            {
                                //regex
                                Match m = Regex.Match(playGround[lastLine, j], "[a-z]");
                                if (m.Success)
                                {
                                    Debug.WriteLine("cht.Y{0} lastLine {1} cht.X {2} j {3}", cht.Y, lastLine, cht.X, j);
                                    if (lastLine == cht.Y && j == cht.X)
                                    {
                                        //gameEnd();
                                        playGround[playGround.GetLength(0) - 2, j] = "  ";
                                        Debug.WriteLine("GameEnd!");
                                        cancellationTokenSource.Cancel();
                                    }
                                    playGround[playGround.GetLength(0) - 2, j] = "  ";
                                }
                            }
                        }


                        for (int j = 1; j < playGround.GetLength(1) - 2; j++)
                        {
                            if (playGround[i, j] != "□" && playGround[i, j] != "  " && playGround[i, j] != "♨")
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
                    if (cancellationTokenSource.IsCancellationRequested) { 
                        Console.Clear();
                        EndGame();
                    }
                }
            });
            //위에서부터 아래가 아닌 아래에서부터 위로 올라가는 방식으로.,
        }

        //public static Character cht = new Character();

        public static ConsoleKeyInfo c;
        public static async Task Input()
        {
            await Task.Run(() =>
            {
                while (true && !cancellationTokenSource.IsCancellationRequested)
                {
                    c = Console.ReadKey(true);
                    if (c.Key == ConsoleKey.RightArrow && playGround.GetLength(1) - 2 > cht.X)
                    {
                        cht.MoveRight(playGround);
                        cht.X = cht.X + 1;
                    }
                    else if (c.Key == ConsoleKey.LeftArrow && cht.X > 1)
                    {
                        cht.MoveLeft(playGround);
                        cht.X = cht.X - 1;
                    }
                }
            });
        }
        public static void StartGame()
        {
            //게임시작

            string[,] startGround = (string[,])playGround.Clone();

            String texts = "Select what you want";
            String text1 = "1 => Start Game";
            String text2 = "2 => End Game";
            String text3 = "3 => Setting";

            for (int j = 0; j < texts.Length; j++)
            {
                startGround[4, j + 4] = texts[j].ToString() + " ";
            }
            for (int j = 0; j < text1.Length; j++)
            {
                startGround[7, j + 4] = text1[j].ToString() + " ";
            }
            for (int j = 0; j < text2.Length; j++)
            {
                startGround[8, j + 4] = text2[j].ToString() + " ";
            }
            for (int j = 0; j < text3.Length; j++)
            {
                startGround[9, j + 4] = text3[j].ToString() + " ";
            }
            
            Initialize init = new Initialize();
            init.InitializePlayGround(startGround);

            int startY = 7;
            Console.SetCursorPosition(7, startY);

            
            while (true)
            {
                c = Console.ReadKey(true);
                if (c.Key == ConsoleKey.DownArrow && startY < 9)
                {
                    ++startY;
                    Console.SetCursorPosition(7, startY);
                }
                if(c.Key == ConsoleKey.UpArrow && startY > 7)
                {
                    --startY;
                    Console.SetCursorPosition(7, startY);
                }
                if(c.Key == ConsoleKey.Enter)
                {
                    if(startY == 7)
                    {
                        Console.Clear();
                        break;
                    }else if(startY == 8)
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }
                    else if(startY == 9)
                    {

                    }
                }
            }
        }
        public static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        static void Main(string[] args)
        {
            IntToString(intArr);
            StartGame();
            SetRandom();
            SetCharacter();

                var workPlayGround = OnTimedEvent();
                var workMoveDown = MoveDown();
                var workInput = Input();
                Task.WaitAll(workMoveDown, workInput, workPlayGround);
        }
    }
}

