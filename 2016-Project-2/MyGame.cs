using _2016_Project_2.Library.Network;
using _2016_Project_2.Managers;
using _2016_Project_2.UI;
using log4net;
using log4net.Config;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace _2016_Project_2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MyGame : Game
    {
        private static MyGame _instance;

        public static MyGame Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MyGame();
                }
                return _instance;
            }
        }

        public ILog Log { get; private set; }

        public GraphicsDeviceManager Graphics;
        public int Width = 1280;
        public int Height = 768;

        private SpriteBatch spriteBatch;
        
        private UILog _lbl_log;
        private UIMenu _menu;
         
        private MouseState _lastMouseState;
        private KeyboardState _lastKeyboardState;

        public MyGame()
        {
            // On récupère le chemin du fichier de config
            var configFile = Directory.GetCurrentDirectory() + @"\log4net.config";

            // On remplace le BasicConfigurator par le XmlConfigurator
            // et on charge la configuration définie dans le fichier log4net.config
            XmlConfigurator.Configure(new FileInfo(configFile));

            Log = LogManager.GetLogger("MyGame");

            Graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            Window.AllowAltF4 = true;
            Window.Title = "";

            Graphics.PreferredBackBufferWidth = Width;
            Graphics.PreferredBackBufferHeight = Height;
            Graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //_lbl_log = new UILog(new Vector2(0, 0), 350, Height);

            ManagerNetwork.Instance.OnNewLogMessage += OnNewLogMessage;

            ManagerNetwork.Instance.Start(false, 14241, "localhost");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

           
#if DEBUG
            ManagerState.Instance.ChangeState(States.EnumState.LOGIN);
#else
            ManagerState.Instance.ChangeState(States.EnumState.LOGIN);
#endif
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            spriteBatch.Dispose();

            ManagerNetwork.Instance.Stop();

            //_lbl_log.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (ManagerPlayer.Instance.Player != null)
            {
                Window.Title = ManagerPlayer.Instance.Player.Username;
            }

            var mouseState = Mouse.GetState();
            var keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            ManagerState.Instance.Update(gameTime);

            ManagerUI.Instance.Update(gameTime);

            //_lbl_log.Update(gameTime);

            _lastMouseState = Mouse.GetState();

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

            ManagerState.Instance.Draw(gameTime, spriteBatch);

            //_lbl_log.Draw(gameTime, spriteBatch);

            ManagerUI.Instance.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void OnNewLogMessage(object sender, LogMessage message)
        {
            switch(message.Type)
            {
                case TypeLog.DEBUG:
                    Log.Debug(message.Message);
                    break;
                case TypeLog.INFO:
                    Log.Info(message.Message);
                    break;
                case TypeLog.WARNING:
                    Log.Warn(message.Message);
                    break;
                case TypeLog.ERROR:
                    Log.Error(message.Message);
                    break;
            }
        }
    }
}
