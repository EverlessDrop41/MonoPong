using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MonoPong.Objects
{
    class Ball : GameObject
    {

        public float Speed = 5;
        public Vector2 Direction = new Vector2();

        public Ball(Rectangle rect) : base(rect) { }

        public override void Start()
        {
            base.Start();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime time)
        {
            try
            {
                spriteBatch.Draw(this.texture, this.GetRect(), Color.White);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            base.Draw(spriteBatch, time);
        }

        KeyboardState oldKBState;

        public void Update(GameTime time, GraphicsDeviceManager graphics, GameObject[] toCollideWith)
        {
            KeyboardState newKBState = Keyboard.GetState();

            Random rand = new Random();

            if (newKBState.IsKeyDown(Keys.Space) && oldKBState.IsKeyUp(Keys.Space))
            {
                int x = rand.Next(3, 5) * (rand.Next(100) >= 50 ? 1 : -1);
                int y = rand.Next(1, 3) * (rand.Next(100) >= 50 ? 1 : -1);
                Direction = new Vector2(x, y);
                Console.WriteLine("Launch!");
            }

            foreach (GameObject obj in toCollideWith) {
                if (this.GetRect().Intersects(obj.GetRect())) {
                    if (this.Position.Y + Size.Y > obj.Position.Y + obj.Size.Y/2)
                    {
                        Direction.Y = Math.Abs(Direction.Y);
                    }
                    else
                    {
                        Direction.Y = Math.Abs(Direction.Y) * -1;
                    }
                    this.Direction.X *= -1; //TODO: Improve this collision
                }
            }

            this.Position += Direction;

            if (this.Position.Y <= 0)
            {
                //Hit Upper Bound
                Direction.Y *= -1;
            }

            if (this.Position.Y + this.Size.Y >= graphics.GraphicsDevice.Viewport.Bounds.Height)
            {
                //Hit Lower bound
                Direction.Y *= -1;
            }

            if (this.Position.X <= 0)
            {
                //Hit Left Bound
                ResetBall(graphics.GraphicsDevice.Viewport.Bounds);
                Console.WriteLine("Left Out");
            }

            if (this.Position.X + this.Size.X >= graphics.GraphicsDevice.Viewport.Bounds.Width)
            {
                //Hit Right bound
                ResetBall(graphics.GraphicsDevice.Viewport.Bounds);
                Console.WriteLine("Right Out");
            }

            oldKBState = newKBState;
            base.Update(time);
        }

        void ResetBall(Rectangle Bounds)
        {
            Direction = new Vector2();
            Position = new Vector2(Bounds.Width / 2, Bounds.Height / 2);
        }
    }
}
