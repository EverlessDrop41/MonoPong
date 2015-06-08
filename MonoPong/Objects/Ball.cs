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

            if (newKBState.IsKeyDown(Keys.Space) != oldKBState.IsKeyDown(Keys.Space))
            {
                Direction = new Vector2(3, 1);
                Console.WriteLine("Launch!");
            }

            foreach (GameObject obj in toCollideWith) {
                if (this.GetRect().Intersects(obj.GetRect())) {
                    this.Direction *= -1;
                }
            }

            this.Position += Direction;

            if (this.Position.Y <= 0)
            {
                //Hit Upper Bound
                Direction *= -1;
            }

            if (this.Position.Y + this.Size.Y >= graphics.GraphicsDevice.Viewport.Bounds.Height)
            {
                //Hit Lower bound
                Direction *= -1;
            }

            if (this.Position.X <= 0)
            {
                //Hit Left Bound
                Direction *= -1;
            }

            if (this.Position.X + this.Size.X >= graphics.GraphicsDevice.Viewport.Bounds.Width)
            {
                //Hit Right bound
                Direction *= -1;
                Console.WriteLine("Right Out");
            }

            oldKBState = newKBState;
            base.Update(time);
        }
    }
}
