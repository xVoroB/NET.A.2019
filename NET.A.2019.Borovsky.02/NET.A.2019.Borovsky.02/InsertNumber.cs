using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.A._2019.Borovsky._02
{
    class InsertNumber
    {
        public int InsNum(int a, int b, int i, int j)
        {
            int mask = j - i + 1;
            mask = (int)Math.Pow(2, (double)mask) - 1;      // Creating mask
            int num = (b & mask) << i;                      // Moving start to i

            return (a | num);                               // Calculating
        }
    }
}
