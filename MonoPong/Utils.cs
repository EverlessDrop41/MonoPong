using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoPong
{
    class Utils
    {
        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
