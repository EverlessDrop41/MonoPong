using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoPong.Objects
{
    public class Bullet : GameObject
    {
        public Bullet(Rectangle rect, int Speed)
            : base(rect)
        {
            speed = Speed;   
        }

        public Bullet(Vector2 Position, Vector2 Size, int Speed)
            : base(Position, Size)
        {
            speed = Speed;
        }

        int speed;

        public override void Update(GameTime time)
        {
            this.Position.X += speed;
            base.Update(time);
        }
    }
}
