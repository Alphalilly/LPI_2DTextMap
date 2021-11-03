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


        static void Main()
        {

            DrawMap(0);

            Console.ReadKey(true);
        }

        static void DrawMap(int scale)
        {
            int border;
            int x;
            int y;

            Console.Write("╔");

            for (border = 0; border < map.GetLength(1); border++)
            {
                Console.Write("═");
            }

            Console.WriteLine("╗");

            for (y = 0; y < map.GetLength(1); y++)
            {
                Console.Write("║");

                for (x = 0; x < map.GetLength(1); x++)
                {
                    Console.Write(map[y, x]);
                }

                Console.WriteLine("║");
            }

            Console.Write("╚");

            for (border = 0; border < map.GetLength(1); border++)
            {
                Console.Write("═");
            }

            Console.WriteLine("╝");
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