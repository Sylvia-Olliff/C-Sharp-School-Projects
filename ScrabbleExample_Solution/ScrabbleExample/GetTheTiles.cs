using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace ScrabbleExample
{
    public class GetTheTiles
    {
        public void run()
        {
            ScrabbleBoard newInstance = ScrabbleBoard.getInstance();

            Console.WriteLine("1st Instance ID: {0}", RuntimeHelpers.GetHashCode(newInstance));

            Console.WriteLine("Tiles Available: \n");

            List<String> setOfTiles = newInstance.getLetterList();

            setOfTiles.ForEach(item => Console.Write(item + ","));

            List<String> playerOneTiles = newInstance.getTiles(7);

            Console.WriteLine("\n\nPlayer Tiles: \n");

            playerOneTiles.ForEach(item => Console.Write(item + ","));

            Console.WriteLine("\n\nGot Tiles");
        }
    }
}
