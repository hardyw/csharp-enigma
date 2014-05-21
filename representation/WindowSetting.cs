using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.representation
{
    class WindowSetting
    {
        private const int LEFT = 0;
        private const int MID = 1;
        private const int RIGHT = 2;

        //the window display that our enigma operator sees
        private char[] windows = new char[3];

        //to model the mechanical idiosyncracy - double-stepping
        private bool[] justStepped = { false, false, false };


        public WindowSetting(char l, char m, char r)
        {
            this.windows[LEFT] = l;
            this.windows[MID] = m;
            this.windows[RIGHT] = r;
        }

        public char getWindowValue(int slot)
        {
            return windows[slot];
        }

        public void tick(char[] knockers)
        {
            bool carryToMid = false;
            bool carryToLeft = false;

            /* ***********************
             * TICK RIGHT ROTOR
             * ***********************/

            windows[RIGHT] = (char)('A' + ((windows[RIGHT] - 'A' + 1) % 26));
            if (windows[RIGHT] == knockers[RIGHT])
            {
                carryToMid = true;
            }



            /* ***********************
             * TICK MID ROTOR (if any)
             * ***********************/

            if (carryToMid)
            {
                windows[MID] = (char)('A' + ((windows[MID] - 'A' + 1) % 26));
                if (windows[MID] == knockers[MID]) carryToLeft = true;
                justStepped[MID] = true;
            }
            else if (justStepped[MID])
            {

                //has the potential to double-step
                //Double stepping occurs if MID's nextValue = knockers[MID]
                justStepped[MID] = false;
                char nextValue = (char)('A' + ((windows[MID] - 'A' + 1) % 26));
                if (nextValue == knockers[MID])
                {
                    windows[MID] = (char)('A' + ((windows[MID] - 'A' + 1) % 26));
                    if (windows[MID] == knockers[MID]) carryToLeft = true;
                }
            }



            /* ***********************
             * TICK LEFT ROTOR (if any)
             * ***********************/

            if (carryToLeft)
            {
                windows[LEFT] = (char)('A' + ((windows[LEFT] - 'A' + 1) % 26));
                //justStepped[LEFT] = true; //TODO confirm whether left can also double-step 
            }
            else if (justStepped[LEFT])
            {
                justStepped[LEFT] = false;
                windows[LEFT] = (char)('A' + ((windows[LEFT] - 'A' + 1) % 26));
            }




        }

    }
}
