using System;
using System.Collections.Generic;

// TODO: add arguments checking
// TODO: add checking for the internal values of the arrays
// TODO: add constructor which gets not the char[,], but just size
// TODO: add possibility to handle not just square crosswords, but reqtangular also
// TODO: add verification that provided lists are matching the size(s) of the crossword
// TODO: add possibility to change placeholder symbol
// TODO: ? should the lists be fixed (e.g. private setters)
// TODO: ? will another organization of word-position in crossword provide any benefits (e.g. separate item which holds the word and its position (coordinates) and placement (vert, horisont)?
namespace Crossword
{
    public class Crossword
    {
        public Crossword(
            char[,] crossword,
            List<string> wordsHorisontal,
            List<Position> wordsHorisontalCoordinates,
            List<string> wordsVertical,
            List<Position> wordsVerticalCoordinates)
        {
            // TODO: ?need to copy, not just assign
            Table = crossword;

            // TODO: ?need to copy, not just assign
            WordsHorisontal = wordsHorisontal;

            // TODO: ?need to copy, not just assign
            WordsHorisontalCoordinates = wordsHorisontalCoordinates;

            // TODO: ?need to copy, not just assign
            WordsVertical = wordsVertical;

            // TODO: ?need to copy, not just assign
            WordsVerticalCoordinates = wordsVerticalCoordinates;
        }

        public char[,] Table { get; private set; }

        public List<string> WordsHorisontal { get; set; }

        public List<Position> WordsHorisontalCoordinates { get; set; }

        public List<string> WordsVertical { get; set; }

        public List<Position> WordsVerticalCoordinates { get; set; }

        public void Fill()
        {
            FillCrosswordWithPlaceHolders(Table);
            FillVerticallyPlacedWords(WordsVertical, WordsVerticalCoordinates, Table);
            FillHorisontallyPlacedWords(WordsHorisontal, WordsHorisontalCoordinates, Table);
        }

        public void Show()
        {
            int length = Table.GetLength(0);

            // show the crossword (assuming square-formed crossword)
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(Table[i, j]);
                }

                Console.WriteLine();
            }
        }

        private void FillCrosswordWithPlaceHolders(char[,] crossword)
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

        private void FillVerticallyPlacedWords(List<string> wordsVertical, List<Position> wordsVerticalCoordinates, char[,] crossword)
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

        private void FillHorisontallyPlacedWords(List<string> wordsHorisontal, List<Position> wordHorisontalCoordinates, char[,] crossword)
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
    }
}