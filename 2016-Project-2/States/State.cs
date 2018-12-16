using _2016_Project_2.Library.Network;
using _2016_Project_2.Managers;
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
    public class State : IState
    {
        public virtual void Start()
        {
            ManagerNetwork.Instance.OnConnectionConnect += OnConnectionConnect;
            ManagerNetwork.Instance.OnConnectionDisconnect += OnConnectionDisconnect;
            ManagerNetwork.Instance.OnDisconnect += OnDisconnect;
            ManagerNetwork.Instance.OnLogout += OnLogout;
            ManagerNetwork.Instance.OnLogin += OnLogin;
            ManagerNetwork.Instance.OnCreateCharacter += OnCreateCharacter;
            ManagerNetwork.Instance.OnDeleteCharacter += OnDeleteCharacter;
            ManagerNetwork.Instance.OnGetCharacter += OnGetCharacter;
            ManagerNetwork.Instance.OnGetCharacters += OnGetCharacters;
            ManagerNetwork.Instance.OnNewLogMessage += OnNewLogMessage;

        }

        public virtual void End()
        {
            ManagerNetwork.Instance.OnConnectionConnect -= OnConnectionConnect;
            ManagerNetwork.Instance.OnConnectionDisconnect -= OnConnectionDisconnect;
            ManagerNetwork.Instance.OnDisconnect -= OnDisconnect;
            ManagerNetwork.Instance.OnLogout -= OnLogout;
            ManagerNetwork.Instance.OnLogin -= OnLogin;
            ManagerNetwork.Instance.OnCreateCharacter -= OnCreateCharacter;
            ManagerNetwork.Instance.OnDeleteCharacter -= OnDeleteCharacter;
            ManagerNetwork.Instance.OnGetCharacter -= OnGetCharacter;
            ManagerNetwork.Instance.OnGetCharacters -= OnGetCharacters;
            ManagerNetwork.Instance.OnNewLogMessage -= OnNewLogMessage;
        }

        public virtual void Initialize(GraphicsDeviceManager graphics)
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        #region Events
        public virtual void OnConnectionConnect(object sender, NetIncomingMessage message)
        {

        }

        public virtual void OnConnectionDisconnect(object sender, NetIncomingMessage message)
        {
  
        }

        public virtual void OnDisconnect(object sender, DisconnectMessage message)
        {
            ManagerState.Instance.ChangeState(EnumState.LOGIN);
        }

        public virtual void OnLogin(object sender, LoginMessage message)
        {
            
        }

        public virtual void OnLogout(object sender, LogoutMessage message)
        {
            ManagerState.Instance.ChangeState(EnumState.LOGIN);
        }

        public virtual void OnCreateCharacter(object sender, CreateCharacterMessage message)
        {

        }

        public virtual void OnDeleteCharacter(object sender, DeleteCharacterMessage message)
        {

        }

        public virtual void OnGetCharacter(object sender, GetCharacterMessage message)
        {

        }

        public virtual void OnGetCharacters(object sender, GetCharactersMessage message)
        {

        }

        public virtual void OnNewLogMessage(object sender, LogMessage message)
        {

        }
        #endregion
    }
}
