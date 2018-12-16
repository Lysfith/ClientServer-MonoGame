using _2016_Project_2.Library.Entities;
using _2016_Project_2.Managers;
using _2016_Project_2.States;
using _2016_Project_2.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_2.UI.Advanced
{
    public class CharacterSlot : UIBaseElement
    {
        private UIWindow _windowGrey;
        private UIWindow _windowBlue;
        private UIWindow _windowYellow;

        private UIButton _btn_createCharacter;
        private UIButton _btn_nameCharacter;

        public Character Character;

        public event EventHandler<Character> OnSelectCharacter;

        public CharacterSlot(Point position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;
            Visible = true;
        }

        public void Initialize(GraphicsDeviceManager graphics)
        {
            _btn_createCharacter = new UIButton(Position, Width, Height, "Create Character");
            _btn_createCharacter.Visible = false;
            _btn_createCharacter.OnGainFocus += (sender, e) =>
            {
                ManagerState.Instance.ChangeState(EnumState.CHARACTER_CREATION);
            };
            _btn_createCharacter.Visible = false;

            _btn_nameCharacter = new UIButton(Position, Width, Height, "");
            _btn_nameCharacter.OnGainFocus += (sender, e) =>
            {
                
                if (OnSelectCharacter != null)
                {
                    OnSelectCharacter(this, Character);
                }
                _windowBlue.Visible = false;
                _windowGrey.Visible = false;
                _windowYellow.Visible = true;


            };
            _btn_nameCharacter.Visible = false;

            _windowGrey = new UIWindow(Position, Width, Height, new Color(80, 80, 80));
            _windowGrey.OnHoverStart += (sender, e) =>
            {
                var window = ((UIWindow)sender);

                _btn_createCharacter.Visible = true;
            };
            _windowGrey.OnHoverEnd += (sender, e) =>
            {
                _btn_createCharacter.Visible = false;
            };
            _windowGrey.Visible = true;

            _windowBlue = new UIWindow(Position, Width, Height, new Color(0, 0, 173));
            _windowBlue.Visible = false;

            _windowYellow = new UIWindow(Position, Width, Height, Color.DarkGoldenrod);
            _windowYellow.Visible = false;

            AddChild(_windowGrey);
            AddChild(_windowBlue);
            AddChild(_windowYellow);
            AddChild(_btn_createCharacter);
            AddChild(_btn_nameCharacter);
        }

        public override void Update(GameTime gameTime)
        {
            if (Enable && Visible)
            {
                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Enable && Visible)
            {
                base.Draw(gameTime, spriteBatch);
            }
        }

        public void SetCharacter(Character character)
        {
            Character = character;

            if (character != null)
            {
                _windowBlue.Visible = true;
                _windowGrey.Visible = false;
                _windowYellow.Visible = false;

                _btn_nameCharacter.Text = character.Name;
                _btn_nameCharacter.Visible = true;
            }
            else
            {
                _windowBlue.Visible = false;
                _windowGrey.Visible = true;
                _windowYellow.Visible = false;

                _btn_nameCharacter.Visible = false;
            }
        }

        public void LostFocus()
        {
            _windowBlue.Visible = true;
            _windowGrey.Visible = false;
            _windowYellow.Visible = false;
        }
    }
}
