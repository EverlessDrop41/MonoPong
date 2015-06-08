using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MonoPong.Objects
{
    class Bat : GameObject
    {
        public Keys UpKey = Keys.Up;
        public Keys DownKey = Keys.Down;

        public float Speed = 5;

        public Bat(Texture2D texture) : base(texture) { }

        public Bat(Texture2D texture, Rectangle Rect) : base(texture, Rect) { }

        public Bat (Keys _UpKey, Keys _DownKey, Texture2D texture) : base(texture)
        {
            UpKey = _UpKey;
            DownKey = _DownKey;
        }

        public Bat(Keys _UpKey, Keys _DownKey, Texture2D texture, Rectangle Rect) : base(texture, Rect)
        {
            UpKey = _UpKey;
            DownKey = _DownKey;
        }
        
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

        public void Update(GameTime time, GraphicsDeviceManager graphics)
        {
            KeyboardState newKBState = Keyboard.GetState();

            if (this.Position.Y > 0)
            {
                if (newKBState.IsKeyDown(UpKey))
                {
                    this.Position.Y -= Speed;
                }
            }

            if (this.Position.Y + this.Size.Y < graphics.GraphicsDevice.Viewport.Bounds.Height)
            {
                if (newKBState.IsKeyDown(DownKey))
                {
                    this.Position.Y += Speed;
                }
            }

            if (this.Position.Y + this.Size.Y > graphics.GraphicsDevice.Viewport.Bounds.Height)
            {
                this.Position.Y = 10;
            }

            oldKBState = newKBState;

            base.Update(time);
        }
    }
}
