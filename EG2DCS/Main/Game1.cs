using EG2DCS.Engine.Blanks;
using EG2DCS.Engine.Globals;
using EG2DCS.Engine.Screen_Manager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace EG2DCS
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        ScreenManager ScreenManager;
        public Game1()
        {
            Universal.Graphics = new GraphicsDeviceManager(this);
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
            this.IsMouseVisible = true;
            Universal.GameSize = new Vector2(1280, 720);
            Universal.Graphics.PreferredBackBufferWidth = (int)Universal.GameSize.X;
            Universal.Graphics.PreferredBackBufferHeight = (int)Universal.GameSize.Y;
            Universal.BackBuffer = new RenderTarget2D(Universal.Graphics.GraphicsDevice, (int)Universal.GameSize.X, (int)Universal.GameSize.Y, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents);
            Universal.Graphics.SynchronizeWithVerticalRetrace = true;
            this.IsFixedTimeStep = true;
            Universal.Graphics.ApplyChanges();
            Universal.Debugging = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Universal.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Universal.Content = this.Content;
            Textures.Load();
            Sounds.Load();
            Fonts.Load();
            ScreenManager = new ScreenManager();
            //Add screens here           
            ScreenManager.RegisterScreen(new Gametest());
            ScreenManager.SetActive("game_test");

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
            base.Update(gameTime);
            Universal.WindowFocused = this.IsActive;
            Universal.GameTime = gameTime;
            ScreenManager.Update();
            Input.Update();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Universal.SpriteBatch.Begin();
            base.Draw(gameTime);
            ScreenManager.Draw();
            Universal.SpriteBatch.End();
        }
    }
}
