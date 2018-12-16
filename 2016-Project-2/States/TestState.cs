using _2016_Project_2.Library.Network;
using _2016_Project_2.Managers;
using _2016_Project_2.UI;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.States
{
    public class TestState : State
    {
        private UIWindow _window1;
        private UIWindow _window2;
        private UIWindow _window3;
        private UIWindow _window4;

        public override void Start()
        {
            base.Start();
        }

        public override void End()
        {
            base.End();
        }

        public override void Initialize(GraphicsDeviceManager graphics)
        {
            _window1 = new UIWindow(new Point(100, 100), 200, 200, Color.Blue);
            _window2 = new UIWindow(new Point(150, 150), 200, 200, Color.Red);
            _window3 = new UIWindow(new Point(200, 200), 200, 200, Color.Yellow);
            _window4 = new UIWindow(new Point(250, 250), 200, 200, Color.Green);

            ManagerUI.Instance.AddItem(_window1);
            ManagerUI.Instance.AddItem(_window2);
            ManagerUI.Instance.AddItem(_window3);
            ManagerUI.Instance.AddItem(_window4);

            base.Initialize(graphics);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }


        #region Events

        #endregion
    }
}
