using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoPong.Levels
{
    public class MainMenu : Level
    {
        SpriteFont Font;
        SpriteFont Title;

        public MainMenu(Pong game) : base (game) { }

        public override void LoadContent()
        {
            Font = Game.Content.Load<SpriteFont>("ScoreFont");
            Title = Game.Content.Load<SpriteFont>("TitleFont");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState kbd = Keyboard.GetState();

            if (kbd.IsKeyDown(Keys.Enter))
            {
                Game.SwitchLevel(GameState.Playing);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game.GraphicsDevice.Clear(Color.Black);

            SpriteBatch sb = this.Game.spriteBatch;

            Vector2 msgPosition = new Vector2((this.Game.graphics.GraphicsDevice.Viewport.Width / 2) - (Font.MeasureString("Press Enter To Play").X / 2),
                (this.Game.graphics.GraphicsDevice.Viewport.Height / 4) * 3);

            Vector2 TitlePosition = new Vector2((this.Game.graphics.GraphicsDevice.Viewport.Width / 2) - (Font.MeasureString("Battle Pong").X * 1.9f),
                (this.Game.graphics.GraphicsDevice.Viewport.Height / 4));

            sb.Begin();

            sb.DrawString(Title, "Battle Pong", TitlePosition, Color.White);
            sb.DrawString(Font, "Press Enter To Play", msgPosition, Color.White);

            sb.End();

            base.Draw(gameTime);
        }
    }
}
