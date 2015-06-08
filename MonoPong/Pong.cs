using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoPong.Objects;

namespace MonoPong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Pong : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont ScoreFont;

        Texture2D PaddleTexture;
        Texture2D BallTexture;

        Bat Paddle;
        Bat Paddle2;
        Ball MainBall;

        public Pong()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            this.Window.AllowUserResizing = true;

            this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);

            //Game Objects
            Paddle = new Bat(Keys.W, Keys.S, new Rectangle(40, 350, 15, 100));

            Rectangle paddleRect = new Rectangle(graphics.GraphicsDevice.Viewport.Width - 40, 350, 15, 100);
            Paddle2 = new Bat(paddleRect);

            MainBall = new Ball(new Rectangle(graphics.GraphicsDevice.Viewport.Width/2, graphics.GraphicsDevice.Viewport.Height/2, 15, 15));

            base.Initialize();
        }

        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
            graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ScoreFont = Content.Load<SpriteFont>("ScoreFont");

            PaddleTexture = Content.Load<Texture2D>("Paddle");
            Paddle.texture = PaddleTexture;
            Paddle2.texture = PaddleTexture;

            BallTexture = Content.Load<Texture2D>("ball");
            MainBall.texture = BallTexture;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Paddle.Update(gameTime, graphics);
            Paddle2.Update(gameTime, graphics);
            Paddle2.Position = new Vector2(graphics.GraphicsDevice.Viewport.Width - 40, Paddle2.Position.Y);

            GameObject[] Paddles = {Paddle, Paddle2};

            MainBall.Update(gameTime, graphics, Paddles);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            // TODO: Add your drawing code here
            Paddle.Draw(spriteBatch, gameTime);
            Paddle2.Draw(spriteBatch, gameTime);
            MainBall.Draw(spriteBatch, gameTime);

            Vector2 textPosition = new Vector2((graphics.GraphicsDevice.Viewport.Width / 2) - (ScoreFont.MeasureString(MainBall.score.ToString()).X / 2), 30);

            spriteBatch.DrawString(ScoreFont, MainBall.score.ToString(), textPosition, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
