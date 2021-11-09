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

        static void Boarder(char edgeA, char edgeB, int scale) // dont name it scale (or just make 2 of them lol)
        {
            Console.Write(edgeA);

            for (int xBorder = 0; xBorder < Xlength * scale; xBorder++)
            {
                Console.Write(xLine);
            }

            Console.WriteLine(edgeB);
        }

        static void Colour(char hue)
        {

            //try to make it a switch statement 
            //switch(hue)
            //{
            //    case == '*':
            //            Console.WriteLine("dafdaf");
            //        break;

            //}
        }

        public static void DrawMap()
        {
            Boarder('╔', '╗', 1);

            for (int y = 0; y < Ylength; y++)
            {
                Console.Write(yLine);

                    for (int x = 0; x < Xlength; x++)
                        Console.Write(map[y, x]);

                Console.WriteLine(yLine);
            }

            Boarder('╚', '╝', 1);
        }
        public static void DrawMap(int scale)
        {
            // to scale, is to repeat the same charcater an x amount of times based on the value of scale
            // so scale the range that the map is going to be printed
            // and "scale map"

            // oh shit. so the .Length and Scale should be handled in 2 seporate loops. (well 4 in total for each axis)
            // one that increases the capacity of array, and the other that increases the ammount of characters.

            Boarder('╔', '╗', scale);

            for (int y = 0; y < Ylength; y++)
            {
                for (int i = 0; i < scale; i++)
                {
                    Console.Write(yLine);

                    for (int x = 0; x < Xlength; x++)
                        for (int j = 0; j < scale; j++)
                            Console.Write(map[y, x]);

                    Console.WriteLine(yLine);
                }
            }

            Boarder('╚', '╝', scale);
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