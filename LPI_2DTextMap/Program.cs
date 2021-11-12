using System;
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

    class Program
    {
        static void Main()
        {

            Map.DrawMap();

            Map.DrawMap(2);

            Map.DrawMap(3);

            Map.DrawMap(4);

            Map.DrawMap(5);

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

        static void SetColour(char c)
        {
            switch (c)
            {
                case '^':
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case '*':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case '~':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case '\'':
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
        }

        static void DrawChar(char c)
        {
            SetColour(c);
            Console.Write(c);
        }

        public static void DrawMap()
        {
            void Border(char edgeA, char edgeB)
            {
                DrawChar(edgeA);

                for (int xBorder = 0; xBorder < Xlength; xBorder++)
                {
                    DrawChar(xLine);
                }

                DrawChar(edgeB);
            }

            Border('╔', '╗');
            DrawChar('\n');

            for (y = 0; y < Ylength; y++)
            {
                DrawChar(yLine);

                for (x = 0; x < Xlength; x++)
                    DrawChar(map[y, x]);

                DrawChar(yLine);
                DrawChar('\n');
            }

            Border('╚', '╝');
            DrawChar('\n');
        }

        public static void DrawMap(int scale)  // (int scale = 1)
        {
            // to scale, is to repeat the same charcater an x amount of times based on the value of scale
            // so scale the range that the map is going to be printed
            // and "scale map"

            // .Length and Scale should be handled in 2 seporate loops. (well 4 in total for each axis)
            // one that increases the capacity of array, and the other that increases the ammount of characters.

            Console.WriteLine("Map Scale x" + scale);

            void Border(char edgeA, char edgeB)
            {
                DrawChar(edgeA);

                for (int xBorder = 0; xBorder < Xlength * scale; xBorder++)
                {
                    DrawChar(xLine);
                }

                DrawChar(edgeB);
            }

            Border('╔', '╗');
            DrawChar('\n');

            for (int y = 0; y < Ylength; y++)
                for (int i = 0; i < scale; i++)
                {
                    DrawChar(yLine);

                    for (int x = 0; x < Xlength; x++)
                        for (int j = 0; j < scale; j++)
                            DrawChar(map[y, x]);

                    DrawChar(yLine);
                    DrawChar('\n');
                }

            Border('╚', '╝');
            DrawChar('\n');
        }
    }
}