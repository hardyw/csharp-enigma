using Enigma.representation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.utility
{
    class Utility
    {

        public static String FileToString(String filePath)
        {

            StringBuilder sb = new StringBuilder();
            using (StreamReader r = new StreamReader(filePath))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    sb.Append(line);
                }


            }
            return sb.ToString();
        }

        /**
         * Get the appropriate offset (always > 0) of the internal rotor core
         * with respect to global 'A' position
         * This offset is influenced by 
         * 	i) the ring setting (which stays the same for a given ciphertext, and 
         * 	ii) the window value (which updates every time the enigma ticks)
         * @param ringSetting
         * @param windowSetting
         * @param slot
         * @return
         */

        public static int GetOffsetRotorInternal(RingSetting ringSetting, WindowSetting windowSetting, int slot)
        {

            //for easy intuition, we call the global 'A' position the sea level

            int dispRingAboveSea;			//displacement of Ring with respect to global 'A' position
            int dispRotorInternalWrtRing;
            int dispRotorInternalAboveSea;	//always > 0, expressed in mod26


            dispRingAboveSea = 'A' - windowSetting.getWindowValue(slot); 	//if window shows 'C', disp = -2
            dispRotorInternalWrtRing = ringSetting.ringOffset(slot); 		//offset = 4 means internal A is locked to ring's E
            dispRotorInternalAboveSea = (dispRingAboveSea + dispRotorInternalWrtRing + 26) % 26;

            return dispRotorInternalAboveSea;
        }

    }
}
