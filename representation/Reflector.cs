using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.representation
{
    class Reflector
    {
        private Dictionary<char, char> map;


        public Reflector(FixedMechanicReflector re)
        {

            map = new Dictionary<char, char>(26);

            string[] pairing = re.Pairing;
            foreach (string pair in pairing)
            {
                char key = pair.ElementAt(0);
                char val = pair.ElementAt(1);
                map.Add(key, val);
                map.Add(val, key);

            }


        }




        public char reflect(char input)
        {
            //pre-req: input must be a valid key
            //may use TryGetValue
            return map[input];



        }


    }
}
