using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MonoPong.Objects
{
    public enum BatType
    {
        Unset,
        Player1,
        Player2
    }

    class Bat : GameObject
    {
        public Keys UpKey = Keys.Up;
        public Keys DownKey = Keys.Down;
        public Keys FireKey = Keys.RightShift;

        public BatType type = BatType.Unset;

        public float Speed = 5;
        public float bulletOffset = 15;

        public Bat(Rectangle rect) : base(rect) { }

        public Bat(Keys _UpKey, Keys _DownKey, Keys _FireKey, Rectangle rect) : base(rect)
        {
            UpKey = _UpKey;
            DownKey = _DownKey;
            FireKey = _FireKey;
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

        public void Update(GameTime time, GraphicsDeviceManager graphics, BulletList Bullets, Pong game)
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
                this.Position.Y = graphics.GraphicsDevice.Viewport.Bounds.Height - this.Size.Y;
            }

            if (newKBState.IsKeyDown(FireKey) && !oldKBState.IsKeyDown(FireKey))
            {
                Vector2 position = this.Position;
                position.X += bulletOffset;
                position.Y = this.Position.Y + (this.Size.Y / 2) - 7;
                Bullets.CreateBullet(position, bulletOffset > 0);
            }

            BulletList toRemove = new BulletList();

            foreach (Bullet bull in Bullets)
            {
                if (this.GetRect().Intersects(bull.GetRect()))
                {
                    ResetReason reason = ResetReason.Meta;

                    if (type == BatType.Player1)
                    {
                        reason = ResetReason.P2Score;
                    }
                    else if (type == BatType.Player2)
                    {
                        reason = ResetReason.P1Score;
                    }

                    game.MainBall.ResetBall(game.GraphicsDevice.Viewport.Bounds, reason);
                    toRemove.Add(bull);
                }
            }

            foreach (Bullet bull in toRemove)
            {
                if (Bullets.Contains(bull))
                {
                    Bullets.Remove(bull);
                }
            }

            oldKBState = newKBState;

            base.Update(time);
        }
    }
}
