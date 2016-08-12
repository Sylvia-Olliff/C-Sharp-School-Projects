using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ScrabbleExample
{
    public class ScrabbleBoard
    {
        private static ScrabbleBoard firstInstance = null;
        private static object Lock = new Object();

        private static String[] scrabbleLetters = {"a", "a", "a", "a", "a", "a", "a", "a", "a",
            "b", "b", "c", "c", "d", "d", "d", "d", "e", "e", "e", "e", "e",
            "e", "e", "e", "e", "e", "e", "e", "f", "f", "g", "g", "g", "h",
            "h", "i", "i", "i", "i", "i", "i", "i", "i", "i", "j", "k", "l",
            "l", "l", "l", "m", "m", "n", "n", "n", "n", "n", "n", "o", "o",
            "o", "o", "o", "o", "o", "o", "p", "p", "q", "r", "r", "r", "r",
            "r", "r", "s", "s", "s", "s", "t", "t", "t", "t", "t", "t", "u",
            "u", "u", "u", "v", "v", "w", "w", "x", "y", "y", "z"};

        private static Random rng = new Random();

        private static List<String> letterList; 

        private static Boolean firstThread = true;

        private ScrabbleBoard() 
        {
            scrabbleLetters = scrabbleLetters.OrderBy(x => rng.Next()).ToArray();
            letterList = new List<String>(scrabbleLetters);
        }

        public static ScrabbleBoard getInstance()
        {
            if (null == firstInstance)
            {
                if (firstThread)
                {
                    firstThread = false;

                    try
                    {
                        Thread.Sleep(1000);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }

                lock (Lock)
                {
                    if (firstInstance == null)
                    {
                        firstInstance = new ScrabbleBoard();
                    }
                }
            }

            return firstInstance;
        }

        public List<String> getLetterList()
        {
            return letterList;
        }

        public List<String> getTiles(int howManyTiles)
        {
            List<String> tilesToSend = new List<string>();
            String temp = "";
            for (int i = 0; i < howManyTiles; i++)
            {
                temp = letterList.First();
                tilesToSend.Add(temp);
                letterList.Remove(temp);
            }

            return tilesToSend;
        }
    }
}
