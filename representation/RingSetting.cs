using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma.representation
{
    class RingSetting
    {

        private const int LEFT = 0;
        private const int MID = 1;
        private const int RIGHT = 2;


        private int[] rings = new int[3];

          


        public RingSetting(int l, int m, int r)
        {


            this.rings[LEFT] = l;
            this.rings[MID] = m;
            this.rings[RIGHT] = r;


        }


        //If the ring setting is E (or 05), then offset from 'A' is +4
        public int ringOffset(int slot)
        {
            return rings[slot] - 1;
        }



    }
}
