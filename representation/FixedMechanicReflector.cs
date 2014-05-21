using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.representation
{
    public class FixedMechanicReflector
    {
        public static readonly FixedMechanicReflector REFLECTOR_B = new FixedMechanicReflector(
            new string[] {
					"AY", "BR", "CU", "DH", "EQ", "FS", "GL", "IP", "JX", "KN", "MO", "TZ", "VW"});

        public static readonly FixedMechanicReflector REFLECTOR_C = new FixedMechanicReflector(
            new string[] {
					"AF", "BV", "CP", "DJ", "EI", "GO", "HY", "KR", "LZ", "MX", "NW", "TQ", "SU"});

        public static readonly FixedMechanicReflector REFLECTOR_A = new FixedMechanicReflector(
            new string[] {
					"AE", "BJ", "CM", "DZ", "FL", "GY", "HX", "IV", "KW", "NR", "OQ", "PU", "ST"});



        public static IEnumerable<FixedMechanicReflector> Values
        {
            get
            {
                yield return REFLECTOR_B;
                yield return REFLECTOR_C;
                yield return REFLECTOR_A;
            }
        }


        private readonly string[] _pairing;

        FixedMechanicReflector(string[] pairing)
        {
            this._pairing = pairing;
        }
	   
        public string[] Pairing { get { return _pairing; } }
	     
    };




}

    

    

