using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ScrabbleExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            ThreadStart player1Ref = new ThreadStart(CallRun);
            Console.WriteLine("Creating Player one");
            Thread player1 = new Thread(player1Ref);

            ThreadStart player2Ref = new ThreadStart(CallRun);
            Console.WriteLine("Creating Player two");
            Thread player2 = new Thread(player1Ref);

            player1.Start();
            player2.Start();

            Console.ReadLine();
        }

        private static void CallRun()
        {
            GetTheTiles tileGetter = new GetTheTiles();

            tileGetter.run();
        }
    }
}
