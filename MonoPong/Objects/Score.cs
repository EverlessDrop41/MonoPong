using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoPong.Objects
{
    struct Score
    {
        public int Player1;
        public int Player2;

        public override string ToString()
        {
            return string.Format("Player 1: {0} - Player 2: {1}", Player1.ToString(), Player2.ToString());
        }
    }

    enum ResetReason
    {
        P1Score,
        P2Score,
        Meta
    }
}
