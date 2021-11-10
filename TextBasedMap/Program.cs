using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextBasedMap
{
    class Program
    {
        static bool gameOver = false;
        static bool buttonPress = false;
        static int numberPressed;
        static bool shownRules = false;
        
        

        static char[,] map = new char[,]
        {
                    
                    {'`', '`', '~', '~', '^', '^', '^', '^', '`', '`', '`', '`', '`', '`', '`', '`', '`', '~', '~', '`', '`', '`', '`', '*', '*', '*', '`', '^', '^', '^'},
                    {'*', '`', '~', '~', '^', '^', '^', '^', '^', '`', '`', '~', '`', '`', '`', '`', '~', '~', '~', '~', '~', '~', '`', '`', '*', '`', '`', '^', '^', '^'},
                    {'*', '*', '`', '~', '~', '^', '^', '^', '^', '`', '~', '~', '`', '`', '`', '`', '~', '~', '*', '*', '~', '~', '~', '`', '`', '`', '^', '^', '^', '*'},
                    {'*', '*', '`', '`', '~', '~', '^', '`', '`', '`', '~', '~', '~', '`', '`', '=', '=', '=', '*', '*', '*', '*', '~', '~', '`', '`', '^', '^', '*', '*'},
                    {'*', '*', '`', '`', '~', '~', '^', '^', '`', '`', '`', '~', '~', '~', '`', '~', '~', '*', '*', '`', '*', '*', '~', '~', '`', '`', '*', '*', '*', '*'},
                    {'*', '`', '`', '~', '~', '~', '~', '^', '^', '^', '`', '`', '~', '`', '`', '~', '~', '*', '*', '`', '*', '=', '=', '=', '`', '*', '*', '*', '*', '*'},
                    {'`', '~', '=', '~', '*', '*', '~', '~', '^', '^', '^', '`', '`', '`', '`', '~', '~', '~', '`', '`', '`', '~', '~', '`', '`', '*', '*', '*', '`', '`'},
                    {'~', '~', '=', '~', '*', '*', '~', '~', '^', '^', '`', '`', '`', '`', '`', '`', '~', '~', '~', '`', '~', '~', '~', '`', '`', '*', '*', '*', '`', '`'},
                    {'~', '~', '=', '*', '*', '*', '*', '=', '=', '`', '`', '^', '^', '^', '`', '`', '`', '~', '~', '~', '~', '~', '`', '`', '`', '`', '`', '`', '`', '`'},
                    {'`', '`', '`', '`', '*', '*', '*', '~', '~', '^', '^', '^', '^', '^', '^', '`', '`', '`', '`', '~', '~', '`', '`', '`', '`', '`', '`', '`', '`', '`'},
                    
                    // legend:
                    // ^ = mountain
                    // = = bridge
                    // ~ = water
                    // ' = plains
                    // * = forest
        };

       

        static void Main(string[] args)
        {
            char[,] map = new char[10, 30];

            while (gameOver == false)
            {
                while (shownRules == false)
                {
                    ShowRules();
                    shownRules = true;
                }

                while (buttonPress == true)
                {
                    DisplayMap(numberPressed);
                    MapLegend(); 
                }
               
               if (Console.KeyAvailable)
               {  
                if (Console.ReadKey(true).Key == ConsoleKey.D1)
                {
                    numberPressed = 1;
                    buttonPress = true;
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.D2)   // for some reason u must press the number in the right section of the cycle??
                {                                                  // example 0 is anything else pressed* 000 etc if u press 1 here: 100, it works, but if u press it 010, or 001, it doesnt work??
                    numberPressed = 2;                             // 200, 002 dont work, but 020 does, same for 003, but not 300, or 030...
                    buttonPress = true; 
                }
                else if (Console.ReadKey(true).Key == ConsoleKey.D3)
                {
                    numberPressed = 3;
                    buttonPress = true; 
                }

                else if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    gameOver = true;
                }
               }
            }
        } 
        static void DisplayMap(int scale) //works!
        {
            if (scale < 1)
            {
                scale = 1;
            }
            if (scale > 3)
            {
                scale = 3;
            }
            if (scale == 1)
            {
                Console.WriteLine();
                Console.WriteLine("+------------------------------+");
            }
            else if (scale == 2)
            {
                Console.WriteLine();
                Console.WriteLine("+------------------------------------------------------------+");
            }
            else if (scale == 3)
            {
                Console.WriteLine();
                Console.WriteLine("+------------------------------------------------------------------------------------------+");
            }
            for (int x = 0; x <= 9; x = x + 1)
            {
                if (x >= 1)
                {
                    Console.WriteLine();
                }
                
                Console.Write(Convert.ToChar(124));
                
                for (int y = 0; y <= 29; y = y + 1)
                {
                    if (map[x, y] == '^')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else if (map[x, y] == '`')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else if (map[x, y] == '~')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }
                    else if (map[x, y] == '=')
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    }
                    else if (map[x, y] == '*')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }

                    if (scale == 1)
                    {
                        Console.Write(map[x, y]);
                    }

                    if (scale == 2)
                    {
                        Console.Write(map[x, y]);
                        Console.Write(map[x, y]);
                    }

                    if (scale == 3)
                    {
                        Console.Write(map[x, y]);
                        Console.Write(map[x, y]);
                        Console.Write(map[x, y]);
                    }
                    Console.ResetColor();
                }
                Console.Write(Convert.ToChar(124));
                if (scale >= 2)
                {
                    Console.WriteLine();
                    Console.Write(Convert.ToChar(124));
                    for (int y = 0; y <= 29; y = y + 1)
                    {
                        if (map[x, y] == '^')
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else if (map[x, y] == '`')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                        else if (map[x, y] == '~')
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                        else if (map[x, y] == '=')
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        }
                        else if (map[x, y] == '*')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }

                        if (scale == 2)
                        {
                            Console.Write(map[x, y]);
                            Console.Write(map[x, y]);
                        }
                        if (scale == 3)
                        {
                            Console.Write(map[x, y]);
                            Console.Write(map[x, y]);
                            Console.Write(map[x, y]);
                        }
                    }
                    Console.ResetColor();
                    Console.Write(Convert.ToChar(124));
                }
                if (scale >= 3)
                {
                    Console.WriteLine();
                    Console.Write(Convert.ToChar(124));
                    for (int y = 0; y <= 29; y = y + 1)
                    {
                        if (map[x, y] == '^')
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                        }
                        else if (map[x, y] == '`')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                        else if (map[x, y] == '~')
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                        }
                        else if (map[x, y] == '=')
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        }
                        else if (map[x, y] == '*')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                        if (scale == 3)
                        {
                            Console.Write(map[x, y]);
                            Console.Write(map[x, y]);
                            Console.Write(map[x, y]);
                        }
                    }
                    Console.ResetColor();
                    Console.Write(Convert.ToChar(124));
                }
                
                if (x >= 9)
                {
                    buttonPress = false;
                }
            }
            Console.WriteLine();
            if (scale == 1)
            {
                Console.WriteLine("+------------------------------+");
            }
            else if (scale == 2)
            {
                Console.WriteLine("+------------------------------------------------------------+");
            }
            else if (scale == 3)
            {
                Console.WriteLine("+------------------------------------------------------------------------------------------+");
            }
        }

        static void MapLegend()
        {
            Console.WriteLine("");
            Console.WriteLine("  Legend:");
            Console.WriteLine("==================");
            Console.WriteLine("// ^ = mountain");
            Console.WriteLine("// = = bridge");
            Console.WriteLine("// ~ = water");
            Console.WriteLine("// ' = plains");
            Console.WriteLine("// * = forest");
            Console.WriteLine("");
        }

        static void ShowRules()
        {
            Console.WriteLine();
            Console.WriteLine("  Controls:  ");
            Console.WriteLine("/////////////");
            Console.WriteLine(" Press 1 --> Scale 1");
            Console.WriteLine(" Press 2 twice --> Scale 2");
            Console.WriteLine(" Press 3 thrice --> Scale 3");
            Console.WriteLine(" Press esc x4 --> Quit Game");
            Console.WriteLine();

        }
        
    } 

}
