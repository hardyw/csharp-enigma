using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.representation
{
    class Plugboard
    {
        private Dictionary<char, char> map;

        public Plugboard(string[] pairing)
        {
            //pairing is of format {"AV", "BS", "CG", "DL", "FU", "HZ", "IN", "KM", "OW", "RX"}
            
            //Number of plug pairs are generally less than 26, but we allow 26
            map = new Dictionary<char, char>(26);

            foreach (string pair in pairing)
            {
                char key = pair.ElementAt(0);
                char val = pair.ElementAt(1);
                map.Add(key, val);
                map.Add(val, key);
            }

        }


        /*
	     * If input character is among the swapped pairs, return its paired partner
	     * Otherwise, just return the input itself
	     */
        public char translate(char input)
        {
            if (map.ContainsKey(input))
            {
                return map[input];
            }
            else
            {
                return input;
            }
        }

    }
}
