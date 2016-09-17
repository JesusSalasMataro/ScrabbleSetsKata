using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScrabbleSetsKata;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class Given_An_InputTilesString
    {
        private static Dictionary<char, int> _defaultTileSet;

        [TestInitialize]
        public void Init()
        {
            Scrabble scrabble = new Scrabble();
            _defaultTileSet = scrabble.InitScrabbleBag();
        }

        [TestMethod]
        public void When_OneTileRemoved_Then_AddToOutput()
        {
            // ARRANGE
            string tileSet = "A";
            Scrabble scrabble = new Scrabble();
            Dictionary<char, int> expectedOutput = scrabble.DecrementTileQuantity('A', 1, _defaultTileSet);

            // ACT
            Dictionary<char, int> actualOutput = scrabble.GetOutputTileSet(tileSet);

            // ASSERT
            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void When_SeveralTilesRemoved_Then_AddToOutput()
        {
            // ARRANGE
            string tileSet = "ABCAA";
            Scrabble scrabble = new Scrabble();
            Dictionary<char, int> expectedOutput = scrabble.DecrementTileQuantity('A', 1, _defaultTileSet);
            expectedOutput = scrabble.DecrementTileQuantity('B', 1, _defaultTileSet);
            expectedOutput = scrabble.DecrementTileQuantity('C', 1, _defaultTileSet);
            expectedOutput = scrabble.DecrementTileQuantity('A', 1, _defaultTileSet);
            expectedOutput = scrabble.DecrementTileQuantity('A', 1, _defaultTileSet);

            // ACT
            Dictionary<char, int> actualOutput = scrabble.GetOutputTileSet(tileSet);

            // ASSERT
            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void When_TooManyTilesRemoved_Then_ThrowException()
        {
            // ARRANGE
            string tileSet = "QQ";
            Scrabble scrabble = new Scrabble();

            // ACT
            Dictionary<char, int> actualOutput = scrabble.GetOutputTileSet(tileSet);

            // ASSERT

        }

        [TestMethod]
        public void When_OutputDictionaryCreated_PrintCorrectOutput()
        {
            // ARRANGE
            Scrabble scrabble = new Scrabble();

            // ACT
            Dictionary<char, int> tileSetDictionary = scrabble.GetOutputTileSet("AEERTYOXMCNB_S");

            List<string> actualOutput = scrabble.GetOutputTilesString(tileSetDictionary);
            List<string> expectedOutput = new List<string> {
			    "10: E",
			    "9: I",
			    "8: A",
			    "7: O",
			    "5: N, R, T",
			    "4: D, L, U",
			    "3: G, S",
			    "2: F, H, P, V, W",
			    "1: B, C, J, K, M, Q, Y, Z, _",
			    "0: X"            
            };

            // ASSERT
            CollectionAssert.AreEqual(expectedOutput, actualOutput);
        }

    }
}
