using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MonoPong.Objects;

namespace MonoPong.Objects
{
    class BulletList : List<Bullet>
    {
        public Texture2D Texture;

        public BulletList() : base()
        { 
            //UMMM
        }

        public BulletList(Texture2D texture)
            : base()
        {
            Texture = texture;
        }

        public void CreateBullet(Vector2 position, bool goingRight)
        {
            Rectangle rect = new Rectangle(new Point((int)position.X, (int)position.Y), new Point(15, 15));
            CreateBullet(rect, goingRight);
        }

        public void CreateBullet(Vector2 Position, Vector2 Size, bool goingRight)
        {
            int dir = 5 * (goingRight ? 1 : -1);
            Rectangle rect = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            Bullet bull = new Bullet(rect, dir);
            bull.texture = Texture;
            this.Add(bull);
        }

        public void CreateBullet(Rectangle rect, bool goingRight)
        {
            int dir = 5 * (goingRight ? 1 : -1);
            Bullet bull = new Bullet(rect, dir);
            bull.texture = Texture;
            this.Add(bull);
        }
    }
}
