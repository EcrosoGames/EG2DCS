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
            Globals.Graphics = new GraphicsDeviceManager(this);
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
            Globals.GameSize = new Vector2(1280, 720);
            Globals.Graphics.PreferredBackBufferWidth = (int)Globals.GameSize.X;
            Globals.Graphics.PreferredBackBufferHeight = (int)Globals.GameSize.Y;
            Globals.BackBuffer = new RenderTarget2D(Globals.Graphics.GraphicsDevice, (int)Globals.GameSize.X, (int)Globals.GameSize.Y, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.PreserveContents);
            Globals.Graphics.SynchronizeWithVerticalRetrace = true;
            this.IsFixedTimeStep = true;
            Globals.Graphics.ApplyChanges();
            Globals.Debugging = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.Content = this.Content;
            Textures.Load();
            Sounds.Load();
            Fonts.Load();
            ScreenManager = new ScreenManager();
            //Add screens here



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
            Globals.WindowFocused = this.IsActive;
            Globals.GameTime = gameTime;
            ScreenManager.Update();
            //Input.Update();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Globals.Graphics.GraphicsDevice.SetRenderTarget(Globals.BackBuffer);
            Globals.Graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
            ScreenManager.Draw();
            Globals.Graphics.GraphicsDevice.SetRenderTarget(null);
            Globals.SpriteBatch.Begin();
            Globals.SpriteBatch.Draw(Globals.BackBuffer, new Rectangle(0, 0, Globals.Graphics.GraphicsDevice.Viewport.Width, Globals.Graphics.GraphicsDevice.Viewport.Height), new Color(255,255,255));
            Globals.SpriteBatch.End();
        }
    }
}
