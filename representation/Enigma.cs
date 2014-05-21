using Enigma.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.representation
{
    class Enigma
    {
        //Constants to define the rotors
        private const int LEFT = 0;
        private const int MID = 1;
        private const int RIGHT = 2;

        private Rotor[] rotors = new Rotor[3];
        private char[] rotorKnockers;

        private Reflector reflector;
        private Plugboard plugboard;
        private WindowSetting windowSetting;
        private RingSetting ringSetting;


        public Enigma(Rotor[] rots, Reflector re, Plugboard plug, RingSetting rings, WindowSetting initWindow)
        {

            //Following WW2 Convention, it is specified Left-Mid-Right
            this.rotors = rots;
            this.rotorKnockers = new char[] { rotors[LEFT].getKnocker(), rotors[MID].getKnocker(), rotors[RIGHT].getKnocker() };

            this.reflector = re;
            this.plugboard = plug;
            this.windowSetting = initWindow;
            this.ringSetting = rings;
        }


        private void tick()
        {
            windowSetting.tick(rotorKnockers);
        }


        public string encryptString(string input)
        {
            StringBuilder sb = new StringBuilder();
            char[] plain = input.Trim().ToUpper().ToCharArray();

            foreach (char c in plain)
            {
                if (!Char.IsWhiteSpace(c))
                {

                    if (!Char.IsLetter(c))
                        Console.WriteLine("INVALID INPUT");

                    //Following WW2 Convention, rotors are specified Left-Mid-Right
                    //But the actual encrypt/decrypt happens from Right->Mid->Left

                    //result holds the intermediary values as well as the final output
                    char result;

                    /* ***********************
                     * PLUGBOARD TRANSLATION
                     * ***********************/

                    result = plugboard.translate(c);


                    /* ***********************
                     * ROTOR PROCESSING
                     * ***********************/

                    //TICK BEFORE ENCRYPT
                    tick();

                    // variables we will keep using during rotor stages
                    int offsetRotInternalAboveSea;	//always > 0, expressed in mod26
                    int inputValueRotorInternal;	//always > 0, expressed in mod26


                    foreach (int rot in new int[] { RIGHT, MID, LEFT })
                    {
                        offsetRotInternalAboveSea = Utility.GetOffsetRotorInternal(ringSetting, windowSetting, rot);
                        inputValueRotorInternal = ((result - 'A') - offsetRotInternalAboveSea + 26) % 26;

                        char currentRot_internalInput = (char)('A' + inputValueRotorInternal);
                        char currentRot_internalOutput = rotors[rot].process(currentRot_internalInput);
                        char currentRot_sealevelOutput = (char)('A' +
                                ((currentRot_internalOutput - 'A') + offsetRotInternalAboveSea) % 26);
                        result = currentRot_sealevelOutput;

                    }

                    /* ***********************
                     * REFLECTOR PROCESSING
                     * ***********************/
                    result = reflector.reflect(result);




                    /* ***********************
				     * ROTOR IN REVERSE
				     * ***********************/

                    foreach (int rot in new int[] { LEFT, MID, RIGHT })
                    {

                        offsetRotInternalAboveSea = Utility.GetOffsetRotorInternal(ringSetting, windowSetting, rot);
                        inputValueRotorInternal = ((result - 'A') - offsetRotInternalAboveSea + 26) % 26;

                        char currentRot_internalInput = (char)('A' + inputValueRotorInternal);
                        char currentRot_internalOutput = rotors[rot].revProcess(currentRot_internalInput);
                        char currentRot_sealevelOutput = (char)('A' +
                                ((currentRot_internalOutput - 'A') + offsetRotInternalAboveSea) % 26);
                        result = currentRot_sealevelOutput;


                    }


                    /* ***********************
                     * PLUGBOARD TRANSLATION
                     * ***********************/

                    char final_out = plugboard.translate(result);
                    sb.Append(final_out);


                }
            }

            return sb.ToString();
        }

    }
}
