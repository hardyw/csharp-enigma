using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.representation
{
    class Rotor
    {
        private char[] permutation;
        private char[] reverse;
        private char knocker;

        public Rotor(FixedMechanicRotor rot)
        {
            this.permutation = rot.Permutation.ToUpper().ToCharArray();
            this.knocker = rot.Knocker;

            this.reverse = new char[26];
            for (int i = 0; i < permutation.Length; i++)
            {
                int revIndex = permutation[i] - 'A';
                reverse[revIndex] = (char)('A' + i);
            }

        }

        public char process(char input)
        {
            if(! (input >= 'A' && input <= 'Z')) 
            {
                Console.WriteLine("In ROTOR Invalid Input!");
            }
            int distance = (int)(input - 'A');
            return permutation[distance];
        }

        public char revProcess(char input)
        {
            if (!(input >= 'A' && input <= 'Z'))
            {
                Console.WriteLine("In ROTOR Invalid Input!");
            }
            int distance = (int)(input - 'A');
            return reverse[distance];
        }

        public char getKnocker()
        {
            return knocker;
        }

    }
}
