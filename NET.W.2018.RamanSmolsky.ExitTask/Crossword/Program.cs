using System;
using System.Collections.Generic;
using static Crossword.Crossword;

namespace Crossword
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> wordsHorisontal = new List<string>
            {
                "перелом",
                "подвывих",
                "закрытый",
                "ушиб"
            };

            // horisontally placed words places (coordinates) inside crossword
            List<Position> wordHorisontalCoordinates = new List<Position>
            {
                new Position(2, 0),
                new Position(3, 4),
                new Position(0, 7),
                new Position(2, 9)
            };

            List<string> wordsVertical = new List<string>
            {
                "шина",
                "вывих",
                "открытый"
            };

            // vertically placed words places (coordinates) inside crossword
            List<Position> wordsVerticalCoordinates = new List<Position>
            {
                new Position(1, 4),
                new Position(4, 6),
                new Position(7, 0)
            };

            char[,] crossword = new char[11, 11];

            Crossword cr = new Crossword(crossword, wordsHorisontal, wordHorisontalCoordinates, wordsVertical, wordsVerticalCoordinates);

            cr.Fill();

            cr.Show();

            Console.ReadLine();
        }
    }
}