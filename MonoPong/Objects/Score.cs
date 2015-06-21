using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoPong.Objects
{
    public struct Score
    {
        public int Player1;
        public int Player2;

        public override string ToString()
        {
            return string.Format("{0} : {1}", Player1.ToString(), Player2.ToString());
        }
    }

    public enum ResetReason
    {
        P1Score,
        P2Score,
        P1Win,
        P2Win,
        Meta
    }
}
