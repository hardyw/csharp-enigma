using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.representation
{
    class FixedMechanicRotor
    {
        //these are the so-called 'enum'
        public static readonly FixedMechanicRotor ROTOR_I = new FixedMechanicRotor("EKMFLGDQVZNTOWYHXUSPAIBRCJ", 'R');
        public static readonly FixedMechanicRotor ROTOR_II = new FixedMechanicRotor("AJDKSIRUXBLHWTMCQGZNPYFVOE", 'F');
        public static readonly FixedMechanicRotor ROTOR_III = new FixedMechanicRotor("BDFHJLCPRTXVZNYEIWGAKMUSQO", 'W');
        public static readonly FixedMechanicRotor ROTOR_IV = new FixedMechanicRotor("ESOVPZJAYQUIRHXLNFTGKDCMWB", 'K');
        public static readonly FixedMechanicRotor ROTOR_V = new FixedMechanicRotor("VZBRGITYUPSDNHLXAWMJQOFECK", 'A');

        //implement 'Values'
        public static IEnumerable<FixedMechanicRotor> Values
        {
            get
            {
                yield return ROTOR_I;
                yield return ROTOR_II;
                yield return ROTOR_III;
                yield return ROTOR_IV;
                yield return ROTOR_V;
            }
        }

        //fields private readonly
        private readonly string _permutation;
        private readonly char _knocker;

        //constructor private
        private FixedMechanicRotor(string perm, char knock)
        {
            this._permutation = perm;
            this._knocker = knock;
        }

        //public getters
        public string Permutation { get { return _permutation; } }
        public char Knocker { get { return _knocker; } }


    }
}
