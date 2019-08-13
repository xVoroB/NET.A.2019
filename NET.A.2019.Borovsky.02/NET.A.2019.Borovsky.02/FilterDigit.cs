using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.A._2019.Borovsky._02
{
    class FilterDigit
    {
        public List<int> FilDig(List<int> list)
        {
            int number = list[0];                                                   // Needed digit
            list.RemoveAt(0);                                                       // We don't need it anymore in our list

            List<int> result = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                while (list[i] > 0)
                {
                    if ((number == list[i] % 10) || (number == list[i] / 10))       // Checking if there is our digit in number
                    {
                        result.Add(list[i]);
                        break;
                    }
                    list[i] /= 10;                                                  // Cutting the number
                }
            }

            return result;
        }
    }
}
