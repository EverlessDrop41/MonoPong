using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MonoPong.Objects
{
    public class Ball : GameObject
    {
        public const int MAX_SPEED = 20;

        public Score score;
        
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

            if (Direction.X > MAX_SPEED)
            {
                Direction.X = MAX_SPEED;
            }

            if (Direction.Y > MAX_SPEED)
            {
                Direction.Y = MAX_SPEED;
            }

            foreach (GameObject obj in toCollideWith) {
                if (this.GetRect().Intersects(obj.GetRect())) {
                    /*
                    if (this.Position.Y + Size.Y > obj.Position.Y + obj.Size.Y/2)
                    {
                        Direction.Y = Math.Abs(Direction.Y);
                    }
                    else
                    {
                        Direction.Y = Math.Abs(Direction.Y) * -1;
                    }*/
                    int x = rand.Next(0, 100);
                    this.Direction.Y *= (x < 50 ? 1 : -1); //Randomize direction
                    this.Direction *= -1.01f; //TODO: Improve this collision
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
                ResetBall(graphics.GraphicsDevice.Viewport.Bounds, ResetReason.P2Score);
                Console.WriteLine("Left Out");
            }

            if (this.Position.X + this.Size.X >= graphics.GraphicsDevice.Viewport.Bounds.Width)
            {
                //Hit Right bound
                ResetBall(graphics.GraphicsDevice.Viewport.Bounds, ResetReason.P1Score);
                Console.WriteLine("Right Out");
            }

            oldKBState = newKBState;
            base.Update(time);
        }

        public void ResetBall(Rectangle Bounds, ResetReason reason)
        {
            if (reason == ResetReason.P1Score) score.Player1 += 1;
            if (reason == ResetReason.P2Score) score.Player2 += 1;

            Direction = new Vector2();
            Position = new Vector2(Bounds.Width / 2, Bounds.Height / 2);

            Console.WriteLine(score.ToString());
        }
    }
}
