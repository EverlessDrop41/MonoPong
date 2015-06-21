using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoPong.Objects;
using MonoPong.Levels;

namespace MonoPong
{
    public enum GameState
    {
        GenericState,
        MainMenu,
        Playing,
        GameOver
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Pong : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public GameplayLevel gameplay;
        public MainMenu menu;

        public GameState CurrentState = GameState.MainMenu;

        public Pong()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameplay = new GameplayLevel(this);
            menu = new MainMenu(this);
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

            gameplay.Initialize();

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

            gameplay.LoadContent();
            menu.LoadContent();
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

            switch (CurrentState)
            {
                case GameState.MainMenu:
                    menu.Update(gameTime);
                    break;
                case GameState.Playing:
                    gameplay.Update(gameTime);
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            switch (CurrentState)
            {
                case GameState.MainMenu:
                    menu.Draw(gameTime);
                    break;
                case GameState.Playing:
                    gameplay.Draw(gameTime);
                    break;
            }

            base.Draw(gameTime);
        }

        public void SwitchLevel(GameState state)
        {
            CurrentState = state;
        }
    }
}
