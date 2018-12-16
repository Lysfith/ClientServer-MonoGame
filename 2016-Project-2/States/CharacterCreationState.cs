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
    public class CharacterCreationState : State
    {
        private int _nbCharacters = 8;
        private CharacterSlot[] _characters;

        private CharacterSelect _characterSelect;
        private UITextBox _txt_name;
        private UIButton _btn_create;
        private UIButton _btn_cancel;

        private UIInfoPopup _popup;

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
            //_popup = new UIInfoPopup(500, 200);
            //_popup.Visible = false;
            //_popup.Text = "Le nom existe déjà";
            //_popup.Modal = true;
            //_popup.OnOk += (sender, e) =>
            //{
            //    _popup.Visible = false;
            //};

            _characterSelect = new CharacterSelect(
                new Point(
                    (int)((graphics.PreferredBackBufferWidth - (int)(graphics.PreferredBackBufferWidth * 0.5 - 100)) * 0.5), 
                    100
                ),
                (int)(graphics.PreferredBackBufferWidth * 0.5 - 100), (int)(graphics.PreferredBackBufferHeight * 0.5));
            _characterSelect.Initialize(graphics);

            _txt_name = new UITextBox(new Point((int)(graphics.PreferredBackBufferWidth * 0.5 - 150), (int)(graphics.PreferredBackBufferHeight * 0.8)), 300, 40);
            _txt_name.MaxSize = 15;

            _btn_create = new UIButton(new Point((int)(graphics.PreferredBackBufferWidth * 0.5 - 50), (int)(graphics.PreferredBackBufferHeight * 0.9)), 100, 40, "Create");
            _btn_create.OnGainFocus += (sender, e) =>
            {
                var character = new Character(_txt_name.Text, _characterSelect.Model);
                //var sended = ManagerNetwork.Instance.SendCharacterCreation(character);
                //_btn_create.ButtonDisabled = sended;
            };

            _btn_cancel = new UIButton(new Point((int)(graphics.PreferredBackBufferWidth * 0.5 + 100), (int)(graphics.PreferredBackBufferHeight * 0.9)), 100, 40, "Cancel");
            _btn_cancel.OnGainFocus += (sender, e) =>
            {
                ManagerState.Instance.ChangeState(EnumState.CHARACTER_SELECT);
            };

            ManagerUI.Instance.AddItem(_characterSelect);
            ManagerUI.Instance.AddItem(_txt_name);
            ManagerUI.Instance.AddItem(_btn_create);
            ManagerUI.Instance.AddItem(_btn_cancel);
        }

        public override void Update(GameTime gameTime)
        {

            _btn_create.ButtonDisabled = _txt_name.Text == string.Empty;

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        #region Events
        public void OnCharacterCreation(object sender, CreateCharacterMessage message)
        {
            //if (player != null)
            //{
            //    ManagerPlayer.Instance.Player = player;
            //    ManagerState.Instance.ChangeState(EnumState.CHARACTER_SELECT);
            //}
            //else
            //{
            //    _btn_create.ButtonDisabled = false;
            //}
        }
        #endregion

    }
}
