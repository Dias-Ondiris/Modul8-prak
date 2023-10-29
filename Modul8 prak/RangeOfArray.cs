using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul8_prak
{
    public class RangeOfArray
    {
        private int[] array;
        private int lowerBound;
        private int upperBound;

        public RangeOfArray(int lowerBound, int upperBound)
        {
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
            array = new int[upperBound - lowerBound + 1];
        }

        public int this[int index]
        {
            get
            {
                if (index < lowerBound || index > upperBound)
                {
                    throw new IndexOutOfRangeException("Индекс за пределами диапазона.");
                }
                return array[index - lowerBound];
            }
            set
            {
                if (index < lowerBound || index > upperBound)
                {
                    throw new IndexOutOfRangeException("Индекс за пределами диапазона.");
                }
                array[index - lowerBound] = value;
            }
        }
    } 
}
