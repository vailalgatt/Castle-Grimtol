using System;
using CastleGrimtol.Game;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            bool playing = true;            

            while(playing){
            Console.WriteLine("Where Do you want to go?: ");
            string input = Console.ReadLine();

            string output = something.something(input);

            Console.WriteLine(output);

            }
        }
    }
}
