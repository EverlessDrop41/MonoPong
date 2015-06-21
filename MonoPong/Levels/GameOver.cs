using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoPong.Levels
{
    public class GameOver : Level
    {
        SpriteFont Font;
        private const string BASE_MSG = "{0} Wins!\nPress Enter To Restart";
        private string Message = BASE_MSG;

        public GameOver(Pong game) : base(game) { }

        public override void LoadContent()
        {
            Font = Game.Content.Load<SpriteFont>("ScoreFont");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState kbd = Keyboard.GetState();

            if (kbd.IsKeyDown(Keys.Enter))
            {
                Game.SwitchLevel(GameState.Playing, new string[0]);
            }

            base.Update(gameTime);
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);

            SpriteBatch sb = this.Game.spriteBatch;

            Vector2 msgPosition = new Vector2((this.Game.graphics.GraphicsDevice.Viewport.Width / 2) - (Font.MeasureString(Message).X / 2),
                this.Game.graphics.GraphicsDevice.Viewport.Height / 2 - (Font.MeasureString(Message).Y / 2));

            sb.Begin();

            sb.DrawString(Font, Message, msgPosition, Color.White);

            sb.End();

            base.Draw(gameTime);
            base.Draw(gameTime);
        }

        public void SetMessage(string Player)
        {
            Message = String.Format(BASE_MSG, Player);
        }
    }
}
