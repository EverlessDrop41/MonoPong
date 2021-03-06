﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

using MonoPong;
using MonoPong.Objects;

namespace MonoPong.Levels
{
    public class GameplayLevel : Level
    {
        SpriteFont ScoreFont;

        Texture2D PaddleTexture;
        Texture2D BallTexture;

        SoundEffect BeepEffect;
        SoundEffect ShootEffect;

        public BulletList Bullets = new BulletList();

        Bat Paddle;
        Bat Paddle2;
        public Ball MainBall;

        public GameplayLevel (Pong game) : base(game) { }

        public override void Initialize()
        {
            //Game Objects
            Paddle = new Bat(Keys.W, Keys.S, Keys.LeftShift, new Rectangle(40, 350, 15, 100));
            Paddle.type = BatType.Player1;

            Rectangle paddleRect = new Rectangle(this.Game.graphics.GraphicsDevice.Viewport.Width - 40, 350, 15, 100);
            Paddle2 = new Bat(paddleRect);

            Paddle2.bulletOffset = -15;
            Paddle2.type = BatType.Player2;

            MainBall = new Ball(new Rectangle(this.Game.graphics.GraphicsDevice.Viewport.Width / 2, this.Game.graphics.GraphicsDevice.Viewport.Height / 2, 15, 15));
            MainBall.game = this.Game;

            base.Initialize();
        }

        public override void LoadContent()
        {
            ScoreFont = Game.Content.Load<SpriteFont>("ScoreFont");

            BeepEffect = Game.Content.Load<SoundEffect>("Beep2");
            MainBall.BeepEffect = BeepEffect;

            ShootEffect = Game.Content.Load<SoundEffect>("laser5");
            Paddle.ShootEffect = ShootEffect;
            Paddle2.ShootEffect = ShootEffect;

            PaddleTexture = Game.Content.Load<Texture2D>("Paddle");
            Paddle.texture = PaddleTexture;
            Paddle2.texture = PaddleTexture;
            Bullets.Texture = PaddleTexture;

            BallTexture = Game.Content.Load<Texture2D>("ball");
            MainBall.texture = BallTexture;
        }

        public override void Update(GameTime gameTime)
        {
            Paddle.Update(gameTime, this.Game.graphics, Bullets, this.Game);
            Paddle2.Update(gameTime, this.Game.graphics, Bullets, this.Game);
            Paddle2.Position = new Vector2(this.Game.graphics.GraphicsDevice.Viewport.Width - 40, Paddle2.Position.Y);

            Bat[] Paddles = { Paddle, Paddle2 };

            foreach (Bullet bull in Bullets)
            {
                bull.Update(gameTime);
            }

            MainBall.Update(gameTime, this.Game.graphics, Paddles);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.Game.GraphicsDevice.Clear(Color.Black);

            SpriteBatch spriteBatch = this.Game.spriteBatch;

            this.Game.spriteBatch.Begin();

            // TODO: Add your drawing code here
            Paddle.Draw(spriteBatch, gameTime);
            Paddle2.Draw(spriteBatch, gameTime);
            MainBall.Draw(spriteBatch, gameTime);

            Vector2 textPosition = new Vector2((this.Game.graphics.GraphicsDevice.Viewport.Width / 2) - (ScoreFont.MeasureString(MainBall.score.ToString()).X / 2), 30);

            spriteBatch.DrawString(ScoreFont, MainBall.score.ToString(), textPosition, Color.White);

            spriteBatch.DrawString(ScoreFont, Paddle.ammo.ToString(), new Vector2(15, 15), Color.White);

            int Paddle2Length = (int)ScoreFont.MeasureString(Paddle2.ammo.ToString()).Length();
            Console.WriteLine(Paddle2Length);
            spriteBatch.DrawString(ScoreFont, Paddle2.ammo.ToString(), new Vector2((this.Game.graphics.GraphicsDevice.Viewport.Width - Paddle2Length) , 15), Color.White);

            foreach (Bullet bull in Bullets)
            {
                spriteBatch.Draw(bull.texture, bull.GetRect(), Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
