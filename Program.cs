using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Enigma.utility;
using Enigma.representation;

namespace Enigma
{
    class Program
    {
        static void Main(string[] args)
        {


            Rotor rL = new Rotor(FixedMechanicRotor.ROTOR_II); 	//II has notch F
            Rotor rM = new Rotor(FixedMechanicRotor.ROTOR_IV);	//IV has notch K
            Rotor rR = new Rotor(FixedMechanicRotor.ROTOR_V);	//V  has notch A

            //Following WW2 Convention, it is Left-Mid-Right e.g. II IV V
            Rotor[] rotors = { rL, rM, rR };


            Reflector re = new Reflector(FixedMechanicReflector.REFLECTOR_B);
            Plugboard plug = new Plugboard(new String[] {
				"AV", "BS", "CG", "DL", "FU", "HZ", "IN", "KM", "OW", "RX"}); //Barbarosa
            WindowSetting initialSetting = new WindowSetting('B', 'L', 'A');
            RingSetting ringPositions = new RingSetting(2, 21, 12);



            //an example of naming hassle because Enigma is both namespace and class
            Enigma.representation.Enigma enigma = new Enigma.representation.Enigma(rotors, re, plug, ringPositions, initialSetting);



            string myfile = "C:\\Users\\ToshiW\\Documents\\Visual Studio 2012\\Projects\\Enigma\\Enigma\\Resources\\BarbarosaCiphertext.txt";
            string input = Utility.FileToString(myfile);
            //Console.WriteLine(readResult);
            //Console.ReadLine();

            //Let Enigma do its thing
            string result = enigma.encryptString(input);

            Console.WriteLine(result);
            Console.ReadLine();

      

        }
    }
}
