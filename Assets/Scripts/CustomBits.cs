using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menezis {
    public class CustomBits {
        private bool[] bits;

        public CustomBits(int size)
        {
            this.bits = new bool[size];
        }

        public bool GetCustomBit(int index)
        {
            if (index >= 0 && index < bits.Length) {
                return this.bits[index];
            } else {
                throw new Exception("Couldn't get bit: Bit index out of bounds!");
            }
        }

        public void SetCustomBit(int index, bool value)
        {
            if (index >= 0 && index < bits.Length) {
                this.bits[index] = value;
            } else {
                throw new Exception("Couldn't set bit: Bit index out of bounds!");
            }
        }
    }
}
