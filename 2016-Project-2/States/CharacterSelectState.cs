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
using _2016_Project_2.UI.Advanced;
using _2016_Project_2.Library.Network;

namespace _2016_Project_2.States
{
    public class CharacterSelectState : State
    {
        private int _nbCharacters = 8;
        private CharacterSlot[] _characters;

        private CharacterSelected _characterSelected;

        private UIConfirmPopup _popup;

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
            _characters = new CharacterSlot[_nbCharacters];

            var height = (int)((graphics.PreferredBackBufferHeight - 100)/ _nbCharacters);
            var width = (int)(graphics.PreferredBackBufferWidth * 0.2) - 40;
            var player = ManagerPlayer.Instance.Player;

            for (var i=0; i< _nbCharacters; i++)
            {
                _characters[i] = new CharacterSlot(new Point(20, (int)(50 + i * height)), width, (int)(height * 0.8));
                _characters[i].Initialize(graphics);
                _characters[i].Visible = false;

                _characters[i].OnSelectCharacter += OnSelectCharacter;

                ManagerUI.Instance.AddItem(_characters[i]);
            }

            _characterSelected = new CharacterSelected(
                new Point((int)(MyGame.Instance.Graphics.PreferredBackBufferWidth * 0.2 + MyGame.Instance.Graphics.PreferredBackBufferWidth * 0.15), 100), 
                (int)(MyGame.Instance.Graphics.PreferredBackBufferWidth * 0.5), 
                (int)(MyGame.Instance.Graphics.PreferredBackBufferHeight * 0.7));
            _characterSelected.Initialize(graphics);
            _characterSelected.Visible = false;

            ManagerUI.Instance.AddItem(_characterSelected);

            //Récupération des characters
            var message = new GetCharactersMessage()
            {
                PlayerId = ManagerPlayer.Instance.Player.Id
            };

            ManagerNetwork.Instance.GetCharacters(message);
        }


        public override void Update(GameTime gameTime)
        {
            //foreach (var character in _characters)
            //{
            //    character.Update(gameTime);
            //}


            //_characterSelected.Update(gameTime);

            //_btn_createCharacter.Update(gameTime);
           // _popup.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //foreach (var character in _characters)
            //{
            //    character.Draw(gameTime, spriteBatch);
            //}

            //_characterSelected.Draw(gameTime, spriteBatch);


            ////_btn_createCharacter.Draw(gameTime, spriteBatch);
            //_popup.Draw(gameTime, spriteBatch);
        }

        #region Events

        public void OnSelectCharacter(object sender, Character e)
        {
            foreach (var character in _characters.Where(x => x.Character != null))
            {
                character.LostFocus();
            }

            _characterSelected.SetCharacter(e);
            _characterSelected.Visible = true;
        }

        public override void OnDeleteCharacter(object sender, DeleteCharacterMessage message)
        {
            if (message.Result)
            {
                _characterSelected.Visible = false;
                _characterSelected.SetCharacter(null);

                var characterSlot = _characters.Where(x => x.Character != null && x.Character.Id == message.CharacterId).FirstOrDefault();

                if (characterSlot != null)
                {
                    characterSlot.SetCharacter(null);
                    characterSlot.Visible = true;
                }
            }
        }

        public override void OnGetCharacters(object sender, GetCharactersMessage message)
        {
            if (message.Result)
            {
                ManagerPlayer.Instance.Player.Characters = message.Characters;

                for (var i = 0; i < _nbCharacters; i++)
                {
                    if (message.Characters.Count > i)
                    {
                        _characters[i].SetCharacter(message.Characters.ElementAt(i));
                        
                    }
                    _characters[i].Visible = true;
                }
            }
        }

        public void OnJoinHub(object sender, Library.Entities.Hub e)
        {
            ManagerPlayer.Instance.Hub = e;
            ManagerPlayer.Instance.Player = e.GetPlayer(ManagerPlayer.Instance.Player.Username);

            ManagerState.Instance.ChangeState(EnumState.HUB);
        }

        
        #endregion

    }
}
