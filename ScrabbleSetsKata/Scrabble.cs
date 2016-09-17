using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("UnitTestProject")]
namespace ScrabbleSetsKata
{
    public class Scrabble
    {
        private Dictionary<char, int> _tilesInBag;

        public Scrabble()
        {
            _tilesInBag = InitScrabbleBag();
        }

        public Dictionary<char, int> GetOutputTileSet(string tileSet)
        {
            Dictionary<char, int> tilesInCurrentBag = new Dictionary<char, int>(_tilesInBag);

            for (int i = 0; i < tileSet.Length; i++)
            {
                if (tilesInCurrentBag[(char)tileSet[i]] > 0)
                {
                    tilesInCurrentBag = DecrementTileQuantity((char)tileSet[i], 1, tilesInCurrentBag);
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            return tilesInCurrentBag;
        }

        public List<string> GetOutputTilesString(Dictionary<char, int> tileSetDictionary)
        {
            List<string> output =
                        (from pair in tileSetDictionary
                         orderby pair.Value descending, pair.Key ascending
                         select pair)

                         .GroupBy(p => new { p.Value })
                         .Select(p => string.Join(": ", p.Key.Value, string.Join(", ", p.Select(l => l.Key))))
                         .ToList<string>();

            return output;
        }


        #region "Private methods"

        internal Dictionary<char, int> InitScrabbleBag()
        {
            Dictionary<char, int> tilesInBag = new Dictionary<char, int>();

            tilesInBag.Add('A', 9);
            tilesInBag.Add('B', 2);
            tilesInBag.Add('C', 2);
            tilesInBag.Add('D', 4);
            tilesInBag.Add('E', 12);
            tilesInBag.Add('F', 2);
            tilesInBag.Add('G', 3);
            tilesInBag.Add('H', 2);
            tilesInBag.Add('I', 9);
            tilesInBag.Add('J', 1);
            tilesInBag.Add('K', 1);
            tilesInBag.Add('L', 4);
            tilesInBag.Add('M', 2);
            tilesInBag.Add('N', 6);
            tilesInBag.Add('O', 8);
            tilesInBag.Add('P', 2);
            tilesInBag.Add('Q', 1);
            tilesInBag.Add('R', 6);
            tilesInBag.Add('S', 4);
            tilesInBag.Add('T', 6);
            tilesInBag.Add('U', 4);
            tilesInBag.Add('V', 2);
            tilesInBag.Add('W', 2);
            tilesInBag.Add('X', 1);
            tilesInBag.Add('Y', 2);
            tilesInBag.Add('Z', 1);
            tilesInBag.Add('_', 2);

            return tilesInBag;
        }

        internal Dictionary<char, int> DecrementTileQuantity(char tile, int decrementNumber, Dictionary<char, int> tileSet)
        {
            tileSet[tile] = tileSet[tile] - decrementNumber;
            
            return tileSet;
        }

        #endregion

    }
}
