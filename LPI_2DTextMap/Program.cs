﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Diagnostics.Trace;  //this is weird

namespace LPI_2DTextMap
{
    /* Project - C#: 2D Text-Based RPG Map (Multi-Dimensional Arrays):
  
      * Code a C# program that displays a 2D text-based RPG map. *
     
        + Functional Specifications:
            - displays 2D text-based RPG map
            - scales
            - has a border (border does not scale)

        + Technical Specifications:
            - DisplayMap() displays an RPG map by displaying each tile as a single character.
            - Draw each map tile using a single character
            - DisplayMap(int scale) = same; but display each tile scaled, as a grid of characters.
            - If scale = 3, then draw each map tile using 3x3 characters
            - all DisplayMap() methods should display a map border using extended ASCII characters.

        + Extra Mile Suggestions:
            - make a better map
            - implement methods to show a map legend
            - implement color
            - different color for every tile
            - different color for same tiles (white and grey for mountains perhaps)
            - put a player on the map
            - make the player move
            - etc.
     */

    //https://blob.jacobsdata.com/software-alchemy/entry2/visual-studio-2019-hotkey-snippet-cheat-sheet.pdf#:~:text=Visual%20Studio%202019%20Hotkey%20and%20Code%20Snippet%20Cheat,F10%20F11%20Step%20into%20Ctrl%2BF10%20Run%20to%20cursor
    class Program
    {
        static void Main()
        {

            Map.DrawMap();

            Map.DrawMap(2);

            Console.ReadKey(true);
        }

    }

    class Map
    {
        static char[,] map = new char[,]
        {
            {'^','^','^','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'^','^','\'','\'','\'','\'','*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','~','~','~','\'','\'','\''},
            {'^','^','\'','\'','\'','*','*','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\''},
            {'^','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','~','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','\'','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','^','^','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','\'','~','~','~','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','^','^','^','^','\'','\'','\''},
            {'\'','\'','\'','\'','\'','\'','\'','~','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
            {'\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\'','\''},
        };

        static int Ylength = map.GetLength(0); // gets the length of the 0th dimention in map[,]
        static int Xlength = map.GetLength(1); // gets the length of the 1st dimention in map[,]
        static char xLine = '═';
        static char yLine = '║';
        static int y;
        static int x;

        static void Colour()
        {

            //try to make it a switch statement 
            //switch(hue)
            //{
            //    case == '*':
            //            Console.WriteLine("dafdaf");
            //        break;

            //}


            switch(map[y, x])
            {
                case '^':
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                }
                case '*':
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                }
                case '~':
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                }
                case '"':
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                }
                default:
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }
            }

            //if (map[y, x] == '^')
            //{
            //    Console.ForegroundColor = ConsoleColor.Cyan;
            //}
            //else if (map[y, x] == '*')
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;
            //}
            //else if (map[y, x] == '~')
            //{
            //    Console.ForegroundColor = ConsoleColor.Blue;
            //}
            //else if (map[y, x] == '\'')
            //{
            //    Console.ForegroundColor = ConsoleColor.Gray;
            //}
        }

        public static void DrawMap()
        {
            void Boarder(char edgeA, char edgeB)
            {
                Console.Write(edgeA);

                for (int xBorder = 0; xBorder < Xlength; xBorder++)
                {
                    Console.Write(xLine);
                }

                Console.WriteLine(edgeB);
            }

            Boarder('╔', '╗');

            for (y = 0; y < Ylength; y++)
            {
                Console.Write(yLine);

                for (x = 0; x < Xlength; x++)
                {
                    Colour();
                    Console.Write(map[y, x]);
                }      

                Console.WriteLine(yLine);
            }

            Boarder('╚', '╝');
        }
        public static void DrawMap(int scale)
        {
            // to scale, is to repeat the same charcater an x amount of times based on the value of scale
            // so scale the range that the map is going to be printed
            // and "scale map"

            // oh shit. so the .Length and Scale should be handled in 2 seporate loops. (well 4 in total for each axis)
            // one that increases the capacity of array, and the other that increases the ammount of characters.

            void Boarder(char edgeA, char edgeB)
            {
                Console.Write(edgeA);

                for (int xBorder = 0; xBorder < Xlength * scale; xBorder++)
                {
                    Console.Write(xLine);
                }

                Console.WriteLine(edgeB);
            }

            Boarder('╔', '╗');

            for (int y = 0; y < Ylength; y++)
            {
                for (int i = 0; i < scale; i++)
                {
                    Console.Write(yLine);

                    for (int x = 0; x < Xlength; x++)
                    {
                        for (int j = 0; j < scale; j++)
                        {
                            Console.Write(map[y, x]);
                        }
                    }

                    Console.WriteLine(yLine);
                }
            }

            Boarder('╚', '╝');
        }
    }
}

/* old
//private const char V = 'g'; what?

//char w = '~';
    //char g = ':';
    //char t = '*';
    //char m = '^';

    //{'m','m','m','g','g','g','g','g','g','g','g','g','g','g'},
    //{'m','m','g','g','g','g','t','t','t','g','g','g','g','g'},
    //{'m','g','g','g','t','t','t','t','t','t','g','g','g','g'},
    //{'g','g','g','g','g','g','g','g','g','g','g','g','g','g'},
    //{'g','g','g','g','w','w','w','g','g','g','g','g','g','g'},
    //{'g','g','g','w','w','w','w','w','g','g','g','g','g','g'},
    //{'g','t','t','g','w','w','w','w','w','g','g','g','g','g'},
    //{'t','t','t','g','g','g','w','w','w','g','g','g','g','g'},
    //{'g','g','g','g','g','g','g','w','g','g','g','g','g','g'},
    //{'g','g','g','g','g','g','g','t','t','t','t','g','g','g'},
    //{'g','g','g','g','g','m','m','m','g','g','g','g','g','g'},
    //{'g','g','g','m','m','m','m','m','m','m','m','m','m','g'},


    // 1 pixel = 1 char
    // max 1000 x 1000 pixels
    // min 100 x 100
    // use an image map to decide what goes where?
    // this might be too advanced
*/

//╔═╗
//║ ║
//╚═╝

/*
            char a = 'h';
            void OWO(int d)
            {
                Console.WriteLine(a * d);
            }

            OWO(0);
            */