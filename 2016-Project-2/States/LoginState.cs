using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using _2016_Project_2.UI;
using _2016_Project_2.Managers;
using _2016_Project_2.Library.Entities;
using _2016_Project_2.Library.Network;
using Lidgren.Network;

namespace _2016_Project_2.States
{
    public class LoginState : State
    {
        private UILabel _lbl_login;
        private UITextBox _txt_login;
        private UILabel _lbl_pass;
        private UITextBox _txt_pass;
        private UIButton _btn_login;
        private UILabel _lbl_serverStatus;
        private UIImage _logo;

        private bool _loginSended = false;
        private DateTime _lastUpdateButton;

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
            _lbl_login = new UILabel(new Point((int)(graphics.PreferredBackBufferWidth * 0.5f - 250), (int)(graphics.PreferredBackBufferHeight * 0.5f + 100)), 100, 40, "Username :");
            _txt_login = new UITextBox(new Point((int)(graphics.PreferredBackBufferWidth * 0.5f - 150), (int)(graphics.PreferredBackBufferHeight * 0.5f +100)), 300, 40);
            _txt_login.MaxSize = 18;

            _lbl_pass = new UILabel(new Point((int)(graphics.PreferredBackBufferWidth * 0.5f - 250), (int)(graphics.PreferredBackBufferHeight * 0.5f + 150)), 100, 40, "Password :");
            _txt_pass = new UITextBox(new Point((int)(graphics.PreferredBackBufferWidth * 0.5f - 150), (int)(graphics.PreferredBackBufferHeight * 0.5f +150)), 300, 40);
            _txt_pass.MaxSize = 18;
            _txt_pass.IsPassword = true;

            _btn_login = new UIButton(new Point((int)(graphics.PreferredBackBufferWidth * 0.5f - 50), (int)(graphics.PreferredBackBufferHeight * 0.5f + 200)), 100, 40,"Login");
            _btn_login.OnGainFocus += (sender, e) =>
                {
                    var message = new LoginMessage()
                    {
                        UserName = _txt_login.Text,
                        Password = _txt_pass.Text
                    };

                    ManagerNetwork.Instance.Login(message);
                    _txt_login.Text = "";
                    _txt_pass.Text = "";
                    _loginSended = true;
                };
            _btn_login.TextCentered = false;
            _btn_login.ButtonDisabled = true;

            _logo = new UIImage(new Point((int)(MyGame.Instance.Graphics.PreferredBackBufferWidth * 0.5f - 250), (int)(MyGame.Instance.Graphics.PreferredBackBufferHeight * 0.5f - 300)), 
                500, 250, "ff7-logo");

            _lbl_serverStatus = new UILabel(new Point(graphics.PreferredBackBufferWidth - 100, 10), 100, 40, "");

            _lastUpdateButton = DateTime.Now;

            ManagerUI.Instance.AddItem(_lbl_login);
            ManagerUI.Instance.AddItem(_txt_login);
            ManagerUI.Instance.AddItem(_lbl_pass);
            ManagerUI.Instance.AddItem(_txt_pass);
            ManagerUI.Instance.AddItem(_btn_login);
            ManagerUI.Instance.AddItem(_lbl_serverStatus);
            ManagerUI.Instance.AddItem(_logo);
        }

        public override void Update(GameTime gameTime)
        {
            //_txt_login.Update(gameTime);
            //_txt_pass.Update(gameTime);
            //_btn_login.Update(gameTime);

            if(_loginSended)
            {
                if(_btn_login.ButtonDisabled && (DateTime.Now - _lastUpdateButton).TotalMilliseconds > 500)
                {
                    var cpt = _btn_login.Text.Count(x => x == '.');

                    _btn_login.Text += ".";

                    if (cpt > 2)
                    {
                        _btn_login.Text = "Login";
                    }

                    _lastUpdateButton = DateTime.Now;
                }
            }

            //_lbl_serverStatus.Text = "Server : " + (ManagerNetwork.Instance.ServerIsOnline ? "On" : "Off");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(_logo, new Rectangle((int)(MyGame.Instance.Graphics.PreferredBackBufferWidth *0.5f - 250), (int)(MyGame.Instance.Graphics.PreferredBackBufferHeight * 0.5f -300), 500, 250), Color.White);

            //_lbl_login.Draw(gameTime, spriteBatch);
            //_txt_login.Draw(gameTime, spriteBatch);
            //_lbl_pass.Draw(gameTime, spriteBatch);
            //_txt_pass.Draw(gameTime, spriteBatch);
            //_btn_login.Draw(gameTime, spriteBatch);

            //_lbl_serverStatus.Draw(gameTime, spriteBatch);
        }


        #region Events
        public override void OnLogin(object sender, LoginMessage message)
        {
            ManagerPlayer.Instance.Player = new Player()
            {
                Username = message.UserName,
                Id = message.PlayerId
            };
            ManagerState.Instance.ChangeState(EnumState.CHARACTER_SELECT);
        }

        public override void OnConnectionConnect(object sender, NetIncomingMessage message)
        {
            _btn_login.Text = "Login";
            _btn_login.ButtonDisabled = false;
        }

        public override void OnConnectionDisconnect(object sender, NetIncomingMessage message)
        {
            _btn_login.ButtonDisabled = true;
        }
        #endregion
    }
}
