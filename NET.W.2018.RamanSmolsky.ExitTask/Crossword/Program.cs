using System;
using System.Collections.Generic;

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

            FillCrosswordWithPlaceHolders(crossword);

            FillHorisontallyPlacedWords(wordsHorisontal, wordHorisontalCoordinates, crossword);

            FillVerticallyPlacedWords(wordsVertical, wordsVerticalCoordinates, crossword);

            Show(crossword);

            Console.ReadLine();
        }

        private static void FillCrosswordWithPlaceHolders(char[,] crossword)
        {
            // currently assuming only square-formed crosswords (e.g. 11x11)
            int length = crossword.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    crossword[i, j] = '.';
                }
            }
        }

        private static void FillHorisontallyPlacedWords(List<string> wordsHorisontal, List<Position> wordHorisontalCoordinates, char[,] crossword)
        {
            for (int i = 0; i < wordsHorisontal.Count; i++)
            {
                char[] charsInWord = wordsHorisontal[i].ToCharArray();

                // to fill the line N with symbols from the word
                int line = wordHorisontalCoordinates[i].Y;

                // with offset
                int offset = wordHorisontalCoordinates[i].X;

                for (int j = 0; j < charsInWord.Length; j++)
                {
                    crossword[line, offset + j] = charsInWord[j];
                }
            }
        }

        private static void FillVerticallyPlacedWords(List<string> wordsVertical, List<Position> wordsVerticalCoordinates, char[,] crossword)
        {
            for (int i = 0; i < wordsVertical.Count; i++)
            {
                char[] charsInWord = wordsVertical[i].ToCharArray();

                // to fill the column N with symbols from the word
                int column = wordsVerticalCoordinates[i].X;

                // with offset
                int offset = wordsVerticalCoordinates[i].Y;

                for (int j = 0; j < charsInWord.Length; j++)
                {
                    crossword[offset + j, column] = charsInWord[j];
                }
            }
        }

        private static void Show(char[,] crossword)
        {
            int length = crossword.GetLength(0);

            // show the crossword (assuming square-formed crossword)
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(crossword[i, j]);
                }

                Console.WriteLine();
            }
        }

        public struct Position
        {
            public int X;
            public int Y;

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }
        }        
    }
}