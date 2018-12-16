using _2016_Project_2.Library.Entities;
using _2016_Project_2.Library.Enums;
using _2016_Project_2.Library.Network;
using _2016_Project_2.Managers;
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
    public class CharacterSelected : UIBaseElement
    {
        private Dictionary<EnumCharacterModel, UIImage> _modelTextures;

        private Character _character;

        private UIButton _btn_play;
        private UIButton _btn_removeCharacter;

        private UILabel _lbl_nameCharacter;

        public CharacterSelected(Point position, int width, int height)
        {
            Position = position;
            Width = width;
            Height = height;
            Visible = false;
        }

        public void Initialize(GraphicsDeviceManager graphics)
        {
            _modelTextures = new Dictionary<EnumCharacterModel, UIImage>();

            _btn_play = new UIButton(new Point((int)(Position.X + Width * 0.5 - 50), Position.Y + Height), 100, 40, "Play", 36);
            _btn_play.OnGainFocus += (sender, e) =>
            {
                //ManagerNetwork.Instance.SendJoinHub(_character);
            };

            _btn_removeCharacter = new UIButton(new Point((int)(Position.X + 20), Position.Y + Height), 100, 40, "Remove");
            _btn_removeCharacter.OnGainFocus += (sender, e) =>
            {
                //ManagerNetwork.Instance.SendCharacterDelete(_character);
            };

            _lbl_nameCharacter = new UILabel(new Point((int)(Position.X + Width * 0.5 - 50), Position.Y), 100, 40, "", 24);
            _lbl_nameCharacter.TextCentered = true;

            _modelTextures.Add(EnumCharacterModel.MODEL_1, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/AerisA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_2, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/BarretA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_3, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/CaitSithA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_4, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/CidA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_5, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/CloudA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_6, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/NanakiA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_7, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/TifaA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_8, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/VincentA"));
            _modelTextures.Add(EnumCharacterModel.MODEL_9, new UIImage(new Point(Position.X + 50, Position.Y + 50), 400, 400, "Characters/YoufieA"));

            AddChild(_btn_play);
            AddChild(_btn_removeCharacter);
            AddChild(_lbl_nameCharacter);

            foreach(var item in _modelTextures)
            {
                item.Value.Visible = false;
                AddChild(item.Value);
            }
            
        }

        public override void Update(GameTime gameTime)
        {
            if (Visible && _character != null)
            {
                base.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Visible && _character != null)
            {
                base.Draw(gameTime, spriteBatch);
                //var textureHeight = 400;

                //var texture = _modelTextures[_character.Model];

                //var ratio = (double)texture.Width / (double)texture.Height;

                //if (ratio > 1)
                //{
                //    var height = (int)(texture.Height * ((double)Width / texture.Width));
                //    spriteBatch.Draw(texture, new Rectangle((int)(Position.X + 50), (int)(Position.Y + (int)((textureHeight - height) * 0.5) + 50), Width - 100, height), Color.White);
                //}
                //else
                //{
                //    var width = (int)(texture.Width * ((double)textureHeight / texture.Height));

                //    spriteBatch.Draw(texture, new Rectangle((int)(Position.X + (Width - width) * 0.5), (int)(Position.Y + 50), width, textureHeight), Color.White);
                //}

                //_btn_play.Draw(gameTime, spriteBatch);
                //_btn_removeCharacter.Draw(gameTime, spriteBatch);
                //_lbl_nameCharacter.Draw(gameTime, spriteBatch);
            }
        }

        public void SetCharacter(Character character)
        {
            foreach(var item in _modelTextures)
            {
                item.Value.Visible = false;
            }

            _character = character;

            if (character != null)
            {
                _lbl_nameCharacter.Text = character.Name;

                _modelTextures[_character.Model].Visible = true;
            }
        }
    }
}
