using _2016_Project_2.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.Managers
{
    public class ManagerState
    {
        private static ManagerState _instance;

        public static ManagerState Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManagerState();
                }
                return _instance;
            }
        }

        private Dictionary<EnumState, State> _states;
        private State _stateActive;
        private EnumState? _stateAsked;

        public ManagerState()
        {
            _states = new Dictionary<EnumState, State>();
            _states.Add(EnumState.LOGIN, new LoginState());
            _states.Add(EnumState.CHARACTER_SELECT, new CharacterSelectState());
            _states.Add(EnumState.CHARACTER_CREATION, new CharacterCreationState());
            _states.Add(EnumState.HUB, new HubState());
            _states.Add(EnumState.TEST, new TestState());
        }

        public void ChangeState(EnumState state)
        {
            _stateAsked = state;
        }

        public void Update(GameTime gameTime)
        {
            if (_stateAsked.HasValue)
            {
                if (_stateActive != null)
                {
                    ManagerUI.Instance.Clear();
                    _stateActive.End();
                }

                _stateActive = GetState(_stateAsked.Value);

                _stateActive.Start();
                _stateActive.Initialize(MyGame.Instance.Graphics);

                _stateAsked = null;
            }

            if (_stateActive != null)
            {
                _stateActive.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            if (_stateActive != null)
            {
                _stateActive.Draw(gameTime, spriteBatch);
            }
        }

        public State GetState(EnumState type)
        {
            State newState = null;

            switch(type)
            {
                case EnumState.LOGIN:
                    newState = new LoginState();
                    break;
                case EnumState.CHARACTER_SELECT:
                    newState = new CharacterSelectState();
                    break;
                case EnumState.CHARACTER_CREATION:
                    newState = new CharacterCreationState();
                    break;
                case EnumState.HUB:
                    newState = new HubState();
                    break;
                case EnumState.GAME:
                    
                    break;
                case EnumState.TEST:
                    newState = new TestState();
                    break;
            }

            return newState;
        }
    }
}
