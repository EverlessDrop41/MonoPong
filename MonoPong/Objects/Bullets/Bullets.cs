using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using MonoPong.Objects;

namespace MonoPong.Objects
{
    class Bullets : List<Bullet>
    {
        public void CreateBullet(Rectangle rect, bool goingRight)
        {
            int dir = 5 * (goingRight ? 1 : -1);
            this.Add(new Bullet(rect, dir ));
        }
    }
}
